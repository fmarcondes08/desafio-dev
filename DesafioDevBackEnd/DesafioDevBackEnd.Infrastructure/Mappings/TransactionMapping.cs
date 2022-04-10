using DesafioDevBackEnd.Domain.Entities;
using DesafioDevBackEnd.Infrastructure.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDevBackEnd.Infrastructure.Mappings
{
    public class TransactionMapping : BaseEntityMapping<Transaction>, IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            BaseConfigure(builder);

            builder.ToTable("Transactions");

            builder.Property(t => t.DateTime)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(t => t.Value)
                .HasColumnType("decimal")
                .IsRequired();

            builder.Property(t => t.CPF)
                .HasColumnType("nvarchar(11)")
                .IsRequired();

            builder.Property(t => t.Card)
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            builder.Property(t => t.StoreOwner)
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            builder.Property(t => t.StoreName)
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            builder.HasIndex(p => new { p.Id, p.TransactionTypeId })
                 .IsUnique();
        }
    }
}
