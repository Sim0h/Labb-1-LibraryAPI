using LibraryAPI.Models.DTO;

namespace MVC_LibraryAPI.Services
{
    public class LibraryService : BaseService, ILibraryService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LibraryService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            this._httpClientFactory = clientFactory;
        }

        public async Task<T> CreateBookAsync<T>(LibraryDTO libraryDTO)
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                apiType = StaticDetails.ApiType.POST,
                Data = libraryDTO,
                Url = StaticDetails.LibraryApiBase + "/api/createbook",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteBookAsync<T>(int id)
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                apiType = StaticDetails.ApiType.DELETE,
                Url = StaticDetails.LibraryApiBase + "/api/deletebook" + id,
                AccessToken = ""
            });
        }

        public Task<T> GetAllBooks<T>()
        {
            return this.SendAsync<T>(new Models.ApiRequest()
            {
                apiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.LibraryApiBase + "/api/books",
                AccessToken = ""
            });
        }

        public async Task<T> GetBookByAuthor<T>(string author)
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                apiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.LibraryApiBase + "/api/book/" + author,
                AccessToken = ""
            });
        }

        public async Task<T> GetBookById<T>(int id)
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                apiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.LibraryApiBase + "/api/book/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> GetBookByTitle<T>(string title)
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                apiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.LibraryApiBase + "/api/book/" + title,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateBookAsync<T>(LibraryDTO libraryDTO)
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                apiType = StaticDetails.ApiType.PUT,
                Data = libraryDTO,
                Url = StaticDetails.LibraryApiBase + "/api/updatebook",
                AccessToken = ""
            });
        }
    }
}
