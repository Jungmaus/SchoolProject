using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolProject.Model.VM
{
    public class UserVM
    {
        public int ID { get; set; }

        [MaxLength(25),Required]
        public string Name { get; set; }

        [MaxLength(25), Required]
        public string Surname { get; set; }

        [MaxLength(50), Required]
        public string Email { get; set; }

        [MaxLength(25), Required]
        public string Password { get; set; }

        [Required]
        public int AccountType { get; set; }
    }
}