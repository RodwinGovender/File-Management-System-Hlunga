using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCLogin.Models
{
    public class UserAccount
    {

        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage ="First Name is required")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public String LastName { get; set; }
        
        [Required(ErrorMessage = "Username is required")]
        public String Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public String Password { get; set; }


        public bool IsAdmin { get; set; } 
    }
}