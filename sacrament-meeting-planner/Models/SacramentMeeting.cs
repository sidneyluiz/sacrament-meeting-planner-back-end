using System;
using System.Collections.Generic;

namespace SacramentMeetingPlanner.Models
{
    public class SacramentMeeting : EntityBase
    {
        public DateTime Date { get; set; }

        public string Conductor { get; set; }

        public int OpeningHymn { get; set; }

        public string OpeningPlayer { get; set; }

        public int SacramentHymn { get; set; }

        public int ClosingHymn { get; set; }

        public string ClosingPlayer { get; set; }

        public string Topic1 { get; set; }

        public string Topic2 { get; set; }

        public string Topic3 { get; set; }

        public string Speaker1Name { get; set; }

        public string Speaker2Name { get; set; }

        public string Speaker3Name { get; set; }




    }
}
