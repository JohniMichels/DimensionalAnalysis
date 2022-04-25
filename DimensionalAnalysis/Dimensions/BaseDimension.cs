namespace DimensionalAnalysis;

public abstract class BaseDimension : IDimension, IEquatable<BaseDimension>
{
    protected BaseDimension(string name, string symbol)
    {
        Name = name;
        Symbol = symbol;
        Dimensions = new Dictionary<BaseDimension, double>()
        {
            { this, 1 }
        };
    }

    public string Name { get; }
    public string Symbol { get; }

    public IReadOnlyDictionary<BaseDimension, double> Dimensions { get; }

    public override bool Equals(object? obj)
    {
        return obj is IDimension dimension
            && Equals(dimension);
    }

    public override int GetHashCode() => GetType().GetHashCode();

    public bool Equals(BaseDimension? other) =>
        GetType() == other?.GetType();

    public bool Equals(IDimension? other)
    {
        return other is BaseDimension baseDimension?
            Equals(baseDimension) :
            other?.Dimensions.Count == 1 &&
            other.Dimensions.GetValueOrDefault(this, 0) == 1;
    }
}
