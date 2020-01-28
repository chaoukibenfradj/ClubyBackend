using System.Collections.Generic;

namespace ClubyBackend.Models
{
    public class UpdateDto
    {
        public string Id{ get;set;} 
             
        public string FirstName{ get;set;}

        public string LastName{ get;set;}
        
        public string Password{ get ; set;}

        public string Institute{ get ; set;}

        public string Photo{ get;set;}
         public string Description{ get;set;}
        public string Name{ get;set;}
         public string Domain{ get;set;}


        public string Entreprise{ get ; set;}
        public  List<string> Interests {get;set;}
    }
}