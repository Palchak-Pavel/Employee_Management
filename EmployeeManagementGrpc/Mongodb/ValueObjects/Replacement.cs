using EmployeeManagementGrpc.Common;

namespace EmployeeManagementGrpc.Mongodb.ValueObjects;

public class Replacement : ValueObject
{
    public Replacement(ReplacementEmployee employee)
    {
        Employee = employee;
  
    }
    public ReplacementEmployee Employee { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Employee;
    }
    
}