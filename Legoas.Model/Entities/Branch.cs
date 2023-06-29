using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Legoas.Model.Entities
{
    [Table("branch")]
    public class Branch : BaseEntity
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        [Required]
        [StringLength(50)]
        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
