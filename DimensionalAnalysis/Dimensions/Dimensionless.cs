namespace DimensionalAnalysis;

public class Dimensionless : Dimension,
    IDefinedDimension<Dimensionless>
{
    public Dimensionless() : base(
        name: "Dimensionless",
        symbol: " 1",
        dimensions: new Dictionary<BaseDimension, double>())
    {
    }
}
