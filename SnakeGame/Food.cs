using System;

namespace SnakeGame
{
    public class Food : Point
    {
        /// <summary>
        /// Символ для отрисовки "еды"
        /// </summary>
        private const char _symbol = 'X';

        public Food(int x, int y) : base(x, y)
        {
        }

        /// <summary>
        /// Переопредленный метод рисования точки
        /// </summary>
        public override void PrintPoint()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(this.X, this.Y); //финальный вариант
            Console.Write(_symbol);
            Console.ResetColor();
        }
    }
}