using System;
using System.ComponentModel;

namespace SnakeGame
{
    public class ConsoleKeyPressedEventArgs : EventArgs
    {
        public ConsoleKeyInfo KeyPressed { get; set; }

        public ConsoleKeyPressedEventArgs(ConsoleKeyInfo consoleKeyInfo)
        {
            KeyPressed = consoleKeyInfo;
        }
    }
}