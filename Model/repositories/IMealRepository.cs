using ASPPractice.Model.models;

namespace ASPPractice.Model.repositories;

public interface IMealRepository
{
    public Task<Meal?> GetMeal(int id);
    public Task<IEnumerable<Meal?>> GetMeals();
    public bool DeleteMeal(int id);
    public bool AddMeal(Meal meal);
    public bool UpdateMeal(int id,  Meal meal);
}
