using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TablesController : ControllerBase
{
    private readonly ITableService _tableService;

    public TablesController(ITableService tableService)
    {
        _tableService = tableService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTables() =>
        Ok(await _tableService.GetAllTablesAsync());

    [HttpPost]
    public async Task<IActionResult> CreateTable([FromBody] CreateTableRequest request) =>
        Ok(await _tableService.CreateTableAsync(request));

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTable(int id, [FromBody] UpdateTableRequest request) =>
        Ok(await _tableService.UpdateTableAsync(id, request));
}
