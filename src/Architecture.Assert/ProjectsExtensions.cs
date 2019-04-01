using Buildalyzer;
using FluentAssertions;
using FluentAssertions.Collections;
using FluentAssertions.Execution;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Architecture.Assert
{
    public static class ProjectsExtensions
    {
        public static AndConstraint<GenericCollectionAssertions<T>> NotReference<T>(this GenericCollectionAssertions<T> assertation, IEnumerable<T> projects, string because = "",
            params object[] becauseArgs)
            where T : Project
        {
            var invalidReferenceProjects = assertation
                .Subject
                .Where(x => x.ProjectReferences
                .Any(y => projects.Any(p => p.Id == y.ProjectId)));

            if (invalidReferenceProjects.Any())
            {
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .FailWith("Expected the projects {0} not to reference {1}",
                        string.Join(", ", assertation.Subject.Select(x => x.AssemblyName)),
                        string.Join(", ", projects.Select(x => x.AssemblyName))
                    );
            }

            return new AndConstraint<GenericCollectionAssertions<T>>(assertation);
        }
    }
}
