using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_and_Ladder_2Players
{
    public class Obstacles
    {
        public int[,] ladder_snakes_noplay()
        {
            int[,] ladder_snakes_and_noplay = new int[3, 7];
            HashSet<int> set = new HashSet<int>();
            Random random = new Random();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    int val;
                    if (i == 0)
                    {
                        do
                        {
                            val = random.Next(1, 81);
                            if (!set.Contains(val))
                                set.Add(val);
                        } while (!set.Contains(val));
                        ladder_snakes_and_noplay[i, j] = val;
                    }
                    else if (i == 1)
                    {
                        do
                        {
                            val = random.Next(21, 101);
                            if (!set.Contains(val))
                                set.Add(val);
                        } while (!set.Contains(val));
                        ladder_snakes_and_noplay[i, j] = val;
                    }
                    else if (i == 2)
                    {
                        do
                        {
                            val = random.Next(1, 100);
                            if (!set.Contains(val))
                                set.Add(val);
                        } while (!set.Contains(val));
                        ladder_snakes_and_noplay[i, j] = val;
                    }
                }
            }
            return ladder_snakes_and_noplay;
        }
        public int[] Ladder(int[,] ladder_snakes_and_noplay)
        {
            int[] ladder = new int[7];
            for (int i = 0; i < ladder_snakes_and_noplay.GetLength(1); i++)
            {
                ladder[i] = ladder_snakes_and_noplay[0, i];
            }
            return ladder;
        }
        public int[] Snakes(int[,] ladder_snakes_and_noplay)
        {
            int[] snakes = new int[7];
            for (int i = 0; i < ladder_snakes_and_noplay.GetLength(1); i++)
            {
                snakes[i] = ladder_snakes_and_noplay[1, i];
            }
            return snakes;
        }
        public int[] Noplay(int[,] ladder_snakes_and_noplay)
        {
            int[] noplay = new int[7];
            for (int i = 0; i < ladder_snakes_and_noplay.GetLength(1); i++)
            {
                noplay[i] = ladder_snakes_and_noplay[2, i];
            }
            return noplay;
        }
        public void Dice(int val)
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

    public class Players : Obstacles
    {
        public int player;
        public Players()
        {
            this.player = 1;
        }
        public int player_position(int[] ladder, int[] snakes, int val, Random rand)
        {
            List<int> list = new List<int> { 20, 30, 40, 50 };
            if (this.player + val <= 100)
            {
                this.player += val;
                if (ladder.Contains(this.player))
                {
                    int increment = list[rand.Next(0, list.Count)];
                    do
                    {
                        if (this.player + increment <= 100)
                            this.player += increment;
                        increment = list[rand.Next(0, list.Count)];
                    } while (this.player + increment > 100);

                    Console.WriteLine($"Ladder : {increment}");
                    Console.WriteLine("|-|");
                    Console.WriteLine("|-|");
                    Console.WriteLine("|-|");
                    Console.WriteLine("|-|");
                }
                else if (snakes.Contains(this.player))
                {
                    int minus = rand.Next(20, 41);
                    this.player -= minus;
                    if (this.player < 0)
                    {
                        this.player = 0;
                    }
                    Console.WriteLine($"Snake : {minus}");
                    Console.WriteLine(" ( ) ");
                    Console.WriteLine("  \\ ");
                    Console.WriteLine("  /  ");
                    Console.WriteLine("  \\ ");
                    Console.WriteLine("  /  ");
                }

            }
            return this.player;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Players play1 = new Players();
            Players play2 = new Players();
            Obstacles obstacles = new Obstacles();
            Random rand = new Random();
            int[,] ladder_snakes_noplay = obstacles.ladder_snakes_noplay();
            int[] ladder = obstacles.Ladder(ladder_snakes_noplay);
            int[] snakes = obstacles.Snakes(ladder_snakes_noplay);
            int[] noplay = obstacles.Noplay(ladder_snakes_noplay);
            int player1 = 1;
            int player2 = 1;
            int chance = 1;
            int val;
            int chance1 = 0;
            int chance2 = 0;
            Console.WriteLine("Press Any Key To Start The Game ...");

            do
            {
                Console.ReadKey();
                if (chance == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Player 1");
                    val = rand.Next(6) + 1;
                    obstacles.Dice(val);
                    if (chance1 == 0)
                    {
                        player1 = play1.player_position(ladder, snakes, val, rand);
                        if (noplay.Contains(player1))
                        {
                            chance1 = 1;
                            Console.WriteLine($"Chance : {chance1}");
                        }
                    }

                    else
                    {
                        chance1 = 0;
                    }
                    Console.WriteLine($"Player1 : {player1}");
                    chance = 2;
                }

                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Player 2");
                    val = rand.Next(6) + 1;
                    obstacles.Dice(val);
                    if (chance2 == 0)
                    {
                        player2 = play2.player_position(ladder, snakes, val, rand);
                        if (noplay.Contains(player2))
                        {
                            chance2 = 1;
                            Console.WriteLine($"Chance : {chance2}");
                        }

                    }
                    else
                    {
                        chance2 = 0;
                    }
                    Console.WriteLine($"Player2 : {player2}");
                    chance = 1;
                }
            } while (player1 < 100 && player2 < 100);
            if (player1 == 100)
            {
                Console.WriteLine("Player 1 has Won the Game ...");
            }
            else
            {
                Console.WriteLine("Player 2 has Won the Game ...");
            }
        }
    }
}
