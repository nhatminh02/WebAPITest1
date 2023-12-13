
using Microsoft.AspNetCore.JsonPatch;

namespace WebAPITest1.Repository
{
    public interface IRepository<T1,T2> where T1 : class
    {
        Task<IEnumerable<T1>> GetAll();
        Task<T1> GetById(T2 id);
        Task<T1> Insert(T1 entity);
        Task Delete(T2 id);
        Task Put(T2 id, T1 entity);
        Task Patch(T2 id, JsonPatchDocument entity);
        Task Save();
    }
}
