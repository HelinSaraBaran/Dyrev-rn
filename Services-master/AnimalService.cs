using System.Collections.Generic;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Repositories;

namespace Service
{
    public class AnimalService
    {
        private IAnimalRepository _animalRepository;

        public AnimalService()
        {
            _animalRepository = new AnimalRepository();
        }

        public List<Animal> GetAllAnimals()
        {
            return _animalRepository.GetAll();
        }

        public List<Animal> FilterBySpecies(string species)
        {
            List<Animal> allAnimals = _animalRepository.GetAll();
            List<Animal> filtered = new List<Animal>();

            foreach (Animal animal in allAnimals)
            {
                if (species == "" || animal.Species == species)
                {
                    filtered.Add(animal);
                }
            }

            return filtered;
        }

        
        public void AddAnimal(Animal animal)
        {
            _animalRepository.Add(animal);
        }

        public void SaveAnimals(List<Animal> animals)
        {
            _animalRepository.SaveAll(animals);
        }
    }
}
