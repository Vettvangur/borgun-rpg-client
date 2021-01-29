using System.Threading.Tasks;

namespace BorgunRpgClient.Model
{
    public interface ITokenSingleAPI
    {
        Task<TokenSingleResponse> CreateAsync(TokenSingleRequest req);

        Task DisableAsync(string token);

        Task<TokenSingleInfo> GetAsync(string token);
    }
}
