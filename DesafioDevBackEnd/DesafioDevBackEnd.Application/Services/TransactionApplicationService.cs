using AutoMapper;
using DesafioDevBackEnd.Application.Dtos;
using DesafioDevBackEnd.Application.Interfaces;
using DesafioDevBackEnd.Domain.Entities;
using DesafioDevBackEnd.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDevBackEnd.Application.Services
{
    public class TransactionApplicationService : ITransactionApplicationService
    {
        private readonly IMapper _mapper;
        private ITransactionService _service;

        public TransactionApplicationService(IMapper mapper, ITransactionService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public async Task<List<StoreOutputDto>> ImportFile(List<IFormFile> file)
        {
            List<byte[]> fileBytes = new List<byte[]>();
            foreach (var item in file)
            {
                fileBytes.Add(Helpers.Helpers.ConvertToBytes(item));
            }

            return _mapper.Map<List<StoreOutputDto>>(await _service.ImportFile(fileBytes));
        }
    }
}
