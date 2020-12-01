using Boek.Shared.Defines;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Boek.Data.Models {
  public class DbImage : IModel {
    public int Id { get; set; }
    public enum ImageFormat { jpg,png,bmp,tiff,gif};
    public string Naam { get; set; }
    [Required]
    public byte[] Content { get; set; }
    public ImageFormat ImageType { get; set; } = ImageFormat.jpg;
    public string Description { get; set; }
  }
}
