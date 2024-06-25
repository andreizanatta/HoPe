using HoPe.Application.InputModels;
using HoPe.Application.Services.Interfaces;
using HoPe.Application.ViewModels;
using HoPe.Core.Entities;
using HoPe.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoPe.Application.Services.Implementations
{
    public class PetService : IPetService
    {
        private readonly HoPeDbContext _dbContext;
        public PetService(HoPeDbContext hoPeDbContext)
        {
            _dbContext = hoPeDbContext;
        }
        public void Delete(int id)
        {
            var pet = _dbContext.Pet.FirstOrDefault(pet => pet.Id == id);
            pet?.Disable();
        }

        public List<PetViewModel> Get(string query)
        {
            var pets = _dbContext.Pet.AsQueryable();

            var petsViewModel = pets.Select(r => new PetViewModel()
            {
                Nome = r.Comment,
            }).ToList();

            return petsViewModel;
        }

        public PetDetailsViewModel GetById(int id)
        {
            var pet = _dbContext.Pet.Single(r => r.Id == id);

            var petDetailsViewModel = new PetDetailsViewModel()
            {
                Nome = pet.Name
            };

            return petDetailsViewModel;
        }

        public int Post(CreatePetInputModel createPetInputModel)
        {
            var pet = new Pet(createPetInputModel.Comment, createPetInputModel.Name);

            _dbContext.Pet.Add(pet);
            return pet.Id;
        }

        public void Update(UpdatePetInputModel updatePetInputModel)
        {
            var pet = _dbContext.Pet.Single(r => r.Id == updatePetInputModel.Id);
            pet.Update(updatePetInputModel.Name, updatePetInputModel.Comment);
        }
    }
}
