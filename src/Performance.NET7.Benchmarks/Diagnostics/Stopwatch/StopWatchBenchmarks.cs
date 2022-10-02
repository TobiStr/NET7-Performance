using System.Diagnostics;

namespace Performance.NET7.Benchmarks.Diagnostics.StopwatchPerformance;

[RPlotExporter]
[SimpleJob(RuntimeMoniker.Net70, launchCount: 1, warmupCount: 3, targetCount: 5, invocationCount: -1, id: "NET 7.0", baseline: true)]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns(Column.Job, Column.StdDev, Column.Error, Column.RatioSD)]
public class StopWatchBenchmarks
{
    [Benchmark(Baseline = true)]
    public TimeSpan OldStopwatch()
    {
        Stopwatch sw = Stopwatch.StartNew();
        return sw.Elapsed;
    }

#if NET7_0
    [Benchmark]
    public TimeSpan NewStopwatch()
    {
        long timestamp = Stopwatch.GetTimestamp();
        return Stopwatch.GetElapsedTime(timestamp);
    }
#endif
}