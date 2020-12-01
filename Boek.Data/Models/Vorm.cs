using Boek.Shared.Defines;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boek.Data.Models {
  public class Vorm : IModel {
    public int Id { get; set; }
    public string Omschrijving { get; set; }
    public bool Digitaal { get; set; }
  }
}
