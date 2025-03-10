using FoodGappBackend_WebAPI.Contract;
using FoodGappBackend_WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using static FoodGappBackend_WebAPI.Utils.Utilities;

namespace FoodGappBackend_WebAPI.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        public DbContext _db;
        public DbSet<T> _table;

        public BaseRepository()
        {
            _db = new FoodGappDbContext();
            _table = _db.Set<T>();
        }

        public ErrorCode Create(T t, out string errorMsg)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Delete(object id, out string errorMsg)
        {
            throw new NotImplementedException();
        }

        public T Get(object id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public ErrorCode Update(object id, T t, out string errorMsg)
        {
            throw new NotImplementedException();
        }
    }
}
