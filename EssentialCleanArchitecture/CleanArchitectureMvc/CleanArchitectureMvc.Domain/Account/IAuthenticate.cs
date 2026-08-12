namespace CleanArchitectureMvc.Domain.Account
{
    /// <summary>
    /// Provides methods for user authentication and registration within the application.
    /// </summary>
    public interface IAuthenticate
    {
        /// <summary>
        /// Authenticates a user based on the provided email and password.
        /// </summary>
        /// <param name="email">The email address of the user attempting to authenticate.</param>
        /// <param name="password">The password associated with the provided email address.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean value indicating whether the authentication was successful.</returns>
        Task<bool> Authenticate(string email, string password);

        /// <summary>
        /// Registers a new user with the provided email and password.
        /// </summary>
        /// <param name="email">The email address of the user to be registered.</param>
        /// <param name="password">The password for the new user account.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean value indicating whether the registration was successful.</returns>
        Task<bool> RegisterUser(string email, string password);

        /// <summary>
        /// Logs out the currently authenticated user from the application.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task Logout();
    }
}