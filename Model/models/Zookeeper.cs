namespace Model.models;
/// <summary>
/// Entity which represents worker which takes care of animals
/// </summary>
public class Zookeeper
{
    public Zookeeper(string firstName)
    {
        FirstName = firstName;
    }

    public int Id { get; set; }
    public string FirstName { get; set; }

    public List<Animal> Animals { get; set; } = new();

}
