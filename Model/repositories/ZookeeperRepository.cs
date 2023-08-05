using ASPPractice.Model.context;
using ASPPractice.Model.models;
using Microsoft.EntityFrameworkCore;

namespace ASPPractice.Model.repositories;

public class ZookeeperRepository : IZookeeperRepository
{
    private readonly ApplicationContext _context;

    public ZookeeperRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets zookeeper from context by id
    /// </summary>
    /// <param name="id"> Id of zookeeper to be get</param>
    /// <returns> Task with zookeeper, if it was found. Otherwise, Task with null</returns>
    public async Task<Zookeeper?> GetZookeeper(int id)
    {
        return await _context.Zookeepers.FirstOrDefaultAsync(z => z.Id == id);
    }

    /// <summary>
    /// Gets all zookeepers from database
    /// </summary>
    /// <returns> Task with all zookeepers in database</returns>
    public async Task<IEnumerable<Zookeeper?>> GetZookeepers()
    {
        return await _context.Zookeepers.OrderBy(z => z.Id).ToListAsync();
    }

    /// <summary>
    /// Removes zookeeper from database
    /// </summary>
    /// <param name="id"> Id of zookeeper that will be removed</param>
    /// <returns> True if all was done well, otherwise false</returns>
    public bool RemoveZookeeper(int id)
    {
        var zookeeper = GetZookeeper(id).Result;
        if (zookeeper == null) return false;
        _context.Zookeepers.Remove(zookeeper);
        return Save();
    }

    /// <summary>
    /// Adds zookeeper to the database
    /// </summary>
    /// <param name="zookeeper"> Zookeeper to be added</param>
    /// <returns> True if all was done well, otherwise false</returns>
    public bool AddZookeeper(Zookeeper zookeeper)
    {
        if (_context.Zookeepers.Any(z => z.Id == zookeeper.Id))
            return false;
        _context.Zookeepers.Add(zookeeper);
        return Save();
    }

    /// <summary>
    /// Updates existing zookeeper
    /// </summary>
    /// <param name="id"> Id of zookeeper to be updated</param>
    /// <param name="zookeeper"> Entity with new parameters</param>
    /// <returns> True if all was done well, otherwise false</returns>
    public bool UpdateZookeeper(int id, Zookeeper zookeeper)
    {
        if (id != zookeeper.Id)
            return false;
        var prevZookeeper = GetZookeeper(id).Result;
        if (prevZookeeper == null)
            return false;
        _context.Zookeepers.Remove(prevZookeeper);
        _context.Zookeepers.Add(zookeeper);
        return Save();
    }


    /// <summary>
    /// Saves changes in database
    /// </summary>
    /// <returns> True if all was done well, otherwise false</returns>
    private bool Save()
    {
        return _context.SaveChanges() > 0;
    }
}

