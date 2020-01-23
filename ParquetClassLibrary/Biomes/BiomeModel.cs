using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Biomes
{
    /// <summary>
    /// Models the biome that a <see cref="Maps.MapRegion"/> embodies.
    /// </summary>
    public sealed class BiomeModel : EntityModel
    {
        #region Characteristics
        /// <summary>
        /// A rating indicating where in the progression this <see cref="BiomeModel"/> falls.
        /// Must be non-negative.  Higher values indicate later Biomes.
        /// </summary>
        public int Tier { get; }

        /// <summary>Describes where this <see cref="BiomeModel"/> falls in terms of the game world's overall topography.</summary>
        public Elevation ElevationCategory { get; }

        /// <summary>Determines whether or not this <see cref="BiomeModel"/> is defined in terms of liquid parquets.</summary>
        public bool IsLiquidBased { get; }

        /// <summary>Describes the parquets that make up this <see cref="BiomeModel"/>.</summary>
        public IReadOnlyList<EntityTag> ParquetCriteria { get; }

        /// <summary>Describes the <see cref="ItemModel"/>s a <see cref="Beings.PlayerCharacterModel"/> needs to safely access this <see cref="BiomeModel"/>.</summary>
        public IReadOnlyList<EntityTag> EntryRequirements { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="BiomeModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="BiomeModel"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="BiomeModel"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="BiomeModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="BiomeModel"/>.</param>
        /// <param name="inTier">A rating indicating where in the progression this <see cref="BiomeModel"/> falls.</param>
        /// <param name="inElevationCategory">Describes where this <see cref="BiomeModel"/> falls in terms of the game world's overall topography.</param>
        /// <param name="inIsLiquidBased">Determines whether or not this <see cref="BiomeModel"/> is defined in terms of liquid parquets.</param>
        /// <param name="inParquetCriteria">Describes the parquets that make up this <see cref="BiomeModel"/>.</param>
        /// <param name="inEntryRequirements">Describes the <see cref="ItemModel"/>s needed to access this <see cref="BiomeModel"/>.</param>
        public BiomeModel(EntityID inID, string inName, string inDescription, string inComment,
                     int inTier, Elevation inElevationCategory,
                     bool inIsLiquidBased, IEnumerable<EntityTag> inParquetCriteria,
                     IEnumerable<EntityTag> inEntryRequirements)
            : base(All.BiomeIDs, inID, inName, inDescription, inComment)
        {
            Precondition.MustBeNonNegative(inTier, nameof(inTier));

            Tier = inTier;
            ElevationCategory = inElevationCategory;
            IsLiquidBased = inIsLiquidBased;
            ParquetCriteria = (inParquetCriteria ?? Enumerable.Empty<EntityTag>()).ToList();
            EntryRequirements = (inEntryRequirements ?? Enumerable.Empty<EntityTag>()).ToList();
        }
        #endregion

        #region Serialization
        #region Serializer Shim
        /// <summary>
        /// Provides a default public parameterless constructor for a
        /// <see cref="BiomeModel"/>-like class that CSVHelper can instantiate.
        /// 
        /// Provides the ability to generate a <see cref="BiomeModel"/> from this class.
        /// </summary>
        internal class BiomeShim : EntityShim
        {
            /// <summary>
            /// A rating indicating where in the progression this <see cref="BiomeModel"/> falls.
            /// Must be non-negative.  Higher values indicate later Biomes.
            /// </summary>
            public int Tier;

            /// <summary>Describes where this <see cref="BiomeModel"/> falls in terms of the game world's overall topography.</summary>
            public Elevation ElevationCategory;

            /// <summary>Determines whether or not this <see cref="BiomeModel"/> is defined in terms of liquid parquets.</summary>
            public bool IsLiquidBased;

            /// <summary>Describes the parquets that make up this <see cref="BiomeModel"/>.</summary>
            public EntityTag ParquetCriteria;
            // TODO public IReadOnlyList<EntityTag> ParquetCriteria;

            /// <summary>Describes the <see cref="Item"/>s a <see cref="Beings.PlayerCharacterModel"/> needs to safely access this <see cref="BiomeModel"/>.
            /// </summary>
            public EntityTag EntryRequirements;
            // TODO public IReadOnlyList<EntityTag> EntryRequirements;

            /// <summary>
            /// Converts a shim into the class it corresponds to.
            /// </summary>
            /// <typeparam name="TModel">The type to convert this shim to.</typeparam>
            /// <returns>An instance of a parquet enity model.</returns>
            public override TModel ToEntity<TModel>()
            {
                Precondition.IsOfType<TModel, BiomeModel>(typeof(TModel).ToString());

                return (TModel)(EntityModel)new BiomeModel(ID, Name, Description, Comment, Tier, ElevationCategory,
                                                           IsLiquidBased, new List<EntityTag>() { ParquetCriteria },
                                                           new List<EntityTag>() { EntryRequirements });
            }
        }
        #endregion

        #region Class Map
        /// <summary>
        /// Maps the values in a <see cref="BiomeShim"/> to records that CSVHelper recognizes.
        /// </summary>
        internal sealed class BiomeClassMap : ClassMap<BiomeShim>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="BiomeClassMap"/> class.
            /// </summary>
            public BiomeClassMap()
            {
                // Properties are ordered by index to facilitate a logical layout in spreadsheet apps.
                Map(m => m.ID).Index(0);
                Map(m => m.Name).Index(1);
                Map(m => m.Description).Index(2);
                Map(m => m.Comment).Index(3);

                Map(m => m.Tier).Index(4);
                Map(m => m.ElevationCategory).Index(5);
                Map(m => m.IsLiquidBased).Index(6);
                Map(m => m.ParquetCriteria).Index(7);
                Map(m => m.EntryRequirements).Index(8);
            }
        }
        #endregion

        /// <summary>Caches a class mapper.</summary>
        private static BiomeClassMap classMapCache;

        /// <summary>
        /// Provides the means to map all members of this class to a CSV file.
        /// </summary>
        /// <returns>The member mapping.</returns>
        internal static ClassMap GetClassMap()
            => classMapCache
            ?? (classMapCache = new BiomeClassMap());

        /// <summary>
        /// Provides the means to map all members of this class to a CSV file.
        /// </summary>
        /// <returns>The member mapping.</returns>
        internal static Type GetShimType()
            => typeof(BiomeShim);
        #endregion
    }
}
