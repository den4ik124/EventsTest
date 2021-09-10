namespace SnakeGame
{
    /// <summary>
    /// Базовый класс для создания точки в консоли
    /// </summary>
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
}