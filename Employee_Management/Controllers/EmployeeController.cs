using System.Net;
using AutoMapper;
using Employee_Management.Mongodb.Data;
using Employee_Management.Mongodb.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Employee_Management.Controllers;

[ApiController]
[Route("employee")]

public class EmployeeController : ControllerBase
{
    private readonly IMongoEmployeeManagementContext _context;
    private readonly IMapper _mapper;
    
    public EmployeeController(IMongoEmployeeManagementContext context , IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Employee>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
    {
        var employee = await _context.Employees.Find(x => true).ToListAsync();
      
        return Ok(employee);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(IEnumerable<Employee>), (int) HttpStatusCode.OK)]
    public async Task<ActionResult<Employee>> GetId(string id)
    {
        var employeeId = await _context.Employees.Find(x => x.Id == id).FirstOrDefaultAsync();
        if (employeeId == null) return NotFound();
        
        return Ok(employeeId);
    }
    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<Employee>), (int) HttpStatusCode.OK)]
    public async Task<ActionResult<Employee>> CreateEmployee([FromBody] Employee employee)
    {
        employee.CreatedAt = DateTime.Now;
        await _context.Employees.InsertOneAsync(employee);
        var result = _mapper.Map<Employee>(employee);
        return Ok(result);
    }
    
    [HttpPut]
    [ProducesResponseType(typeof(Employee), (int)HttpStatusCode.OK)]
    [Route("{id}")]
    public async Task<bool> UpdateEmployee(string id, [FromBody] Employee employee)
    {
        var updateEmployee = await _context.Employees.
            ReplaceOneAsync(filter: g => g.Id == employee.Id, replacement: employee);

        return updateEmployee.IsAcknowledged && updateEmployee.ModifiedCount > 0;
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(Employee), (int)HttpStatusCode.OK)]
    public async Task<bool> DeleteEmployee(string id)
    {
        FilterDefinition<Employee> filter = Builders<Employee>.Filter.Eq(p => p.Id, id);

        DeleteResult deleteResult = await _context
            .Employees
            .DeleteOneAsync(filter);

        return deleteResult.IsAcknowledged
               && deleteResult.DeletedCount > 0;
    }
}