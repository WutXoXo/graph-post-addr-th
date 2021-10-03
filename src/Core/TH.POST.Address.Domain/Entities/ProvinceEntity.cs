using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TH.POST.Address.Domain.Entities
{

    [Table("provinces")]
    public class ProvinceEntity
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("code")]
        public string Code { get; set; }

        [Required]
        [Column("nameTH")]
        public string NameTH { get; set; }

        [Required]
        [Column("nameEN")]
        public string NameEN { get; set; }

        [Required]
        [Column("geographyId")]
        public int GeographyId { get; set; }

        public GeographyEntity Geography { get; set; }

        public ICollection<AmphurEntity> Amphures { get; set; } = new List<AmphurEntity>();
    }
}
