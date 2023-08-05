namespace ASPPractice.Model.models;
/// <summary>
/// Entity which represents cell with animals
/// </summary>
public class Cell
{
    public Cell(string name)
    {
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public List<Animal>? Animals { get; set; } = new();
}