using DesafioDevBackEnd.Domain.Entities;
using DesafioDevBackEnd.Domain.Interfaces.Repositories;
using DesafioDevBackEnd.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDevBackEnd.Service
{
    public class TransactionTypeService : ITransactionTypeService
    {
        private ITransactionTypeRepository _repository;
        public TransactionTypeService(ITransactionTypeRepository repository)
        {
            _repository = repository;
        }

        public TransactionType GetTransactionTypeByType(string type)
        {
            return _repository.GetTransactionByType(type);
        }
    }
}