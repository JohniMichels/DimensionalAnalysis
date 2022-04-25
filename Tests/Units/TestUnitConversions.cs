namespace Tests;

public class TestUnitConversion
{
    [Fact]
    public void TestLinearUnit()
    {
        var unit = new LinearUnit<StubBaseDimension>("kilometer", "km", 1000);
        unit.FromSI<double, double>(1000.0).Should().Be(1.0);
        unit.ToSI<double, double>(1.0).Should().Be(1000.0);
    }

    [Fact]
    public void TestAffineUnit()
    {
        var unit = new AffineUnit<StubBaseDimension>("Celsius", "°C", 1.0, 273.15);
        unit.FromSI<double, double>(373.15).Should().Be(100);
        unit.ToSI<double, double>(100).Should().Be(373.15);
    }
}
