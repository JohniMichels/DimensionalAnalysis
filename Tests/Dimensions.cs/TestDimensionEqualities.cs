namespace Tests;

public class TestDimensionEqualities
{
    [Fact]
    [UnitTest]

    public void BaseDimensionHashEqualsType()
    {
        object d = new StubBaseDimension();
        d.GetHashCode().Should().Be(d.GetType().GetHashCode(), "because the hash code of a base dimension should be its type's hash code");
    }

    [Fact]
    [UnitTest]
    public void BaseDimensionHashEqualsSingleItemDimensionHash()
    {
        object d1 = new StubBaseDimension();
        object d2 = new Dimension(
            "Stub",
            "S",
            new Dictionary<BaseDimension, double> { { new StubBaseDimension(), 1 } }
        );
        d1.GetHashCode().Should().Be(d2.GetHashCode(), "the hash of a single item dimension is the hash of the dimension itself");
    }

    [Fact]
    [UnitTest]
    public void BaseDimensionEqualsDimension()
    {
        object d1 = new StubBaseDimension();
        object d2 = new Dimension(
            "Stub",
            "S",
            new Dictionary<BaseDimension, double> { { new StubBaseDimension(), 1 } }
        );
        var msg = "a single item dimension is equal to the base dimension it contains";
        d1.Should().Be(d2, msg);
        d2.Should().Be(d1, msg);
    }

    [Fact]
    [UnitTest]
    public void SquareDimensionDiffers()
    {
        object d1 = new Dimension(
            "Stub",
            "S",
            new Dictionary<BaseDimension, double> { { new StubBaseDimension(), 1 } }
        );
        object d2 = new Dimension(
            "Stub",
            "S",
            new Dictionary<BaseDimension, double> { { new StubBaseDimension(), 2 } }
        );
        var msg = "a dimension with different power is not equal to the base dimension";
        d1.Should().NotBe(d2, msg);
        d2.Should().NotBe(d1, msg);
    }

    [Fact]
    [UnitTest]
    public void DynamicEqualsBaseDimension()
    {
        object d1 = new Dimension(
            "Stub",
            "S",
            new Dictionary<BaseDimension, double> { { new StubBaseDimension(), 1 } }
        );
        object d2 = new StubBaseDimension();
        var msg = "a single item dimension is equal to a base dimension";
        d1.Should().Be(d2, msg);
        d2.Should().Be(d1, msg);
    }

    [Fact]
    [UnitTest]
    public void BaseDimensionNotEqualsOtherTypes()
    {
        object d1 = new Dimension(
            "Stub",
            "S",
            new Dictionary<BaseDimension, double> { { new StubBaseDimension(), 1 } }
        );
        object d2 = new object();
        d1.Should().NotBe(d2, "they are not the same type");
    }

    [Fact]
    [UnitTest]
    public void BaseDimensionSkipCheckOnComposedDimensions()
    {
        object d1 = new Dimension(
            "Stub",
            "S",
            new Dictionary<BaseDimension, double> {
                { new StubBaseDimension(), 1 },
                { new StubBaseDimension2(), 1 }
            }
        );
        object d2 = new StubBaseDimension();
        var msg = "a composed dimension is not equal to any base dimension";
        d2.Should().NotBe(d1, msg);
        d1.Should().NotBe(d2, msg);
    }

    [Fact]
    [UnitTest]
    public void BaseDimensionFalseOnSquaredDimension()
    {
        object d1 = new StubBaseDimension();
        object d2 = new Dimension(
            "Stub",
            "S",
            new Dictionary<BaseDimension, double> { { new StubBaseDimension(), 2 } }
        );
        var msg = "a dimension with different power is not equal to the base dimension";
        d1.Should().NotBe(d2, msg);
        d2.Should().NotBe(d1, msg);
    }

    [Fact]
    [UnitTest]
    public void BaseDimensionsOfSameTypeAreEqual()
    {
        object d1 = new StubBaseDimension();
        object d2 = new StubBaseDimension();
        var msg = "two base dimensions of the same type are equal";
        d1.Should().Be(d2, msg);
        d2.Should().Be(d1, msg);
    }

    [Fact]
    [UnitTest]
    public void DimensionsWithSamePowersEquals()
    {
        object d1 = new Dimension(
            "Stub",
            "S",
            new Dictionary<BaseDimension, double> {
                { new StubBaseDimension(), 1 },
                { new StubBaseDimension2(), 1 }
            }
        );
        object d2 = new Dimension(
            "Stub",
            "S",
            new Dictionary<BaseDimension, double> {
                { new StubBaseDimension(), 1 },
                { new StubBaseDimension2(), 1 }
            }
        );
        var msg = "two dimensions with the same powers are equal";
        d1.Should().Be(d2, msg);
        d2.Should().Be(d1, msg);
    }

}
