// Copyright (c) Martin Costello, 2024. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using BenchmarkDotNet.Running;
using DotNetBenchmarks;

Type[] benchmarks =
[
    typeof(HashBenchmarks),
    typeof(ILoggerFactoryBenchmarks),
    typeof(IndexOfAnyBenchmarks),
];

var switcher = new BenchmarkSwitcher(benchmarks);
switcher.Run(args);
