using Boek.Shared.Defines;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Boek.Data.Models {
  public class Auteur :IModel{
    public int Id { get; set; }
    [Required]
    public string ArtiestenNaam { get; set; }
    public string Voornaam { get; set; }
    public string Achternaam { get; set; }
    public string Woonplaats { get; set; }
    public string Achtergrond { get; set; }
    public string Afbeelding { get; set; }
    public DbImage Foto { get; set; }
  }
}
