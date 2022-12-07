using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Day6.Tests.Benchmark
{
    public class Benchmark
    {
        private readonly string _dataStream;

        public Benchmark()
        {
            _dataStream = File.ReadAllText("input.txt");
        }

        [Benchmark]
        public void Part1() => Day6.Program.GetStartOfPacketMarker(_dataStream);

        [Benchmark]
        public void Part2() => Day6.Program.GetStartOfMessageMarker(_dataStream);
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmark>();
        }
    }
}