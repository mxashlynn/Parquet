// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Naming",
    "CA1707:Identifiers should not contain underscores",
    Justification = "Conflicts with project style.",
    Scope = "namespaceanddescendants", Target = "ParquetClassLibrary")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization",
    "CA1303:Do not pass literals as localized parameters",
    Justification = "Incompatible with nameof().",
    Scope = "namespaceanddescendants", Target = "ParquetClassLibrary")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Performance",
    "CA1814:Prefer jagged arrays over multidimensional",
    Justification = "Parquet requires rectangular multidimensional arrays.",
    Scope = "namespaceanddescendants", Target = "ParquetClassLibrary")]

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Performance",
    "CA1815:Override equals and operator equals on value types",
    Justification = "Comparing two AssemblyInfos is nonsensical.",
    Scope = "type", Target = "~T:ParquetClassLibrary.AssemblyInfo")]
