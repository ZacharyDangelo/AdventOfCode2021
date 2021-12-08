using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8 {
    class Program {
        public static Dictionary<string, int> Values = new Dictionary<string, int>() {
            {"abcefg",0 },
            {"cf",1 },
            {"acdeg",2 },
            {"acdfg",3 },
            {"bcdf",4 },
            {"abdfg",5 },
            {"abdefg",6 },
            {"acf",7 },
            {"abcdefg",8 },
            {"abcdfg",9 }
        };

        static void Main(string[] args) {
            string[] uniqueInput = System.IO.File.ReadAllLines("input.txt");

            Console.WriteLine(CountUniqueDigits(uniqueInput));
            Console.WriteLine(Decode(uniqueInput));
        }

        public static int CountUniqueDigits(string[] input) {
            int counter = 0;
            foreach(string s in input) {
                string[] outputDigits = s.Split('|')[1].Split(' ');
                foreach(string digit in outputDigits) {
                    if (digit.Length == 2 || digit.Length == 4 || digit.Length == 3 || digit.Length == 7)
                        counter++;
                }

            }

            return counter;
        }

        public static int Decode(string[] input) {
            int result = 0;
            Dictionary<char, char> encodedValues = new Dictionary<char, char>();




            foreach (string s in input) {
                string[] digits = s.Split('|')[0].Split(' ');
                //Sort each string for ease of use
                for(int i = 0; i < digits.Length; i++) {
                    char[] temp = digits[i].ToCharArray();
                    Array.Sort(temp);
                    digits[i] = new string(temp);
                }
                string seven = digits.FirstOrDefault(str => str.Length == 3);
                string one = digits.FirstOrDefault(str => str.Length == 2);

                //We can always decode the letter 'a' easily
                foreach(char c in seven) {
                    if (one.Contains(c))
                        continue;
                    else
                        encodedValues['a'] = c;
                }


                string four = digits.FirstOrDefault(str => str.Length == 4);
                //Determine 'b'
                foreach (char c in four) {
                    int counter = 0;
                    foreach (string str in digits) {
                        if (str.Length != 5)
                            continue;
                        if (str.Contains(c))
                            counter++;
                    }
                    if (counter != 1)
                        continue;
                    else {
                        encodedValues['b'] = c;
                        break;
                    }
                }



                //Determine 'c' and 'f'
                foreach (string str in digits.Where(s2 => s2.Length == 5)) {
                    if (str.Contains(one[0]) && str.Contains(one[1]))
                        continue;
                    else {
                        if (str.Contains(encodedValues['b'])) {
                            if (str.Contains(one[0])) {
                                encodedValues['c'] = one[1];
                                encodedValues['f'] = one[0];
                            }
                            else {
                                encodedValues['c'] = one[0];
                                encodedValues['f'] = one[1];
                            }
                        }
                    }
                }

                //Determine 'd'
                foreach (char c in four) {
                    if (encodedValues.ContainsValue(c))
                        continue;
                    else
                        encodedValues['d'] = c;
                }

                //Determine 'g'
                string str2 = digits.FirstOrDefault(s2 => s2.Length == '5' && !s2.Contains(encodedValues['b']) && s2.Contains(encodedValues['f']));
                foreach(string str in digits.Where(s2 => s2.Length == 5)) {

                    if (str.Contains(encodedValues['b']))
                        continue;
                    else if (!str.Contains(encodedValues['f']))
                        continue;
                    else
                        str2 = str;
                }


                foreach (char c in str2) {
                    if (encodedValues.ContainsValue(c))
                        continue;
                    else
                        encodedValues['g'] = c;
                }

                //Determine e
                str2 = digits.FirstOrDefault(s2 => s2.Length == 7);
                foreach(char c in str2) {
                    if (encodedValues.ContainsValue(c))
                        continue;
                    else
                        encodedValues['e'] = c;
                    
                }


                string resultString = ""; 
                string tempString = "";
                Dictionary<char, char> DecodedValues = encodedValues.ToDictionary(c => c.Value, c => c.Key);
                foreach(string str in s.Split('|')[1].Split(' ')) {
                    tempString = "";
                    foreach(char c in str) {
                        if(!char.IsWhiteSpace(c))
                            tempString += DecodedValues[c];
                    }
                    char[] temp = tempString.ToCharArray();
                    Array.Sort(temp);
                    string tempStringSorted = new string(temp);
                    if(tempString != "")
                        resultString += Values[tempStringSorted];
                }
                result += int.Parse(resultString);
                


            }
            return result;
        }

    }
}
