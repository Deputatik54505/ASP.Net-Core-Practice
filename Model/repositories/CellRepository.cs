using ASPPractice.Model.context;
using ASPPractice.Model.models;
using Microsoft.EntityFrameworkCore;

namespace ASPPractice.Model.repositories;
/// <summary>
/// Repository for work with cells in database
/// </summary>
public class CellRepository : ICellRepository
{
    private readonly ApplicationContext _context;

    public CellRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets cell from database by Id
    /// </summary>
    /// <param name="id"> id of cell to be get</param>
    /// <returns>Task with cell if it was found. Otherwise, Task with null</returns>
    public async Task<Cell?> GetCell(int id)
    {
        return await _context.Cells.FirstOrDefaultAsync(c => c.Id == id);
    }

    /// <summary>
    /// Gets cell from database by name
    /// </summary>
    /// <param name="name"> name of cell to be get</param>
    /// <returns>Task with cell if it was found. Otherwise, Task with null</returns>
    public async Task<Cell?> GetCell(string name)
    {
        return await _context.Cells.FirstOrDefaultAsync(c => c.Name == name);
    }
    /// <summary>
    /// Gets all cells from database
    /// </summary>
    /// <returns>Task with IEnumerable of all cells in context</returns>
    public async Task<IEnumerable<Cell>> GetCells()
    {
        return await _context.Cells.OrderBy(c => c.Id).ToListAsync();
    }


    /// <summary>
    /// Gets all animals which are lives in cell
    /// </summary>
    /// <param name="cellId"> Id of cell we are open</param>
    /// <returns>Task with IEnumerable of all animals in cell</returns>
    public async Task<IEnumerable<Animal>> GetAnimals(int cellId)
    {
        return await _context.Animals.Where(a => a.CellId == cellId).ToListAsync();
    }


    /// <summary>
    /// Remove cell from the database
    /// </summary>
    /// <param name="id">id of cell to be removed</param>
    /// <returns>true if all was done well, otherwise false</returns>
    public bool RemoveCell(int id)
    {
        var cell = GetCell(id).Result;
        if (cell == null)
            return false;
        _context.Cells.Remove(cell);
        return Save();
    }

    /// <summary>
    /// Add cell to the database
    /// </summary>
    /// <param name="cell">cell to be added</param>
    /// <returns>true if all was done well, otherwise false</returns>
    public bool AddCell(Cell cell)
    {
        _context.Cells.Add(cell);
        return Save();
    }


    /// <summary>
    /// Change values of existing cell
    /// </summary>
    /// <param name="id">id of cell will be changed</param>
    /// <param name="cell"> an entity with new parameters</param>
    /// <returns>true if all was done well, otherwise false</returns>
    public bool UpdateCell(int id, Cell cell)
    {
        var prevCell = GetCell(id).Result;
        if (prevCell == null)
            return false;
        if (cell.Id != id)
            return false;

        _context.Cells.Remove(prevCell);
        _context.Cells.Add(cell);
        return Save();
    }

    /// <summary>
    /// Save changes to the database
    /// </summary>
    /// <returns>true if all was done well, otherwise false</returns>
    private bool Save()
    {
        return _context.SaveChanges() > 0;
    }
}

