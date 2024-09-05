namespace Music.Market.Core.Repositories
{
    public interface IMusicRepository:IRepository<Models.Music>
    {
        Task<IEnumerable<Models.Music>> GetAllWithArtistAsync();
        Task<Models.Music> GetWithArtistByIdAsync(int id);
        Task<IEnumerable<Models.Music>> GetAllWithArtistByArtistIdAsync(int artistId);
    }
}
