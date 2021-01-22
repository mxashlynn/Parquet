using System.Diagnostics.CodeAnalysis;
// This file is used by Code Analysis to maintain SuppressMessage
// attributes.  Project-level suppressions have no target.

[assembly: SuppressMessage("Performance", "CA1814:Prefer jagged arrays over multidimensional",
                           Justification = "Parquet requires rectangular multidimensional arrays.",
                           Scope = "namespaceanddescendants", Target = "~N:ParquetClassLibrary")]

[assembly: SuppressMessage("Usage", "CA2225:Operator overloads have named alternates",
                           Justification = "This would defeat the purpose of making these classes implicitly interchangeable.",
                           Scope = "namespaceanddescendants", Target = "~N:ParquetClassLibrary")]

[assembly: SuppressMessage("Naming", "CA1725:Parameter names should match base declaration",
                           Justification = "This rule inhibits clarity as items are refered to in generic terms when specific terms are available.  (For example, calling a Model an Object.)",
                           Scope = "namespaceanddescendants", Target = "~N:ParquetClassLibrary")]
