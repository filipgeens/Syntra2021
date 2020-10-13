using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WickedAir.Models.Data
{
    [Table("Flight", Schema = "dbo")]
    public partial class Flight
    {
        public Flight()
        {
            Booking = new HashSet<Booking>();
        }

        [Key]
        public int FlightNo { get; set; }
        [StringLength(50)]
        public string Departure { get; set; }
        [StringLength(50)]
        public string Destination { get; set; }
        public DateTime FlightDate { get; set; }
        public bool? NonSmokingFlight { get; set; }
        public short Seats { get; set; }
        public short? FreeSeats { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Price { get; set; }
        public string Memo { get; set; }
        public bool? Strikebound { get; set; }
        [Column(TypeName = "numeric(20, 8)")]
        public decimal? Utilization { get; set; }
        public byte[] Timestamp { get; set; }
        [StringLength(3)]
        public string AirlineCode { get; set; }
        public int PilotId { get; set; }
        public int? CopilotId { get; set; }
        [Column("AircraftTypeID")]
        public byte? AircraftTypeId { get; set; }
        public DateTime LastChange { get; set; }

        [ForeignKey(nameof(AircraftTypeId))]
        [InverseProperty("Flight")]
        public virtual AircraftType AircraftType { get; set; }
        [ForeignKey(nameof(AirlineCode))]
        [InverseProperty(nameof(Airline.Flight))]
        public virtual Airline AirlineCodeNavigation { get; set; }
        [ForeignKey(nameof(CopilotId))]
        [InverseProperty(nameof(Employee.FlightCopilot))]
        public virtual Employee Copilot { get; set; }
        [ForeignKey(nameof(PilotId))]
        [InverseProperty(nameof(Employee.FlightPilot))]
        public virtual Employee Pilot { get; set; }
        [InverseProperty("FlightNoNavigation")]
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
