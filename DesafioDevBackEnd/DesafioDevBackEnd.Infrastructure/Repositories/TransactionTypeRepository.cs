using DesafioDevBackEnd.Domain.Entities;
using DesafioDevBackEnd.Domain.Interfaces.Repositories;
using System;
using System.Linq;

namespace DesafioDevBackEnd.Infrastructure.Repositories
{
    public class TransactionTypeRepository : Repository<TransactionType>, ITransactionTypeRepository
    {
        public TransactionTypeRepository(AppDbContext context) : base(context)
        {
        }

        public TransactionType GetTransactionByType(string type)
        {
            return DbSet.Where(x => x.Type == Convert.ToInt64(type)).FirstOrDefault();
        }
    }
}
