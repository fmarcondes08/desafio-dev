using DesafioDevBackEnd.Domain.Entities;
using System.Collections.Generic;
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
