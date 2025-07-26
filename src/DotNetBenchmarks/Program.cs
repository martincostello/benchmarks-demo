// Copyright (c) Martin Costello, 2024. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using BenchmarkDotNet.Running;

var switcher = new BenchmarkSwitcher(typeof(Program).Assembly);

var summary = switcher.Run(args);

return summary.Reports.Any((p) => !p.Success) ? 1 : 0;
