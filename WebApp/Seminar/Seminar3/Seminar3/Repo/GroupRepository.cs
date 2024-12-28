using AutoMapper;
using Seminar3.Abstraction;
using Seminar3.Data;
using Seminar3.DTO;
using Seminar3.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Seminar3.Repo
{
    public class GroupRepository : IGroupRepository
    {
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly ProductsContext _context;

        private const string CacheKey = "groups"; // Константа для ключа кэша

        public GroupRepository(IMapper mapper, IMemoryCache cache, ProductsContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public int AddGroup(ProductGroupDto group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }

            // Проверяем, существует ли группа с таким именем
            var entityGroup = _context.ProductGroups.FirstOrDefault(x => x.Name.ToLower() == group.Name.ToLower());
            if (entityGroup == null)
            {
                // Если группа не найдена, создаем новую
                var entity = _mapper.Map<ProductGroup>(group);
                _context.ProductGroups.Add(entity);
                _context.SaveChanges();

                // Удаляем кэш при добавлении новой группы
                _cache.Remove(CacheKey);

                return entity.Id;
            }

            return entityGroup.Id; // Если группа уже существует, возвращаем её ID
        }

        public IEnumerable<ProductGroupDto> GetGroups()
        {
            // Проверяем наличие данных в кэше
            if (_cache.TryGetValue(CacheKey, out List<ProductGroupDto> cachedGroups))
            {
                return cachedGroups; // Возвращаем данные из кэша
            }

            // Если данных в кэше нет, читаем их из базы данных
            var groupsList = _context.ProductGroups
                                     .Select(x => _mapper.Map<ProductGroupDto>(x))
                                     .ToList();

            // Сохраняем данные в кэш на 30 минут
            _cache.Set(CacheKey, groupsList, TimeSpan.FromMinutes(30));

            return groupsList;
        }

    }
}
