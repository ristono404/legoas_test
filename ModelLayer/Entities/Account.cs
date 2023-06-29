using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Legoas.Model.Entities
{
    [Table("account")]
    public class Account : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            AccountRoleMappings = new HashSet<AccountRoleMapping>();
            AccountBranchMappings = new HashSet<AccountBranchMapping>();
        }
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [Column("zip_code")]
        public string ZipCode { get; set; }
        public string Province { get; set; }
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccountBranchMapping> AccountBranchMappings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccountRoleMapping> AccountRoleMappings { get; set; }
    }
}
