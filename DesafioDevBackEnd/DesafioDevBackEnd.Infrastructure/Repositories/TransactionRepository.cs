using DesafioDevBackEnd.Domain.Entities;
using DesafioDevBackEnd.Domain.Interfaces.Repositories;
using DesafioDevBackEnd.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDevBackEnd.Infrastructure.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Transaction>> GetTransactionList(List<Transaction> list)
        {
            return DbSet.Include(x => x.TransactionType).Where(x => list.Select(l => l.Id).Contains(x.Id)).ToList();
        }

        public Task<List<Transaction>> GetTransactionByStore(string store)
        {
            return DbSet.Include(x => x.TransactionType).Where(x => x.StoreName.Equals(store)).ToListAsync();
        }
    }
}