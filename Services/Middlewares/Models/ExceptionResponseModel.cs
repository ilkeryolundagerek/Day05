using Newtonsoft.Json;

namespace Services.Middlewares.Models
{
    public class ExceptionResponseModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
