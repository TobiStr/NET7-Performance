namespace Performance.NET7.Benchmarks.IO.WriteAllText;

[RPlotExporter]
[SimpleJob(RuntimeMoniker.Net60, launchCount: 1, warmupCount: 3, targetCount: 5, invocationCount: -1, id: "NET 6.0")]
[SimpleJob(RuntimeMoniker.Net70, launchCount: 1, warmupCount: 3, targetCount: 5, invocationCount: -1, id: "NET 7.0", baseline: true)]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns(Column.Job, Column.StdDev, Column.Error, Column.RatioSD, Column.AllocRatio)]
public class WriteAllTextBenchmark
{
    private string path;

    private string content;

    [GlobalSetup]
    public void Setup()
    {
        path = Path.GetRandomFileName();
        content = string.Join(";", Enumerable.Range(0, 1000));
    }

    [GlobalCleanup]
    public void Cleanup() => File.Delete(path);

    [Benchmark]
    public void WriteAllText() => File.WriteAllText(path, content);
}