using AutoMapper;
using MarketDb.Abstraction;
using MarketDb.Controllers;
using MarketDb.Data;
using MarketDb.DTO;
using MarketDb.Models;
using Microsoft.Extensions.Caching.Memory;

namespace MarketDb.Repo
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly ProductsContext _context;

        private const string CacheKey = "products"; // Константа для ключа кэша

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

            // Проверяем, существует ли группа с таким именем
            var entityGroup = _context.Procucts.FirstOrDefault(x => x.Name.ToLower() == product.Name.ToLower());
            if (entityGroup == null)
            {
                // Если группа не найдена, создаем новую
                var entity = _mapper.Map<ProductGroup>(product);
                _context.ProductGroups.Add(entity);
                _context.SaveChanges();

                // Удаляем кэш при добавлении новой группы
                _cache.Remove(CacheKey);

                return entity.Id;
            }

            return entityGroup.Id; // Если группа уже существует, возвращаем её ID
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            // Проверяем наличие данных в кэше
            if (_cache.TryGetValue(CacheKey, out List<ProductDto> cachedProducts))
            {
                return cachedProducts; // Возвращаем данные из кэша
            }

            // Если данных в кэше нет, читаем их из базы данных
            var productsList = _context.Procucts
                                     .Select(x => _mapper.Map<ProductDto>(x))
                                     .ToList();

            // Сохраняем данные в кэш на 30 минут
            _cache.Set(CacheKey, productsList, TimeSpan.FromMinutes(30));

            return productsList;
        }
    }
}
