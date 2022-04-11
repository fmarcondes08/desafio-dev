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
    public class TransactionTypeMapping : BaseEntityMapping<TransactionType>, IEntityTypeConfiguration<TransactionType>
    {
        public void Configure(EntityTypeBuilder<TransactionType> builder)
        {
            BaseConfigure(builder);

            builder.ToTable("TransactionTypes");

            builder.Property(t => t.Description)
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            builder.Property(t => t.Nature)
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            builder.Property(t => t.Signal)
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            builder.Property(t => t.Type)
                .HasColumnType("bigint")
                .IsRequired();

            builder.HasMany(t => t.Transactions)
                .WithOne(b => b.TransactionType)
                .HasForeignKey(fk => fk.TransactionTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(p => new { p.Type })
                 .IsUnique();
        }
    }
}
