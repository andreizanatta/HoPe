using HoPe.Application.InputModels;
using HoPe.Application.Services.Interfaces;
using HoPe.Application.ViewModels;
using HoPe.Core.Entities;
using HoPe.Infrastructure.Persistence;

namespace HoPe.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly HoPeDbContext _dbContext;
        public UserService(HoPeDbContext hoPeDbContext)
        {
            _dbContext = hoPeDbContext;
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
            var user = new User(createUserInputModel.FullName, createUserInputModel.Email, createUserInputModel.Comment, createUserInputModel.BithDate);

            _dbContext.User.Add(user);
            return user.Id;
        }
    }
}
