using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Legoas.Model.Entities
{
    [Table("account_branch_mapping")]
    public class AccountBranchMapping : BaseEntity
    {
        public int ID { get; set; }
        [Column("account_id")]
        public int AccountID { get; set; }
        [Column("branch_id")]
        public int BranchID { get; set; }
        [ForeignKey("BranchID")]
        public virtual Branch Branch { get; set; }
        [ForeignKey("AccountID")]
        public virtual Account Account { get; set; }
    }
}
