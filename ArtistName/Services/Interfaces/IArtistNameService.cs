using ArtistName.DTO;
using System.Threading.Tasks;

namespace ArtistName.Services.Interfaces
{
    public interface IArtistNameService
    {
        Task<ArtistNameDto> GetArtistNameAsync(string name);
    }
}
