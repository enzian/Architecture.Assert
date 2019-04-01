using Buildalyzer;
using Buildalyzer.Workspaces;
using FluentAssertions;
using Microsoft.CodeAnalysis;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace Architecture.Assert.Test
{

    public class MicroserviceSolutionFixture : IDisposable
    {
        public MicroserviceSolutionFixture()
        {
            Workspace = new AdhocWorkspace().PopulateFromSolution(@"..\..\..\..\..\samples\Microservice\Microservice.sln");
        }

        public Workspace Workspace { get; private set; }

        public void Dispose()
        {
            Workspace.Dispose();
        }

    }
}
