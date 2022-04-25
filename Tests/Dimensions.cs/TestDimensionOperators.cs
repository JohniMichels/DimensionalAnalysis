namespace Tests;

public class TestDimensionOperators
{
    [Fact]
    public void BaseDimensionTimesItself()
    {
        IDimension d1 = new StubBaseDimension();
        var d2 = d1 * d1;
        var msg = "a base dimension times itself should be a order two dimension";
        d2.Should().BeOfType<Dimension>().Which.Dimensions.Values.Sum().Should().Be(2, msg);
    }

    [Fact]
    public void BaseDimensionDividedByItself()
    {
        IDimension d1 = new StubBaseDimension();
        IDimension d2 = d1 / d1;
        var msg = "a base dimension divided by itself should be a dimensionless";
        d2.Should().Be(IDefinedDimension<Dimensionless>.GetInstance(), msg);
    }

    [Fact]
    [UnitTest]
    public void CombineMethodMultiplicativeCase()
    {
        IDimension d1 = new StubBaseDimension();
        IDimension d2 = new StubBaseDimension();
        var d3 = d1.Combine(d2, true);
        var msg = "combining base dimensions should result in a squared base dimension";
        d3.Should().BeOfType<Dimension>().Which.Dimensions.Values.Sum().Should().Be(2, msg);
    }

    [Fact]
    [UnitTest]
    public void CombineMethodDivisiveCase()
    {
        IDimension d1 = new StubBaseDimension();
        IDimension d2 = new StubBaseDimension();
        var d3 = d1.Combine(d2, false);
        var msg = "combining base dimensions should result in a dimensionless";
        d3.Should().Be(IDefinedDimension<Dimensionless>.GetInstance(), msg);
    }

    [Fact]
    [Exploratory]
    public void EmptyListAggregate()
    {
        var items = new List<string>();
        var items2 = items.Aggregate("", (x, y) => x + y);
        items2.Should().Be("");
        Action invalidAgg = () => items2 = items.Aggregate((x, y) => x + y);
        invalidAgg.Should()
            .Throw<InvalidOperationException>()
            .WithMessage("Sequence contains no elements");
        // Thus the aggregation on the Combine method must have a empty seed value
    }
}
