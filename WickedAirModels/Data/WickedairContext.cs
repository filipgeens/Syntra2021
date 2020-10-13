using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WickedAir.Models.Data
{
    public partial class WickedairContext : DbContext
    {
        public WickedairContext()
        {
        }

        public WickedairContext(DbContextOptions<WickedairContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AircraftType> AircraftType { get; set; }
        public virtual DbSet<AircraftTypeDetail> AircraftTypeDetail { get; set; }
        public virtual DbSet<Airline> Airline { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<DepartureGrouping> DepartureGrouping { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Flight> Flight { get; set; }
        public virtual DbSet<Passenger> Passenger { get; set; }
        public virtual DbSet<Persondetail> Persondetail { get; set; }
        public virtual DbSet<VDepartureStatistics> VDepartureStatistics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //optionsBuilder.UseSqlServer("Data Source=188.121.44.214;Initial Catalog=Wickedair;User ID=syntra;Password=Airbus-A800");
        optionsBuilder.UseSqlServer("Data Source=FG-DELL; Initial Catalog = WickedAir; Integrated Security = True");
  //      optionsBuilder.UseSqlite(@"e:\tmp\WickedAir.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "syntra");

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => new { e.FlightNo, e.PassengerId });

                entity.HasIndex(e => e.PassengerId);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.DetailId);

                entity.HasIndex(e => e.SupervisorPersonId);
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.HasIndex(e => e.AircraftTypeId);

                entity.HasIndex(e => e.AirlineCode);

                entity.HasIndex(e => e.CopilotId);

                entity.HasIndex(e => e.FreeSeats)
                    .HasName("Index_FreeSeats");

                entity.HasIndex(e => e.PilotId);

                entity.HasIndex(e => new { e.Departure, e.Destination });

                entity.Property(e => e.FlightNo).ValueGeneratedNever();

                entity.Property(e => e.Departure).HasDefaultValueSql("(N'(not set)')");

                entity.Property(e => e.Destination).HasDefaultValueSql("(N'(not set)')");

                entity.Property(e => e.FlightDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Price).HasDefaultValueSql("((123.45))");

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Utilization).HasComputedColumnSql("((100.0)-(([FreeSeats]*(1.0))/[Seats])*(100.0))");

                entity.HasOne(d => d.Pilot)
                    .WithMany(p => p.FlightPilot)
                    .HasForeignKey(d => d.PilotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.HasIndex(e => e.DetailId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
