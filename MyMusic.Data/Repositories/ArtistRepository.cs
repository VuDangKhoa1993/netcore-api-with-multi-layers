using Microsoft.EntityFrameworkCore;
using MyMusic.Core.Models;
using MyMusic.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Data.Repositories
{
    public class ArtistRepository : BaseRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(MyMusicDbContext context) : base(context) { }
        public async Task<IEnumerable<Artist>> GetAllWithMusicAsync()
        {
            return await _context.Artists.Include(m => m.Musics).ToListAsync();
        }

        public async Task<Artist> GetWithMusicByIdAsync(int artistId)
        {
            return await _context.Artists.Include(m => m.Musics).SingleOrDefaultAsync(m => m.Id == artistId);
        }
    }
}
