using Employee_Management.Common;

namespace Employee_Management.Mongodb.ValueObjects;

public class Car : ValueObject
{
    public Car(string mark, string number)
    {
        Mark = mark;
        Number = number;
    }
    public string Mark { get; private set; }
    public string Number { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Mark;
        yield return Number;
    }
}