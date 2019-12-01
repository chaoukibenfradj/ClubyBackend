using System.ComponentModel.DataAnnotations;

namespace clubyApi.Models
{
    public class Authentification
    {
        [Required]
        
        [DataType(DataType.EmailAddress)]
        public string Email{ get;set;}
        [Required]
        public string Password{ get ; set;}
    }
}