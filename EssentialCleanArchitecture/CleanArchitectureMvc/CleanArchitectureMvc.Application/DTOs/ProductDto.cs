using CleanArchitectureMvc.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitectureMvc.Application.DTOs
{
    /// <summary>
    /// Represents a Data Transfer Object (DTO) for a product in the application.
    /// </summary>
    public class ProductDto
    {
        /// <summary>
        /// Gets the unique identifier for the product.
        /// </summary>
        [Key]
        [Display(AutoGenerateField = true, Name = "id", Order = 1)]
        public int Id { get; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <remarks>This property is required and must be between 3 and 100 characters in length.</remarks>
        [Required(ErrorMessage = "The field {0} is required!")]
        [Display(Name = "name")]
        [MinLength(3, ErrorMessage = "The field {0} must be at least {1} characters!")]
        [MaxLength(100, ErrorMessage = "The field {0} must be at least {1} characters!")]
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the product.
        /// </summary>
        /// <remarks>
        /// The description must be between 3 and 500 characters long.
        /// This field is required.
        /// </remarks>
        [Required(ErrorMessage = "The field {0} is required!")]
        [Display(Name = "description")]
        [MinLength(3, ErrorMessage = "The field {0} must be at least {1} characters!")]
        [MaxLength(500, ErrorMessage = "The field {0} must be at least {1} characters!")]
        public required string Description { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        /// <value>
        /// A decimal value representing the price of the product. 
        /// The value must be greater than 0.1.
        /// </value>
        /// <exception cref="System.ComponentModel.DataAnnotations.ValidationException">Thrown when the value is less than or equal to 0.1.</exception>
        [Required(ErrorMessage = "The field {0} is required!")]
        [Display(Name = "price")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Range(0.1, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}!")]
        public decimal Price { get; set; } = 0.1m;

        /// <summary>
        /// Gets the quantity of the product currently in stock.
        /// </summary>
        /// <remarks>This property is required and must be a non-negative integer.</remarks>
        [Required(ErrorMessage = "The field {0} is required!")]
        [Display(Name = "quantity_in_stock")]
        [Range(0, Int32.MaxValue, ErrorMessage = "The field {0} must be equal or greater than {1}!")]
        public int QuantityInStock { get; set; }

        /// <summary>
        /// Gets or sets the category associated with the product.
        /// </summary>
        /// <remarks>
        /// This property represents the relationship between the product and its category.
        /// The <see cref="Category"/> entity contains details about the category, such as its name and description.
        /// </remarks>
        [Display(Name = "category")]
        public required Category Category { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the associated category.
        /// </summary>
        /// <remarks>
        /// This property represents the foreign key relationship between a product and its category.
        /// It is used to associate a product with a specific <see cref="Category"/>.
        /// </remarks>
        [Display(Name = "category_id")]
        public int CategoryId { get; set; }
    }
}