using System.CommandLine;

namespace RecreateSolutionStructure;

public class RecreateStructureCommand : RootCommand
{
    public RecreateStructureCommand()
    {
        Description = "Recreate solution directory tree, i.e. for use in building a containerized .NET application with cached restore layer\n" +
                      "Takes the path to a solution (.sln) file as input, and moves\n" +
                      "Example: 'recreate-sln-structure MySolution.sln'";

        var solutionFileArgument = new Argument<FileInfo>("path to sln")
        {
            Description = "File path to the solution (.sln) file",
            Arity = ArgumentArity.ExactlyOne
        };

        var ignoreMissingProjectsOption = new Option<bool>("--ignore-missing-projects", "-i")
        {
            Description = "Ignore missing project files",
            DefaultValueFactory = _ => false,
            Arity = ArgumentArity.ZeroOrOne
        };

        Add(solutionFileArgument);
        Add(ignoreMissingProjectsOption);

        SetAction(result =>
            SolutionDirectoryTreeRecreator.Recreate(result.GetRequiredValue(solutionFileArgument), result.GetValue(ignoreMissingProjectsOption)));
    }
}