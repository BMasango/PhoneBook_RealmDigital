using PhoneBook.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Models
{
    public class DialUpContact: BaseModel
    {
        public int ContactDetailId { get; set; }
        public string Contact { get; set; }
        public DialType DialUpType { get; set; }
    }
}
