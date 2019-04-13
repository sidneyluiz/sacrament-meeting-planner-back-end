using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Data.Mappings
{
    public class SacramentMeetingMap : IEntityTypeConfiguration<SacramentMeeting>
    {
        public void Configure(EntityTypeBuilder<SacramentMeeting> builder)
        {
            builder.Property(s => s.OpeningHymn)
                .IsRequired();

            builder.Property(s => s.OpeningPlayer)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(s => s.ClosingHymn)
                .IsRequired();

            builder.Property(s => s.ClosingPlayer)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(s => s.Conductor)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(s => s.Date)
                .IsRequired()
                .ValueGeneratedOnAdd();

            
        }
    }
}
