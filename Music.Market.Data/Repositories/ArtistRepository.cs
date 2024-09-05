﻿using Microsoft.EntityFrameworkCore;
using Music.Market.Core.Models;
using Music.Market.Core.Repositories;

namespace Music.Market.Data.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(MusicMarketDbContext context) : base(context)
        {

        }

        private MusicMarketDbContext MusicMarketDbContext
        {
            get { return Context as MusicMarketDbContext; }
        }

        public async Task<IEnumerable<Artist>> GetAllWithMusicsAsync()
        {
            return await MusicMarketDbContext.Artists
                .Include(x => x.Musics)
                .ToListAsync();
        }

        public async Task<Artist> GetWithMusicsByIdAsync(int id)
        {
            return await MusicMarketDbContext.Artists
                .Include(x => x.Musics)
                .SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
