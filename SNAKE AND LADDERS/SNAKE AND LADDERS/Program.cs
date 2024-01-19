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
                for (int j = 0; j < 7; j++)
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
        public int[] snake_array(int[,] list)
        {
            int[] snake = new int[7];
            for (int i = 0; i < list.GetLength(1); i++)
            {
                snake[i] = list[0, i];
            }
            return snake;
        }
        public int[] ladder_array(int[,] list)
        {
            int[] ladder = new int[7];
            for (int i = 0; i < list.GetLength(1); i++)
            {
                ladder[i] = list[1, i];
            }
            return ladder;
        }
        public int[] noplay_array(int[,] list)
        {
            int[] noplay = new int[7];
            for (int i = 0; i < list.GetLength(1); i++)
            {
                noplay[i] = list[0, i];
            }
            return noplay;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int player_position = 1;
            int chance = 0;
            int dierolls = 0;
            List<int> list = new List<int> { 20, 30, 40, 50 };
            Console.WriteLine($"Player Position : {player_position}");
            dice die = new dice();
            int[,] ladder_snake_noplay=die.Ladder_Snake_Noplay();
            int[] snake = die.snake_array(ladder_snake_noplay);
            int[] ladder = die.ladder_array(ladder_snake_noplay);
            int[] noplay = die.noplay_array(ladder_snake_noplay);
            do
            {
                Console.ReadKey();
                int val = random.Next(6) + 1;
                die.roll(val);
                dierolls++;
                if (chance == 0 && player_position+val<=100)
                player_position += val;
                else 
                    chance= 0;
                Console.WriteLine($"Player Position : {player_position}");
                if (snake.Contains(player_position))
                {
                    int snake_container= random.Next(20, 40);
                    if (player_position - snake_container < 0)
                        player_position = 0;
                    else
                        player_position -= snake_container;
                    Console.WriteLine($"Snake : {snake_container}");
                    Console.WriteLine(" ( ) ");
                    Console.WriteLine("  \\  ");
                    Console.WriteLine("  /  ");
                    Console.WriteLine("  \\  ");
                    Console.WriteLine("  / ");
                    Console.WriteLine($"Player Position : {player_position}");
                }
                else if (ladder.Contains(player_position))
                {
                    int ladder_container;
                    do
                    {
                        ladder_container = random.Next(4);
                    } while (player_position + list[ladder_container] > 100);
                    player_position += list[ladder_container];
                    Console.WriteLine($"Ladder : {list[ladder_container]}");
                    Console.WriteLine("|-|");
                    Console.WriteLine("|-|");
                    Console.WriteLine("|-|");
                    Console.WriteLine("|-|");
                    Console.WriteLine("|-|");
                    Console.WriteLine($"Player Position : {player_position}");
                }
                else if (noplay.Contains(player_position))
                {
                    chance = 1;
                    Console.WriteLine($"Chance : {chance}");
                }
            } while (player_position < 100);
        }
    }
}
