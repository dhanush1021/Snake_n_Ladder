using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE_AND_LADDERS
{
    class dice
    {
        public void roll(int val)
        {
            switch (val)
            {
                case 1:
                    Console.WriteLine(" ----- ");
                    Console.WriteLine("|     |");
                    Console.WriteLine("|  o  |");
                    Console.WriteLine("|     |");
                    Console.WriteLine(" ----- ");
                    break;
                case 2:
                    Console.WriteLine(" ----- ");
                    Console.WriteLine("|  o  |");
                    Console.WriteLine("|     |");
                    Console.WriteLine("|  o  |");
                    Console.WriteLine(" ----- ");
                    break;
                case 3:
                    Console.WriteLine(" ----- ");
                    Console.WriteLine("|  o  |");
                    Console.WriteLine("|  o  |");
                    Console.WriteLine("|  o  |");
                    Console.WriteLine(" ----- ");
                    break;
                case 4:
                    Console.WriteLine(" ----- ");
                    Console.WriteLine("| o o |");
                    Console.WriteLine("|     |");
                    Console.WriteLine("| o o |");
                    Console.WriteLine(" ----- ");
                    break;
                case 5:
                    Console.WriteLine(" ----- ");
                    Console.WriteLine("|o   o|");
                    Console.WriteLine("|  o  |");
                    Console.WriteLine("|o   o|");
                    Console.WriteLine(" ----- ");
                    break;
                case 6:
                    Console.WriteLine(" ----- ");
                    Console.WriteLine("| o o |");
                    Console.WriteLine("| o o |");
                    Console.WriteLine("| o o |");
                    Console.WriteLine(" ----- ");
                    break;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string str;
            dice die = new dice();
            do
            {
                int val = random.Next(5) + 1;
                die.roll(val);
                Console.WriteLine("Do you want to play ?");
                str = Console.ReadLine();
            } while (str == "Yes");
        }
    }
}
