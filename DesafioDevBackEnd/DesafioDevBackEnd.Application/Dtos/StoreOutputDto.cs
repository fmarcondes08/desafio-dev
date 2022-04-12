using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDevBackEnd.Application.Dtos
{
    public class StoreOutputDto
    {
        public string Name { get; set; }
        public List<TransactionOutputDto> Transactions { get; set; }
        public decimal CurrentBalance { get; set; }
    }
}
