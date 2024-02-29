using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDistance
{
  internal class Barrel
  {
    public int Distance { get; set; }
    public int Fuel { get; set; }

    public Barrel()
    {
      this.Distance = 0;
      this.Fuel = 100;
    }
  }
}
