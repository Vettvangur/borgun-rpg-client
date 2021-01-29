using BorgunRpgClient.Model.Mpi;
using System.Threading.Tasks;

namespace BorgunRpgClient.API
{
    public interface IMpiAPI
    {
        Task<EnrollmentResponse> EnrollAsync(EnrollmentRequest req);
        Task<ValidationResponse> PaResValidationAsync(string PARes);
    }
}
