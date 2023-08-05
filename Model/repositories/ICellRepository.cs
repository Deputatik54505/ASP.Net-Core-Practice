using ASPPractice.Model.models;

namespace ASPPractice.Model.repositories;

public interface ICellRepository
{
    public Task<IEnumerable<Cell>> GetCells();
    public Task<Cell?> GetCell(int id);
    public Task<Cell?> GetCell(string name);
    public Task<IEnumerable<Animal>> GetAnimals(int cellId);
    public bool AddCell(Cell cell);
    public bool RemoveCell(int id);
    public bool UpdateCell(int id, Cell cell);
}

