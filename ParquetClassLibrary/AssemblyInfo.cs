using System;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ParquetClassLibrary;

// Set assembly values.
[assembly: AssemblyTitle("Parquet Class Library")]
[assembly: AssemblyDescription("Core game mechanics for Parquet.")]
[assembly: AssemblyCompany("Queertet")]
[assembly: AssemblyCopyright("2018-2019 Paige Ashlynn")]
[assembly: AssemblyProduct("ParquetClassLibrary")]
[assembly: AssemblyVersion(AssemblyInfo.LibraryVersion)]
[assembly: AssemblyInformationalVersion(AssemblyInfo.LibraryVersion)]
[assembly: AssemblyFileVersion(AssemblyInfo.LibraryVersion)]

// Make no promises to maintain public services.
[assembly: ComVisible(false)]

// Declare American English as the coding language.
[assembly: NeutralResourcesLanguage("en-US")]

// Show warnings on CLS-noncompliant statements to better support .NET languages other than C#.
[assembly: CLSCompliant(true)]

// Allow unit tests to access classes and members with internal accessibility.
[assembly: InternalsVisibleTo("ParquetUnitTests")]

namespace ParquetClassLibrary
{
    /// <summary>
    /// Provides assembly-wide information.
    /// </summary>
    public struct AssemblyInfo
    {
        /// <summary>
        /// Describes the version of the serialized <see cref="Map.MapParent"/>
        /// data that the class library understands.
        /// </summary>
        /// <remarks>
        /// The version has the format "{Major}.{Minor}.{Build}".
        /// - Major ⇒ Breaking changes resulting in lost saves.
        /// - Minor ⇒ Backwards-compatible changes, preserving existing saves.
        /// - Build ⇒ Procedural updates that do not imply any changes.
        /// </remarks>
        public const string SupportedMapDataVersion = "0.1.0";

        /// <summary>
        /// Describes the version of the serialized <see cref="Characters.PlayerCharacter"/>
        /// data that the class library understands.
        /// </summary>
        /// <remarks>
        /// The version has the format "{Major}.{Minor}.{Build}".
        /// - Major ⇒ Breaking changes resulting in lost saves.
        /// - Minor ⇒ Backwards-compatible changes, preserving existing saves.
        /// - Build ⇒ Procedural updates that do not imply any changes.
        /// </remarks>
        public const string SupportedBeingDataVersion = "0.1.0";

        /// <summary>Describes the version of the class library itself.</summary>
        /// <remarks>
        /// The version has the format "{Major}.{Minor}.{Patch}.{Build}".
        /// - Major ⇒ Enhancements or fixes that break the API or its serialized data.
        /// - Minor ⇒ Enhancements that do not break the API or its serialized data.
        /// - Patch ⇒ Fixes that do not break the API or its serialized data.
        /// - Build ⇒ Procedural updates that do not imply any changes, such as when rebuilding for APK/IPA submission.
        /// </remarks>
        public const string LibraryVersion = "0.1.0.0";
    }
}
