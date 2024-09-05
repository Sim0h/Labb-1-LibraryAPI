using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repository
{
    public class LibraryRepo : ILibraryRepo
    {
        private readonly LibraryDbContext _db;
        public LibraryRepo(LibraryDbContext db)
        {
            _db = db;
        }


        public async Task CreateAsync(Library library)
        {
            _db.Libraries.AddAsync(library);
        }

        public async Task<IEnumerable<Library>> GetAllAsync()
        {
            return await _db.Libraries.ToListAsync();
        }

        public async Task<Library> GetAsync(int id)
        {
            return await _db.Libraries.FirstOrDefaultAsync(l => l.Id == id);
        }
      

        public async Task RemoveAsync(Library library)
        {
            _db.Libraries.Remove(library);
        }

        public async Task SaveAsync()
        {
           await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Library library)
        {
            _db.Libraries.Update(library);
        }
    }
}
