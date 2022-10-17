using Bogus;
using Newtonsoft.Json.Serialization;
using Performance.NET7.Benchmarks.Model;
using System.Text.Json;

namespace Performance.NET7.Benchmarks.Serialization.NewtonsoftVsText;

[RPlotExporter]
[SimpleJob(RuntimeMoniker.Net70, launchCount: 1, warmupCount: 3, targetCount: 5, invocationCount: -1, id: "NET 7.0", baseline: true)]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns(Column.Job, Column.StdDev, Column.Error, Column.RatioSD)]
public class NewtonsoftVsTextDeserializeBenchmarks
{
    [Params(10000)]
    public int Count { get; set; }

private string serializedTestUsers;

private List<string> serializedTestUsersList = new();

[GlobalSetup]
public void GlobalSetup()
{
    var faker = new Faker<User>()
        .CustomInstantiator(f => new User(
            Guid.NewGuid(),
            f.Name.FirstName(),
            f.Name.LastName(),
            f.Name.FullName(),
            f.Internet.UserName(f.Name.FirstName(), f.Name.LastName()),
            f.Internet.Email(f.Name.FirstName(), f.Name.LastName())
        ));

    var testUsers = faker.Generate(Count);

    serializedTestUsers = JsonSerializer.Serialize(testUsers);

    foreach (var user in testUsers.Select(u => JsonSerializer.Serialize(u)))
    {
        serializedTestUsersList.Add(user);
    }
}

    [Benchmark]
    public void NewtonsoftDeserializeBigData() =>
        _ = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(serializedTestUsers);

    [Benchmark]
    public void MicrosoftDeserializeBigData() =>
        _ = System.Text.Json.JsonSerializer.Deserialize<List<User>>(serializedTestUsers);

    [Benchmark]
    public void NewtonsoftDeserializeMuchData()
    {
        foreach (var user in serializedTestUsersList)
        {
            _ = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(user);
        }
    }

    [Benchmark]
    public void MicrosoftDeserializeMuchData()
    {
        foreach (var user in serializedTestUsersList)
        {
            _ = System.Text.Json.JsonSerializer.Deserialize<User>(user);
        }
    }
}