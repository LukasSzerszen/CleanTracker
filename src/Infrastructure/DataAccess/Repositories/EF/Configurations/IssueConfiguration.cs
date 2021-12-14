using Domain;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.DataAccess.Repositories.EF.Configurations;

public class IssueConfiguration : IEntityTypeConfiguration<Issue>
{
    public void Configure(EntityTypeBuilder<Issue> builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        builder.ToTable(nameof(Issue));
        //builder.HasKey(x => x.IssueId);

        builder.Property(x => x.IssueId)
            .HasConversion(
            v => v.Id,
            v => TrackerId.Build(v).Value)
            .IsRequired();
     

        builder.Property(x => x.Title)
            .HasConversion(
            v => v.Title,
            v => IssueTitle.Build(v).Value)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasConversion(
            v => v.Description,
            v => IssueDescription.Build(v).Value);

        builder.Property(x => x.Points)
            .HasConversion(
            v => v.Points,
            v => IssuePoints.Build(v).Value);

        builder.Property(x => x.AssignedTo)
            .HasConversion(
            v => v.Id,
            v => TrackerId.Build(v).Value);

        builder.Property(x => x.Status)
            .HasConversion<string>();
        
    }
}
