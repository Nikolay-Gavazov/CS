using System.Threading;

namespace CarDistance
{
  class Program
  {
    public static int CarContainerCapacity = 20;
    public static int CarContainer = 0;
    public static int FuelConsumption = 10;
    public static int BarrelCapacity = 100;
        const int DistanceMultiplier = 100;
        static void Main(string[] args)
    {
      var barrels = new Barrel[3] { new Barrel(BarrelCapacity), new Barrel(BarrelCapacity), new Barrel(BarrelCapacity) };
      int currentDistance = 0;
      StartMove(barrels, true, 0, ref currentDistance);
      // Current passed km
      Console.WriteLine(currentDistance);


    }

    internal static void StartMove(Barrel[] barrels, Boolean isForward, int transportedBarel, ref int currentDistance)
    {
      if (!IsThereFuel(barrels))
      {
        return;
      }
      
      var defDistance = (CarContainer / FuelConsumption) * DistanceMultiplier;
      if (isForward)
      {
        if (transportedBarel == 0 && currentDistance == 0)
        {
          barrels[transportedBarel].Fuel -= CarContainerCapacity;
          CarContainer = CarContainerCapacity;
          barrels[transportedBarel].Distance += defDistance;
          currentDistance = barrels[transportedBarel].Distance;
        }
        else {
          if (barrels[transportedBarel].Fuel >= CarContainer)
          {
            barrels[transportedBarel].Fuel -= CarContainerCapacity;
            CarContainer = CarContainerCapacity;
            OverflowFuel(barrels);
            barrels[transportedBarel].Distance += defDistance;
            currentDistance = barrels[transportedBarel].Distance;
          }
        }
        
      }else {
        foreach (var barrel in barrels)
        {
          if (barrel.Distance == currentDistance && barrel.Fuel >= CarContainer) { 
            barrel.Fuel -= CarContainerCapacity;
            CarContainer = CarContainerCapacity;
            currentDistance -= defDistance;
            break;
          }
        }
      }
      
      
      isForward = !isForward;

      if (!ShouldGoBakward(barrels, currentDistance)) { 
        isForward = true;
      }
      if (isForward) {
        transportedBarel = NextForTranspot(barrels);
      }

      StartMove(barrels, isForward, transportedBarel,ref currentDistance);
    }

    internal static Boolean IsThereFuel(Barrel[] barrels)
    {
            if (barrels[0].Fuel >= CarContainer)
            {
                barrels[0].Fuel -= CarContainerCapacity;
                CarContainer = CarContainerCapacity;
                return true;
            }
            else if (barrels[0].Fuel < CarContainer && barrels[0].Fuel > 0) 
            {
                barrels[0].Fuel -= CarContainerCapacity;
                CarContainer = CarContainerCapacity;
                return true;
            }
      //foreach (var barrel in barrels)
      //{
      //  if (barrel.Fuel >= CarContainer)
      //  {
      //    return true;

      //  }
      //}
      return false;
    }

    internal static Boolean OverflowFuel(Barrel[] barrels)
    {
      var arrLentght = barrels.Length;
      var isOverflow = false;
      for (int i = 0; i < arrLentght; i++)
      {
        if (i != arrLentght - 1 && barrels[i].Fuel != 0)
        {
          if (barrels[i].Distance == barrels[i + 1].Distance) {
            if (barrels[i].Fuel < BarrelCapacity && barrels[i + 1].Fuel > 0)
            { 
              var diff = BarrelCapacity - barrels[i].Fuel;
              if (barrels[i + 1].Fuel > diff)
              {
                barrels[i + 1].Fuel -= diff;
                barrels[i].Fuel += diff;
              }
              else {
                barrels[i].Fuel += barrels[i + 1].Fuel;
                barrels[i + 1].Fuel = 0;
              }
              isOverflow = true;
            }
          }         
        }
      }
     return isOverflow;
    }

    internal static int NextForTranspot(Barrel[] barrels)
    {
      var maxKilometer = 0;
      for (int i = 0; i < barrels.Length; i++)
      {
        if (barrels[i].Fuel > CarContainer)
        {
          if (barrels[i].Distance > maxKilometer)
          {
            maxKilometer = barrels[i].Distance;
          }
          if (barrels[i].Distance < maxKilometer){
            return i;
          }
        }
      }
      for (int i = 0; i < barrels.Length; i++)
      {
        if (barrels[i].Fuel > CarContainer)
        {
          if (barrels[i].Distance == maxKilometer)
          {
            return i;
          }
        }
      }
      return 0;
    }

    internal static Boolean ShouldGoBakward(Barrel[] barrels, int distance) {
      foreach (var barrel in barrels)
      {
        if (barrel.Fuel > CarContainerCapacity * 2 && barrel.Distance < distance)
        {
          return true;
        }
      }
      return false;
    }

  }
}