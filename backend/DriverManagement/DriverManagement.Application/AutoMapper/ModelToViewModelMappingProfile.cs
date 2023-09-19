using AutoMapper;
using DriverManagement.Application.ViewModels;
using DriverManagement.Domain.Models;

namespace DriverManagement.Application.AutoMapper
{
    public class ModelToViewModelMappingProfile : Profile
    {
        public ModelToViewModelMappingProfile()
        {
            CreateMap<DriverModel, DriverViewModel>();
        }
    }

}