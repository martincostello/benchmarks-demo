// Copyright (c) Martin Costello, 2024. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace DotNetBenchmarks;

[MemoryDiagnoser]
public class ILoggerFactoryBenchmarks
{
    private static readonly ILoggerFactory Factory = NullLoggerFactory.Instance;

    [Benchmark(Baseline = true)]
    public ILogger CreateLogger_Generic()
    {
        return Factory.CreateLogger<MyClass>();
    }

    [Benchmark]
    public ILogger CreateLogger_Type()
    {
        return Factory.CreateLogger(typeof(MyClass));
    }

    private sealed class MyClass;
}
