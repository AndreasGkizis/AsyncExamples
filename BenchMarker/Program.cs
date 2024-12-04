using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

public class Program
{
	static async Task Main(string[] args)
	{
		// Run benchmarks
		BenchmarkRunner.Run<BenchmarkTests>();
	}

	[MemoryDiagnoser]
	[SimpleJob(RuntimeMoniker.Net60)]
	[SimpleJob(RuntimeMoniker.Net80)]
	// [SimpleJob(RuntimeMoniker.Net90)]
	[IterationCount(10)]
	public class BenchmarkTests
	{
		[Benchmark]
		public async Task ConfigureAwaitFalseBenchmark() => await ConfigureAwait.Program.ConfigureAwaitFalse();

		[Benchmark]
		public async Task SimpleAwaitBenchmark() => await ConfigureAwait.Program.SimpleAwait();

		[Benchmark]
		public async Task ConfigureAwaitTrueBenchmark() => await ConfigureAwait.Program.ConfigureAwaitTrue();
	}
}