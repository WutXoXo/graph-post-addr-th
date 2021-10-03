using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TH.POST.Address.Domain.Entities
{
    [Table("amphures")]
    public class AmphurEntity
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
        [Column("provinceId")]
        public int ProvinceId { get; set; }

        public ProvinceEntity Province { get; set; }

        public ICollection<DistrictEntity> Districts { get; set; } = new List<DistrictEntity>();
    }
}
