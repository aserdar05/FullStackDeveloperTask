namespace FulStackDeveloperTask.App.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COUNTRY")]
    public partial class Country
    {
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        [Column("NAME")]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [Column("FULLNAME")]
        public string FullName { get; set; }

        [Required]
        [StringLength(10)]
        [Column("CODE")]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        [Column("CURRENCY")]
        public string Currency { get; set; }

        [Required]
        [StringLength(50)]
        [Column("FLAG")]
        public string Flag { get; set; }

        [Required]
        [StringLength(50)]
        [Column("LANGUAGE")]
        public string Language { get; set; }

        [Required]
        [StringLength(50)]
        [Column("CAPITALCITY")]
        public string CapitalCity { get; set; }

        [Column("POPULATION")]
        public long Population { get; set; }

        [Required]
        [StringLength(50)]
        [Column("REGION")]
        public string Region { get; set; }
    }
}
