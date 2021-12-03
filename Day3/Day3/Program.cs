using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3 {
    class Program {
        static void Main(string[] args) {
            string[] firstInput = { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };
            string[] uniqueInput = System.IO.File.ReadAllLines("input.txt");

            Console.WriteLine(CalculateGammaAndEpsilon(firstInput));
            Console.WriteLine(CalculateGammaAndEpsilon(uniqueInput));

            //Part 2
            Console.WriteLine(CalculateLifeSupportRating(firstInput));
            Console.WriteLine(CalculateLifeSupportRating(uniqueInput));


        }

        public static int CalculateGammaAndEpsilon(string[] input) {
            int zeroBitCounter = 0;
            int oneBitCounter = 0;
            string gammaString = "";
            string epsilonString = "";

            //input.Where(s => s[0] == 1);

            for(int i=0; i<input[0].Length; i++) {
                //Determine which value is most common in each string.
                foreach(string s in input) {
                    if (s[i] == '0')
                        zeroBitCounter++;
                    else if (s[i] == '1')
                        oneBitCounter++;
                }
                //Append the resulting value to our result strings.
                if (zeroBitCounter > oneBitCounter) {
                    gammaString += "0";
                    epsilonString += "1";
                }
                else {
                    gammaString += "1";
                    epsilonString += "0";
                }
                zeroBitCounter = 0;
                oneBitCounter = 0;
            }
            return Convert.ToInt32(gammaString, 2) * Convert.ToInt32(epsilonString,2);
        }

        public static int CalculateLifeSupportRating(string[] input) {
            List<string> oxygenRatingData = input.ToList<string>();
            List<string> co2RatingData = input.ToList<string>();
            for(int i = 0; i < input.Length; i++) {
                if (oxygenRatingData.Count == 1)
                    break;
                int count = oxygenRatingData.Count(s => s[i] == '1');
                if (count >= oxygenRatingData.Count / 2.0)
                    oxygenRatingData.RemoveAll(s => s[i] == '0');
                else
                    oxygenRatingData.RemoveAll(s => s[i] == '1');

            }
            for (int i = 0; i < input.Length; i++) {
                if (co2RatingData.Count == 1)
                    break;
                int count = co2RatingData.Count(s => s[i] == '1');
                if (count >= co2RatingData.Count / 2.0)
                    co2RatingData.RemoveAll(s => s[i] == '1');
                else
                    co2RatingData.RemoveAll(s => s[i] == '0');

            }
            return Convert.ToInt32(oxygenRatingData[0], 2) * Convert.ToInt32(co2RatingData[0], 2);
        }

    }
}
