﻿using ECommerceSite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSite.Data
{
    public class DataInitializer
    {
        private readonly ECommerceDBContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public DataInitializer(ECommerceDBContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public void SeedData()
        {
            _dbContext.Database.Migrate(); 
                                           
            SeedRoles();
            SeedUsers();
        }

        

        private void SeedUsers()
        {
            AddUserIfNotExists("test.tester@testing.com", "Hejsan123#", new string[] { "Customer" });
        }

        private void SeedRoles()
        {
            AddRoleIfNotExisting("Customer");
        }

        private void AddRoleIfNotExisting(string roleName)
        {
            var role = _dbContext.Roles.FirstOrDefault(r => r.Name == roleName);
            if (role == null)
            {
                _dbContext.Roles.Add(new IdentityRole { Name = roleName, NormalizedName = roleName });
                _dbContext.SaveChanges();
            }
        }


        private void AddUserIfNotExists(string userName, string password, string[] roles)
        {
            if (_userManager.FindByEmailAsync(userName).Result != null) return;

            var user = new IdentityUser
            {
                UserName = userName,
                Email = userName,
                EmailConfirmed = true
            };
            _userManager.CreateAsync(user, password).Wait();
            _userManager.AddToRolesAsync(user, roles).Wait();
        }
    }
}
