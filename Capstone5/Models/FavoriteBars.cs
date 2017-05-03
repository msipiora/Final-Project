using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone5.Models
{
    public class FavoriteBars
    {
        [Key]

        public int BarsID { get; set; }

        public string BarName { get; set; }

        public string Specials { get; set; }

        public string AdditionalFeatures { get; set; }
    }
}