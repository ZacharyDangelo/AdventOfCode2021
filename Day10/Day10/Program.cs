using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10 {
    class Program {
        public static Dictionary<char, char> symbolPairs = new Dictionary<char, char> {
            {'{','}' },
            {'(', ')' },
            {'[', ']' },
            {'<', '>' }
        };
        public static Dictionary<char, int> corruptedSymbolScores = new Dictionary<char, int> {
            {')', 3 },
            {']', 57 },
            {'}', 1197 },
            {'>', 25137 }
        };

        public static Dictionary<char, int> incompleteSymbolScores = new Dictionary<char, int> {
            {')', 1 },
            {']', 2 },
            {'}', 3 },
            {'>', 4 }
        };

        static void Main(string[] args) {
            List<string> completedStrings = new List<string>();
            string[] input = System.IO.File.ReadAllLines("input.txt");
            int corruptedScore = 0;
            foreach(string s in input) {
                int corruptedScoreChange = CheckLine(s);
                corruptedScoreChange = CheckLine(s);
                if (corruptedScoreChange != 0)
                    corruptedScore += corruptedScoreChange;
                else
                    completedStrings.Add(CompleteLine(s));
            }
            Console.WriteLine(corruptedScore);
            Console.WriteLine(CalculatePartTwoScore(completedStrings));
        }

        public static long CalculatePartTwoScore(List<string> completedStrings) {
            List<long> scores = new List<long>();
            foreach(string s in completedStrings) {
                long score = 0;
                foreach(char c in s) {
                    score *= 5;
                    score += incompleteSymbolScores[c];
                }
                scores.Add(score);
            }
            scores.Sort();

            return scores.ElementAt((scores.Count-1) / 2);
            
        }

        public static string CompleteLine(string s) {
            Stack<char> symbolStack = new Stack<char>();
            string result = "";
            foreach (char c in s) {
                //If the character is an opening symbole
                if (symbolPairs.Keys.Contains(c)) {
                    symbolStack.Push(c);
                }
                else {
                    if (c != symbolPairs[symbolStack.Peek()])
                        continue;
                    else
                        symbolStack.Pop();
                }

            }
            foreach(char c in symbolStack) {
                result += symbolPairs[c];
            }

            return result;
        }

        public static int CheckLine(string s) {
            Stack<char> symbolStack = new Stack<char>();
            int score = 0;
            foreach(char c in s) {
                //If the character is an opening symbole
                if (symbolPairs.Keys.Contains(c)) {
                    symbolStack.Push(c);
                }
                else {
                    if (c != symbolPairs[symbolStack.Peek()])
                        return corruptedSymbolScores[c];
                    else
                        symbolStack.Pop();
                }

            }

            return score;
        }
        

    }
}
