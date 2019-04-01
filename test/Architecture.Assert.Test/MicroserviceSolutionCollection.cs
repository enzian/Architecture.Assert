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

    [CollectionDefinition("Microservice Solution collection")]
    public class MicroserviceSolutionCollection : ICollectionFixture<MicroserviceSolutionFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
