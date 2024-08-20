// Copyright (c) Martin Costello, 2024. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

namespace DotNetBenchmarks;

[MemoryDiagnoser]
public class HashBenchmarks
{
    private readonly byte[] _buffer;

    public HashBenchmarks()
    {
        _buffer = new byte[10_000];
        RandomNumberGenerator.Fill(_buffer);
    }

    [Benchmark(Baseline = true)]
    public byte[] Sha256ComputeHash()
    {
        using var hash = SHA256.Create();
        return hash.ComputeHash(_buffer);
    }

    [Benchmark]
    public byte[] Sha256HashData()
    {
        return SHA256.HashData(_buffer);
    }
}
