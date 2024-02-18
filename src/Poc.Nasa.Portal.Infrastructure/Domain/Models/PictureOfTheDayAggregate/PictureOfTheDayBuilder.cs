using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poc.Nasa.Portal.Domain.Models.PictureOfTheDayAggregate;

namespace Poc.Nasa.Portal.Infrastructure.Domain.Models.PictureOfTheDayAggregate;

public sealed class PictureOfTheDayBuilder
{
    public void Build(EntityTypeBuilder<PictureOfTheDay> builder)
    {
        builder.ToTable("PictureOfTheDay");

        // Keys
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Copyright)
            .HasColumnType("varchar(200)")
            .IsRequired();

        builder.Property(x => x.PictureDate)
            .HasColumnType("Datetime")
            .IsRequired();

        builder.Property(x => x.Explanation)
            .HasColumnType("varchar(10000)")
            .IsRequired();

        builder.Property(x => x.HdUrl)
            .HasColumnType("varchar(5000)")
            .IsRequired();

        builder.Property(x => x.Title)
            .HasColumnType("varchar(200)")
            .IsRequired();

        builder.Property(x => x.Url)
            .HasColumnType("varchar(5000)")
            .IsRequired();
    }
}