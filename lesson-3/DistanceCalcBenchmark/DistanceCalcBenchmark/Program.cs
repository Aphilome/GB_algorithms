using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace DistanceCalcBenchmark
{
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
        
        public class Tests
        {
            private PointClass[,] PointClasses { get; set; }
            private PointStruct<float>[,] PointStructsF { get; set; }
            private PointStruct<double>[,] PointStructsD { get; set; }

            [Params(10, 100)] 
            public int N { get; set; }
            
            [GlobalSetup]
            public void Setup()
            {
                var random = new Random();
                PointClasses = new PointClass[N, 2];
                PointStructsF = new PointStruct<float>[N, 2];
                PointStructsD = new PointStruct<double>[N, 2];
                for (int i = 0; i < N; i++)
                {
                    PointClasses[i, 0] = new PointClass()
                    {
                        X = random.Next() / 100f,
                        Y = random.Next() / 100f
                    };
                    PointClasses[i, 1] = new PointClass()
                    {
                        X = random.Next() / 100f,
                        Y = random.Next() / 100f
                    };
                    
                    PointStructsF[i, 0] = new PointStruct<float>()
                    {
                        X = random.Next() / 100f,
                        Y = random.Next() / 100f
                    };
                    PointStructsF[i, 1] = new PointStruct<float>()
                    {
                        X = random.Next() / 100f,
                        Y = random.Next() / 100f
                    };
                    
                    PointStructsD[i, 0] = new PointStruct<double>()
                    {
                        X = random.Next() / 100d,
                        Y = random.Next() / 100d
                    };
                    PointStructsD[i, 1] = new PointStruct<double>()
                    {
                        X = random.Next() / 100d,
                        Y = random.Next() / 100d
                    };
                }
            }

            [Benchmark(Description = "Class float")]
            public void TestFloatClass()
            {
                for (int i = 0; i < N; i++)
                {
                    float ox = Math.Abs(PointClasses[i, 1].X - PointClasses[i, 0].X);
                    float oy = Math.Abs(PointClasses[i, 1].Y - PointClasses[i, 0].Y);
                    float s = (float)Math.Sqrt(Math.Pow(ox, 2) + Math.Pow(oy, 2));
                }
            }

            [Benchmark(Description = "Struct float")]
            public void TestFloatStructF()
            {
                for (int i = 0; i < N; i++)
                {
                    float ox = Math.Abs(PointStructsF[i, 1].X - PointStructsF[i, 0].X);
                    float oy = Math.Abs(PointStructsF[i, 1].Y - PointStructsF[i, 0].Y);
                    float s = (float)Math.Sqrt(Math.Pow(ox, 2) + Math.Pow(oy, 2));
                }
            }
            
            [Benchmark(Description = "Struct double")]
            public void TestFloatStructD()
            {
                for (int i = 0; i < N; i++)
                {
                    double ox = Math.Abs(PointStructsD[i, 1].X - PointStructsD[i, 0].X);
                    double oy = Math.Abs(PointStructsD[i, 1].Y - PointStructsD[i, 0].Y);
                    double s = Math.Sqrt(Math.Pow(ox, 2) + Math.Pow(oy, 2));
                }
            }
            
            [Benchmark(Description = "Struct float without sqrt")]
            public void TestFloatStructFWithoutSqrt()
            {
                for (int i = 0; i < N; i++)
                {
                    float ox = Math.Abs(PointStructsF[i, 1].X - PointStructsF[i, 0].X);
                    float oy = Math.Abs(PointStructsF[i, 1].Y - PointStructsF[i, 0].Y);
                    float s = (float)Math.Pow(ox, 2) + (float)Math.Pow(oy, 2);
                }
            }
        }
    }
}
