using Music.Market.Core.Models;

namespace Music.Market.Api.DTO
{
    public class MusicDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Artist Artist { get; set; }
    }
}
