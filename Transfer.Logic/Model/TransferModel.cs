using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Logic.Interfaces;

namespace Transfer.Logic.Model {
  public class TransferModel :IModelBase{
    public int Id { get; set; }
    public TransferClient Afzender { get; set; }
    public TransferClient Ontvanger { get; set; }
    public decimal Bedrag { get; set; }
    public string Mededeling { get; set; }
    public DateTime CreatieDatum { get; set; } = DateTime.Now;
    public DateTime UitvoeringsDatem { get; set; } = DateTime.Now;
  }
}
