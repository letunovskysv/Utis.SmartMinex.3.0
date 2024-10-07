using System.IO;
using System.Dynamic;

dynamic test = new DynamicTest();
test.Name = "test";

Console.WriteLine(test.Name);

DynamicObject d;

public class DynamicTest : DynamicObject
{
    public override bool TrySetMember(SetMemberBinder binder, object? value)
    {
        return true;
    }

    public override bool TryGetMember(GetMemberBinder binder,
                                      out object result)
    {
        result = null;
        return result == null ? false : true;
    }
}
