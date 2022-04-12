using DesafioDevBackEnd.Domain.Entities;

namespace DesafioDevBackEnd.Domain.Interfaces.Repositories
{
    public interface ITransactionTypeRepository : IRepository<TransactionType>
    {
        /// <summary>
        /// Get Transaction Type by type 
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Transaction Type</returns>
        public TransactionType GetTransactionByType(string type);
    }
}
