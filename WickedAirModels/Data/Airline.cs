using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WickedAir.Models.Data {
  [Table("Airline", Schema = "dbo")]
  public partial class Airline {
    public Airline() {
      Flight = new HashSet<Flight>();
    }

    [Key]
    [StringLength(3)]
    public string Code { get; set; }
    [StringLength(100)]
    public string Name { get; set; }
    [StringLength(100)]
    public string Address { get; set; }
    public int? FoundingYear { get; set; }
    public bool? Bunkrupt { get; set; }

    [InverseProperty("AirlineCodeNavigation")]
    public virtual ICollection<Flight> Flight { get; set; }
    public short? Rating { get; set; }
  }
}
