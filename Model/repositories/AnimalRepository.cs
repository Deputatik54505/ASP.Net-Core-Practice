using Microsoft.EntityFrameworkCore;
using Model.context;
using Model.models;
using NLog;

namespace Model.repositories;

/// <summary>
/// Repository for work with animals in database
/// </summary>
public class AnimalRepository : IAnimalRepository
{
    private readonly ApplicationContext _context;
    private static readonly Logger Logger = NLog.LogManager.GetCurrentClassLogger();
    public AnimalRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets animal from database
    /// </summary>
    /// <param name="id"> Id of searched animal</param>
    /// <returns> Task with animal, if it was found. Task with null, otherwise</returns>
    public async Task<Animal?> GetAnimalById(int id)
    {
        return await _context.Animals.Where(a => a != null && a.Id == id).FirstOrDefaultAsync();
    }

    /// <summary>
    /// Returns all animals in database
    /// </summary>
    /// <returns> Task with all animals in database</returns>
    public async Task<IEnumerable<Animal>> GetAnimals()
    {
        return await _context.Animals.OrderBy(a => a.Id).ToListAsync();
    }

    /// <summary>
    /// Adds animal to the database
    /// </summary>
    /// <param name="cellId"> id of cell where animal lives</param>
    /// <param name="mealId"> id of meal which animal eats</param>
    /// <param name="newAnimal"> entity of animal</param>
    /// <returns>true if all was done well, otherwise false</returns>
    public bool Add(int cellId, int mealId, Animal newAnimal)
    {
        var cell = _context.Cells.FirstOrDefault(c => c.Id == cellId);
        var meal = _context.Meals.FirstOrDefault(m => m.Id == mealId);

        if (cell == null)
        {
            Logger.Error("cell by {cellId} not found");
            return false;
        }
        if (meal == null)
        {
            Logger.Error("meal by {mealId} not found");
            return false;
        }
        newAnimal.CellId = cellId;
        newAnimal.MainMealId = mealId;

        newAnimal.Cell = cell;
        newAnimal.MainMeal = meal;

        _context.Animals.Add(newAnimal);

        Logger.Info("animal{newAnimal} added to {_context.Animals} from {_context}");
        return SaveChanges();
    }
    /// <summary>
    /// Deletes animal from the database.
    /// </summary>
    /// <param name="animal"> animal to delete </param>
    /// <returns>true if all was done well, otherwise false </returns>
    public bool Delete(Animal animal)
    {
        _context.Animals.Remove(animal);
        Logger.Info("animal{animal} removed from {_context}");
        return SaveChanges();
    }
    /// <summary>
    /// Changes values of existing animal
    /// </summary>
    /// <param name="id"> Id of animal to be changed</param>
    /// <param name="animal"> An entity with new parameters </param>
    /// <returns> True if all was done well, otherwise false</returns>
    public bool Update(int id, Animal animal)
    {
        Animal? prevAnimal = _context.Animals.Find(id);
        if (prevAnimal != null)
        {
            _context.Animals.Remove(prevAnimal);
            Logger.Info("animal{prevAnimal} removed from {_context}");
            _context.Add(animal);
            Logger.Info("animal{animal} added to {_context}");
            return SaveChanges();
        }
        Logger.Warn("animal with id {id} was not updated, because was not fount in {_context.Animals} from {_context}");
        return false;
    }

    /// <summary>
    /// Saves changes in database
    /// </summary>
    /// <returns> True if all was done well, otherwise false</returns>
    private bool SaveChanges()
    {
        Logger.Info("context{_context} is saving");
        return _context.SaveChanges() > 0;
    }



}
