using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2 {
    class Program {
        static void Main(string[] args) {
            string[] firstInput = { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" };
            Console.WriteLine(CalculatePositions(firstInput));

            string[] uniqueInput = System.IO.File.ReadAllLines("input.txt");
            Console.WriteLine(CalculatePositions(uniqueInput));

        }

        public static int CalculatePositions(string[] input) {
            int depth = 0;
            int horizontalPos = 0;
            int aim = 0;
            foreach (string str in input) {
                string direction = str.Split(' ')[0];
                int value = Int32.Parse(str.Split(' ')[1]);
                switch (direction) {
                case "forward":
                    horizontalPos += value;
                    depth += aim * value;
                    break;
                case "down":
                    aim += value;
                    break;
                case "up":
                    aim -= value;
                    break;
                }
            }
            return depth * horizontalPos;
        }
    }
}
