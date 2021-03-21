using System;
using System.ComponentModel.DataAnnotations;

namespace GreetingAppLoginModel1
{
    public class EmployeeLogin
    {
        [Required(ErrorMessage = "Enter Your Mail ID")]
        [RegularExpression(@"^[1-9A-Za-z]+[.][a-zA-Z]*@(bl)[.](co)([.](in))?$", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Your Password")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[0-9])(?=.*[@$!_%*#?&]{1})[a-zA-Z0-9@$!_%*#?&]{8,}$", ErrorMessage = "Not a Password")]
        public string Password { get; set; }
    }
}
