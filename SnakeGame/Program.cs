using System;
using System.Windows.Input;
using System.Threading;

namespace SnakeGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Snake snake = new Snake(10, 10);
            //Food food = new Food(10, 13);
            Food food = new Food(12, 12);
            //new Food(50, 10).PrintPoint();
            //snake.LengthIncrease(11, 10);
            //snake.LengthIncrease(12, 10);
            //snake.LengthIncrease(13, 10);
            food.PrintPoint();
            int i = 0;
            do
            {
                snake.MoveDown(food);
                snake.MoveRight(food);
                Thread.Sleep(300);
                i++;
            } while (i < 10);
        }
    }
}