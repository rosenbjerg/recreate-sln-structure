using System;
using System.IO;

namespace RecreateSolutionStructure.Tests;

public sealed class TestDirectory : IDisposable
{
    private readonly string _tempDirectory;

    private TestDirectory(string tempDirectory)
    {
        _tempDirectory = tempDirectory;
    }

    public void Dispose()
    {
        if (Directory.Exists(_tempDirectory)) Directory.Delete(_tempDirectory, true);
    }

    public string GetFilePath(string fileName)
    {
        return Path.Combine(_tempDirectory, fileName);
    }

    public static TestDirectory Create(string inputDirectory)
    {
        var tempDirectory = Path.Combine(Path.GetTempPath(), $"unittest-{Guid.NewGuid()}");
        Directory.CreateDirectory(tempDirectory);
        var files = Directory.EnumerateFiles(inputDirectory);
        foreach (var inputPath in files)
        {
            var outputPath = Path.Combine(tempDirectory, Path.GetFileName(inputPath));
            File.Copy(inputPath, outputPath);
        }

        return new TestDirectory(tempDirectory);
    }
}