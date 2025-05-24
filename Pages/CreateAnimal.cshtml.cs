using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Domain.Models;
using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    // Repository der håndterer læsning og skrivning af dyr til/fra JSON-fil
    public class AnimalRepository : IAnimalRepository
    {
        private const string JsonPath = "Data/animals.json"; // Sti til filen
        private List<Animal> _animals; // Intern liste med alle dyr

        // Constructor – indlæser data fra JSON-filen
        public AnimalRepository()
        {
            if (File.Exists(JsonPath))
            {
                string json = File.ReadAllText(JsonPath);
                _animals = JsonSerializer.Deserialize<List<Animal>>(json);
            }
            else
            {
                _animals = new List<Animal>();
            }
        }

        // Returnerer alle dyr
        public List<Animal> GetAll()
        {
            return _animals;
        }

        // Returnerer ét dyr ud fra ID
        public Animal GetById(int id)
        {
            foreach (Animal animal in _animals)
            {
                if (animal.Id == id)
                {
                    return animal;
                }
            }
            return null;
        }

        // Gemmer hele listen af dyr til fil
        public void SaveAll(List<Animal> animals)
        {
            _animals = animals;

            string json = JsonSerializer.Serialize(_animals, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            Directory.CreateDirectory("Data");
            File.WriteAllText(JsonPath, json);
        }

        // Tilføjer et nyt dyr og giver det automatisk ID
        public void Add(Animal animal)
        {
            int maxId = 0;

            foreach (Animal a in _animals)
            {
                if (a.Id > maxId)
                {
                    maxId = a.Id;
                }
            }

            animal.Id = maxId + 1;
            _animals.Add(animal);
            SaveAll(_animals);
        }
    }
}
