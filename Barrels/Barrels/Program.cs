using System;
using System.Threading;

namespace CarDistance
{
    class Program
    {
        static int CarContainerCapacity = 20;
        static int FuelConsumption = 10;
        static int BarrelCapacity = 100;
        static int BarrelsCount = 3;
        const int DistanceMultiplier = 100;
        static void Main(string[] args)
        {
            var barrels = new Barrel[BarrelsCount];
            for (int i = 0; i < barrels.Length; i++)
            {
                barrels[i] = new Barrel(BarrelCapacity);
            }
            int currentDestionation = 0;
            StartMove(barrels, true, 0, ref currentDestionation);
            // Current passed km
            Console.WriteLine(currentDestionation);


        }

        internal static void StartMove(Barrel[] barrels, Boolean isForward, int transportedbarrel, ref int currentDestionation)
        {
            if (!IsThereFuel(barrels, currentDestionation))
            {
                return;
            }

            if (isForward)
            {
                currentDestionation = MoveForwardCar(barrels, ref transportedbarrel, currentDestionation);
            }
            else
            {
                currentDestionation = MoveBackwordCar(barrels, currentDestionation);
            }


            isForward = !isForward;

            if (!isForward && !ShouldGoBakward(barrels, currentDestionation))
            {
                isForward = true;
            }
            if (isForward)
            {
                transportedbarrel = NextForTranspotFromCurrentPosition(barrels, currentDestionation);
            }

            StartMove(barrels, isForward, transportedbarrel, ref currentDestionation);
        }

        private static int MoveBackwordCar(Barrel[] barrels, int currentDestionation)
        {
            var fuelLoaded = 0;
            foreach (var barrel in barrels)
            {
                if (barrel.Distance == currentDestionation && barrel.Fuel > 0)
                {
                    if (barrel.Fuel >= CarContainerCapacity)
                    {
                        barrel.Fuel -= CarContainerCapacity;
                        fuelLoaded = CarContainerCapacity;
                    }
                    else
                    {
                        var necceceryFuel = CarContainerCapacity - fuelLoaded;
                        if (barrel.Fuel >= necceceryFuel)
                        {
                            fuelLoaded += necceceryFuel;
                            barrel.Fuel -= necceceryFuel;
                        }
                        else
                        {
                            fuelLoaded += barrel.Fuel;
                            barrel.Fuel = 0;
                        }
                    }
                }
                if (fuelLoaded == CarContainerCapacity)
                {
                    break;
                }
            }
            var defDistance = fuelLoaded / FuelConsumption * DistanceMultiplier;
            currentDestionation -= defDistance;
            return currentDestionation;
        }

        private static int MoveForwardCar(Barrel[] barrels, ref int transportedbarrel, int currentDestionation)
        {
            var defDistance = 0;
            if (barrels[transportedbarrel].Fuel >= CarContainerCapacity)
            {
                defDistance = CarContainerCapacity / FuelConsumption * DistanceMultiplier;
                barrels[transportedbarrel].Fuel -= CarContainerCapacity;
                OverflowFuel(barrels, currentDestionation);
                barrels[transportedbarrel].Distance += defDistance;
                currentDestionation = barrels[transportedbarrel].Distance;
            }
            else
            {
                var fuelLoaded = 0;
                fuelLoaded += barrels[transportedbarrel].Fuel;
                barrels[transportedbarrel].Fuel = 0;
                if (fuelLoaded < CarContainerCapacity)
                {
                    for (int i = 0; i < barrels.Length; i++)
                    {
                        if (barrels[i].Distance == currentDestionation && barrels[i].Fuel > 0)
                        {
                            var missingFuel = CarContainerCapacity - fuelLoaded;
                            if (barrels[i].Fuel > missingFuel)
                            {
                                barrels[i].Fuel -= missingFuel;
                                fuelLoaded += missingFuel;
                            }
                            else
                            {
                                fuelLoaded += barrels[i].Fuel;
                                barrels[i].Fuel = 0;
                            }

                            if (fuelLoaded == CarContainerCapacity)
                            {
                                defDistance = fuelLoaded / FuelConsumption * DistanceMultiplier;
                                i = barrels.Length;
                            }
                        }
                    }
                    OverflowFuel(barrels, currentDestionation);
                    defDistance = fuelLoaded / FuelConsumption * DistanceMultiplier;
                    transportedbarrel = NextForTranspotFromCurrentPosition(barrels, currentDestionation);
                    barrels[transportedbarrel].Distance += defDistance;
                    currentDestionation = barrels[transportedbarrel].Distance;
                }

            }
            return currentDestionation;
        }

        internal static Boolean IsThereFuel(Barrel[] barrels, int currendetsination)
        {
            foreach (Barrel barrel in barrels)
            {
                if (barrel.Distance == currendetsination && barrel.Fuel > 0) { 
                    return true;
                }
            }
            return false;
        }

        internal static void OverflowFuel(Barrel[] barrels, int currentDestionation)
        {
            var fuelOnCurrentdestination = 0;
            var barrelsOndestioantion = 0;
            foreach (var barrel in barrels)
            {
                if (barrel.Distance == currentDestionation) {
                    fuelOnCurrentdestination += barrel.Fuel;
                    barrelsOndestioantion++;
                }
            }
            foreach (var barrel in barrels)
            {
                if (barrel.Distance == currentDestionation)
                {
                    if (fuelOnCurrentdestination >= BarrelCapacity)
                    {
                        barrel.Fuel = BarrelCapacity;
                        fuelOnCurrentdestination -= BarrelCapacity;
                    }
                    else {
                        barrel.Fuel = fuelOnCurrentdestination;
                        fuelOnCurrentdestination -= fuelOnCurrentdestination;
                    }
                }
            }
            
        }

        internal static int NextForTranspotFromCurrentPosition(Barrel[] barrels, int currentDestionation) {
            var maxFuel = 0;
            var transportBarrelNumber = 0;
            for (var i = 0; i < barrels.Length; i++)
            {
                if (barrels[i].Distance == currentDestionation && barrels[i].Fuel > maxFuel)
                {
                    maxFuel = barrels[i].Fuel;
                    transportBarrelNumber = i;
                }
            }
            return transportBarrelNumber;
        }
        internal static Boolean ShouldGoBakward(Barrel[] barrels, int currentDestionation)
        {
            var distanceFuel = 0;
            foreach (var barrel in barrels)
            {
                if (barrel.Distance == currentDestionation) {
                    distanceFuel += barrel.Fuel;
                }
            }
            var possibleKmPass = distanceFuel/FuelConsumption * DistanceMultiplier;
            foreach (var barrel in barrels)
            {
                if (barrel.Distance < currentDestionation && (currentDestionation - barrel.Distance) <= possibleKmPass)
                {
                    var distancePass = currentDestionation - barrel.Distance;
                    var necceceryLittersForBackAndForward = (2 * distancePass) / DistanceMultiplier  * FuelConsumption;
                    if (CheckDistanceFuelCapacity(barrels, barrel.Distance, necceceryLittersForBackAndForward)){
                        return true;
                    }                     
                }
            }
            return false;
        }
        internal static Boolean CheckDistanceFuelCapacity(Barrel[] barrels, int distance, int necceceryLittersForBackAndForward) {
            var distanceCapacity = 0;
            foreach (var barrel in barrels) {
                if (barrel.Distance == distance && barrel.Fuel > 0) {
                    distanceCapacity += barrel.Fuel;
                }
            }
            return distanceCapacity > necceceryLittersForBackAndForward;
        }

    }
}