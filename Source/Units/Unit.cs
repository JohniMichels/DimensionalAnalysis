using System.Collections.Concurrent;

namespace DimensionalAnalysis;

public abstract class Unit : IDimensionDependent
{

    internal static ConcurrentDictionary<string, Unit> KnownSymbols = new();
    internal static ConcurrentDictionary<string, Unit> KnownNames = new();

    public string Name { get; }
    public string Symbol { get; }
    public IDimension Dimension { get; }

    private void Register()
    {
        KnownSymbols.AddOrUpdate(Symbol, this, (key, oldValue) => this);
        KnownNames.AddOrUpdate(Name, this, (key, oldValue) => this);
    }

    public Unit(string name, string symbol, IDimension dimension, bool skipRegistration = false)
    {
        Name = name;
        Symbol = symbol;
        Dimension = dimension;
        if (!skipRegistration) Register();
    }

    public abstract TDouble FromSI<T, TDouble>(T SIValue)
        where T : INumber<T>,
            IMultiplyOperators<T, double, TDouble>,
            IDivisionOperators<T, double, TDouble>,
            IAdditionOperators<T, double, TDouble>
        where TDouble : INumber<TDouble>,
            IMultiplyOperators<TDouble, double, TDouble>,
            IDivisionOperators<TDouble, double, TDouble>,
            IAdditionOperators<TDouble, double, TDouble>;

    public abstract TDouble ToSI<T, TDouble>(T Value)
        where T : INumber<T>,
            IMultiplyOperators<T, double, TDouble>,
            IDivisionOperators<T, double, TDouble>,
            IAdditionOperators<T, double, TDouble>
        where TDouble : INumber<TDouble>,
            IMultiplyOperators<TDouble, double, TDouble>,
            IDivisionOperators<TDouble, double, TDouble>,
            IAdditionOperators<TDouble, double, TDouble>;
}

public abstract class Unit<T> : Unit, IDimensionDependent<T>
    where T : IDefinedDimension<T>, new()
{
    public Unit(string name, string symbol)
        : base(name, symbol, IDefinedDimension<T>.GetInstance())
    {
    }

    public new T Dimension { get => IDefinedDimension<T>.GetInstance(); }
}
