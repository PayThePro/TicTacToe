using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsoleInput;

namespace TicTacToeSpil
{
    public class Program
    {
        const int RefreshRate = 10;

        static void Main(string[] args)
        {
            Input.Setup(true, false);

            start:
            Console.Clear();
            Game game = new Game();

            Console.CursorVisible = false;

            

            bool gameRunning = true;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            PrintBoard(game);

            while (gameRunning)
            {
                while (stopwatch.ElapsedMilliseconds < 1000f / RefreshRate)
                {
                   Thread.Sleep(0);
                }
                stopwatch.Restart();
                Input.Update();


                // DEBUG !!
                Console.Title = $"({Mouse.x}, {Mouse.y}) {CheckInput(Mouse.x, Mouse.y)}";
                // DEBUG !!

                // has player clicked
                if (!Mouse.MouseUp[0])
                {
                    continue;
                }
                
                int? result = CheckInput(Mouse.x, Mouse.y);

                if (!result.HasValue || game.GetCell(result.Value) != Player.Ingen)
                {
                    continue;
                }

                game.MakeMove(result.Value);
                Player? winner = game.CheckWinConditions();

                Console.Clear();
                PrintBoard(game);

                if (winner.HasValue)
                {
                    Console.SetCursorPosition(0, 19);
                    Console.WriteLine($"{Enum.GetName(typeof(Player), winner)} vandt spillet");
                    gameRunning = false;
                    continue;
                }
            }

            Console.WriteLine("Du har gennemført spillet");
            Console.ReadLine();

            goto start;
        }

        static void PrintBoard(Game gamestate)
        {
            //Opsætter gitter
            Console.WriteLine("-------------------------");
            for (int i = 1; i <= 3; i++)
            {
                Console.Write(
                  "|       |       |       |\n"
                + "|       |       |       |\n"
                + "|       |       |       |\n"
                + "|       |       |       |\n"
                + "|       |       |       |\n"
                );

                if (i != 3)
                {
                    Console.Write("|-------|-------|-------|\n");
                }
            }
            Console.Write("-------------------------");

            //Udregner og opsætter brikker
            for (int i = 0; i < 9; i++)
            {
                Player cell = gamestate.GetCell(i);

                if (cell == Player.Ingen)
                {
                    continue;
                }

                int left = i % 3;
                int top = (i - left) / 3;
                //int top = Math.Floor(i / 3);

                if (cell == Player.Bolle)
                {
                    Console.SetCursorPosition(3 + left * 8, 2 + top * 6);
                    Console.Write('█');
                    Console.SetCursorPosition(4 + left * 8, 2 + top * 6);
                    Console.Write('█');
                    Console.SetCursorPosition(5 + left * 8, 2 + top * 6);
                    Console.Write('█');
                    Console.SetCursorPosition(3 + left * 8, 3 + top * 6);
                    Console.Write('█');
                    Console.SetCursorPosition(5 + left * 8, 3 + top * 6);
                    Console.Write('█');
                    Console.SetCursorPosition(3 + left * 8, 4 + top * 6);
                    Console.Write('█');
                    Console.SetCursorPosition(4 + left * 8, 4 + top * 6);
                    Console.Write('█');
                    Console.SetCursorPosition(5 + left * 8, 4 + top * 6);
                    Console.Write('█');
                }
                else
                {
                    Console.SetCursorPosition(3 + left * 8, 2 + top * 6);
                    Console.Write('█');
                    Console.SetCursorPosition(5 + left * 8, 2 + top * 6);
                    Console.Write('█');
                    Console.SetCursorPosition(4 + left * 8, 3 + top * 6);
                    Console.Write('█');
                    Console.SetCursorPosition(3 + left * 8, 4 + top * 6);
                    Console.Write('█');
                    Console.SetCursorPosition(5 + left * 8, 4 + top * 6);
                    Console.Write('█');
                }
            }
        }

        public static int? CheckInput(int left, int top)
        {
            for (int i = 0; i < 3; i++)
            {
                if (left >= 1 + (i * 8) && left < 8 + (i * 8))
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (top >= 1 + (j * 6) && top < 6 + (j * 6))
                        {
                            return i + j * 3;
                        }
                    }
                }
            }

            return null;
        }
    }
}
