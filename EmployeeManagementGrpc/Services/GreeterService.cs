using Grpc.Core;
using EmployeeManagementGrpc.Mongodb.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using EmployeeManagementGrpc.Mongodb.Entities;
using MongoDB.Driver;

namespace EmployeeManagementGrpc.Services;

public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;
    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }


    //[HttpGet("{id}")]
    //[ProducesResponseType(typeof(IEnumerable<SalesEmployee>), (int)HttpStatusCode.OK)]
    //public async Task<ActionResult<IEnumerable<SalesEmployee>>> GetId( ReplacementExistRequest request, EmployeeManagementContext context, string id )
    //{
    //    var salesEmployeeId = await _context.SalesEmployees.Find(x => x.Id == id).FirstOrDefaultAsync();

    //    return Task.FromResult(new ReplacementExistReply
    //    {
    //        SalesEmployeeId = request.salesEmployeeId
    //    });
    //}
    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        // формирование ответа
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        }) ;
    }

}