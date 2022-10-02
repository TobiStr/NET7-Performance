namespace Performance.NET7.Benchmarks;

[RPlotExporter]
[SimpleJob(RuntimeMoniker.Net60, launchCount: 1, warmupCount: 3, targetCount: 5, invocationCount: -1, id: "NET 6.0")]
[SimpleJob(RuntimeMoniker.Net70, launchCount: 1, warmupCount: 3, targetCount: 5, invocationCount: -1, id: "NET 7.0", baseline: true)]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns(Column.Job, Column.StdDev, Column.Error, Column.RatioSD, Column.AllocRatio)]
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