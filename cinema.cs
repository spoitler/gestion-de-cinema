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
        [Key]
        public int id_cinema { get; set; }

        [Required]
        [StringLength(50)]
        public string nom { get; set; }

        public int id_ville { get; set; }

        public virtual ville ville { get; set; }
    }
}
