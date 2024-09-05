using LibraryAPI.Models.DTO;

namespace MVC_LibraryAPI.Services
{
    public interface ILibraryService
    {
        Task<T> GetAllBooks<T>();
        Task<T> GetBookById<T>(int id);

        Task<T> CreateBookAsync<T>(LibraryDTO libraryDTO);
        Task<T> UpdateBookAsync<T>(LibraryDTO libraryDTO);
        Task<T> DeleteBookAsync<T>(int id);

    }
}
