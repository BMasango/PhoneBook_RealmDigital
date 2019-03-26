using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services.Interfaces
{
    public partial interface IDataStoreService
    {
        List<ContactDetailDto> GetAllContactDetails();
        void InsertNewContact(ContactDetailDto contactDetail);
        void UpdateContactDetails(ContactDetailDto contacts);
        void DeleteContactDetails(ContactDetailDto contacts);
    }
}
