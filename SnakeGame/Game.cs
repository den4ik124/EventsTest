using System;
using System.Threading;

namespace SnakeGame
{
    public class Game
    {
        private static Snake _snake;

        public Game()
        {
            Console.CursorVisible = false;
            Food food = new Food(10, 5);
            _snake = new Snake(5, 5, food);
            food.PrintPoint();
            _snake.PrintPoint();
        }

        public void Start()
        {
            Console.Clear();
            do
            {
                _snake.MoveSnake();
                Thread.Sleep(100);
            } while (_snake.Score < 6);
        }
    }
}