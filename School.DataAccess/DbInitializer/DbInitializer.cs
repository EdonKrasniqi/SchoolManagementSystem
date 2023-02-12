using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using School.DataAccess.Data;
using School.Models;
using School.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitilizer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DbInitializer
            (UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }
    
        public void Initialize()
        {
            //migrate if they are not applied
            try
            {
                if(_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
               
            }
            //create roles if they are not created
            if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Student)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Professor)).GetAwaiter().GetResult();

                //if roles are not created, then we will create admin user as well
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    Name = "Admin",
                    LastName = "Admin",
                    PhoneNumber = "12312312312",
                    ParentName = "AdminParent",
                    Address = "test test",
                    PlaceOfBirth = "Test test",
                    BirthDate = DateTime.Now,
                    Sex = 'M',
                    ID_Number = 1178823335,
                    User_Id = 2023223314
                },"Admin@2023").GetAwaiter().GetResult();
                ApplicationUser? user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "admin@admin.com");
                _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
            }
            return;
        }
    }
}
