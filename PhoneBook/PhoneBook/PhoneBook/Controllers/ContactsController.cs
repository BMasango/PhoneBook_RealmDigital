using Microsoft.AspNetCore.Mvc;
using PhoneBook.Controllers.Base;
using PhoneBook.Models;
using PhoneBook.Services.Interfaces;

namespace PhoneBook.Controllers
{
    public class ContactsController:BaseController
    {
        private IDataStoreService _DataStoreService;

        public ContactsController(IDataStoreService dataStoreService)
        {
            _DataStoreService = dataStoreService;
        }

        [HttpGet()]
        public JsonResult GetAllContactDetails()
        {
            return new JsonResult(_DataStoreService.GetAllContactDetails());
        }
        
        public void AddContactDetials(ContactDetailDto contact)
        {
            _DataStoreService.InsertNewContact(contact);
        }
        
        public void DeleteContactDetails(ContactDetailDto contact)
        {
            _DataStoreService.DeleteContactDetails(contact);
        }
        
        public void UpdateContactDetails(ContactDetailDto contact)
        {
            _DataStoreService.UpdateContactDetails(contact);
        }
    }
}
