using PhoneBook.Controllers.Base;
using PhoneBook.Models;
using PhoneBook.Services.Interfaces;
using System.Collections.Generic;

namespace PhoneBook.Controllers
{
    public class DialUpController : BaseController
    {
        private IDataStoreService _DataStoreService;

        public DialUpController(IDataStoreService dataStoreService)
        {
            _DataStoreService = dataStoreService;
        }

        public void AddNewDialUpContact(List<DialUpContact> dialUpContact)
        {
            _DataStoreService.InsertNewDialUpContact(dialUpContact);
        }

        public void UpdateDialUpContact(DialUpContact dialUpContact)
        {
            _DataStoreService.UpdateDialUpContact(dialUpContact);
        }

        public void DeleteDialUpContact(DialUpContact dialUpContact)
        {
            _DataStoreService.DeleteDialUpContact(dialUpContact);
        }
    }
}
