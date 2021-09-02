using System;
using System.Collections.Generic;

namespace SnakeGame
{
    public class Snake : Point
    {
        private static Random random = new Random();

        //public delegate void KeyboardButton(ConsoleKey key);
        public event EventHandler KeyboardButtonPressed;

        //private Queue<Point> snake = new Queue<Point>();
        private List<Point> snake = new List<Point>();

        private const char _symbol = 'O';

        private Point _head;
        private Point _tail;
        private Point _tailOld;

        public Snake(int x, int y) : base(x, y)
        {
            //snake.Enqueue(new Point(x, y));
            //snake.Peek().PrintPoint();
            _head = new Point(x, y);
            _tail = new Point(x, y);
            _tailOld = new Point(0, 0);
            snake.Add(_head);
        }

        public override void PrintPoint()
        {
            Console.SetCursorPosition(this.X, this.Y); //финальный вариант
            Console.Write(_symbol);
        }

        public void MoveSnake()
        {
        }

        public void PrintSnakeHead(int tailX, int tailY) //Сделать метод универсальным
        {
            Console.SetCursorPosition(_head.X, _head.Y);
            Console.Write(_symbol);
            Console.SetCursorPosition(tailX, tailY);
            Console.Write(' ');
        }

        public void LengthIncrease(ref Food food)
        {
            snake.Insert(0, new Point(food.X, food.Y));
            food.X = food.X + 0;
            food.Y = food.Y - 5;
            food.PrintPoint();
            _head = snake[0];
            _tail = snake[snake.Count - 1];
            PrintSnakeHead(_tailOld.X, _tailOld.Y);
        }

        public void MoveRight(Food food)
        {
            //var x = this.X = snake.Peek().X += 1;
            //var y = this.Y = snake.Peek().Y;
            //PrintSnakeHead();
            //snake.Dequeue();
            //snake.Enqueue(new Point(x, y));
            if (food.X == _head.X + 1 && food.Y == _head.Y) //Это условие заменить событием
            {
                LengthIncrease(ref food);
                return;
            }

            _tailOld.X = _tail.X;
            _tailOld.Y = _tail.Y;
            var temp = snake[snake.Count - 1];
            if (snake.Count > 1)
            {
                for (int i = snake.Count - 1; i > 0; i--)
                {
                    snake[i].X = snake[i - 1].X;
                    snake[i].Y = snake[i - 1].Y;
                }
            }
            snake[0].X++;

            _head = snake[0];
            _tail = snake[snake.Count - 1];

            PrintSnakeHead(_tailOld.X, _tailOld.Y);
        }

        public void MoveUp(Food food)
        {
            //var x = snake.Peek().X;
            //var y = snake.Peek().Y -= 1;
            //PrintSnakeHead();
            //snake.Dequeue();
            //snake.Enqueue(new Point(x, y));
            if (food.X == _head.X && food.Y == _head.Y - 1) //Это условие заменить событием
            {
                this.LengthIncrease(ref food);
                return;
            }

            _tailOld.X = _tail.X;
            _tailOld.Y = _tail.Y;
            var temp = snake[snake.Count - 1];
            if (snake.Count > 1)
            {
                for (int i = snake.Count - 1; i > 0; i--)
                {
                    snake[i].X = snake[i - 1].X;
                    snake[i].Y = snake[i - 1].Y;
                }
            }
            snake[0].Y--;
            _head = snake[0];
            _tail = snake[snake.Count - 1];
            PrintSnakeHead(_tailOld.X, _tailOld.Y);
        }

        public void MoveDown(Food food)
        {
            //var x = snake.Peek().X;
            //var y = snake.Peek().Y += 1;
            //PrintSnakeHead();
            //snake.Dequeue();
            //snake.Enqueue(new Point(x, y));

            if (food.X == _head.X && food.Y == _head.Y + 1) //Это условие заменить событием
            {
                this.LengthIncrease(ref food);
                return;
            }

            _tailOld.X = _tail.X;
            _tailOld.Y = _tail.Y;
            var temp = snake[snake.Count - 1];
            if (snake.Count > 1)
            {
                for (int i = snake.Count - 1; i > 0; i--)
                {
                    snake[i].X = snake[i - 1].X;
                    snake[i].Y = snake[i - 1].Y;
                }
            }
            snake[0].Y++;
            _head = snake[0];
            _tail = snake[snake.Count - 1];
            PrintSnakeHead(_tailOld.X, _tailOld.Y);
        }

        public void MoveLeft(Food food)
        {
            //var x = snake.Peek().X -= 1;
            //var y = snake.Peek().Y;
            //PrintSnakeHead();
            //snake.Dequeue();
            //snake.Enqueue(new Point(x, y));
            if (food.X == _head.X - 1 && food.Y == _head.Y) //Это условие заменить событием
            {
                LengthIncrease(ref food);
                return;
            }

            _tailOld.X = _tail.X;
            _tailOld.Y = _tail.Y;
            if (snake.Count > 1)
            {
                for (int i = snake.Count - 1; i > 0; i--)
                {
                    snake[i].X = snake[i - 1].X;
                    snake[i].Y = snake[i - 1].Y;
                }
            }
            snake[0].X--;

            _head = snake[0];
            _tail = snake[snake.Count - 1];

            PrintSnakeHead(_tailOld.X, _tailOld.Y);
        }

        //public void LengthIncrease(int x, int y) => snake.Enqueue(new Point(x, y));
    }
}