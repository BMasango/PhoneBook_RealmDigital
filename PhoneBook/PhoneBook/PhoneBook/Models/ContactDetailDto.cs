using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Models
{
    public class ContactDetailDto: ContactDetail
    {
        public List<DialUpContact> DialUpContacts { get; set; } = new List<DialUpContact>();

        public string DisplayName
        {
            get {
                return !string.IsNullOrEmpty(LastName) && !string.IsNullOrEmpty(FirstName) ? $"{LastName}, {FirstName}"
                    : $"{LastName}{FirstName}";
            }
        }
    }
}
