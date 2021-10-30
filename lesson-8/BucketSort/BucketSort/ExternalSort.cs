using System;
using System.Collections.Generic;
using System.Linq;

namespace BucketSort
{
    public class ExternalSort : BucketSorter
    {
        protected override int[] UnionBuckets(int inputLen)
        {
            int[] output = new int[inputLen];
            for (int i = 0; i < inputLen; i++)
                output[i] = GetMin();
            return output;
        }

        protected override void Distributor(int[] input)
        {
            var random = new Random();
            foreach (var i in input)
                Buckets[random.Next(0, BucketCount)].Add(i);
        }

        private int GetMin()
        {
            int? min = null;
            List<int> minBucket = null;
            foreach (var bucket in Buckets)
            {
                if (bucket.Count == 0)
                    continue;
                if (min == null || min > bucket.First())
                {
                    min = bucket.First();
                    minBucket = bucket;
                }
            }
            minBucket.Remove(minBucket.First());
            
            return min.Value;
        }
    }
}