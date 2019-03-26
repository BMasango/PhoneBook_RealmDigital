using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Models
{
    public class ContactDetail: BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
