using System.CommandLine;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RecreateSolutionStructure.Tests;

public class Tests
{
    public const string FullSln = "../../../TestResources/full";
    public const string MissingProjectSln = "../../../TestResources/missing-project";

    [Test]
    public async Task Success_with_full_sln()
    {
        using var copy = TestDirectory.Create(FullSln);
        var slnPath = copy.GetFilePath("RecreateSolutionStructure.sln");
        var command = new RecreateStructureCommand();
        
        var exitCode = await command.InvokeAsync(slnPath);
        
        Assert.Zero(exitCode);
    }

    [Test]
    public async Task Fails_when_missing_project()
    {
        using var copy = TestDirectory.Create(MissingProjectSln);
        var slnPath = copy.GetFilePath("RecreateSolutionStructure.sln");
        var command = new RecreateStructureCommand();
        
        var exitCode = await command.InvokeAsync(slnPath);
        
        Assert.NotZero(exitCode);
    }

    [Test]
    public async Task Success_when_explicitly_ignoring_missing_projects()
    {
        using var copy = TestDirectory.Create(MissingProjectSln);
        var slnPath = copy.GetFilePath("RecreateSolutionStructure.sln --ignore-missing-projects");
        var command = new RecreateStructureCommand();
        
        var exitCode = await command.InvokeAsync(slnPath);
        
        Assert.Zero(exitCode);
    }
}