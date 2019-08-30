using AutoMapper;

namespace Ecommerce.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<DomainToViewModelsMappingProfile>();
                cfg.AddProfile<ViewModelsToDomainMappingProfile>();
            });
        }
    }
}