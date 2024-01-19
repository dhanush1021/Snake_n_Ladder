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
        public int[,] Ladder_Snake_Noplay()
        {
            int[,] ladder_snake_noplay = new int[3, 7];
            Random random = new Random();
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    int val;
                    if (i == 0)
                    {
                        do
                        {
                            val = random.Next(20, 101);
                            if (!set.Contains(val))
                                set.Add(val);
                        } while (!set.Contains(val));
                        ladder_snake_noplay[i, j] = val;
                    }
                    else if (i == 1)
                    {
                        do
                        {
                            val = random.Next(1, 81);
                            if (!set.Contains(val))
                                set.Add(val);
                        } while (!set.Contains(val));
                        ladder_snake_noplay[i, j] = val;
                    }
                    else if (i == 2)
                    {
                        do
                        {
                            val = random.Next(1, 101);
                            if (!set.Contains(val))
                                set.Add(val);
                        } while (!set.Contains(val));
                        ladder_snake_noplay[i, j] = val;
                    }
                }
            }
            return ladder_snake_noplay;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int player_position = 0;
            string str;
            dice die = new dice();
            int[,] ladder_snake_noplay=die.Ladder_Snake_Noplay();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write($"{ladder_snake_noplay[i, j]} ");
                }
                Console.WriteLine();
            }
            do
            {
                
                int val = random.Next(6) + 1;
                die.roll(val);
                Console.WriteLine("Do you want to play ?");
                str = Console.ReadLine();
            } while (str == "y");
        }
    }
}
