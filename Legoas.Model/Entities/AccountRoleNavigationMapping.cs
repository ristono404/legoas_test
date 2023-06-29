using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Legoas.Model.Entities
{
    [Table("account_role_navigation_mapping")]
    class AccountRoleNavigationMapping : BaseEntity
    {
        public long ID { get; set; }
        public long AccountRoleID { get; set; }
        public long NavigationID { get; set; }
        public string Privilege { get; set; }
    }
}
