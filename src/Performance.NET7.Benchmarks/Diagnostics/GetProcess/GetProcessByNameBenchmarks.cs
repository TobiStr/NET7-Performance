using System.Diagnostics;

namespace Performance.NET7.Benchmarks.Diagnostics.GetProcess;

[RPlotExporter]
[SimpleJob(RuntimeMoniker.Net60, launchCount: 1, warmupCount: 3, targetCount: 5, invocationCount: -1, id: "NET 6.0")]
[SimpleJob(RuntimeMoniker.Net70, launchCount: 1, warmupCount: 3, targetCount: 5, invocationCount: -1, id: "NET 7.0", baseline: true)]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns(Column.Job, Column.StdDev, Column.Error, Column.RatioSD)]
public class GetProcessByNameBenchmarks
{
    [Benchmark]
    public Process[] GetProcessByName()
        => Process.GetProcessesByName("dotnet.exe");
}