using RecreateSolutionStructure;

var rootCommand = new RecreateStructureCommand();
var parsed = rootCommand.Parse(args);
return await parsed.InvokeAsync();