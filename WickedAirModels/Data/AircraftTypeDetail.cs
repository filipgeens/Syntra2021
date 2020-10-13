using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WickedAir.Models.Data
{
    [Table("AircraftTypeDetail", Schema = "dbo")]
    public partial class AircraftTypeDetail
    {
        [Key]
        [Column("AircraftTypeID")]
        public byte AircraftTypeId { get; set; }
        public byte? TurbineCount { get; set; }
        public float? Length { get; set; }
        public short? Tare { get; set; }
        public string Memo { get; set; }

        [ForeignKey(nameof(AircraftTypeId))]
        [InverseProperty("AircraftTypeDetail")]
        public virtual AircraftType AircraftType { get; set; }
    }
}
