using System;
using System.Runtime.InteropServices;
using System.Text;

namespace PathCounter
{
    public class PathPrinter
    {
        public ulong M { get; private set; }
        
        public ulong N { get; private set; }
        
        public PathPrinter()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.InputEncoding = Encoding.UTF8;
            }
        }
        
        public ulong GetPathCount()
        {
            if (M > 0 && N > 0)
            {
                var i = M - 1;
                var j = N - 1;
                return CalcCount(i, j);
            }
            return 0;
        }
        
        public void SetSize()
        {
            M = ParseInput("Введите M - количество столбцов массива: ");
            N = ParseInput("Введите N - количество строк массива: ");
        }
        
        private ulong CalcCount(ulong i, ulong j)
        {
            if (i == 0 || j == 0)
                return 1;
            return CalcCount(i, j - 1) + CalcCount(i - 1, j);
        }
        
        private ulong ParseInput(string prompt)
        {
            Console.Write(prompt);
            if (!ulong.TryParse(Console.ReadLine(), out ulong input))
            {
                //Console.WriteLine("Ошибка парсинга");
                throw new InvalidCastException("Ошибка парсинга");
            }
            return input;
        }
        
        // public void Print2(ulong n, ulong m, ulong[,] a)
        // {
        //     for (ulong i = 0; i < n; i++)
        //     {
        //         for (ulong j = 0; j < m; j++)
        //             Console.Write($"{a[i, j]} "); // установить ширину вывода
        //         Console.WriteLine();
        //     }
        // }
    }
}