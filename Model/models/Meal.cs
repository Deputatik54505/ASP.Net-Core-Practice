namespace Model.models;

/// <summary>
/// Entity which represents meals eaten by animals
/// </summary>
public class Meal
{
    public Meal(string name)
    {
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public List<Animal>? Animals { get; set; } = new();
}