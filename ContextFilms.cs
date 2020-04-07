namespace ppeEntityWpf
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ContextFilms : DbContext
    {
        public ContextFilms()
            : base("name=ContextFilms")
        {
        }

        public virtual DbSet<acteur> acteurs { get; set; }
        public virtual DbSet<appartient> appartients { get; set; }
        public virtual DbSet<cinema> cinemas { get; set; }
        public virtual DbSet<diffuse> diffuses { get; set; }
        public virtual DbSet<film> films { get; set; }
        public virtual DbSet<genre> genres { get; set; }
        public virtual DbSet<joue> joues { get; set; }
        public virtual DbSet<realisateur> realisateurs { get; set; }
        public virtual DbSet<ville> villes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<acteur>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<acteur>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<cinema>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<film>()
                .Property(e => e.titre)
                .IsUnicode(false);

            modelBuilder.Entity<film>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<genre>()
                .Property(e => e.genre1)
                .IsUnicode(false);

            modelBuilder.Entity<realisateur>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<realisateur>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<realisateur>()
                .HasMany(e => e.films)
                .WithRequired(e => e.realisateur)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ville>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<ville>()
                .HasMany(e => e.cinemas)
                .WithRequired(e => e.ville)
                .WillCascadeOnDelete(false);
        }
    }
}
