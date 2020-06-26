using System.Threading.Tasks;
using eShopSolution.ViewModels.System.Users;

namespace eShopSolution.Application.System.Users
{
    public interface IUsersService
    {
        Task<string> Authenticate(LoginRequest request);
        Task<bool> Register(RegisterRequest request);
    }
}