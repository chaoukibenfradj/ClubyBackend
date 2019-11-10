using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace clubyApi.Utils{
    public  class HashPassword{
          
          public HashPassword(){

          } 
          public  string HashedPass(string password){
             byte[] salt = new byte[20];
             
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
                return hashed;
        }
    }
}