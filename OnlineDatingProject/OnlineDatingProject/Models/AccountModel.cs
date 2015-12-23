using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OnlineDatingProject.Models
{
    public class AccountModel
    {
        [Key]
        public int UserID { get; set; }

        [RegularExpression(@"^ ([a - zA - Z0 - 9_\-\.] +)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter your email address.")]
        public string Email { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = " The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = " The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Username")]
        public string Username { get; }

        [Required]
        [Display(Name = "Gender")]
        public bool Gender { get; set; }

        [Required(ErrorMessage = "Please enter your birthdate in the format YYYYMMDD.")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Birthdate")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "Please enter your current city of residence.")]
        [Display(Name = "City")]
        public int City { get; set; }
    }
}