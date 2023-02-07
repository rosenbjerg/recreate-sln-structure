# A dotnet tool for moving project files into the directories specified by the solution (.sln) file

Useful for optimizing cache reuse in containerized .NET builds

```
Description:
  Recreate solution directory tree, i.e. for use in building a containerized .NET application with cached restore layer
  Takes the path to a solution (.sln) file as input, and moves
  Example: 'recreate-solution-directory-tree MySolution.sln'

Usage:
  recreate-sln-structure <path to sln> [options]

Arguments:
  <path to sln>  File path to the solution (.sln) file

Options:
  --version       Show version information
  -?, -h, --help  Show help and usage information
```
