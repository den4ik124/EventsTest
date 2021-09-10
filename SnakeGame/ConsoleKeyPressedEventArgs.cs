using System;
using System.ComponentModel;

namespace SnakeGame
{
    /// <summary>
    /// Аргументы события
    /// </summary>
    public class ConsoleKeyPressedEventArgs : EventArgs
    {
        public ConsoleKeyInfo KeyPressed { get; set; }

        public ConsoleKeyPressedEventArgs(ConsoleKeyInfo consoleKeyInfo)
        {
            KeyPressed = consoleKeyInfo;
        }
    }
}