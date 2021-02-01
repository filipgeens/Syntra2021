using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Logic.Interfaces;

namespace Transfer.Logic.Model {
  public class TransferClient : ITransferClient {
    IAccountValidator _validator = null;
    public int Id { get; set; }
    public string Naam { get; set; }
    public string RekeningNummer { get; set; }
    public string Adres { get; set; }
    public int? CountryId { get; set; }
    public Country Land { get; set; }
    [NotMapped]
    public string LandCode { get => Land?.Code; }
    [NotMapped]
    public IAccountValidator Validator {
      get { return _validator; }
      set {
        _validator = value;
        if (value != null) {
          value.Owner = this;
        }
      }
    }

    public bool IsValid() => Validator?.IsValid() == true;
  }


}
