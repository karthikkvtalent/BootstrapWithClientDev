using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BootstrapWithClientDev.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Enter Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Enter Password")]
        public String  Password { get; set; }
    }
}