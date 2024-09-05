using static MVC_LibraryAPI.StaticDetails;

namespace MVC_LibraryAPI.Models
{
    public class ApiRequest
    {
        public ApiType apiType { get; set; }

        public string Url { get; set; }

        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
