namespace Performance.NET7.Benchmarks;

[ShortRunJob(RuntimeMoniker.Net60)]
[ShortRunJob(RuntimeMoniker.Net70)]
[RankColumn(NumeralSystem.Arabic)]
[MemoryDiagnoser(displayGenColumns: false)]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class BenchmarkTemplate
{
    [Params(100)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
    }

    [Benchmark]
    public void Benchmark()
    {
    }
}