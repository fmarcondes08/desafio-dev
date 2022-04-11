using DesafioDevBackEnd.Domain.Entities;
using DesafioDevBackEnd.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDevBackEnd.Domain.Interfaces.Repositories
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        /// <summary>
        /// Add a list of Transaction
        /// </summary>
        /// <param name="list">List of transaction</param>
        /// <returns>List of Transactions</returns>
        public Task<List<Transaction>> AddTransactionList(List<Transaction> list);
        /// <summary>
        /// Get transactions by store
        /// </summary>
        /// <param name="Store">Name of the store</param>
        /// <returns>List of Transactions</returns>
        public Task<List<Transaction>> GetTransactionByStore(string store);
    }
}
