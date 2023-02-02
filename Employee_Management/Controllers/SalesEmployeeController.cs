using System.Net;
using AutoMapper;
using Employee_Management.Mongodb.Data;
using Employee_Management.Mongodb.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Employee_Management.Controllers;

[ApiController]
[Route("sales_employee")]

public class SalesEmployeeController : ControllerBase
{
    private readonly IMongoEmployeeManagementContext _context;
    private readonly IMapper _mapper;

    public SalesEmployeeController(IMongoEmployeeManagementContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<SalesEmployee>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<SalesEmployee>>> GetSalesEmployee()
    {
        var salesEmployee = await _context.SalesEmployees.Find(x => true).ToListAsync();
      
        return Ok(salesEmployee);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(IEnumerable<SalesEmployee>), (int) HttpStatusCode.OK)]
    public async Task<ActionResult<SalesEmployee>> GetId(string id)
    {
        var salesEmployeeId = await _context.SalesEmployees.Find(x => x.Id == id).FirstOrDefaultAsync();
        if (salesEmployeeId == null) return NotFound();
        
        return Ok(salesEmployeeId);
    }
    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<SalesEmployee>), (int) HttpStatusCode.OK)]
    public async Task<ActionResult<SalesEmployee>> CreateSalesEmployee([FromBody] SalesEmployee salesEmployee)
    {
        salesEmployee.CreatedAt = DateTime.Now;
        await _context.SalesEmployees.InsertOneAsync(salesEmployee);
        var result = _mapper.Map<SalesEmployee>(salesEmployee);
        return Ok(result);
    }
    
    [HttpPut]
    [ProducesResponseType(typeof(SalesEmployee), (int)HttpStatusCode.OK)]
    [Route("{id}")]
    public async Task<bool> UpdateSalesEmployee(string id, [FromBody] SalesEmployee salesEmployee)
    {
        var updateSalesEmployee = await _context.SalesEmployees.
            ReplaceOneAsync(filter: g => g.Id == salesEmployee.Id, replacement: salesEmployee);

        return updateSalesEmployee.IsAcknowledged && updateSalesEmployee.ModifiedCount > 0;
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(SalesEmployee), (int)HttpStatusCode.OK)]
    public async Task<bool> DeleteSalesEmployee(string id)
    {
        FilterDefinition<SalesEmployee> filter = Builders<SalesEmployee>.Filter.Eq(p => p.Id, id);

        DeleteResult deleteResult = await _context
            .SalesEmployees
            .DeleteOneAsync(filter);

        return deleteResult.IsAcknowledged
               && deleteResult.DeletedCount > 0;
    }
}