using AutoMapper;
using Ecommerce.Models;
using Ecommerce.Models.ViewModels;

namespace Ecommerce.AutoMapper
{
    public class DomainToViewModelsMappingProfile : Profile
    {
        public DomainToViewModelsMappingProfile()
        {
           
            CreateMap<Fornecedor, FornecedorViewModel>();
            CreateMap<Revendedor, RevendedorViewModel>();
        }
    }
}