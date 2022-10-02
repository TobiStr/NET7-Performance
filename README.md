# NET Performance Series
Repository to accompany my .NET Performance Series Articles on medium.com

## How to run

To run Benchmarks in a certain namespace or by name, simply run:

```
dotnet run -c Release --framework net6.0 net7.0 --filter *<filter>*
```

and replace '<filter>' with a part of the name or namespace. If applicable, you might need to remove **net6.0** from this line.