using JogosAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JogosAPI.Infra.Data.EntitiesConfig
{
    public class GameAccountConfig : IEntityTypeConfiguration<GameAccount>
    {
        public void Configure(EntityTypeBuilder<GameAccount> builder)
        {
            builder
                .ToTable("GameAccount")
                .HasKey(x => new { x.GameId, x.AccountId });
                
            builder.Ignore(x => x.Id);

            builder
                .HasOne(x => x.Game)
                .WithMany(x => x.Accounts)
                .HasForeignKey(x => x.GameId);

            builder
                .HasOne(x => x.Account)
                .WithMany(x => x.Games)
                .HasForeignKey(x => x.AccountId);
        }
    }
}
