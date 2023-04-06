using Microsoft.Build.Construction;

namespace RecreateSolutionStructure;

public class SolutionDirectoryTreeRecreator
{
    public static void Recreate(FileInfo solutionFile, bool ignoreMissingProjects)
    {
        var solution = SolutionFile.Parse(solutionFile.FullName);
        var solutionDirectory = solutionFile.Directory!.FullName;
        foreach (var project in solution.ProjectsInOrder)
        {
            if (project.ProjectType == SolutionProjectType.SolutionFolder)
                continue;

            var destinationPath = Path.Combine(solutionDirectory, Path.GetRelativePath(solutionDirectory, Path.GetFullPath(project.AbsolutePath)));
            var projectName = Path.GetFileName(destinationPath);
            var currentPath = Path.Combine(solutionDirectory, projectName);

            var relativeDestinationPath = Path.GetRelativePath(".", destinationPath);
            var relativeCurrentPath = Path.GetRelativePath(".", currentPath);

            if (File.Exists(destinationPath))
            {
                Console.WriteLine($"Skipping - {relativeDestinationPath} already exists");
            }
            else if (File.Exists(currentPath))
            {
                var directoryTree = Path.GetDirectoryName(destinationPath)!;
                Directory.CreateDirectory(directoryTree);
                File.Move(currentPath, destinationPath);
                Console.WriteLine($"{relativeCurrentPath} moved to {relativeDestinationPath}");
            }
            else if (!ignoreMissingProjects)
            {
                throw new FileNotFoundException(currentPath);
            }
        }
    }
}