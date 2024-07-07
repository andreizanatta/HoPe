using HoPe.Application.InputModels;
using HoPe.Application.Services.Interfaces;
using HoPe.Application.ViewModels;
using HoPe.Core.Entities;
using HoPe.Core.Service;
using HoPe.Infrastructure.Persistence;

namespace HoPe.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly HoPeDbContext _dbContext;
        private readonly IAuthService _authService;
        public UserService(HoPeDbContext hoPeDbContext, IAuthService authService)
        {
            _dbContext = hoPeDbContext;
            _authService = authService;
        }

        public UserDetailsViewModel GetById(int id)
        {
            var user = _dbContext.Pet.Single(r => r.Id == id);

            var petDetailsViewModel = new UserDetailsViewModel()
            {
                Nome = user.Name,
            };

            return petDetailsViewModel;
        }

        public int Post(CreateUserInputModel createUserInputModel)
        {
            var passwordCripto = _authService.ComputeSha256(createUserInputModel.Password);
            var user = new User(createUserInputModel.FullName, 
                createUserInputModel.Email, 
                createUserInputModel.Comment, 
                createUserInputModel.BithDate,
                passwordCripto,
                createUserInputModel.Role);

            _dbContext.User.Add(user);
            _dbContext.SaveChanges();
            return user.Id;
        }
    }
}
