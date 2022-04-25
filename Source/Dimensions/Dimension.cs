using System.Collections.Concurrent;

namespace DimensionalAnalysis;

public class Dimension : IDimension
{
    public Dimension(string name, string symbol, IReadOnlyDictionary<BaseDimension, double> dimensions)
    {
        Name = name;
        Symbol = symbol;
        Dimensions = dimensions;
        HashCode = dimensions.Aggregate(0, (acc, kvp) => acc ^ kvp.Key.GetHashCode() ^ (Convert.ToInt32(kvp.Value)-1));
    }

    public string Name { get; }
    public string Symbol { get; }

    public IReadOnlyDictionary<BaseDimension, double> Dimensions { get; }

    private int HashCode { get; }

    public override bool Equals(object? obj)
    {
        return obj is IDimension dimension &&
            Equals(dimension);
    }

    public bool Equals(IDimension? other) =>
        other?.GetHashCode() == GetHashCode() &&
        (
            other?.Dimensions.Keys.Union(Dimensions.Keys)
            .All(k => other?.Dimensions.GetValueOrDefault(k) == Dimensions.GetValueOrDefault(k))
            ??false
        );

    public override int GetHashCode()
    {
        return HashCode;
    }

}
