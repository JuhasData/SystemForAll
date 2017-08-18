namespace SystemForAll.Session
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WorldSystemModel : DbContext
    {
        public WorldSystemModel()
            : base("name=WorldSystemModel")
        {
        }

        public virtual DbSet<GlobalEntity> Globals { get; set; }
        public virtual DbSet<LocationEntity> Locations { get; set; }
        public virtual DbSet<WorldSystemEntity> WorldSystems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorldSystemEntity>()
                .Property(e => e.Datum)
                .IsFixedLength();

            modelBuilder.Entity<WorldSystemEntity>()
                .Property(e => e.Prime_Meridan)
                .IsFixedLength();

            modelBuilder.Entity<WorldSystemEntity>()
                .Property(e => e.Projection)
                .IsFixedLength();

            modelBuilder.Entity<WorldSystemEntity>()
                .Property(e => e.Unit_of_Measure)
                .IsFixedLength();

            modelBuilder.Entity<WorldSystemEntity>()
                .Property(e => e.Authority_Name)
                .IsFixedLength();

            modelBuilder.Entity<WorldSystemEntity>()
                .Property(e => e.Unit_Conversion_Factor)
                .IsFixedLength();
        }

        public System.Data.Entity.DbSet<SystemForAll.Session.Repository.Global> Globals1 { get; set; }
    }
}
