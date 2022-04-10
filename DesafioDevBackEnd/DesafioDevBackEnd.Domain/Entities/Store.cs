using System.Collections.Generic;

namespace DesafioDevBackEnd.Domain.Entities
{
    public class Store
    {
        public string Name { get; set; }
        public List<Transaction> Transactions { get; set; }
        public decimal CurrentBalance { get; set; }
    }
}
