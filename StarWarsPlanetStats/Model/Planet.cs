using StarWarsPlanetStats.DTOs;
using StarWarsPlanetStats.Utils;
namespace StarWarsPlanetStats.Model;

public readonly record struct Planet
{
    public string Name { get; }
    public int Diameter { get; }
    public int? SurfaceWater { get; }
    public long? Population { get; }

    public Planet(
        string name,
        int diameter,
        int? surfaceWater,
        long? population)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        Name = name;
        Diameter = diameter;
        SurfaceWater = surfaceWater;
        Population = population;
    }

    public static explicit operator Planet(Result planetDto)
    {
        var name = planetDto.name;
        var diameter = int.Parse(planetDto.diameter);

        long? population = planetDto.population.ToLongOrNull();

        int? surfaceWater = planetDto.surface_water.ToIntOrNull();

        return new Planet(name, diameter, surfaceWater, population);

    }

    public override string ToString()
    {
        return $"Name: {Name}, Population: {Population}, Diameter: {Diameter}, Surface Water: {SurfaceWater}";
    }
}
