public interface ITableService
{
    Task<IEnumerable<TableResponse>> GetAllTablesAsync();
    Task<TableResponse> CreateTableAsync(CreateTableRequest request);
    Task<TableResponse> UpdateTableAsync(int id, UpdateTableRequest request);
}
