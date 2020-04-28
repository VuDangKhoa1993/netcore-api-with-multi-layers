using MyMusic.Core.Repositories;
using MyMusic.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyMusicDbContext _context;

        private ArtistRepository artistRepository;

        private MusicRepository musicRepository;
        public UnitOfWork(MyMusicDbContext context)
        {
            _context = context;
        }
        public IMusicRepository Musics => musicRepository = musicRepository ?? new MusicRepository(_context);

        public IArtistRepository Artists => artistRepository = artistRepository ?? new ArtistRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
