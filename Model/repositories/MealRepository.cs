using Microsoft.EntityFrameworkCore;
using Model.context;
using Model.models;

namespace Model.repositories;

public class MealRepository : IMealRepository
{
    private readonly ApplicationContext _context;

    public MealRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets meal from the database by id
    /// </summary>
    /// <param name="id"> Id of meal to be get</param>
    /// <returns> Task with meal, if it was found. Otherwise, Task with null</returns>
    public async Task<Meal?> GetMeal(int id)
    {
        return await _context.Meals.FirstOrDefaultAsync(m => m.Id == id);
    }

    /// <summary>
    /// Gets all meals in the context
    /// </summary>
    /// <returns> Task with IEnumerable of meals</returns>
    public async Task<IEnumerable<Meal?>> GetMeals()
    {
        return await _context.Meals.OrderBy(a => a.Id).ToListAsync();
    }

    /// <summary>
    /// Deletes meal from the database
    /// </summary>
    /// <param name="id"> Id of meal to be deleted</param>
    /// <returns> True if all was done well, otherwise false</returns>
    public bool DeleteMeal(int id)
    {
        var meal = GetMeal(id).Result;
        if (meal == null)
            return false;
        _context.Meals.Remove(meal);
        return Save();
    }
    /// <summary>
    /// Adds meal to the database 
    /// </summary>
    /// <param name="meal"> Entity to be added</param>
    /// <returns> True if all was done well, otherwise false</returns>
    public bool AddMeal(Meal meal)
    {
        if (_context.Meals.Any(m => m.Id == meal.Id))
            return false;
        _context.Meals.Add(meal);
        return Save();
    }

    /// <summary>
    /// Changes values of existing meal
    /// </summary>
    /// <param name="id"> Id of meal to be changed</param>
    /// <param name="meal"> An entity with new parameters</param>
    /// <returns> True if all was done well, otherwise false</returns>
    public bool UpdateMeal(int id, Meal meal)
    {
        if (id != meal.Id)
            return false;
        var prevMeal = GetMeal(id).Result;
        if (prevMeal == null)
            return false;
        _context.Meals.Remove(prevMeal);
        _context.Meals.Add(meal);
        return Save();
    }

    /// <summary>
    /// Saves changes in database
    /// </summary>
    /// <returns> True if all was done well, otherwise false</returns>
    public bool Save()
    {
        return _context.SaveChanges() > 0;
    }
}
