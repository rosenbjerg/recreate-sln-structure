using System.CommandLine;
using NUnit.Framework;

namespace RecreateSolutionStructure.Tests;

public class Tests
{
    [Test]
    public void CanInvokeWithOnlySln()
    {
        var command = new RecreateStructureCommand();
        var parsed = command.Parse("test.sln");
        Assert.IsEmpty(parsed.Errors);
    }
}