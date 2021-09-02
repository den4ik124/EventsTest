using System;

namespace SnakeGame
{
    public class Food : Point
    {
        private const char _symbol = 'X';

        public Food(int x, int y) : base(x, y)
        {
        }

        public override void PrintPoint()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(this.X, this.Y); //финальный вариант
            Console.Write(_symbol);
            Console.ResetColor();
        }
    }
}