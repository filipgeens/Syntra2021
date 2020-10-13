using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WickedAir.Models.Data
{
    [Table("Passenger", Schema = "dbo")]
    public partial class Passenger
    {
        public Passenger()
        {
            Booking = new HashSet<Booking>();
        }

        public DateTime? Birthday { get; set; }
        [Column("DetailID")]
        public int? DetailId { get; set; }
        [Key]
        [Column("PersonID")]
        public int PersonId { get; set; }
        public string Surname { get; set; }
        public string GivenName { get; set; }
        [Column("EMail")]
        public string Email { get; set; }
        public DateTime? CustomerSince { get; set; }
        public bool? FrequentFlyer { get; set; }
        [Required]
        [StringLength(1)]
        public string Status { get; set; }

        [ForeignKey(nameof(DetailId))]
        [InverseProperty(nameof(Persondetail.Passenger))]
        public virtual Persondetail Detail { get; set; }
        [InverseProperty("Passenger")]
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
