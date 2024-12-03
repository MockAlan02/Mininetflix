using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniNetflix.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniNetflix.InfraEstructure.Context.Configuration
{
    public class GenreSerieConfiguration : IEntityTypeConfiguration<GenreSerie>
    {
        public void Configure(EntityTypeBuilder<GenreSerie> builder)
        {
            builder.HasKey(bp => new {bp.GenreId, bp.SerieId });

            builder.HasOne(t => t.Serie).WithMany(t => t.GenreSeries).HasForeignKey(bp => bp.SerieId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(t => t.Genre).WithMany(t => t.GenreSeries).HasForeignKey(bp => bp.GenreId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
