using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Boek.Data.Models;

namespace Boek.Data.Db {
  public class BoekDb : DbContext {
    public BoekDb() { }
    public BoekDb(string fileName) { DataFile = fileName ?? DataFile; }
    public string DataFile { get; } = "Boek.lib";

    public DbSet<Boekje> Boeken { get; set; }
    public DbSet<Auteur> Auteurs { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<SubGenre> SubGenres { get; set; }
    public DbSet<Vorm> BoekVorm { get; set; }
    public DbSet<Uitgeverij> Uitgeverijen { get; set; }
    public DbSet<Taal> Talen { get; set; }
    public DbSet<DbImage> DbImages { get; set; }
    public string DataPath {
      get {
        string dir = @$"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).TrimEnd('\\')}\BoekDb";
        if (!Directory.Exists(dir)) { Directory.CreateDirectory(dir); }
        return $@"{dir}\{DataFile}";
      }
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseSqlite($@"Data Source={DataPath}");
      base.OnConfiguring(optionsBuilder);
    }
  }
}
