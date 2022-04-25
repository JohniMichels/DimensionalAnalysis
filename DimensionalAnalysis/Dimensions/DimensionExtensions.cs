namespace DimensionalAnalysis;

public static class DimensionExtensions
{
    public static Dimension Combine(
        this IDimension dimension1,
        IDimension dimension2,
        bool isMultiply
    )
    {
        var dimensions = dimension1.Dimensions.Keys.Union(
            dimension2.Dimensions.Keys)
            .Select(
                key => (key, value: dimension1.Dimensions.GetValueOrDefault(key)
                    + (dimension2.Dimensions.GetValueOrDefault(key) * (isMultiply ? 1 : -1)))
            ).Where(kvp => kvp.value != 0).ToDictionary(kvp => kvp.key, kvp => kvp.value);
        return new Dimension(
            dimensions.Select(kv => $"{kv.Key.Name}^{kv.Value}").Aggregate("", (a, b) => $"{a} * {b}"),
            dimensions.Select(kv => $"{kv.Key.Symbol}^{kv.Value}").Aggregate("", (a, b) => $"{a} * {b}"),
            dimensions
        );
    }
}
