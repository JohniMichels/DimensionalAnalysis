namespace DimensionalAnalysis;

public class AffineUnit : Unit
{
    public AffineUnit(string name, string symbol, double factor, double offset, IDimension dimension)
        : base(name, symbol, dimension)
    {
        Factor = factor;
        Offset = offset;
    }

    public double Factor { get; }
    public double Offset { get; }

    public override TDouble FromSI<T, TDouble>(T SIValue)
    {
        return (SIValue + (-Offset)) / Factor;
    }

    public override TDouble ToSI<T, TDouble>(T Value)
    {
        return (Value * Factor) + Offset;
    }
}

public class AffineUnit<T> : AffineUnit, IDimensionDependent<T>
    where T : IDefinedDimension<T>, new()
{
    public AffineUnit(string name, string symbol, double factor, double offset)
        : base(name, symbol, factor, offset, IDefinedDimension<T>.GetInstance())
    {
    }
    T IDimensionDependent<T>.Dimension => IDefinedDimension<T>.GetInstance();
}
