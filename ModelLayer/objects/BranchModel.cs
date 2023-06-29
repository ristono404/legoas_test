namespace Legoas.Model.objects
{
    public class BranchModel
    {
        public BranchModel() { }

        public BranchModel(Entities.Branch param)
        {
            if (param != null)
            {
                this.ID = param.ID;
                this.BranchName = param.Name;
            }

        }

        
        public int ID { get; set; }
        public string BranchName { get; set; }
    }

}
