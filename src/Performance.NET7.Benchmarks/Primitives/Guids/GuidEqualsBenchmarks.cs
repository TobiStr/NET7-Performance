namespace Performance.NET7.Benchmarks.Primitives.Guids;

[RPlotExporter]
[SimpleJob(RuntimeMoniker.Net60, launchCount: 1, warmupCount: 3, targetCount: 5, invocationCount: -1, id: "NET 6.0")]
[SimpleJob(RuntimeMoniker.Net70, launchCount: 1, warmupCount: 3, targetCount: 5, invocationCount: -1, id: "NET 7.0", baseline: true)]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns(Column.Job, Column.StdDev, Column.Error, Column.RatioSD, Column.AllocRatio)]
public class GuidEqualsBenchmarks
{
    private Guid guid0 = Guid.Parse("18a2c952-2920-4750-844b-2007cb6fd42d");
    private Guid guid1 = Guid.Parse("18a2c952-2920-4750-844b-2007cb6fd42d");

    [Benchmark]
    public bool GuidEquals() => guid0 == guid1;
}