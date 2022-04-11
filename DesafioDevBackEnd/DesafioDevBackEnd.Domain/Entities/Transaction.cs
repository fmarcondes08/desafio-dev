using DesafioDevBackEnd.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDevBackEnd.Domain.Entities
{
    [Table("Transactions")]
    public class Transaction : BaseEntity
    {
        public DateTime DateTime { get; set; }
        public decimal Value { get; set; }
        public string CPF { get; set; }
        public string Card { get; set; }
        public string StoreOwner { get; set; }
        public string StoreName { get; set; }
        public Guid TransactionTypeId { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}
