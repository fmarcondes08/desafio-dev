using DesafioDevBackEnd.Domain.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioDevBackEnd.Domain.Entities
{
    [Table("Stores")]
    public class Store : BaseEntity
    {
        public string Name { get; set; }
        public List<Transaction> Transactions { get; set; }
        public decimal CurrentBalance { get; set; }
    }
}
