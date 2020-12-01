using Boek.Shared.Defines;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Boek.Data.Models {
  public class Uitgeverij : IModel {
    public int Id { get; set; }
    [Required]
    public string Naam { get; set; }
    public string Hoofdkwartier { get; set; }
    public string Oprichter { get; set; }
  }
}
