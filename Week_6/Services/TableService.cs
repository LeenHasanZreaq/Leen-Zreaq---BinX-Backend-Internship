
using MyWebProject.Models;
using MyWebProject.DTOs;

public class TableService : ITableService
{
    private readonly ITableRepository _repository;

    public TableService(ITableRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TableResponse>> GetAllTablesAsync()
    {
        var tables = await _repository.GetAllAsync();
        return tables.Select(t => new TableResponse { Id = t.Id, Number = t.Number, Capacity = t.Capacity });
    }

    public async Task<TableResponse> CreateTableAsync(CreateTableRequest request)
    {
        var table = new RestaurantTable { Number = request.Number, Capacity = request.Capacity };
        await _repository.AddAsync(table);
        return new TableResponse { Id = table.Id, Number = table.Number, Capacity = table.Capacity };
    }

    public async Task<TableResponse> UpdateTableAsync(int id, UpdateTableRequest request)
    {
        var table = await _repository.GetByIdAsync(id);
        if (table == null) throw new Exception("Table not found");

        table.Number = request.Number;
        table.Capacity = request.Capacity;
        await _repository.UpdateAsync(table);

        return new TableResponse { Id = table.Id, Number = table.Number, Capacity = table.Capacity };
    }
}
