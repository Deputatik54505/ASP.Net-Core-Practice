namespace ASPPractice.Model.Dto;

/// <summary>
/// DTO which encapsulates data of meal for data representation
/// </summary>
public class MealDto
{
    public MealDto(string name)
    {
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }
}
