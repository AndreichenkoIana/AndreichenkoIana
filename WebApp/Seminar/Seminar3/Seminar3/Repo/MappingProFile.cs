using AutoMapper;
using Seminar3.DTO;
using Seminar3.Models;

namespace Seminar3.Repo
{
    public class MappingProFile:Profile
    {
        public MappingProFile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<ProductGroup, ProductGroupDto>();
            CreateMap<ProductGroupDto, ProductGroup>();
            CreateMap<Store, StoreDto>();
            CreateMap<StoreDto, Store>();
        }
    }
}
