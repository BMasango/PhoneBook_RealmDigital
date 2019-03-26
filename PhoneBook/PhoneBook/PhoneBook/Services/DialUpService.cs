using PhoneBook.Models;
using PhoneBook.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services
{
    public partial class DataStoreService: IDataStoreService
    {
        public void InsertNewDialUpContact(List<DialUpContact> dialUpContact, int linkedContactId = 0)
        {
            foreach (DialUpContact dial in dialUpContact)
            {
                if (linkedContactId > 0) dial.ContactDetailId = linkedContactId;
                DataStore.Instance.Insert(dial);
            }
        }

        public void UpdateDialUpContact(DialUpContact dialUpContacts)
        {
            DataStore.Instance.Update(dialUpContacts);
        }

        public void DeleteDialUpContact(DialUpContact dialUpContacts)
        {
            DataStore.Instance.Delete(dialUpContacts);
        }
    }
}
