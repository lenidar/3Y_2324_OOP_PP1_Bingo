using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Y_2324_OOP_PP1_Bingo
{
    internal class Program
    {
        static Random _rnd = new Random();
        static int[,] _card = null;

        static void Main(string[] args)
        {
            while (true)
            {
                Initialize();
                GenerateCard();
                DisplayCard();

                if (!Regenerate())
                    break;
            }
        }

        static void Initialize()
        {
            Console.Clear();

            _card = new int[5, 5];
            for(int x = 0; x < _card.GetLength(0); x++) 
                for(int y = 0; y < _card.GetLength(1); y++)
                    _card[x,y] = 0;
        }

        static void GenerateCard()
        {
            List<int> nums = new List<int>();
            int num = 0;

            // columnar generation
            for(int y = 0; y < _card.GetLength(1); y++) // column
            {
                nums = ReGenerateList(nums);
                for(int x = 0; x < _card.GetLength(0); x++) // row
                {
                    //Console.WriteLine($"{x},{y}");
                    num = nums[_rnd.Next(nums.Count)];
                    nums.Remove(num);
                    _card[x, y] = ModifyNumber(num, y);
                }
            }
        }

        static List<int> ReGenerateList(List<int> numbers)
        {
            numbers.Clear();

            for(int x = 1; x <= 15; x++)
                numbers.Add(x);

            return numbers;
        }

        static int ModifyNumber(int num, int colNum)
        {
            return (colNum * 15) + num;
        }

        static void DisplayCard()
        {
            Console.WriteLine("\t|   B   |   I   |   N   |   G   |   O   |\t");
            Console.WriteLine("\t-----------------------------------------");
            for (int x = 0; x < _card.GetLength(0); x++)
            {
                Console.Write("\t|  ");
                for (int y = 0; y < _card.GetLength(1); y++)
                {
                    if(x == 2 && y == 2)
                        Console.Write("FRE  |  ");
                    else
                        Console.Write(FormatNum(_card[x, y]) + "  |  ");
                }
                Console.WriteLine("\n\t-----------------------------------------");
            }
        }

        static string FormatNum(int num)
        {
            string fNum = num + "";

            while (fNum.Length < 3)
                fNum = "0" + fNum;

            return fNum;
        }

        static bool Regenerate()
        {
            string uInput = "";
            Console.Write("\n\nWould you like to regenerate the card? [Y/N]\t");
            uInput = Console.ReadLine().ToUpper();
            if (uInput == "Y")
                return true;
            else
                return false;
        }
    }
}
