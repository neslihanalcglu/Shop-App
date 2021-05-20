using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Models
{
    public class RegisterModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)] //parola değerlerini görmemek için
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")] //eşitlik kontrolü için
        public string RePassword { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)] //mail formatına uygunluk kontrolü
        public string Email { get; set; }
    }
}
