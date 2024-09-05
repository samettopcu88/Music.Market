namespace Music.Market.Core.Services
{
    public interface IMusicService
    {
        Task<IEnumerable<Models.Music>> GetAllWithArtist();
        Task<Models.Music> GetMusicById(int id);
        Task<IEnumerable<Models.Music>> GetMusicByArtistId(int artistId);
        Task<Models.Music> CreateMusic(Models.Music newMusic);
        Task<Models.Music> UpdateMusic(Models.Music musicToBeUpdated, Models.Music music);
        Task<Models.Music> DeleteMusic(Models.Music music);

    }
}
