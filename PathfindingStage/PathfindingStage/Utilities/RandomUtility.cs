using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestFire.Utilities
{

    // Klasa pomocnicza losująca liczby
    public static class RandomUtility
    {
        static Random random = new Random();

        public static int ChooseRandom(int min, int max)
        {
            return random.Next(min, max);
        }

        public static double DoubleChooseRandom()
        {
            return random.NextDouble();
        }
    }
}
