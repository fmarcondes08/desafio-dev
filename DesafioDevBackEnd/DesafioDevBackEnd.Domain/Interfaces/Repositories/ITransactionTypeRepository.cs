using DesafioDevBackEnd.Domain.Entities;
using DesafioDevBackEnd.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
