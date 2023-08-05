namespace Model.models;
/// <summary>
/// Entity which represent animal
/// </summary>
public class Animal
{
	public Animal(string animalName)
    {
        this.AnimalName = animalName;
    }
	public int Id { get; set; }
	public string AnimalName { get; set; }
	public Cell Cell { get; set; }
	public int CellId { get; set; }
	public Meal MainMeal { get; set; }
	public int MainMealId { get; set; }

	public List<Zookeeper> Zookeepers { get; set; } = new();

}