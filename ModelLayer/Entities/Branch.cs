using System;
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
        [Display(Name = "Branch")]
        public string Name { get; set; }
        [Column("created_date")]
        public DateTime CreatedDate { get; set; }
        [Required]
        [StringLength(50)]
        [Column("created_by")]
        public string CreatedBy { get; set; }
        [Column("updated_date")]
        public DateTime? UpdatedDate { get; set; }
        [Required]
        [StringLength(50)]
        [Column("updated_by")]
        public string UpdatedBy { get; set; }
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }
    }
}
