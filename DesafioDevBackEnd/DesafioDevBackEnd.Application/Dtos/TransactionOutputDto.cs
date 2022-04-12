using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDevBackEnd.Application.Dtos
{
    public class TransactionOutputDto
    {
        public Guid Id { get; set; }
        public Guid TransactionTypeId { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Value { get; set; }
        public string CPF { get; set; }
        public string Card { get; set; }
        public string StoreOwner { get; set; }
        public string StoreName { get; set; }

        public virtual TransactionTypeOutputDto TransactionsType { get; set; }
    }
}