using System.Threading.Tasks;

namespace BorgunRpgClient.Model
{
    public interface ITokenMultiAPI
    {
        Task<TokenMultiResponse> CreateAsync(TokenMultiRequest req);

        Task<TokenMultiResponse> DisableAsync(string token);

        Task<TokenMultiResponse> GetAsync(string token);

    }
}