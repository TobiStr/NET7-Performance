using System.Numerics;

namespace Performance.NET7.Benchmarks.Primitives.Parsing;

[RPlotExporter]
[SimpleJob(RuntimeMoniker.Net60, launchCount: 1, warmupCount: 3, targetCount: 5, invocationCount: -1, id: "NET 6.0")]
[SimpleJob(RuntimeMoniker.Net70, launchCount: 1, warmupCount: 3, targetCount: 5, invocationCount: -1, id: "NET 7.0", baseline: true)]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns(Column.Job, Column.StdDev, Column.Error, Column.RatioSD, Column.AllocRatio)]
public class ParseBenchmarks
{
    private string bigIntString = string.Concat(Enumerable.Repeat("123456789", 100000));

    [Benchmark]
    public BigInteger ParseBigInt() => BigInteger.Parse(bigIntString);

    [Benchmark]
    public bool ParseBool() => bool.TryParse("True", out _);
}