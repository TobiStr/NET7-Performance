namespace Performance.NET7.Benchmarks.LINQ.AverageSum;

[RPlotExporter]
[SimpleJob(RuntimeMoniker.Net60, launchCount: 1, warmupCount: 3, targetCount: 5, invocationCount: -1, id: "NET 6.0")]
[SimpleJob(RuntimeMoniker.Net70, launchCount: 1, warmupCount: 3, targetCount: 5, invocationCount: -1, id: "NET 7.0", baseline: true)]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns(Column.Job, Column.StdDev, Column.Error, Column.RatioSD, Column.AllocRatio)]
public class AverageSumBenchmarks
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
    public double Average() => arr.Average();

    [Benchmark]
    public double Sum() => arr.Sum();
}