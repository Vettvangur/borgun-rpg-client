using BorgunRpgClient.Model.Mpi;
using System.Threading.Tasks;

namespace BorgunRpgClient.API
{
    public interface IMpiAPI
    {
        Task<EnrollmentResponse> EnrollAsync(EnrollmentRequest req);
        Task<object> PaResValidationAsync(string PARes);
    }
}