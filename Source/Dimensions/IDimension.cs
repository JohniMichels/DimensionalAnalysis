namespace DimensionalAnalysis;

public interface IDimension:
    IEquatable<IDimension>
{
    string Name { get; }
    string Symbol { get; }

    IReadOnlyDictionary<BaseDimension, double> Dimensions { get; }

    public static IDimension operator *(IDimension dimension1, IDimension dimension2) =>
        dimension1.Combine(dimension2, true);

    public static IDimension operator /(IDimension dimension1, IDimension dimension2) =>
        dimension1.Combine(dimension2, false);

}

public interface IDefinedDimension<T>
    : IDimension
    where T:IDefinedDimension<T>, new()
{
    private static readonly T Instance = new();
    static T GetInstance() => Instance;

    public static Dimensionless operator /(IDefinedDimension<T> dimension1, T dimension2) =>
        IDefinedDimension<Dimensionless>.GetInstance();
}
