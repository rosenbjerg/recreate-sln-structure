using System.CommandLine;
using RecreateSolutionStructure;

var recreateStructureCommand = new RecreateStructureCommand();
return await recreateStructureCommand.InvokeAsync(args);