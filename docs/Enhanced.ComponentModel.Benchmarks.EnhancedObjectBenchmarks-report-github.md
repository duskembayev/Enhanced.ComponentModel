``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1440 (1909/November2018Update/19H2)
Intel Core i7-9700K CPU 3.60GHz (Coffee Lake), 1 CPU, 8 logical and 8 physical cores
.NET Core SDK=5.0.201
  [Host]     : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT
  DefaultJob : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT


```
|           Method |       Mean |     Error |    StdDev |        Min |        Max |     Median | Ratio |
|----------------- |-----------:|----------:|----------:|-----------:|-----------:|-----------:|------:|
|  RegularGetValue |  58.476 ns | 0.0034 ns | 0.0030 ns |  58.469 ns |  58.480 ns |  58.476 ns |  1.00 |
| EnhancedGetValue |   2.837 ns | 0.0143 ns | 0.0127 ns |   2.815 ns |   2.850 ns |   2.844 ns |  0.05 |
|                  |            |           |           |            |            |            |       |
|  RegularSetValue | 168.688 ns | 1.2438 ns | 1.1634 ns | 167.455 ns | 170.549 ns | 167.960 ns |  1.00 |
| EnhancedSetValue |   6.795 ns | 0.0510 ns | 0.0477 ns |   6.748 ns |   6.873 ns |   6.763 ns |  0.04 |
