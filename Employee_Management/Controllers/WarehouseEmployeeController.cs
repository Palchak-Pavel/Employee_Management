using System.Net;
using AutoMapper;
using Employee_Management.Mongodb.Data;
using Employee_Management.Mongodb.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Employee_Management.Controllers;

[ApiController]
[Route("warehouse_emp")]

public class WarehouseEmployeeController : ControllerBase
{
    private readonly IMongoEmployeeManagementContext _context;
    private readonly IMapper _mapper;

    public WarehouseEmployeeController(IMongoEmployeeManagementContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<WarehouseEmployee>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<WarehouseEmployee>>> GetWarehouseEmployee()
    {
        var warehouseEmployee = await _context.WarehouseEmployees.Find(x => true).ToListAsync();
      
        return Ok(warehouseEmployee);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(IEnumerable<WarehouseEmployee>), (int) HttpStatusCode.OK)]
    public async Task<ActionResult<WarehouseEmployee>> GetId(string id)
    {
        var mapWarehouseEmployeeId = await _context.WarehouseEmployees.Find(x => x.Id == id).FirstOrDefaultAsync();
        if (mapWarehouseEmployeeId == null) return NotFound();
        
        return Ok(mapWarehouseEmployeeId);
    }
    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<WarehouseEmployee>), (int) HttpStatusCode.OK)]
    public async Task<ActionResult<WarehouseEmployee>> CreateWarehouseEmployee([FromBody] WarehouseEmployee warehouseEmployee)
    {
        warehouseEmployee.CreatedAt = DateTime.Now;
        await _context.@WarehouseEmployees.InsertOneAsync(warehouseEmployee);
        var result = _mapper.Map<WarehouseEmployee>(warehouseEmployee);
        return Ok(result);
    }
    
    [HttpPut]
    [ProducesResponseType(typeof(WarehouseEmployee), (int)HttpStatusCode.OK)]
    [Route("{id}")]
    public async Task<bool> UpdateWarehouseEmployee(string id, [FromBody] WarehouseEmployee warehouseEmployee)
    {
        var updateWarehouseEmployee = await _context.WarehouseEmployees.
            ReplaceOneAsync(filter: g => g.Id == warehouseEmployee.Id, replacement: warehouseEmployee);

        return updateWarehouseEmployee.IsAcknowledged && updateWarehouseEmployee.ModifiedCount > 0;
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(WarehouseEmployee), (int)HttpStatusCode.OK)]
    public async Task<bool> DeleteWarehouseEmployee(string id)
    {
        FilterDefinition<WarehouseEmployee> filter = Builders<WarehouseEmployee>.Filter.Eq(p => p.Id, id);

        DeleteResult deleteResult = await _context
            .WarehouseEmployees
            .DeleteOneAsync(filter);

        return deleteResult.IsAcknowledged
               && deleteResult.DeletedCount > 0;
    }
}