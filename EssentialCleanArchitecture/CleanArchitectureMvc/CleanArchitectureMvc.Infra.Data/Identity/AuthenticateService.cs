using CleanArchitectureMvc.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitectureMvc.Infra.Data.Identity
{
    /// <summary>
    /// Provides an implementation of the <see cref="CleanArchitectureMvc.Domain.Account.IAuthenticate"/> interface  for handling user authentication, registration, and logout operations using Identity.
    /// </summary>
    /// <remarks>
    /// This service utilizes <see cref="Microsoft.AspNetCore.Identity.SignInManager{TUser}"/> and <see cref="Microsoft.AspNetCore.Identity.UserManager{TUser}"/> to manage user-related operations.
    /// </remarks>
    public class AuthenticateService : IAuthenticate
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticateService"/> class.
        /// </summary>
        /// <param name="signInManager">An instance of <see cref="Microsoft.AspNetCore.Identity.SignInManager{TUser}"/> used to manage user sign-in operations.</param>
        /// <param name="userManager">An instance of <see cref="Microsoft.AspNetCore.Identity.UserManager{TUser}"/> used to manage user-related operations.</param>
        private AuthenticateService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        //* Methods...
        /// <summary>
        /// Authenticates a user using the provided email and password.
        /// </summary>
        /// <param name="email">The email address of the user attempting to authenticate.</param>
        /// <param name="password">The password associated with the provided email address.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean value indicating whether the authentication was successful.</returns>
        /// <remarks>This method utilizes <see cref="Microsoft.AspNetCore.Identity.SignInManager{TUser}.PasswordSignInAsync"/> to perform the authentication process.</remarks>
        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);

            return result.Succeeded;
        }

        /// <summary>
        /// Registers a new user with the specified email and password.
        /// </summary>
        /// <param name="email">The email address of the user to register.</param>
        /// <param name="password">The password for the new user account.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean value indicating whether the registration was successful.</returns>
        /// <remarks>
        /// If the registration is successful, the user is automatically signed in.
        /// </remarks>
        public async Task<bool> RegisterUser(string email, string password)
        {
            var applicationUser = new ApplicationUser { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(applicationUser, password);

            if(result.Succeeded) await _signInManager.SignInAsync(applicationUser, isPersistent: false);

            return result.Succeeded;
        }

        /// <summary>
        /// Logs the current user out of the application.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <remarks>This method utilizes <see cref="Microsoft.AspNetCore.Identity.SignInManager{TUser}.SignOutAsync"/> to perform the logout operation.</remarks>
        public async Task Logout() => await _signInManager.SignOutAsync();
    }
}