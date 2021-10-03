using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TH.POST.Address.Domain.Entities
{
    [Table("geographies")]
    public class GeographyEntity
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        public ICollection<ProvinceEntity> Provinces { get; set; } = new List<ProvinceEntity>();
    }
}
