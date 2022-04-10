﻿using DesafioDevBackEnd.Domain.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioDevBackEnd.Domain.Entities
{
    [Table("TransactionType")]
    public class TransactionType : BaseEntity
    {
        public string Description { get; set; }
        public string Nature { get; set; }
        public string Signal { get; set; }
        public long Type { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
