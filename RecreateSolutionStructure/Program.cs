using System.CommandLine;
using RecreateSolutionStructure;

var solutionFileArgument = new Argument<FileInfo>(name: "path to sln", description: "File path to the solution (.sln) file");
var rootCommand = new RootCommand("Recreate solution directory tree, i.e. for use in building a containerized .NET application with cached restore layer\n" +
                                  "Takes the path to a solution (.sln) file as input, and moves\n" +
                                  "Example: 'recreate-solution-directory-tree MySolution.sln'") { Name = "recreate-solution-directory-tree" };
rootCommand.AddArgument(solutionFileArgument);
rootCommand.SetHandler(SolutionDirectoryTreeRecreator.Recreate, solutionFileArgument);

return await rootCommand.InvokeAsync(args);