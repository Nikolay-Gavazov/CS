namespace CarDistance
{
  class Program
  {
    public static int CarContainer = 20;
    public static int FuelConsumption = 10;
    static void Main(string[] args)
    {
      var barrels = new Barrel[3] { new Barrel(), new Barrel(), new Barrel() };
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
      
      var defDistance = CarContainer / FuelConsumption * 100;
      if (isForward)
      {
        if (transportedBarel == 0 && currentDistance == 0)
        {
          barrels[transportedBarel].Distance += defDistance;
          currentDistance = barrels[transportedBarel].Distance;
        }
        else {
          if (barrels[transportedBarel].Fuel >= CarContainer)
          {
            barrels[transportedBarel].Fuel -= CarContainer;
            OverflowFuel(barrels);
            barrels[transportedBarel].Distance += defDistance;
            currentDistance = barrels[transportedBarel].Distance;
          }
        }
        
      }else {
        foreach (var barrel in barrels)
        {
          if (barrel.Distance == currentDistance && barrel.Fuel >= CarContainer) { 
            barrel.Fuel -= CarContainer;
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
      foreach (var barrel in barrels)
      {
        if (barrel.Fuel >= CarContainer)
        {
          return true;

        }
      }
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
            if (barrels[i].Fuel < 100 && barrels[i + 1].Fuel > 0)
            { 
              var diff = 100 - barrels[i].Fuel;
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
        if (barrels[i].Fuel >= CarContainer)
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
        if (barrels[i].Fuel >= CarContainer)
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
        if (barrel.Fuel >= CarContainer && barrel.Distance < distance)
        {
          return true;
        }
      }
      return false;
    }

  }
}