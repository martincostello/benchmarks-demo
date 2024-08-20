// Copyright (c) Martin Costello, 2024. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

namespace DotNetBenchmarks;

[MemoryDiagnoser]
public class IndexOfAnyBenchmarks
{
    private const string AUrlWithAPathAndQueryString = "http://www.example.com/path/to/file.html?query=string";
    private static readonly char[] QueryStringAndFragmentTokens = ['?', '#'];

    [Benchmark(Baseline = true)]
    public int IndexOfAny_String()
    {
        return AUrlWithAPathAndQueryString.IndexOfAny(QueryStringAndFragmentTokens);
    }

    [Benchmark]
    public int IndexOfAny_Span_Array()
    {
        return AUrlWithAPathAndQueryString.AsSpan().IndexOfAny(QueryStringAndFragmentTokens);
    }

    [Benchmark]
    public int IndexOfAny_Span_Two_Chars()
    {
        return AUrlWithAPathAndQueryString.AsSpan().IndexOfAny('?', '#');
    }
}
