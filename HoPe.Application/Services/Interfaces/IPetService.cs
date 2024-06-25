using HoPe.Application.InputModels;
using HoPe.Application.ViewModels;

namespace HoPe.Application.Services.Interfaces
{
    public interface IPetService
    {
        PetDetailsViewModel GetById(int id);
        List<PetViewModel> Get(string query);
        int Post(CreatePetInputModel createPetInputModel);
        void Update(UpdatePetInputModel createPetInputModel);
        void Delete(int id);
    }
}
