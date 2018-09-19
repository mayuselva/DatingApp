using System;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            this._context = context;

        }
        public async Task<User> Login(string uname, string pwd)
        {
            var user  =await  _context.Users.FirstOrDefaultAsync(x => x.Username == uname);

            if(user == null)
                return null;

            if(!VerifyPasswordHash(pwd,user.PasswordHash,user.PasswordSalt))
                return null;

            return user;
        }

        private bool VerifyPasswordHash(string pwd, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)){
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pwd));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if(computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, paswordSalt;
            CreateHashPassword(password, out passwordHash ,out  paswordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = paswordSalt ; 

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreateHashPassword(string password, out byte[] passwordHash, out byte[] paswordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512()){
                paswordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string uname)
        {
            if(await _context.Users.AnyAsync(x => x.Username == uname))
                return true;

            return false;
        }
    }
}