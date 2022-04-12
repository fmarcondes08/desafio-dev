using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDevBackEnd.Application.Dtos
{
    public class TransactionTypeOutputDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Nature { get; set; }
        public string Signal { get; set; }
        public long Type { get; set; }

        public virtual List<TransactionOutputDto> TransactionsList { get; set; }
    }
}
