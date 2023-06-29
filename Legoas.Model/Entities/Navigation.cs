using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Legoas.Model.Entities
{
    [Table("navigation")]
    class Navigation : BaseEntity
    {
        public long ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Controller { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        [StringLength(50)]
        public string UpdatedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}
