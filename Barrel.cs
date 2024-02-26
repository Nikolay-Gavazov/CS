namespace CarDistance
{
    internal class Barrel
  {
    public int Distance { get; set; }
    public int Fuel { get; set; }

    public Barrel(int barrelCapacity)
    {
      this.Distance = 0;
      this.Fuel = 100;
    }
  }
}
