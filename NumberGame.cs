using System;

namespace NumberGame
{
    class Program
    {
        static int number_of_players = 1;
        static String[] players;
        static int[] numbers;
        static int move = 1;
        static int[] scores;

        static void Main(string[] args)
        {
            Console.Title = "Number Game";

            Title();

            Number_Of_Players();
        }

        static void Title()
        {
            Console.Clear();
            Console.WindowWidth = 59;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t---------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t\tNumber Game");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t---------------------------\n");
        }

        static void Warning()
        {
            Console.Clear();
            Console.WindowWidth = 59;

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\t\t---------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t Warning!");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\t\t---------------------------\n");
        }

        static void Number_Of_Players()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Number of Players: ");
            try
            {
                number_of_players = Convert.ToInt16(Console.ReadLine());
            }
            catch (Exception)
            {
                Warning();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tYou can only enter number between 2 and 10!");
                Console.ReadKey();

                Title();
                Number_Of_Players();
            }

            if (!(number_of_players >= 2 && number_of_players <= 10))
            {

                Warning();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You can only enter number between 2 and 10!");
                Console.ReadKey();

                Title();
                Number_Of_Players();
            }

            Players();

        }

        static void Players()
        {
            players = new String[number_of_players + 1];
            numbers = new int[number_of_players + 1];
            scores = new int[number_of_players + 1];

            Title();

            for (int i = 1; i <= number_of_players; i++)
            {
                if (i % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }

                Console.Write("Player {0}: ", i);
                String player = Console.ReadLine().Trim();
                if (player != "")
                {
                    players[i] = player;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Player name can't be empty!");
                    Console.ForegroundColor = ConsoleColor.Green;
                    i--;
                }

            }

            Start();
        }

        static void Start()
        {
            Title();

            for (int i = 1; i <= number_of_players; i++)
            {
                int number = 0;

                Console.Write(players[i] + " choose number between 1 and 1000: ");
                try
                {
                    number = Convert.ToInt16(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You must enter number between 1 and 1000!");
                    Console.ForegroundColor = ConsoleColor.Green;
                    i--;
                    continue;
                }

                if (number > 1000 || number < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You must enter number between 1 and 1000!");
                    Console.ForegroundColor = ConsoleColor.Green;
                    i--;
                    continue;
                }

                numbers[i] = number;
                move = i;

                Title();

                for (int j = 1; j <= number_of_players; j++)
                {
                    if (j != move)
                    {
                        int num = 0;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(players[j] + " you must found " + players[i] + "'s secret number.\n");

                        while (num != number)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Enter number: ");
                            try
                            {
                                num = Convert.ToInt16(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("You must enter number between 1 and 1000!");
                                Console.ForegroundColor = ConsoleColor.Green;
                                continue;
                            }

                            if (num > 1000 || num < 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("You must enter number between 1 and 1000!");
                                Console.ForegroundColor = ConsoleColor.Green;
                                continue;
                            }

                            if (num == number)
                            {
                                break;
                            }
                            else if (num > number)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(players[i] + "'s number is Lower!");
                                scores[j] = scores[j] + (num - number);
                            }
                            else if (num < number)
                            {

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(players[i] + "'s number is Higher!");
                                scores[j] = scores[j] + (number - num);
                            }

                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nCongratulations " + players[j] + " you just find " + players[i] + "'s \nsecret number and earn " + scores[j] + " score!");
                        Console.ReadKey();
                        Title();
                    }
                }
            }

            //Winner

            Console.Clear();
            Console.WindowWidth = 59;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t---------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t\t Score");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t---------------------------\n\n\n\n\n");

            Console.WriteLine("\t\t PLAYER\t|SCORE");
            Console.WriteLine("\t\t ____________________");
            for (int i = 1; i <= number_of_players; i++)
            {
                Console.WriteLine("\t\t " + players[i] + "\t|" + scores[i]);
                Console.WriteLine("\t\t ____________________");
            }
            Console.ReadLine();
            Main(null);
        }
    }
}
