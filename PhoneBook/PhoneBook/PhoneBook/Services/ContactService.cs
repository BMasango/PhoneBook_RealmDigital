using PhoneBook.Enums;
using PhoneBook.Models;
using PhoneBook.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services
{
    public partial class DataStoreService : IDataStoreService
    {
        public List<ContactDetailDto> GetAllContactDetails()
        {
            return DataStore.Instance.GetAll().ToList();
        }

        public void InsertNewContact(ContactDetailDto contactDetail)
        {
            try
            {
                int result = DataStore.Instance.Insert(contactDetail as ContactDetail);
                if (result > 0)
                {
                    InsertNewDialUpContact(contactDetail.DialUpContacts, result);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateContactDetails(ContactDetailDto contacts)
        {
            DataStore.Instance.Update(contacts as ContactDetail);
            contacts.DialUpContacts.ForEach(x => UpdateDialUpContact(x));
        }

        public void DeleteContactDetails(ContactDetailDto contacts)
        {
            contacts.DialUpContacts.ForEach(x => DeleteDialUpContact(x));
            DataStore.Instance.Delete(contacts);
        }
    }
}
