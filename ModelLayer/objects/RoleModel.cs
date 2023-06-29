namespace Legoas.Model.objects
{
    public class RoleModel
    {
        public RoleModel() { }

        public RoleModel(Entities.Role param)
        {
            if (param != null)
            {
                this.ID = param.ID;
                this.RoleName = param.Name;
            }

        }

        
        public int ID { get; set; }
        public string RoleName { get; set; }
    }

}
