using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Legoas.Model.Entities
{
    [Table("account")]
    class Account : BaseEntity
    {
        public long ID { get; set; }
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Province { get; set; }
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
