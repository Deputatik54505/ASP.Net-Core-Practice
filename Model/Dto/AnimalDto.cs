namespace ASPPractice.Model.Dto;

/// <summary>
/// DTO which encapsulates data of animal for data representation
/// </summary>
public class AnimalDto
{
	public int Id { get; set; }
    public string AnimalName { get; set; }
    public int CellId { get; set; }
    public int MainMealId { get; set; }
}

