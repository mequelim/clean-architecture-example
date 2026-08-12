using CleanArchitectureMvc.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitectureMvc.Infra.Data.Identity
{
    /// <summary>
    /// Implements the initialization of default user roles and seeding of initial users in the system.
    /// </summary>
    /// <remarks>
    /// This class is responsible for ensuring that the necessary roles and users are created and initialized for the application to function correctly.
    /// It utilizes the <see cref="Microsoft.AspNetCore.Identity.RoleManager{T}"/> and <see cref="Microsoft.AspNetCore.Identity.UserManager{TUser}"/> to manage roles and users.
    /// </remarks>
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SeedUserRoleInitial"/> class.
        /// </summary>
        /// <param name="roleManager">An instance of <see cref="Microsoft.AspNetCore.Identity.RoleManager{T}"/> used to manage roles in the system.</param>
        /// <param name="userManager">An instance of <see cref="Microsoft.AspNetCore.Identity.UserManager{TUser}"/> used to manage users in the system.</param>
        private SeedUserRoleInitial(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        /// <summary>
        /// Seeds the initial user data into the system.
        /// </summary>
        /// <remarks>
        /// This method ensures that default users are created and assigned to their respective roles.
        /// It checks for the existence of specific users by their email addresses and creates them if they do not exist.
        /// Additionally, it assigns the appropriate roles to the newly created users.
        /// </remarks>
        /// <exception cref="System.AggregateException">Thrown if any asynchronous operations fail during user creation or role assignment.</exception>
        public void SeedUsers()
        {
            if(_userManager.FindByEmailAsync("pedro@admin.com").Result is null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "pedro",
                    NormalizedUserName = "PEDRO",
                    Email = "pedro@admin.com",
                    EmailConfirmed = true,
                    NormalizedEmail = "PEDRO@ADMIN.COM",
                    PhoneNumber = "+55 41 9 99999-9999",
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };

                IdentityResult result = _userManager.CreateAsync(user, "Admin@123").Result;

                if(result.Succeeded) _userManager.AddToRoleAsync(user, "Admin").Wait();
            }

            if(_userManager.FindByEmailAsync("pedro@user.com").Result is null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "pedro",
                    NormalizedUserName = "PEDRO",
                    Email = "pedro@user.com",
                    EmailConfirmed = true,
                    NormalizedEmail = "PEDRO@USER.COM",
                    PhoneNumber = "+55 41 9 99999-9999",
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };

                IdentityResult result = _userManager.CreateAsync(user, "User@123").Result;

                if(result.Succeeded) _userManager.AddToRoleAsync(user, "User").Wait();
            }
        }

        /// <summary>
        /// Seeds the initial roles into the system.
        /// </summary>
        /// <remarks>
        /// This method ensures that default roles such as "Admin" and "User" are created in the system.
        /// It checks for the existence of these roles and creates them if they do not already exist.
        /// </remarks>
        /// <exception cref="System.Exception">Thrown if the creation of a role fails.</exception>
        public void SeedRoles()
        {
            if(!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" };
                IdentityResult result = _roleManager.CreateAsync(role).Result;

                if(!result.Succeeded) throw new Exception("Failed to create Admin role!");
            }

            if(!_roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole { Name = "User", NormalizedName = "USER" };
                IdentityResult result = _roleManager.CreateAsync(role).Result;

                if(!result.Succeeded) throw new Exception("Failed to create User role!");
            }
        }
    }
}