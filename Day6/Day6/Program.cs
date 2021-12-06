using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6 {
    class Program {
        static void Main(string[] args) {
            int[] exampleInput = { 3, 4, 3, 1, 2 };
            string inputString = System.IO.File.ReadAllLines("input.txt")[0];
            string[] uniqueInput = inputString.Split(',');
            int[] uniqueInputInts = Array.ConvertAll(uniqueInput, s => int.Parse(s));

            //Data for part 2
            long[] fishCounter = new long[9];
            foreach (var ch in inputString.Split(',')) {
                fishCounter[int.Parse(ch)]++;
            }

            Console.WriteLine(CalculateFishGrowth(exampleInput, 80));
            Console.WriteLine(CalculateFishGrowth(uniqueInputInts, 80));
            Console.WriteLine(CalculateFishGrowthPartTwo(fishCounter, 256));
        }

        public static int CalculateFishGrowth(int[] input,int numDays) {
            List<int> lanternFish = input.ToList<int>();
            int fishToAdd = 0;

            //Iterate for a day
            for (int i = 0; i < numDays; i++) {
                //Iterate over every fish each day.
                for (int j = 0; j < lanternFish.Count; j++) {
                    lanternFish[j]--;
                    if (lanternFish[j] == -1) {
                        lanternFish[j] = 6;
                        fishToAdd++;
                    }
                }
                for (int j = 0; j < fishToAdd; j++) {
                    lanternFish.Add(8);
                }
                fishToAdd = 0;
            }

            return lanternFish.Count();
        }

        //Part two involved calculating very large data. Due to this we needed a different implementation.
        public static long CalculateFishGrowthPartTwo(long[] input, int numDays) {
            for (int i = 0; i < numDays; i++) {
                input[(i + 7) % 9] += input[i % 9];
            }

            return input.Sum();
        }

    }
}
