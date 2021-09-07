using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnakeGame
{
    //internal class KeyEvent
    //{
    //    public event EventHandler<ConsoleKeyPressedEventArgs> KeyPress;

    //    public void OnKeyPress(ConsoleKeyInfo _key)
    //    {
    //        KeyPress(this, new ConsoleKeyPressedEventArgs(_key));
    //    }
    //}

    public class Snake : Point
    {
        private static Random random = new Random();

        public delegate void KeyboardButton(object sender, ConsoleKeyPressedEventArgs e);

        public event KeyboardButton OnKeyPressed;

        private Direction _direction;

        //private Queue<Point> snake = new Queue<Point>();
        private List<Point> snake = new List<Point>();

        private const char _symbol = 'O';

        private Point _head;
        private Point _tail;
        private Point _tailOld;
        private Food _food;

        private int _score = 0;

        public int Score { get => _score; }

        public Snake(int x, int y, Food food) : base(x, y)
        {
            //snake.Enqueue(new Point(x, y));
            //snake.Peek().PrintPoint();
            _direction = Direction.RIGHT;
            _head = new Point(x, y);
            _tail = new Point(x, y);
            _tailOld = new Point(0, 0);
            _food = food;
            snake.Add(_head);
            OnKeyPressed += (sender, e) =>
            {
                ChangeDirection(e.KeyPressed);
            };
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    OnKeyPressed?.Invoke(this, new ConsoleKeyPressedEventArgs(Console.ReadKey(true)));
                }
            });
        }

        public void ChangeDirection(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    _direction = Direction.UP;
                    break;

                case ConsoleKey.DownArrow:
                    _direction = Direction.DOWN;
                    break;

                case ConsoleKey.RightArrow:
                    _direction = Direction.RIGHT;
                    break;

                case ConsoleKey.LeftArrow:
                    _direction = Direction.LEFT;
                    break;
            }
        }

        public void MoveSnake()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(_score);
            switch (_direction)
            {
                case Direction.LEFT:
                    MoveLeft();
                    break;

                case Direction.RIGHT:
                    MoveRight();
                    break;

                case Direction.UP:
                    MoveUp();
                    break;

                case Direction.DOWN:
                    MoveDown();
                    break;

                default: break;
            }
        }

        public override void PrintPoint()
        {
            Console.SetCursorPosition(this.X, this.Y); //финальный вариант
            Console.Write(_symbol);
        }

        public void PrintSnakeHead(int tailX, int tailY) //Сделать метод универсальным
        {
            try
            {
                Console.SetCursorPosition(_head.X, _head.Y);
                Console.Write(_symbol);
                Console.SetCursorPosition(tailX, tailY);
                Console.Write(' ');
            }
            catch (Exception)
            {
                Console.Clear();
                string text = "GAME OVER!";
                Console.WriteLine(text);
            }
        }

        public void LengthIncrease(ref Food food)
        {
            _score++;
            snake.Insert(0, new Point(food.X, food.Y));
            food.X = random.Next(0, Console.WindowWidth / 2);
            food.Y = random.Next(0, Console.WindowHeight / 2);
            food.PrintPoint();
            _head = snake[0];
            _tail = snake[snake.Count - 1];
            PrintSnakeHead(_tailOld.X, _tailOld.Y);
        }

        public void MoveRight()
        {
            //var x = this.X = snake.Peek().X += 1;
            //var y = this.Y = snake.Peek().Y;
            //PrintSnakeHead();
            //snake.Dequeue();
            //snake.Enqueue(new Point(x, y));
            if (_food.X == _head.X + 1 && _food.Y == _head.Y) //Это условие заменить событием
            {
                LengthIncrease(ref _food);
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
            snake[0].X++;

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
            if (_food.X == _head.X && _food.Y == _head.Y - 1) //Это условие заменить событием
            {
                this.LengthIncrease(ref _food);
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
            snake[0].Y--;
            _head = snake[0];
            _tail = snake[snake.Count - 1];
            PrintSnakeHead(_tailOld.X, _tailOld.Y);
        }

        public void MoveDown()
        {
            //var x = snake.Peek().X;
            //var y = snake.Peek().Y += 1;
            //PrintSnakeHead();
            //snake.Dequeue();
            //snake.Enqueue(new Point(x, y));

            if (_food.X == _head.X && _food.Y == _head.Y + 1) //Это условие заменить событием
            {
                this.LengthIncrease(ref _food);
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
            snake[0].Y++;
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
            if (_food.X == _head.X - 1 && _food.Y == _head.Y) //Это условие заменить событием
            {
                LengthIncrease(ref _food);
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