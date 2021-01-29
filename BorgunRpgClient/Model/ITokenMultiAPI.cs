using System.Threading.Tasks;

namespace BorgunRpgClient.Model
{
    public interface ITokenMultiAPI
    {
        Task<TokenMultiResponse> CreateAsync(TokenMultiRequest req);

        Task DisableAsync(string token);

        Task<TokenMultiInfo> GetAsync(string token);

    }
}
