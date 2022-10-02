namespace Performance.NET7.Benchmarks.LINQ.MinMax;

[RPlotExporter]
[SimpleJob(RuntimeMoniker.Net60, launchCount: 1, warmupCount: 3, targetCount: 5, invocationCount: -1, id: "NET 6.0")]
[SimpleJob(RuntimeMoniker.Net70, launchCount: 1, warmupCount: 3, targetCount: 5, invocationCount: -1, id: "NET 7.0", baseline: true)]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns(Column.Job, Column.StdDev, Column.Error, Column.RatioSD, Column.AllocRatio)]
public class MinMaxBenchmarks
{
    [Params(1000)]
    public int Length { get; set; }

    private int[] arr;

    [GlobalSetup]
    public void GlobalSetup() => arr = Enumerable.Range(0, Length).ToArray();

    [Benchmark]
    public int Min() => arr.Min();

    [Benchmark]
    public int Max() => arr.Max();
}