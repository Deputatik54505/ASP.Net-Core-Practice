using ASPPractice.Model.models;

namespace ASPPractice.Model.repositories;

public interface IZookeeperRepository
{
    public Task<Zookeeper?> GetZookeeper(int id);
    public Task<IEnumerable<Zookeeper?>> GetZookeepers();
    public bool RemoveZookeeper(int id);
    public bool AddZookeeper(Zookeeper zookeeper);
    public bool UpdateZookeeper(int id, Zookeeper zookeeper);
}

