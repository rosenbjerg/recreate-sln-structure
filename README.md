# A dotnet tool for moving project files into the directories specified by the solution (.sln) file

[![NuGet Badge](https://img.shields.io/nuget/v/RecreateSolutionStructure)](https://www.nuget.org/packages/RecreateSolutionStructure/)
[![codecov](https://codecov.io/gh/rosenbjerg/recreate-sln-structure/branch/main/graph/badge.svg)](https://codecov.io/gh/rosenbjerg/recreate-sln-structure)

Useful for optimizing cache reuse in containerized .NET builds

## Usage example

```dockerfile
COPY ["MySolution.sln", "**/*.csproj", "./"]
RUN recreate-sln-structure MySolution.sln && dotnet restore MySolution.sln
```

## Help

```
Description:
  Recreate solution directory tree, i.e. for use in building a containerized .NET application with cached restore layer
  Takes the path to a solution (.sln) file as input, and moves
  Example: 'recreate-sln-structure MySolution.sln'

Usage:
  recreate-sln-structure <path to sln> [options]

Arguments:
  <path to sln>  File path to the solution (.sln) file

Options:
  -i, --ignore-missing-projects  Ignore missing project files [default: False]
  --version                      Show version information
  -?, -h, --help                 Show help and usage information
```
