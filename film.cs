namespace ppeEntityWpf
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ppe.films")]
    public partial class film
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public film()
        {
            genres = new HashSet<genre>();
            cinemas = new HashSet<cinema>();
            acteurs = new HashSet<acteur>();
        }

        [Key]
        public int id_film { get; set; }

        [Required]
        [StringLength(25)]
        public string titre { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [StringLength(65535)]
        public string description { get; set; }

        [Column(TypeName = "date")]
        public DateTime année { get; set; }

        public int id_realisateur { get; set; }

        public virtual realisateur realisateur { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<genre> genres { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cinema> cinemas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<acteur> acteurs { get; set; }
    }
}
