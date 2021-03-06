using System.Collections.Generic;
using System.Linq;
using DatingApp.API.Models;
using Newtonsoft.Json;

namespace DatingApp.API.Data
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            _context = context;
            
        }

        public void SeedUsers(){
            if(_context.Users.Count() == 0){
            var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
            List<User> users = JsonConvert.DeserializeObject<List<User>>(userData);
            foreach (User user in users)
            {
                byte[] passwordHash, passwordSalt;
                CreateHashPassword("password", out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Username = user.Username.ToLower();

                _context.Users.Add(user);
            }
            _context.SaveChanges();
            }
        }
        private void CreateHashPassword(string password, out byte[] passwordHash, out byte[] paswordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512()){
                paswordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}