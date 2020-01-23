using System;
using System.Collections.Generic;
using CsvHelper.Configuration;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Beings
{
    /// <summary>
    /// Models the definition for a simple in-game actor, such as a friendly mob with limited interaction.
    /// </summary>
    public sealed class CritterModel : BeingModel
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

        #region Serialization
        #region Serializer Shim
        /// <summary>
        /// Provides a default public parameterless constructor for a
        /// <see cref="CritterModel"/>-like class that CSVHelper can instantiate.
        /// 
        /// Provides the ability to generate a <see cref="CritterModel"/> from this class.
        /// </summary>
        internal class CritterShim : Serialization.Shims.BeingShim
        {
            /// <summary>
            /// Converts a shim into the class it corresponds to.
            /// </summary>
            /// <typeparam name="TModel">The type to convert this shim to.</typeparam>
            /// <returns>An instance of a child class of <see cref="BeingModel"/>.</returns>
            public override TModel ToEntity<TModel>()
            {
                Precondition.IsOfType<TModel, CritterModel>(typeof(TModel).ToString());

                return (TModel)(EntityModel)new CritterModel(ID, Name, Description, Comment, NativeBiome, PrimaryBehavior,
                                                             new List<EntityID>() { Avoids }, new List<EntityID>() { Seeks });
            }
        }
        #endregion

        #region Class Map
        /// <summary>
        /// Maps the values in a <see cref="CritterShim"/> to records that CSVHelper recognizes.
        /// </summary>
        internal sealed class CritterClassMap : ClassMap<CritterShim>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="CritterClassMap"/> class.
            /// </summary>
            public CritterClassMap()
            {
                // Properties are ordered by index to facilitate a logical layout in spreadsheet apps.
                Map(m => m.ID).Index(0);
                Map(m => m.Name).Index(1);
                Map(m => m.Description).Index(2);
                Map(m => m.Comment).Index(3);

                Map(m => m.NativeBiome).Index(4);
                Map(m => m.PrimaryBehavior).Index(5);
                Map(m => m.Avoids).Index(6);
                Map(m => m.Seeks).Index(7);
            }
        }
        #endregion

        /// <summary>Caches a class mapper.</summary>
        private static CritterClassMap classMapCache;

        /// <summary>
        /// Provides the means to map all members of this class to a CSV file.
        /// </summary>
        /// <returns>The member mapping.</returns>
        internal static ClassMap GetClassMap()
            => classMapCache
            ?? (classMapCache = new CritterClassMap());

        /// <summary>
        /// Provides the means to map all members of this class to a CSV file.
        /// </summary>
        /// <returns>The member mapping.</returns>
        internal static Type GetShimType()
            => typeof(CritterShim);
        #endregion
    }
}
