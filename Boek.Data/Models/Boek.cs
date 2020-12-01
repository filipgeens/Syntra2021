using Boek.Shared.Defines;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Boek.Data.Models {
  public class Boekje : IModel {
    public int Id { get; set; }
    [Required]
    public string Naam { get; set; }
    public SubGenre Genre { get; set; }
    public Vorm Vorm { get; set; }
    public Taal Taal { get; set; }
    public Auteur Auteur { get; set; }
    public Uitgeverij Uitgeverij { get; set; }
    public string KorteInhoud { get; set; }
    [MaxLength(10)]
    public string ISBN10 { get; set; }
    [MaxLength(15)]
    public string ISBN13 { get; set; }
    [MaxLength(18)]
    public string EAN { get; set; }
    public string Afbeelding { get; set; }
    public DbImage Foto { get; set; }
  }
}
