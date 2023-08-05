using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.models;

namespace Model.repositories;

public interface IZookeeperRepository
{
    public Task<Zookeeper?> GetZookeeper(int id);
    public Task<IEnumerable<Zookeeper?>> GetZookeepers();
    public bool RemoveZookeeper(int id);
    public bool AddZookeeper(Zookeeper zookeeper);
    public bool UpdateZookeeper(int id, Zookeeper zookeeper);
}

