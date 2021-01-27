using System.Threading.Tasks;

namespace BorgunRpgClient.Model
{
    public interface ITokenSingleAPI
    {
        Task<TokenSingleResponse> CreateAsync(TokenSingleRequest req);

        Task<TokenSingleResponse> DisableAsync(string token);

        Task<TokenSingleResponse> GetAsync(string token);
    }
}