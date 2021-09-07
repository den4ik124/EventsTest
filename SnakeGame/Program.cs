using System;
using System.Windows.Input;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Program
    {
        private static Random random = new Random();

        private static void Main(string[] args)
        {
            Preview();
            Console.ReadLine();

            new Game().Start();
            Ending();
        }

        private static void Preview() => Message("Press any key to start the game...", ConsoleColor.Red);

        private static void Ending()
        {
            Console.Clear();
            while (true)
            {
                var color = (ConsoleColor)random.Next(0, 16);
                Message("Congratulations !!!", color);
                Thread.Sleep(50);
            }
        }

        private static void Message(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, (Console.WindowHeight - 1) / 2);
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}