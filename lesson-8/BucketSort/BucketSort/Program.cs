using System;

namespace BucketSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var bucketSorter = new BucketSorter();
            var externalSorter = new ExternalSort();
            
            var count = 100;
            var mas = new int[count];
            var rnd = new Random();
            for (int i = 0; i < count; i++)
                mas[i] = rnd.Next(int.MinValue, int.MaxValue);
            
            var res1 = bucketSorter.Sort(mas);
            var res2 = externalSorter.Sort(mas);
        }
    }
}
