``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1440 (1909/November2018Update/19H2)
Intel Core i7-9700K CPU 3.60GHz (Coffee Lake), 1 CPU, 8 logical and 8 physical cores
.NET Core SDK=5.0.201
  [Host]     : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT
  DefaultJob : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT


```
|                   Method |       Mean |     Error |    StdDev |        Min |        Max |     Median | Ratio |
|------------------------- |-----------:|----------:|----------:|-----------:|-----------:|-----------:|------:|
|  Regular_GetValue_String |  58.832 ns | 0.0616 ns | 0.0546 ns |  58.735 ns |  58.922 ns |  58.826 ns |  1.00 |
| Enhanced_GetValue_String |   2.903 ns | 0.0035 ns | 0.0031 ns |   2.898 ns |   2.909 ns |   2.903 ns |  0.05 |
|                          |            |           |           |            |            |            |       |
|  Regular_SetValue_String | 165.952 ns | 1.1949 ns | 0.9978 ns | 164.399 ns | 167.964 ns | 166.150 ns |  1.00 |
| Enhanced_SetValue_String |   6.293 ns | 0.0312 ns | 0.0260 ns |   6.240 ns |   6.317 ns |   6.305 ns |  0.04 |
|                          |            |           |           |            |            |            |       |
|     Regular_GetValue_Int |  76.682 ns | 0.0436 ns | 0.0386 ns |  76.600 ns |  76.725 ns |  76.693 ns |  1.00 |
|    Enhanced_GetValue_Int |   4.758 ns | 0.0181 ns | 0.0170 ns |   4.721 ns |   4.789 ns |   4.757 ns |  0.06 |
|                          |            |           |           |            |            |            |       |
|     Regular_SetValue_Int | 172.237 ns | 0.1051 ns | 0.0821 ns | 172.100 ns | 172.377 ns | 172.244 ns |  1.00 |
|    Enhanced_SetValue_Int |   7.084 ns | 0.0216 ns | 0.0169 ns |   7.052 ns |   7.111 ns |   7.085 ns |  0.04 |
