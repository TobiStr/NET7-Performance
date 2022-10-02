namespace Performance.NET7.Benchmarks.LINQ.Order;

[RPlotExporter]
[SimpleJob(RuntimeMoniker.Net70, launchCount: 1, warmupCount: 3, targetCount: 5, invocationCount: -1, id: "NET 7.0", baseline: true)]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns(Column.Job, Column.StdDev, Column.Error, Column.RatioSD, Column.AllocRatio)]
public class OrderBenchmarks
{
    [Params(1000)]
    public int Length { get; set; }

    private double[] arr;

    [GlobalSetup]
    public void GlobalSetup()
    {
        var random = new Random();
        arr = Enumerable
            .Range(0, Length)
            .Select(_ => random.NextDouble())
            .ToArray();
    }

    [Benchmark]
    public double[] OrderBy() => arr.OrderBy(d => d).ToArray();

#if NET7_0
    [Benchmark]
    public double[] Order() => arr.Order().ToArray();
#endif
}