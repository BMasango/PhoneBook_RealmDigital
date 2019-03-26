using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services.Interfaces
{
    public partial interface IDataStoreService
    {
        void InsertNewDialUpContact(List<DialUpContact> dialUpContact, int linkedContactId = 0);
        void UpdateDialUpContact(DialUpContact dialUpContacts);
        void DeleteDialUpContact(DialUpContact dialUpContacts);
    }
}
