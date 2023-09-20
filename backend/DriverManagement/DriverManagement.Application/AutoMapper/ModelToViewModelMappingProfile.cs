using AutoMapper;
using DriverManagement.Application.ViewModels;
using DriverManagement.Domain.Models;

namespace DriverManagement.Application.AutoMapper
{
    public class ViewModelToModelMappingProfile : Profile
    {
        public ViewModelToModelMappingProfile()
        {
            CreateMap<DriverViewModel, DriverModel>();
        }
    }

}