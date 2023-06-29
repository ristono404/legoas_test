using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Legoas.Model.Entities
{
    [Table("account_role_mapping")]
    class AccountRoleMapping : BaseEntity
    {
        public long ID { get; set; }
        public long AccountID { get; set; }
        public long RoleID { get; set; }
    }
}
