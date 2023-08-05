using Microsoft.EntityFrameworkCore;
using Model.context;
using Model.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.repositories;

public interface IAnimalRepository
{ 
    public Task<Animal?> GetAnimalById(int id);
    public Task<IEnumerable<Animal>> GetAnimals();
    public bool Add(int cellId, int mealId, Animal newAnimal);
    public bool Delete(Animal animal);
    public bool Update(int id, Animal animal);
}
