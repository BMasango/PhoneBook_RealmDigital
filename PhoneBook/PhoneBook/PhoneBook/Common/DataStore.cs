using Dapper;
using PhoneBook.Models;
using PhoneBook.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services
{
    public class DataStore
    {
        private readonly string connString = @"Data Source=RRT00048\SQLEXPRESS;Initial Catalog=PhoneBook;Integrated Security=True";
        public static DataStore Instance { get; } = new DataStore();

        public IEnumerable<ContactDetailDto> GetAll()
        {
            var lookup = new Dictionary<int, ContactDetailDto>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Query<ContactDetailDto, DialUpContact, ContactDetailDto>("spGetAllContactDetails", 
                    (x, y) => {
                        ContactDetailDto contactDetail;
                        if (!lookup.TryGetValue(x.Id, out contactDetail))
                        {
                            contactDetail = x;
                            lookup.Add(contactDetail.Id, contactDetail);
                        }

                        contactDetail.DialUpContacts.Add(y);
                        return contactDetail;
                    },
                    splitOn: "Id",
                    commandType: System.Data.CommandType.StoredProcedure);
                return lookup.Values;
            }
        }

        public int Insert<T>(T item) where T: BaseModel
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                var tbl = typeof(T).Name.ToString();
                var columns = typeof(T).GetProperties().Select(x => x.Name).Where(x => x != "Id").ToArray();
                var insertColumns = string.Join(",", columns);
                var values = string.Join(",", columns.Select(x => "@" + x).ToArray());
                var query = $"INSERT INTO {tbl}({insertColumns}) VALUES({values}); SELECT CAST(SCOPE_IDENTITY() as int) as Id, @@RowCount";

                return (int)(conn.Query<dynamic>(query, item).FirstOrDefault() as IDictionary<string, object>)["Id"];
            }
        }

        public void Update<T>(T item) where T: BaseModel
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                var tbl = typeof(T).Name.ToString();
                var columns = typeof(T).GetProperties().Select(x => x.Name).ToArray();
                var setStatement = string.Join(",", columns.Select(x => x + " = @" + x).ToArray()).Replace(",Id = @Id", null);
                string query = $"UPDATE {tbl} SET {setStatement} WHERE {tbl}Id = {item.Id}";
                conn.Execute(query, item);
            }
        }

        public void Delete<T>(T item) where T: BaseModel
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                var tbl = typeof(T).Name.ToString();
                string query = $"DELETE FROM {tbl} WHERE {tbl}Id = {item.Id}";
                conn.Execute(query, conn);
            }
        }
    }
}
