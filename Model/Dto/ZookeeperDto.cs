namespace Model.Dto;
/// <summary>
/// DTO which encapsulates data of zookeeper for data representation
/// </summary>
public class ZookeeperDto
{
    public ZookeeperDto(string firstName)
    {
        FirstName = firstName;
    }

    public int Id { get; set; }
    public string FirstName { get; set; }
}
