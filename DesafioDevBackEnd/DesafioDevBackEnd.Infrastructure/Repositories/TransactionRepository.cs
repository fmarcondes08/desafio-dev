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

        public async Task<List<Transaction>> AddTransactionList(List<Transaction> list)
        {
            DbSet.AddRange(list);

            list = DbSet.Include(x => x.TransactionType).Where(x => list.Select(l => l.Id).Contains(x.Id)).ToList();

            return list;
        }

        public Task<List<Transaction>> GetTransactionByStore(string store)
        {
            return DbSet.Include(x => x.TransactionType).Where(x => x.StoreName.Equals(store)).ToListAsync();
        }
    }
}