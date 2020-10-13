using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WickedAir.Models.Data
{
    [Table("Booking", Schema = "dbo")]
    public partial class Booking
    {
        [Key]
        public int FlightNo { get; set; }
        [Key]
        [Column("PassengerID")]
        public int PassengerId { get; set; }

        [ForeignKey(nameof(FlightNo))]
        [InverseProperty(nameof(Flight.Booking))]
        public virtual Flight FlightNoNavigation { get; set; }
        [ForeignKey(nameof(PassengerId))]
        [InverseProperty("Booking")]
        public virtual Passenger Passenger { get; set; }
    }
}
