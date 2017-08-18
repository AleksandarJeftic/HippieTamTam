namespace HippieTamTam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [Key]
        [Column(Order = 0)]
        public int AdminID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string AdminUsername { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string AdminPassword { get; set; }
    }
}
