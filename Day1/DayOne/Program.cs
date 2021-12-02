using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1 {
    class Program {
        static void Main(string[] args) {
            //Part one example input.
            List<int> firstInput = new List<int> { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
            Console.WriteLine(CalculateDepthIncreases(firstInput));

            //Read and convert part one unique input.
            string[] uniqueInput = System.IO.File.ReadAllLines("input.txt");
            List<int> uniqueInputInts = new List<int>();
            foreach(string s in uniqueInput) {
                uniqueInputInts.Add(Int32.Parse(s));
            }

            Console.WriteLine(CalculateDepthIncreases(uniqueInputInts)); //Part one
            Console.WriteLine(CalculateDepthIncreasesWindowed(uniqueInputInts, 3)); //Part two.
            
        }

        //Part one solution.
        public static int CalculateDepthIncreases(List<int> input) {
            int result = 0;
            for (int i= 1; i < input.Count; i++) {
                if (input[i] > input[i - 1])
                    result++;
            }
            return result;
        }

        //Part two solution.
        //Because only one number from the set is changing, we only need to check the integer that is entering the window.
        //IF this integer is larger than the integer leaving the window, then we have an increase.
        public static int CalculateDepthIncreasesWindowed(List<int> input, int windowSize) {
            int result = 0;
            for(int i=0; i<input.Count - windowSize; i++) {
                if (input[i + windowSize] > input[i])
                    result++;
            }
            return result;
        }
    }
}
