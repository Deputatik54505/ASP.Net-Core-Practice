using ASPPractice.Model.models;

namespace ASPPractice.Model.repositories;

public interface IAnimalRepository
{ 
    public Task<Animal?> GetAnimalById(int id);
    public Task<IEnumerable<Animal>> GetAnimals();
    public bool Add(int cellId, int mealId, Animal newAnimal);
    public bool Delete(Animal animal);
    public bool Update(int id, Animal animal);
}
