using System.Net;
using AutoMapper;
using Employee_Management.Mongodb.Data;
using Employee_Management.Mongodb.Entities;
using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management.Controllers;

[ApiController]
[Route("driver")]

public class DriverController : ControllerBase
{
    private readonly IMongoEmployeeManagementContext _context;
    private readonly IMapper _mapper;
    
    public DriverController(IMongoEmployeeManagementContext context , IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Driver>), (int)HttpStatusCode.OK)]
    
    public async Task<ActionResult<IEnumerable<Driver>>> GetDrivers()
    {
        var drivers = await _context.Drivers.Find(x => true).ToListAsync();
      
        return Ok(drivers);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(IEnumerable<Driver>), (int) HttpStatusCode.OK)]
    public async Task<ActionResult<Driver>> GetId(string id)
    {
        var driverId = await _context.Drivers.Find(x => x.Id == id).FirstOrDefaultAsync();
        if (driverId == null) return NotFound();
        
        return Ok(driverId);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<Driver>), (int) HttpStatusCode.OK)]
    public async Task<ActionResult<Driver>> CreateDriver([FromBody] Driver driver)
    {
        driver.CreatedAt = DateTime.Now;
        await _context.Drivers.InsertOneAsync(driver);
        var result = _mapper.Map<Driver>(driver);
        return Ok(result);
    }
    
    [HttpPut]
    [ProducesResponseType(typeof(Driver), (int)HttpStatusCode.OK)]
    [Route("{id}")]
    public async Task<bool> UpdateDriver(string id, [FromBody] Driver driver)
    {
        var updateDriver = await _context.Drivers.
            ReplaceOneAsync(filter: g => g.Id == driver.Id, replacement: driver);

        return updateDriver.IsAcknowledged && updateDriver.ModifiedCount > 0;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(Driver), (int)HttpStatusCode.OK)]
    public async Task<bool> DeleteDriver(string id)
    {
        FilterDefinition<Driver> filter = Builders<Driver>.Filter.Eq(p => p.Id, id);

        DeleteResult deleteResult = await _context
            .Drivers
            .DeleteOneAsync(filter);

        return deleteResult.IsAcknowledged
               && deleteResult.DeletedCount > 0;
    }
}

