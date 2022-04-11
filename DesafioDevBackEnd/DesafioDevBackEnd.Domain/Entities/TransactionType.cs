using DesafioDevBackEnd.Domain.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioDevBackEnd.Domain.Entities
{
    [Table("TransactionTypes")]
    public class TransactionType : BaseEntity
    {
        public string Description { get; set; }
        public string Nature { get; set; }
        public string Signal { get; set; }
        public long Type { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
