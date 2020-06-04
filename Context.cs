namespace ppeEntityWpf
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<acteur> acteurs { get; set; }
        public virtual DbSet<cinema> cinemas { get; set; }
        public virtual DbSet<film> films { get; set; }
        public virtual DbSet<genre> genres { get; set; }
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

            modelBuilder.Entity<acteur>()
                .HasMany(e => e.films)
                .WithMany(e => e.acteurs)
                .Map(m => m.ToTable("joue").MapLeftKey("id_acteur").MapRightKey("id_film"));

            modelBuilder.Entity<cinema>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<cinema>()
                .HasMany(e => e.films)
                .WithMany(e => e.cinemas)
                .Map(m => m.ToTable("diffuse").MapLeftKey("id_cinema").MapRightKey("id_film"));

            modelBuilder.Entity<film>()
                .Property(e => e.titre)
                .IsUnicode(false);

            modelBuilder.Entity<film>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<film>()
                .HasMany(e => e.genres)
                .WithMany(e => e.films)
                .Map(m => m.ToTable("appartient").MapLeftKey("id_film").MapRightKey("id_genre"));

            modelBuilder.Entity<genre>()
                .Property(e => e.name)
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
