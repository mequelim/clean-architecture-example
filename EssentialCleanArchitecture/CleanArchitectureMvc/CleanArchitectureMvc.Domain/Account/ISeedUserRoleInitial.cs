namespace CleanArchitectureMvc.Domain.Account
{
    /// <summary>
    /// Provides methods to initialize default user roles and seed initial users in the system.
    /// </summary>
    public interface ISeedUserRoleInitial
    {
        /// <summary>
        /// Seeds the initial user data into the system.
        /// </summary>
        /// <remarks>
        /// This method is responsible for creating and initializing default users required for the application to function correctly.
        /// Ensure that roles are seeded prior to invoking this method.
        /// </remarks>
        void SeedUsers();

        /// <summary>
        /// Seeds the initial roles into the system.
        /// </summary>
        /// <remarks>
        /// This method is responsible for creating and initializing default roles required for the application to function correctly.
        /// It should be called before seeding users to ensure proper role assignments.
        /// </remarks>
        void SeedRoles();
    }
}