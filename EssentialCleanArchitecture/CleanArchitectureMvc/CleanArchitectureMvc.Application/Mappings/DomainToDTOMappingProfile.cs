using AutoMapper;
using CleanArchitectureMvc.Application.DTOs;
using CleanArchitectureMvc.Domain.Entities;

namespace CleanArchitectureMvc.Application.Mappings
{
    /// <summary>
    /// Provides mapping configurations between domain entities and Data Transfer Objects (DTOs) using AutoMapper.
    /// This class is part of the application's mapping layer.
    /// </summary>
    public class DomainToDtoMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainToDtoMappingProfile"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor sets up the mapping configuration between domain entities and their corresponding Data Transfer Objects (DTOs).
        /// Specifically, it maps the <see cref="Category"/> entity to the <see cref="CategoryDto"/> DTO.
        /// </remarks>
        public DomainToDtoMappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}