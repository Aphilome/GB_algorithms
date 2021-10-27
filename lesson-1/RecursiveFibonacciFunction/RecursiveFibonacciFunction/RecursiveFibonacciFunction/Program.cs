using System;
using System.Runtime.InteropServices;
using System.Text;

namespace RecursiveFibonacciFunction
{
    class Program
    {
        static ulong FibIter(ulong index)
        {
            if (index == 0)
                return 0;
            if (index == 1)
                return 1;
            ulong i = 2;
            ulong left;
            ulong right = 1;
            ulong res = 1;

            while (i < index)
            {
                left = right;
                right = res;
                res = left + right;
                i++;
            }
            return res;
        }
        
        static ulong FibRecourse(ulong index)
        {
            if (index == 0)
                return 0;
            if (index == 1)
                return 1;
            return FibRecourse(index - 2) + FibRecourse(index - 1);
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
            
            Console.Write("Введите индекс числа Фибоначчи: ");
            if (!ulong.TryParse(Console.ReadLine(), out ulong index))
            {
                Console.WriteLine("Parse exeption");
                return;
            }
            Console.WriteLine($"F({index}) = {FibRecourse(index)} (рекурсивно)");
            Console.WriteLine($"F({index}) = {FibIter(index)} (итеративно)");
        }
    }
}