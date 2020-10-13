using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WickedAir.Models.Data
{
    [Table("Persondetail", Schema = "dbo")]
    public partial class Persondetail
    {
        public Persondetail()
        {
            Employee = new HashSet<Employee>();
            Passenger = new HashSet<Passenger>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public string Memo { get; set; }
        public byte[] Photo { get; set; }
        [StringLength(30)]
        public string Street { get; set; }
        [StringLength(30)]
        public string City { get; set; }
        [StringLength(3)]
        public string Country { get; set; }
        [StringLength(8)]
        public string Postcode { get; set; }
        [StringLength(130)]
        public string Planet { get; set; }

        [InverseProperty("Detail")]
        public virtual ICollection<Employee> Employee { get; set; }
        [InverseProperty("Detail")]
        public virtual ICollection<Passenger> Passenger { get; set; }
    }
}
