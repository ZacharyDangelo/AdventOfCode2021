using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7 {
    class Program {
        static void Main(string[] args) {
            int[] exampleInput = { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 };
            int[] uniqueInput = Array.ConvertAll(System.IO.File.ReadAllLines("input.txt")[0].Split(','), s => int.Parse(s));

            Console.WriteLine(CalculatePosition(exampleInput));
            Console.WriteLine(CalculatePosition(uniqueInput));

        }

        public static int CalculatePosition(int[] input) {
            Dictionary<int, int> crabsAtPos = new Dictionary<int, int>();
            Dictionary<int, int> fuelToPos = new Dictionary<int, int>();
            Array.Sort(input);
            int minPos = input[0];
            int maxPos = input[input.Length-1];
            foreach(int i in input) {
                if (!crabsAtPos.ContainsKey(i))
                    crabsAtPos[i] = 0;
                crabsAtPos[i]++;
            }
            int idealPos = minPos;
            for(int targetPos=minPos; targetPos <= maxPos; targetPos++) {
                if (!fuelToPos.ContainsKey(targetPos))
                    fuelToPos[targetPos] = 0;
                foreach(int crabPos in crabsAtPos.Keys) {
                    int fuelCost =0;
                    int stepCost = 1;
                    while(stepCost <= Math.Abs(crabPos - targetPos)) {
                        fuelCost += stepCost;
                        stepCost++;
                    }
                    fuelToPos[targetPos] += crabsAtPos[crabPos] * fuelCost;
                }
                if (fuelToPos[targetPos] < fuelToPos[idealPos])
                    idealPos = targetPos;
            }
            return fuelToPos[idealPos];
        }
    }
}
