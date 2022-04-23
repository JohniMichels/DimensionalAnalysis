namespace DimensionalAnalysis;

public class LinearUnit : Unit
{
    public LinearUnit(string name, string symbol, double factor, IDimension dimension)
        : base(name, symbol, dimension)
    {
        Factor = factor;
    }

    public double Factor { get; }

    public override TDouble FromSI<T, TDouble>(T SIValue)
    {
        return SIValue / Factor;
    }

    public override TDouble ToSI<T, TDouble>(T Value)
    {
        return Value * Factor;
    }
}

public class LinearUnit<T> : LinearUnit, IDimensionDependent<T>
    where T : IDefinedDimension<T>, new()
{
    public LinearUnit(string name, string symbol, double factor)
        : base(name, symbol, factor, IDefinedDimension<T>.GetInstance())
    {
    }
    T IDimensionDependent<T>.Dimension => IDefinedDimension<T>.GetInstance();
}
