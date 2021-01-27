// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Style", "IDE0022:Use expression body for methods",
                           Justification = "I think it's better to use full blocks when it comes to unit tests.",
                           Scope = "namespaceanddescendants", Target = "~N:ParquetUnitTests")]
