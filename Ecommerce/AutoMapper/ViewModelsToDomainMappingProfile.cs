﻿using AutoMapper;
using Ecommerce.Models;
using Ecommerce.Models.ViewModels;

namespace Ecommerce.AutoMapper
{
    public class ViewModelsToDomainMappingProfile : Profile
    {
        public ViewModelsToDomainMappingProfile()
        {
        
            CreateMap<FornecedorViewModel, Fornecedor>();
            CreateMap<RevendedorViewModel, Revendedor>();
        }
    }
}