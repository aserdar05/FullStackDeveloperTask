namespace FulStackDeveloperTask.App.Model
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using FulStackDeveloperTask.App.Validation;

    [Table("COUNTRY")]
    public partial class Country : BaseModel
    {

        [Required(ErrorMessage ="Ülke adı girilmelidir")]
        [StringLength(50, ErrorMessage = "Ülke adı alanı 50 karakterden uzun olmamalıdır")]
        [Column("NAME")]
        [DisplayName("Ülke Adı")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ülke tam adı girilmelidir")]
        [StringLength(100, ErrorMessage = "Ülke tam adı alanı 100 karakterden uzun olmamalıdır")]
        [Column("FULLNAME")]
        [DisplayName("Ülke Tam Adı")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Ülke kodu girilmelidir")]
        [StringLength(10, ErrorMessage = "Ülke kodu alanı 00 karakterden uzun olmamalıdır")]
        [Column("CODE")]
        [DisplayName("Ülke Kodu")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Ülke para birimi girilmelidir")]
        [StringLength(50, ErrorMessage = "Ülke para birimi alanı 50 karakterden uzun olmamalıdır")]
        [Column("CURRENCY")]
        [DisplayName("Ülke Para Birimi")]
        public string Currency { get; set; }
        
        [StringLength(50)]
        [Column("FLAG")]
        [DisplayName("Ülke Bayrağı")]
        public string Flag { get; set; }

        [Required(ErrorMessage = "Ülke dili girilmelidir")]
        [StringLength(50, ErrorMessage = "Ülke dili alanı 50 karakterden uzun olmamalıdır")]
        [Column("LANGUAGE")]
        [DisplayName("Ülke Dili")]
        public string Language { get; set; }

        [Required(ErrorMessage = "Ülke başkenti girilmelidir")]
        [StringLength(50, ErrorMessage = "Ülke başkenti alanı 50 karakterden uzun olmamalıdır")]
        [Column("CAPITALCITY")]
        [DisplayName("Ülke Başkenti")]
        public string CapitalCity { get; set; }

        [Required(ErrorMessage = "Ülke nüfusu girilmelidir")]
        [DisplayName("Ülke Nüfusu")]
        [Column("POPULATION")]
        //[MinLength(1, ErrorMessage = "Nüfus bilgisi pozitif tamsayı olmalıdır")]
        //[MaxLongValidation(10000000000, ErrorMessage = "Nüfus bilgisi geçerli bir sayı girilmelidir")]
        [Range(typeof(long), "1", "10000000000", ErrorMessage = "Nüfus bilgisi geçerli pozitif bir sayı girilmelidir")]
        public long Population { get; set; }

        [Required(ErrorMessage = "Ülkenin yeraldığı kıta seçilmelidir")]
        [Column("REGIONID")]
        [DisplayName("Ülkenin Bulunduğu Kıta")]
        public int RegionId { get; set; }

        public virtual Region Region { get; set; }

        [NotMapped]
        public virtual string Base64FlagData { get; set; }
    }
}
