using Buildalyzer;
using Buildalyzer.Workspaces;
using Microsoft.CodeAnalysis;
using System.IO;

namespace Architecture.Assert
{
    public static class TestSolutionWorkspace
    {
        public static AdhocWorkspace PopulateFromSolution(this AdhocWorkspace subject, string solutionFilePath)
        {
            var solutionPath = solutionFilePath;

            if (!Path.IsPathRooted(solutionFilePath))
            {
                solutionPath = Path.Combine(Directory.GetCurrentDirectory(), solutionFilePath);
            }

            var analysis = new AnalyzerManager(solutionPath);
            foreach (var project in analysis.Projects)
            {
                project.Value.AddToWorkspace(subject);
            }

            return subject;
        }
    }
}
