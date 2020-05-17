using JogosAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JogosAPI.Infra.Data.EntitiesConfig
{
    public class SaleConfig : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sale");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Game)
                   .WithMany(x => x.Sales)
                   .HasForeignKey(x => x.GameId);
        }
    }
}
