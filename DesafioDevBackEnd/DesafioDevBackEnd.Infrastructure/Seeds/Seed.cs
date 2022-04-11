using DesafioDevBackEnd.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDevBackEnd.Infrastructure.Seeds
{
    public class Seed
    {
        public void TransactionTypeSeed(EntityTypeBuilder<TransactionType> builder)
        {
            builder.HasData(
                  new TransactionType { Id = Guid.NewGuid(), Description = "Débito", Nature = "Entrada", Signal = "+", Type = 1, Created_At = DateTime.Now, Updated_At = DateTime.Now },
                  new TransactionType { Id = Guid.NewGuid(), Description = "Boleto", Nature = "Saída", Signal = "-", Type = 2, Created_At = DateTime.Now, Updated_At = DateTime.Now },
                  new TransactionType { Id = Guid.NewGuid(), Description = "Financiamento", Nature = "Saída", Signal = "-", Type = 3, Created_At = DateTime.Now, Updated_At = DateTime.Now },
                  new TransactionType { Id = Guid.NewGuid(), Description = "Crédito", Nature = "Entrada", Signal = "+", Type = 4, Created_At = DateTime.Now, Updated_At = DateTime.Now },
                  new TransactionType { Id = Guid.NewGuid(), Description = "Recebimento Empréstimo", Nature = "Entrada", Signal = "+", Type = 5, Created_At = DateTime.Now, Updated_At = DateTime.Now },
                  new TransactionType { Id = Guid.NewGuid(), Description = "Vendas", Nature = "Entrada", Signal = "+", Type = 6, Created_At = DateTime.Now, Updated_At = DateTime.Now },
                  new TransactionType { Id = Guid.NewGuid(), Description = "Recebimento TED", Nature = "Entrada", Signal = "+", Type = 7, Created_At = DateTime.Now, Updated_At = DateTime.Now },
                  new TransactionType { Id = Guid.NewGuid(), Description = "Recebimento DOC", Nature = "Entrada", Signal = "+", Type = 8, Created_At = DateTime.Now, Updated_At = DateTime.Now },
                  new TransactionType { Id = Guid.NewGuid(), Description = "Aluguel", Nature = "Saída", Signal = "+", Type = 9, Created_At = DateTime.Now, Updated_At = DateTime.Now }
                  );
        }
    }
}
