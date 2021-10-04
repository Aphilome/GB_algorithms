using System;
using System.Linq;

namespace BinarySearch
{
    class Program
    {
        static void Main()
        {
            var mas = Enumerable.Range(1, 20).ToArray();
            var s = 5;
            Console.WriteLine($"Search {s} = {BinarySearch(mas, s)}");
            s = 19;
            Console.WriteLine($"Search {s} = {BinarySearch(mas, s)}");
            s = 55;
            Console.WriteLine($"Search {s} = {BinarySearch(mas, s)}");
        }
        
        // O(log(n))
        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            var min = 0;
            var max = inputArray.Length - 1;
            while (min <= max)
            {
                var mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                    return mid;
                if (searchValue < inputArray[mid])
                    max = mid - 1;
                else
                    min = mid + 1;
            }
            return -1;
        }
    }
}