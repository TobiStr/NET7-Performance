namespace Performance.NET7.Benchmarks.IO.DirectoryMove;

[RPlotExporter]
[SimpleJob(RuntimeMoniker.Net60, launchCount: 1, warmupCount: 3, targetCount: 5, invocationCount: -1, id: "NET 6.0")]
[SimpleJob(RuntimeMoniker.Net70, launchCount: 1, warmupCount: 3, targetCount: 5, invocationCount: -1, id: "NET 7.0", baseline: true)]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns(Column.Job, Column.StdDev, Column.Error, Column.RatioSD, Column.AllocRatio)]
public class DirectoryMoveBenchmarks
{
    private string path1;

    private string path2;

    [GlobalSetup]
    public void Setup()
    {
        path1 = Path.GetTempFileName();
        path2 = Path.GetTempFileName();
        File.Delete(path2);
        Directory.CreateDirectory(path1);
    }

    [Benchmark]
    public void Move()
    {
        Directory.Move(path1, path2);
    }
}