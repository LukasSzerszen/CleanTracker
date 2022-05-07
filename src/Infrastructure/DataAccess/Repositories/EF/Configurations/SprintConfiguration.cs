using Domain;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.DataAccess.Repositories.EF.Configurations;
public sealed class SprintConfiguration : IEntityTypeConfiguration<Sprint>
{
    public void Configure(EntityTypeBuilder<Sprint> builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        builder.ToTable(nameof(Sprint));

        builder.Property(x => x.Id).HasConversion(
            v => v.Id,
            v => TrackerId.Build(v).Value)
            .IsRequired();

        builder.Property(x => x.StartDate).HasConversion(
            v => v.Date,
            v => TrackerDate.Build(v).Value)
            .IsRequired();

        builder.Property(x => x.EndDate).HasConversion(
            v => v.Date,
            v => TrackerDate.Build(v).Value)
            .IsRequired();

        builder.HasMany(x => x.Issues).WithOne(b => b.Sprint!).HasForeignKey(b => b.SprintId!).OnDelete(DeleteBehavior.Cascade);

    }
}
