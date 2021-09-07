using System;
using System.Threading.Tasks;

namespace EventsTest2
{
    public class Notifyer
    {
        public delegate void MessageHandler(string message);

        public event MessageHandler Notify;

        public Notifyer()
        {
        }

        private int _value;

        public int Value
        {
            get => _value;
            set
            {
                this._value = value;
                if (value % 10 == 0)
                    Notify?.Invoke($"Было введено {value}");
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            #region EventsCode

            Notifyer notifyer = new Notifyer();
            notifyer.Notify += DisplayMessage;
            while (true)
            {
                notifyer.Value = int.Parse(Console.ReadLine());
            }

            #endregion EventsCode

            Console.ReadLine();
        }

        public static void DisplayMessage(string message) => Console.WriteLine(message);
    }
}