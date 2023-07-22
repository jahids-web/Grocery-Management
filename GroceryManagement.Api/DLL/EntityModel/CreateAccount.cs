using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EntityModel
{
    public class CreateAccount
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        public int PhoneNumber { get; set; }   

        [Required]
        public string Password { get; set; }

    }
}
