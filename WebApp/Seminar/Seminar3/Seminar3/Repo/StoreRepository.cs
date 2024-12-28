using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Seminar3.Abstraction;
using Seminar3.Data;
using Seminar3.DTO;
using Seminar3.Models;

namespace Seminar3.Repo
{
    public class StoreRepository: IStoreRepository
    {
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly ProductsContext _context;

        private const string CacheKey = "stores"; // Константа для ключа кэша

        public StoreRepository(IMapper mapper, IMemoryCache cache, ProductsContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public int AddStore(StoreDto store)
        {
            if (store == null)
            {
                throw new ArgumentNullException(nameof(store));
            }

            var entityStore = _context.Stores.FirstOrDefault(x => x.Name.ToLower() == store.Name.ToLower());
            if (entityStore == null)
            {
                var entity = _mapper.Map<Store>(store);
                _context.Stores.Add(entity);
                _context.SaveChanges();

                _cache.Remove(CacheKey);

                return entity.Id;
            }

            return entityStore.Id;
        }

        public IEnumerable<StoreDto> GetStores()
        {
            if (_cache.TryGetValue(CacheKey, out List<StoreDto> cachedStores))
            {
                return cachedStores;
            }

            var storesList = _context.Stores
                                     .Select(x => _mapper.Map<StoreDto>(x))
                                     .ToList();

            _cache.Set(CacheKey, storesList, TimeSpan.FromMinutes(30));

            return storesList;
        }
    }
}
