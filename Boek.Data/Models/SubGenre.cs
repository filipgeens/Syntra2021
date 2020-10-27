using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Boek.Data.Models {
  public class SubGenre {
    public int Id { get; set; }
    [Required]
    public Genre Genre { get; set; }
    public string Omschrijving { get; set; }
    public int? Doelgroep { get; set; }
    public int? MinLeeftijd { get; set; }
  }
}
