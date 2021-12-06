using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5 {
    class Program {
        static void Main(string[] args) {
            int[] exampleInput = { 3, 4, 3, 1, 2 };
            Console.WriteLine(CalculateFishGrowth(exampleInput));
        }

        public static int CalculateFishGrowth(int[] input) {
            List<int> lanternFish = input.ToList<int>();
            int fishToAdd = 0;

            //Iterate for a day
            for (int i = 0; i < 80; i++) {
                //Iterate over every fish each day.
                for(int j = 0; j < lanternFish.Count; j++) {
                    lanternFish[j]--;
                    if(lanternFish[j] == -1) {
                        lanternFish[j] = 6;
                        fishToAdd++;
                    }
                }
                for(int j = 0; j< fishToAdd; j++) {
                    lanternFish.Add(8);
                }
                fishToAdd = 0;
            }

            return lanternFish.Count();
        }

    }
}
