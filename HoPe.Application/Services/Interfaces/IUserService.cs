using HoPe.Application.InputModels;
using HoPe.Application.ViewModels;

namespace HoPe.Application.Services.Interfaces
{
    public interface IUserService
    {
        UserDetailsViewModel GetById(int id);
        int Post(CreateUserInputModel createUserInputModel);
    }
}
