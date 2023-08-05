namespace Model.Dto;

/// <summary>
/// DTO which encapsulates data of cell for data representation
/// </summary>
public class CellDto
{
    public CellDto(string name)
    {
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }
}