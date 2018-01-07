using Microsoft.AspNetCore.Identity;
using NetCore2CustomIdentityMySQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore2CustomIdentityMySQL.Data.Repository
{
    public class UsersRepo
    {
        private ApplicationDbContext _context { get; set; }

        public UsersRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        private ApplicationUser Map(Users user)
        {
            return new ApplicationUser()
            {
                Id = user.id,
                Email = user.email,
                PasswordHash = user.password,
                EmailConfirmed = user.emailconfirmed,
                UserName = user.email,
                IsAuthenticated = true
            };
        }

        public IdentityResult Create(ApplicationUser user)
        {
            var customUser = new Users()
            {
                email = user.Email.ToLower(),
                emailconfirmed = user.EmailConfirmed,
                password = user.PasswordHash,
                username = user.Email.ToLower()
            };
            _context.Users.Add(customUser);
            var rows = _context.SaveChanges();
            if (rows > 0)
            {
                user.Id = customUser.id;
                return IdentityResult.Success;
            }

            return IdentityResult.Failed(new IdentityError { Description = "Create user failed." });
        }

        public IdentityResult Update(ApplicationUser user)
        {
            var temp = _context.Users.Find(user.Id);
            temp.email = user.Email.ToLower();
            temp.emailconfirmed = user.EmailConfirmed;
            temp.password = user.PasswordHash;
            temp.username = user.Email.ToLower();

            var rows = _context.SaveChanges();
            if (rows > 0)
            {
                return IdentityResult.Success;
            }

            return IdentityResult.Failed(new IdentityError { Description = "Update user failed." });
        }

        public ApplicationUser FindById(int userId)
        {
            var user = Get(userId);
            if (user == null)
                return null;
            return Map(user);

        }

        public ApplicationUser FindByMail(string email)
        {
            var user = Get(email);
            if (user == null)
                return null;
            return Map(user);
        }

        public Users Get(int id)
        {
            var user = _context.Users.FirstOrDefault(m => m.id == id);
            return user;
        }

        public Users Get(string email)
        {
            var user = _context.Users.FirstOrDefault(m => m.email == email.ToLower());
            return user;
        }

        public List<Users> GetAll()
        {
            return _context.Users.ToList();
        }
    }
}
