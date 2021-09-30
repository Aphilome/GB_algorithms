using System;
using System.Runtime.InteropServices;
using System.Text;

namespace IsSimpleNumber
{
    class Program
    {
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

            // тут видимо забыла d создать?
            ulong i = 0; // внимтельнее. Разве по алгоритму 0 она равна?
            while (i < n)
            {
                if (n % i == 0)
                {
                    d++;
                }
                
                i++;
            }
            
            // посленяя проверка d
            
            
            //Console.WriteLine("Excellent");    
        }
    }
}
