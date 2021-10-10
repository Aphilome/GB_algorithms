using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace StringSearch
{
    class Program
    {
        static public string RandomString()
        {
            Random rnd = new Random();
            string alphabet = "abcdefghijklmnopqrstuvwxyz0123456789";
            int len = rnd.Next(2, 11);
            StringBuilder strB = new StringBuilder(len);
            for (int i = 0; i < len; i++)
                strB.Append(alphabet[rnd.Next(alphabet.Length)]);
            return strB.ToString();
        }
        
        static void Main(string[] args)
        {
            int size = 10000;
            
            string[] randomStrMas = new string[size + 1];
            HashSet<string> randomStrHashSet = new HashSet<string>(size + 1);
            for (int i = 0; i < randomStrMas.Length; i++)
            {
                string rs = RandomString();
                while (randomStrHashSet.Contains(rs))
                    rs = RandomString();
                randomStrMas[i] = rs;
                randomStrHashSet.Add(rs);
            }

            string existStr = "qwertyuioasdfghjklzxcvbnm";
            string notExistStr = "qqqqqqqqqqqqqqqqqqqqqqqqqqqqqq";
            randomStrMas[size] = existStr;
            randomStrHashSet.Add(existStr);

            randomStrMas.Contains(existStr);
            randomStrHashSet.Contains(existStr);


            Stopwatch sw = new Stopwatch();
            sw.Start();
            randomStrMas.Contains(existStr);
            randomStrMas.Contains(notExistStr);
            sw.Stop();
            long masTime = sw.ElapsedTicks;
            sw.Restart();
            randomStrHashSet.Contains(existStr);
            randomStrHashSet.Contains(notExistStr);
            sw.Stop();
            long hashSetTime = sw.ElapsedTicks;

            Console.WriteLine($"Massive: {masTime} ms");
            Console.WriteLine($"HashSet: {hashSetTime} ms");
        } 
    }
}