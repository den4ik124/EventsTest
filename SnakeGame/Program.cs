using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Threading;

namespace SnakeGame
{
    public class Food : Point
    {
        private static Random random = new Random();
        private const char _symbol = '@';

        public Food(int x, int y) : base(x, y)
        {
        }

        public override void PrintPoint()
        {
            Console.SetCursorPosition(this.X, this.Y); //финальный вариант
            Console.Write(_symbol);
        }
    }

    public class Snake : Point
    {
        private static Random random = new Random();

        //public delegate void KeyboardButton(ConsoleKey key);
        public event EventHandler KeyboardButtonPressed;

        private Queue<Point> snake = new Queue<Point>();
        private const char _symbol = 'X';

        public Snake(int x, int y) : base(x, y)
        {
            snake.Enqueue(new Point(x, y));
            snake.Peek().PrintPoint();
        }

        public override void PrintPoint()
        {
            Console.SetCursorPosition(this.X, this.Y); //финальный вариант
            Console.Write(_symbol);
        }

        public void MoveSnake()
        {
        }

        public void PrintSnakeHead()
        {
            foreach (var item in snake)
            {
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write(_symbol);
            }
        }

        public void MoveUp()
        {
            var x = snake.Peek().X;
            var y = snake.Peek().Y -= 1;
            PrintSnakeHead();
            snake.Dequeue();
            snake.Enqueue(new Point(x, y));
        }

        public void MoveDown()
        {
            var x = snake.Peek().X;
            var y = snake.Peek().Y += 1;
            PrintSnakeHead();
            snake.Dequeue();
            snake.Enqueue(new Point(x, y));
        }

        public void MoveLeft()
        {
            var x = snake.Peek().X -= 1;
            var y = snake.Peek().Y;
            PrintSnakeHead();
            snake.Dequeue();
            snake.Enqueue(new Point(x, y));
        }

        public void MoveRight(Point food)
        {
            if (food.X == this.X + 1 && food.Y == this.Y) //Это условие заменить событием
            {
                this.LengthIncrease(food.X, food.Y);
                food.X = random.Next(food.X + 1, food.X + 10);
                //point.X = random.Next(0, Console.WindowWidth - 1);
                //point.Y = random.Next(0, Console.WindowHeight - 1);
            }
            var x = this.X = snake.Peek().X += 1;
            var y = this.Y = snake.Peek().Y;
            PrintSnakeHead();
            snake.Dequeue();
            snake.Enqueue(new Point(x, y));
        }

        public void LengthIncrease(int x, int y) => snake.Enqueue(new Point(x, y));
    }

    public class Point
    {
        private int _x;
        private int _y;

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int X
        {
            get => _x;
            set
            {
                if (_x == value)
                    return;
                _x = value;
            }
        }

        public int Y
        {
            get => _y;
            set
            {
                if (_y == value)
                    return;
                _y = value;
            }
        }

        public virtual void PrintPoint()
        {
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Food food = new Food(15, 10);
            //new Food(50, 10).PrintPoint();
            Snake snake = new Snake(10, 10);
            do
            {
                Console.Clear();

                food.PrintPoint();
                snake.MoveRight(food);
                Thread.Sleep(100);
            } while (true);
        }
    }
}