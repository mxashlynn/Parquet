using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Parquets;

namespace ParquetClassLibrary.Rooms
{
    /// <summary>
    /// Models the minimum requirements for a <see cref="Room"/> to be recognizable and useful.
    /// </summary>
    public sealed class RoomRecipe : EntityModel, ITypeConverter
    {
        #region Characteristics
        /// <summary>Minimum number of open spaces needed for this <see cref="RoomRecipe"/> to register.</summary>
        public int MinimumWalkableSpaces { get; }

        /// <summary>A list of <see cref="Parquets.FurnishingModel"/> categories this <see cref="RoomRecipe"/> requires.</summary>
        public IReadOnlyList<RecipeElement> RequiredFurnishings { get; }

        /// <summary>An optional list of <see cref="Parquets.FloorModel"/> categories this <see cref="RoomRecipe"/> requires.</summary>
        public IReadOnlyList<RecipeElement> RequiredFloors { get; }

        /// <summary>An optional list of <see cref="Parquets.BlockModel"/> categories this <see cref="RoomRecipe"/> requires as walls.</summary>
        public IReadOnlyList<RecipeElement> RequiredPerimeterBlocks { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomRecipe"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="RoomRecipe"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="RoomRecipe"/>.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="RoomRecipe"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="RoomRecipe"/>.</param>
        /// <param name="inMinimumWalkableSpaces">The minimum number of walkable <see cref="MapSpace"/>s required by this <see cref="RoomRecipe"/>.</param>
        /// <param name="inOptionallyRequiredFurnishings">An optional list of furnishing categories this <see cref="RoomRecipe"/> requires.</param>
        /// <param name="inOptionallyRequiredWalkableFloors">An optional list of floor categories this <see cref="RoomRecipe"/> requires.</param>
        /// <param name="inOptionallyRequiredPerimeterBlocks">An optional list of block categories this <see cref="RoomRecipe"/> requires as walls.</param>
        public RoomRecipe(EntityID inID, string inName, string inDescription, string inComment,
                          int inMinimumWalkableSpaces = Rules.Recipes.Room.MinWalkableSpaces,
                          IEnumerable<RecipeElement> inOptionallyRequiredFurnishings = null,
                          IEnumerable<RecipeElement> inOptionallyRequiredWalkableFloors = null,
                          IEnumerable<RecipeElement> inOptionallyRequiredPerimeterBlocks = null)
            : base(All.RoomRecipeIDs, inID, inName, inDescription, inComment)
        {
            if (inMinimumWalkableSpaces < Rules.Recipes.Room.MinWalkableSpaces
                || inMinimumWalkableSpaces > Rules.Recipes.Room.MaxWalkableSpaces)
            {
                throw new ArgumentOutOfRangeException(nameof(inMinimumWalkableSpaces));
            }

            MinimumWalkableSpaces = inMinimumWalkableSpaces;
            RequiredFurnishings = inOptionallyRequiredFurnishings.ToList() ?? Enumerable.Empty<RecipeElement>().ToList();
            RequiredFloors = inOptionallyRequiredWalkableFloors.ToList() ?? Enumerable.Empty<RecipeElement>().ToList();
            RequiredPerimeterBlocks = inOptionallyRequiredPerimeterBlocks.ToList() ?? Enumerable.Empty<RecipeElement>().ToList();
        }
        #endregion

        #region Derived Details
        /// A measure of the stringency of this <see cref="RoomRecipe"/>'s requirements.
        /// If a <see cref="Room"/> corresponds to multiple recipes' requirements,
        /// the room is asigned the type of the most demanding recipe.
        /// </summary>
        public int Priority
            => RequiredFloors.Count + RequiredPerimeterBlocks.Count + RequiredFurnishings.Count + MinimumWalkableSpaces;

        /// <summary>
        /// Determines if the given <see cref="Room"/> conforms to this <see cref="RoomRecipe"/>.
        /// </summary>
        /// <param name="inRoom">The <see cref="Room"/> to check.</param>
        /// <returns>
        /// <c>ture</c> if <paramref name="inRoom"/> is an instance of this <see cref="RoomRecipe"/>;
        /// <c>false</c> otherwise.
        /// </returns>
        public bool Matches(Room inRoom)
            => null != inRoom
            && inRoom.WalkableArea.Count >= MinimumWalkableSpaces
            && RequiredPerimeterBlocks.All(element =>
                inRoom.Perimeter.Count(space =>
                    All.Parquets.Get<BlockModel>(space.Content.Block).AddsToRoom == element.ElementTag) >= element.ElementAmount)
            && RequiredFloors.All(element =>
                inRoom.WalkableArea.Count(space =>
                    All.Parquets.Get<FloorModel>(space.Content.Floor).AddsToRoom == element.ElementTag) >= element.ElementAmount)
            && RequiredFurnishings.All(element =>
                inRoom.FurnishingTags.Count(tag =>
                    tag == element.ElementTag) >= element.ElementAmount);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static readonly RoomRecipe ConverterFactory = new RoomRecipe(EntityID.None, nameof(ConverterFactory), "", "");

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => null != inValue
            && inValue is RoomRecipe recipe
                ? $"{recipe.ID}{Rules.Delimiters.InternalDelimiter}" +
                  $"{recipe.Name}{Rules.Delimiters.InternalDelimiter}" +
                  $"{recipe.Description}{Rules.Delimiters.InternalDelimiter}" +
                  $"{recipe.Comment}{Rules.Delimiters.InternalDelimiter}" +
                  $"{recipe.MinimumWalkableSpaces}{Rules.Delimiters.InternalDelimiter}" +
                  $"{SeriesConverter<RecipeElement, List<RecipeElement>>.ConverterFactory.ConvertToString(recipe.RequiredFurnishings, inRow, inMemberMapData)}" +
                  $"{Rules.Delimiters.InternalDelimiter}" +
                  $"{SeriesConverter<RecipeElement, List<RecipeElement>>.ConverterFactory.ConvertToString(recipe.RequiredFloors, inRow, inMemberMapData)}" +
                  $"{Rules.Delimiters.InternalDelimiter}" +
                  $"{SeriesConverter<RecipeElement, List<RecipeElement>>.ConverterFactory.ConvertToString(recipe.RequiredPerimeterBlocks, inRow, inMemberMapData)}"
                : throw new ArgumentException($"Could not serialize {inValue} as {nameof(RoomRecipe)}.");

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="inText">The text to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            if (string.IsNullOrEmpty(inText))
            {
                throw new ArgumentException($"Could not convert '{inText}' to {nameof(RoomRecipe)}.");
            }

            try
            {
                var numberStyle = inMemberMapData?.TypeConverterOptions?.NumberStyle ?? Serializer.SerializedNumberStyle;
                var cultureInfo = inMemberMapData?.TypeConverterOptions?.CultureInfo ?? Serializer.SerializedCultureInfo;
                var parameterText = inText.Split(Rules.Delimiters.InternalDelimiter);

                var id = (EntityID)EntityID.ConverterFactory.ConvertFromString(parameterText[0], inRow, inMemberMapData);
                var name = parameterText[1];
                var description = parameterText[2];
                var comment = parameterText[3];
                var walkable = int.Parse(parameterText[4], numberStyle, cultureInfo);
                var furnishings = (IReadOnlyList<RecipeElement>)SeriesConverter<RecipeElement, List<RecipeElement>>.ConverterFactory
                    .ConvertFromString(parameterText[5], inRow, inMemberMapData);
                var floors = (IReadOnlyList<RecipeElement>)SeriesConverter<RecipeElement, List<RecipeElement>>.ConverterFactory
                    .ConvertFromString(parameterText[6], inRow, inMemberMapData);
                var perimiter = (IReadOnlyList<RecipeElement>)SeriesConverter<RecipeElement, List<RecipeElement>>.ConverterFactory
                    .ConvertFromString(parameterText[7], inRow, inMemberMapData);

                return new RoomRecipe(id, name, description, comment, walkable, furnishings, floors, perimiter);
            }
            catch (Exception e)
            {
                throw new FormatException($"Could not parse '{inText}' as {nameof(RoomRecipe)}: {e}");
            }
        }
        #endregion
    }
}
