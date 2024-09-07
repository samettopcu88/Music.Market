using Music.Market.Core;
using Music.Market.Core.Models;
using Music.Market.Core.Services;

namespace Music.Market.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IUnitOfWork unitOfWork;

        public ArtistService(IUnitOfWork _unitOfwork)
        {
            this.unitOfWork = _unitOfwork;
        }

        public async Task<Artist> CreateArtist(Artist newArtist)
        {
            await unitOfWork.Artists.AddAsync(newArtist);
            unitOfWork.CommitAsync();
            return newArtist;
        }

        public async Task DeleteArtist(Artist artist)
        {
            unitOfWork.Artists.RemoveAsync(artist);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Artist>> GetAllArtists()
        {
            return await unitOfWork.Artists.GetAllAsync();
        }

        public async Task<Artist> GetArtistById(int id)
        {
            return await unitOfWork.Artists.GetByIdAsync(id);
        }

        public async Task UpdateArtist(Artist artistToBeUpdated, Artist artist)
        {
            artistToBeUpdated.Name = artist.Name;
            await unitOfWork.CommitAsync();
        }
    }
}
