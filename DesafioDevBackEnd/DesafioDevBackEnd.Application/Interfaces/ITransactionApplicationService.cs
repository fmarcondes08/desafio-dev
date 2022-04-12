using DesafioDevBackEnd.Application.Dtos;
using DesafioDevBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDevBackEnd.Application.Interfaces
{
    public interface ITransactionApplicationService
    {
        /// <summary>
        /// Import File
        /// </summary>
        /// <param name="fileBytes">file bytes</param>
        /// <returns></returns>
        public Task<List<StoreOutputDto>> ImportFile(List<byte[]> fileBytes);
    }
}
