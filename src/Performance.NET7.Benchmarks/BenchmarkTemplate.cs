namespace Performance.NET7.Benchmarks;

[RPlotExporter]
[RankColumn(NumeralSystem.Arabic)]
[ShortRunJob(RuntimeMoniker.Net60)]
[ShortRunJob(RuntimeMoniker.Net70)]
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