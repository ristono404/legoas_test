using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Legoas.Model.Entities
{
    [Table("account_role_navigation_mapping")]
    public class AccountRoleNavigationMapping : BaseEntity
    {
        public int ID { get; set; }
        [Column("account_role_id")]
        public int AccountRoleID { get; set; }
        [Column("navigation_id")]
        public int NavigationID { get; set; }
        public string Privilege { get; set; }
        [ForeignKey("AccountRoleID")]
        public virtual AccountRoleMapping AccountRoleMapping { get; set; }
        [ForeignKey("NavigationID")]
        public virtual Navigation Navigation { get; set; }
    }
}
