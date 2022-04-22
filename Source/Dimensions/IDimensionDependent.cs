namespace DimensionalAnalysis;

public interface IDimensionDependent
{
    IDimension Dimension { get; }
}

public interface IDimensionDependent<T> : IDimensionDependent
   where T : IDefinedDimension<T>, new()
{
    new T Dimension { get; }
}
