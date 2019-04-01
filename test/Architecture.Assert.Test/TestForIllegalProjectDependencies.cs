using FluentAssertions;
using Microsoft.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace Architecture.Assert.Test
{
    [Collection("Microservice Solution collection")]
    public class TestForIllegalProjectDependencies
    {
        public TestForIllegalProjectDependencies(MicroserviceSolutionFixture fixture)
        {
            Workspace = fixture.Workspace;
        }

        public Workspace Workspace { get; private set; }

        [Fact]
        public void RepositoryProjects_Should_Not_Reference_Service_Or_Api_Projects()
        {
            var repositoryProjectsRegex = new Regex(@"\.[Rr]epositories", RegexOptions.Compiled);
            var apiProjectsRegex = new Regex(@"\.[Aa]pi", RegexOptions.Compiled);
            var serviceProjectsRegex = new Regex(@"\.[Ss]ervices", RegexOptions.Compiled);

            var repoProjects = Workspace.CurrentSolution.Projects.Where(x => repositoryProjectsRegex.IsMatch(x.AssemblyName));
            var apiProjects = Workspace.CurrentSolution.Projects.Where(x => apiProjectsRegex.IsMatch(x.AssemblyName));
            var serviceProjects = Workspace.CurrentSolution.Projects.Where(x => serviceProjectsRegex.IsMatch(x.AssemblyName));

            repoProjects
                .Should()
                .NotReference(apiProjects)
                .And
                .NotReference(serviceProjects);
        }

        [Fact]
        public void RepositoryAbstractionProjects_Should_Not_Refrence_RepositoryImplementations()
        {
            var repositoryAbstrationProjectsRegex = new Regex(@"\.[Rr]epositories$", RegexOptions.Compiled);
            var implementationRepositoryProjectsRegex = new Regex(@"\.[Rr]epositories\..*$", RegexOptions.Compiled);

            var abstractionProjects = Workspace.CurrentSolution.Projects.Where(x => repositoryAbstrationProjectsRegex.IsMatch(x.AssemblyName));
            var repoImplementationProjects = Workspace.CurrentSolution.Projects.Where(x => implementationRepositoryProjectsRegex.IsMatch(x.AssemblyName));

            abstractionProjects
                .Should()
                .NotReference(repoImplementationProjects);
        }
    }
}
