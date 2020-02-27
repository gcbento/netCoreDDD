using JogosAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JogosAPI.Infra.Data.EntitiesConfig
{
    public class WishGameConfig : IEntityTypeConfiguration<WishGame>
    {
        public void Configure(EntityTypeBuilder<WishGame> builder)
        {
            builder.ToTable("WishGame");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");
        }
    }
}
