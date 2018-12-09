using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Model.VM
{
    public class GetUserVM
    {
        [MaxLength(50), Required]
        public string Email { get; set; }

        [MaxLength(25), Required]
        public string Password { get; set; }
    }
}
