# Benchmarks Demo

[![Build status][build-badge]][build-status] [![Benchmarks status][benchmark-badge]][benchmark-status]

## Introduction

Demonstrates continuous benchmarking in GitHub Actions using [BenchmarkDotNet][benchmarkdotnet]
and [martincostello/benchmarkdotnet-results-publisher][benchmarkdotnet-results-publisher].

## How it works

This project contains a [few different examples][benchmark-code] of BenchmarkDotNet microbenchmarks.

The project is configured to run benchmarks on every push to the `main` branch using GitHub Actions,
as well as every weekday at 0100 UTC, via the `benchmark.ps1` PowerShell script.

Running the script will build the project and run the benchmarks. The results are written to the
`BenchmarkDotNet.Artifacts` directory in the root of the repository. These results are then published
to another repository, [martincostello/benchmarks][benchmark-repo], by the [benchmarkdotnet-results-publisher] action.

The results are then viewable in [a GitHub Pages site][benchmark-site] deployed from that repository
that consumes the data to view trends over time.

## Feedback

Any feedback or issues can be added to the issues for this project in [GitHub][issues].

## Repository

The repository is hosted in [GitHub][repo]: <https://github.com/martincostello/benchmarks-demo.git>

## License

This project is licensed under the [Apache 2.0][license] license.

[benchmarkdotnet]: https://github.com/dotnet/BenchmarkDotNet
[benchmarkdotnet-results-publisher]: https://github.com/martincostello/benchmarkdotnet-results-publisher
[benchmark-badge]: https://github.com/martincostello/benchmarks-demo/actions/workflows/benchmark.yml/badge.svg?branch=main&event=push
[benchmark-code]: https://github.com/martincostello/benchmarks-demo/tree/main/src/DotNetBenchmarks
[benchmark-repo]: https://github.com/martincostello/benchmarks/tree/main/benchmarks-demo
[benchmark-site]: https://benchmarks.martincostello.com/?repo=benchmarks-demo&branch=main
[benchmark-status]: https://github.com/martincostello/benchmarks-demo/actions?query=workflow%3Abenchmark+branch%3Amain+event%3Apush "Continuous benchmarks for this project"
[build-badge]: https://github.com/martincostello/benchmarks-demo/actions/workflows/build.yml/badge.svg?branch=main&event=push
[build-status]: https://github.com/martincostello/benchmarks-demo/actions?query=workflow%3Abuild+branch%3Amain+event%3Apush "Continuous integration for this project"
[issues]: https://github.com/martincostello/benchmarks-demo/issues "Issues for this project on GitHub.com"
[license]: https://www.apache.org/licenses/LICENSE-2.0.txt "The Apache 2.0 license"
[repo]: https://github.com/martincostello/benchmarks-demo "This project on GitHub.com"
