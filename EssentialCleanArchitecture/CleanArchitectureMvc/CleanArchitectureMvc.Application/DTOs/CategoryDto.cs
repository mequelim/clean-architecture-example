using System.ComponentModel.DataAnnotations;

namespace CleanArchitectureMvc.Application.DTOs
{
    /// <summary>
    /// Represents a Data Transfer Object (DTO) for a category, containing its identifier, name, and description.
    /// </summary>
    public class CategoryDto
    {
        /// <summary>
        /// Gets the unique identifier for the category.
        /// </summary>
        [Key]
        [Display(AutoGenerateField = true, Name = "id", Order = 1)]
        public int Id { get; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        /// <remarks>
        /// The name is a required field with a minimum length of 5 characters and a maximum length of 150 characters.
        /// </remarks>
        /// <value>
        /// A <see cref="string"/> representing the name of the category.
        /// </value>
        /// <exception cref="ValidationException">
        /// Thrown when the name does not meet the validation requirements.
        /// </exception>
        [Required(ErrorMessage = "The field {0} is required!")]
        [Display(Name = "category")]
        [MinLength(5)]
        [MaxLength(150)]
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the category.
        /// </summary>
        /// <remarks>
        /// The description is a required field with a minimum length of 5 characters and a maximum length of 300 characters.
        /// </remarks>
        [Required(ErrorMessage = "The field {0} is required!")]
        [Display(Name = "description")]
        [MinLength(5)]
        [MaxLength(300)]
        public required string Description { get; set; }
    }
}