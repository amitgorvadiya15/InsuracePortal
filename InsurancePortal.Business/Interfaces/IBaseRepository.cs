using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsurancePortal.Business.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        //T GetSingleBySpec(ISpecification<T> spec);
        IEnumerable<T> ListAll();
        //IEnumerable<T> List(ISpecification<T> spec);
        T Add(T entity);
        void AddRange(List<T> entities);
        void Update(T entity);
        void UpdateRange(List<T> entities);
        void Delete(T entity);
        void DeleteRange(List<T> entities);

        #region Async methods
        Task<T> GetByIdAsync(int id);
        Task<List<T>> ListAllAsync();
        //Task<List<T>> ListAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(List<T> entities);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(List<T> entities);
        #endregion
    }
}
