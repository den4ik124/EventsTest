using System;
using System.Windows.Input;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame
{
    public class Program
    {
        public class SnakeEventArgs
        {
            public Food Food { get; set; }

            public ConsoleKey KeyPressed { get; set; }

            public SnakeEventArgs(Food food, ConsoleKey keyPressed)
            {
                Food = food;
                KeyPressed = keyPressed;
            }
        }

        public delegate void KeyboardButton(object sender, EventArgs e);

        public static event KeyboardButton OnKeyPressed;

        private static Snake _snake;

        private static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Food food = new Food(10, 5);
            //Food food = new Food(5, 10);

            _snake = new Snake(5, 5, food);
            food.PrintPoint();
            _snake.PrintPoint();
            OnKeyPressed += (o, e) =>
            { //определить какая клавиша была нажата и передать в метод _snake.ChangeDirection()
                ConsoleKey keyPressed;
                switch (Console)
                {
                    default:
                        break;
                }

                var test = Console.ReadKey(true).Key;
            };
            int i = 0;
            do
            {
                _snake.MoveSnake();
                Thread.Sleep(100);
                i++;
            } while (true);
        }

        public static void Move(object sender, EventArgs e)
        {
            _snake.MoveSnake();
        }
    }
}