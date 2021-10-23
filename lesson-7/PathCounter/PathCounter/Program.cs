using System;

namespace PathCounter
{
    class Program
    {
        static void Main()
        {
            var pather = new PathPrinter();
            try
            {
                pather.SetSize();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            Console.WriteLine($"W({pather.M},{pather.N})={pather.GetPathCount()}");
        }
    }
}
