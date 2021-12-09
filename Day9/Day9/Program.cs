using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9 {
    class Program {
        public static int maxX;
        public static int maxY;
        static void Main(string[] args) {

            string[] uniqueInput = System.IO.File.ReadAllLines("input.txt");

            //Convert input to an array for ease of use.
            maxY = uniqueInput.Length;
            maxX = uniqueInput[0].Length;

            int[,] uniqueInputInts = new int[maxX, maxY];
            for (int y=0; y < maxY; y++) {
                for(int x=0; x < maxX; x++) {
                    uniqueInputInts[x, y] = int.Parse(uniqueInput[y][x].ToString());
                }
            }
            int sum = 0;
            for (int y = 0; y < uniqueInput.Length; y++) {
                for (int x = 0; x < uniqueInput[0].Length; x++) {
                    //Check above
                    if (CheckForLowPoint(uniqueInputInts, x, y)) {
                        int val = uniqueInputInts[x, y];
                        sum += val + 1;
                    }


                }
            }

            Console.WriteLine(sum);
        }
        public static bool CheckForLowPoint(int[,] arr, int x, int y) {
            bool result = true;
            int val = arr[x, y];

            //Check above
            if(y + 1 < maxY) {
                 if (!(val < arr[x, y + 1]))
                    result = false;
            }
            if(y - 1 >= 0) {
                if (!(val < arr[x, y - 1]))
                    result = false;
            }
            if(x + 1 < maxX) {
                if (!(val < arr[x + 1, y]))
                    result = false;
            }
            if(x - 1 >= 0) {
                if (!(val < arr[x - 1, y]))
                    result = false;
            }
            
            return result;
        }
    }

}
