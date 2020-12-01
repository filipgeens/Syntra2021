using Boek.Shared.Defines;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boek.Data.Models {
  public class Genre : IModel {
    public int Id { get; set; }
    public string Omschrijving { get; set; }
    public int Doelgroep { get; set; }
    public List<SubGenre> SubGenres { get; set; }
  }
}
