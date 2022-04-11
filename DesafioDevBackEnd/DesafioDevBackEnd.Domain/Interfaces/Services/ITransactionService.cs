using DesafioDevBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDevBackEnd.Domain.Interfaces.Services
{
    public interface ITransactionService
    {
        /// <summary>
        /// Import File
        /// </summary>
        /// <param name="fileBytes">file bytes</param>
        /// <returns></returns>
        public Task<List<Store>> ImportFile(List<byte[]> fileBytes);
    }
}
