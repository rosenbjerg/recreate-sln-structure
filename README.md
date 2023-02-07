# A dotnet tool for moving project files into the directories specified by the solution (.sln) file

Useful for optimizing cache reuse in containerized .NET builds

```
Description:
Recreate solution directory tree, i.e. for use in building a containerized .NET application with cached restore layer
Takes the path to a solution (.sln) file as input, and moves all project files into their respective folders according to the solution file. Directories are created if necessary
Example: 'recreate-sln-structure MySolution.sln'

Usage:
recreate-solution-directory-tree <path to sln> [options]

Arguments:
<path to sln>  File path to the solution (.sln) file

Options:
--version       Show version information
-?, -h, --help  Show help and usage information
```
