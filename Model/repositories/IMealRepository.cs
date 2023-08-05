using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.models;

namespace Model.repositories;

public interface IMealRepository
{
    public Task<Meal?> GetMeal(int id);
    public Task<IEnumerable<Meal?>> GetMeals();
    public bool DeleteMeal(int id);
    public bool AddMeal(Meal meal);
    public bool UpdateMeal(int id,  Meal meal);
}
