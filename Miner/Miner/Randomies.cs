using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner
{
    static class Randomies
    {
        public static int randoms(int threshold)
        {
            Random rnd = new Random();
            int num = rnd.Next(threshold);
            switch (num)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                case 2:
                    return 2;

            }
            return num;
        }
    }
}
