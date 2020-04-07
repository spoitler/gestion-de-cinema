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

        
    }
}
