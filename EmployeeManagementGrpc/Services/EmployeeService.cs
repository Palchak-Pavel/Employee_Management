using EmployeeManagementGrpc.Mongodb.Data;
using EmployeeManagementGrpc.Mongodb.Entities;
using EmployeeManagementGrpc.Protos;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Net;

namespace EmployeeManagementGrpc.Services
{
    public class EmployeeService : Employee.EmployeeBase
    {
        private readonly ILogger<EmployeeService> _logger;
        private readonly IMongoEmployeeContext _context;
        public EmployeeService(ILogger<EmployeeService> logger, IMongoEmployeeContext context) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<SalesEmployee>), (int)HttpStatusCode.OK)]
        public override Task<SalesEmployee> GetId(ReplacementExistRequest request, ServerCallContext context, string id)
        {
           
                var salesEmployeeId =  _context.SalesEmployees.Find(x => x.Id == id).FirstOrDefaultAsync();
                if (salesEmployeeId == null) return NotFound();

                return Ok(salesEmployeeId);
            
            // var salesEmployeeId =  _context.SalesEmployees.Find(x => x.Id == id).FirstOrDefaultAsync();
            // ReplacementExistReply output = new ReplacementExistReply();

            // if (request.AssistantId == 1)
            //  {
            //    output.Response = true;
            // }
            //  return Task.FromResult(output);


        }
    }
}
