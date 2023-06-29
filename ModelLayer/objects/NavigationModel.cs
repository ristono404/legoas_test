namespace Legoas.Model.objects
{
    public class NavigationModel
    {
        public NavigationModel() { }

        public NavigationModel(Entities.Navigation param)
        {
            if (param != null)
            {
                this.ID = param.ID;
                this.NavigationName = param.Name;
                this.ControllerName = param.Controller;
            }

        }

        
        public int ID { get; set; }
        public string NavigationName { get; set; }
        public string ControllerName { get; set; }
    }

}
