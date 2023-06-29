using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Legoas.Model.Entities
{
    [Table("account_branch_mapping")]
    class AccountBranchMapping : BaseEntity
    {
        public long ID { get; set; }
        public long AccountID { get; set; }
        public long BranchID { get; set; }
    }
}
