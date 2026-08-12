using Microsoft.AspNetCore.Identity;

namespace CleanArchitectureMvc.Infra.Data.Identity
{
    /// <summary>
    /// Represents an application user in the identity system, inheriting from <see cref="Microsoft.AspNetCore.Identity.IdentityUser"/>.
    /// </summary>
    public class ApplicationUser : IdentityUser { }
}