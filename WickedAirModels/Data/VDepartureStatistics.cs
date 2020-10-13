using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WickedAir.Models.Data
{
    [Table("V_DepartureStatistics", Schema = "dbo")]
    public partial class VDepartureStatistics
    {
        [Key]
        public string Departure { get; set; }
        public int FlightCount { get; set; }
    }
}
