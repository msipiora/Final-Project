using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone5.Models
{
    public class WednesdayBars
    {
        [Key]

        public int BarsID { get; set; }

        public string BarName { get; set; }

        public string Specials { get; set; }
        [Range(1, 5)]

        public int DaytimeBusyness { get; set; }
        [Range(1, 5)]

        public int EveningBusyness { get; set; }
        [Range(1, 5)]

        public int NightTimeBusyness { get; set; }

        public string AdditionalFeatures { get; set; }

    }
}