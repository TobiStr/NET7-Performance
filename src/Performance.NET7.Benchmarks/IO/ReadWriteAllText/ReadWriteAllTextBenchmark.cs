namespace Performance.NET7.Benchmarks.IO.ReadWriteAllText;

[RPlotExporter]
[SimpleJob(RuntimeMoniker.Net60, launchCount: 1, warmupCount: 3, targetCount: 5, invocationCount: -1, id: "NET 6.0")]
[SimpleJob(RuntimeMoniker.Net70, launchCount: 1, warmupCount: 3, targetCount: 5, invocationCount: -1, id: "NET 7.0", baseline: true)]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns(Column.Job, Column.StdDev, Column.Error, Column.RatioSD)]
public class ReadWriteAllTextBenchmark
{
    private string path1;

    private string path2;

    private string content;

    [GlobalSetup]
    public void Setup()
    {
        path1 = Path.GetRandomFileName();
        path2 = Path.GetRandomFileName();
        content = string.Join(";", Enumerable.Range(0, 1000));

        File.WriteAllText(path2, content);
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        File.Delete(path1);
        File.Delete(path2);
    }

    [Benchmark]
    public void WriteAllText() => File.WriteAllText(path1, content);

    [Benchmark]
    public string ReadAllText() => File.ReadAllText(path2);
}