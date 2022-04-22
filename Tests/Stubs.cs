

namespace Tests;

public class StubBaseDimension : BaseDimension, IDefinedDimension<StubBaseDimension>
{
    public StubBaseDimension() : base("Stub", "S")
    {
    }
}

public class StubBaseDimension2 : BaseDimension, IDefinedDimension<StubBaseDimension>
{
    public StubBaseDimension2() : base("Stub2", "S2")
    {
    }
}
