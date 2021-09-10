using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Snake : Point
    {
        private static Random random = new Random();

        public delegate void KeyboardButton(object sender, ConsoleKeyPressedEventArgs e);

        public event KeyboardButton OnKeyPressed;

        private Direction _direction;

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
            _direction = Direction.RIGHT; //дефолтное направление змейки
            _head = new Point(x, y);
            _tail = new Point(x, y);
            _tailOld = new Point(0, 0);
            _food = food;
            snake.Add(_head);
            OnKeyPressed += (sender, e) =>
            {
                ChangeDirection(e.KeyPressed);
            };
            //Создание "задачи" которая будет отлавливать нажатие клавиши на клавиатуре
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    OnKeyPressed?.Invoke(this, new ConsoleKeyPressedEventArgs(Console.ReadKey(true)));
                }
            });
        }

        /// <summary>
        /// Меняет направление змейки в зависимости от нажатой клавиши на клавиатуре
        /// </summary>
        /// <param name="keyInfo">Параметры нажатой клавиши</param>
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

        /// <summary>
        /// Перемещение змейки по полю
        /// </summary>
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

        /// <summary>
        /// Отрисовка точки на поле консоли
        /// </summary>
        public override void PrintPoint()
        {
            Console.SetCursorPosition(this.X, this.Y); //финальный вариант
            Console.Write(_symbol);
        }

        /// <summary>
        /// Отрисовка "головы" змейки И удаление хвоста
        /// </summary>
        /// <param name="tailX">прежнияя координата Х хвоста</param>
        /// <param name="tailY">прежнияя координата Y хвоста</param>
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

        /// <summary>
        /// Увеличение длины змейки при съедании еды
        /// </summary>
        /// <param name="food">Объект еды</param>
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

        /// <summary>
        /// Движение змейки вправо
        /// </summary>
        public void MoveRight()
        {
            if (_food.X == _head.X + 1 && _food.Y == _head.Y) //Это условие заменить событием
            {
                LengthIncrease(ref _food);
                return;
            }
            _tailOld.X = _tail.X;
            _tailOld.Y = _tail.Y;
            if (snake.Count > 1)
                for (int i = snake.Count - 1; i > 0; i--)
                {
                    snake[i].X = snake[i - 1].X;
                    snake[i].Y = snake[i - 1].Y;
                }
            snake[0].X++;
            _head = snake[0];
            _tail = snake[snake.Count - 1];
            PrintSnakeHead(_tailOld.X, _tailOld.Y);
        }

        /// <summary>
        /// Движение змейки вверх
        /// </summary>
        public void MoveUp()
        {
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

        /// <summary>
        /// Движение змейки вниз
        /// </summary>
        public void MoveDown()
        {
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

        /// <summary>
        /// Движение змейки влево
        /// </summary>
        public void MoveLeft()
        {
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
    }
}