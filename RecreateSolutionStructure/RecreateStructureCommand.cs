using System.CommandLine;

namespace RecreateSolutionStructure;

public class RecreateStructureCommand : RootCommand
{
    public RecreateStructureCommand()
    {
        base.Name = "recreate-sln-structure";
        base.Description = "Recreate solution directory tree, i.e. for use in building a containerized .NET application with cached restore layer\n" +
                           "Takes the path to a solution (.sln) file as input, and moves\n" +
                           "Example: 'recreate-sln-structure MySolution.sln'";
        
        var solutionFileArgument = new Argument<FileInfo>(name: "path to sln", description: "File path to the solution (.sln) file");
        AddArgument(solutionFileArgument);
        this.SetHandler(SolutionDirectoryTreeRecreator.Recreate, solutionFileArgument);
    }
}