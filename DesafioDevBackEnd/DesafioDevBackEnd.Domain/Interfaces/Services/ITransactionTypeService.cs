using DesafioDevBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDevBackEnd.Domain.Interfaces.Services
{
    public interface ITransactionTypeService
    {
        /// <summary>
        /// Get Transaction Type by type 
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Transaction Type</returns>
        public TransactionType GetTransactionTypeByType(string type);
    }
}
