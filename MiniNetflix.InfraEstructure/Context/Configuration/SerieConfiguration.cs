using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniNetflix.Core.Entities;


namespace MiniNetflix.InfraEstructure.Context.Configuration
{
    public class SerieConfiguration : IEntityTypeConfiguration<Serie>
    {
        public void Configure(EntityTypeBuilder<Serie> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.ImageUrl).IsRequired().HasMaxLength(250);
            builder.Property(e => e.LinkVideo).IsRequired().HasMaxLength(250);

            builder.HasOne(e => e.Production).WithMany(p => p.Serie).HasForeignKey(e => e.ProductionId).OnDelete(DeleteBehavior.Cascade); 
         
           
        }
    }
}
