
namespace Legoas.Model.objects
{
    public class ResultModel<T>
    {
        public ResultModel()
        {

        }
        public string StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public T Value { get; set; }
        public int Total { get; set; }
    }
}
