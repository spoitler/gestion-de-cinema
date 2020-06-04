namespace ppeEntityWpf
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ppe.cinemas")]
    public partial class cinema
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cinema()
        {
            films = new HashSet<film>();
        }

        [Key]
        public int id_cinema { get; set; }

        [Required]
        [StringLength(50)]
        public string nom { get; set; }

        public int id_ville { get; set; }

        public virtual ville ville { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<film> films { get; set; }
    }
}
