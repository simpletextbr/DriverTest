using AutoMapper;

namespace DriverManagement.Application.AutoMapper
{
    public class AutoMapperSetup
    {
        public static MapperConfiguration RegisterMapping()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelToViewModelMappingProfile());
            });
        }
    }
}