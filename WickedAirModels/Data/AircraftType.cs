using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WickedAir.Models.Data
{
    [Table("AircraftType", Schema = "dbo")]
    public partial class AircraftType
    {
        public AircraftType()
        {
            Flight = new HashSet<Flight>();
        }

        [Key]
        [Column("TypeID")]
        public byte TypeId { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }

        [InverseProperty("AircraftType")]
        public virtual AircraftTypeDetail AircraftTypeDetail { get; set; }
        [InverseProperty("AircraftType")]
        public virtual ICollection<Flight> Flight { get; set; }
    }
}
