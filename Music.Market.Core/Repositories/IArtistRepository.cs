using Music.Market.Core.Models;

namespace Music.Market.Core.Repositories
{
    public interface IArtistRepository: IRepository<Artist>
    {
        Task<IEnumerable<Artist>> GetAllWithMusicsAsync();
        Task<Artist> GetWithMusicsByIdAsync(int id);
    }
}
