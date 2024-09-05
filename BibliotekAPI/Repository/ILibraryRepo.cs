using LibraryAPI.Models;

namespace LibraryAPI.Repository
{
    public interface ILibraryRepo
    {
        Task<IEnumerable<Library>> GetAllAsync();
        Task<Library> GetAsync(int id);
        Task CreateAsync(Library library);
        Task UpdateAsync (Library library);
        Task RemoveAsync (Library library);
        Task SaveAsync();
    }
}
