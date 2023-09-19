using AutoMapper;

namespace DriverManagement.Application.AutoMapper
{
    public class AutoMapperSetup
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelToViewModelMappingProfile());
            });
        }
    }
}