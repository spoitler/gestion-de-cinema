namespace ppeEntityWpf
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ppe.acteurs")]
    public partial class acteur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public acteur()
        {
            films = new HashSet<film>();
        }

        [Key]
        public int id_acteur { get; set; }

        [Required]
        [StringLength(25)]
        public string nom { get; set; }

        [Required]
        [StringLength(25)]
        public string prenom { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<film> films { get; set; }

        public string fullName
        {
            get
            {
                return prenom + " " + nom;
            }
        }
    }
}
