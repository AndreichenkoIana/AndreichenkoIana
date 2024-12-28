using AutoMapper;
using Seminar3.Abstraction;
using Seminar3.Data;
using Seminar3.DTO;
using Seminar3.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Seminar3.Repo
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly ProductsContext _context;

        private const string CacheKey = "products";

        public ProductRepository(IMapper mapper, IMemoryCache cache, ProductsContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public int AddProduct(ProductDto product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            var entityProduct = _context.Procucts.FirstOrDefault(x => x.Name.ToLower() == product.Name.ToLower());
            if (entityProduct == null)
            {
                var entity = _mapper.Map<Product>(product);
                _context.Procucts.Add(entity);
                _context.SaveChanges();

                _cache.Remove(CacheKey);

                return entity.Id;
            }

            return entityProduct.Id;
        }
        public IEnumerable<ProductDto> GetProducts()
        {
            if (_cache.TryGetValue(CacheKey, out List<ProductDto> cachedProducts))
            {
                return cachedProducts;
            }

            var productsList = _context.Procucts
                                     .Select(x => _mapper.Map<ProductDto>(x))
                                     .ToList();

            _cache.Set(CacheKey, productsList, TimeSpan.FromMinutes(30));

            return productsList;
        }
        public bool DeleteProduct(int id)
        {
            var product = _context.Procucts.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return false;
            }

            _context.Procucts.Remove(product);
            _context.SaveChanges();
            _cache.Remove(CacheKey);
            return true;
        }
        public IEnumerable<ProductDto> GetProductsByGroupId(int productGroupId)
        {
            if (_cache.TryGetValue(CacheKey, out List<ProductDto> cachedProducts))
            {
                return cachedProducts;
            }

            var productsInGroup = _context.Procucts
                                          .Where(p => p.ProductGroupId == productGroupId)
                                          .Select(p => _mapper.Map<ProductDto>(p))
                                          .ToList();
            _cache.Set(CacheKey, productsInGroup, TimeSpan.FromMinutes(30));
            return productsInGroup;
        }

        public IEnumerable<ProductDto> GetProductsByStoreID(int storeID)
        {
            if (_cache.TryGetValue(CacheKey, out List<ProductDto> cachedProducts))
            {
                return cachedProducts;
            }

            var productsInStore = _context.Procucts
                                          .Where(p => p.StoreID == storeID)
                                          .Select(p => _mapper.Map<ProductDto>(p))
                                          .ToList();
            _cache.Set(CacheKey, productsInStore, TimeSpan.FromMinutes(30));
            return productsInStore;
        }
    }
}
