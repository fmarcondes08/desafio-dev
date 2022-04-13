using DesafioDevBackEnd.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDevBackEnd.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> Get(Guid id);
        Task<T> Add(T entity);
        Task AddRange(List<T> entity);
        Task<T> Update(T entity);
    }
}
