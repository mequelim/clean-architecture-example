namespace CleanArchitectureMvc.Domain.Validations
{
    /// <summary>
    /// Represents a custom exception type used for domain validation errors in the Clean Architecture MVC application.
    /// </summary>
    public class DomainExceptionValidation : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainExceptionValidation"/> class with a specified error message.
        /// </summary>
        /// <param name="error">The error message that explains the reason for the exception.</param>
        private DomainExceptionValidation(string error) : base(error) { }

        //* Methods...
        /// <summary>
        /// Validates a condition and throws a <see cref="DomainExceptionValidation"/> if the condition is true.
        /// </summary>
        /// <param name="hasError">A boolean value indicating whether the specified condition is met.</param>
        /// <param name="error">The error message to include in the exception if the condition is met.</param>
        /// <exception cref="DomainExceptionValidation">Thrown when <paramref name="hasError"/> is <c>true</c>.</exception>
        public static void When(bool hasError, string error)
        {
            if(hasError) throw new DomainExceptionValidation(error);
        }
    }
}