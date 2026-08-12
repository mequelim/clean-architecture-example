using CleanArchitectureMvc.Domain.Entities;
using CleanArchitectureMvc.Domain.Validations;
using FluentAssertions;
using Xunit;

namespace CleanArchitectureMvc.Domain.Tests
{
    /// <summary>
    /// Contains unit tests for the <see cref="Category"/> class in the domain layer.
    /// </summary>
    /// <remarks>
    /// The <see cref="CategoryUnitTest1"/> class is designed to validate the behavior and state of the <see cref="Category"/> entity.
    /// It ensures that the <see cref="Category"/> class adheres to the expected domain rules and constraints.
    /// </remarks>
    public class CategoryUnitTest1
    {
        /// <summary>
        /// Tests the creation of a <see cref="Category"/> object with valid parameters.
        /// </summary>
        /// <remarks>
        /// This test ensures that a <see cref="Category"/> object can be successfully created without throwing a <see cref="DomainExceptionValidation"/>
        /// and verifies that the resulting object is in a valid state.
        /// </remarks>
        [Fact(DisplayName = "Create a category with valid state.")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            //* Arrange: defines a category creation action with valid parameters.
            Action action = () => new Category(1, "Category Name", "Category description...");

            //* Act & Assert: checks that creation does not throw domain validation exceptions.
            action.Should().NotThrow<DomainExceptionValidation>();

            //* Assert: validates the internal state of the created object.
            Category category = new(1, "Category Name", "Category description...");

            category.Id.Should().Be(1);
            category.Name.Should().Be("Category Name");
            category.Description.Should().Be("Category description...");
        }

        /// <summary>
        /// Validates that attempting to create a <see cref="Category"/> with a negative ID value throws a <see cref="DomainExceptionValidation"/>.
        /// </summary>
        /// <remarks>
        /// This test ensures that the domain rules for the <see cref="Category"/> entity are enforced, specifically that the ID value must be greater than zero.
        /// </remarks>
        /// <exception cref="DomainExceptionValidation">
        /// Thrown when the <see cref="Category"/> is created with an invalid ID value.
        /// </exception>
        [Fact(DisplayName = "Create a category with negative id.")]
        public void CreateCategory_WithNegativeIdValue_DomainExceptionValidation()
        {
            //* Arrange: defines a category creation action with a negative ID.
            Action action = () => new Category(-1, "Category Name", "Category description...");

            //* Act & Assert: checks that creation throws a domain validation exception.
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Id must be greater than zero!");
        }

        /// <summary>
        /// Validates that creating a <see cref="Category"/> with an empty name throws a <see cref="DomainExceptionValidation"/>.
        /// </summary>
        /// <remarks>
        /// This test ensures that the <see cref="Category"/> entity enforces the domain rule requiring a non-empty name.
        /// It verifies that attempting to create a category with an empty name results in a domain validation exception with the appropriate error message.
        /// </remarks>
        /// <exception cref="DomainExceptionValidation">
        /// Thrown when the name of the category is empty, as per the domain validation rules.
        /// </exception>
        [Fact(DisplayName = "Create a category with empty name.")]
        public void CreateCategory_WithEmptyName_DomainExceptionValidation()
        {
            //* Arrange: defines a category creation action with an empty name.
            Action action = () => new Category(1, string.Empty, "Category description...");

            //* Act & Assert: checks that creation throws a domain validation exception.
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Name is required!");
        }

        /// <summary>
        /// Validates that creating a <see cref="Category"/> with a short name throws a <see cref="DomainExceptionValidation"/>.
        /// </summary>
        /// <remarks>
        /// This test ensures that the <see cref="Category"/> entity enforces the domain rule requiring the name to have a minimum length of 5 characters.
        /// </remarks>
        /// <exception cref="DomainExceptionValidation">
        /// Thrown when the name of the <see cref="Category"/> is shorter than the required minimum length.
        /// </exception>
        [Fact(DisplayName = "Create a category with short name.")]
        public void CreateCategory_WithShortName_DomainExceptionValidation()
        {
            //* Arrange: defines a category creation action with a short name.
            Action action = () => new Category(1, "Abc", "Category description...");

            //* Act: checks that creation throws a domain validation exception.
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Name must be at least 5 characters long!");
        }

        /// <summary>
        /// Validates the creation of a <see cref="Category"/> with a name that exceeds the maximum allowed length.
        /// </summary>
        /// <remarks>
        /// This test ensures that attempting to create a <see cref="Category"/> with a name longer than 150 characters
        /// results in a <see cref="DomainExceptionValidation"/> being thrown, adhering to the domain rules.
        /// </remarks>
        /// <exception cref="DomainExceptionValidation">
        /// Thrown when the name of the <see cref="Category"/> exceeds 150 characters.
        /// </exception>
        [Fact(DisplayName = "Create a category with long name.")]
        public void CreateCategory_WithLongName_DomainExceptionValidation()
        {
            //* Arrange: defines a category creation action with a long name.
            Action action = () => new Category(1, new string('A', 151), "Category description...");

            //* Act & Assert: checks that creation throws a domain validation exception.
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Name cannot exceed 150 characters!");
        }

        /// <summary>
        /// Validates that creating a <see cref="Category"/> with an empty description throws a <see cref="DomainExceptionValidation"/>.
        /// </summary>
        /// <remarks>
        /// This test ensures that the <see cref="Category"/> entity enforces the domain rule requiring a non-empty description.
        /// An exception with the message "Description is required!" is expected to be thrown when attempting to create a category with an empty description.
        /// </remarks>
        /// <exception cref="DomainExceptionValidation">
        /// Thrown when the description of the <see cref="Category"/> is empty.
        /// </exception>
        [Fact(DisplayName = "Create a category with empty description.")]
        public void CreateCategory_WithEmptyDescription_DomainExceptionValidation()
        {
            //* Arrange: defines a category creation action with an empty description.
            Action action = () => new Category(1, "Category Name", string.Empty);

            //* Act & Assert: checks that creation throws a domain validation exception.
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Description is required!");
        }

        /// <summary>
        /// Validates the creation of a <see cref="Category"/> with a short description.
        /// </summary>
        /// <remarks>
        /// This test ensures that attempting to create a <see cref="Category"/> with a description shorter than the required minimum length throws a <see cref="DomainExceptionValidation"/>.
        /// </remarks>
        /// <exception cref="DomainExceptionValidation">
        /// Thrown when the description length is less than the required minimum (e.g., 5 characters).
        /// </exception>
        [Fact(DisplayName = "Create a category with short description.")]
        public void CreateCategory_WithShortDescription_DomainExceptionValidation()
        {
            //* Arrange: defines a category creation action with a short description.
            Action action = () => new Category(1, "Category Name", "Desc");

            //* Act & Assert: checks that creation throws a domain validation exception.
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Description must be at least 5 characters long!");
        }

        /// <summary>
        /// Validates the creation of a <see cref="Category"/> entity with a long description.
        /// </summary>
        /// <remarks>
        /// This test ensures that attempting to create a <see cref="Category"/> with a description exceeding 300 characters results in a <see cref="DomainExceptionValidation"/> being thrown.
        /// </remarks>
        /// <exception cref="DomainExceptionValidation">
        /// Thrown when the description length exceeds the maximum allowed limit of 300 characters.
        /// </exception>
        [Fact(DisplayName = "Create a category with long description.")]
        public void CreateCategory_WithLongDescription_DomainExceptionValidation()
        {
            //* Arrange: defines a category creation action with a long description.
            Action action = () => new Category(1, "Category Name", new string('A', 301));

            //* Act & Assert: checks that creation throws a domain validation exception.
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Description cannot exceed 300 characters!");
        }

        /// <summary>
        /// Validates the creation of a <see cref="Category"/> object with a valid name and description.
        /// </summary>
        /// <remarks>
        /// This test ensures that a <see cref="Category"/> object can be successfully created when valid parameters are provided.
        /// It verifies that no exceptions are thrown during the creation process and that the resulting object's state matches the expected values.
        /// </remarks>
        /// <example>
        /// This test demonstrates the creation of a <see cref="Category"/> object:
        /// <code>
        /// var category = new Category("Valid Name", "Valid description...");
        /// category.Name.Should().Be("Valid Name");
        /// category.Description.Should().Be("Valid description...");
        /// </code>
        /// </example>
        [Fact(DisplayName = "Create a category with valid name and description.")]
        public void CreateCategory_WithValidNameAndDescription_ResultObjectValidState()
        {
            //* Arrange: defines a category creation action with valid name and description.
            Action action = () => new Category("Valid Name", "Valid description...");

            //* Act & Assert: checks that creation does not throw domain validation exceptions.
            action.Should().NotThrow<DomainExceptionValidation>();

            //* Assert: validates the internal state of the created object.
            Category category = new("Valid Name", "Valid description...");

            category.Name.Should().Be("Valid Name");
            category.Description.Should().Be("Valid description...");
        }

        /// <summary>
        /// Validates that creating a <see cref="Category"/> with an empty name and a valid description throws a <see cref="DomainExceptionValidation"/>.
        /// </summary>
        /// <remarks>
        /// This test ensures that the domain rules for the <see cref="Category"/> entity are enforced, specifically that a category name cannot be empty.
        /// </remarks>
        /// <exception cref="DomainExceptionValidation">
        /// Thrown when attempting to create a <see cref="Category"/> with an empty name.
        /// </exception>
        [Fact(DisplayName = "Create a category with empty name and valid description.")]
        public void CreateCategory_WithEmptyNameAndValidDescription_DomainExceptionValidation()
        {
            //* Arrange: defines a category creation action with an empty name and a valid description.
            Action action = () => new Category(string.Empty, "Valid description...");

            //* Act & Assert: checks that creation throws a domain validation exception.
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Name is required!");
        }

        /// <summary>
        /// Validates that creating a <see cref="Category"/> with a valid name and an empty description throws a <see cref="DomainExceptionValidation"/>.
        /// </summary>
        /// <remarks>
        /// This test ensures that the domain rules for the <see cref="Category"/> entity are enforced, specifically that a category description cannot be empty.
        /// </remarks>
        /// <exception cref="DomainExceptionValidation">
        /// Thrown when attempting to create a <see cref="Category"/> with an empty description.
        /// </exception>
        [Fact(DisplayName = "Create a category with valid name and empty description.")]
        public void CreateCategory_WithValidNameAndEmptyDescription_DomainExceptionValidation()
        {
            //* Arrange: defines a category creation action with a valid name and an empty description.
            Action action = () => new Category("Valid Name", string.Empty);

            //* Act & Assert: checks that creation throws a domain validation exception.
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Description is required!");
        }

        /// <summary>
        /// Validates the update of a <see cref="Category"/> object with valid parameters.
        /// </summary>
        /// <remarks>
        /// This test ensures that a <see cref="Category"/> object can be successfully updated without throwing a <see cref="DomainExceptionValidation"/>
        /// and verifies that the resulting object is in a valid state.
        /// </remarks>
        [Fact(DisplayName = "Update a category with valid state.")]
        public void UpdateCategory_WithValidParameters_ResultObjectValidState()
        {
            // Arrange: defines a category with initial valid parameters.
            var category = new Category(1, "Category Name", "Category description...");

            // Act: updates the category with new valid data.
            category.UpdateData("Updated category name", "Updated category description.");

            // Assert: validates the internal state of the updated object.
            category.Name.Should().Be("Updated category name");
            category.Description.Should().Be("Updated category description.");
        }

        /// <summary>
        /// Validates the update of a <see cref="Category"/> object with an invalid name.
        /// </summary>
        /// <remarks>
        /// This test ensures that attempting to update a <see cref="Category"/> object with an invalid name throws a <see cref="DomainExceptionValidation"/>.
        /// </remarks>
        [Fact(DisplayName = "Update a category with invalid name.")]
        public void UpdateCategory_WithInvalidName_DomainExceptionValidation()
        {
            // Arrange: defines a category with initial valid parameters.
            var category = new Category(1, "Category Name", "Category description...");
            Action action = () => category.UpdateData("In", "Updated Category description...");

            // Act & Assert: checks that updating the category throws a domain validation exception.
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Name must be at least 5 characters long!");
        }

        /// <summary>
        /// Validates the update of a <see cref="Category"/> object with an invalid description.
        /// </summary>
        /// <remarks>
        /// This test ensures that attempting to update a <see cref="Category"/> object with an invalid description throws a <see cref="DomainExceptionValidation"/>.
        /// </remarks>
        [Fact(DisplayName = "Update a category with invalid description.")]
        public void UpdateCategory_WithInvalidDescription_DomainExceptionValidation()
        {
            // Arrange: defines a category with initial valid parameters.
            var category = new Category(1, "Category Name", "Category description...");
            Action action = () => category.UpdateData("Updated Category Name", "Des");

            // Act & Assert: checks that updating the category throws a domain validation exception.
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Description must be at least 5 characters long!");
        }
    }
}