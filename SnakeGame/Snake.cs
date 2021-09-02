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

        public void MoveRight(Food food)
        {
            //var x = this.X = snake.Peek().X += 1;
            //var y = this.Y = snake.Peek().Y;
            //PrintSnakeHead();
            //snake.Dequeue();
            //snake.Enqueue(new Point(x, y));
            if (food.X == _head.X + 1 && food.Y == _head.Y) //Это условие заменить событием
            {
                this.LengthIncrease(food.X, food.Y);
                food.X = food.X + 5;
                food.PrintPoint();
                _head = snake[0];
                _tail = snake[snake.Count - 1];
                PrintSnakeHead(_tailOld.X, _tailOld.Y);
                return;
            }

            _tailOld = new Point(_tail.X, _tail.Y);
            for (int i = 0; i < snake.Count; i++)
                snake[i].X++;

            _head = snake[0];
            _tail = snake[snake.Count - 1];

            PrintSnakeHead(_tailOld.X, _tailOld.Y);
        }

        public void MoveUp()
        {
            //var x = snake.Peek().X;
            //var y = snake.Peek().Y -= 1;
            //PrintSnakeHead();
            //snake.Dequeue();
            //snake.Enqueue(new Point(x, y));
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
                this.LengthIncrease(food.X, food.Y);
                food.Y = food.Y + 5;
                food.PrintPoint();
                _head = snake[0];
                _tail = snake[snake.Count - 1];
                PrintSnakeHead(_tailOld.X, _tailOld.Y);
                return;
            }
            _tailOld = new Point(_tail.X, _tail.Y);

            for (int i = 0; i < snake.Count; i++)
                snake[i].Y++;

            _head = snake[0];
            _tail = snake[snake.Count - 1];
            PrintSnakeHead(_tailOld.X, _tailOld.Y);
        }

        public void MoveLeft()
        {
            //var x = snake.Peek().X -= 1;
            //var y = snake.Peek().Y;
            //PrintSnakeHead();
            //snake.Dequeue();
            //snake.Enqueue(new Point(x, y));
        }

        //public void LengthIncrease(int x, int y) => snake.Enqueue(new Point(x, y));
        public void LengthIncrease(int x, int y) => snake.Insert(0, new Point(x, y));
    }
}