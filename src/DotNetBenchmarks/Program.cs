// Copyright (c) Martin Costello, 2024. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using BenchmarkDotNet.Running;

var switcher = new BenchmarkSwitcher(typeof(Program).Assembly);

var results = switcher.Run(args);

return results.Any((p) => p.Reports.Any((r) => !r.Success) ? 1 : 0;
