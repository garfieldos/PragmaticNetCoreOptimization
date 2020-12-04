using System.Buffers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmarks.ArrayPool
{
    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    public class RentReturn_vs_allocate
    {
        [Params(100,1_000,50_000,84_000,85_000, 100_000, 200_000)]
        public int ArrayLength { get; set; }

        private ArrayPool<byte> _pool;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _pool = ArrayPool<byte>.Shared;
        }

        [Benchmark]
        public void RendAndReturn()
        {
            var array = _pool.Rent(ArrayLength);
            _pool.Return(array);
        }

        [Benchmark]
        public void Allocate()
        {
            var array = new byte[ArrayLength];
        }
    }
}