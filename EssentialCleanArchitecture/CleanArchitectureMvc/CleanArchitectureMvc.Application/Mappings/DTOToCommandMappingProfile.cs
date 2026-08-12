using AutoMapper;
using CleanArchitectureMvc.Application.DTOs;
using CleanArchitectureMvc.Application.Products.Commands;

namespace CleanArchitectureMvc.Application.Mappings
{
    /// <summary>
    /// Provides mappings between Data Transfer Objects (DTOs) and Command objects using AutoMapper.
    /// </summary>
    /// <remarks>
    /// This profile specifically maps between <c>ProductDto</c> and <c>ProductCommand</c>, and vice versa,
    /// to facilitate data transformation in application layers.
    /// </remarks>
    public class DtoToCommandMappingProfile : Profile
    {
        /// <summary>
        /// Defines a mapping profile to configure mappings between DTOs and command objects for the application using AutoMapper.
        /// </summary>
        /// <remarks>
        /// The profile contains mappings between <c>ProductDto</c> and <c>ProductCommand</c> to enable seamless transformation of data
        /// between the application layers while maintaining a clean architecture.
        /// </remarks>
        public DtoToCommandMappingProfile()
        {
            CreateMap<ProductDto, ProductCommand>();
            CreateMap<ProductCommand, ProductDto>();
        }
    }
}