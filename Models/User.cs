using System.ComponentModel.DataAnnotations;

namespace clubyApi.Models
{
    public class User
    {
        [Required (ErrorMessage = "Firstname is required")]

        public string FirstName{ get;set;}
        [Required (ErrorMessage = "Lastname is required")]
        public string LastName{ get;set;}
        
        [Required (ErrorMessage = "Email is required")]
        
        [DataType(DataType.EmailAddress)]
        public string Email{ get;set;}
        [Required (ErrorMessage = "Password is required")]
        public string Password{ get ; set;}


    }
}