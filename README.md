# `dotnet watch` silently fails when `launchSettings.json` contains a comment

This is a minimal reproduction of a bug in .NET.

## Expected behaviour

The application is configured to print an environment variable called `MyVariable`. Since this variable is defined as `"Hello world"` in `launchSettings.json`, it is expected to print `Hello world` when run with either `dotnet run` or `dotnet watch run`.

## Actual behaviour

The application runs as-expected when run with `dotnet run`. When run using `dotnet watch run` the application prints an empty string and runs with default configuration (even if you specify `dotnet watch run --launch-profile http`) because the launch profile is not used. This seems to be because `dotnet watch` cannot parse `launchSettings.json` because it contains a comment. Despite this, no errors or warnings are logged. This is inconsistent with the behaviour of `dotnet run` which _does_ tolerate comments (as explicitly added in [#11860](https://github.com/dotnet/cli/pull/11860)).