﻿using System;
using System.Windows.Input;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Snake snake = new Snake(5, 5);
            Food food = new Food(10, 5);
            //Food food = new Food(5, 10);
            //new Food(50, 10).PrintPoint();
            //snake.LengthIncrease(11, 10);
            //snake.LengthIncrease(12, 10);
            //snake.LengthIncrease(13, 10);
            food.PrintPoint();
            snake.PrintPoint();
            //snake.KeyboardButtonPressed += Move;
            int i = 0;
            do
            {
                //snake.MoveDown(food);
                //Thread.Sleep(100);
                snake.MoveRight(food);
                Thread.Sleep(100);
                i++;
            } while (true);
        }

        public void Move(Snake snake, Food food)
        {
            snake.MoveSnake(food);
        }
    }
}