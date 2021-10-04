using System;
using System.Runtime.InteropServices;
using System.Text;

namespace IsSimpleNumber
{
    class Program
    {
        public static bool IsSimple(ulong number)
        {
            ulong i = 2;
            ulong d = 0;
            while (i < number)
            {
                if (number % i == 0)
                    d++;
                i++;
            }
            if (d == 0)
                return true;
            return false;
        }
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.InputEncoding = Encoding.UTF8;
            }

            ulong n;
            do
            {
                Console.WriteLine("Введите целое положительное число");
            } while (!ulong.TryParse(Console.ReadLine(), out n));

            if (IsSimple(n))
                Console.WriteLine($"Число {n} простое");
            else
                Console.WriteLine($"Число {n} не простое");
        }
    }
}
