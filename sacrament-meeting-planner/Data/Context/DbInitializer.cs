using SacramentMeetingPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SacramentMeetingPlanner.Data.Context
{
    public static class DbInitializer
    {
        public static void Initialize(SacramentMeetingPlannerContext context)
        {
            // Look for data.
            if (context.SacramentMeetings.Any())
            {
                return;   // DB has been seeded
            }

            new List<SacramentMeeting>
            {
                 new SacramentMeeting
                 {
                     ClosingPlayer = "AA",
                     Date = new DateTime(2019, 04, 11),
                     OpeningPlayer = "BB",
                     Conductor = "CC",
                     OpeningHymn = 1,
                     ClosingHymn = 2,
                     SacramentHymn = 3,
                     CreatedDate = DateTime.Now,
                     Speaker1Name = "Joshua Carter",
                     Speaker2Name = "Jimmy J.",
                     Speaker3Name = "Smith J.",
                     Topic1 = "Topc 1",
                     Topic2 = "Topc 2",
                     Topic3 = "Topc 3"
                     
                 }

            }.ForEach(s =>
            {
                context.SacramentMeetings.Add(s);
            });

            context.SaveChanges();
        }
    }
}
