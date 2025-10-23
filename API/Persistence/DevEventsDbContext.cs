using System;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence;

public class DevEventsDbContext : DbContext
{
    public DevEventsDbContext(DbContextOptions<DevEventsDbContext> options) : base(options)
    {

    }

    public DbSet<DevEvent> DevEvents { get; set; }
    public DbSet<DevEventSpeaker> DevEventSpeakers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<DevEvent>(e =>
        {
            e.HasKey(de => de.Id);

            e.Property(de => de.Title)
                .IsRequired(true)
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            e.Property(de => de.Description)
                .IsRequired(false)
                .HasMaxLength(200)
                .HasColumnType("varchar(200)");

            e.Property(de => de.StartDate)
                .HasColumnName("Start_Date");

            e.Property(de => de.EndDate)
                .HasColumnName("End_Date");

            e.HasMany(de => de.Speakers)
                .WithOne()
                .HasForeignKey(s => s.DevEventId);

        });

        modelBuilder.Entity<DevEventSpeaker>(e =>
        {
            e.HasKey(de => de.Id);

            e.Property(s => s.Name)
                .IsRequired(true)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            e.Property(s => s.TalkTitle)
                .IsRequired(true)
                .HasMaxLength(200)
                .HasColumnType("varchar(200)");

            e.Property(s => s.TalkDescription)
                .IsRequired(false)
                .HasMaxLength(1000)
                .HasColumnType("varchar(1000)");

            e.Property(s => s.LinkeInProfile)
                .IsRequired(false)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

        });
    }

}
