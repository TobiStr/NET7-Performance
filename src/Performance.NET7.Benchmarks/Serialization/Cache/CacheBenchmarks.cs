using System.Text.Json;

namespace Performance.NET7.Benchmarks.Serialization.Cache;

[RPlotExporter]
[SimpleJob(RuntimeMoniker.Net60, launchCount: 1, warmupCount: 3, targetCount: 5, invocationCount: -1, id: "NET 6.0")]
[SimpleJob(RuntimeMoniker.Net70, launchCount: 1, warmupCount: 3, targetCount: 5, invocationCount: -1, id: "NET 7.0", baseline: true)]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns(Column.Job, Column.StdDev, Column.Error, Column.RatioSD)]
public class CacheBenchmarks
{
    private JsonSerializerOptions options = new JsonSerializerOptions();
    private TestClass instance = new TestClass("Test");

    [Benchmark(Baseline = true)]
    public string Default() => JsonSerializer.Serialize(instance);

    [Benchmark]
    public string CachedOptions() => JsonSerializer.Serialize(instance, options);

    [Benchmark]
    public string NoCachedOptions() => JsonSerializer.Serialize(instance, new JsonSerializerOptions());

    public record TestClass(string Test);
}