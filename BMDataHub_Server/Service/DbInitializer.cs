using BMDataHub_Server.Service.IService;
using BMDataHub_Server.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Common;


namespace BMDataHub_Server.Service
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IdentityApplicationDBcontext _db;
        private readonly UserManager <IdentityUser>_userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(IdentityApplicationDBcontext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager) 
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

       

        public void Initialize()
        {
            try
            {
                if(_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }

            }catch (Exception ex) { }

            if (_db.Roles.Any(x => x.Name == SD.Role_Admin)) return;

            _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Role_BMInternational)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Role_CountryCoord)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Role_Teacher)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new IdentityUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true
            }, "Admin123*" ).GetAwaiter().GetResult();

            IdentityUser user = _db.Users.FirstOrDefault(u => u.Email == "admin@gmail.com");
            _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
        }
}
}
