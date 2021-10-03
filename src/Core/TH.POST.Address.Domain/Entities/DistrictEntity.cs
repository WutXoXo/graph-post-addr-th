using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TH.POST.Address.Domain.Entities
{
    [Table("districts")]
    public class DistrictEntity
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

        [Column("zipCode")]
        public string ZipCode { get; set; }

        [Required]
        [Column("amphurId")]
        public int AmphurId { get; set; }

        public AmphurEntity Amphur { get; set; }
    }
}
