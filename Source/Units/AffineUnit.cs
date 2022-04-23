namespace DimensionalAnalysis;

public sealed class AffineUnit : Unit
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
