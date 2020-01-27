using System;
using System.Collections.Generic;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Beings
{
    /// <summary>
    /// Models the definition for a simple in-game actor, such as a friendly mob with limited interaction.
    /// </summary>
    public sealed class CritterModel : BeingModel, ITypeConverter
    {
        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="CritterModel"/> class.
        /// </summary>
        /// <param name="inID">
        /// Unique identifier for the <see cref="CritterModel"/>.  Cannot be null.
        /// Must be a <see cref="All.CritterIDs"/>.
        /// </param>
        /// <param name="inName">Player-friendly name of the <see cref="CritterModel"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="CritterModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="CritterModel"/>.</param>
        /// <param name="inNativeBiome">The <see cref="BiomeModel"/> in which this <see cref="CritterModel"/> is most comfortable.</param>
        /// <param name="inPrimaryBehavior">The rules that govern how this <see cref="CritterModel"/> acts.  Cannot be null.</param>
        /// <param name="inAvoids">Any parquets this <see cref="CritterModel"/> avoids.</param>
        /// <param name="inSeeks">Any parquets this <see cref="CritterModel"/> seeks.</param>
        public CritterModel(EntityID inID, string inName, string inDescription, string inComment,
                            EntityID inNativeBiome, Behavior inPrimaryBehavior,
                            IEnumerable<EntityID> inAvoids = null, IEnumerable<EntityID> inSeeks = null)
            : base(All.CritterIDs, inID, inName, inDescription, inComment, inNativeBiome, inPrimaryBehavior, inAvoids, inSeeks)
        {
            Precondition.IsInRange(inID, All.CritterIDs, nameof(inID));
        }
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself without exposing a public parameterless constructor.</summary>
        internal static readonly CritterModel ConverterFactory =
            new CritterModel(EntityID.None, nameof(ConverterFactory), "", "", "", EntityID.None, Behavior.Still);

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="value">The instance to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
        }

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="text">The text to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
        }
        #endregion
    }
}
