using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Legoas.Model.Entities
{
    [Table("account_role_mapping")]
    public class AccountRoleMapping : BaseEntity
    {
        public int ID { get; set; }
        [Column("account_id")]
        public int AccountID { get; set; }
        [Column("role_id")]
        public int RoleID { get; set; }
        [ForeignKey("AccountID")]
        public virtual Account Account { get; set; }
        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccountRoleNavigationMapping> AccountRoleNavigationMappings { get; set; }
    }
}
