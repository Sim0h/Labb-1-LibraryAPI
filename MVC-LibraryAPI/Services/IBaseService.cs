using MVC_LibraryAPI.Models;

namespace MVC_LibraryAPI.Services
{
    public interface IBaseService
    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
