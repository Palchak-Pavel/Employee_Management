using Employee_Management.Common;

namespace Employee_Management.Mongodb.ValueObjects;

public class Replacement : ValueObject
{
    public Replacement(ReplacementEmployee employee, DateTime from, DateTime to)
    {
        Employee = employee;
        From = from;
        To = to;
    }
    public ReplacementEmployee Employee { get; private set; }
    public DateTime From { get; private set; }
    public DateTime To { get; private set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Employee;
        yield return From;
        yield return To;
    }
    
}