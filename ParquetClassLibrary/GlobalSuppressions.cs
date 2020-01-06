// This file is used by Code Analysis to maintain SuppressMessage
// attributes.  Project-level suppressions have no target.

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization",
    "CA1303:Do not pass literals as localized parameters",
    Justification = "Incompatible with nameof().",
    Scope = "namespaceanddescendants", Target = "ParquetClassLibrary")]

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Performance",
    "CA1814:Prefer jagged arrays over multidimensional",
    Justification = "Parquet requires rectangular multidimensional arrays.",
    Scope = "namespaceanddescendants", Target = "ParquetClassLibrary")]

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Usage",
    "CA2225:Operator overloads have named alternates",
    Justification = "This would defeat the purpose of making these classes implicitly interchangeable.",
    Scope = "namespaceanddescendants", Target = "ParquetClassLibrary")]
