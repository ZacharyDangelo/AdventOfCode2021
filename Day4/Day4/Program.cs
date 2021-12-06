using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4 {
    public struct BingoBoard {
        public int[,] numbers;
        public int score;

        public void PrintBoard() {
            Console.WriteLine("-----");
            for(int x = 0; x < 5; x++) {
                for(int y = 0; y < 5; y++) {
                    Console.Write(numbers[x, y] + " ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("-----");
        }

        public bool HasBingo() {
            int counter = 0;
            //Check horizontal
            for (int x = 0; x < 5; x++) {
                for (int y = 0; y < 5; y++) {
                    if (numbers[x, y] == -1)
                        counter++;
                }
                if (counter == 5)
                    return true;
                else
                    counter = 0;
            }
            counter = 0;
            //Check Vertical
            for(int y = 0; y < 5; y++) {
                for(int x = 0; x < 5; x++) {
                    if (numbers[x, y] == -1)
                        counter++;
                }
                if (counter == 5)
                    return true;
                else
                    counter = 0;
            }


            return false;
        }

        //Sets a number to 0 if it is marked by the called bingo numbers
        public void MarkNumber(int val) {
            for (int x = 0; x < 5; x++) {
                for (int y = 0; y < 5; y++) {
                    if (numbers[x, y] == val)
                        numbers[x, y] = -1;
                }
            }
        }

        public int GetScore(int lastNumber) {
            int sum = 0;
            for (int x = 0; x < 5; x++) {
                for (int y = 0; y < 5; y++) {
                    if (numbers[x, y] == -1)
                        continue;
                    else
                        sum += numbers[x, y];
                }
            }
            return sum * lastNumber;
        }

        public void SetNumbers(string[] board) {
            numbers = new int[5, 5];
            int currentIndex = 0;
            foreach(string s in board) {
                string[] temp = s.Split(' ');
                temp = temp.Where(line => line != "").ToArray();
                for (int i = 0; i < 5; i++)
                    numbers[currentIndex, i] = Int32.Parse(temp[i]);
                currentIndex++;
            }
        }
    }


    class Program {
        static void Main(string[] args) {
            string[] bingoNumers = { "7", "4", "9", "5", "11", "17", "23", "2", "0", "14", "21", "24",
                "10", "16", "13", "6", "15", "25", "12", "22", "18", "20", "8", "19", "3", "26", "1" };




            string[] uniqueInput = System.IO.File.ReadAllLines("input.txt");
            Console.WriteLine(CalculateBingoWinner(uniqueInput));

        }

        public static int CalculateBingoWinner(string[] input) {
            List<BingoBoard> bingoBoards = ReadBingoBoards(input.Skip(2).ToArray());
            string[] bingoNumbers = input[0].Split(',').Where(s => s != "").ToArray();
            int result =0;
            foreach(string number in bingoNumbers) {
                int val = Int32.Parse(number);
                foreach(BingoBoard board in bingoBoards) {
                    board.MarkNumber(val);
                }
                foreach (BingoBoard board in bingoBoards) {
                    if (board.HasBingo()) {
                        result = board.GetScore(val);
                    }
                }
                bingoBoards.RemoveAll(b => b.HasBingo());
            }

            return result;
        }

        public static List<BingoBoard> ReadBingoBoards(string[] input) {
            List<BingoBoard> result = new List<BingoBoard>();
            int currentBoardIndex = 0;
            input = input.Where(s => s != "").ToArray();
            while (currentBoardIndex + 5 <= input.Length) {
                BingoBoard currentBoard = new BingoBoard();
                string[] temp = new string[5];
                for (int i = 0; i < 5; i++) {
                    temp[i] = input[i + currentBoardIndex];
                }
                currentBoard.SetNumbers(temp);
                result.Add(currentBoard);
                currentBoard.PrintBoard();
                currentBoardIndex+=5;
            }
            return result;
        }

    }
}
