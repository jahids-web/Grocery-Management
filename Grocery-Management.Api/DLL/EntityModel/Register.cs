using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EntityModel
{
    public class Register
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        public string Email { get; set; }
        public string Address { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<Login> Logins { get; set; }

    }
}
