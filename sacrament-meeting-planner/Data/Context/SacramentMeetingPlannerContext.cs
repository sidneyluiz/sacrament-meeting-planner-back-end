using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;
using System;

namespace SacramentMeetingPlanner.Data.Context
{
    public class SacramentMeetingPlannerContext : DbContext
    {
        public SacramentMeetingPlannerContext (DbContextOptions<SacramentMeetingPlannerContext> options)
            : base(options)
        {
        }

        public DbSet<SacramentMeeting> SacramentMeetings { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Apply all mapping classes in Data/Mappings
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SacramentMeetingPlannerContext).Assembly);

            #region Applying global standards for models

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                //ensure table name is not in plural

                entityType.Relational().TableName = entityType.ClrType.Name;

                foreach (var property in entityType.GetProperties())
                {
                    switch (property.Name)
                    {
                        case nameof(EntityBase.Id):
                            property.IsKey();
                            break;
                        case nameof(EntityBase.ModifiedDate):
                            property.IsNullable = true;
                            break;
                        case nameof(EntityBase.CreatedDate):
                            property.IsNullable = false;
                            property.Relational().DefaultValueSql = "GETDATE()";
                            break;
                    }

                    if (property.ClrType == typeof(string) && string.IsNullOrEmpty(property.Relational().ColumnType))
                        property.Relational().ColumnType = $"varchar({property.GetMaxLength() ?? 100})";

                    if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                        property.Relational().ColumnType = "DATETIME";
                }
            }

            #endregion

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //To identify all the changes in context
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);

            //to log
            optionsBuilder.EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }
    }
}
