namespace ppeEntityWpf
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ppe.genres")]
    public partial class genre
    {
        [Key]
        public int id_genre { get; set; }

        [Column("genre")]
        [Required]
        [StringLength(50)]
        public string genre1 { get; set; }
    }
}
