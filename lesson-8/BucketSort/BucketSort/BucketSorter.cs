using System.Collections.Generic;

namespace BucketSort
{
    public class BucketSorter
    {
        protected int BucketCount = 5;
        protected List<int>[] Buckets { get; }
        
        public BucketSorter()
        {
            Buckets = new[]
            {
                new List<int>(),    // (-...; -1'000'000)
                new List<int>(),    // [-1'000'000; 0)
                new List<int>(),    // [0; 1'000'000)
                new List<int>(),    // [1'000'000; 2'000'000)
                new List<int>(),    // [2'000'000; +...)
            };
        }

        public int[] Sort(int[] input)
        {
            Distributor(input);
            SortBuckets();
            
            var output = UnionBuckets(input.Length);
            
            ClearBuckets();
            
            return output;
        }

        protected virtual void Distributor(int[] input)
        {
            foreach (var i in input)
            {
                switch (i)
                {
                    case < -1000000:
                        Buckets[0].Add(i);
                        break;
                    case >= -1000000 and < 0:
                        Buckets[1].Add(i);
                        break;
                    case >= 0 and < 1000000:
                        Buckets[2].Add(i);
                        break;
                    case >= 1000000 and < 2000000:
                        Buckets[3].Add(i);
                        break;
                    default:
                        Buckets[4].Add(i);
                        break;
                }
            }
        }
        
        private void SortBuckets()
        {
            foreach (var bucket in Buckets)
                bucket.Sort();
        }

        protected virtual int[] UnionBuckets(int inputLen)
        {
            int[] output = new int[inputLen];
            int i = 0;
            foreach (var bucket in Buckets)
            foreach (var j in bucket)
                output[i++] = j;
            return output;
        }

        private void ClearBuckets()
        {
            foreach (var bucket in Buckets)
                bucket.Clear();
        }
    }
}