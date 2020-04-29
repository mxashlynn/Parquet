<a name='assembly'></a>
# ParquetClassLibrary

## Contents

- [All](#T-ParquetClassLibrary-All 'ParquetClassLibrary.All')
  - [BeingIDs](#F-ParquetClassLibrary-All-BeingIDs 'ParquetClassLibrary.All.BeingIDs')
  - [BiomeIDs](#F-ParquetClassLibrary-All-BiomeIDs 'ParquetClassLibrary.All.BiomeIDs')
  - [BlockIDs](#F-ParquetClassLibrary-All-BlockIDs 'ParquetClassLibrary.All.BlockIDs')
  - [CharacterIDs](#F-ParquetClassLibrary-All-CharacterIDs 'ParquetClassLibrary.All.CharacterIDs')
  - [CollectibleIDs](#F-ParquetClassLibrary-All-CollectibleIDs 'ParquetClassLibrary.All.CollectibleIDs')
  - [CraftingRecipeIDs](#F-ParquetClassLibrary-All-CraftingRecipeIDs 'ParquetClassLibrary.All.CraftingRecipeIDs')
  - [CritterIDs](#F-ParquetClassLibrary-All-CritterIDs 'ParquetClassLibrary.All.CritterIDs')
  - [FloorIDs](#F-ParquetClassLibrary-All-FloorIDs 'ParquetClassLibrary.All.FloorIDs')
  - [FurnishingIDs](#F-ParquetClassLibrary-All-FurnishingIDs 'ParquetClassLibrary.All.FurnishingIDs')
  - [InteractionIDs](#F-ParquetClassLibrary-All-InteractionIDs 'ParquetClassLibrary.All.InteractionIDs')
  - [ItemIDs](#F-ParquetClassLibrary-All-ItemIDs 'ParquetClassLibrary.All.ItemIDs')
  - [MapChunkIDs](#F-ParquetClassLibrary-All-MapChunkIDs 'ParquetClassLibrary.All.MapChunkIDs')
  - [MapIDs](#F-ParquetClassLibrary-All-MapIDs 'ParquetClassLibrary.All.MapIDs')
  - [MapRegionIDs](#F-ParquetClassLibrary-All-MapRegionIDs 'ParquetClassLibrary.All.MapRegionIDs')
  - [ParquetIDs](#F-ParquetClassLibrary-All-ParquetIDs 'ParquetClassLibrary.All.ParquetIDs')
  - [PlayerIDs](#F-ParquetClassLibrary-All-PlayerIDs 'ParquetClassLibrary.All.PlayerIDs')
  - [RoomRecipeIDs](#F-ParquetClassLibrary-All-RoomRecipeIDs 'ParquetClassLibrary.All.RoomRecipeIDs')
  - [ScriptIDs](#F-ParquetClassLibrary-All-ScriptIDs 'ParquetClassLibrary.All.ScriptIDs')
  - [SerializedNumberStyle](#F-ParquetClassLibrary-All-SerializedNumberStyle 'ParquetClassLibrary.All.SerializedNumberStyle')
  - [Beings](#P-ParquetClassLibrary-All-Beings 'ParquetClassLibrary.All.Beings')
  - [Biomes](#P-ParquetClassLibrary-All-Biomes 'ParquetClassLibrary.All.Biomes')
  - [CollectionsHaveBeenInitialized](#P-ParquetClassLibrary-All-CollectionsHaveBeenInitialized 'ParquetClassLibrary.All.CollectionsHaveBeenInitialized')
  - [ConversionConverters](#P-ParquetClassLibrary-All-ConversionConverters 'ParquetClassLibrary.All.ConversionConverters')
  - [CraftingRecipes](#P-ParquetClassLibrary-All-CraftingRecipes 'ParquetClassLibrary.All.CraftingRecipes')
  - [IdentifierOptions](#P-ParquetClassLibrary-All-IdentifierOptions 'ParquetClassLibrary.All.IdentifierOptions')
  - [Interactions](#P-ParquetClassLibrary-All-Interactions 'ParquetClassLibrary.All.Interactions')
  - [Items](#P-ParquetClassLibrary-All-Items 'ParquetClassLibrary.All.Items')
  - [Maps](#P-ParquetClassLibrary-All-Maps 'ParquetClassLibrary.All.Maps')
  - [Parquets](#P-ParquetClassLibrary-All-Parquets 'ParquetClassLibrary.All.Parquets')
  - [PronounGroups](#P-ParquetClassLibrary-All-PronounGroups 'ParquetClassLibrary.All.PronounGroups')
  - [RoomRecipes](#P-ParquetClassLibrary-All-RoomRecipes 'ParquetClassLibrary.All.RoomRecipes')
  - [Scripts](#P-ParquetClassLibrary-All-Scripts 'ParquetClassLibrary.All.Scripts')
  - [SerializedCultureInfo](#P-ParquetClassLibrary-All-SerializedCultureInfo 'ParquetClassLibrary.All.SerializedCultureInfo')
  - [WorkingDirectory](#P-ParquetClassLibrary-All-WorkingDirectory 'ParquetClassLibrary.All.WorkingDirectory')
  - [#cctor()](#M-ParquetClassLibrary-All-#cctor 'ParquetClassLibrary.All.#cctor')
  - [InitializeCollections(inPronouns,inBeings,inBiomes,inCraftingRecipes,inInteractions,inMaps,inParquets,inRoomRecipes,inScripts,inItems)](#M-ParquetClassLibrary-All-InitializeCollections-System-Collections-Generic-IEnumerable{ParquetClassLibrary-Beings-PronounGroup},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Beings-BeingModel},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Biomes-BiomeModel},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Crafts-CraftingRecipe},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Scripts-InteractionModel},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Maps-MapModel},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Parquets-ParquetModel},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Rooms-RoomRecipe},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Scripts-ScriptModel},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Items-ItemModel}- 'ParquetClassLibrary.All.InitializeCollections(System.Collections.Generic.IEnumerable{ParquetClassLibrary.Beings.PronounGroup},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Beings.BeingModel},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Biomes.BiomeModel},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Crafts.CraftingRecipe},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Scripts.InteractionModel},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Maps.MapModel},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Parquets.ParquetModel},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Rooms.RoomRecipe},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Scripts.ScriptModel},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Items.ItemModel})')
  - [LoadFromCSVs()](#M-ParquetClassLibrary-All-LoadFromCSVs 'ParquetClassLibrary.All.LoadFromCSVs')
  - [SaveToCSVs()](#M-ParquetClassLibrary-All-SaveToCSVs 'ParquetClassLibrary.All.SaveToCSVs')
- [AssemblyInfo](#T-ParquetClassLibrary-AssemblyInfo 'ParquetClassLibrary.AssemblyInfo')
  - [LibraryVersion](#F-ParquetClassLibrary-AssemblyInfo-LibraryVersion 'ParquetClassLibrary.AssemblyInfo.LibraryVersion')
  - [SupportedBeingDataVersion](#F-ParquetClassLibrary-AssemblyInfo-SupportedBeingDataVersion 'ParquetClassLibrary.AssemblyInfo.SupportedBeingDataVersion')
  - [SupportedMapDataVersion](#F-ParquetClassLibrary-AssemblyInfo-SupportedMapDataVersion 'ParquetClassLibrary.AssemblyInfo.SupportedMapDataVersion')
  - [SupportedScriptDataVersion](#F-ParquetClassLibrary-AssemblyInfo-SupportedScriptDataVersion 'ParquetClassLibrary.AssemblyInfo.SupportedScriptDataVersion')
- [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel')
  - [#ctor(inBounds,inID,inName,inDescription,inComment,inNativeBiome,inPrimaryBehavior,inAvoids,inSeeks)](#M-ParquetClassLibrary-Beings-BeingModel-#ctor-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},ParquetClassLibrary-ModelID,System-String,System-String,System-String,ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID,System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID}- 'ParquetClassLibrary.Beings.BeingModel.#ctor(ParquetClassLibrary.Range{ParquetClassLibrary.ModelID},ParquetClassLibrary.ModelID,System.String,System.String,System.String,ParquetClassLibrary.ModelID,ParquetClassLibrary.ModelID,System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID},System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID})')
  - [Avoids](#P-ParquetClassLibrary-Beings-BeingModel-Avoids 'ParquetClassLibrary.Beings.BeingModel.Avoids')
  - [NativeBiome](#P-ParquetClassLibrary-Beings-BeingModel-NativeBiome 'ParquetClassLibrary.Beings.BeingModel.NativeBiome')
  - [PrimaryBehavior](#P-ParquetClassLibrary-Beings-BeingModel-PrimaryBehavior 'ParquetClassLibrary.Beings.BeingModel.PrimaryBehavior')
  - [Seeks](#P-ParquetClassLibrary-Beings-BeingModel-Seeks 'ParquetClassLibrary.Beings.BeingModel.Seeks')
- [BeingStatus](#T-ParquetClassLibrary-Beings-BeingStatus 'ParquetClassLibrary.Beings.BeingStatus')
  - [#ctor(inBeingDefinition,inPosition,inSpawnAt,inCurrentBehavior,inBiomeTimeRemaining,inBuildingSpeed,inModificationSpeed,inGatheringSpeed,inMovementSpeed,inKnownBeings,inKnownParquets,inKnownRoomRecipes,inKnownCraftingRecipes,inQuests,inInventory)](#M-ParquetClassLibrary-Beings-BeingStatus-#ctor-ParquetClassLibrary-Beings-BeingModel,ParquetClassLibrary-ModelID,ParquetClassLibrary-Location,ParquetClassLibrary-Location,System-Int32,System-Single,System-Single,System-Single,System-Single,System-Collections-Generic-List{ParquetClassLibrary-ModelID},System-Collections-Generic-List{ParquetClassLibrary-ModelID},System-Collections-Generic-List{ParquetClassLibrary-ModelID},System-Collections-Generic-List{ParquetClassLibrary-ModelID},System-Collections-Generic-List{ParquetClassLibrary-ModelID},System-Collections-Generic-List{ParquetClassLibrary-ModelID}- 'ParquetClassLibrary.Beings.BeingStatus.#ctor(ParquetClassLibrary.Beings.BeingModel,ParquetClassLibrary.ModelID,ParquetClassLibrary.Location,ParquetClassLibrary.Location,System.Int32,System.Single,System.Single,System.Single,System.Single,System.Collections.Generic.List{ParquetClassLibrary.ModelID},System.Collections.Generic.List{ParquetClassLibrary.ModelID},System.Collections.Generic.List{ParquetClassLibrary.ModelID},System.Collections.Generic.List{ParquetClassLibrary.ModelID},System.Collections.Generic.List{ParquetClassLibrary.ModelID},System.Collections.Generic.List{ParquetClassLibrary.ModelID})')
  - [BeingDefinition](#P-ParquetClassLibrary-Beings-BeingStatus-BeingDefinition 'ParquetClassLibrary.Beings.BeingStatus.BeingDefinition')
  - [BiomeTimeRemaining](#P-ParquetClassLibrary-Beings-BeingStatus-BiomeTimeRemaining 'ParquetClassLibrary.Beings.BeingStatus.BiomeTimeRemaining')
  - [BuildingSpeed](#P-ParquetClassLibrary-Beings-BeingStatus-BuildingSpeed 'ParquetClassLibrary.Beings.BeingStatus.BuildingSpeed')
  - [CurrentBehavior](#P-ParquetClassLibrary-Beings-BeingStatus-CurrentBehavior 'ParquetClassLibrary.Beings.BeingStatus.CurrentBehavior')
  - [DataVersion](#P-ParquetClassLibrary-Beings-BeingStatus-DataVersion 'ParquetClassLibrary.Beings.BeingStatus.DataVersion')
  - [GatheringSpeed](#P-ParquetClassLibrary-Beings-BeingStatus-GatheringSpeed 'ParquetClassLibrary.Beings.BeingStatus.GatheringSpeed')
  - [Inventory](#P-ParquetClassLibrary-Beings-BeingStatus-Inventory 'ParquetClassLibrary.Beings.BeingStatus.Inventory')
  - [KnownBeings](#P-ParquetClassLibrary-Beings-BeingStatus-KnownBeings 'ParquetClassLibrary.Beings.BeingStatus.KnownBeings')
  - [KnownCraftingRecipes](#P-ParquetClassLibrary-Beings-BeingStatus-KnownCraftingRecipes 'ParquetClassLibrary.Beings.BeingStatus.KnownCraftingRecipes')
  - [KnownParquets](#P-ParquetClassLibrary-Beings-BeingStatus-KnownParquets 'ParquetClassLibrary.Beings.BeingStatus.KnownParquets')
  - [KnownRoomRecipes](#P-ParquetClassLibrary-Beings-BeingStatus-KnownRoomRecipes 'ParquetClassLibrary.Beings.BeingStatus.KnownRoomRecipes')
  - [ModificationSpeed](#P-ParquetClassLibrary-Beings-BeingStatus-ModificationSpeed 'ParquetClassLibrary.Beings.BeingStatus.ModificationSpeed')
  - [MovementSpeed](#P-ParquetClassLibrary-Beings-BeingStatus-MovementSpeed 'ParquetClassLibrary.Beings.BeingStatus.MovementSpeed')
  - [Position](#P-ParquetClassLibrary-Beings-BeingStatus-Position 'ParquetClassLibrary.Beings.BeingStatus.Position')
  - [Quests](#P-ParquetClassLibrary-Beings-BeingStatus-Quests 'ParquetClassLibrary.Beings.BeingStatus.Quests')
  - [Revision](#P-ParquetClassLibrary-Beings-BeingStatus-Revision 'ParquetClassLibrary.Beings.BeingStatus.Revision')
  - [RoomAssignment](#P-ParquetClassLibrary-Beings-BeingStatus-RoomAssignment 'ParquetClassLibrary.Beings.BeingStatus.RoomAssignment')
  - [SpawnAt](#P-ParquetClassLibrary-Beings-BeingStatus-SpawnAt 'ParquetClassLibrary.Beings.BeingStatus.SpawnAt')
  - [ToString()](#M-ParquetClassLibrary-Beings-BeingStatus-ToString 'ParquetClassLibrary.Beings.BeingStatus.ToString')
- [BiomeCriteria](#T-ParquetClassLibrary-Rules-BiomeCriteria 'ParquetClassLibrary.Rules.BiomeCriteria')
  - [FluidThreshold](#F-ParquetClassLibrary-Rules-BiomeCriteria-FluidThreshold 'ParquetClassLibrary.Rules.BiomeCriteria.FluidThreshold')
  - [LandThreshold](#F-ParquetClassLibrary-Rules-BiomeCriteria-LandThreshold 'ParquetClassLibrary.Rules.BiomeCriteria.LandThreshold')
  - [ParquetsPerLayer](#F-ParquetClassLibrary-Rules-BiomeCriteria-ParquetsPerLayer 'ParquetClassLibrary.Rules.BiomeCriteria.ParquetsPerLayer')
- [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel')
  - [#ctor(inID,inName,inDescription,inComment,inTier,inElevationCategory,inIsLiquidBased,inParquetCriteria,inEntryRequirements)](#M-ParquetClassLibrary-Biomes-BiomeModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Int32,ParquetClassLibrary-Biomes-Elevation,System-Boolean,System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag}- 'ParquetClassLibrary.Biomes.BiomeModel.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.Int32,ParquetClassLibrary.Biomes.Elevation,System.Boolean,System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag},System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag})')
  - [ElevationCategory](#P-ParquetClassLibrary-Biomes-BiomeModel-ElevationCategory 'ParquetClassLibrary.Biomes.BiomeModel.ElevationCategory')
  - [EntryRequirements](#P-ParquetClassLibrary-Biomes-BiomeModel-EntryRequirements 'ParquetClassLibrary.Biomes.BiomeModel.EntryRequirements')
  - [IsLiquidBased](#P-ParquetClassLibrary-Biomes-BiomeModel-IsLiquidBased 'ParquetClassLibrary.Biomes.BiomeModel.IsLiquidBased')
  - [ParquetCriteria](#P-ParquetClassLibrary-Biomes-BiomeModel-ParquetCriteria 'ParquetClassLibrary.Biomes.BiomeModel.ParquetCriteria')
  - [Tier](#P-ParquetClassLibrary-Biomes-BiomeModel-Tier 'ParquetClassLibrary.Biomes.BiomeModel.Tier')
  - [GetAllTags()](#M-ParquetClassLibrary-Biomes-BiomeModel-GetAllTags 'ParquetClassLibrary.Biomes.BiomeModel.GetAllTags')
- [BlockModel](#T-ParquetClassLibrary-Parquets-BlockModel 'ParquetClassLibrary.Parquets.BlockModel')
  - [#ctor(inID,inName,inDescription,inComment,inItemID,inAddsToBiome,inAddsToRoom,inGatherTool,inGatherEffect,inCollectibleID,inIsFlammable,inIsLiquid,inMaxToughness)](#M-ParquetClassLibrary-Parquets-BlockModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Nullable{ParquetClassLibrary-ModelID},ParquetClassLibrary-ModelTag,ParquetClassLibrary-ModelTag,ParquetClassLibrary-Items-GatheringTool,ParquetClassLibrary-Parquets-GatheringEffect,System-Nullable{ParquetClassLibrary-ModelID},System-Boolean,System-Boolean,System-Int32- 'ParquetClassLibrary.Parquets.BlockModel.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.Nullable{ParquetClassLibrary.ModelID},ParquetClassLibrary.ModelTag,ParquetClassLibrary.ModelTag,ParquetClassLibrary.Items.GatheringTool,ParquetClassLibrary.Parquets.GatheringEffect,System.Nullable{ParquetClassLibrary.ModelID},System.Boolean,System.Boolean,System.Int32)')
  - [DefaultMaxToughness](#F-ParquetClassLibrary-Parquets-BlockModel-DefaultMaxToughness 'ParquetClassLibrary.Parquets.BlockModel.DefaultMaxToughness')
  - [LowestPossibleToughness](#F-ParquetClassLibrary-Parquets-BlockModel-LowestPossibleToughness 'ParquetClassLibrary.Parquets.BlockModel.LowestPossibleToughness')
  - [Bounds](#P-ParquetClassLibrary-Parquets-BlockModel-Bounds 'ParquetClassLibrary.Parquets.BlockModel.Bounds')
  - [CollectibleID](#P-ParquetClassLibrary-Parquets-BlockModel-CollectibleID 'ParquetClassLibrary.Parquets.BlockModel.CollectibleID')
  - [GatherEffect](#P-ParquetClassLibrary-Parquets-BlockModel-GatherEffect 'ParquetClassLibrary.Parquets.BlockModel.GatherEffect')
  - [GatherTool](#P-ParquetClassLibrary-Parquets-BlockModel-GatherTool 'ParquetClassLibrary.Parquets.BlockModel.GatherTool')
  - [IsFlammable](#P-ParquetClassLibrary-Parquets-BlockModel-IsFlammable 'ParquetClassLibrary.Parquets.BlockModel.IsFlammable')
  - [IsLiquid](#P-ParquetClassLibrary-Parquets-BlockModel-IsLiquid 'ParquetClassLibrary.Parquets.BlockModel.IsLiquid')
  - [MaxToughness](#P-ParquetClassLibrary-Parquets-BlockModel-MaxToughness 'ParquetClassLibrary.Parquets.BlockModel.MaxToughness')
- [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel')
  - [#ctor(inID,inName,inDescription,inComment,inNativeBiome,inPrimaryBehavior,inAvoids,inSeeks,inPronouns,inStoryCharacterID,inStartingQuests,inStartingDialogue,inStartingInventory)](#M-ParquetClassLibrary-Beings-CharacterModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID,System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-String,System-String,System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID}- 'ParquetClassLibrary.Beings.CharacterModel.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,ParquetClassLibrary.ModelID,ParquetClassLibrary.ModelID,System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID},System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID},System.String,System.String,System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID},System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID},System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID})')
  - [FamilyName](#P-ParquetClassLibrary-Beings-CharacterModel-FamilyName 'ParquetClassLibrary.Beings.CharacterModel.FamilyName')
  - [PersonalName](#P-ParquetClassLibrary-Beings-CharacterModel-PersonalName 'ParquetClassLibrary.Beings.CharacterModel.PersonalName')
  - [Pronouns](#P-ParquetClassLibrary-Beings-CharacterModel-Pronouns 'ParquetClassLibrary.Beings.CharacterModel.Pronouns')
  - [StartingDialogue](#P-ParquetClassLibrary-Beings-CharacterModel-StartingDialogue 'ParquetClassLibrary.Beings.CharacterModel.StartingDialogue')
  - [StartingInventory](#P-ParquetClassLibrary-Beings-CharacterModel-StartingInventory 'ParquetClassLibrary.Beings.CharacterModel.StartingInventory')
  - [StartingQuests](#P-ParquetClassLibrary-Beings-CharacterModel-StartingQuests 'ParquetClassLibrary.Beings.CharacterModel.StartingQuests')
  - [StoryCharacterID](#P-ParquetClassLibrary-Beings-CharacterModel-StoryCharacterID 'ParquetClassLibrary.Beings.CharacterModel.StoryCharacterID')
- [ChunkTopography](#T-ParquetClassLibrary-Maps-ChunkTopography 'ParquetClassLibrary.Maps.ChunkTopography')
  - [Central](#F-ParquetClassLibrary-Maps-ChunkTopography-Central 'ParquetClassLibrary.Maps.ChunkTopography.Central')
  - [Clustered](#F-ParquetClassLibrary-Maps-ChunkTopography-Clustered 'ParquetClassLibrary.Maps.ChunkTopography.Clustered')
  - [East](#F-ParquetClassLibrary-Maps-ChunkTopography-East 'ParquetClassLibrary.Maps.ChunkTopography.East')
  - [Empty](#F-ParquetClassLibrary-Maps-ChunkTopography-Empty 'ParquetClassLibrary.Maps.ChunkTopography.Empty')
  - [North](#F-ParquetClassLibrary-Maps-ChunkTopography-North 'ParquetClassLibrary.Maps.ChunkTopography.North')
  - [NorthEast](#F-ParquetClassLibrary-Maps-ChunkTopography-NorthEast 'ParquetClassLibrary.Maps.ChunkTopography.NorthEast')
  - [NorthWest](#F-ParquetClassLibrary-Maps-ChunkTopography-NorthWest 'ParquetClassLibrary.Maps.ChunkTopography.NorthWest')
  - [Scattered](#F-ParquetClassLibrary-Maps-ChunkTopography-Scattered 'ParquetClassLibrary.Maps.ChunkTopography.Scattered')
  - [Solid](#F-ParquetClassLibrary-Maps-ChunkTopography-Solid 'ParquetClassLibrary.Maps.ChunkTopography.Solid')
  - [South](#F-ParquetClassLibrary-Maps-ChunkTopography-South 'ParquetClassLibrary.Maps.ChunkTopography.South')
  - [SouthEast](#F-ParquetClassLibrary-Maps-ChunkTopography-SouthEast 'ParquetClassLibrary.Maps.ChunkTopography.SouthEast')
  - [SouthWest](#F-ParquetClassLibrary-Maps-ChunkTopography-SouthWest 'ParquetClassLibrary.Maps.ChunkTopography.SouthWest')
  - [West](#F-ParquetClassLibrary-Maps-ChunkTopography-West 'ParquetClassLibrary.Maps.ChunkTopography.West')
- [ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType')
  - [#ctor()](#M-ParquetClassLibrary-Maps-ChunkType-#ctor 'ParquetClassLibrary.Maps.ChunkType.#ctor')
  - [#ctor(inIsHandmade)](#M-ParquetClassLibrary-Maps-ChunkType-#ctor-System-Boolean- 'ParquetClassLibrary.Maps.ChunkType.#ctor(System.Boolean)')
  - [#ctor(inBaseTopography,inBaseComposition,inModifierTopography,inModifierComposition)](#M-ParquetClassLibrary-Maps-ChunkType-#ctor-ParquetClassLibrary-Maps-ChunkTopography,ParquetClassLibrary-ModelTag,ParquetClassLibrary-Maps-ChunkTopography,ParquetClassLibrary-ModelTag- 'ParquetClassLibrary.Maps.ChunkType.#ctor(ParquetClassLibrary.Maps.ChunkTopography,ParquetClassLibrary.ModelTag,ParquetClassLibrary.Maps.ChunkTopography,ParquetClassLibrary.ModelTag)')
  - [Empty](#F-ParquetClassLibrary-Maps-ChunkType-Empty 'ParquetClassLibrary.Maps.ChunkType.Empty')
  - [BaseComposition](#P-ParquetClassLibrary-Maps-ChunkType-BaseComposition 'ParquetClassLibrary.Maps.ChunkType.BaseComposition')
  - [BaseTopography](#P-ParquetClassLibrary-Maps-ChunkType-BaseTopography 'ParquetClassLibrary.Maps.ChunkType.BaseTopography')
  - [ConverterFactory](#P-ParquetClassLibrary-Maps-ChunkType-ConverterFactory 'ParquetClassLibrary.Maps.ChunkType.ConverterFactory')
  - [Handmade](#P-ParquetClassLibrary-Maps-ChunkType-Handmade 'ParquetClassLibrary.Maps.ChunkType.Handmade')
  - [ModifierComposition](#P-ParquetClassLibrary-Maps-ChunkType-ModifierComposition 'ParquetClassLibrary.Maps.ChunkType.ModifierComposition')
  - [ModifierTopography](#P-ParquetClassLibrary-Maps-ChunkType-ModifierTopography 'ParquetClassLibrary.Maps.ChunkType.ModifierTopography')
  - [Clone()](#M-ParquetClassLibrary-Maps-ChunkType-Clone 'ParquetClassLibrary.Maps.ChunkType.Clone')
  - [ConvertFromString(inText,inRow,inMemberMapData)](#M-ParquetClassLibrary-Maps-ChunkType-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData- 'ParquetClassLibrary.Maps.ChunkType.ConvertFromString(System.String,CsvHelper.IReaderRow,CsvHelper.Configuration.MemberMapData)')
  - [ConvertToString(inValue,inRow,inMemberMapData)](#M-ParquetClassLibrary-Maps-ChunkType-ConvertToString-System-Object,CsvHelper-IWriterRow,CsvHelper-Configuration-MemberMapData- 'ParquetClassLibrary.Maps.ChunkType.ConvertToString(System.Object,CsvHelper.IWriterRow,CsvHelper.Configuration.MemberMapData)')
  - [Equals(inChunkType)](#M-ParquetClassLibrary-Maps-ChunkType-Equals-ParquetClassLibrary-Maps-ChunkType- 'ParquetClassLibrary.Maps.ChunkType.Equals(ParquetClassLibrary.Maps.ChunkType)')
  - [Equals(obj)](#M-ParquetClassLibrary-Maps-ChunkType-Equals-System-Object- 'ParquetClassLibrary.Maps.ChunkType.Equals(System.Object)')
  - [GetHashCode()](#M-ParquetClassLibrary-Maps-ChunkType-GetHashCode 'ParquetClassLibrary.Maps.ChunkType.GetHashCode')
  - [ToString()](#M-ParquetClassLibrary-Maps-ChunkType-ToString 'ParquetClassLibrary.Maps.ChunkType.ToString')
  - [op_Equality(inChunkType1,inChunkType2)](#M-ParquetClassLibrary-Maps-ChunkType-op_Equality-ParquetClassLibrary-Maps-ChunkType,ParquetClassLibrary-Maps-ChunkType- 'ParquetClassLibrary.Maps.ChunkType.op_Equality(ParquetClassLibrary.Maps.ChunkType,ParquetClassLibrary.Maps.ChunkType)')
  - [op_Inequality(inChunkType1,inChunkType2)](#M-ParquetClassLibrary-Maps-ChunkType-op_Inequality-ParquetClassLibrary-Maps-ChunkType,ParquetClassLibrary-Maps-ChunkType- 'ParquetClassLibrary.Maps.ChunkType.op_Inequality(ParquetClassLibrary.Maps.ChunkType,ParquetClassLibrary.Maps.ChunkType)')
- [ChunkTypeExtensions](#T-ParquetClassLibrary-Maps-ChunkTypeExtensions 'ParquetClassLibrary.Maps.ChunkTypeExtensions')
  - [IsValidPosition(inChunkTypeArray,inPosition)](#M-ParquetClassLibrary-Maps-ChunkTypeExtensions-IsValidPosition-ParquetClassLibrary-Maps-ChunkType[0-,0-],ParquetClassLibrary-Vector2D- 'ParquetClassLibrary.Maps.ChunkTypeExtensions.IsValidPosition(ParquetClassLibrary.Maps.ChunkType[0:,0:],ParquetClassLibrary.Vector2D)')
- [ChunkTypeGrid](#T-ParquetClassLibrary-Maps-ChunkTypeGrid 'ParquetClassLibrary.Maps.ChunkTypeGrid')
  - [#ctor()](#M-ParquetClassLibrary-Maps-ChunkTypeGrid-#ctor 'ParquetClassLibrary.Maps.ChunkTypeGrid.#ctor')
  - [#ctor(inRowCount,inColumnCount)](#M-ParquetClassLibrary-Maps-ChunkTypeGrid-#ctor-System-Int32,System-Int32- 'ParquetClassLibrary.Maps.ChunkTypeGrid.#ctor(System.Int32,System.Int32)')
  - [ChunkTypes](#P-ParquetClassLibrary-Maps-ChunkTypeGrid-ChunkTypes 'ParquetClassLibrary.Maps.ChunkTypeGrid.ChunkTypes')
  - [Columns](#P-ParquetClassLibrary-Maps-ChunkTypeGrid-Columns 'ParquetClassLibrary.Maps.ChunkTypeGrid.Columns')
  - [Count](#P-ParquetClassLibrary-Maps-ChunkTypeGrid-Count 'ParquetClassLibrary.Maps.ChunkTypeGrid.Count')
  - [DimensionsInChunks](#P-ParquetClassLibrary-Maps-ChunkTypeGrid-DimensionsInChunks 'ParquetClassLibrary.Maps.ChunkTypeGrid.DimensionsInChunks')
  - [Item](#P-ParquetClassLibrary-Maps-ChunkTypeGrid-Item-System-Int32,System-Int32- 'ParquetClassLibrary.Maps.ChunkTypeGrid.Item(System.Int32,System.Int32)')
  - [Rows](#P-ParquetClassLibrary-Maps-ChunkTypeGrid-Rows 'ParquetClassLibrary.Maps.ChunkTypeGrid.Rows')
  - [GetEnumerator()](#M-ParquetClassLibrary-Maps-ChunkTypeGrid-GetEnumerator 'ParquetClassLibrary.Maps.ChunkTypeGrid.GetEnumerator')
  - [IsValidPosition(inPosition)](#M-ParquetClassLibrary-Maps-ChunkTypeGrid-IsValidPosition-ParquetClassLibrary-Vector2D- 'ParquetClassLibrary.Maps.ChunkTypeGrid.IsValidPosition(ParquetClassLibrary.Vector2D)')
  - [System#Collections#Generic#IEnumerable{ParquetClassLibrary#Maps#ChunkType}#GetEnumerator()](#M-ParquetClassLibrary-Maps-ChunkTypeGrid-System#Collections#Generic#IEnumerable{ParquetClassLibrary#Maps#ChunkType}#GetEnumerator 'ParquetClassLibrary.Maps.ChunkTypeGrid.System#Collections#Generic#IEnumerable{ParquetClassLibrary#Maps#ChunkType}#GetEnumerator')
- [CollectibleModel](#T-ParquetClassLibrary-Parquets-CollectibleModel 'ParquetClassLibrary.Parquets.CollectibleModel')
  - [#ctor(inID,inName,inDescription,inComment,inItemID,inAddsToBiome,inAddsToRoom,inCollectionEffect,inEffectAmount)](#M-ParquetClassLibrary-Parquets-CollectibleModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Nullable{ParquetClassLibrary-ModelID},ParquetClassLibrary-ModelTag,ParquetClassLibrary-ModelTag,ParquetClassLibrary-Parquets-CollectingEffect,System-Int32- 'ParquetClassLibrary.Parquets.CollectibleModel.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.Nullable{ParquetClassLibrary.ModelID},ParquetClassLibrary.ModelTag,ParquetClassLibrary.ModelTag,ParquetClassLibrary.Parquets.CollectingEffect,System.Int32)')
  - [Bounds](#P-ParquetClassLibrary-Parquets-CollectibleModel-Bounds 'ParquetClassLibrary.Parquets.CollectibleModel.Bounds')
  - [CollectionEffect](#P-ParquetClassLibrary-Parquets-CollectibleModel-CollectionEffect 'ParquetClassLibrary.Parquets.CollectibleModel.CollectionEffect')
  - [EffectAmount](#P-ParquetClassLibrary-Parquets-CollectibleModel-EffectAmount 'ParquetClassLibrary.Parquets.CollectibleModel.EffectAmount')
- [CollectingEffect](#T-ParquetClassLibrary-Parquets-CollectingEffect 'ParquetClassLibrary.Parquets.CollectingEffect')
  - [BiomeTime](#F-ParquetClassLibrary-Parquets-CollectingEffect-BiomeTime 'ParquetClassLibrary.Parquets.CollectingEffect.BiomeTime')
  - [Item](#F-ParquetClassLibrary-Parquets-CollectingEffect-Item 'ParquetClassLibrary.Parquets.CollectingEffect.Item')
  - [None](#F-ParquetClassLibrary-Parquets-CollectingEffect-None 'ParquetClassLibrary.Parquets.CollectingEffect.None')
- [Commands](#T-ParquetClassLibrary-Scripts-Commands 'ParquetClassLibrary.Scripts.Commands')
  - [Alert](#F-ParquetClassLibrary-Scripts-Commands-Alert 'ParquetClassLibrary.Scripts.Commands.Alert')
  - [CallCharacter](#F-ParquetClassLibrary-Scripts-Commands-CallCharacter 'ParquetClassLibrary.Scripts.Commands.CallCharacter')
  - [ClearFlag](#F-ParquetClassLibrary-Scripts-Commands-ClearFlag 'ParquetClassLibrary.Scripts.Commands.ClearFlag')
  - [GiveItem](#F-ParquetClassLibrary-Scripts-Commands-GiveItem 'ParquetClassLibrary.Scripts.Commands.GiveItem')
  - [GiveQuest](#F-ParquetClassLibrary-Scripts-Commands-GiveQuest 'ParquetClassLibrary.Scripts.Commands.GiveQuest')
  - [Jump](#F-ParquetClassLibrary-Scripts-Commands-Jump 'ParquetClassLibrary.Scripts.Commands.Jump')
  - [JumpIf](#F-ParquetClassLibrary-Scripts-Commands-JumpIf 'ParquetClassLibrary.Scripts.Commands.JumpIf')
  - [None](#F-ParquetClassLibrary-Scripts-Commands-None 'ParquetClassLibrary.Scripts.Commands.None')
  - [Put](#F-ParquetClassLibrary-Scripts-Commands-Put 'ParquetClassLibrary.Scripts.Commands.Put')
  - [Say](#F-ParquetClassLibrary-Scripts-Commands-Say 'ParquetClassLibrary.Scripts.Commands.Say')
  - [SetBehavior](#F-ParquetClassLibrary-Scripts-Commands-SetBehavior 'ParquetClassLibrary.Scripts.Commands.SetBehavior')
  - [SetDialogue](#F-ParquetClassLibrary-Scripts-Commands-SetDialogue 'ParquetClassLibrary.Scripts.Commands.SetDialogue')
  - [SetFlag](#F-ParquetClassLibrary-Scripts-Commands-SetFlag 'ParquetClassLibrary.Scripts.Commands.SetFlag')
  - [SetPronoun](#F-ParquetClassLibrary-Scripts-Commands-SetPronoun 'ParquetClassLibrary.Scripts.Commands.SetPronoun')
  - [ShowLocation](#F-ParquetClassLibrary-Scripts-Commands-ShowLocation 'ParquetClassLibrary.Scripts.Commands.ShowLocation')
- [Craft](#T-ParquetClassLibrary-Rules-Recipes-Craft 'ParquetClassLibrary.Rules.Recipes.Craft')
  - [IngredientCount](#P-ParquetClassLibrary-Rules-Recipes-Craft-IngredientCount 'ParquetClassLibrary.Rules.Recipes.Craft.IngredientCount')
  - [ProductCount](#P-ParquetClassLibrary-Rules-Recipes-Craft-ProductCount 'ParquetClassLibrary.Rules.Recipes.Craft.ProductCount')
- [CraftingRecipe](#T-ParquetClassLibrary-Crafts-CraftingRecipe 'ParquetClassLibrary.Crafts.CraftingRecipe')
  - [#ctor(inID,inName,inDescription,inComment,inProducts,inIngredients,inPanelPattern)](#M-ParquetClassLibrary-Crafts-CraftingRecipe-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Collections-Generic-IEnumerable{ParquetClassLibrary-RecipeElement},System-Collections-Generic-IEnumerable{ParquetClassLibrary-RecipeElement},ParquetClassLibrary-Crafts-StrikePanelGrid- 'ParquetClassLibrary.Crafts.CraftingRecipe.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.Collections.Generic.IEnumerable{ParquetClassLibrary.RecipeElement},System.Collections.Generic.IEnumerable{ParquetClassLibrary.RecipeElement},ParquetClassLibrary.Crafts.StrikePanelGrid)')
  - [EmptyCraftingElementList](#P-ParquetClassLibrary-Crafts-CraftingRecipe-EmptyCraftingElementList 'ParquetClassLibrary.Crafts.CraftingRecipe.EmptyCraftingElementList')
  - [Ingredients](#P-ParquetClassLibrary-Crafts-CraftingRecipe-Ingredients 'ParquetClassLibrary.Crafts.CraftingRecipe.Ingredients')
  - [NotCraftable](#P-ParquetClassLibrary-Crafts-CraftingRecipe-NotCraftable 'ParquetClassLibrary.Crafts.CraftingRecipe.NotCraftable')
  - [PanelPattern](#P-ParquetClassLibrary-Crafts-CraftingRecipe-PanelPattern 'ParquetClassLibrary.Crafts.CraftingRecipe.PanelPattern')
  - [Products](#P-ParquetClassLibrary-Crafts-CraftingRecipe-Products 'ParquetClassLibrary.Crafts.CraftingRecipe.Products')
- [CritterModel](#T-ParquetClassLibrary-Beings-CritterModel 'ParquetClassLibrary.Beings.CritterModel')
  - [#ctor(inID,inName,inDescription,inComment,inNativeBiome,inPrimaryBehavior,inAvoids,inSeeks)](#M-ParquetClassLibrary-Beings-CritterModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID,System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID}- 'ParquetClassLibrary.Beings.CritterModel.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,ParquetClassLibrary.ModelID,ParquetClassLibrary.ModelID,System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID},System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID})')
- [Delimiters](#T-ParquetClassLibrary-Rules-Delimiters 'ParquetClassLibrary.Rules.Delimiters')
  - [DimensionalDelimiter](#F-ParquetClassLibrary-Rules-Delimiters-DimensionalDelimiter 'ParquetClassLibrary.Rules.Delimiters.DimensionalDelimiter')
  - [DimensionalTerminator](#F-ParquetClassLibrary-Rules-Delimiters-DimensionalTerminator 'ParquetClassLibrary.Rules.Delimiters.DimensionalTerminator')
  - [ElementDelimiter](#F-ParquetClassLibrary-Rules-Delimiters-ElementDelimiter 'ParquetClassLibrary.Rules.Delimiters.ElementDelimiter')
  - [InternalDelimiter](#F-ParquetClassLibrary-Rules-Delimiters-InternalDelimiter 'ParquetClassLibrary.Rules.Delimiters.InternalDelimiter')
  - [NameDelimiter](#F-ParquetClassLibrary-Rules-Delimiters-NameDelimiter 'ParquetClassLibrary.Rules.Delimiters.NameDelimiter')
  - [PronounDelimiter](#F-ParquetClassLibrary-Rules-Delimiters-PronounDelimiter 'ParquetClassLibrary.Rules.Delimiters.PronounDelimiter')
  - [SecondaryDelimiter](#F-ParquetClassLibrary-Rules-Delimiters-SecondaryDelimiter 'ParquetClassLibrary.Rules.Delimiters.SecondaryDelimiter')
- [Dimensions](#T-ParquetClassLibrary-Rules-Dimensions 'ParquetClassLibrary.Rules.Dimensions')
  - [ChunksPerRegion](#F-ParquetClassLibrary-Rules-Dimensions-ChunksPerRegion 'ParquetClassLibrary.Rules.Dimensions.ChunksPerRegion')
  - [PanelsPerPatternHeight](#F-ParquetClassLibrary-Rules-Dimensions-PanelsPerPatternHeight 'ParquetClassLibrary.Rules.Dimensions.PanelsPerPatternHeight')
  - [PanelsPerPatternWidth](#F-ParquetClassLibrary-Rules-Dimensions-PanelsPerPatternWidth 'ParquetClassLibrary.Rules.Dimensions.PanelsPerPatternWidth')
  - [ParquetsPerChunk](#F-ParquetClassLibrary-Rules-Dimensions-ParquetsPerChunk 'ParquetClassLibrary.Rules.Dimensions.ParquetsPerChunk')
  - [ParquetsPerRegion](#F-ParquetClassLibrary-Rules-Dimensions-ParquetsPerRegion 'ParquetClassLibrary.Rules.Dimensions.ParquetsPerRegion')
- [Elevation](#T-ParquetClassLibrary-Biomes-Elevation 'ParquetClassLibrary.Biomes.Elevation')
  - [AboveGround](#F-ParquetClassLibrary-Biomes-Elevation-AboveGround 'ParquetClassLibrary.Biomes.Elevation.AboveGround')
  - [BelowGround](#F-ParquetClassLibrary-Biomes-Elevation-BelowGround 'ParquetClassLibrary.Biomes.Elevation.BelowGround')
  - [LevelGround](#F-ParquetClassLibrary-Biomes-Elevation-LevelGround 'ParquetClassLibrary.Biomes.Elevation.LevelGround')
- [ElevationMask](#T-ParquetClassLibrary-Biomes-ElevationMask 'ParquetClassLibrary.Biomes.ElevationMask')
- [ElevationMaskSelectionExtensions](#T-ParquetClassLibrary-Biomes-ElevationMaskSelectionExtensions 'ParquetClassLibrary.Biomes.ElevationMaskSelectionExtensions')
  - [Clear(refEnumVariable,inFlagToClear)](#M-ParquetClassLibrary-Biomes-ElevationMaskSelectionExtensions-Clear-ParquetClassLibrary-Biomes-ElevationMask@,ParquetClassLibrary-Biomes-ElevationMask- 'ParquetClassLibrary.Biomes.ElevationMaskSelectionExtensions.Clear(ParquetClassLibrary.Biomes.ElevationMask@,ParquetClassLibrary.Biomes.ElevationMask)')
  - [IsSet(inEnumVariable,inFlagToTest)](#M-ParquetClassLibrary-Biomes-ElevationMaskSelectionExtensions-IsSet-ParquetClassLibrary-Biomes-ElevationMask,ParquetClassLibrary-Biomes-ElevationMask- 'ParquetClassLibrary.Biomes.ElevationMaskSelectionExtensions.IsSet(ParquetClassLibrary.Biomes.ElevationMask,ParquetClassLibrary.Biomes.ElevationMask)')
  - [Set(refEnumVariable,inFlagToSet)](#M-ParquetClassLibrary-Biomes-ElevationMaskSelectionExtensions-Set-ParquetClassLibrary-Biomes-ElevationMask@,ParquetClassLibrary-Biomes-ElevationMask- 'ParquetClassLibrary.Biomes.ElevationMaskSelectionExtensions.Set(ParquetClassLibrary.Biomes.ElevationMask@,ParquetClassLibrary.Biomes.ElevationMask)')
  - [SetTo(refEnumVariable,inFlagToTest,inState)](#M-ParquetClassLibrary-Biomes-ElevationMaskSelectionExtensions-SetTo-ParquetClassLibrary-Biomes-ElevationMask@,ParquetClassLibrary-Biomes-ElevationMask,System-Boolean- 'ParquetClassLibrary.Biomes.ElevationMaskSelectionExtensions.SetTo(ParquetClassLibrary.Biomes.ElevationMask@,ParquetClassLibrary.Biomes.ElevationMask,System.Boolean)')
- [ExitCode](#T-ParquetRoller-ExitCode 'ParquetRoller.ExitCode')
  - [AccessDenied](#F-ParquetRoller-ExitCode-AccessDenied 'ParquetRoller.ExitCode.AccessDenied')
  - [BadArguments](#F-ParquetRoller-ExitCode-BadArguments 'ParquetRoller.ExitCode.BadArguments')
  - [FileNotFound](#F-ParquetRoller-ExitCode-FileNotFound 'ParquetRoller.ExitCode.FileNotFound')
  - [InvalidData](#F-ParquetRoller-ExitCode-InvalidData 'ParquetRoller.ExitCode.InvalidData')
  - [NotSupported](#F-ParquetRoller-ExitCode-NotSupported 'ParquetRoller.ExitCode.NotSupported')
  - [Success](#F-ParquetRoller-ExitCode-Success 'ParquetRoller.ExitCode.Success')
- [ExitPoint](#T-ParquetClassLibrary-Maps-ExitPoint 'ParquetClassLibrary.Maps.ExitPoint')
  - [#ctor()](#M-ParquetClassLibrary-Maps-ExitPoint-#ctor 'ParquetClassLibrary.Maps.ExitPoint.#ctor')
  - [#ctor(inPosition,inDestinationID)](#M-ParquetClassLibrary-Maps-ExitPoint-#ctor-ParquetClassLibrary-Vector2D,ParquetClassLibrary-ModelID- 'ParquetClassLibrary.Maps.ExitPoint.#ctor(ParquetClassLibrary.Vector2D,ParquetClassLibrary.ModelID)')
  - [ConverterFactory](#P-ParquetClassLibrary-Maps-ExitPoint-ConverterFactory 'ParquetClassLibrary.Maps.ExitPoint.ConverterFactory')
  - [Destination](#P-ParquetClassLibrary-Maps-ExitPoint-Destination 'ParquetClassLibrary.Maps.ExitPoint.Destination')
  - [Position](#P-ParquetClassLibrary-Maps-ExitPoint-Position 'ParquetClassLibrary.Maps.ExitPoint.Position')
  - [ConvertFromString(inText,inRow,inMemberMapData)](#M-ParquetClassLibrary-Maps-ExitPoint-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData- 'ParquetClassLibrary.Maps.ExitPoint.ConvertFromString(System.String,CsvHelper.IReaderRow,CsvHelper.Configuration.MemberMapData)')
  - [ConvertToString(inValue,inRow,inMemberMapData)](#M-ParquetClassLibrary-Maps-ExitPoint-ConvertToString-System-Object,CsvHelper-IWriterRow,CsvHelper-Configuration-MemberMapData- 'ParquetClassLibrary.Maps.ExitPoint.ConvertToString(System.Object,CsvHelper.IWriterRow,CsvHelper.Configuration.MemberMapData)')
  - [Equals(inPoint)](#M-ParquetClassLibrary-Maps-ExitPoint-Equals-ParquetClassLibrary-Maps-ExitPoint- 'ParquetClassLibrary.Maps.ExitPoint.Equals(ParquetClassLibrary.Maps.ExitPoint)')
  - [Equals(obj)](#M-ParquetClassLibrary-Maps-ExitPoint-Equals-System-Object- 'ParquetClassLibrary.Maps.ExitPoint.Equals(System.Object)')
  - [GetHashCode()](#M-ParquetClassLibrary-Maps-ExitPoint-GetHashCode 'ParquetClassLibrary.Maps.ExitPoint.GetHashCode')
  - [ToString()](#M-ParquetClassLibrary-Maps-ExitPoint-ToString 'ParquetClassLibrary.Maps.ExitPoint.ToString')
  - [op_Equality(inPoint1,inPoint2)](#M-ParquetClassLibrary-Maps-ExitPoint-op_Equality-ParquetClassLibrary-Maps-ExitPoint,ParquetClassLibrary-Maps-ExitPoint- 'ParquetClassLibrary.Maps.ExitPoint.op_Equality(ParquetClassLibrary.Maps.ExitPoint,ParquetClassLibrary.Maps.ExitPoint)')
  - [op_Inequality(inPoint1,inPoint2)](#M-ParquetClassLibrary-Maps-ExitPoint-op_Inequality-ParquetClassLibrary-Maps-ExitPoint,ParquetClassLibrary-Maps-ExitPoint- 'ParquetClassLibrary.Maps.ExitPoint.op_Inequality(ParquetClassLibrary.Maps.ExitPoint,ParquetClassLibrary.Maps.ExitPoint)')
- [FloorModel](#T-ParquetClassLibrary-Parquets-FloorModel 'ParquetClassLibrary.Parquets.FloorModel')
  - [#ctor(inID,inName,inDescription,inComment,inItemID,inAddsToBiome,inAddsToRoom,inModTool,inTrenchName)](#M-ParquetClassLibrary-Parquets-FloorModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Nullable{ParquetClassLibrary-ModelID},ParquetClassLibrary-ModelTag,ParquetClassLibrary-ModelTag,ParquetClassLibrary-Items-ModificationTool,System-String- 'ParquetClassLibrary.Parquets.FloorModel.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.Nullable{ParquetClassLibrary.ModelID},ParquetClassLibrary.ModelTag,ParquetClassLibrary.ModelTag,ParquetClassLibrary.Items.ModificationTool,System.String)')
  - [defaultTrenchName](#F-ParquetClassLibrary-Parquets-FloorModel-defaultTrenchName 'ParquetClassLibrary.Parquets.FloorModel.defaultTrenchName')
  - [Bounds](#P-ParquetClassLibrary-Parquets-FloorModel-Bounds 'ParquetClassLibrary.Parquets.FloorModel.Bounds')
  - [ModTool](#P-ParquetClassLibrary-Parquets-FloorModel-ModTool 'ParquetClassLibrary.Parquets.FloorModel.ModTool')
  - [TrenchName](#P-ParquetClassLibrary-Parquets-FloorModel-TrenchName 'ParquetClassLibrary.Parquets.FloorModel.TrenchName')
- [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel')
  - [#ctor(inID,inName,inDescription,inComment,inItemID,inAddsToBiome,inAddsToRoom,inIsWalkable,inIsEntry,inIsEnclosing,inIsFlammable,inSwapID)](#M-ParquetClassLibrary-Parquets-FurnishingModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Nullable{ParquetClassLibrary-ModelID},ParquetClassLibrary-ModelTag,ParquetClassLibrary-ModelTag,System-Boolean,System-Boolean,System-Boolean,System-Boolean,System-Nullable{ParquetClassLibrary-ModelID}- 'ParquetClassLibrary.Parquets.FurnishingModel.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.Nullable{ParquetClassLibrary.ModelID},ParquetClassLibrary.ModelTag,ParquetClassLibrary.ModelTag,System.Boolean,System.Boolean,System.Boolean,System.Boolean,System.Nullable{ParquetClassLibrary.ModelID})')
  - [Bounds](#P-ParquetClassLibrary-Parquets-FurnishingModel-Bounds 'ParquetClassLibrary.Parquets.FurnishingModel.Bounds')
  - [IsEnclosing](#P-ParquetClassLibrary-Parquets-FurnishingModel-IsEnclosing 'ParquetClassLibrary.Parquets.FurnishingModel.IsEnclosing')
  - [IsEntry](#P-ParquetClassLibrary-Parquets-FurnishingModel-IsEntry 'ParquetClassLibrary.Parquets.FurnishingModel.IsEntry')
  - [IsFlammable](#P-ParquetClassLibrary-Parquets-FurnishingModel-IsFlammable 'ParquetClassLibrary.Parquets.FurnishingModel.IsFlammable')
  - [IsWalkable](#P-ParquetClassLibrary-Parquets-FurnishingModel-IsWalkable 'ParquetClassLibrary.Parquets.FurnishingModel.IsWalkable')
  - [SwapID](#P-ParquetClassLibrary-Parquets-FurnishingModel-SwapID 'ParquetClassLibrary.Parquets.FurnishingModel.SwapID')
- [GatheringEffect](#T-ParquetClassLibrary-Parquets-GatheringEffect 'ParquetClassLibrary.Parquets.GatheringEffect')
  - [Collectible](#F-ParquetClassLibrary-Parquets-GatheringEffect-Collectible 'ParquetClassLibrary.Parquets.GatheringEffect.Collectible')
  - [Item](#F-ParquetClassLibrary-Parquets-GatheringEffect-Item 'ParquetClassLibrary.Parquets.GatheringEffect.Item')
  - [None](#F-ParquetClassLibrary-Parquets-GatheringEffect-None 'ParquetClassLibrary.Parquets.GatheringEffect.None')
- [GatheringTool](#T-ParquetClassLibrary-Items-GatheringTool 'ParquetClassLibrary.Items.GatheringTool')
  - [Axe](#F-ParquetClassLibrary-Items-GatheringTool-Axe 'ParquetClassLibrary.Items.GatheringTool.Axe')
  - [Bucket](#F-ParquetClassLibrary-Items-GatheringTool-Bucket 'ParquetClassLibrary.Items.GatheringTool.Bucket')
  - [None](#F-ParquetClassLibrary-Items-GatheringTool-None 'ParquetClassLibrary.Items.GatheringTool.None')
  - [Pick](#F-ParquetClassLibrary-Items-GatheringTool-Pick 'ParquetClassLibrary.Items.GatheringTool.Pick')
  - [Shovel](#F-ParquetClassLibrary-Items-GatheringTool-Shovel 'ParquetClassLibrary.Items.GatheringTool.Shovel')
- [GridConverter\`2](#T-ParquetClassLibrary-GridConverter`2 'ParquetClassLibrary.GridConverter`2')
  - [ConverterFactory](#P-ParquetClassLibrary-GridConverter`2-ConverterFactory 'ParquetClassLibrary.GridConverter`2.ConverterFactory')
  - [ConvertFromString(inText,inRow,inMemberMapData)](#M-ParquetClassLibrary-GridConverter`2-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData- 'ParquetClassLibrary.GridConverter`2.ConvertFromString(System.String,CsvHelper.IReaderRow,CsvHelper.Configuration.MemberMapData)')
  - [ConvertToString(inValue,inRow,inMemberMapData)](#M-ParquetClassLibrary-GridConverter`2-ConvertToString-System-Object,CsvHelper-IWriterRow,CsvHelper-Configuration-MemberMapData- 'ParquetClassLibrary.GridConverter`2.ConvertToString(System.Object,CsvHelper.IWriterRow,CsvHelper.Configuration.MemberMapData)')
- [IGrid\`1](#T-ParquetClassLibrary-IGrid`1 'ParquetClassLibrary.IGrid`1')
  - [Columns](#P-ParquetClassLibrary-IGrid`1-Columns 'ParquetClassLibrary.IGrid`1.Columns')
  - [Item](#P-ParquetClassLibrary-IGrid`1-Item-System-Int32,System-Int32- 'ParquetClassLibrary.IGrid`1.Item(System.Int32,System.Int32)')
  - [Rows](#P-ParquetClassLibrary-IGrid`1-Rows 'ParquetClassLibrary.IGrid`1.Rows')
- [IMapRegionEdit](#T-ParquetClassLibrary-Maps-IMapRegionEdit 'ParquetClassLibrary.Maps.IMapRegionEdit')
  - [BackgroundColor](#P-ParquetClassLibrary-Maps-IMapRegionEdit-BackgroundColor 'ParquetClassLibrary.Maps.IMapRegionEdit.BackgroundColor')
  - [ElevationGlobal](#P-ParquetClassLibrary-Maps-IMapRegionEdit-ElevationGlobal 'ParquetClassLibrary.Maps.IMapRegionEdit.ElevationGlobal')
  - [ElevationLocal](#P-ParquetClassLibrary-Maps-IMapRegionEdit-ElevationLocal 'ParquetClassLibrary.Maps.IMapRegionEdit.ElevationLocal')
  - [Name](#P-ParquetClassLibrary-Maps-IMapRegionEdit-Name 'ParquetClassLibrary.Maps.IMapRegionEdit.Name')
- [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit')
  - [Comment](#P-ParquetClassLibrary-IModelEdit-Comment 'ParquetClassLibrary.IModelEdit.Comment')
  - [Description](#P-ParquetClassLibrary-IModelEdit-Description 'ParquetClassLibrary.IModelEdit.Description')
  - [Name](#P-ParquetClassLibrary-IModelEdit-Name 'ParquetClassLibrary.IModelEdit.Name')
- [IParquetStack](#T-ParquetClassLibrary-Parquets-IParquetStack 'ParquetClassLibrary.Parquets.IParquetStack')
  - [Block](#P-ParquetClassLibrary-Parquets-IParquetStack-Block 'ParquetClassLibrary.Parquets.IParquetStack.Block')
  - [Collectible](#P-ParquetClassLibrary-Parquets-IParquetStack-Collectible 'ParquetClassLibrary.Parquets.IParquetStack.Collectible')
  - [Floor](#P-ParquetClassLibrary-Parquets-IParquetStack-Floor 'ParquetClassLibrary.Parquets.IParquetStack.Floor')
  - [Furnishing](#P-ParquetClassLibrary-Parquets-IParquetStack-Furnishing 'ParquetClassLibrary.Parquets.IParquetStack.Furnishing')
  - [IsEmpty](#P-ParquetClassLibrary-Parquets-IParquetStack-IsEmpty 'ParquetClassLibrary.Parquets.IParquetStack.IsEmpty')
- [IPronounGroupEdit](#T-ParquetClassLibrary-Beings-IPronounGroupEdit 'ParquetClassLibrary.Beings.IPronounGroupEdit')
  - [Determiner](#P-ParquetClassLibrary-Beings-IPronounGroupEdit-Determiner 'ParquetClassLibrary.Beings.IPronounGroupEdit.Determiner')
  - [Objective](#P-ParquetClassLibrary-Beings-IPronounGroupEdit-Objective 'ParquetClassLibrary.Beings.IPronounGroupEdit.Objective')
  - [Possessive](#P-ParquetClassLibrary-Beings-IPronounGroupEdit-Possessive 'ParquetClassLibrary.Beings.IPronounGroupEdit.Possessive')
  - [Reflexive](#P-ParquetClassLibrary-Beings-IPronounGroupEdit-Reflexive 'ParquetClassLibrary.Beings.IPronounGroupEdit.Reflexive')
  - [Subjective](#P-ParquetClassLibrary-Beings-IPronounGroupEdit-Subjective 'ParquetClassLibrary.Beings.IPronounGroupEdit.Subjective')
- [IntExtensions](#T-ParquetClassLibrary-IntExtensions 'ParquetClassLibrary.IntExtensions')
  - [Normalize(inInt,inLowerBound,inUpperBound)](#M-ParquetClassLibrary-IntExtensions-Normalize-System-Int32,System-Int32,System-Int32- 'ParquetClassLibrary.IntExtensions.Normalize(System.Int32,System.Int32,System.Int32)')
- [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel')
  - [#ctor(inID,inName,inDescription,inComment,inPrerequisites,inSteps,inOutcomes)](#M-ParquetClassLibrary-Scripts-InteractionModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID}- 'ParquetClassLibrary.Scripts.InteractionModel.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID},System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID},System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID})')
  - [Outcomes](#P-ParquetClassLibrary-Scripts-InteractionModel-Outcomes 'ParquetClassLibrary.Scripts.InteractionModel.Outcomes')
  - [Prerequisites](#P-ParquetClassLibrary-Scripts-InteractionModel-Prerequisites 'ParquetClassLibrary.Scripts.InteractionModel.Prerequisites')
  - [Steps](#P-ParquetClassLibrary-Scripts-InteractionModel-Steps 'ParquetClassLibrary.Scripts.InteractionModel.Steps')
- [InteractionStatus](#T-ParquetClassLibrary-Scripts-InteractionStatus 'ParquetClassLibrary.Scripts.InteractionStatus')
  - [#ctor(inInteractionDefinition,inState,inProgramCounter)](#M-ParquetClassLibrary-Scripts-InteractionStatus-#ctor-ParquetClassLibrary-Scripts-InteractionModel,ParquetClassLibrary-Scripts-RunState,System-Int32- 'ParquetClassLibrary.Scripts.InteractionStatus.#ctor(ParquetClassLibrary.Scripts.InteractionModel,ParquetClassLibrary.Scripts.RunState,System.Int32)')
  - [DataVersion](#P-ParquetClassLibrary-Scripts-InteractionStatus-DataVersion 'ParquetClassLibrary.Scripts.InteractionStatus.DataVersion')
  - [InteractionDefinition](#P-ParquetClassLibrary-Scripts-InteractionStatus-InteractionDefinition 'ParquetClassLibrary.Scripts.InteractionStatus.InteractionDefinition')
  - [ProgramCounter](#P-ParquetClassLibrary-Scripts-InteractionStatus-ProgramCounter 'ParquetClassLibrary.Scripts.InteractionStatus.ProgramCounter')
  - [Revision](#P-ParquetClassLibrary-Scripts-InteractionStatus-Revision 'ParquetClassLibrary.Scripts.InteractionStatus.Revision')
  - [State](#P-ParquetClassLibrary-Scripts-InteractionStatus-State 'ParquetClassLibrary.Scripts.InteractionStatus.State')
  - [ToString()](#M-ParquetClassLibrary-Scripts-InteractionStatus-ToString 'ParquetClassLibrary.Scripts.InteractionStatus.ToString')
- [Inventory](#T-ParquetClassLibrary-Items-Inventory 'ParquetClassLibrary.Items.Inventory')
  - [#ctor(inCapacity)](#M-ParquetClassLibrary-Items-Inventory-#ctor-System-Int32- 'ParquetClassLibrary.Items.Inventory.#ctor(System.Int32)')
  - [#ctor(inSlots,inCapacity)](#M-ParquetClassLibrary-Items-Inventory-#ctor-System-Collections-Generic-IEnumerable{ParquetClassLibrary-Items-InventorySlot},System-Int32- 'ParquetClassLibrary.Items.Inventory.#ctor(System.Collections.Generic.IEnumerable{ParquetClassLibrary.Items.InventorySlot},System.Int32)')
  - [Capacity](#P-ParquetClassLibrary-Items-Inventory-Capacity 'ParquetClassLibrary.Items.Inventory.Capacity')
  - [Count](#P-ParquetClassLibrary-Items-Inventory-Count 'ParquetClassLibrary.Items.Inventory.Count')
  - [Slots](#P-ParquetClassLibrary-Items-Inventory-Slots 'ParquetClassLibrary.Items.Inventory.Slots')
  - [Contains(inItemID)](#M-ParquetClassLibrary-Items-Inventory-Contains-ParquetClassLibrary-ModelID- 'ParquetClassLibrary.Items.Inventory.Contains(ParquetClassLibrary.ModelID)')
  - [GetEnumerator()](#M-ParquetClassLibrary-Items-Inventory-GetEnumerator 'ParquetClassLibrary.Items.Inventory.GetEnumerator')
  - [Give(inSlot)](#M-ParquetClassLibrary-Items-Inventory-Give-ParquetClassLibrary-Items-InventorySlot- 'ParquetClassLibrary.Items.Inventory.Give(ParquetClassLibrary.Items.InventorySlot)')
  - [Give(inItemID,inHowMany)](#M-ParquetClassLibrary-Items-Inventory-Give-ParquetClassLibrary-ModelID,System-Int32- 'ParquetClassLibrary.Items.Inventory.Give(ParquetClassLibrary.ModelID,System.Int32)')
  - [Has(inItems)](#M-ParquetClassLibrary-Items-Inventory-Has-System-Collections-Generic-IEnumerable{System-ValueTuple{ParquetClassLibrary-ModelID,System-Int32}}- 'ParquetClassLibrary.Items.Inventory.Has(System.Collections.Generic.IEnumerable{System.ValueTuple{ParquetClassLibrary.ModelID,System.Int32}})')
  - [Has(inSlots)](#M-ParquetClassLibrary-Items-Inventory-Has-System-Collections-Generic-IEnumerable{ParquetClassLibrary-Items-InventorySlot}- 'ParquetClassLibrary.Items.Inventory.Has(System.Collections.Generic.IEnumerable{ParquetClassLibrary.Items.InventorySlot})')
  - [Has(inSlot)](#M-ParquetClassLibrary-Items-Inventory-Has-ParquetClassLibrary-Items-InventorySlot- 'ParquetClassLibrary.Items.Inventory.Has(ParquetClassLibrary.Items.InventorySlot)')
  - [Has(inItemID,inHowMany)](#M-ParquetClassLibrary-Items-Inventory-Has-ParquetClassLibrary-ModelID,System-Int32- 'ParquetClassLibrary.Items.Inventory.Has(ParquetClassLibrary.ModelID,System.Int32)')
  - [System#Collections#IEnumerable#GetEnumerator()](#M-ParquetClassLibrary-Items-Inventory-System#Collections#IEnumerable#GetEnumerator 'ParquetClassLibrary.Items.Inventory.System#Collections#IEnumerable#GetEnumerator')
  - [Take(inSlot)](#M-ParquetClassLibrary-Items-Inventory-Take-ParquetClassLibrary-Items-InventorySlot- 'ParquetClassLibrary.Items.Inventory.Take(ParquetClassLibrary.Items.InventorySlot)')
  - [Take(inItemID,inHowMany)](#M-ParquetClassLibrary-Items-Inventory-Take-ParquetClassLibrary-ModelID,System-Int32- 'ParquetClassLibrary.Items.Inventory.Take(ParquetClassLibrary.ModelID,System.Int32)')
  - [ToString()](#M-ParquetClassLibrary-Items-Inventory-ToString 'ParquetClassLibrary.Items.Inventory.ToString')
- [InventorySlot](#T-ParquetClassLibrary-Items-InventorySlot 'ParquetClassLibrary.Items.InventorySlot')
  - [#ctor()](#M-ParquetClassLibrary-Items-InventorySlot-#ctor 'ParquetClassLibrary.Items.InventorySlot.#ctor')
  - [#ctor(inItemToStore,inHowMany)](#M-ParquetClassLibrary-Items-InventorySlot-#ctor-ParquetClassLibrary-ModelID,System-Int32- 'ParquetClassLibrary.Items.InventorySlot.#ctor(ParquetClassLibrary.ModelID,System.Int32)')
  - [DefaultStackMax](#F-ParquetClassLibrary-Items-InventorySlot-DefaultStackMax 'ParquetClassLibrary.Items.InventorySlot.DefaultStackMax')
  - [StackMax](#F-ParquetClassLibrary-Items-InventorySlot-StackMax 'ParquetClassLibrary.Items.InventorySlot.StackMax')
  - [ConverterFactory](#P-ParquetClassLibrary-Items-InventorySlot-ConverterFactory 'ParquetClassLibrary.Items.InventorySlot.ConverterFactory')
  - [Count](#P-ParquetClassLibrary-Items-InventorySlot-Count 'ParquetClassLibrary.Items.InventorySlot.Count')
  - [ItemID](#P-ParquetClassLibrary-Items-InventorySlot-ItemID 'ParquetClassLibrary.Items.InventorySlot.ItemID')
  - [ConvertFromString(inText,inRow,inMemberMapData)](#M-ParquetClassLibrary-Items-InventorySlot-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData- 'ParquetClassLibrary.Items.InventorySlot.ConvertFromString(System.String,CsvHelper.IReaderRow,CsvHelper.Configuration.MemberMapData)')
  - [ConvertToString(inValue,inRow,inMemberMapData)](#M-ParquetClassLibrary-Items-InventorySlot-ConvertToString-System-Object,CsvHelper-IWriterRow,CsvHelper-Configuration-MemberMapData- 'ParquetClassLibrary.Items.InventorySlot.ConvertToString(System.Object,CsvHelper.IWriterRow,CsvHelper.Configuration.MemberMapData)')
  - [Give(inHowMany)](#M-ParquetClassLibrary-Items-InventorySlot-Give-System-Int32- 'ParquetClassLibrary.Items.InventorySlot.Give(System.Int32)')
  - [Take(inHowMany)](#M-ParquetClassLibrary-Items-InventorySlot-Take-System-Int32- 'ParquetClassLibrary.Items.InventorySlot.Take(System.Int32)')
  - [ToString()](#M-ParquetClassLibrary-Items-InventorySlot-ToString 'ParquetClassLibrary.Items.InventorySlot.ToString')
- [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel')
  - [#ctor(inID,inName,inDescription,inComment,inSubtype,inPrice,inRarity,inStackMax,inEffectWhileHeld,inEffectWhenUsed,inParquetID,inItemTags)](#M-ParquetClassLibrary-Items-ItemModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,ParquetClassLibrary-Items-ItemType,System-Int32,System-Int32,System-Int32,ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID,System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag}- 'ParquetClassLibrary.Items.ItemModel.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,ParquetClassLibrary.Items.ItemType,System.Int32,System.Int32,System.Int32,ParquetClassLibrary.ModelID,ParquetClassLibrary.ModelID,ParquetClassLibrary.ModelID,System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag})')
  - [EffectWhenUsed](#P-ParquetClassLibrary-Items-ItemModel-EffectWhenUsed 'ParquetClassLibrary.Items.ItemModel.EffectWhenUsed')
  - [EffectWhileHeld](#P-ParquetClassLibrary-Items-ItemModel-EffectWhileHeld 'ParquetClassLibrary.Items.ItemModel.EffectWhileHeld')
  - [ItemTags](#P-ParquetClassLibrary-Items-ItemModel-ItemTags 'ParquetClassLibrary.Items.ItemModel.ItemTags')
  - [ParquetID](#P-ParquetClassLibrary-Items-ItemModel-ParquetID 'ParquetClassLibrary.Items.ItemModel.ParquetID')
  - [Price](#P-ParquetClassLibrary-Items-ItemModel-Price 'ParquetClassLibrary.Items.ItemModel.Price')
  - [Rarity](#P-ParquetClassLibrary-Items-ItemModel-Rarity 'ParquetClassLibrary.Items.ItemModel.Rarity')
  - [StackMax](#P-ParquetClassLibrary-Items-ItemModel-StackMax 'ParquetClassLibrary.Items.ItemModel.StackMax')
  - [Subtype](#P-ParquetClassLibrary-Items-ItemModel-Subtype 'ParquetClassLibrary.Items.ItemModel.Subtype')
  - [GetAllTags()](#M-ParquetClassLibrary-Items-ItemModel-GetAllTags 'ParquetClassLibrary.Items.ItemModel.GetAllTags')
- [ItemType](#T-ParquetClassLibrary-Items-ItemType 'ParquetClassLibrary.Items.ItemType')
  - [Consumable](#F-ParquetClassLibrary-Items-ItemType-Consumable 'ParquetClassLibrary.Items.ItemType.Consumable')
  - [Equipment](#F-ParquetClassLibrary-Items-ItemType-Equipment 'ParquetClassLibrary.Items.ItemType.Equipment')
  - [KeyItem](#F-ParquetClassLibrary-Items-ItemType-KeyItem 'ParquetClassLibrary.Items.ItemType.KeyItem')
  - [Material](#F-ParquetClassLibrary-Items-ItemType-Material 'ParquetClassLibrary.Items.ItemType.Material')
  - [Other](#F-ParquetClassLibrary-Items-ItemType-Other 'ParquetClassLibrary.Items.ItemType.Other')
  - [Storage](#F-ParquetClassLibrary-Items-ItemType-Storage 'ParquetClassLibrary.Items.ItemType.Storage')
  - [ToolForGathering](#F-ParquetClassLibrary-Items-ItemType-ToolForGathering 'ParquetClassLibrary.Items.ItemType.ToolForGathering')
  - [ToolForModification](#F-ParquetClassLibrary-Items-ItemType-ToolForModification 'ParquetClassLibrary.Items.ItemType.ToolForModification')
- [Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location')
  - [Position](#P-ParquetClassLibrary-Location-Position 'ParquetClassLibrary.Location.Position')
  - [RegionID](#P-ParquetClassLibrary-Location-RegionID 'ParquetClassLibrary.Location.RegionID')
  - [Equals(inLocation)](#M-ParquetClassLibrary-Location-Equals-ParquetClassLibrary-Location- 'ParquetClassLibrary.Location.Equals(ParquetClassLibrary.Location)')
  - [Equals(obj)](#M-ParquetClassLibrary-Location-Equals-System-Object- 'ParquetClassLibrary.Location.Equals(System.Object)')
  - [GetHashCode()](#M-ParquetClassLibrary-Location-GetHashCode 'ParquetClassLibrary.Location.GetHashCode')
  - [ToString()](#M-ParquetClassLibrary-Location-ToString 'ParquetClassLibrary.Location.ToString')
  - [op_Equality(inLocation1,inLocation2)](#M-ParquetClassLibrary-Location-op_Equality-ParquetClassLibrary-Location,ParquetClassLibrary-Location- 'ParquetClassLibrary.Location.op_Equality(ParquetClassLibrary.Location,ParquetClassLibrary.Location)')
  - [op_Inequality(inLocation1,inLocation2)](#M-ParquetClassLibrary-Location-op_Inequality-ParquetClassLibrary-Location,ParquetClassLibrary-Location- 'ParquetClassLibrary.Location.op_Inequality(ParquetClassLibrary.Location,ParquetClassLibrary.Location)')
- [MapChunk](#T-ParquetClassLibrary-Maps-MapChunk 'ParquetClassLibrary.Maps.MapChunk')
  - [#ctor(inID,inName,inDescription,inComment,inDataVersion,inRevision,inExits,inParquetStatuses,inParquetDefinitions)](#M-ParquetClassLibrary-Maps-MapChunk-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-String,System-Int32,System-Collections-Generic-IEnumerable{ParquetClassLibrary-Maps-ExitPoint},ParquetClassLibrary-Parquets-ParquetStatusGrid,ParquetClassLibrary-Parquets-ParquetStackGrid- 'ParquetClassLibrary.Maps.MapChunk.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.String,System.Int32,System.Collections.Generic.IEnumerable{ParquetClassLibrary.Maps.ExitPoint},ParquetClassLibrary.Parquets.ParquetStatusGrid,ParquetClassLibrary.Parquets.ParquetStackGrid)')
  - [Empty](#F-ParquetClassLibrary-Maps-MapChunk-Empty 'ParquetClassLibrary.Maps.MapChunk.Empty')
  - [Bounds](#P-ParquetClassLibrary-Maps-MapChunk-Bounds 'ParquetClassLibrary.Maps.MapChunk.Bounds')
  - [DimensionsInParquets](#P-ParquetClassLibrary-Maps-MapChunk-DimensionsInParquets 'ParquetClassLibrary.Maps.MapChunk.DimensionsInParquets')
  - [ParquetDefinitions](#P-ParquetClassLibrary-Maps-MapChunk-ParquetDefinitions 'ParquetClassLibrary.Maps.MapChunk.ParquetDefinitions')
  - [ParquetStatuses](#P-ParquetClassLibrary-Maps-MapChunk-ParquetStatuses 'ParquetClassLibrary.Maps.MapChunk.ParquetStatuses')
  - [ToString()](#M-ParquetClassLibrary-Maps-MapChunk-ToString 'ParquetClassLibrary.Maps.MapChunk.ToString')
- [MapModel](#T-ParquetClassLibrary-Maps-MapModel 'ParquetClassLibrary.Maps.MapModel')
  - [#ctor(inBounds,inID,inName,inDescription,inComment,inDataVersion,inRevision,inExits)](#M-ParquetClassLibrary-Maps-MapModel-#ctor-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-String,System-Int32,System-Collections-Generic-IEnumerable{ParquetClassLibrary-Maps-ExitPoint}- 'ParquetClassLibrary.Maps.MapModel.#ctor(ParquetClassLibrary.Range{ParquetClassLibrary.ModelID},ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.String,System.Int32,System.Collections.Generic.IEnumerable{ParquetClassLibrary.Maps.ExitPoint})')
  - [DataVersion](#P-ParquetClassLibrary-Maps-MapModel-DataVersion 'ParquetClassLibrary.Maps.MapModel.DataVersion')
  - [DimensionsInParquets](#P-ParquetClassLibrary-Maps-MapModel-DimensionsInParquets 'ParquetClassLibrary.Maps.MapModel.DimensionsInParquets')
  - [Exits](#P-ParquetClassLibrary-Maps-MapModel-Exits 'ParquetClassLibrary.Maps.MapModel.Exits')
  - [ParquetDefinitions](#P-ParquetClassLibrary-Maps-MapModel-ParquetDefinitions 'ParquetClassLibrary.Maps.MapModel.ParquetDefinitions')
  - [ParquetStatuses](#P-ParquetClassLibrary-Maps-MapModel-ParquetStatuses 'ParquetClassLibrary.Maps.MapModel.ParquetStatuses')
  - [ParquetsCount](#P-ParquetClassLibrary-Maps-MapModel-ParquetsCount 'ParquetClassLibrary.Maps.MapModel.ParquetsCount')
  - [Revision](#P-ParquetClassLibrary-Maps-MapModel-Revision 'ParquetClassLibrary.Maps.MapModel.Revision')
  - [GetSubregion()](#M-ParquetClassLibrary-Maps-MapModel-GetSubregion 'ParquetClassLibrary.Maps.MapModel.GetSubregion')
  - [GetSubregion(inUpperLeft,inLowerRight)](#M-ParquetClassLibrary-Maps-MapModel-GetSubregion-ParquetClassLibrary-Vector2D,ParquetClassLibrary-Vector2D- 'ParquetClassLibrary.Maps.MapModel.GetSubregion(ParquetClassLibrary.Vector2D,ParquetClassLibrary.Vector2D)')
  - [IsValidPosition(inPosition)](#M-ParquetClassLibrary-Maps-MapModel-IsValidPosition-ParquetClassLibrary-Vector2D- 'ParquetClassLibrary.Maps.MapModel.IsValidPosition(ParquetClassLibrary.Vector2D)')
  - [ToString()](#M-ParquetClassLibrary-Maps-MapModel-ToString 'ParquetClassLibrary.Maps.MapModel.ToString')
- [MapRegion](#T-ParquetClassLibrary-Maps-MapRegion 'ParquetClassLibrary.Maps.MapRegion')
  - [#ctor(inID,inName,inDescription,inComment,inDataVersion,inRevision,inBackgroundColor,inElevationLocal,inElevationGlobal,inExits,inParquetStatuses,inParquetDefinitions)](#M-ParquetClassLibrary-Maps-MapRegion-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-String,System-Int32,System-String,ParquetClassLibrary-Biomes-Elevation,System-Int32,System-Collections-Generic-IEnumerable{ParquetClassLibrary-Maps-ExitPoint},ParquetClassLibrary-Parquets-ParquetStatusGrid,ParquetClassLibrary-Parquets-ParquetStackGrid- 'ParquetClassLibrary.Maps.MapRegion.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.String,System.Int32,System.String,ParquetClassLibrary.Biomes.Elevation,System.Int32,System.Collections.Generic.IEnumerable{ParquetClassLibrary.Maps.ExitPoint},ParquetClassLibrary.Parquets.ParquetStatusGrid,ParquetClassLibrary.Parquets.ParquetStackGrid)')
  - [DefaultColor](#F-ParquetClassLibrary-Maps-MapRegion-DefaultColor 'ParquetClassLibrary.Maps.MapRegion.DefaultColor')
  - [DefaultGlobalElevation](#F-ParquetClassLibrary-Maps-MapRegion-DefaultGlobalElevation 'ParquetClassLibrary.Maps.MapRegion.DefaultGlobalElevation')
  - [DefaultName](#F-ParquetClassLibrary-Maps-MapRegion-DefaultName 'ParquetClassLibrary.Maps.MapRegion.DefaultName')
  - [Empty](#F-ParquetClassLibrary-Maps-MapRegion-Empty 'ParquetClassLibrary.Maps.MapRegion.Empty')
  - [BackgroundColor](#P-ParquetClassLibrary-Maps-MapRegion-BackgroundColor 'ParquetClassLibrary.Maps.MapRegion.BackgroundColor')
  - [Bounds](#P-ParquetClassLibrary-Maps-MapRegion-Bounds 'ParquetClassLibrary.Maps.MapRegion.Bounds')
  - [DimensionsInParquets](#P-ParquetClassLibrary-Maps-MapRegion-DimensionsInParquets 'ParquetClassLibrary.Maps.MapRegion.DimensionsInParquets')
  - [ElevationGlobal](#P-ParquetClassLibrary-Maps-MapRegion-ElevationGlobal 'ParquetClassLibrary.Maps.MapRegion.ElevationGlobal')
  - [ElevationLocal](#P-ParquetClassLibrary-Maps-MapRegion-ElevationLocal 'ParquetClassLibrary.Maps.MapRegion.ElevationLocal')
  - [ParquetClassLibrary#Maps#IMapRegionEdit#BackgroundColor](#P-ParquetClassLibrary-Maps-MapRegion-ParquetClassLibrary#Maps#IMapRegionEdit#BackgroundColor 'ParquetClassLibrary.Maps.MapRegion.ParquetClassLibrary#Maps#IMapRegionEdit#BackgroundColor')
  - [ParquetClassLibrary#Maps#IMapRegionEdit#ElevationGlobal](#P-ParquetClassLibrary-Maps-MapRegion-ParquetClassLibrary#Maps#IMapRegionEdit#ElevationGlobal 'ParquetClassLibrary.Maps.MapRegion.ParquetClassLibrary#Maps#IMapRegionEdit#ElevationGlobal')
  - [ParquetClassLibrary#Maps#IMapRegionEdit#ElevationLocal](#P-ParquetClassLibrary-Maps-MapRegion-ParquetClassLibrary#Maps#IMapRegionEdit#ElevationLocal 'ParquetClassLibrary.Maps.MapRegion.ParquetClassLibrary#Maps#IMapRegionEdit#ElevationLocal')
  - [ParquetClassLibrary#Maps#IMapRegionEdit#Name](#P-ParquetClassLibrary-Maps-MapRegion-ParquetClassLibrary#Maps#IMapRegionEdit#Name 'ParquetClassLibrary.Maps.MapRegion.ParquetClassLibrary#Maps#IMapRegionEdit#Name')
  - [ParquetDefinitions](#P-ParquetClassLibrary-Maps-MapRegion-ParquetDefinitions 'ParquetClassLibrary.Maps.MapRegion.ParquetDefinitions')
  - [ParquetStatuses](#P-ParquetClassLibrary-Maps-MapRegion-ParquetStatuses 'ParquetClassLibrary.Maps.MapRegion.ParquetStatuses')
  - [ToString()](#M-ParquetClassLibrary-Maps-MapRegion-ToString 'ParquetClassLibrary.Maps.MapRegion.ToString')
- [MapRegionSketch](#T-ParquetClassLibrary-Maps-MapRegionSketch 'ParquetClassLibrary.Maps.MapRegionSketch')
  - [#ctor(inID,inName,inDescription,inComment,inDataVersion,inRevision,inBackgroundColor,inElevationLocal,inElevationGlobal,inExits,inChunks)](#M-ParquetClassLibrary-Maps-MapRegionSketch-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-String,System-Int32,System-String,ParquetClassLibrary-Biomes-Elevation,System-Int32,System-Collections-Generic-IEnumerable{ParquetClassLibrary-Maps-ExitPoint},ParquetClassLibrary-Maps-ChunkTypeGrid- 'ParquetClassLibrary.Maps.MapRegionSketch.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.String,System.Int32,System.String,ParquetClassLibrary.Biomes.Elevation,System.Int32,System.Collections.Generic.IEnumerable{ParquetClassLibrary.Maps.ExitPoint},ParquetClassLibrary.Maps.ChunkTypeGrid)')
  - [DefaultColor](#F-ParquetClassLibrary-Maps-MapRegionSketch-DefaultColor 'ParquetClassLibrary.Maps.MapRegionSketch.DefaultColor')
  - [DefaultGlobalElevation](#F-ParquetClassLibrary-Maps-MapRegionSketch-DefaultGlobalElevation 'ParquetClassLibrary.Maps.MapRegionSketch.DefaultGlobalElevation')
  - [DefaultTitle](#F-ParquetClassLibrary-Maps-MapRegionSketch-DefaultTitle 'ParquetClassLibrary.Maps.MapRegionSketch.DefaultTitle')
  - [Empty](#F-ParquetClassLibrary-Maps-MapRegionSketch-Empty 'ParquetClassLibrary.Maps.MapRegionSketch.Empty')
  - [BackgroundColor](#P-ParquetClassLibrary-Maps-MapRegionSketch-BackgroundColor 'ParquetClassLibrary.Maps.MapRegionSketch.BackgroundColor')
  - [Bounds](#P-ParquetClassLibrary-Maps-MapRegionSketch-Bounds 'ParquetClassLibrary.Maps.MapRegionSketch.Bounds')
  - [Chunks](#P-ParquetClassLibrary-Maps-MapRegionSketch-Chunks 'ParquetClassLibrary.Maps.MapRegionSketch.Chunks')
  - [DimensionsInParquets](#P-ParquetClassLibrary-Maps-MapRegionSketch-DimensionsInParquets 'ParquetClassLibrary.Maps.MapRegionSketch.DimensionsInParquets')
  - [ElevationGlobal](#P-ParquetClassLibrary-Maps-MapRegionSketch-ElevationGlobal 'ParquetClassLibrary.Maps.MapRegionSketch.ElevationGlobal')
  - [ElevationLocal](#P-ParquetClassLibrary-Maps-MapRegionSketch-ElevationLocal 'ParquetClassLibrary.Maps.MapRegionSketch.ElevationLocal')
  - [ParquetClassLibrary#Maps#IMapRegionEdit#BackgroundColor](#P-ParquetClassLibrary-Maps-MapRegionSketch-ParquetClassLibrary#Maps#IMapRegionEdit#BackgroundColor 'ParquetClassLibrary.Maps.MapRegionSketch.ParquetClassLibrary#Maps#IMapRegionEdit#BackgroundColor')
  - [ParquetClassLibrary#Maps#IMapRegionEdit#ElevationGlobal](#P-ParquetClassLibrary-Maps-MapRegionSketch-ParquetClassLibrary#Maps#IMapRegionEdit#ElevationGlobal 'ParquetClassLibrary.Maps.MapRegionSketch.ParquetClassLibrary#Maps#IMapRegionEdit#ElevationGlobal')
  - [ParquetClassLibrary#Maps#IMapRegionEdit#ElevationLocal](#P-ParquetClassLibrary-Maps-MapRegionSketch-ParquetClassLibrary#Maps#IMapRegionEdit#ElevationLocal 'ParquetClassLibrary.Maps.MapRegionSketch.ParquetClassLibrary#Maps#IMapRegionEdit#ElevationLocal')
  - [ParquetClassLibrary#Maps#IMapRegionEdit#Name](#P-ParquetClassLibrary-Maps-MapRegionSketch-ParquetClassLibrary#Maps#IMapRegionEdit#Name 'ParquetClassLibrary.Maps.MapRegionSketch.ParquetClassLibrary#Maps#IMapRegionEdit#Name')
  - [ParquetDefinitions](#P-ParquetClassLibrary-Maps-MapRegionSketch-ParquetDefinitions 'ParquetClassLibrary.Maps.MapRegionSketch.ParquetDefinitions')
  - [ParquetStatuses](#P-ParquetClassLibrary-Maps-MapRegionSketch-ParquetStatuses 'ParquetClassLibrary.Maps.MapRegionSketch.ParquetStatuses')
  - [ToString()](#M-ParquetClassLibrary-Maps-MapRegionSketch-ToString 'ParquetClassLibrary.Maps.MapRegionSketch.ToString')
- [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace')
  - [#ctor(inPosition,inContent,inSubregion)](#M-ParquetClassLibrary-Rooms-MapSpace-#ctor-ParquetClassLibrary-Vector2D,ParquetClassLibrary-Parquets-ParquetStack,ParquetClassLibrary-Parquets-ParquetStackGrid- 'ParquetClassLibrary.Rooms.MapSpace.#ctor(ParquetClassLibrary.Vector2D,ParquetClassLibrary.Parquets.ParquetStack,ParquetClassLibrary.Parquets.ParquetStackGrid)')
  - [#ctor(inX,inY,inContent,inSubregion)](#M-ParquetClassLibrary-Rooms-MapSpace-#ctor-System-Int32,System-Int32,ParquetClassLibrary-Parquets-ParquetStack,ParquetClassLibrary-Parquets-ParquetStackGrid- 'ParquetClassLibrary.Rooms.MapSpace.#ctor(System.Int32,System.Int32,ParquetClassLibrary.Parquets.ParquetStack,ParquetClassLibrary.Parquets.ParquetStackGrid)')
  - [Empty](#F-ParquetClassLibrary-Rooms-MapSpace-Empty 'ParquetClassLibrary.Rooms.MapSpace.Empty')
  - [Content](#P-ParquetClassLibrary-Rooms-MapSpace-Content 'ParquetClassLibrary.Rooms.MapSpace.Content')
  - [IsEmpty](#P-ParquetClassLibrary-Rooms-MapSpace-IsEmpty 'ParquetClassLibrary.Rooms.MapSpace.IsEmpty')
  - [IsEnclosing](#P-ParquetClassLibrary-Rooms-MapSpace-IsEnclosing 'ParquetClassLibrary.Rooms.MapSpace.IsEnclosing')
  - [IsEntry](#P-ParquetClassLibrary-Rooms-MapSpace-IsEntry 'ParquetClassLibrary.Rooms.MapSpace.IsEntry')
  - [IsWalkable](#P-ParquetClassLibrary-Rooms-MapSpace-IsWalkable 'ParquetClassLibrary.Rooms.MapSpace.IsWalkable')
  - [IsWalkableEntry](#P-ParquetClassLibrary-Rooms-MapSpace-IsWalkableEntry 'ParquetClassLibrary.Rooms.MapSpace.IsWalkableEntry')
  - [Position](#P-ParquetClassLibrary-Rooms-MapSpace-Position 'ParquetClassLibrary.Rooms.MapSpace.Position')
  - [Subregion](#P-ParquetClassLibrary-Rooms-MapSpace-Subregion 'ParquetClassLibrary.Rooms.MapSpace.Subregion')
  - [EastNeighbor()](#M-ParquetClassLibrary-Rooms-MapSpace-EastNeighbor 'ParquetClassLibrary.Rooms.MapSpace.EastNeighbor')
  - [Equals(inSpace)](#M-ParquetClassLibrary-Rooms-MapSpace-Equals-ParquetClassLibrary-Rooms-MapSpace- 'ParquetClassLibrary.Rooms.MapSpace.Equals(ParquetClassLibrary.Rooms.MapSpace)')
  - [Equals(obj)](#M-ParquetClassLibrary-Rooms-MapSpace-Equals-System-Object- 'ParquetClassLibrary.Rooms.MapSpace.Equals(System.Object)')
  - [GetHashCode()](#M-ParquetClassLibrary-Rooms-MapSpace-GetHashCode 'ParquetClassLibrary.Rooms.MapSpace.GetHashCode')
  - [IsEnclosingEntry(inWalkableArea)](#M-ParquetClassLibrary-Rooms-MapSpace-IsEnclosingEntry-ParquetClassLibrary-Rooms-MapSpaceCollection- 'ParquetClassLibrary.Rooms.MapSpace.IsEnclosingEntry(ParquetClassLibrary.Rooms.MapSpaceCollection)')
  - [Neighbor()](#M-ParquetClassLibrary-Rooms-MapSpace-Neighbor-ParquetClassLibrary-Vector2D- 'ParquetClassLibrary.Rooms.MapSpace.Neighbor(ParquetClassLibrary.Vector2D)')
  - [Neighbors()](#M-ParquetClassLibrary-Rooms-MapSpace-Neighbors 'ParquetClassLibrary.Rooms.MapSpace.Neighbors')
  - [NorthNeighbor()](#M-ParquetClassLibrary-Rooms-MapSpace-NorthNeighbor 'ParquetClassLibrary.Rooms.MapSpace.NorthNeighbor')
  - [SouthNeighbor()](#M-ParquetClassLibrary-Rooms-MapSpace-SouthNeighbor 'ParquetClassLibrary.Rooms.MapSpace.SouthNeighbor')
  - [ToString()](#M-ParquetClassLibrary-Rooms-MapSpace-ToString 'ParquetClassLibrary.Rooms.MapSpace.ToString')
  - [WestNeighbor()](#M-ParquetClassLibrary-Rooms-MapSpace-WestNeighbor 'ParquetClassLibrary.Rooms.MapSpace.WestNeighbor')
  - [op_Equality(inSpace1,inSpace2)](#M-ParquetClassLibrary-Rooms-MapSpace-op_Equality-ParquetClassLibrary-Rooms-MapSpace,ParquetClassLibrary-Rooms-MapSpace- 'ParquetClassLibrary.Rooms.MapSpace.op_Equality(ParquetClassLibrary.Rooms.MapSpace,ParquetClassLibrary.Rooms.MapSpace)')
  - [op_Inequality(inSpace1,inSpace2)](#M-ParquetClassLibrary-Rooms-MapSpace-op_Inequality-ParquetClassLibrary-Rooms-MapSpace,ParquetClassLibrary-Rooms-MapSpace- 'ParquetClassLibrary.Rooms.MapSpace.op_Inequality(ParquetClassLibrary.Rooms.MapSpace,ParquetClassLibrary.Rooms.MapSpace)')
- [MapSpaceCollection](#T-ParquetClassLibrary-Rooms-MapSpaceCollection 'ParquetClassLibrary.Rooms.MapSpaceCollection')
  - [#ctor(inSpaces)](#M-ParquetClassLibrary-Rooms-MapSpaceCollection-#ctor-System-Collections-Generic-IEnumerable{ParquetClassLibrary-Rooms-MapSpace}- 'ParquetClassLibrary.Rooms.MapSpaceCollection.#ctor(System.Collections.Generic.IEnumerable{ParquetClassLibrary.Rooms.MapSpace})')
  - [Count](#P-ParquetClassLibrary-Rooms-MapSpaceCollection-Count 'ParquetClassLibrary.Rooms.MapSpaceCollection.Count')
  - [Empty](#P-ParquetClassLibrary-Rooms-MapSpaceCollection-Empty 'ParquetClassLibrary.Rooms.MapSpaceCollection.Empty')
  - [First](#P-ParquetClassLibrary-Rooms-MapSpaceCollection-First 'ParquetClassLibrary.Rooms.MapSpaceCollection.First')
  - [Spaces](#P-ParquetClassLibrary-Rooms-MapSpaceCollection-Spaces 'ParquetClassLibrary.Rooms.MapSpaceCollection.Spaces')
  - [AllSpacesAreReachable(inIsApplicable)](#M-ParquetClassLibrary-Rooms-MapSpaceCollection-AllSpacesAreReachable-System-Predicate{ParquetClassLibrary-Rooms-MapSpace}- 'ParquetClassLibrary.Rooms.MapSpaceCollection.AllSpacesAreReachable(System.Predicate{ParquetClassLibrary.Rooms.MapSpace})')
  - [AllSpacesAreReachableAndCycleExists(inIsApplicable)](#M-ParquetClassLibrary-Rooms-MapSpaceCollection-AllSpacesAreReachableAndCycleExists-System-Predicate{ParquetClassLibrary-Rooms-MapSpace}- 'ParquetClassLibrary.Rooms.MapSpaceCollection.AllSpacesAreReachableAndCycleExists(System.Predicate{ParquetClassLibrary.Rooms.MapSpace})')
  - [Contains(inSpace)](#M-ParquetClassLibrary-Rooms-MapSpaceCollection-Contains-ParquetClassLibrary-Rooms-MapSpace- 'ParquetClassLibrary.Rooms.MapSpaceCollection.Contains(ParquetClassLibrary.Rooms.MapSpace)')
  - [GetEnumerator()](#M-ParquetClassLibrary-Rooms-MapSpaceCollection-GetEnumerator 'ParquetClassLibrary.Rooms.MapSpaceCollection.GetEnumerator')
  - [Search(inStart,inIsApplicable,inIsGoal)](#M-ParquetClassLibrary-Rooms-MapSpaceCollection-Search-ParquetClassLibrary-Rooms-MapSpace,System-Predicate{ParquetClassLibrary-Rooms-MapSpace},System-Predicate{ParquetClassLibrary-Rooms-MapSpace}- 'ParquetClassLibrary.Rooms.MapSpaceCollection.Search(ParquetClassLibrary.Rooms.MapSpace,System.Predicate{ParquetClassLibrary.Rooms.MapSpace},System.Predicate{ParquetClassLibrary.Rooms.MapSpace})')
  - [SetEquals(inEqualTo)](#M-ParquetClassLibrary-Rooms-MapSpaceCollection-SetEquals-ParquetClassLibrary-Rooms-MapSpaceCollection- 'ParquetClassLibrary.Rooms.MapSpaceCollection.SetEquals(ParquetClassLibrary.Rooms.MapSpaceCollection)')
  - [System#Collections#Generic#IEnumerable{ParquetClassLibrary#Rooms#MapSpace}#GetEnumerator()](#M-ParquetClassLibrary-Rooms-MapSpaceCollection-System#Collections#Generic#IEnumerable{ParquetClassLibrary#Rooms#MapSpace}#GetEnumerator 'ParquetClassLibrary.Rooms.MapSpaceCollection.System#Collections#Generic#IEnumerable{ParquetClassLibrary#Rooms#MapSpace}#GetEnumerator')
  - [ToString()](#M-ParquetClassLibrary-Rooms-MapSpaceCollection-ToString 'ParquetClassLibrary.Rooms.MapSpaceCollection.ToString')
  - [TryGetPerimeter(outPerimeter)](#M-ParquetClassLibrary-Rooms-MapSpaceCollection-TryGetPerimeter-ParquetClassLibrary-Rooms-MapSpaceCollection@- 'ParquetClassLibrary.Rooms.MapSpaceCollection.TryGetPerimeter(ParquetClassLibrary.Rooms.MapSpaceCollection@)')
  - [op_Implicit(inSpaces)](#M-ParquetClassLibrary-Rooms-MapSpaceCollection-op_Implicit-ParquetClassLibrary-Rooms-MapSpaceCollection-~System-Collections-Generic-HashSet{ParquetClassLibrary-Rooms-MapSpace} 'ParquetClassLibrary.Rooms.MapSpaceCollection.op_Implicit(ParquetClassLibrary.Rooms.MapSpaceCollection)~System.Collections.Generic.HashSet{ParquetClassLibrary.Rooms.MapSpace}')
  - [op_Implicit(inSpaces)](#M-ParquetClassLibrary-Rooms-MapSpaceCollection-op_Implicit-System-Collections-Generic-HashSet{ParquetClassLibrary-Rooms-MapSpace}-~ParquetClassLibrary-Rooms-MapSpaceCollection 'ParquetClassLibrary.Rooms.MapSpaceCollection.op_Implicit(System.Collections.Generic.HashSet{ParquetClassLibrary.Rooms.MapSpace})~ParquetClassLibrary.Rooms.MapSpaceCollection')
- [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model')
  - [#ctor(inBounds,inID,inName,inDescription,inComment)](#M-ParquetClassLibrary-Model-#ctor-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},ParquetClassLibrary-ModelID,System-String,System-String,System-String- 'ParquetClassLibrary.Model.#ctor(ParquetClassLibrary.Range{ParquetClassLibrary.ModelID},ParquetClassLibrary.ModelID,System.String,System.String,System.String)')
  - [Comment](#P-ParquetClassLibrary-Model-Comment 'ParquetClassLibrary.Model.Comment')
  - [Description](#P-ParquetClassLibrary-Model-Description 'ParquetClassLibrary.Model.Description')
  - [ID](#P-ParquetClassLibrary-Model-ID 'ParquetClassLibrary.Model.ID')
  - [Name](#P-ParquetClassLibrary-Model-Name 'ParquetClassLibrary.Model.Name')
  - [ParquetClassLibrary#IModelEdit#Comment](#P-ParquetClassLibrary-Model-ParquetClassLibrary#IModelEdit#Comment 'ParquetClassLibrary.Model.ParquetClassLibrary#IModelEdit#Comment')
  - [ParquetClassLibrary#IModelEdit#Description](#P-ParquetClassLibrary-Model-ParquetClassLibrary#IModelEdit#Description 'ParquetClassLibrary.Model.ParquetClassLibrary#IModelEdit#Description')
  - [ParquetClassLibrary#IModelEdit#Name](#P-ParquetClassLibrary-Model-ParquetClassLibrary#IModelEdit#Name 'ParquetClassLibrary.Model.ParquetClassLibrary#IModelEdit#Name')
  - [Equals(inModel)](#M-ParquetClassLibrary-Model-Equals-ParquetClassLibrary-Model- 'ParquetClassLibrary.Model.Equals(ParquetClassLibrary.Model)')
  - [Equals(obj)](#M-ParquetClassLibrary-Model-Equals-System-Object- 'ParquetClassLibrary.Model.Equals(System.Object)')
  - [GetAllTags()](#M-ParquetClassLibrary-Model-GetAllTags 'ParquetClassLibrary.Model.GetAllTags')
  - [GetHashCode()](#M-ParquetClassLibrary-Model-GetHashCode 'ParquetClassLibrary.Model.GetHashCode')
  - [ToString()](#M-ParquetClassLibrary-Model-ToString 'ParquetClassLibrary.Model.ToString')
  - [op_Equality(inModel1,inModel2)](#M-ParquetClassLibrary-Model-op_Equality-ParquetClassLibrary-Model,ParquetClassLibrary-Model- 'ParquetClassLibrary.Model.op_Equality(ParquetClassLibrary.Model,ParquetClassLibrary.Model)')
  - [op_Inequality(inModel1,inModel2)](#M-ParquetClassLibrary-Model-op_Inequality-ParquetClassLibrary-Model,ParquetClassLibrary-Model- 'ParquetClassLibrary.Model.op_Inequality(ParquetClassLibrary.Model,ParquetClassLibrary.Model)')
- [ModelCollection](#T-ParquetClassLibrary-ModelCollection 'ParquetClassLibrary.ModelCollection')
  - [#ctor(inBounds,inModels)](#M-ParquetClassLibrary-ModelCollection-#ctor-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Model}- 'ParquetClassLibrary.ModelCollection.#ctor(ParquetClassLibrary.Range{ParquetClassLibrary.ModelID},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Model})')
  - [#ctor(inBounds,inModels)](#M-ParquetClassLibrary-ModelCollection-#ctor-System-Collections-Generic-IEnumerable{ParquetClassLibrary-Range{ParquetClassLibrary-ModelID}},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Model}- 'ParquetClassLibrary.ModelCollection.#ctor(System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Model})')
  - [Default](#F-ParquetClassLibrary-ModelCollection-Default 'ParquetClassLibrary.ModelCollection.Default')
  - [Get(inID)](#M-ParquetClassLibrary-ModelCollection-Get-ParquetClassLibrary-ModelID- 'ParquetClassLibrary.ModelCollection.Get(ParquetClassLibrary.ModelID)')
  - [GetFilePath\`\`1()](#M-ParquetClassLibrary-ModelCollection-GetFilePath``1 'ParquetClassLibrary.ModelCollection.GetFilePath``1')
- [ModelCollection\`1](#T-ParquetClassLibrary-ModelCollection`1 'ParquetClassLibrary.ModelCollection`1')
  - [#ctor(inBounds,inModels)](#M-ParquetClassLibrary-ModelCollection`1-#ctor-System-Collections-Generic-IEnumerable{ParquetClassLibrary-Range{ParquetClassLibrary-ModelID}},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Model}- 'ParquetClassLibrary.ModelCollection`1.#ctor(System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Model})')
  - [#ctor(inBounds,inModels)](#M-ParquetClassLibrary-ModelCollection`1-#ctor-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Model}- 'ParquetClassLibrary.ModelCollection`1.#ctor(ParquetClassLibrary.Range{ParquetClassLibrary.ModelID},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Model})')
  - [Default](#F-ParquetClassLibrary-ModelCollection`1-Default 'ParquetClassLibrary.ModelCollection`1.Default')
  - [Bounds](#P-ParquetClassLibrary-ModelCollection`1-Bounds 'ParquetClassLibrary.ModelCollection`1.Bounds')
  - [ConverterFactory](#P-ParquetClassLibrary-ModelCollection`1-ConverterFactory 'ParquetClassLibrary.ModelCollection`1.ConverterFactory')
  - [Count](#P-ParquetClassLibrary-ModelCollection`1-Count 'ParquetClassLibrary.ModelCollection`1.Count')
  - [Models](#P-ParquetClassLibrary-ModelCollection`1-Models 'ParquetClassLibrary.ModelCollection`1.Models')
  - [AssignMissingIDs\`\`1(inModelsWithOldIDs,inRecordsNeedingIDs)](#M-ParquetClassLibrary-ModelCollection`1-AssignMissingIDs``1-System-Collections-Generic-List{``0},System-Text-StringBuilder- 'ParquetClassLibrary.ModelCollection`1.AssignMissingIDs``1(System.Collections.Generic.List{``0},System.Text.StringBuilder)')
  - [ConfigureCSVReader(inReader)](#M-ParquetClassLibrary-ModelCollection`1-ConfigureCSVReader-System-IO-TextReader- 'ParquetClassLibrary.ModelCollection`1.ConfigureCSVReader(System.IO.TextReader)')
  - [Contains(inModel)](#M-ParquetClassLibrary-ModelCollection`1-Contains-ParquetClassLibrary-Model- 'ParquetClassLibrary.ModelCollection`1.Contains(ParquetClassLibrary.Model)')
  - [Contains(inID)](#M-ParquetClassLibrary-ModelCollection`1-Contains-ParquetClassLibrary-ModelID- 'ParquetClassLibrary.ModelCollection`1.Contains(ParquetClassLibrary.ModelID)')
  - [GetEnumerator()](#M-ParquetClassLibrary-ModelCollection`1-GetEnumerator 'ParquetClassLibrary.ModelCollection`1.GetEnumerator')
  - [GetRecordsForType\`\`1(inBounds)](#M-ParquetClassLibrary-ModelCollection`1-GetRecordsForType``1-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID}- 'ParquetClassLibrary.ModelCollection`1.GetRecordsForType``1(ParquetClassLibrary.Range{ParquetClassLibrary.ModelID})')
  - [GetRecordsForType\`\`1(inBounds)](#M-ParquetClassLibrary-ModelCollection`1-GetRecordsForType``1-System-Collections-Generic-IEnumerable{ParquetClassLibrary-Range{ParquetClassLibrary-ModelID}}- 'ParquetClassLibrary.ModelCollection`1.GetRecordsForType``1(System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}})')
  - [Get\`\`1(inID)](#M-ParquetClassLibrary-ModelCollection`1-Get``1-ParquetClassLibrary-ModelID- 'ParquetClassLibrary.ModelCollection`1.Get``1(ParquetClassLibrary.ModelID)')
  - [HandleUnassignedIDs\`\`1(inColumnHeaders,inModels)](#M-ParquetClassLibrary-ModelCollection`1-HandleUnassignedIDs``1-System-String[],System-Collections-Generic-List{``0}- 'ParquetClassLibrary.ModelCollection`1.HandleUnassignedIDs``1(System.String[],System.Collections.Generic.List{``0})')
  - [PutRecordsForType\`\`1()](#M-ParquetClassLibrary-ModelCollection`1-PutRecordsForType``1 'ParquetClassLibrary.ModelCollection`1.PutRecordsForType``1')
  - [ReconstructHeader(inColumnHeaders,inRecordsWithNewIDs)](#M-ParquetClassLibrary-ModelCollection`1-ReconstructHeader-System-String[],System-Text-StringBuilder- 'ParquetClassLibrary.ModelCollection`1.ReconstructHeader(System.String[],System.Text.StringBuilder)')
  - [RemoveHeaderPrefix(inHeaderText,inHeaderIndex)](#M-ParquetClassLibrary-ModelCollection`1-RemoveHeaderPrefix-System-String,System-Int32- 'ParquetClassLibrary.ModelCollection`1.RemoveHeaderPrefix(System.String,System.Int32)')
  - [System#Collections#Generic#IEnumerable{TModel}#GetEnumerator()](#M-ParquetClassLibrary-ModelCollection`1-System#Collections#Generic#IEnumerable{TModel}#GetEnumerator 'ParquetClassLibrary.ModelCollection`1.System#Collections#Generic#IEnumerable{TModel}#GetEnumerator')
  - [System#Collections#IEnumerable#GetEnumerator()](#M-ParquetClassLibrary-ModelCollection`1-System#Collections#IEnumerable#GetEnumerator 'ParquetClassLibrary.ModelCollection`1.System#Collections#IEnumerable#GetEnumerator')
  - [ToString()](#M-ParquetClassLibrary-ModelCollection`1-ToString 'ParquetClassLibrary.ModelCollection`1.ToString')
- [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')
  - [None](#F-ParquetClassLibrary-ModelID-None 'ParquetClassLibrary.ModelID.None')
  - [RecordsWithMissingIDs](#F-ParquetClassLibrary-ModelID-RecordsWithMissingIDs 'ParquetClassLibrary.ModelID.RecordsWithMissingIDs')
  - [id](#F-ParquetClassLibrary-ModelID-id 'ParquetClassLibrary.ModelID.id')
  - [ConverterFactory](#P-ParquetClassLibrary-ModelID-ConverterFactory 'ParquetClassLibrary.ModelID.ConverterFactory')
  - [CompareTo(inIDentifier)](#M-ParquetClassLibrary-ModelID-CompareTo-ParquetClassLibrary-ModelID- 'ParquetClassLibrary.ModelID.CompareTo(ParquetClassLibrary.ModelID)')
  - [ConvertFromString(inText,inRow,inMemberMapData)](#M-ParquetClassLibrary-ModelID-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData- 'ParquetClassLibrary.ModelID.ConvertFromString(System.String,CsvHelper.IReaderRow,CsvHelper.Configuration.MemberMapData)')
  - [ConvertToString(inValue,inRow,inMemberMapData)](#M-ParquetClassLibrary-ModelID-ConvertToString-System-Object,CsvHelper-IWriterRow,CsvHelper-Configuration-MemberMapData- 'ParquetClassLibrary.ModelID.ConvertToString(System.Object,CsvHelper.IWriterRow,CsvHelper.Configuration.MemberMapData)')
  - [Equals(inIDentifier)](#M-ParquetClassLibrary-ModelID-Equals-ParquetClassLibrary-ModelID- 'ParquetClassLibrary.ModelID.Equals(ParquetClassLibrary.ModelID)')
  - [Equals(obj)](#M-ParquetClassLibrary-ModelID-Equals-System-Object- 'ParquetClassLibrary.ModelID.Equals(System.Object)')
  - [GetHashCode()](#M-ParquetClassLibrary-ModelID-GetHashCode 'ParquetClassLibrary.ModelID.GetHashCode')
  - [IsValidForRange(inRange)](#M-ParquetClassLibrary-ModelID-IsValidForRange-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID}- 'ParquetClassLibrary.ModelID.IsValidForRange(ParquetClassLibrary.Range{ParquetClassLibrary.ModelID})')
  - [IsValidForRange(inRanges)](#M-ParquetClassLibrary-ModelID-IsValidForRange-System-Collections-Generic-IEnumerable{ParquetClassLibrary-Range{ParquetClassLibrary-ModelID}}- 'ParquetClassLibrary.ModelID.IsValidForRange(System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}})')
  - [RegisterMissingID(inRawRecord)](#M-ParquetClassLibrary-ModelID-RegisterMissingID-System-String- 'ParquetClassLibrary.ModelID.RegisterMissingID(System.String)')
  - [ToString()](#M-ParquetClassLibrary-ModelID-ToString 'ParquetClassLibrary.ModelID.ToString')
  - [op_Equality(inIDentifier1,inIDentifier2)](#M-ParquetClassLibrary-ModelID-op_Equality-ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID- 'ParquetClassLibrary.ModelID.op_Equality(ParquetClassLibrary.ModelID,ParquetClassLibrary.ModelID)')
  - [op_GreaterThan(inIDentifier1,inIDentifier2)](#M-ParquetClassLibrary-ModelID-op_GreaterThan-ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID- 'ParquetClassLibrary.ModelID.op_GreaterThan(ParquetClassLibrary.ModelID,ParquetClassLibrary.ModelID)')
  - [op_GreaterThanOrEqual(inIDentifier1,inIDentifier2)](#M-ParquetClassLibrary-ModelID-op_GreaterThanOrEqual-ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID- 'ParquetClassLibrary.ModelID.op_GreaterThanOrEqual(ParquetClassLibrary.ModelID,ParquetClassLibrary.ModelID)')
  - [op_Implicit(inValue)](#M-ParquetClassLibrary-ModelID-op_Implicit-System-Int32-~ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID.op_Implicit(System.Int32)~ParquetClassLibrary.ModelID')
  - [op_Implicit(inIDentifier)](#M-ParquetClassLibrary-ModelID-op_Implicit-ParquetClassLibrary-ModelID-~System-Int32 'ParquetClassLibrary.ModelID.op_Implicit(ParquetClassLibrary.ModelID)~System.Int32')
  - [op_Inequality(inIDentifier1,inIDentifier2)](#M-ParquetClassLibrary-ModelID-op_Inequality-ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID- 'ParquetClassLibrary.ModelID.op_Inequality(ParquetClassLibrary.ModelID,ParquetClassLibrary.ModelID)')
  - [op_LessThan(inIDentifier1,inIDentifier2)](#M-ParquetClassLibrary-ModelID-op_LessThan-ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID- 'ParquetClassLibrary.ModelID.op_LessThan(ParquetClassLibrary.ModelID,ParquetClassLibrary.ModelID)')
  - [op_LessThanOrEqual(inIDentifier1,inIDentifier2)](#M-ParquetClassLibrary-ModelID-op_LessThanOrEqual-ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID- 'ParquetClassLibrary.ModelID.op_LessThanOrEqual(ParquetClassLibrary.ModelID,ParquetClassLibrary.ModelID)')
- [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag')
  - [None](#F-ParquetClassLibrary-ModelTag-None 'ParquetClassLibrary.ModelTag.None')
  - [tagContent](#F-ParquetClassLibrary-ModelTag-tagContent 'ParquetClassLibrary.ModelTag.tagContent')
  - [ConverterFactory](#P-ParquetClassLibrary-ModelTag-ConverterFactory 'ParquetClassLibrary.ModelTag.ConverterFactory')
  - [CompareTo(inTag)](#M-ParquetClassLibrary-ModelTag-CompareTo-ParquetClassLibrary-ModelTag- 'ParquetClassLibrary.ModelTag.CompareTo(ParquetClassLibrary.ModelTag)')
  - [ConvertFromString(inText,inRow,inMemberMapData)](#M-ParquetClassLibrary-ModelTag-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData- 'ParquetClassLibrary.ModelTag.ConvertFromString(System.String,CsvHelper.IReaderRow,CsvHelper.Configuration.MemberMapData)')
  - [ConvertToString(inValue,inRow,inMemberMapData)](#M-ParquetClassLibrary-ModelTag-ConvertToString-System-Object,CsvHelper-IWriterRow,CsvHelper-Configuration-MemberMapData- 'ParquetClassLibrary.ModelTag.ConvertToString(System.Object,CsvHelper.IWriterRow,CsvHelper.Configuration.MemberMapData)')
  - [ToString()](#M-ParquetClassLibrary-ModelTag-ToString 'ParquetClassLibrary.ModelTag.ToString')
  - [op_Implicit(inValue)](#M-ParquetClassLibrary-ModelTag-op_Implicit-System-String-~ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag.op_Implicit(System.String)~ParquetClassLibrary.ModelTag')
  - [op_Implicit(inTag)](#M-ParquetClassLibrary-ModelTag-op_Implicit-ParquetClassLibrary-ModelTag-~System-String 'ParquetClassLibrary.ModelTag.op_Implicit(ParquetClassLibrary.ModelTag)~System.String')
- [ModificationTool](#T-ParquetClassLibrary-Items-ModificationTool 'ParquetClassLibrary.Items.ModificationTool')
  - [Hammer](#F-ParquetClassLibrary-Items-ModificationTool-Hammer 'ParquetClassLibrary.Items.ModificationTool.Hammer')
  - [None](#F-ParquetClassLibrary-Items-ModificationTool-None 'ParquetClassLibrary.Items.ModificationTool.None')
  - [Shovel](#F-ParquetClassLibrary-Items-ModificationTool-Shovel 'ParquetClassLibrary.Items.ModificationTool.Shovel')
- [ParquetModel](#T-ParquetClassLibrary-Parquets-ParquetModel 'ParquetClassLibrary.Parquets.ParquetModel')
  - [#ctor(inBounds,inID,inName,inDescription,inComment,inItemID,inAddsToBiome,inAddsToRoom)](#M-ParquetClassLibrary-Parquets-ParquetModel-#ctor-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},ParquetClassLibrary-ModelID,System-String,System-String,System-String,ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelTag,ParquetClassLibrary-ModelTag- 'ParquetClassLibrary.Parquets.ParquetModel.#ctor(ParquetClassLibrary.Range{ParquetClassLibrary.ModelID},ParquetClassLibrary.ModelID,System.String,System.String,System.String,ParquetClassLibrary.ModelID,ParquetClassLibrary.ModelTag,ParquetClassLibrary.ModelTag)')
  - [AddsToBiome](#P-ParquetClassLibrary-Parquets-ParquetModel-AddsToBiome 'ParquetClassLibrary.Parquets.ParquetModel.AddsToBiome')
  - [AddsToRoom](#P-ParquetClassLibrary-Parquets-ParquetModel-AddsToRoom 'ParquetClassLibrary.Parquets.ParquetModel.AddsToRoom')
  - [ItemID](#P-ParquetClassLibrary-Parquets-ParquetModel-ItemID 'ParquetClassLibrary.Parquets.ParquetModel.ItemID')
  - [GetAllTags()](#M-ParquetClassLibrary-Parquets-ParquetModel-GetAllTags 'ParquetClassLibrary.Parquets.ParquetModel.GetAllTags')
- [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack')
  - [#ctor()](#M-ParquetClassLibrary-Parquets-ParquetStack-#ctor 'ParquetClassLibrary.Parquets.ParquetStack.#ctor')
  - [#ctor(inFloor,inBlock,inFurnishing,inCollectible)](#M-ParquetClassLibrary-Parquets-ParquetStack-#ctor-ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID- 'ParquetClassLibrary.Parquets.ParquetStack.#ctor(ParquetClassLibrary.ModelID,ParquetClassLibrary.ModelID,ParquetClassLibrary.ModelID,ParquetClassLibrary.ModelID)')
  - [Block](#P-ParquetClassLibrary-Parquets-ParquetStack-Block 'ParquetClassLibrary.Parquets.ParquetStack.Block')
  - [Collectible](#P-ParquetClassLibrary-Parquets-ParquetStack-Collectible 'ParquetClassLibrary.Parquets.ParquetStack.Collectible')
  - [ConverterFactory](#P-ParquetClassLibrary-Parquets-ParquetStack-ConverterFactory 'ParquetClassLibrary.Parquets.ParquetStack.ConverterFactory')
  - [Count](#P-ParquetClassLibrary-Parquets-ParquetStack-Count 'ParquetClassLibrary.Parquets.ParquetStack.Count')
  - [Empty](#P-ParquetClassLibrary-Parquets-ParquetStack-Empty 'ParquetClassLibrary.Parquets.ParquetStack.Empty')
  - [Floor](#P-ParquetClassLibrary-Parquets-ParquetStack-Floor 'ParquetClassLibrary.Parquets.ParquetStack.Floor')
  - [Furnishing](#P-ParquetClassLibrary-Parquets-ParquetStack-Furnishing 'ParquetClassLibrary.Parquets.ParquetStack.Furnishing')
  - [IsEmpty](#P-ParquetClassLibrary-Parquets-ParquetStack-IsEmpty 'ParquetClassLibrary.Parquets.ParquetStack.IsEmpty')
  - [IsEnclosing](#P-ParquetClassLibrary-Parquets-ParquetStack-IsEnclosing 'ParquetClassLibrary.Parquets.ParquetStack.IsEnclosing')
  - [IsEntry](#P-ParquetClassLibrary-Parquets-ParquetStack-IsEntry 'ParquetClassLibrary.Parquets.ParquetStack.IsEntry')
  - [IsWalkable](#P-ParquetClassLibrary-Parquets-ParquetStack-IsWalkable 'ParquetClassLibrary.Parquets.ParquetStack.IsWalkable')
  - [Clone()](#M-ParquetClassLibrary-Parquets-ParquetStack-Clone 'ParquetClassLibrary.Parquets.ParquetStack.Clone')
  - [ConvertFromString(inText,inRow,inMemberMapData)](#M-ParquetClassLibrary-Parquets-ParquetStack-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData- 'ParquetClassLibrary.Parquets.ParquetStack.ConvertFromString(System.String,CsvHelper.IReaderRow,CsvHelper.Configuration.MemberMapData)')
  - [ConvertToString(inValue,inRow,inMemberMapData)](#M-ParquetClassLibrary-Parquets-ParquetStack-ConvertToString-System-Object,CsvHelper-IWriterRow,CsvHelper-Configuration-MemberMapData- 'ParquetClassLibrary.Parquets.ParquetStack.ConvertToString(System.Object,CsvHelper.IWriterRow,CsvHelper.Configuration.MemberMapData)')
  - [Equals(inStack)](#M-ParquetClassLibrary-Parquets-ParquetStack-Equals-ParquetClassLibrary-Parquets-ParquetStack- 'ParquetClassLibrary.Parquets.ParquetStack.Equals(ParquetClassLibrary.Parquets.ParquetStack)')
  - [Equals(obj)](#M-ParquetClassLibrary-Parquets-ParquetStack-Equals-System-Object- 'ParquetClassLibrary.Parquets.ParquetStack.Equals(System.Object)')
  - [GetHashCode()](#M-ParquetClassLibrary-Parquets-ParquetStack-GetHashCode 'ParquetClassLibrary.Parquets.ParquetStack.GetHashCode')
  - [ToString()](#M-ParquetClassLibrary-Parquets-ParquetStack-ToString 'ParquetClassLibrary.Parquets.ParquetStack.ToString')
  - [op_Equality(inStack1,inStack2)](#M-ParquetClassLibrary-Parquets-ParquetStack-op_Equality-ParquetClassLibrary-Parquets-ParquetStack,ParquetClassLibrary-Parquets-ParquetStack- 'ParquetClassLibrary.Parquets.ParquetStack.op_Equality(ParquetClassLibrary.Parquets.ParquetStack,ParquetClassLibrary.Parquets.ParquetStack)')
  - [op_Inequality(inStack1,inStack2)](#M-ParquetClassLibrary-Parquets-ParquetStack-op_Inequality-ParquetClassLibrary-Parquets-ParquetStack,ParquetClassLibrary-Parquets-ParquetStack- 'ParquetClassLibrary.Parquets.ParquetStack.op_Inequality(ParquetClassLibrary.Parquets.ParquetStack,ParquetClassLibrary.Parquets.ParquetStack)')
- [ParquetStackArrayExtensions](#T-ParquetClassLibrary-Parquets-ParquetStackArrayExtensions 'ParquetClassLibrary.Parquets.ParquetStackArrayExtensions')
  - [IsValidPosition(inSubregion,inPosition)](#M-ParquetClassLibrary-Parquets-ParquetStackArrayExtensions-IsValidPosition-ParquetClassLibrary-Parquets-ParquetStack[0-,0-],ParquetClassLibrary-Vector2D- 'ParquetClassLibrary.Parquets.ParquetStackArrayExtensions.IsValidPosition(ParquetClassLibrary.Parquets.ParquetStack[0:,0:],ParquetClassLibrary.Vector2D)')
- [ParquetStackExtensions](#T-ParquetClassLibrary-Rooms-RegionAnalysis-ParquetStackExtensions 'ParquetClassLibrary.Rooms.RegionAnalysis.ParquetStackExtensions')
  - [GetWalkableAreas(inSubregion)](#M-ParquetClassLibrary-Rooms-RegionAnalysis-ParquetStackExtensions-GetWalkableAreas-ParquetClassLibrary-Parquets-ParquetStackGrid- 'ParquetClassLibrary.Rooms.RegionAnalysis.ParquetStackExtensions.GetWalkableAreas(ParquetClassLibrary.Parquets.ParquetStackGrid)')
- [ParquetStackGrid](#T-ParquetClassLibrary-Parquets-ParquetStackGrid 'ParquetClassLibrary.Parquets.ParquetStackGrid')
  - [#ctor()](#M-ParquetClassLibrary-Parquets-ParquetStackGrid-#ctor 'ParquetClassLibrary.Parquets.ParquetStackGrid.#ctor')
  - [#ctor(inRowCount,inColumnCount)](#M-ParquetClassLibrary-Parquets-ParquetStackGrid-#ctor-System-Int32,System-Int32- 'ParquetClassLibrary.Parquets.ParquetStackGrid.#ctor(System.Int32,System.Int32)')
  - [#ctor(inParquetStackArray)](#M-ParquetClassLibrary-Parquets-ParquetStackGrid-#ctor-ParquetClassLibrary-Parquets-ParquetStack[0-,0-]- 'ParquetClassLibrary.Parquets.ParquetStackGrid.#ctor(ParquetClassLibrary.Parquets.ParquetStack[0:,0:])')
  - [Columns](#P-ParquetClassLibrary-Parquets-ParquetStackGrid-Columns 'ParquetClassLibrary.Parquets.ParquetStackGrid.Columns')
  - [Count](#P-ParquetClassLibrary-Parquets-ParquetStackGrid-Count 'ParquetClassLibrary.Parquets.ParquetStackGrid.Count')
  - [Item](#P-ParquetClassLibrary-Parquets-ParquetStackGrid-Item-System-Int32,System-Int32- 'ParquetClassLibrary.Parquets.ParquetStackGrid.Item(System.Int32,System.Int32)')
  - [ParquetStacks](#P-ParquetClassLibrary-Parquets-ParquetStackGrid-ParquetStacks 'ParquetClassLibrary.Parquets.ParquetStackGrid.ParquetStacks')
  - [Rows](#P-ParquetClassLibrary-Parquets-ParquetStackGrid-Rows 'ParquetClassLibrary.Parquets.ParquetStackGrid.Rows')
  - [GetEnumerator()](#M-ParquetClassLibrary-Parquets-ParquetStackGrid-GetEnumerator 'ParquetClassLibrary.Parquets.ParquetStackGrid.GetEnumerator')
  - [IsValidPosition(inPosition)](#M-ParquetClassLibrary-Parquets-ParquetStackGrid-IsValidPosition-ParquetClassLibrary-Vector2D- 'ParquetClassLibrary.Parquets.ParquetStackGrid.IsValidPosition(ParquetClassLibrary.Vector2D)')
  - [System#Collections#Generic#IEnumerable{ParquetClassLibrary#Parquets#ParquetStack}#GetEnumerator()](#M-ParquetClassLibrary-Parquets-ParquetStackGrid-System#Collections#Generic#IEnumerable{ParquetClassLibrary#Parquets#ParquetStack}#GetEnumerator 'ParquetClassLibrary.Parquets.ParquetStackGrid.System#Collections#Generic#IEnumerable{ParquetClassLibrary#Parquets#ParquetStack}#GetEnumerator')
- [ParquetStackGridExtensions](#T-ParquetClassLibrary-Rooms-RegionAnalysis-ParquetStackGridExtensions 'ParquetClassLibrary.Rooms.RegionAnalysis.ParquetStackGridExtensions')
  - [GetSpaces()](#M-ParquetClassLibrary-Rooms-RegionAnalysis-ParquetStackGridExtensions-GetSpaces-ParquetClassLibrary-Parquets-ParquetStackGrid- 'ParquetClassLibrary.Rooms.RegionAnalysis.ParquetStackGridExtensions.GetSpaces(ParquetClassLibrary.Parquets.ParquetStackGrid)')
- [ParquetStatus](#T-ParquetClassLibrary-Parquets-ParquetStatus 'ParquetClassLibrary.Parquets.ParquetStatus')
  - [#ctor()](#M-ParquetClassLibrary-Parquets-ParquetStatus-#ctor 'ParquetClassLibrary.Parquets.ParquetStatus.#ctor')
  - [#ctor(inIsTrench,inToughness,inMaxToughness)](#M-ParquetClassLibrary-Parquets-ParquetStatus-#ctor-System-Boolean,System-Int32,System-Int32- 'ParquetClassLibrary.Parquets.ParquetStatus.#ctor(System.Boolean,System.Int32,System.Int32)')
  - [maxToughness](#F-ParquetClassLibrary-Parquets-ParquetStatus-maxToughness 'ParquetClassLibrary.Parquets.ParquetStatus.maxToughness')
  - [toughness](#F-ParquetClassLibrary-Parquets-ParquetStatus-toughness 'ParquetClassLibrary.Parquets.ParquetStatus.toughness')
  - [ConverterFactory](#P-ParquetClassLibrary-Parquets-ParquetStatus-ConverterFactory 'ParquetClassLibrary.Parquets.ParquetStatus.ConverterFactory')
  - [IsTrench](#P-ParquetClassLibrary-Parquets-ParquetStatus-IsTrench 'ParquetClassLibrary.Parquets.ParquetStatus.IsTrench')
  - [Toughness](#P-ParquetClassLibrary-Parquets-ParquetStatus-Toughness 'ParquetClassLibrary.Parquets.ParquetStatus.Toughness')
  - [Unused](#P-ParquetClassLibrary-Parquets-ParquetStatus-Unused 'ParquetClassLibrary.Parquets.ParquetStatus.Unused')
  - [Clone()](#M-ParquetClassLibrary-Parquets-ParquetStatus-Clone 'ParquetClassLibrary.Parquets.ParquetStatus.Clone')
  - [ConvertFromString(inText,inRow,inMemberMapData)](#M-ParquetClassLibrary-Parquets-ParquetStatus-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData- 'ParquetClassLibrary.Parquets.ParquetStatus.ConvertFromString(System.String,CsvHelper.IReaderRow,CsvHelper.Configuration.MemberMapData)')
  - [ConvertToString(inValue,inRow,inMemberMapData)](#M-ParquetClassLibrary-Parquets-ParquetStatus-ConvertToString-System-Object,CsvHelper-IWriterRow,CsvHelper-Configuration-MemberMapData- 'ParquetClassLibrary.Parquets.ParquetStatus.ConvertToString(System.Object,CsvHelper.IWriterRow,CsvHelper.Configuration.MemberMapData)')
  - [Equals(inStatus)](#M-ParquetClassLibrary-Parquets-ParquetStatus-Equals-ParquetClassLibrary-Parquets-ParquetStatus- 'ParquetClassLibrary.Parquets.ParquetStatus.Equals(ParquetClassLibrary.Parquets.ParquetStatus)')
  - [Equals(obj)](#M-ParquetClassLibrary-Parquets-ParquetStatus-Equals-System-Object- 'ParquetClassLibrary.Parquets.ParquetStatus.Equals(System.Object)')
  - [GetHashCode()](#M-ParquetClassLibrary-Parquets-ParquetStatus-GetHashCode 'ParquetClassLibrary.Parquets.ParquetStatus.GetHashCode')
  - [ToString()](#M-ParquetClassLibrary-Parquets-ParquetStatus-ToString 'ParquetClassLibrary.Parquets.ParquetStatus.ToString')
  - [op_Equality(inStatus1,inStatus2)](#M-ParquetClassLibrary-Parquets-ParquetStatus-op_Equality-ParquetClassLibrary-Parquets-ParquetStatus,ParquetClassLibrary-Parquets-ParquetStatus- 'ParquetClassLibrary.Parquets.ParquetStatus.op_Equality(ParquetClassLibrary.Parquets.ParquetStatus,ParquetClassLibrary.Parquets.ParquetStatus)')
  - [op_Inequality(inStatus1,inStatus2)](#M-ParquetClassLibrary-Parquets-ParquetStatus-op_Inequality-ParquetClassLibrary-Parquets-ParquetStatus,ParquetClassLibrary-Parquets-ParquetStatus- 'ParquetClassLibrary.Parquets.ParquetStatus.op_Inequality(ParquetClassLibrary.Parquets.ParquetStatus,ParquetClassLibrary.Parquets.ParquetStatus)')
- [ParquetStatusArrayExtensions](#T-ParquetClassLibrary-Parquets-ParquetStatusArrayExtensions 'ParquetClassLibrary.Parquets.ParquetStatusArrayExtensions')
  - [IsValidPosition(inSubregion,inPosition)](#M-ParquetClassLibrary-Parquets-ParquetStatusArrayExtensions-IsValidPosition-ParquetClassLibrary-Parquets-ParquetStatus[0-,0-],ParquetClassLibrary-Vector2D- 'ParquetClassLibrary.Parquets.ParquetStatusArrayExtensions.IsValidPosition(ParquetClassLibrary.Parquets.ParquetStatus[0:,0:],ParquetClassLibrary.Vector2D)')
- [ParquetStatusGrid](#T-ParquetClassLibrary-Parquets-ParquetStatusGrid 'ParquetClassLibrary.Parquets.ParquetStatusGrid')
  - [#ctor()](#M-ParquetClassLibrary-Parquets-ParquetStatusGrid-#ctor 'ParquetClassLibrary.Parquets.ParquetStatusGrid.#ctor')
  - [#ctor(inRowCount,inColumnCount)](#M-ParquetClassLibrary-Parquets-ParquetStatusGrid-#ctor-System-Int32,System-Int32- 'ParquetClassLibrary.Parquets.ParquetStatusGrid.#ctor(System.Int32,System.Int32)')
  - [Columns](#P-ParquetClassLibrary-Parquets-ParquetStatusGrid-Columns 'ParquetClassLibrary.Parquets.ParquetStatusGrid.Columns')
  - [Count](#P-ParquetClassLibrary-Parquets-ParquetStatusGrid-Count 'ParquetClassLibrary.Parquets.ParquetStatusGrid.Count')
  - [Item](#P-ParquetClassLibrary-Parquets-ParquetStatusGrid-Item-System-Int32,System-Int32- 'ParquetClassLibrary.Parquets.ParquetStatusGrid.Item(System.Int32,System.Int32)')
  - [ParquetStatuses](#P-ParquetClassLibrary-Parquets-ParquetStatusGrid-ParquetStatuses 'ParquetClassLibrary.Parquets.ParquetStatusGrid.ParquetStatuses')
  - [Rows](#P-ParquetClassLibrary-Parquets-ParquetStatusGrid-Rows 'ParquetClassLibrary.Parquets.ParquetStatusGrid.Rows')
  - [GetEnumerator()](#M-ParquetClassLibrary-Parquets-ParquetStatusGrid-GetEnumerator 'ParquetClassLibrary.Parquets.ParquetStatusGrid.GetEnumerator')
  - [IsValidPosition(inPosition)](#M-ParquetClassLibrary-Parquets-ParquetStatusGrid-IsValidPosition-ParquetClassLibrary-Vector2D- 'ParquetClassLibrary.Parquets.ParquetStatusGrid.IsValidPosition(ParquetClassLibrary.Vector2D)')
  - [System#Collections#Generic#IEnumerable{ParquetClassLibrary#Parquets#ParquetStatus}#GetEnumerator()](#M-ParquetClassLibrary-Parquets-ParquetStatusGrid-System#Collections#Generic#IEnumerable{ParquetClassLibrary#Parquets#ParquetStatus}#GetEnumerator 'ParquetClassLibrary.Parquets.ParquetStatusGrid.System#Collections#Generic#IEnumerable{ParquetClassLibrary#Parquets#ParquetStatus}#GetEnumerator')
- [PositionInfoEventArgs](#T-ParquetClassLibrary-Maps-PositionInfoEventArgs 'ParquetClassLibrary.Maps.PositionInfoEventArgs')
  - [#ctor(inStacks,inStatuses,inPoints)](#M-ParquetClassLibrary-Maps-PositionInfoEventArgs-#ctor-ParquetClassLibrary-Parquets-ParquetStack,ParquetClassLibrary-Parquets-ParquetStatus,System-Collections-Generic-IEnumerable{ParquetClassLibrary-Maps-ExitPoint}- 'ParquetClassLibrary.Maps.PositionInfoEventArgs.#ctor(ParquetClassLibrary.Parquets.ParquetStack,ParquetClassLibrary.Parquets.ParquetStatus,System.Collections.Generic.IEnumerable{ParquetClassLibrary.Maps.ExitPoint})')
  - [SpecialPoints](#P-ParquetClassLibrary-Maps-PositionInfoEventArgs-SpecialPoints 'ParquetClassLibrary.Maps.PositionInfoEventArgs.SpecialPoints')
  - [Stack](#P-ParquetClassLibrary-Maps-PositionInfoEventArgs-Stack 'ParquetClassLibrary.Maps.PositionInfoEventArgs.Stack')
  - [Status](#P-ParquetClassLibrary-Maps-PositionInfoEventArgs-Status 'ParquetClassLibrary.Maps.PositionInfoEventArgs.Status')
- [Precondition](#T-ParquetClassLibrary-Utilities-Precondition 'ParquetClassLibrary.Utilities.Precondition')
  - [DefaultArgumentName](#F-ParquetClassLibrary-Utilities-Precondition-DefaultArgumentName 'ParquetClassLibrary.Utilities.Precondition.DefaultArgumentName')
  - [AreInRange(inEnumerable,inBounds,inArgumentName)](#M-ParquetClassLibrary-Utilities-Precondition-AreInRange-System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},System-String- 'ParquetClassLibrary.Utilities.Precondition.AreInRange(System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID},ParquetClassLibrary.Range{ParquetClassLibrary.ModelID},System.String)')
  - [AreInRange(inEnumerable,inBoundsCollection,inArgumentName)](#M-ParquetClassLibrary-Utilities-Precondition-AreInRange-System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Range{ParquetClassLibrary-ModelID}},System-String- 'ParquetClassLibrary.Utilities.Precondition.AreInRange(System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}},System.String)')
  - [IsInRange(inInt,inBounds,inArgumentName)](#M-ParquetClassLibrary-Utilities-Precondition-IsInRange-System-Int32,ParquetClassLibrary-Range{System-Int32},System-String- 'ParquetClassLibrary.Utilities.Precondition.IsInRange(System.Int32,ParquetClassLibrary.Range{System.Int32},System.String)')
  - [IsInRange(inID,inBounds,inArgumentName)](#M-ParquetClassLibrary-Utilities-Precondition-IsInRange-ParquetClassLibrary-ModelID,ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},System-String- 'ParquetClassLibrary.Utilities.Precondition.IsInRange(ParquetClassLibrary.ModelID,ParquetClassLibrary.Range{ParquetClassLibrary.ModelID},System.String)')
  - [IsInRange(inInnerBounds,inOuterBounds,inArgumentName)](#M-ParquetClassLibrary-Utilities-Precondition-IsInRange-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},System-String- 'ParquetClassLibrary.Utilities.Precondition.IsInRange(ParquetClassLibrary.Range{ParquetClassLibrary.ModelID},ParquetClassLibrary.Range{ParquetClassLibrary.ModelID},System.String)')
  - [IsInRange(inID,inBoundsCollection,inArgumentName)](#M-ParquetClassLibrary-Utilities-Precondition-IsInRange-ParquetClassLibrary-ModelID,System-Collections-Generic-IEnumerable{ParquetClassLibrary-Range{ParquetClassLibrary-ModelID}},System-String- 'ParquetClassLibrary.Utilities.Precondition.IsInRange(ParquetClassLibrary.ModelID,System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}},System.String)')
  - [IsInRange(inInnerBounds,inBoundsCollection,inArgumentName)](#M-ParquetClassLibrary-Utilities-Precondition-IsInRange-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Range{ParquetClassLibrary-ModelID}},System-String- 'ParquetClassLibrary.Utilities.Precondition.IsInRange(ParquetClassLibrary.Range{ParquetClassLibrary.ModelID},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}},System.String)')
  - [IsNotNone(inID,inArgumentName)](#M-ParquetClassLibrary-Utilities-Precondition-IsNotNone-ParquetClassLibrary-ModelID,System-String- 'ParquetClassLibrary.Utilities.Precondition.IsNotNone(ParquetClassLibrary.ModelID,System.String)')
  - [IsNotNull(inReference,inArgumentName)](#M-ParquetClassLibrary-Utilities-Precondition-IsNotNull-System-Object,System-String- 'ParquetClassLibrary.Utilities.Precondition.IsNotNull(System.Object,System.String)')
  - [IsNotNullOrEmpty(inString,inArgumentName)](#M-ParquetClassLibrary-Utilities-Precondition-IsNotNullOrEmpty-System-String,System-String- 'ParquetClassLibrary.Utilities.Precondition.IsNotNullOrEmpty(System.String,System.String)')
  - [IsNotNullOrEmpty\`\`1(inEnumerable,inArgumentName)](#M-ParquetClassLibrary-Utilities-Precondition-IsNotNullOrEmpty``1-System-Collections-Generic-IEnumerable{``0},System-String- 'ParquetClassLibrary.Utilities.Precondition.IsNotNullOrEmpty``1(System.Collections.Generic.IEnumerable{``0},System.String)')
  - [IsOfType\`\`2(inArgumentName)](#M-ParquetClassLibrary-Utilities-Precondition-IsOfType``2-System-String- 'ParquetClassLibrary.Utilities.Precondition.IsOfType``2(System.String)')
  - [MustBeNonNegative(inNumber,inArgumentName)](#M-ParquetClassLibrary-Utilities-Precondition-MustBeNonNegative-System-Int32,System-String- 'ParquetClassLibrary.Utilities.Precondition.MustBeNonNegative(System.Int32,System.String)')
  - [MustBePositive(inNumber,inArgumentName)](#M-ParquetClassLibrary-Utilities-Precondition-MustBePositive-System-Int32,System-String- 'ParquetClassLibrary.Utilities.Precondition.MustBePositive(System.Int32,System.String)')
- [PronounGroup](#T-ParquetClassLibrary-Beings-PronounGroup 'ParquetClassLibrary.Beings.PronounGroup')
  - [#ctor(inSubjective,inObjective,inDeterminer,inPossessive,inReflexive)](#M-ParquetClassLibrary-Beings-PronounGroup-#ctor-System-String,System-String,System-String,System-String,System-String- 'ParquetClassLibrary.Beings.PronounGroup.#ctor(System.String,System.String,System.String,System.String,System.String)')
  - [DefaultGroup](#F-ParquetClassLibrary-Beings-PronounGroup-DefaultGroup 'ParquetClassLibrary.Beings.PronounGroup.DefaultGroup')
  - [DefaultKey](#F-ParquetClassLibrary-Beings-PronounGroup-DefaultKey 'ParquetClassLibrary.Beings.PronounGroup.DefaultKey')
  - [DeterminerTag](#F-ParquetClassLibrary-Beings-PronounGroup-DeterminerTag 'ParquetClassLibrary.Beings.PronounGroup.DeterminerTag')
  - [ObjectiveTag](#F-ParquetClassLibrary-Beings-PronounGroup-ObjectiveTag 'ParquetClassLibrary.Beings.PronounGroup.ObjectiveTag')
  - [PossessiveTag](#F-ParquetClassLibrary-Beings-PronounGroup-PossessiveTag 'ParquetClassLibrary.Beings.PronounGroup.PossessiveTag')
  - [ReflexiveTag](#F-ParquetClassLibrary-Beings-PronounGroup-ReflexiveTag 'ParquetClassLibrary.Beings.PronounGroup.ReflexiveTag')
  - [SubjectiveTag](#F-ParquetClassLibrary-Beings-PronounGroup-SubjectiveTag 'ParquetClassLibrary.Beings.PronounGroup.SubjectiveTag')
  - [Determiner](#P-ParquetClassLibrary-Beings-PronounGroup-Determiner 'ParquetClassLibrary.Beings.PronounGroup.Determiner')
  - [Objective](#P-ParquetClassLibrary-Beings-PronounGroup-Objective 'ParquetClassLibrary.Beings.PronounGroup.Objective')
  - [ParquetClassLibrary#Beings#IPronounGroupEdit#Determiner](#P-ParquetClassLibrary-Beings-PronounGroup-ParquetClassLibrary#Beings#IPronounGroupEdit#Determiner 'ParquetClassLibrary.Beings.PronounGroup.ParquetClassLibrary#Beings#IPronounGroupEdit#Determiner')
  - [ParquetClassLibrary#Beings#IPronounGroupEdit#Objective](#P-ParquetClassLibrary-Beings-PronounGroup-ParquetClassLibrary#Beings#IPronounGroupEdit#Objective 'ParquetClassLibrary.Beings.PronounGroup.ParquetClassLibrary#Beings#IPronounGroupEdit#Objective')
  - [ParquetClassLibrary#Beings#IPronounGroupEdit#Possessive](#P-ParquetClassLibrary-Beings-PronounGroup-ParquetClassLibrary#Beings#IPronounGroupEdit#Possessive 'ParquetClassLibrary.Beings.PronounGroup.ParquetClassLibrary#Beings#IPronounGroupEdit#Possessive')
  - [ParquetClassLibrary#Beings#IPronounGroupEdit#Reflexive](#P-ParquetClassLibrary-Beings-PronounGroup-ParquetClassLibrary#Beings#IPronounGroupEdit#Reflexive 'ParquetClassLibrary.Beings.PronounGroup.ParquetClassLibrary#Beings#IPronounGroupEdit#Reflexive')
  - [ParquetClassLibrary#Beings#IPronounGroupEdit#Subjective](#P-ParquetClassLibrary-Beings-PronounGroup-ParquetClassLibrary#Beings#IPronounGroupEdit#Subjective 'ParquetClassLibrary.Beings.PronounGroup.ParquetClassLibrary#Beings#IPronounGroupEdit#Subjective')
  - [Possessive](#P-ParquetClassLibrary-Beings-PronounGroup-Possessive 'ParquetClassLibrary.Beings.PronounGroup.Possessive')
  - [Reflexive](#P-ParquetClassLibrary-Beings-PronounGroup-Reflexive 'ParquetClassLibrary.Beings.PronounGroup.Reflexive')
  - [Subjective](#P-ParquetClassLibrary-Beings-PronounGroup-Subjective 'ParquetClassLibrary.Beings.PronounGroup.Subjective')
  - [GetFilePath()](#M-ParquetClassLibrary-Beings-PronounGroup-GetFilePath 'ParquetClassLibrary.Beings.PronounGroup.GetFilePath')
  - [GetRecords()](#M-ParquetClassLibrary-Beings-PronounGroup-GetRecords 'ParquetClassLibrary.Beings.PronounGroup.GetRecords')
  - [PutRecords()](#M-ParquetClassLibrary-Beings-PronounGroup-PutRecords-System-Collections-Generic-IEnumerable{ParquetClassLibrary-Beings-PronounGroup}- 'ParquetClassLibrary.Beings.PronounGroup.PutRecords(System.Collections.Generic.IEnumerable{ParquetClassLibrary.Beings.PronounGroup})')
  - [ToString()](#M-ParquetClassLibrary-Beings-PronounGroup-ToString 'ParquetClassLibrary.Beings.PronounGroup.ToString')
  - [UpdatePronouns(inText)](#M-ParquetClassLibrary-Beings-PronounGroup-UpdatePronouns-System-Text-StringBuilder- 'ParquetClassLibrary.Beings.PronounGroup.UpdatePronouns(System.Text.StringBuilder)')
  - [UpdatePronouns(inText)](#M-ParquetClassLibrary-Beings-PronounGroup-UpdatePronouns-System-String- 'ParquetClassLibrary.Beings.PronounGroup.UpdatePronouns(System.String)')
- [RangeCollectionExtensions](#T-ParquetClassLibrary-RangeCollectionExtensions 'ParquetClassLibrary.RangeCollectionExtensions')
  - [ContainsRange\`\`1(inRangeCollection,inRange)](#M-ParquetClassLibrary-RangeCollectionExtensions-ContainsRange``1-System-Collections-Generic-IEnumerable{ParquetClassLibrary-Range{``0}},ParquetClassLibrary-Range{``0}- 'ParquetClassLibrary.RangeCollectionExtensions.ContainsRange``1(System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{``0}},ParquetClassLibrary.Range{``0})')
  - [ContainsValue\`\`1(inRangeCollection,inValue)](#M-ParquetClassLibrary-RangeCollectionExtensions-ContainsValue``1-System-Collections-Generic-IEnumerable{ParquetClassLibrary-Range{``0}},``0- 'ParquetClassLibrary.RangeCollectionExtensions.ContainsValue``1(System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{``0}},``0)')
  - [IsValid\`\`1()](#M-ParquetClassLibrary-RangeCollectionExtensions-IsValid``1-System-Collections-Generic-IEnumerable{ParquetClassLibrary-Range{``0}}- 'ParquetClassLibrary.RangeCollectionExtensions.IsValid``1(System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{``0}})')
- [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1')
  - [#ctor(inMinimum,inMaximum)](#M-ParquetClassLibrary-Range`1-#ctor-`0,`0- 'ParquetClassLibrary.Range`1.#ctor(`0,`0)')
  - [ConverterFactory](#P-ParquetClassLibrary-Range`1-ConverterFactory 'ParquetClassLibrary.Range`1.ConverterFactory')
  - [Int32ConverterFactory](#P-ParquetClassLibrary-Range`1-Int32ConverterFactory 'ParquetClassLibrary.Range`1.Int32ConverterFactory')
  - [Maximum](#P-ParquetClassLibrary-Range`1-Maximum 'ParquetClassLibrary.Range`1.Maximum')
  - [Minimum](#P-ParquetClassLibrary-Range`1-Minimum 'ParquetClassLibrary.Range`1.Minimum')
  - [SingleConverterFactory](#P-ParquetClassLibrary-Range`1-SingleConverterFactory 'ParquetClassLibrary.Range`1.SingleConverterFactory')
  - [ContainsRange(inRange)](#M-ParquetClassLibrary-Range`1-ContainsRange-ParquetClassLibrary-Range{`0}- 'ParquetClassLibrary.Range`1.ContainsRange(ParquetClassLibrary.Range{`0})')
  - [ContainsValue(inValue)](#M-ParquetClassLibrary-Range`1-ContainsValue-`0- 'ParquetClassLibrary.Range`1.ContainsValue(`0)')
  - [ConvertFromString(inText,inRow,inMemberMapData)](#M-ParquetClassLibrary-Range`1-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData- 'ParquetClassLibrary.Range`1.ConvertFromString(System.String,CsvHelper.IReaderRow,CsvHelper.Configuration.MemberMapData)')
  - [ConvertToString(inValue,inRow,inMemberMapData)](#M-ParquetClassLibrary-Range`1-ConvertToString-System-Object,CsvHelper-IWriterRow,CsvHelper-Configuration-MemberMapData- 'ParquetClassLibrary.Range`1.ConvertToString(System.Object,CsvHelper.IWriterRow,CsvHelper.Configuration.MemberMapData)')
  - [Equals(inRange)](#M-ParquetClassLibrary-Range`1-Equals-ParquetClassLibrary-Range{`0}- 'ParquetClassLibrary.Range`1.Equals(ParquetClassLibrary.Range{`0})')
  - [Equals(obj)](#M-ParquetClassLibrary-Range`1-Equals-System-Object- 'ParquetClassLibrary.Range`1.Equals(System.Object)')
  - [GetHashCode()](#M-ParquetClassLibrary-Range`1-GetHashCode 'ParquetClassLibrary.Range`1.GetHashCode')
  - [IsValid()](#M-ParquetClassLibrary-Range`1-IsValid 'ParquetClassLibrary.Range`1.IsValid')
  - [ToString()](#M-ParquetClassLibrary-Range`1-ToString 'ParquetClassLibrary.Range`1.ToString')
  - [op_Equality(inRange1,inRange2)](#M-ParquetClassLibrary-Range`1-op_Equality-ParquetClassLibrary-Range{`0},ParquetClassLibrary-Range{`0}- 'ParquetClassLibrary.Range`1.op_Equality(ParquetClassLibrary.Range{`0},ParquetClassLibrary.Range{`0})')
  - [op_Inequality(inRange1,inRange2)](#M-ParquetClassLibrary-Range`1-op_Inequality-ParquetClassLibrary-Range{`0},ParquetClassLibrary-Range{`0}- 'ParquetClassLibrary.Range`1.op_Inequality(ParquetClassLibrary.Range{`0},ParquetClassLibrary.Range{`0})')
- [Rasterization](#T-ParquetClassLibrary-Utilities-Rasterization 'ParquetClassLibrary.Utilities.Rasterization')
  - [PlotCircle(inCenter,inRadius,inIsFilled,inIsValid)](#M-ParquetClassLibrary-Utilities-Rasterization-PlotCircle-ParquetClassLibrary-Vector2D,System-Int32,System-Boolean,System-Predicate{ParquetClassLibrary-Vector2D}- 'ParquetClassLibrary.Utilities.Rasterization.PlotCircle(ParquetClassLibrary.Vector2D,System.Int32,System.Boolean,System.Predicate{ParquetClassLibrary.Vector2D})')
  - [PlotEmptyRectangle(inUpperLeft,inLowerRight,inIsValid)](#M-ParquetClassLibrary-Utilities-Rasterization-PlotEmptyRectangle-ParquetClassLibrary-Vector2D,ParquetClassLibrary-Vector2D,System-Predicate{ParquetClassLibrary-Vector2D}- 'ParquetClassLibrary.Utilities.Rasterization.PlotEmptyRectangle(ParquetClassLibrary.Vector2D,ParquetClassLibrary.Vector2D,System.Predicate{ParquetClassLibrary.Vector2D})')
  - [PlotFilledRectangle(inUpperLeft,inLowerRight,inIsValid)](#M-ParquetClassLibrary-Utilities-Rasterization-PlotFilledRectangle-ParquetClassLibrary-Vector2D,ParquetClassLibrary-Vector2D,System-Predicate{ParquetClassLibrary-Vector2D}- 'ParquetClassLibrary.Utilities.Rasterization.PlotFilledRectangle(ParquetClassLibrary.Vector2D,ParquetClassLibrary.Vector2D,System.Predicate{ParquetClassLibrary.Vector2D})')
  - [PlotFloodFill\`\`1(inStart,inTarget,inIsValid,inMatches)](#M-ParquetClassLibrary-Utilities-Rasterization-PlotFloodFill``1-ParquetClassLibrary-Vector2D,``0,System-Predicate{ParquetClassLibrary-Vector2D},System-Func{ParquetClassLibrary-Vector2D,``0,System-Boolean}- 'ParquetClassLibrary.Utilities.Rasterization.PlotFloodFill``1(ParquetClassLibrary.Vector2D,``0,System.Predicate{ParquetClassLibrary.Vector2D},System.Func{ParquetClassLibrary.Vector2D,``0,System.Boolean})')
  - [PlotLine(inStart,inEend,inIsValid)](#M-ParquetClassLibrary-Utilities-Rasterization-PlotLine-ParquetClassLibrary-Vector2D,ParquetClassLibrary-Vector2D,System-Predicate{ParquetClassLibrary-Vector2D}- 'ParquetClassLibrary.Utilities.Rasterization.PlotLine(ParquetClassLibrary.Vector2D,ParquetClassLibrary.Vector2D,System.Predicate{ParquetClassLibrary.Vector2D})')
- [RecipeElement](#T-ParquetClassLibrary-RecipeElement 'ParquetClassLibrary.RecipeElement')
  - [#ctor()](#M-ParquetClassLibrary-RecipeElement-#ctor 'ParquetClassLibrary.RecipeElement.#ctor')
  - [#ctor(inElementAmount,inElementTag)](#M-ParquetClassLibrary-RecipeElement-#ctor-System-Int32,ParquetClassLibrary-ModelTag- 'ParquetClassLibrary.RecipeElement.#ctor(System.Int32,ParquetClassLibrary.ModelTag)')
  - [None](#F-ParquetClassLibrary-RecipeElement-None 'ParquetClassLibrary.RecipeElement.None')
  - [ConverterFactory](#P-ParquetClassLibrary-RecipeElement-ConverterFactory 'ParquetClassLibrary.RecipeElement.ConverterFactory')
  - [ElementAmount](#P-ParquetClassLibrary-RecipeElement-ElementAmount 'ParquetClassLibrary.RecipeElement.ElementAmount')
  - [ElementTag](#P-ParquetClassLibrary-RecipeElement-ElementTag 'ParquetClassLibrary.RecipeElement.ElementTag')
  - [ConvertFromString(inText,inRow,inMemberMapData)](#M-ParquetClassLibrary-RecipeElement-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData- 'ParquetClassLibrary.RecipeElement.ConvertFromString(System.String,CsvHelper.IReaderRow,CsvHelper.Configuration.MemberMapData)')
  - [ConvertToString(inValue,inRow,inMemberMapData)](#M-ParquetClassLibrary-RecipeElement-ConvertToString-System-Object,CsvHelper-IWriterRow,CsvHelper-Configuration-MemberMapData- 'ParquetClassLibrary.RecipeElement.ConvertToString(System.Object,CsvHelper.IWriterRow,CsvHelper.Configuration.MemberMapData)')
  - [Equals(inElement)](#M-ParquetClassLibrary-RecipeElement-Equals-ParquetClassLibrary-RecipeElement- 'ParquetClassLibrary.RecipeElement.Equals(ParquetClassLibrary.RecipeElement)')
  - [Equals(obj)](#M-ParquetClassLibrary-RecipeElement-Equals-System-Object- 'ParquetClassLibrary.RecipeElement.Equals(System.Object)')
  - [GetHashCode()](#M-ParquetClassLibrary-RecipeElement-GetHashCode 'ParquetClassLibrary.RecipeElement.GetHashCode')
  - [ToString()](#M-ParquetClassLibrary-RecipeElement-ToString 'ParquetClassLibrary.RecipeElement.ToString')
  - [op_Equality(inElement1,inElement2)](#M-ParquetClassLibrary-RecipeElement-op_Equality-ParquetClassLibrary-RecipeElement,ParquetClassLibrary-RecipeElement- 'ParquetClassLibrary.RecipeElement.op_Equality(ParquetClassLibrary.RecipeElement,ParquetClassLibrary.RecipeElement)')
  - [op_Inequality(inElement1,inElement2)](#M-ParquetClassLibrary-RecipeElement-op_Inequality-ParquetClassLibrary-RecipeElement,ParquetClassLibrary-RecipeElement- 'ParquetClassLibrary.RecipeElement.op_Inequality(ParquetClassLibrary.RecipeElement,ParquetClassLibrary.RecipeElement)')
- [Recipes](#T-ParquetClassLibrary-Rules-Recipes 'ParquetClassLibrary.Rules.Recipes')
- [Resources](#T-ParquetClassLibrary-Properties-Resources 'ParquetClassLibrary.Properties.Resources')
  - [Culture](#P-ParquetClassLibrary-Properties-Resources-Culture 'ParquetClassLibrary.Properties.Resources.Culture')
  - [ErrorCannotConvert](#P-ParquetClassLibrary-Properties-Resources-ErrorCannotConvert 'ParquetClassLibrary.Properties.Resources.ErrorCannotConvert')
  - [ErrorCannotParse](#P-ParquetClassLibrary-Properties-Resources-ErrorCannotParse 'ParquetClassLibrary.Properties.Resources.ErrorCannotParse')
  - [ErrorInvalidCast](#P-ParquetClassLibrary-Properties-Resources-ErrorInvalidCast 'ParquetClassLibrary.Properties.Resources.ErrorInvalidCast')
  - [ErrorInvalidPosition](#P-ParquetClassLibrary-Properties-Resources-ErrorInvalidPosition 'ParquetClassLibrary.Properties.Resources.ErrorInvalidPosition')
  - [ErrorModelNotFound](#P-ParquetClassLibrary-Properties-Resources-ErrorModelNotFound 'ParquetClassLibrary.Properties.Resources.ErrorModelNotFound')
  - [ErrorMustBeNonNegative](#P-ParquetClassLibrary-Properties-Resources-ErrorMustBeNonNegative 'ParquetClassLibrary.Properties.Resources.ErrorMustBeNonNegative')
  - [ErrorMustBePositive](#P-ParquetClassLibrary-Properties-Resources-ErrorMustBePositive 'ParquetClassLibrary.Properties.Resources.ErrorMustBePositive')
  - [ErrorMustNotBeEmpty](#P-ParquetClassLibrary-Properties-Resources-ErrorMustNotBeEmpty 'ParquetClassLibrary.Properties.Resources.ErrorMustNotBeEmpty')
  - [ErrorMustNotBeNone](#P-ParquetClassLibrary-Properties-Resources-ErrorMustNotBeNone 'ParquetClassLibrary.Properties.Resources.ErrorMustNotBeNone')
  - [ErrorMustNotBeNull](#P-ParquetClassLibrary-Properties-Resources-ErrorMustNotBeNull 'ParquetClassLibrary.Properties.Resources.ErrorMustNotBeNull')
  - [ErrorMustNotBeNullEmpty](#P-ParquetClassLibrary-Properties-Resources-ErrorMustNotBeNullEmpty 'ParquetClassLibrary.Properties.Resources.ErrorMustNotBeNullEmpty')
  - [ErrorNoExitFound](#P-ParquetClassLibrary-Properties-Resources-ErrorNoExitFound 'ParquetClassLibrary.Properties.Resources.ErrorNoExitFound')
  - [ErrorOutOfBounds](#P-ParquetClassLibrary-Properties-Resources-ErrorOutOfBounds 'ParquetClassLibrary.Properties.Resources.ErrorOutOfBounds')
  - [ErrorOutOfOrder](#P-ParquetClassLibrary-Properties-Resources-ErrorOutOfOrder 'ParquetClassLibrary.Properties.Resources.ErrorOutOfOrder')
  - [ErrorUngenerated](#P-ParquetClassLibrary-Properties-Resources-ErrorUngenerated 'ParquetClassLibrary.Properties.Resources.ErrorUngenerated')
  - [ErrorUnsupportedDimension](#P-ParquetClassLibrary-Properties-Resources-ErrorUnsupportedDimension 'ParquetClassLibrary.Properties.Resources.ErrorUnsupportedDimension')
  - [ErrorUnsupportedDuplicate](#P-ParquetClassLibrary-Properties-Resources-ErrorUnsupportedDuplicate 'ParquetClassLibrary.Properties.Resources.ErrorUnsupportedDuplicate')
  - [ErrorUnsupportedNode](#P-ParquetClassLibrary-Properties-Resources-ErrorUnsupportedNode 'ParquetClassLibrary.Properties.Resources.ErrorUnsupportedNode')
  - [ErrorUnsupportedSerialization](#P-ParquetClassLibrary-Properties-Resources-ErrorUnsupportedSerialization 'ParquetClassLibrary.Properties.Resources.ErrorUnsupportedSerialization')
  - [ErrorUornsupportedVersion](#P-ParquetClassLibrary-Properties-Resources-ErrorUornsupportedVersion 'ParquetClassLibrary.Properties.Resources.ErrorUornsupportedVersion')
  - [ResourceManager](#P-ParquetClassLibrary-Properties-Resources-ResourceManager 'ParquetClassLibrary.Properties.Resources.ResourceManager')
  - [WarningTriedToGiveNothing](#P-ParquetClassLibrary-Properties-Resources-WarningTriedToGiveNothing 'ParquetClassLibrary.Properties.Resources.WarningTriedToGiveNothing')
  - [WarningTriedToStoreNothing](#P-ParquetClassLibrary-Properties-Resources-WarningTriedToStoreNothing 'ParquetClassLibrary.Properties.Resources.WarningTriedToStoreNothing')
- [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room')
- [Room](#T-ParquetClassLibrary-Rules-Recipes-Room 'ParquetClassLibrary.Rules.Recipes.Room')
  - [#ctor(inWalkableArea,inPerimeter)](#M-ParquetClassLibrary-Rooms-Room-#ctor-ParquetClassLibrary-Rooms-MapSpaceCollection,ParquetClassLibrary-Rooms-MapSpaceCollection- 'ParquetClassLibrary.Rooms.Room.#ctor(ParquetClassLibrary.Rooms.MapSpaceCollection,ParquetClassLibrary.Rooms.MapSpaceCollection)')
  - [MaxWalkableSpaces](#F-ParquetClassLibrary-Rules-Recipes-Room-MaxWalkableSpaces 'ParquetClassLibrary.Rules.Recipes.Room.MaxWalkableSpaces')
  - [MinPerimeterSpaces](#F-ParquetClassLibrary-Rules-Recipes-Room-MinPerimeterSpaces 'ParquetClassLibrary.Rules.Recipes.Room.MinPerimeterSpaces')
  - [MinWalkableSpaces](#F-ParquetClassLibrary-Rules-Recipes-Room-MinWalkableSpaces 'ParquetClassLibrary.Rules.Recipes.Room.MinWalkableSpaces')
  - [FurnishingTags](#P-ParquetClassLibrary-Rooms-Room-FurnishingTags 'ParquetClassLibrary.Rooms.Room.FurnishingTags')
  - [Perimeter](#P-ParquetClassLibrary-Rooms-Room-Perimeter 'ParquetClassLibrary.Rooms.Room.Perimeter')
  - [Position](#P-ParquetClassLibrary-Rooms-Room-Position 'ParquetClassLibrary.Rooms.Room.Position')
  - [RecipeID](#P-ParquetClassLibrary-Rooms-Room-RecipeID 'ParquetClassLibrary.Rooms.Room.RecipeID')
  - [WalkableArea](#P-ParquetClassLibrary-Rooms-Room-WalkableArea 'ParquetClassLibrary.Rooms.Room.WalkableArea')
  - [ContainsPosition(inPosition)](#M-ParquetClassLibrary-Rooms-Room-ContainsPosition-ParquetClassLibrary-Vector2D- 'ParquetClassLibrary.Rooms.Room.ContainsPosition(ParquetClassLibrary.Vector2D)')
  - [Equals(inRoom)](#M-ParquetClassLibrary-Rooms-Room-Equals-ParquetClassLibrary-Rooms-Room- 'ParquetClassLibrary.Rooms.Room.Equals(ParquetClassLibrary.Rooms.Room)')
  - [Equals(obj)](#M-ParquetClassLibrary-Rooms-Room-Equals-System-Object- 'ParquetClassLibrary.Rooms.Room.Equals(System.Object)')
  - [FindBestMatch()](#M-ParquetClassLibrary-Rooms-Room-FindBestMatch 'ParquetClassLibrary.Rooms.Room.FindBestMatch')
  - [GetHashCode()](#M-ParquetClassLibrary-Rooms-Room-GetHashCode 'ParquetClassLibrary.Rooms.Room.GetHashCode')
  - [op_Equality(inRoom1,inRoom2)](#M-ParquetClassLibrary-Rooms-Room-op_Equality-ParquetClassLibrary-Rooms-Room,ParquetClassLibrary-Rooms-Room- 'ParquetClassLibrary.Rooms.Room.op_Equality(ParquetClassLibrary.Rooms.Room,ParquetClassLibrary.Rooms.Room)')
  - [op_Inequality(inRoom1,inRoom2)](#M-ParquetClassLibrary-Rooms-Room-op_Inequality-ParquetClassLibrary-Rooms-Room,ParquetClassLibrary-Rooms-Room- 'ParquetClassLibrary.Rooms.Room.op_Inequality(ParquetClassLibrary.Rooms.Room,ParquetClassLibrary.Rooms.Room)')
- [RoomCollection](#T-ParquetClassLibrary-Rooms-RoomCollection 'ParquetClassLibrary.Rooms.RoomCollection')
  - [#ctor()](#M-ParquetClassLibrary-Rooms-RoomCollection-#ctor-System-Collections-Generic-IEnumerable{ParquetClassLibrary-Rooms-Room}- 'ParquetClassLibrary.Rooms.RoomCollection.#ctor(System.Collections.Generic.IEnumerable{ParquetClassLibrary.Rooms.Room})')
  - [Count](#P-ParquetClassLibrary-Rooms-RoomCollection-Count 'ParquetClassLibrary.Rooms.RoomCollection.Count')
  - [Rooms](#P-ParquetClassLibrary-Rooms-RoomCollection-Rooms 'ParquetClassLibrary.Rooms.RoomCollection.Rooms')
  - [Contains(inRoom)](#M-ParquetClassLibrary-Rooms-RoomCollection-Contains-ParquetClassLibrary-Rooms-Room- 'ParquetClassLibrary.Rooms.RoomCollection.Contains(ParquetClassLibrary.Rooms.Room)')
  - [CreateFromSubregion(inSubregion)](#M-ParquetClassLibrary-Rooms-RoomCollection-CreateFromSubregion-ParquetClassLibrary-Parquets-ParquetStackGrid- 'ParquetClassLibrary.Rooms.RoomCollection.CreateFromSubregion(ParquetClassLibrary.Parquets.ParquetStackGrid)')
  - [GetEnumerator()](#M-ParquetClassLibrary-Rooms-RoomCollection-GetEnumerator 'ParquetClassLibrary.Rooms.RoomCollection.GetEnumerator')
  - [GetRoomAt(inPosition)](#M-ParquetClassLibrary-Rooms-RoomCollection-GetRoomAt-ParquetClassLibrary-Vector2D- 'ParquetClassLibrary.Rooms.RoomCollection.GetRoomAt(ParquetClassLibrary.Vector2D)')
  - [System#Collections#IEnumerable#GetEnumerator()](#M-ParquetClassLibrary-Rooms-RoomCollection-System#Collections#IEnumerable#GetEnumerator 'ParquetClassLibrary.Rooms.RoomCollection.System#Collections#IEnumerable#GetEnumerator')
  - [ToString()](#M-ParquetClassLibrary-Rooms-RoomCollection-ToString 'ParquetClassLibrary.Rooms.RoomCollection.ToString')
- [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe')
  - [#ctor(inID,inName,inDescription,inComment,inMinimumWalkableSpaces,inOptionallyRequiredFurnishings,inOptionallyRequiredWalkableFloors,inOptionallyRequiredPerimeterBlocks)](#M-ParquetClassLibrary-Rooms-RoomRecipe-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Int32,System-Collections-Generic-IEnumerable{ParquetClassLibrary-RecipeElement},System-Collections-Generic-IEnumerable{ParquetClassLibrary-RecipeElement},System-Collections-Generic-IEnumerable{ParquetClassLibrary-RecipeElement}- 'ParquetClassLibrary.Rooms.RoomRecipe.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.Int32,System.Collections.Generic.IEnumerable{ParquetClassLibrary.RecipeElement},System.Collections.Generic.IEnumerable{ParquetClassLibrary.RecipeElement},System.Collections.Generic.IEnumerable{ParquetClassLibrary.RecipeElement})')
  - [MinimumWalkableSpaces](#P-ParquetClassLibrary-Rooms-RoomRecipe-MinimumWalkableSpaces 'ParquetClassLibrary.Rooms.RoomRecipe.MinimumWalkableSpaces')
  - [OptionallyRequiredFurnishings](#P-ParquetClassLibrary-Rooms-RoomRecipe-OptionallyRequiredFurnishings 'ParquetClassLibrary.Rooms.RoomRecipe.OptionallyRequiredFurnishings')
  - [OptionallyRequiredPerimeterBlocks](#P-ParquetClassLibrary-Rooms-RoomRecipe-OptionallyRequiredPerimeterBlocks 'ParquetClassLibrary.Rooms.RoomRecipe.OptionallyRequiredPerimeterBlocks')
  - [OptionallyRequiredWalkableFloors](#P-ParquetClassLibrary-Rooms-RoomRecipe-OptionallyRequiredWalkableFloors 'ParquetClassLibrary.Rooms.RoomRecipe.OptionallyRequiredWalkableFloors')
  - [Priority](#P-ParquetClassLibrary-Rooms-RoomRecipe-Priority 'ParquetClassLibrary.Rooms.RoomRecipe.Priority')
  - [Matches(inRoom)](#M-ParquetClassLibrary-Rooms-RoomRecipe-Matches-ParquetClassLibrary-Rooms-Room- 'ParquetClassLibrary.Rooms.RoomRecipe.Matches(ParquetClassLibrary.Rooms.Room)')
- [Rules](#T-ParquetClassLibrary-Rules 'ParquetClassLibrary.Rules')
- [RunState](#T-ParquetClassLibrary-Scripts-RunState 'ParquetClassLibrary.Scripts.RunState')
  - [Completed](#F-ParquetClassLibrary-Scripts-RunState-Completed 'ParquetClassLibrary.Scripts.RunState.Completed')
  - [InProgress](#F-ParquetClassLibrary-Scripts-RunState-InProgress 'ParquetClassLibrary.Scripts.RunState.InProgress')
  - [Unstarted](#F-ParquetClassLibrary-Scripts-RunState-Unstarted 'ParquetClassLibrary.Scripts.RunState.Unstarted')
- [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel')
  - [#ctor(inID,inName,inDescription,inComment,inNodes)](#M-ParquetClassLibrary-Scripts-ScriptModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Collections-Generic-IEnumerable{ParquetClassLibrary-Scripts-ScriptNode}- 'ParquetClassLibrary.Scripts.ScriptModel.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.Collections.Generic.IEnumerable{ParquetClassLibrary.Scripts.ScriptNode})')
  - [Nodes](#P-ParquetClassLibrary-Scripts-ScriptModel-Nodes 'ParquetClassLibrary.Scripts.ScriptModel.Nodes')
  - [GetActions()](#M-ParquetClassLibrary-Scripts-ScriptModel-GetActions 'ParquetClassLibrary.Scripts.ScriptModel.GetActions')
- [ScriptNode](#T-ParquetClassLibrary-Scripts-ScriptNode 'ParquetClassLibrary.Scripts.ScriptNode')
  - [None](#F-ParquetClassLibrary-Scripts-ScriptNode-None 'ParquetClassLibrary.Scripts.ScriptNode.None')
  - [nodeContent](#F-ParquetClassLibrary-Scripts-ScriptNode-nodeContent 'ParquetClassLibrary.Scripts.ScriptNode.nodeContent')
  - [ConverterFactory](#P-ParquetClassLibrary-Scripts-ScriptNode-ConverterFactory 'ParquetClassLibrary.Scripts.ScriptNode.ConverterFactory')
  - [CompareTo(inTag)](#M-ParquetClassLibrary-Scripts-ScriptNode-CompareTo-ParquetClassLibrary-Scripts-ScriptNode- 'ParquetClassLibrary.Scripts.ScriptNode.CompareTo(ParquetClassLibrary.Scripts.ScriptNode)')
  - [ConvertFromString(inText,inRow,inMemberMapData)](#M-ParquetClassLibrary-Scripts-ScriptNode-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData- 'ParquetClassLibrary.Scripts.ScriptNode.ConvertFromString(System.String,CsvHelper.IReaderRow,CsvHelper.Configuration.MemberMapData)')
  - [ConvertToString(inValue,inRow,inMemberMapData)](#M-ParquetClassLibrary-Scripts-ScriptNode-ConvertToString-System-Object,CsvHelper-IWriterRow,CsvHelper-Configuration-MemberMapData- 'ParquetClassLibrary.Scripts.ScriptNode.ConvertToString(System.Object,CsvHelper.IWriterRow,CsvHelper.Configuration.MemberMapData)')
  - [GetAction()](#M-ParquetClassLibrary-Scripts-ScriptNode-GetAction 'ParquetClassLibrary.Scripts.ScriptNode.GetAction')
  - [ParseCommand(inCommandText,inSourceText,inTargetText)](#M-ParquetClassLibrary-Scripts-ScriptNode-ParseCommand-System-String,System-String,System-String- 'ParquetClassLibrary.Scripts.ScriptNode.ParseCommand(System.String,System.String,System.String)')
  - [ToString()](#M-ParquetClassLibrary-Scripts-ScriptNode-ToString 'ParquetClassLibrary.Scripts.ScriptNode.ToString')
  - [op_Implicit(inValue)](#M-ParquetClassLibrary-Scripts-ScriptNode-op_Implicit-System-String-~ParquetClassLibrary-Scripts-ScriptNode 'ParquetClassLibrary.Scripts.ScriptNode.op_Implicit(System.String)~ParquetClassLibrary.Scripts.ScriptNode')
  - [op_Implicit(inNode)](#M-ParquetClassLibrary-Scripts-ScriptNode-op_Implicit-ParquetClassLibrary-Scripts-ScriptNode-~System-String 'ParquetClassLibrary.Scripts.ScriptNode.op_Implicit(ParquetClassLibrary.Scripts.ScriptNode)~System.String')
- [SearchResults](#T-ParquetClassLibrary-Rooms-MapSpaceCollection-SearchResults 'ParquetClassLibrary.Rooms.MapSpaceCollection.SearchResults')
  - [CycleFound](#F-ParquetClassLibrary-Rooms-MapSpaceCollection-SearchResults-CycleFound 'ParquetClassLibrary.Rooms.MapSpaceCollection.SearchResults.CycleFound')
  - [GoalFound](#F-ParquetClassLibrary-Rooms-MapSpaceCollection-SearchResults-GoalFound 'ParquetClassLibrary.Rooms.MapSpaceCollection.SearchResults.GoalFound')
  - [Visited](#F-ParquetClassLibrary-Rooms-MapSpaceCollection-SearchResults-Visited 'ParquetClassLibrary.Rooms.MapSpaceCollection.SearchResults.Visited')
- [SeriesConverter\`2](#T-ParquetClassLibrary-SeriesConverter`2 'ParquetClassLibrary.SeriesConverter`2')
  - [ConverterFactory](#P-ParquetClassLibrary-SeriesConverter`2-ConverterFactory 'ParquetClassLibrary.SeriesConverter`2.ConverterFactory')
  - [ConvertFromString(inText,inRow,inMemberMapData)](#M-ParquetClassLibrary-SeriesConverter`2-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData- 'ParquetClassLibrary.SeriesConverter`2.ConvertFromString(System.String,CsvHelper.IReaderRow,CsvHelper.Configuration.MemberMapData)')
  - [ConvertFromString(inText,inRow,inMemberMapData,inDelimiter)](#M-ParquetClassLibrary-SeriesConverter`2-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData,System-String- 'ParquetClassLibrary.SeriesConverter`2.ConvertFromString(System.String,CsvHelper.IReaderRow,CsvHelper.Configuration.MemberMapData,System.String)')
  - [ConvertToString(inValue,inRow,inMemberMapData)](#M-ParquetClassLibrary-SeriesConverter`2-ConvertToString-System-Object,CsvHelper-IWriterRow,CsvHelper-Configuration-MemberMapData- 'ParquetClassLibrary.SeriesConverter`2.ConvertToString(System.Object,CsvHelper.IWriterRow,CsvHelper.Configuration.MemberMapData)')
- [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel')
  - [#ctor()](#M-ParquetClassLibrary-Crafts-StrikePanel-#ctor 'ParquetClassLibrary.Crafts.StrikePanel.#ctor')
  - [#ctor(inWorkingRange,inIdealRange)](#M-ParquetClassLibrary-Crafts-StrikePanel-#ctor-ParquetClassLibrary-Range{System-Int32},ParquetClassLibrary-Range{System-Int32}- 'ParquetClassLibrary.Crafts.StrikePanel.#ctor(ParquetClassLibrary.Range{System.Int32},ParquetClassLibrary.Range{System.Int32})')
  - [Unused](#F-ParquetClassLibrary-Crafts-StrikePanel-Unused 'ParquetClassLibrary.Crafts.StrikePanel.Unused')
  - [defaultIdealRange](#F-ParquetClassLibrary-Crafts-StrikePanel-defaultIdealRange 'ParquetClassLibrary.Crafts.StrikePanel.defaultIdealRange')
  - [defaultWorkingRange](#F-ParquetClassLibrary-Crafts-StrikePanel-defaultWorkingRange 'ParquetClassLibrary.Crafts.StrikePanel.defaultWorkingRange')
  - [idealRangeBackingStruct](#F-ParquetClassLibrary-Crafts-StrikePanel-idealRangeBackingStruct 'ParquetClassLibrary.Crafts.StrikePanel.idealRangeBackingStruct')
  - [workingRangeBackingStruct](#F-ParquetClassLibrary-Crafts-StrikePanel-workingRangeBackingStruct 'ParquetClassLibrary.Crafts.StrikePanel.workingRangeBackingStruct')
  - [ConverterFactory](#P-ParquetClassLibrary-Crafts-StrikePanel-ConverterFactory 'ParquetClassLibrary.Crafts.StrikePanel.ConverterFactory')
  - [IdealRange](#P-ParquetClassLibrary-Crafts-StrikePanel-IdealRange 'ParquetClassLibrary.Crafts.StrikePanel.IdealRange')
  - [WorkingRange](#P-ParquetClassLibrary-Crafts-StrikePanel-WorkingRange 'ParquetClassLibrary.Crafts.StrikePanel.WorkingRange')
  - [Clone()](#M-ParquetClassLibrary-Crafts-StrikePanel-Clone 'ParquetClassLibrary.Crafts.StrikePanel.Clone')
  - [ConvertFromString(inText,inRow,inMemberMapData)](#M-ParquetClassLibrary-Crafts-StrikePanel-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData- 'ParquetClassLibrary.Crafts.StrikePanel.ConvertFromString(System.String,CsvHelper.IReaderRow,CsvHelper.Configuration.MemberMapData)')
  - [ConvertToString(inValue,inRow,inMemberMapData)](#M-ParquetClassLibrary-Crafts-StrikePanel-ConvertToString-System-Object,CsvHelper-IWriterRow,CsvHelper-Configuration-MemberMapData- 'ParquetClassLibrary.Crafts.StrikePanel.ConvertToString(System.Object,CsvHelper.IWriterRow,CsvHelper.Configuration.MemberMapData)')
  - [Equals(inStrikePanel)](#M-ParquetClassLibrary-Crafts-StrikePanel-Equals-ParquetClassLibrary-Crafts-StrikePanel- 'ParquetClassLibrary.Crafts.StrikePanel.Equals(ParquetClassLibrary.Crafts.StrikePanel)')
  - [Equals(obj)](#M-ParquetClassLibrary-Crafts-StrikePanel-Equals-System-Object- 'ParquetClassLibrary.Crafts.StrikePanel.Equals(System.Object)')
  - [GetHashCode()](#M-ParquetClassLibrary-Crafts-StrikePanel-GetHashCode 'ParquetClassLibrary.Crafts.StrikePanel.GetHashCode')
  - [ToString()](#M-ParquetClassLibrary-Crafts-StrikePanel-ToString 'ParquetClassLibrary.Crafts.StrikePanel.ToString')
  - [op_Equality(inStrikePanel1,inStrikePanel2)](#M-ParquetClassLibrary-Crafts-StrikePanel-op_Equality-ParquetClassLibrary-Crafts-StrikePanel,ParquetClassLibrary-Crafts-StrikePanel- 'ParquetClassLibrary.Crafts.StrikePanel.op_Equality(ParquetClassLibrary.Crafts.StrikePanel,ParquetClassLibrary.Crafts.StrikePanel)')
  - [op_Inequality(inStrikePanel1,inStrikePanel2)](#M-ParquetClassLibrary-Crafts-StrikePanel-op_Inequality-ParquetClassLibrary-Crafts-StrikePanel,ParquetClassLibrary-Crafts-StrikePanel- 'ParquetClassLibrary.Crafts.StrikePanel.op_Inequality(ParquetClassLibrary.Crafts.StrikePanel,ParquetClassLibrary.Crafts.StrikePanel)')
- [StrikePanelArrayExtensions](#T-ParquetClassLibrary-Crafts-StrikePanelArrayExtensions 'ParquetClassLibrary.Crafts.StrikePanelArrayExtensions')
  - [IsValidPosition(inStrikePanels,inPosition)](#M-ParquetClassLibrary-Crafts-StrikePanelArrayExtensions-IsValidPosition-ParquetClassLibrary-Crafts-StrikePanel[0-,0-],ParquetClassLibrary-Vector2D- 'ParquetClassLibrary.Crafts.StrikePanelArrayExtensions.IsValidPosition(ParquetClassLibrary.Crafts.StrikePanel[0:,0:],ParquetClassLibrary.Vector2D)')
- [StrikePanelGrid](#T-ParquetClassLibrary-Crafts-StrikePanelGrid 'ParquetClassLibrary.Crafts.StrikePanelGrid')
  - [#ctor()](#M-ParquetClassLibrary-Crafts-StrikePanelGrid-#ctor 'ParquetClassLibrary.Crafts.StrikePanelGrid.#ctor')
  - [#ctor(inRowCount,inColumnCount)](#M-ParquetClassLibrary-Crafts-StrikePanelGrid-#ctor-System-Int32,System-Int32- 'ParquetClassLibrary.Crafts.StrikePanelGrid.#ctor(System.Int32,System.Int32)')
  - [Columns](#P-ParquetClassLibrary-Crafts-StrikePanelGrid-Columns 'ParquetClassLibrary.Crafts.StrikePanelGrid.Columns')
  - [Count](#P-ParquetClassLibrary-Crafts-StrikePanelGrid-Count 'ParquetClassLibrary.Crafts.StrikePanelGrid.Count')
  - [Item](#P-ParquetClassLibrary-Crafts-StrikePanelGrid-Item-System-Int32,System-Int32- 'ParquetClassLibrary.Crafts.StrikePanelGrid.Item(System.Int32,System.Int32)')
  - [Rows](#P-ParquetClassLibrary-Crafts-StrikePanelGrid-Rows 'ParquetClassLibrary.Crafts.StrikePanelGrid.Rows')
  - [StrikePanels](#P-ParquetClassLibrary-Crafts-StrikePanelGrid-StrikePanels 'ParquetClassLibrary.Crafts.StrikePanelGrid.StrikePanels')
  - [GetEnumerator()](#M-ParquetClassLibrary-Crafts-StrikePanelGrid-GetEnumerator 'ParquetClassLibrary.Crafts.StrikePanelGrid.GetEnumerator')
  - [IsValidPosition(inPosition)](#M-ParquetClassLibrary-Crafts-StrikePanelGrid-IsValidPosition-ParquetClassLibrary-Vector2D- 'ParquetClassLibrary.Crafts.StrikePanelGrid.IsValidPosition(ParquetClassLibrary.Vector2D)')
  - [System#Collections#Generic#IEnumerable{ParquetClassLibrary#Crafts#StrikePanel}#GetEnumerator()](#M-ParquetClassLibrary-Crafts-StrikePanelGrid-System#Collections#Generic#IEnumerable{ParquetClassLibrary#Crafts#StrikePanel}#GetEnumerator 'ParquetClassLibrary.Crafts.StrikePanelGrid.System#Collections#Generic#IEnumerable{ParquetClassLibrary#Crafts#StrikePanel}#GetEnumerator')
- [Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D')
  - [#ctor(inX,inY)](#M-ParquetClassLibrary-Vector2D-#ctor-System-Int32,System-Int32- 'ParquetClassLibrary.Vector2D.#ctor(System.Int32,System.Int32)')
  - [East](#F-ParquetClassLibrary-Vector2D-East 'ParquetClassLibrary.Vector2D.East')
  - [North](#F-ParquetClassLibrary-Vector2D-North 'ParquetClassLibrary.Vector2D.North')
  - [South](#F-ParquetClassLibrary-Vector2D-South 'ParquetClassLibrary.Vector2D.South')
  - [Unit](#F-ParquetClassLibrary-Vector2D-Unit 'ParquetClassLibrary.Vector2D.Unit')
  - [West](#F-ParquetClassLibrary-Vector2D-West 'ParquetClassLibrary.Vector2D.West')
  - [Zero](#F-ParquetClassLibrary-Vector2D-Zero 'ParquetClassLibrary.Vector2D.Zero')
  - [ConverterFactory](#P-ParquetClassLibrary-Vector2D-ConverterFactory 'ParquetClassLibrary.Vector2D.ConverterFactory')
  - [Magnitude](#P-ParquetClassLibrary-Vector2D-Magnitude 'ParquetClassLibrary.Vector2D.Magnitude')
  - [X](#P-ParquetClassLibrary-Vector2D-X 'ParquetClassLibrary.Vector2D.X')
  - [Y](#P-ParquetClassLibrary-Vector2D-Y 'ParquetClassLibrary.Vector2D.Y')
  - [ConvertFromString(inText,inRow,inMemberMapData)](#M-ParquetClassLibrary-Vector2D-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData- 'ParquetClassLibrary.Vector2D.ConvertFromString(System.String,CsvHelper.IReaderRow,CsvHelper.Configuration.MemberMapData)')
  - [ConvertToString(inValue,inRow,inMemberMapData)](#M-ParquetClassLibrary-Vector2D-ConvertToString-System-Object,CsvHelper-IWriterRow,CsvHelper-Configuration-MemberMapData- 'ParquetClassLibrary.Vector2D.ConvertToString(System.Object,CsvHelper.IWriterRow,CsvHelper.Configuration.MemberMapData)')
  - [Equals(inVector)](#M-ParquetClassLibrary-Vector2D-Equals-ParquetClassLibrary-Vector2D- 'ParquetClassLibrary.Vector2D.Equals(ParquetClassLibrary.Vector2D)')
  - [Equals(obj)](#M-ParquetClassLibrary-Vector2D-Equals-System-Object- 'ParquetClassLibrary.Vector2D.Equals(System.Object)')
  - [GetHashCode()](#M-ParquetClassLibrary-Vector2D-GetHashCode 'ParquetClassLibrary.Vector2D.GetHashCode')
  - [ToString()](#M-ParquetClassLibrary-Vector2D-ToString 'ParquetClassLibrary.Vector2D.ToString')
  - [op_Addition(inVector1,inVector2)](#M-ParquetClassLibrary-Vector2D-op_Addition-ParquetClassLibrary-Vector2D,ParquetClassLibrary-Vector2D- 'ParquetClassLibrary.Vector2D.op_Addition(ParquetClassLibrary.Vector2D,ParquetClassLibrary.Vector2D)')
  - [op_Equality(inVector1,inVector2)](#M-ParquetClassLibrary-Vector2D-op_Equality-ParquetClassLibrary-Vector2D,ParquetClassLibrary-Vector2D- 'ParquetClassLibrary.Vector2D.op_Equality(ParquetClassLibrary.Vector2D,ParquetClassLibrary.Vector2D)')
  - [op_Inequality(inVector1,inVector2)](#M-ParquetClassLibrary-Vector2D-op_Inequality-ParquetClassLibrary-Vector2D,ParquetClassLibrary-Vector2D- 'ParquetClassLibrary.Vector2D.op_Inequality(ParquetClassLibrary.Vector2D,ParquetClassLibrary.Vector2D)')
  - [op_Multiply(inScalar,inVector)](#M-ParquetClassLibrary-Vector2D-op_Multiply-System-Int32,ParquetClassLibrary-Vector2D- 'ParquetClassLibrary.Vector2D.op_Multiply(System.Int32,ParquetClassLibrary.Vector2D)')
  - [op_Subtraction(inVector1,inVector2)](#M-ParquetClassLibrary-Vector2D-op_Subtraction-ParquetClassLibrary-Vector2D,ParquetClassLibrary-Vector2D- 'ParquetClassLibrary.Vector2D.op_Subtraction(ParquetClassLibrary.Vector2D,ParquetClassLibrary.Vector2D)')

<a name='T-ParquetClassLibrary-All'></a>
## All `type`

##### Namespace

ParquetClassLibrary

##### Summary

Provides content and identifiers for the game.

##### Remarks

This is the source of truth about game objects whose definitions do not change during play.



For more details, see remarks on [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model').

##### See Also

- [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')
- [ParquetClassLibrary.ModelCollection\`1](#T-ParquetClassLibrary-ModelCollection`1 'ParquetClassLibrary.ModelCollection`1')

<a name='F-ParquetClassLibrary-All-BeingIDs'></a>
### BeingIDs `constants`

##### Summary

A collection containing all defined [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1')s of [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel')s.

<a name='F-ParquetClassLibrary-All-BiomeIDs'></a>
### BiomeIDs `constants`

##### Summary

A subset of the values of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') set aside for [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel')s.
Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Biomes.

<a name='F-ParquetClassLibrary-All-BlockIDs'></a>
### BlockIDs `constants`

##### Summary

A subset of the values of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') set aside for [BlockModel](#T-ParquetClassLibrary-Parquets-BlockModel 'ParquetClassLibrary.Parquets.BlockModel')s.
Valid identifiers may be positive or negative.  By convention, negative IDs indicate test parquets.

<a name='F-ParquetClassLibrary-All-CharacterIDs'></a>
### CharacterIDs `constants`

##### Summary

A subset of the values of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') set aside for [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel')s.
Valid identifiers may be positive or negative.  By convention, negative IDs indicate test NPCs.

<a name='F-ParquetClassLibrary-All-CollectibleIDs'></a>
### CollectibleIDs `constants`

##### Summary

A subset of the values of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') set aside for [CollectibleModel](#T-ParquetClassLibrary-Parquets-CollectibleModel 'ParquetClassLibrary.Parquets.CollectibleModel')s.
Valid identifiers may be positive or negative.  By convention, negative IDs indicate test parquets.

<a name='F-ParquetClassLibrary-All-CraftingRecipeIDs'></a>
### CraftingRecipeIDs `constants`

##### Summary

A subset of the values of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') set aside for [CraftingRecipe](#T-ParquetClassLibrary-Crafts-CraftingRecipe 'ParquetClassLibrary.Crafts.CraftingRecipe')s.
Valid identifiers may be positive or negative.  By convention, negative IDs indicate test recipes.

<a name='F-ParquetClassLibrary-All-CritterIDs'></a>
### CritterIDs `constants`

##### Summary

A subset of the values of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') set aside for [CritterModel](#T-ParquetClassLibrary-Beings-CritterModel 'ParquetClassLibrary.Beings.CritterModel')s.
Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Critters.

<a name='F-ParquetClassLibrary-All-FloorIDs'></a>
### FloorIDs `constants`

##### Summary

A subset of the values of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') set aside for [FloorModel](#T-ParquetClassLibrary-Parquets-FloorModel 'ParquetClassLibrary.Parquets.FloorModel')s.
Valid identifiers may be positive or negative.  By convention, negative IDs indicate test parquets.

<a name='F-ParquetClassLibrary-All-FurnishingIDs'></a>
### FurnishingIDs `constants`

##### Summary

A subset of the values of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') set aside for [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel')s.
Valid identifiers may be positive or negative.  By convention, negative IDs indicate test parquets.

<a name='F-ParquetClassLibrary-All-InteractionIDs'></a>
### InteractionIDs `constants`

##### Summary

A subset of the values of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') set aside for [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel')s.
Valid identifiers may be positive or negative.  By convention, negative IDs indicate test recipes.

<a name='F-ParquetClassLibrary-All-ItemIDs'></a>
### ItemIDs `constants`

##### Summary

A subset of the values of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') set aside for [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel')s.
Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Items.

<a name='F-ParquetClassLibrary-All-MapChunkIDs'></a>
### MapChunkIDs `constants`

##### Summary

A subset of the values of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') set aside for [MapChunk](#T-ParquetClassLibrary-Maps-MapChunk 'ParquetClassLibrary.Maps.MapChunk')s.
Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Items.

<a name='F-ParquetClassLibrary-All-MapIDs'></a>
### MapIDs `constants`

##### Summary

A subset of the values of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') set aside for [MapModel](#T-ParquetClassLibrary-Maps-MapModel 'ParquetClassLibrary.Maps.MapModel')s.
Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Items.

<a name='F-ParquetClassLibrary-All-MapRegionIDs'></a>
### MapRegionIDs `constants`

##### Summary

A subset of the values of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') set aside for [MapRegion](#T-ParquetClassLibrary-Maps-MapRegion 'ParquetClassLibrary.Maps.MapRegion')s.
Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Items.

<a name='F-ParquetClassLibrary-All-ParquetIDs'></a>
### ParquetIDs `constants`

##### Summary

A collection containing all defined [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1')s of parquets.

<a name='F-ParquetClassLibrary-All-PlayerIDs'></a>
### PlayerIDs `constants`

##### Summary

A subset of the values of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') set aside for identifying active players.
Valid identifiers may be positive or negative.  By convention, negative IDs indicate test characters.

<a name='F-ParquetClassLibrary-All-RoomRecipeIDs'></a>
### RoomRecipeIDs `constants`

##### Summary

A subset of the values of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') set aside for [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe')s.
Valid identifiers may be positive or negative.  By convention, negative IDs indicate test recipes.

<a name='F-ParquetClassLibrary-All-ScriptIDs'></a>
### ScriptIDs `constants`

##### Summary

A subset of the values of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') set aside for [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel')s.
Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Items.

<a name='F-ParquetClassLibrary-All-SerializedNumberStyle'></a>
### SerializedNumberStyle `constants`

##### Summary

Instructions for integer parsing.

<a name='P-ParquetClassLibrary-All-Beings'></a>
### Beings `property`

##### Summary

A collection of all defined [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel')s.
This collection is the source of truth about mobs and characters for the rest of the library,
something like a color palette that other classes can paint with.

##### Remarks

All [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s must be unique.

<a name='P-ParquetClassLibrary-All-Biomes'></a>
### Biomes `property`

##### Summary

A collection of all defined [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel')s.
This collection is the source of truth about biome for the rest of the library,
something like a color palette that other classes can paint with.

##### Remarks

All [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s must be unique.

<a name='P-ParquetClassLibrary-All-CollectionsHaveBeenInitialized'></a>
### CollectionsHaveBeenInitialized `property`

##### Summary

`true` if the collections have been initialized; otherwise, `false`.

<a name='P-ParquetClassLibrary-All-ConversionConverters'></a>
### ConversionConverters `property`

##### Summary

Mappings for all classes serialized via [ITypeConverter](#T-CsvHelper-TypeConversion-ITypeConverter 'CsvHelper.TypeConversion.ITypeConverter').

<a name='P-ParquetClassLibrary-All-CraftingRecipes'></a>
### CraftingRecipes `property`

##### Summary

A collection of all defined [CraftingRecipe](#T-ParquetClassLibrary-Crafts-CraftingRecipe 'ParquetClassLibrary.Crafts.CraftingRecipe')s.
This collection is the source of truth about crafting for the rest of the library,
something like a color palette that other classes can paint with.

##### Remarks

All [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s must be unique.

<a name='P-ParquetClassLibrary-All-IdentifierOptions'></a>
### IdentifierOptions `property`

##### Summary

Instructions for handling type conversion when reading identifiers.

<a name='P-ParquetClassLibrary-All-Interactions'></a>
### Interactions `property`

##### Summary

A collection of all defined [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel')s.
This collection is the source of truth about crafting for the rest of the library,
something like a color palette that other classes can paint with.

##### Remarks

All [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s must be unique.

<a name='P-ParquetClassLibrary-All-Items'></a>
### Items `property`

##### Summary

A collection of all defined [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel')s.
This collection is the source of truth about items for the rest of the library,
something like a color palette that other classes can paint with.

##### Remarks

All [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s must be unique.

<a name='P-ParquetClassLibrary-All-Maps'></a>
### Maps `property`

##### Summary

A collection of all defined [MapModel](#T-ParquetClassLibrary-Maps-MapModel 'ParquetClassLibrary.Maps.MapModel')s.
This collection is the source of truth about biome for the rest of the library,
something like a color palette that other classes can paint with.

##### Remarks

All [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s must be unique.

<a name='P-ParquetClassLibrary-All-Parquets'></a>
### Parquets `property`

##### Summary

A collection of all defined parquets of all subtypes.
This collection is the source of truth about parquets for the rest of the library,
something like a color palette that other classes can paint with.

##### Remarks

All [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s must be unique.

<a name='P-ParquetClassLibrary-All-PronounGroups'></a>
### PronounGroups `property`

##### Summary

A collection of all defined [PronounGroup](#T-ParquetClassLibrary-Beings-PronounGroup 'ParquetClassLibrary.Beings.PronounGroup')s.
This collection is the source of truth about pronouns for the rest of the library.

<a name='P-ParquetClassLibrary-All-RoomRecipes'></a>
### RoomRecipes `property`

##### Summary

A collection of all defined [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe')s.
This collection is the source of truth about crafting for the rest of the library,
something like a color palette that other classes can paint with.

##### Remarks

All [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s must be unique.

<a name='P-ParquetClassLibrary-All-Scripts'></a>
### Scripts `property`

##### Summary

A collection of all defined [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel')s.
This collection is the source of truth about crafting for the rest of the library,
something like a color palette that other classes can paint with.

##### Remarks

All [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s must be unique.

<a name='P-ParquetClassLibrary-All-SerializedCultureInfo'></a>
### SerializedCultureInfo `property`

##### Summary

Instructions for string parsing.

<a name='P-ParquetClassLibrary-All-WorkingDirectory'></a>
### WorkingDirectory `property`

##### Summary

The location of the designer CSV files, set to either the working directory
or a predefined designer directory, depending on build type.

<a name='M-ParquetClassLibrary-All-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes the [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1')s and [ModelCollection\`1](#T-ParquetClassLibrary-ModelCollection`1 'ParquetClassLibrary.ModelCollection`1')s defined in [All](#T-ParquetClassLibrary-All 'ParquetClassLibrary.All').

##### Parameters

This method has no parameters.

##### Remarks

This supports defining ItemIDs in terms of the other Ranges.

<a name='M-ParquetClassLibrary-All-InitializeCollections-System-Collections-Generic-IEnumerable{ParquetClassLibrary-Beings-PronounGroup},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Beings-BeingModel},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Biomes-BiomeModel},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Crafts-CraftingRecipe},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Scripts-InteractionModel},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Maps-MapModel},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Parquets-ParquetModel},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Rooms-RoomRecipe},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Scripts-ScriptModel},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Items-ItemModel}-'></a>
### InitializeCollections(inPronouns,inBeings,inBiomes,inCraftingRecipes,inInteractions,inMaps,inParquets,inRoomRecipes,inScripts,inItems) `method`

##### Summary

Initializes the [ModelCollection\`1](#T-ParquetClassLibrary-ModelCollection`1 'ParquetClassLibrary.ModelCollection`1')s from the given collections.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inPronouns | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Beings.PronounGroup}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Beings.PronounGroup}') | The pronouns that the game knows by default. |
| inBeings | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Beings.BeingModel}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Beings.BeingModel}') | All beings to be used in the game. |
| inBiomes | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Biomes.BiomeModel}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Biomes.BiomeModel}') | All biomes to be used in the game. |
| inCraftingRecipes | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Crafts.CraftingRecipe}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Crafts.CraftingRecipe}') | All crafting recipes to be used in the game. |
| inInteractions | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Scripts.InteractionModel}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Scripts.InteractionModel}') | All interactions to be used in the game. |
| inMaps | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Maps.MapModel}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Maps.MapModel}') | All maps to be used in the game. |
| inParquets | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Parquets.ParquetModel}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Parquets.ParquetModel}') | All parquets to be used in the game. |
| inRoomRecipes | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Rooms.RoomRecipe}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Rooms.RoomRecipe}') | All room recipes to be used in the game. |
| inScripts | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Scripts.ScriptModel}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Scripts.ScriptModel}') | All scripts to be used in the game. |
| inItems | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Items.ItemModel}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Items.ItemModel}') | All items to be used in the game. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | When called more than once. |

##### Remarks

This initialization routine may be called only once per library execution.

<a name='M-ParquetClassLibrary-All-LoadFromCSVs'></a>
### LoadFromCSVs() `method`

##### Summary

Initializes [All](#T-ParquetClassLibrary-All 'ParquetClassLibrary.All') based on the values in design-time CSV files.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-All-SaveToCSVs'></a>
### SaveToCSVs() `method`

##### Summary

Stores the content of [All](#T-ParquetClassLibrary-All 'ParquetClassLibrary.All') to CSV files for later reinitialization.

##### Parameters

This method has no parameters.

<a name='T-ParquetClassLibrary-AssemblyInfo'></a>
## AssemblyInfo `type`

##### Namespace

ParquetClassLibrary

##### Summary

Provides assembly-wide information.

<a name='F-ParquetClassLibrary-AssemblyInfo-LibraryVersion'></a>
### LibraryVersion `constants`

##### Summary

Describes the version of the class library itself.

##### Remarks

The version has the format "{Major}.{Minor}.{Patch}.{Build}".
- Major: Enhancements or fixes that break the API or its serialized data.
- Minor: Enhancements that do not break the API or its serialized data.
- Patch: Fixes that do not break the API or its serialized data.
- Build: Procedural updates that do not imply any changes, such as when rebuilding for APK/IPA submission.

<a name='F-ParquetClassLibrary-AssemblyInfo-SupportedBeingDataVersion'></a>
### SupportedBeingDataVersion `constants`

##### Summary

Describes the version of the serialized [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel')
data that the class library understands.

##### Remarks

The version has the format "{Major}.{Minor}.{Build}".
- Major: Breaking changes resulting in lost saves.
- Minor: Backwards-compatible changes, preserving existing saves.

<a name='F-ParquetClassLibrary-AssemblyInfo-SupportedMapDataVersion'></a>
### SupportedMapDataVersion `constants`

##### Summary

Describes the version of the serialized [MapModel](#T-ParquetClassLibrary-Maps-MapModel 'ParquetClassLibrary.Maps.MapModel')
data that the class library understands.

##### Remarks

The version has the format "{Major}.{Minor}.{Build}".
- Major: Breaking changes resulting in lost saves.
- Minor: Backwards-compatible changes, preserving existing saves.

<a name='F-ParquetClassLibrary-AssemblyInfo-SupportedScriptDataVersion'></a>
### SupportedScriptDataVersion `constants`

##### Summary

Describes the version of the serialized [ScriptNode](#T-ParquetClassLibrary-Scripts-ScriptNode 'ParquetClassLibrary.Scripts.ScriptNode')
data that the class library understands.

##### Remarks

The version has the format "{Major}.{Minor}.{Build}".
- Major: Breaking changes resulting in lost saves.
- Minor: Backwards-compatible changes, preserving existing saves.

<a name='T-ParquetClassLibrary-Beings-BeingModel'></a>
## BeingModel `type`

##### Namespace

ParquetClassLibrary.Beings

##### Summary

Models the basic definitions shared by any in-game actor.

<a name='M-ParquetClassLibrary-Beings-BeingModel-#ctor-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},ParquetClassLibrary-ModelID,System-String,System-String,System-String,ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID,System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID}-'></a>
### #ctor(inBounds,inID,inName,inDescription,inComment,inNativeBiome,inPrimaryBehavior,inAvoids,inSeeks) `constructor`

##### Summary

Used by [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') subtypes.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inBounds | [ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}](#T-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID} 'ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}') | The bounds within which the [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel')'s [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') is defined.
Must be one of [BeingIDs](#F-ParquetClassLibrary-All-BeingIDs 'ParquetClassLibrary.All.BeingIDs'). |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | Unique identifier for the [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel').  Cannot be null. |
| inName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly name of the [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel').  Cannot be null or empty. |
| inDescription | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly description of the [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel'). |
| inComment | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Comment of, on, or by the [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel'). |
| inNativeBiome | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') for the [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel') in which this [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') is most comfortable. |
| inPrimaryBehavior | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The rules that govern how this [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') acts.  Cannot be null. |
| inAvoids | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}') | Any parquets this [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') avoids. |
| inSeeks | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}') | Any parquets this [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') seeks. |

<a name='P-ParquetClassLibrary-Beings-BeingModel-Avoids'></a>
### Avoids `property`

##### Summary

Types of parquets this [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') avoids, if any.

<a name='P-ParquetClassLibrary-Beings-BeingModel-NativeBiome'></a>
### NativeBiome `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel') in which this character is at home.

<a name='P-ParquetClassLibrary-Beings-BeingModel-PrimaryBehavior'></a>
### PrimaryBehavior `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel') governing the way this being acts.

<a name='P-ParquetClassLibrary-Beings-BeingModel-Seeks'></a>
### Seeks `property`

##### Summary

Types of parquets this [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') seeks out, if any.

<a name='T-ParquetClassLibrary-Beings-BeingStatus'></a>
## BeingStatus `type`

##### Namespace

ParquetClassLibrary.Beings

##### Summary

Models the status of a [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel').

<a name='M-ParquetClassLibrary-Beings-BeingStatus-#ctor-ParquetClassLibrary-Beings-BeingModel,ParquetClassLibrary-ModelID,ParquetClassLibrary-Location,ParquetClassLibrary-Location,System-Int32,System-Single,System-Single,System-Single,System-Single,System-Collections-Generic-List{ParquetClassLibrary-ModelID},System-Collections-Generic-List{ParquetClassLibrary-ModelID},System-Collections-Generic-List{ParquetClassLibrary-ModelID},System-Collections-Generic-List{ParquetClassLibrary-ModelID},System-Collections-Generic-List{ParquetClassLibrary-ModelID},System-Collections-Generic-List{ParquetClassLibrary-ModelID}-'></a>
### #ctor(inBeingDefinition,inPosition,inSpawnAt,inCurrentBehavior,inBiomeTimeRemaining,inBuildingSpeed,inModificationSpeed,inGatheringSpeed,inMovementSpeed,inKnownBeings,inKnownParquets,inKnownRoomRecipes,inKnownCraftingRecipes,inQuests,inInventory) `constructor`

##### Summary

Initializes a new instance of the [BeingStatus](#T-ParquetClassLibrary-Beings-BeingStatus 'ParquetClassLibrary.Beings.BeingStatus') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inBeingDefinition | [ParquetClassLibrary.Beings.BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') | The [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') whose status is being tracked. |
| inPosition | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The [Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location') the tracked [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') occupies. |
| inSpawnAt | [ParquetClassLibrary.Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location') | The [Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location') the tracked [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') will next spawn at. |
| inCurrentBehavior | [ParquetClassLibrary.Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location') | The behavior currently governing the tracked [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel'). |
| inBiomeTimeRemaining | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | How long [TODO in what units?] to until being kicked out of the current [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel'). |
| inBuildingSpeed | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | The time it takes the tracked [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') to place new parquets. |
| inModificationSpeed | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | The time it takes the tracked [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') to modify existing parquets. |
| inGatheringSpeed | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | The time it takes the tracked [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') to gather existing parquets. |
| inMovementSpeed | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | The time it takes the tracked [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') to walk from one [Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location') to another. |
| inKnownBeings | [System.Collections.Generic.List{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{ParquetClassLibrary.ModelID}') | The [CritterModel](#T-ParquetClassLibrary-Beings-CritterModel 'ParquetClassLibrary.Beings.CritterModel')s that this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') has encountered. |
| inKnownParquets | [System.Collections.Generic.List{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{ParquetClassLibrary.ModelID}') | The parquets that this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') has encountered. |
| inKnownRoomRecipes | [System.Collections.Generic.List{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{ParquetClassLibrary.ModelID}') | The [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe')s that this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') knows. |
| inKnownCraftingRecipes | [System.Collections.Generic.List{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{ParquetClassLibrary.ModelID}') | The [CraftingRecipe](#T-ParquetClassLibrary-Crafts-CraftingRecipe 'ParquetClassLibrary.Crafts.CraftingRecipe')s that this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') knows. |
| inQuests | [System.Collections.Generic.List{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{ParquetClassLibrary.ModelID}') | The [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel')s that this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') offers or has undertaken. |
| inInventory | [System.Collections.Generic.List{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{ParquetClassLibrary.ModelID}') | This [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel')'s set of belongings. |

<a name='P-ParquetClassLibrary-Beings-BeingStatus-BeingDefinition'></a>
### BeingDefinition `property`

##### Summary

The [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') whose status is being tracked.

<a name='P-ParquetClassLibrary-Beings-BeingStatus-BiomeTimeRemaining'></a>
### BiomeTimeRemaining `property`

##### Summary

The time remaining that the tracked [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') can safely remain in the current [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel').

##### Remarks

It is likely that this will only be used by [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') but may be useful for other beings as well.

<a name='P-ParquetClassLibrary-Beings-BeingStatus-BuildingSpeed'></a>
### BuildingSpeed `property`

##### Summary

The time it takes the tracked [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') to place new parquets.

<a name='P-ParquetClassLibrary-Beings-BeingStatus-CurrentBehavior'></a>
### CurrentBehavior `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') for the [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel') currently governing the tracked [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel').

<a name='P-ParquetClassLibrary-Beings-BeingStatus-DataVersion'></a>
### DataVersion `property`

##### Summary

Describes the version of serialized data.
Allows selecting data files that can be successfully deserialized.

<a name='P-ParquetClassLibrary-Beings-BeingStatus-GatheringSpeed'></a>
### GatheringSpeed `property`

##### Summary

The time it takes the tracked [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') to gather existing parquets.

<a name='P-ParquetClassLibrary-Beings-BeingStatus-Inventory'></a>
### Inventory `property`

##### Summary

This [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel')'s set of belongings.

<a name='P-ParquetClassLibrary-Beings-BeingStatus-KnownBeings'></a>
### KnownBeings `property`

##### Summary

The [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel')s that this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') has encountered.

<a name='P-ParquetClassLibrary-Beings-BeingStatus-KnownCraftingRecipes'></a>
### KnownCraftingRecipes `property`

##### Summary

The [CraftingRecipe](#T-ParquetClassLibrary-Crafts-CraftingRecipe 'ParquetClassLibrary.Crafts.CraftingRecipe')s that this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') knows.

<a name='P-ParquetClassLibrary-Beings-BeingStatus-KnownParquets'></a>
### KnownParquets `property`

##### Summary

The parquets that this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') has encountered.

<a name='P-ParquetClassLibrary-Beings-BeingStatus-KnownRoomRecipes'></a>
### KnownRoomRecipes `property`

##### Summary

The [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe')s that this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') knows.

<a name='P-ParquetClassLibrary-Beings-BeingStatus-ModificationSpeed'></a>
### ModificationSpeed `property`

##### Summary

The time it takes the tracked [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') to modify existing parquets.

<a name='P-ParquetClassLibrary-Beings-BeingStatus-MovementSpeed'></a>
### MovementSpeed `property`

##### Summary

The time it takes the tracked [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') to walk from one [Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location') to another.

<a name='P-ParquetClassLibrary-Beings-BeingStatus-Position'></a>
### Position `property`

##### Summary

The [Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location') the tracked [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') occupies.

<a name='P-ParquetClassLibrary-Beings-BeingStatus-Quests'></a>
### Quests `property`

##### Summary

The [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel')s that this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') offers or has undertaken.

<a name='P-ParquetClassLibrary-Beings-BeingStatus-Revision'></a>
### Revision `property`

##### Summary

Tracks how many times the data structure has been serialized.

<a name='P-ParquetClassLibrary-Beings-BeingStatus-RoomAssignment'></a>
### RoomAssignment `property`

##### Summary

The [Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location') the [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') assigned to this [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel').

<a name='P-ParquetClassLibrary-Beings-BeingStatus-SpawnAt'></a>
### SpawnAt `property`

##### Summary

The [Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location') the tracked [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') will next spawn at.

##### Remarks

For example, for [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel')s, this might be the spot the where when the game was last saved.

<a name='M-ParquetClassLibrary-Beings-BeingStatus-ToString'></a>
### ToString() `method`

##### Summary

Returns a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents the current [BeingStatus](#T-ParquetClassLibrary-Beings-BeingStatus 'ParquetClassLibrary.Beings.BeingStatus').

##### Returns

The representation.

##### Parameters

This method has no parameters.

<a name='T-ParquetClassLibrary-Rules-BiomeCriteria'></a>
## BiomeCriteria `type`

##### Namespace

ParquetClassLibrary.Rules

##### Summary

Provides rules for determining a [MapRegion](#T-ParquetClassLibrary-Maps-MapRegion 'ParquetClassLibrary.Maps.MapRegion')'s [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel').

<a name='F-ParquetClassLibrary-Rules-BiomeCriteria-FluidThreshold'></a>
### FluidThreshold `constants`

##### Summary

3/4ths of a layers' worth of parquets must contribute to a fluid-based [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel').

<a name='F-ParquetClassLibrary-Rules-BiomeCriteria-LandThreshold'></a>
### LandThreshold `constants`

##### Summary

1 and 1/4th of a layers' worth of parquets must contribute to a land-based [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel').

<a name='F-ParquetClassLibrary-Rules-BiomeCriteria-ParquetsPerLayer'></a>
### ParquetsPerLayer `constants`

##### Summary

Used in computing thresholds.

<a name='T-ParquetClassLibrary-Biomes-BiomeModel'></a>
## BiomeModel `type`

##### Namespace

ParquetClassLibrary.Biomes

##### Summary

Models the biome that a [MapRegion](#T-ParquetClassLibrary-Maps-MapRegion 'ParquetClassLibrary.Maps.MapRegion') embodies.

<a name='M-ParquetClassLibrary-Biomes-BiomeModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Int32,ParquetClassLibrary-Biomes-Elevation,System-Boolean,System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag}-'></a>
### #ctor(inID,inName,inDescription,inComment,inTier,inElevationCategory,inIsLiquidBased,inParquetCriteria,inEntryRequirements) `constructor`

##### Summary

Initializes a new instance of the [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | Unique identifier for the [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel').  Cannot be null. |
| inName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly name of the [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel').  Cannot be null or empty. |
| inDescription | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly description of the [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel'). |
| inComment | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Comment of, on, or by the [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel'). |
| inTier | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | A rating indicating where in the progression this [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel') falls. |
| inElevationCategory | [ParquetClassLibrary.Biomes.Elevation](#T-ParquetClassLibrary-Biomes-Elevation 'ParquetClassLibrary.Biomes.Elevation') | Describes where this [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel') falls in terms of the game world's overall topography. |
| inIsLiquidBased | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Determines whether or not this [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel') is defined in terms of liquid parquets. |
| inParquetCriteria | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}') | Describes the parquets that make up this [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel'). |
| inEntryRequirements | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}') | Describes the [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel')s needed to access this [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel'). |

<a name='P-ParquetClassLibrary-Biomes-BiomeModel-ElevationCategory'></a>
### ElevationCategory `property`

##### Summary

Describes where this [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel') falls in terms of the game world's overall topography.

<a name='P-ParquetClassLibrary-Biomes-BiomeModel-EntryRequirements'></a>
### EntryRequirements `property`

##### Summary

Describes the [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel')s a [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') needs to safely access this [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel').

<a name='P-ParquetClassLibrary-Biomes-BiomeModel-IsLiquidBased'></a>
### IsLiquidBased `property`

##### Summary

Determines whether or not this [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel') is defined in terms of liquid parquets.

<a name='P-ParquetClassLibrary-Biomes-BiomeModel-ParquetCriteria'></a>
### ParquetCriteria `property`

##### Summary

Describes the parquets that make up this [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel').

<a name='P-ParquetClassLibrary-Biomes-BiomeModel-Tier'></a>
### Tier `property`

##### Summary

A rating indicating where in the progression this [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel') falls.
Must be non-negative.  Higher values indicate later Biomes.

<a name='M-ParquetClassLibrary-Biomes-BiomeModel-GetAllTags'></a>
### GetAllTags() `method`

##### Summary

Returns a collection of all [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag')s the [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') has applied to it. Classes inheriting from [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') that include [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag') should override accordingly.

##### Returns

List of all [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag')s.

##### Parameters

This method has no parameters.

<a name='T-ParquetClassLibrary-Parquets-BlockModel'></a>
## BlockModel `type`

##### Namespace

ParquetClassLibrary.Parquets

##### Summary

Configurations for a sandbox parquet block.

<a name='M-ParquetClassLibrary-Parquets-BlockModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Nullable{ParquetClassLibrary-ModelID},ParquetClassLibrary-ModelTag,ParquetClassLibrary-ModelTag,ParquetClassLibrary-Items-GatheringTool,ParquetClassLibrary-Parquets-GatheringEffect,System-Nullable{ParquetClassLibrary-ModelID},System-Boolean,System-Boolean,System-Int32-'></a>
### #ctor(inID,inName,inDescription,inComment,inItemID,inAddsToBiome,inAddsToRoom,inGatherTool,inGatherEffect,inCollectibleID,inIsFlammable,inIsLiquid,inMaxToughness) `constructor`

##### Summary

Initializes a new instance of the [BlockModel](#T-ParquetClassLibrary-Parquets-BlockModel 'ParquetClassLibrary.Parquets.BlockModel') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | Unique identifier for the parquet.  Cannot be null. |
| inName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly name of the parquet.  Cannot be null. |
| inDescription | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly description of the parquet. |
| inComment | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Comment of, on, or by the parquet. |
| inItemID | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | The item that this collectible corresponds to, if any. |
| inAddsToBiome | [ParquetClassLibrary.ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag') | A set of flags indicating which, if any, [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel') this parquet helps to generate. |
| inAddsToRoom | [ParquetClassLibrary.ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag') | A set of flags indicating which, if any, [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe') this parquet helps to generate. |
| inGatherTool | [ParquetClassLibrary.Items.GatheringTool](#T-ParquetClassLibrary-Items-GatheringTool 'ParquetClassLibrary.Items.GatheringTool') | The tool used to gather this block. |
| inGatherEffect | [ParquetClassLibrary.Parquets.GatheringEffect](#T-ParquetClassLibrary-Parquets-GatheringEffect 'ParquetClassLibrary.Parquets.GatheringEffect') | Effect of this block when gathered. |
| inCollectibleID | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | The Collectible to spawn, if any, when this Block is Gathered. |
| inIsFlammable | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If `true` this block may burn. |
| inIsLiquid | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If `true` this block will flow. |
| inMaxToughness | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Representation of the difficulty involved in gathering this block. |

<a name='F-ParquetClassLibrary-Parquets-BlockModel-DefaultMaxToughness'></a>
### DefaultMaxToughness `constants`

##### Summary

Maximum toughness value to use when none is specified.

<a name='F-ParquetClassLibrary-Parquets-BlockModel-LowestPossibleToughness'></a>
### LowestPossibleToughness `constants`

##### Summary

Minimum toughness value for any Block.

<a name='P-ParquetClassLibrary-Parquets-BlockModel-Bounds'></a>
### Bounds `property`

##### Summary

The set of values that are allowed for Block IDs.

<a name='P-ParquetClassLibrary-Parquets-BlockModel-CollectibleID'></a>
### CollectibleID `property`

##### Summary

The Collectible spawned when a character gathers this Block.

<a name='P-ParquetClassLibrary-Parquets-BlockModel-GatherEffect'></a>
### GatherEffect `property`

##### Summary

The effect generated when a character gathers this Block.

<a name='P-ParquetClassLibrary-Parquets-BlockModel-GatherTool'></a>
### GatherTool `property`

##### Summary

The tool used to remove the block.

<a name='P-ParquetClassLibrary-Parquets-BlockModel-IsFlammable'></a>
### IsFlammable `property`

##### Summary

Whether or not the block is flammable.

<a name='P-ParquetClassLibrary-Parquets-BlockModel-IsLiquid'></a>
### IsLiquid `property`

##### Summary

Whether or not the block is a liquid.

<a name='P-ParquetClassLibrary-Parquets-BlockModel-MaxToughness'></a>
### MaxToughness `property`

##### Summary

The block's native toughness.

<a name='T-ParquetClassLibrary-Beings-CharacterModel'></a>
## CharacterModel `type`

##### Namespace

ParquetClassLibrary.Beings

##### Summary

Models the definitions of in-game actors that take part in the narrative.

<a name='M-ParquetClassLibrary-Beings-CharacterModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID,System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-String,System-String,System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID}-'></a>
### #ctor(inID,inName,inDescription,inComment,inNativeBiome,inPrimaryBehavior,inAvoids,inSeeks,inPronouns,inStoryCharacterID,inStartingQuests,inStartingDialogue,inStartingInventory) `constructor`

##### Summary

Initializes a new instance of the [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | Unique identifier for the [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel').  Cannot be null. |
| inName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Personal and family names of the [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel'), separated by a space.  Cannot be null or empty. |
| inDescription | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly description of the [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel'). |
| inComment | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Comment of, on, or by the [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel'). |
| inNativeBiome | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') for the [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel') in which this [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') is most comfortable. |
| inPrimaryBehavior | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The rules that govern how this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') acts.  Cannot be null. |
| inAvoids | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}') | Any parquets this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') avoids. |
| inSeeks | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}') | Any parquets this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') seeks. |
| inPronouns | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | How to refer to this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel'). |
| inStoryCharacterID | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A means of identifying this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') across multiple shipped game titles. |
| inStartingQuests | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}') | Any quests this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') has to offer or has undertaken. |
| inStartingDialogue | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}') | All dialogue this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') may say. |
| inStartingInventory | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}') | Any items this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') possesses at the outset. |

<a name='P-ParquetClassLibrary-Beings-CharacterModel-FamilyName'></a>
### FamilyName `property`

##### Summary

Player-facing family name.

<a name='P-ParquetClassLibrary-Beings-CharacterModel-PersonalName'></a>
### PersonalName `property`

##### Summary

Player-facing personal name.

<a name='P-ParquetClassLibrary-Beings-CharacterModel-Pronouns'></a>
### Pronouns `property`

##### Summary

A key for the [PronounGroup](#T-ParquetClassLibrary-Beings-PronounGroup 'ParquetClassLibrary.Beings.PronounGroup') the [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') uses,
stored as "[Objective](#P-ParquetClassLibrary-Beings-PronounGroup-Objective 'ParquetClassLibrary.Beings.PronounGroup.Objective')/[Subjective](#P-ParquetClassLibrary-Beings-PronounGroup-Subjective 'ParquetClassLibrary.Beings.PronounGroup.Subjective').

<a name='P-ParquetClassLibrary-Beings-CharacterModel-StartingDialogue'></a>
### StartingDialogue `property`

##### Summary

Dialogue lines this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') can say.

<a name='P-ParquetClassLibrary-Beings-CharacterModel-StartingInventory'></a>
### StartingInventory `property`

##### Summary

The set of belongings that this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') begins with.

##### Remarks

This is not the full [Inventory](#T-ParquetClassLibrary-Items-Inventory 'ParquetClassLibrary.Items.Inventory') but a list of item IDs to populate it with.

<a name='P-ParquetClassLibrary-Beings-CharacterModel-StartingQuests'></a>
### StartingQuests `property`

##### Summary

The [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel')s that this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') either offers or has undertaken.

##### Remarks

Typically, NPCs offer quests, player characters undertake them.

<a name='P-ParquetClassLibrary-Beings-CharacterModel-StoryCharacterID'></a>
### StoryCharacterID `property`

##### Summary

The story character that this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') represents.

##### Remarks

This identifier provides a link between software character classes
and the characters written of in a game's narrative that they represent.  The goal
is that these identifiers be able to span any number of shipped titles, allowing a
sequel title to import data from prior titles in such a way that one game's NPC
can become another game's protagonist.

<a name='T-ParquetClassLibrary-Maps-ChunkTopography'></a>
## ChunkTopography `type`

##### Namespace

ParquetClassLibrary.Maps

##### Summary

Indicates the basic form that the parquets in a [MapChunk](#T-ParquetClassLibrary-Maps-MapChunk 'ParquetClassLibrary.Maps.MapChunk') take.

<a name='F-ParquetClassLibrary-Maps-ChunkTopography-Central'></a>
### Central `constants`

##### Summary

Indicates a central grouping of parquets in this topography.

<a name='F-ParquetClassLibrary-Maps-ChunkTopography-Clustered'></a>
### Clustered `constants`

##### Summary

Indicates parquets appear in clumps throughout this topography.

<a name='F-ParquetClassLibrary-Maps-ChunkTopography-East'></a>
### East `constants`

##### Summary

Indicates parquets are grouped to the east end of this topography.

<a name='F-ParquetClassLibrary-Maps-ChunkTopography-Empty'></a>
### Empty `constants`

##### Summary

Indicates there are no parquets in this topography.

<a name='F-ParquetClassLibrary-Maps-ChunkTopography-North'></a>
### North `constants`

##### Summary

Indicates parquets are grouped to the north end of this topography.

<a name='F-ParquetClassLibrary-Maps-ChunkTopography-NorthEast'></a>
### NorthEast `constants`

##### Summary

Indicates parquets are grouped on both the north and east end of this topography.

<a name='F-ParquetClassLibrary-Maps-ChunkTopography-NorthWest'></a>
### NorthWest `constants`

##### Summary

Indicates parquets are grouped on both the north and west end of this topography.

<a name='F-ParquetClassLibrary-Maps-ChunkTopography-Scattered'></a>
### Scattered `constants`

##### Summary

Indicates parquets are spread evenly throughout this topography.

<a name='F-ParquetClassLibrary-Maps-ChunkTopography-Solid'></a>
### Solid `constants`

##### Summary

Indicates parquets entirely fill this topography.

<a name='F-ParquetClassLibrary-Maps-ChunkTopography-South'></a>
### South `constants`

##### Summary

Indicates parquets are grouped to the south end of this topography.

<a name='F-ParquetClassLibrary-Maps-ChunkTopography-SouthEast'></a>
### SouthEast `constants`

##### Summary

Indicates parquets are grouped on both the south and east end of this topography.

<a name='F-ParquetClassLibrary-Maps-ChunkTopography-SouthWest'></a>
### SouthWest `constants`

##### Summary

Indicates parquets are grouped on both the south and west end of this topography.

<a name='F-ParquetClassLibrary-Maps-ChunkTopography-West'></a>
### West `constants`

##### Summary

Indicates parquets are grouped to the west end of this topography.

<a name='T-ParquetClassLibrary-Maps-ChunkType'></a>
## ChunkType `type`

##### Namespace

ParquetClassLibrary.Maps

##### Summary

Indicates which parquets constitute this [MapChunk](#T-ParquetClassLibrary-Maps-MapChunk 'ParquetClassLibrary.Maps.MapChunk') and how they are arranged.

##### Remarks

Every chunk is either handmade or procedurally generated.



Chunks that are not hand made are instead composed of two layers: a base and a modifier.
 The base is the underlying structure of the chunk and the modifier overlays it to
 produce more complex arrangements than would otherwise be possible.  For example:
 - Forest: Base·Grassy Solid · Modifier·Scattered Trees
 - Seaside: Base·Watery Solid · Modifier·Eastern Sandy
 - Town: Handmade

<a name='M-ParquetClassLibrary-Maps-ChunkType-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new default instance of the [ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType') class.

##### Parameters

This constructor has no parameters.

##### Remarks

This is primarily useful for serialization as the default values are featureless.

<a name='M-ParquetClassLibrary-Maps-ChunkType-#ctor-System-Boolean-'></a>
### #ctor(inIsHandmade) `constructor`

##### Summary

Initializes a new instance of the [ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inIsHandmade | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If `true`, the [MapChunk](#T-ParquetClassLibrary-Maps-MapChunk 'ParquetClassLibrary.Maps.MapChunk') is created at design time instead of procedurally generated. |

<a name='M-ParquetClassLibrary-Maps-ChunkType-#ctor-ParquetClassLibrary-Maps-ChunkTopography,ParquetClassLibrary-ModelTag,ParquetClassLibrary-Maps-ChunkTopography,ParquetClassLibrary-ModelTag-'></a>
### #ctor(inBaseTopography,inBaseComposition,inModifierTopography,inModifierComposition) `constructor`

##### Summary

Initializes a new instance of the [ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inBaseTopography | [ParquetClassLibrary.Maps.ChunkTopography](#T-ParquetClassLibrary-Maps-ChunkTopography 'ParquetClassLibrary.Maps.ChunkTopography') | The basic form that the [MapChunk](#T-ParquetClassLibrary-Maps-MapChunk 'ParquetClassLibrary.Maps.MapChunk') of parquets takes. |
| inBaseComposition | [ParquetClassLibrary.ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag') | Indicates the overall type of parquets in the [MapChunk](#T-ParquetClassLibrary-Maps-MapChunk 'ParquetClassLibrary.Maps.MapChunk'). |
| inModifierTopography | [ParquetClassLibrary.Maps.ChunkTopography](#T-ParquetClassLibrary-Maps-ChunkTopography 'ParquetClassLibrary.Maps.ChunkTopography') | Indicates a modifier on the [MapChunk](#T-ParquetClassLibrary-Maps-MapChunk 'ParquetClassLibrary.Maps.MapChunk') of parquets. |
| inModifierComposition | [ParquetClassLibrary.ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag') | Indicates the type of parquets modifying the [MapChunk](#T-ParquetClassLibrary-Maps-MapChunk 'ParquetClassLibrary.Maps.MapChunk'). |

<a name='F-ParquetClassLibrary-Maps-ChunkType-Empty'></a>
### Empty `constants`

##### Summary

The null [ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType'), which generates an empty [MapChunk](#T-ParquetClassLibrary-Maps-MapChunk 'ParquetClassLibrary.Maps.MapChunk').

<a name='P-ParquetClassLibrary-Maps-ChunkType-BaseComposition'></a>
### BaseComposition `property`

##### Summary

Indicates the overall type of parquets in the [MapChunk](#T-ParquetClassLibrary-Maps-MapChunk 'ParquetClassLibrary.Maps.MapChunk').

<a name='P-ParquetClassLibrary-Maps-ChunkType-BaseTopography'></a>
### BaseTopography `property`

##### Summary

Indicates the basic form that the [MapChunk](#T-ParquetClassLibrary-Maps-MapChunk 'ParquetClassLibrary.Maps.MapChunk') of parquets takes.

<a name='P-ParquetClassLibrary-Maps-ChunkType-ConverterFactory'></a>
### ConverterFactory `property`

##### Summary

Allows the converter to construct itself statically.

<a name='P-ParquetClassLibrary-Maps-ChunkType-Handmade'></a>
### Handmade `property`

##### Summary

If `true`, the [MapChunk](#T-ParquetClassLibrary-Maps-MapChunk 'ParquetClassLibrary.Maps.MapChunk') is created at design time instead of procedurally generated.

<a name='P-ParquetClassLibrary-Maps-ChunkType-ModifierComposition'></a>
### ModifierComposition `property`

##### Summary

Indicates the type of parquets modifying the [MapChunk](#T-ParquetClassLibrary-Maps-MapChunk 'ParquetClassLibrary.Maps.MapChunk').

<a name='P-ParquetClassLibrary-Maps-ChunkType-ModifierTopography'></a>
### ModifierTopography `property`

##### Summary

Indicates a modifier on the [MapChunk](#T-ParquetClassLibrary-Maps-MapChunk 'ParquetClassLibrary.Maps.MapChunk') of parquets.

<a name='M-ParquetClassLibrary-Maps-ChunkType-Clone'></a>
### Clone() `method`

##### Summary

Creates a new instance with the same characteristics as the current instance.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Maps-ChunkType-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData-'></a>
### ConvertFromString(inText,inRow,inMemberMapData) `method`

##### Summary

Converts the given [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') to an [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') as deserialization.

##### Returns

The given instance deserialized.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inText | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The text to convert. |
| inRow | [CsvHelper.IReaderRow](#T-CsvHelper-IReaderRow 'CsvHelper.IReaderRow') | The current context and configuration. |
| inMemberMapData | [CsvHelper.Configuration.MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') | Mapping info for a member to a CSV field or property. |

<a name='M-ParquetClassLibrary-Maps-ChunkType-ConvertToString-System-Object,CsvHelper-IWriterRow,CsvHelper-Configuration-MemberMapData-'></a>
### ConvertToString(inValue,inRow,inMemberMapData) `method`

##### Summary

Converts the given [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') to a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') for serialization.

##### Returns

The given instance serialized.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inValue | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The instance to convert. |
| inRow | [CsvHelper.IWriterRow](#T-CsvHelper-IWriterRow 'CsvHelper.IWriterRow') | The current context and configuration. |
| inMemberMapData | [CsvHelper.Configuration.MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') | Mapping info for a member to a CSV field or property. |

<a name='M-ParquetClassLibrary-Maps-ChunkType-Equals-ParquetClassLibrary-Maps-ChunkType-'></a>
### Equals(inChunkType) `method`

##### Summary

Determines whether the specified [ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType') is equal to the current [ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType').

##### Returns

`true` if the [ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType')s are equal.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inChunkType | [ParquetClassLibrary.Maps.ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType') | The [ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType') to compare with the current. |

<a name='M-ParquetClassLibrary-Maps-ChunkType-Equals-System-Object-'></a>
### Equals(obj) `method`

##### Summary

Determines whether the specified [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') is equal to the current [ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType').

##### Returns

`true` if the specified [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') is equal to the current [ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType'); otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') to compare with the current [ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType'). |

<a name='M-ParquetClassLibrary-Maps-ChunkType-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Serves as a hash function for a [ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType') class.

##### Returns

A hash code for this instance that is suitable for use in hashing algorithms and data structures.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Maps-ChunkType-ToString'></a>
### ToString() `method`

##### Summary

Returns a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents the current [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace').

##### Returns

The representation.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Maps-ChunkType-op_Equality-ParquetClassLibrary-Maps-ChunkType,ParquetClassLibrary-Maps-ChunkType-'></a>
### op_Equality(inChunkType1,inChunkType2) `method`

##### Summary

Determines whether a specified instance of [ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType') is equal to
another specified instance of [ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType').

##### Returns

`true` if the two [ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType')s are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inChunkType1 | [ParquetClassLibrary.Maps.ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType') | The first [ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType') to compare. |
| inChunkType2 | [ParquetClassLibrary.Maps.ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType') | The second [ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType') to compare. |

<a name='M-ParquetClassLibrary-Maps-ChunkType-op_Inequality-ParquetClassLibrary-Maps-ChunkType,ParquetClassLibrary-Maps-ChunkType-'></a>
### op_Inequality(inChunkType1,inChunkType2) `method`

##### Summary

Determines whether a specified instance of [ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType') is unequal to
another specified instance of [ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType').

##### Returns

`true` if the two [ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType')s are NOT equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inChunkType1 | [ParquetClassLibrary.Maps.ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType') | The first [ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType') to compare. |
| inChunkType2 | [ParquetClassLibrary.Maps.ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType') | The second [ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType') to compare. |

<a name='T-ParquetClassLibrary-Maps-ChunkTypeExtensions'></a>
## ChunkTypeExtensions `type`

##### Namespace

ParquetClassLibrary.Maps

##### Summary

Convenience extension methods for concise coding when working with [ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType') instances.

<a name='M-ParquetClassLibrary-Maps-ChunkTypeExtensions-IsValidPosition-ParquetClassLibrary-Maps-ChunkType[0-,0-],ParquetClassLibrary-Vector2D-'></a>
### IsValidPosition(inChunkTypeArray,inPosition) `method`

##### Summary

Determines if the given position corresponds to a point within the current array.

##### Returns

`true`, if the position is valid, `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inChunkTypeArray | [ParquetClassLibrary.Maps.ChunkType[0:](#T-ParquetClassLibrary-Maps-ChunkType[0- 'ParquetClassLibrary.Maps.ChunkType[0:') | The [ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType') array to validate against. |
| inPosition | [0:]](#T-0-] '0:]') | The position to validate. |

<a name='T-ParquetClassLibrary-Maps-ChunkTypeGrid'></a>
## ChunkTypeGrid `type`

##### Namespace

ParquetClassLibrary.Maps

##### Summary

A pattern for generating a playable [MapRegion](#T-ParquetClassLibrary-Maps-MapRegion 'ParquetClassLibrary.Maps.MapRegion').

<a name='M-ParquetClassLibrary-Maps-ChunkTypeGrid-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new [ParquetStatusGrid](#T-ParquetClassLibrary-Parquets-ParquetStatusGrid 'ParquetClassLibrary.Parquets.ParquetStatusGrid') with unusable dimensions.

##### Parameters

This constructor has no parameters.

##### Remarks

For this class, there are no reasonable default values.
 However, this version of the constructor exists to make the generic new() constraint happy
 and is used in the library in a context where its limitations are understood.
 You probably don't want to use this constructor in your own code.

<a name='M-ParquetClassLibrary-Maps-ChunkTypeGrid-#ctor-System-Int32,System-Int32-'></a>
### #ctor(inRowCount,inColumnCount) `constructor`

##### Summary

Initializes a new [ParquetStatusGrid](#T-ParquetClassLibrary-Parquets-ParquetStatusGrid 'ParquetClassLibrary.Parquets.ParquetStatusGrid').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inRowCount | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The length of the Y dimension of the collection. |
| inColumnCount | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The length of the X dimension of the collection. |

<a name='P-ParquetClassLibrary-Maps-ChunkTypeGrid-ChunkTypes'></a>
### ChunkTypes `property`

##### Summary

The backing collection of [ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType')s.

<a name='P-ParquetClassLibrary-Maps-ChunkTypeGrid-Columns'></a>
### Columns `property`

##### Summary

Gets the number of elements in the X dimension of the [ChunkTypeGrid](#T-ParquetClassLibrary-Maps-ChunkTypeGrid 'ParquetClassLibrary.Maps.ChunkTypeGrid').

<a name='P-ParquetClassLibrary-Maps-ChunkTypeGrid-Count'></a>
### Count `property`

##### Summary

The total number of chunks collected.

<a name='P-ParquetClassLibrary-Maps-ChunkTypeGrid-DimensionsInChunks'></a>
### DimensionsInChunks `property`

##### Summary

The grid's dimensions in chunks.

<a name='P-ParquetClassLibrary-Maps-ChunkTypeGrid-Item-System-Int32,System-Int32-'></a>
### Item `property`

##### Summary

Access to any [ParquetStatus](#T-ParquetClassLibrary-Parquets-ParquetStatus 'ParquetClassLibrary.Parquets.ParquetStatus') in the 2D collection.

<a name='P-ParquetClassLibrary-Maps-ChunkTypeGrid-Rows'></a>
### Rows `property`

##### Summary

Gets the number of elements in the Y dimension of the [ChunkTypeGrid](#T-ParquetClassLibrary-Maps-ChunkTypeGrid 'ParquetClassLibrary.Maps.ChunkTypeGrid').

<a name='M-ParquetClassLibrary-Maps-ChunkTypeGrid-GetEnumerator'></a>
### GetEnumerator() `method`

##### Summary

Exposes an enumerator for the [ParquetStatusGrid](#T-ParquetClassLibrary-Parquets-ParquetStatusGrid 'ParquetClassLibrary.Parquets.ParquetStatusGrid'), which supports simple iteration.

##### Returns

An enumerator.

##### Parameters

This method has no parameters.

##### Remarks

For serialization, this guarantees stable iteration order.

<a name='M-ParquetClassLibrary-Maps-ChunkTypeGrid-IsValidPosition-ParquetClassLibrary-Vector2D-'></a>
### IsValidPosition(inPosition) `method`

##### Summary

Determines if the given position corresponds to a point on the grid.

##### Returns

`true`, if the position is valid, `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inPosition | [ParquetClassLibrary.Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') | The position to validate. |

<a name='M-ParquetClassLibrary-Maps-ChunkTypeGrid-System#Collections#Generic#IEnumerable{ParquetClassLibrary#Maps#ChunkType}#GetEnumerator'></a>
### System#Collections#Generic#IEnumerable{ParquetClassLibrary#Maps#ChunkType}#GetEnumerator() `method`

##### Summary

Exposes an [IEnumerator\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerator`1 'System.Collections.Generic.IEnumerator`1'), which supports simple iteration.

##### Returns

An enumerator.

##### Parameters

This method has no parameters.

##### Remarks

For serialization, this guarantees stable iteration order.

<a name='T-ParquetClassLibrary-Parquets-CollectibleModel'></a>
## CollectibleModel `type`

##### Namespace

ParquetClassLibrary.Parquets

##### Summary

Configurations for a sandbox collectible object, such as crafting materials.

<a name='M-ParquetClassLibrary-Parquets-CollectibleModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Nullable{ParquetClassLibrary-ModelID},ParquetClassLibrary-ModelTag,ParquetClassLibrary-ModelTag,ParquetClassLibrary-Parquets-CollectingEffect,System-Int32-'></a>
### #ctor(inID,inName,inDescription,inComment,inItemID,inAddsToBiome,inAddsToRoom,inCollectionEffect,inEffectAmount) `constructor`

##### Summary

Initializes a new instance of the [CollectibleModel](#T-ParquetClassLibrary-Parquets-CollectibleModel 'ParquetClassLibrary.Parquets.CollectibleModel') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | Unique identifier for the parquet.  Cannot be null. |
| inName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly name of the parquet.  Cannot be null. |
| inDescription | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly description of the parquet. |
| inComment | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Comment of, on, or by the parquet. |
| inItemID | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel') that this [CollectibleModel](#T-ParquetClassLibrary-Parquets-CollectibleModel 'ParquetClassLibrary.Parquets.CollectibleModel') corresponds to, if any. |
| inAddsToBiome | [ParquetClassLibrary.ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag') | A set of flags indicating which, if any, [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel') this parquet helps to generate. |
| inAddsToRoom | [ParquetClassLibrary.ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag') | A set of flags indicating which, if any, [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe') this parquet helps to generate. |
| inCollectionEffect | [ParquetClassLibrary.Parquets.CollectingEffect](#T-ParquetClassLibrary-Parquets-CollectingEffect 'ParquetClassLibrary.Parquets.CollectingEffect') | Effect of this collectible. |
| inEffectAmount | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The scale in points of the effect.
For example, how much to alter a stat if inEffect is set to alter a stat. |

<a name='P-ParquetClassLibrary-Parquets-CollectibleModel-Bounds'></a>
### Bounds `property`

##### Summary

The set of values that are allowed for Collectible IDs.

<a name='P-ParquetClassLibrary-Parquets-CollectibleModel-CollectionEffect'></a>
### CollectionEffect `property`

##### Summary

The effect generated when a character encounters this Collectible.

<a name='P-ParquetClassLibrary-Parquets-CollectibleModel-EffectAmount'></a>
### EffectAmount `property`

##### Summary

The scale in points of the effect.
For example, how much to alter a stat if the [CollectingEffect](#T-ParquetClassLibrary-Parquets-CollectingEffect 'ParquetClassLibrary.Parquets.CollectingEffect') is set to alter a stat.

<a name='T-ParquetClassLibrary-Parquets-CollectingEffect'></a>
## CollectingEffect `type`

##### Namespace

ParquetClassLibrary.Parquets

##### Summary

IDs for effects that can happen when a character encounters a Collectible.

<a name='F-ParquetClassLibrary-Parquets-CollectingEffect-BiomeTime'></a>
### BiomeTime `constants`

##### Summary

Allows the [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') to remain safely in the [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel') longer.

<a name='F-ParquetClassLibrary-Parquets-CollectingEffect-Item'></a>
### Item `constants`

##### Summary

Awards the [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') a given [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel').

<a name='F-ParquetClassLibrary-Parquets-CollectingEffect-None'></a>
### None `constants`

##### Summary

Collecting this parquet has no effect.

<a name='T-ParquetClassLibrary-Scripts-Commands'></a>
## Commands `type`

##### Namespace

ParquetClassLibrary.Scripts

##### Summary

IDs for commands used in [ScriptNode](#T-ParquetClassLibrary-Scripts-ScriptNode 'ParquetClassLibrary.Scripts.ScriptNode')s.

<a name='F-ParquetClassLibrary-Scripts-Commands-Alert'></a>
### Alert `constants`

##### Summary

Display the given text as an alert by the user interface.

<a name='F-ParquetClassLibrary-Scripts-Commands-CallCharacter'></a>
### CallCharacter `constants`

##### Summary

Calls the given [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') to stand near another given [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel').

<a name='F-ParquetClassLibrary-Scripts-Commands-ClearFlag'></a>
### ClearFlag `constants`

##### Summary

Lower the given flag.

<a name='F-ParquetClassLibrary-Scripts-Commands-GiveItem'></a>
### GiveItem `constants`

##### Summary

Allot the given number and type of [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel') to the given [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel').

<a name='F-ParquetClassLibrary-Scripts-Commands-GiveQuest'></a>
### GiveQuest `constants`

##### Summary

Allot the given [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel') to the given [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel').

<a name='F-ParquetClassLibrary-Scripts-Commands-Jump'></a>
### Jump `constants`

##### Summary

Immediately load and begin processing the given [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel').

<a name='F-ParquetClassLibrary-Scripts-Commands-JumpIf'></a>
### JumpIf `constants`

##### Summary

If the given variable is set, load and begin processing the given [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel').

<a name='F-ParquetClassLibrary-Scripts-Commands-None'></a>
### None `constants`

##### Summary

Indicates non-command.  NOP.

<a name='F-ParquetClassLibrary-Scripts-Commands-Put'></a>
### Put `constants`

##### Summary

Place the given [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') at the given [Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location').

<a name='F-ParquetClassLibrary-Scripts-Commands-Say'></a>
### Say `constants`

##### Summary

Display the given text as dialogue spoken by the given [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel').

<a name='F-ParquetClassLibrary-Scripts-Commands-SetBehavior'></a>
### SetBehavior `constants`

##### Summary

Allot the given [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel') to the given [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel').

<a name='F-ParquetClassLibrary-Scripts-Commands-SetDialogue'></a>
### SetDialogue `constants`

##### Summary

Allot the given [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel') to the given [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel').

<a name='F-ParquetClassLibrary-Scripts-Commands-SetFlag'></a>
### SetFlag `constants`

##### Summary

Raise the given flag.

<a name='F-ParquetClassLibrary-Scripts-Commands-SetPronoun'></a>
### SetPronoun `constants`

##### Summary

Allot the given [PronounGroup](#T-ParquetClassLibrary-Beings-PronounGroup 'ParquetClassLibrary.Beings.PronounGroup') to the given [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel').

<a name='F-ParquetClassLibrary-Scripts-Commands-ShowLocation'></a>
### ShowLocation `constants`

##### Summary

Highlight the given [Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location') via the UI, perhaps by camera movement or particle effect.

<a name='T-ParquetClassLibrary-Rules-Recipes-Craft'></a>
## Craft `type`

##### Namespace

ParquetClassLibrary.Rules.Recipes

##### Summary

Provides crafting recipe requirements for the game.

<a name='P-ParquetClassLibrary-Rules-Recipes-Craft-IngredientCount'></a>
### IngredientCount `property`

##### Summary

Number of ingredient categories per recipe.

<a name='P-ParquetClassLibrary-Rules-Recipes-Craft-ProductCount'></a>
### ProductCount `property`

##### Summary

Number of product categories per recipe.

<a name='T-ParquetClassLibrary-Crafts-CraftingRecipe'></a>
## CraftingRecipe `type`

##### Namespace

ParquetClassLibrary.Crafts

##### Summary

Models the ingredients and process needed to produce a new item.

<a name='M-ParquetClassLibrary-Crafts-CraftingRecipe-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Collections-Generic-IEnumerable{ParquetClassLibrary-RecipeElement},System-Collections-Generic-IEnumerable{ParquetClassLibrary-RecipeElement},ParquetClassLibrary-Crafts-StrikePanelGrid-'></a>
### #ctor(inID,inName,inDescription,inComment,inProducts,inIngredients,inPanelPattern) `constructor`

##### Summary

Initializes a new instance of the [CraftingRecipe](#T-ParquetClassLibrary-Crafts-CraftingRecipe 'ParquetClassLibrary.Crafts.CraftingRecipe') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | Unique identifier for the [CraftingRecipe](#T-ParquetClassLibrary-Crafts-CraftingRecipe 'ParquetClassLibrary.Crafts.CraftingRecipe').  Cannot be null. |
| inName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly name of the [CraftingRecipe](#T-ParquetClassLibrary-Crafts-CraftingRecipe 'ParquetClassLibrary.Crafts.CraftingRecipe').  Cannot be null or empty. |
| inDescription | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly description of the [CraftingRecipe](#T-ParquetClassLibrary-Crafts-CraftingRecipe 'ParquetClassLibrary.Crafts.CraftingRecipe'). |
| inComment | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Comment of, on, or by the [CraftingRecipe](#T-ParquetClassLibrary-Crafts-CraftingRecipe 'ParquetClassLibrary.Crafts.CraftingRecipe'). |
| inProducts | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.RecipeElement}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.RecipeElement}') | The types and quantities of [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel')s created by following this recipe once. |
| inIngredients | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.RecipeElement}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.RecipeElement}') | All items needed to follow this [CraftingRecipe](#T-ParquetClassLibrary-Crafts-CraftingRecipe 'ParquetClassLibrary.Crafts.CraftingRecipe') once. |
| inPanelPattern | [ParquetClassLibrary.Crafts.StrikePanelGrid](#T-ParquetClassLibrary-Crafts-StrikePanelGrid 'ParquetClassLibrary.Crafts.StrikePanelGrid') | The arrangment of panels encompassed by this [CraftingRecipe](#T-ParquetClassLibrary-Crafts-CraftingRecipe 'ParquetClassLibrary.Crafts.CraftingRecipe'). |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IndexOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IndexOutOfRangeException 'System.IndexOutOfRangeException') | When `inPanelPattern` has dimensions less than `1` or dimensions larger than those given by
[PanelsPerPatternWidth](#F-ParquetClassLibrary-Rules-Dimensions-PanelsPerPatternWidth 'ParquetClassLibrary.Rules.Dimensions.PanelsPerPatternWidth') and [PanelsPerPatternHeight](#F-ParquetClassLibrary-Rules-Dimensions-PanelsPerPatternHeight 'ParquetClassLibrary.Rules.Dimensions.PanelsPerPatternHeight'). |

<a name='P-ParquetClassLibrary-Crafts-CraftingRecipe-EmptyCraftingElementList'></a>
### EmptyCraftingElementList `property`

##### Summary

Used in defining [NotCraftable](#P-ParquetClassLibrary-Crafts-CraftingRecipe-NotCraftable 'ParquetClassLibrary.Crafts.CraftingRecipe.NotCraftable').

<a name='P-ParquetClassLibrary-Crafts-CraftingRecipe-Ingredients'></a>
### Ingredients `property`

##### Summary

All materials and their quantities needed to follow this recipe once.

<a name='P-ParquetClassLibrary-Crafts-CraftingRecipe-NotCraftable'></a>
### NotCraftable `property`

##### Summary

Represents the lack of a [CraftingRecipe](#T-ParquetClassLibrary-Crafts-CraftingRecipe 'ParquetClassLibrary.Crafts.CraftingRecipe') for uncraftable [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel')s.

<a name='P-ParquetClassLibrary-Crafts-CraftingRecipe-PanelPattern'></a>
### PanelPattern `property`

##### Summary

The arrangment of panels encompassed by this recipe.

<a name='P-ParquetClassLibrary-Crafts-CraftingRecipe-Products'></a>
### Products `property`

##### Summary

The types and amounts of [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel')s created by following this recipe.

<a name='T-ParquetClassLibrary-Beings-CritterModel'></a>
## CritterModel `type`

##### Namespace

ParquetClassLibrary.Beings

##### Summary

Models the definition for a simple in-game actor, such as a friendly mob with limited interaction.

<a name='M-ParquetClassLibrary-Beings-CritterModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID,System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID}-'></a>
### #ctor(inID,inName,inDescription,inComment,inNativeBiome,inPrimaryBehavior,inAvoids,inSeeks) `constructor`

##### Summary

Initializes a new instance of the [CritterModel](#T-ParquetClassLibrary-Beings-CritterModel 'ParquetClassLibrary.Beings.CritterModel') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | Unique identifier for the [CritterModel](#T-ParquetClassLibrary-Beings-CritterModel 'ParquetClassLibrary.Beings.CritterModel').  Cannot be null.
Must be a [CritterIDs](#F-ParquetClassLibrary-All-CritterIDs 'ParquetClassLibrary.All.CritterIDs'). |
| inName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly name of the [CritterModel](#T-ParquetClassLibrary-Beings-CritterModel 'ParquetClassLibrary.Beings.CritterModel').  Cannot be null or empty. |
| inDescription | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly description of the [CritterModel](#T-ParquetClassLibrary-Beings-CritterModel 'ParquetClassLibrary.Beings.CritterModel'). |
| inComment | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Comment of, on, or by the [CritterModel](#T-ParquetClassLibrary-Beings-CritterModel 'ParquetClassLibrary.Beings.CritterModel'). |
| inNativeBiome | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel') in which this [CritterModel](#T-ParquetClassLibrary-Beings-CritterModel 'ParquetClassLibrary.Beings.CritterModel') is most comfortable. |
| inPrimaryBehavior | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The rules that govern how this [CritterModel](#T-ParquetClassLibrary-Beings-CritterModel 'ParquetClassLibrary.Beings.CritterModel') acts.  Cannot be null. |
| inAvoids | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}') | Any parquets this [CritterModel](#T-ParquetClassLibrary-Beings-CritterModel 'ParquetClassLibrary.Beings.CritterModel') avoids. |
| inSeeks | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}') | Any parquets this [CritterModel](#T-ParquetClassLibrary-Beings-CritterModel 'ParquetClassLibrary.Beings.CritterModel') seeks. |

<a name='T-ParquetClassLibrary-Rules-Delimiters'></a>
## Delimiters `type`

##### Namespace

ParquetClassLibrary.Rules

##### Summary

Provides a unified source of serialization separators for the library.

<a name='F-ParquetClassLibrary-Rules-Delimiters-DimensionalDelimiter'></a>
### DimensionalDelimiter `constants`

##### Summary

Separator for encoding the dimensions of [IGrid\`1](#T-ParquetClassLibrary-IGrid`1 'ParquetClassLibrary.IGrid`1') implementations.

<a name='F-ParquetClassLibrary-Rules-Delimiters-DimensionalTerminator'></a>
### DimensionalTerminator `constants`

##### Summary

Separator for encoding the dimensions of [IGrid\`1](#T-ParquetClassLibrary-IGrid`1 'ParquetClassLibrary.IGrid`1') implementations.

<a name='F-ParquetClassLibrary-Rules-Delimiters-ElementDelimiter'></a>
### ElementDelimiter `constants`

##### Summary

Separates primitives within serialized [Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D')s and [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1')s.

<a name='F-ParquetClassLibrary-Rules-Delimiters-InternalDelimiter'></a>
### InternalDelimiter `constants`

##### Summary

Separates properties within a class when in serialization.

<a name='F-ParquetClassLibrary-Rules-Delimiters-NameDelimiter'></a>
### NameDelimiter `constants`

##### Summary

Separates family and personal names within serialized [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel')s.

<a name='F-ParquetClassLibrary-Rules-Delimiters-PronounDelimiter'></a>
### PronounDelimiter `constants`

##### Summary

Marks out tags that need to be replaced with pronouns from a [PronounGroup](#T-ParquetClassLibrary-Beings-PronounGroup 'ParquetClassLibrary.Beings.PronounGroup')s.

<a name='F-ParquetClassLibrary-Rules-Delimiters-SecondaryDelimiter'></a>
### SecondaryDelimiter `constants`

##### Summary

Separates objects within collections.

<a name='T-ParquetClassLibrary-Rules-Dimensions'></a>
## Dimensions `type`

##### Namespace

ParquetClassLibrary.Rules

##### Summary

Provides dimensional parameters for the game.

<a name='F-ParquetClassLibrary-Rules-Dimensions-ChunksPerRegion'></a>
### ChunksPerRegion `constants`

##### Summary

The length of each [MapRegion](#T-ParquetClassLibrary-Maps-MapRegion 'ParquetClassLibrary.Maps.MapRegion') dimension in [ChunkTypeGrid](#T-ParquetClassLibrary-Maps-ChunkTypeGrid 'ParquetClassLibrary.Maps.ChunkTypeGrid')s.

<a name='F-ParquetClassLibrary-Rules-Dimensions-PanelsPerPatternHeight'></a>
### PanelsPerPatternHeight `constants`

##### Summary

Height of the [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel') pattern in [CraftingRecipe](#T-ParquetClassLibrary-Crafts-CraftingRecipe 'ParquetClassLibrary.Crafts.CraftingRecipe').

<a name='F-ParquetClassLibrary-Rules-Dimensions-PanelsPerPatternWidth'></a>
### PanelsPerPatternWidth `constants`

##### Summary

Width of the [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel') pattern in [CraftingRecipe](#T-ParquetClassLibrary-Crafts-CraftingRecipe 'ParquetClassLibrary.Crafts.CraftingRecipe').

<a name='F-ParquetClassLibrary-Rules-Dimensions-ParquetsPerChunk'></a>
### ParquetsPerChunk `constants`

##### Summary

The length of each [ChunkTypeGrid](#T-ParquetClassLibrary-Maps-ChunkTypeGrid 'ParquetClassLibrary.Maps.ChunkTypeGrid') dimension in parquets.

<a name='F-ParquetClassLibrary-Rules-Dimensions-ParquetsPerRegion'></a>
### ParquetsPerRegion `constants`

##### Summary

The length of each [MapRegion](#T-ParquetClassLibrary-Maps-MapRegion 'ParquetClassLibrary.Maps.MapRegion') dimension in parquets.

<a name='T-ParquetClassLibrary-Biomes-Elevation'></a>
## Elevation `type`

##### Namespace

ParquetClassLibrary.Biomes

##### Summary

The three categories of elevation that the game understands.
These help determine biome and presentation.

<a name='F-ParquetClassLibrary-Biomes-Elevation-AboveGround'></a>
### AboveGround `constants`

##### Summary

Topmost elevation.

<a name='F-ParquetClassLibrary-Biomes-Elevation-BelowGround'></a>
### BelowGround `constants`

##### Summary

Lowest elevation.

<a name='F-ParquetClassLibrary-Biomes-Elevation-LevelGround'></a>
### LevelGround `constants`

##### Summary

Mid-level elevation.

<a name='T-ParquetClassLibrary-Biomes-ElevationMask'></a>
## ElevationMask `type`

##### Namespace

ParquetClassLibrary.Biomes

##### Summary

Indicates the level of a MapChunk or MapRegion.

<a name='T-ParquetClassLibrary-Biomes-ElevationMaskSelectionExtensions'></a>
## ElevationMaskSelectionExtensions `type`

##### Namespace

ParquetClassLibrary.Biomes

##### Summary

Convenience extension methods for concise coding when working with [ElevationMask](#T-ParquetClassLibrary-Biomes-ElevationMask 'ParquetClassLibrary.Biomes.ElevationMask') instances.

<a name='M-ParquetClassLibrary-Biomes-ElevationMaskSelectionExtensions-Clear-ParquetClassLibrary-Biomes-ElevationMask@,ParquetClassLibrary-Biomes-ElevationMask-'></a>
### Clear(refEnumVariable,inFlagToClear) `method`

##### Summary

Clears the given flag in the specified variable.

##### Returns

The variable with the flag cleared.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| refEnumVariable | [ParquetClassLibrary.Biomes.ElevationMask@](#T-ParquetClassLibrary-Biomes-ElevationMask@ 'ParquetClassLibrary.Biomes.ElevationMask@') | The enum variable under consideration. |
| inFlagToClear | [ParquetClassLibrary.Biomes.ElevationMask](#T-ParquetClassLibrary-Biomes-ElevationMask 'ParquetClassLibrary.Biomes.ElevationMask') | The flag to clear. |

<a name='M-ParquetClassLibrary-Biomes-ElevationMaskSelectionExtensions-IsSet-ParquetClassLibrary-Biomes-ElevationMask,ParquetClassLibrary-Biomes-ElevationMask-'></a>
### IsSet(inEnumVariable,inFlagToTest) `method`

##### Summary

Checks if the given flag is set.

##### Returns

`true`, if at least this flag is set, `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inEnumVariable | [ParquetClassLibrary.Biomes.ElevationMask](#T-ParquetClassLibrary-Biomes-ElevationMask 'ParquetClassLibrary.Biomes.ElevationMask') | The enum variable under consideration. |
| inFlagToTest | [ParquetClassLibrary.Biomes.ElevationMask](#T-ParquetClassLibrary-Biomes-ElevationMask 'ParquetClassLibrary.Biomes.ElevationMask') | The flag to test. |

<a name='M-ParquetClassLibrary-Biomes-ElevationMaskSelectionExtensions-Set-ParquetClassLibrary-Biomes-ElevationMask@,ParquetClassLibrary-Biomes-ElevationMask-'></a>
### Set(refEnumVariable,inFlagToSet) `method`

##### Summary

Sets the given flag in the specified variable.

##### Returns

The variable with the flag set.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| refEnumVariable | [ParquetClassLibrary.Biomes.ElevationMask@](#T-ParquetClassLibrary-Biomes-ElevationMask@ 'ParquetClassLibrary.Biomes.ElevationMask@') | The enum variable under consideration. |
| inFlagToSet | [ParquetClassLibrary.Biomes.ElevationMask](#T-ParquetClassLibrary-Biomes-ElevationMask 'ParquetClassLibrary.Biomes.ElevationMask') | The flag to set. |

<a name='M-ParquetClassLibrary-Biomes-ElevationMaskSelectionExtensions-SetTo-ParquetClassLibrary-Biomes-ElevationMask@,ParquetClassLibrary-Biomes-ElevationMask,System-Boolean-'></a>
### SetTo(refEnumVariable,inFlagToTest,inState) `method`

##### Summary

Sets or clears the given flag in the specified variable, depending on the given boolean.

##### Returns

The variable with the flag modified.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| refEnumVariable | [ParquetClassLibrary.Biomes.ElevationMask@](#T-ParquetClassLibrary-Biomes-ElevationMask@ 'ParquetClassLibrary.Biomes.ElevationMask@') | The enum variable under consideration. |
| inFlagToTest | [ParquetClassLibrary.Biomes.ElevationMask](#T-ParquetClassLibrary-Biomes-ElevationMask 'ParquetClassLibrary.Biomes.ElevationMask') | The flag to set or clear. |
| inState | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If `true`, the flag will be set; otherwise it will be cleared. |

<a name='T-ParquetRoller-ExitCode'></a>
## ExitCode `type`

##### Namespace

ParquetRoller

##### Summary

A value indicating success or the nature of the failure.

##### Remarks

Returned when the application terminates to indicate results of the process.

<a name='F-ParquetRoller-ExitCode-AccessDenied'></a>
### AccessDenied `constants`

##### Summary

Access or permission was denied.

<a name='F-ParquetRoller-ExitCode-BadArguments'></a>
### BadArguments `constants`

##### Summary

One or more arguments were incorrect.

<a name='F-ParquetRoller-ExitCode-FileNotFound'></a>
### FileNotFound `constants`

##### Summary

An invalid function was specified.

<a name='F-ParquetRoller-ExitCode-InvalidData'></a>
### InvalidData `constants`

##### Summary

Invalid data was given.

<a name='F-ParquetRoller-ExitCode-NotSupported'></a>
### NotSupported `constants`

##### Summary

An unsupported request was made.

<a name='F-ParquetRoller-ExitCode-Success'></a>
### Success `constants`

##### Summary

The operation completed successfully.

<a name='T-ParquetClassLibrary-Maps-ExitPoint'></a>
## ExitPoint `type`

##### Namespace

ParquetClassLibrary.Maps

##### Summary

A location at which the player moves from one [MapRegion](#T-ParquetClassLibrary-Maps-MapRegion 'ParquetClassLibrary.Maps.MapRegion') to another.

##### Remarks

Since only one Exit Point can exist in a given location, exit points are considered equal according to their position only.

<a name='M-ParquetClassLibrary-Maps-ExitPoint-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes an empty instance of [ExitPoint](#T-ParquetClassLibrary-Maps-ExitPoint 'ParquetClassLibrary.Maps.ExitPoint') with default values.

##### Parameters

This constructor has no parameters.

##### Remarks

Iseful primarily in the context of serialization.

<a name='M-ParquetClassLibrary-Maps-ExitPoint-#ctor-ParquetClassLibrary-Vector2D,ParquetClassLibrary-ModelID-'></a>
### #ctor(inPosition,inDestinationID) `constructor`

##### Summary

Initializes a new instance of [ExitPoint](#T-ParquetClassLibrary-Maps-ExitPoint 'ParquetClassLibrary.Maps.ExitPoint').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inPosition | [ParquetClassLibrary.Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') | The location of this point on its containing region. |
| inDestinationID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The region this exit leads to. |

<a name='P-ParquetClassLibrary-Maps-ExitPoint-ConverterFactory'></a>
### ConverterFactory `property`

##### Summary

Allows the converter to construct itself statically.

<a name='P-ParquetClassLibrary-Maps-ExitPoint-Destination'></a>
### Destination `property`

##### Summary

The region this exit leads to.

<a name='P-ParquetClassLibrary-Maps-ExitPoint-Position'></a>
### Position `property`

##### Summary

Location of this exit point.

<a name='M-ParquetClassLibrary-Maps-ExitPoint-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData-'></a>
### ConvertFromString(inText,inRow,inMemberMapData) `method`

##### Summary

Converts the given [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') to an [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') as deserialization.

##### Returns

The given instance deserialized.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inText | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The text to convert. |
| inRow | [CsvHelper.IReaderRow](#T-CsvHelper-IReaderRow 'CsvHelper.IReaderRow') | The current context and configuration. |
| inMemberMapData | [CsvHelper.Configuration.MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') | Mapping info for a member to a CSV field or property. |

<a name='M-ParquetClassLibrary-Maps-ExitPoint-ConvertToString-System-Object,CsvHelper-IWriterRow,CsvHelper-Configuration-MemberMapData-'></a>
### ConvertToString(inValue,inRow,inMemberMapData) `method`

##### Summary

Converts the given [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') to a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') for serialization.

##### Returns

The given instance serialized.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inValue | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The instance to convert. |
| inRow | [CsvHelper.IWriterRow](#T-CsvHelper-IWriterRow 'CsvHelper.IWriterRow') | The current context and configuration. |
| inMemberMapData | [CsvHelper.Configuration.MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') | Mapping info for a member to a CSV field or property. |

<a name='M-ParquetClassLibrary-Maps-ExitPoint-Equals-ParquetClassLibrary-Maps-ExitPoint-'></a>
### Equals(inPoint) `method`

##### Summary

Determines whether the specified [ExitPoint](#T-ParquetClassLibrary-Maps-ExitPoint 'ParquetClassLibrary.Maps.ExitPoint') is equal to the current [ExitPoint](#T-ParquetClassLibrary-Maps-ExitPoint 'ParquetClassLibrary.Maps.ExitPoint').

##### Returns

`true` if the given [ExitPoint](#T-ParquetClassLibrary-Maps-ExitPoint 'ParquetClassLibrary.Maps.ExitPoint') is equal to the current [ExitPoint](#T-ParquetClassLibrary-Maps-ExitPoint 'ParquetClassLibrary.Maps.ExitPoint'); otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inPoint | [ParquetClassLibrary.Maps.ExitPoint](#T-ParquetClassLibrary-Maps-ExitPoint 'ParquetClassLibrary.Maps.ExitPoint') | The [ExitPoint](#T-ParquetClassLibrary-Maps-ExitPoint 'ParquetClassLibrary.Maps.ExitPoint') to compare with. |

<a name='M-ParquetClassLibrary-Maps-ExitPoint-Equals-System-Object-'></a>
### Equals(obj) `method`

##### Summary

Determines whether the given [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') is equal to this [ExitPoint](#T-ParquetClassLibrary-Maps-ExitPoint 'ParquetClassLibrary.Maps.ExitPoint').

##### Returns

`true` if the specified [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') is equal to the current [ExitPoint](#T-ParquetClassLibrary-Maps-ExitPoint 'ParquetClassLibrary.Maps.ExitPoint'); otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') to compare with. |

<a name='M-ParquetClassLibrary-Maps-ExitPoint-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Hash function for a [ExitPoint](#T-ParquetClassLibrary-Maps-ExitPoint 'ParquetClassLibrary.Maps.ExitPoint').

##### Returns

A hash code for this instance that is suitable for use in hashing algorithms and data structures.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Maps-ExitPoint-ToString'></a>
### ToString() `method`

##### Summary

Returns a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents the current [ExitPoint](#T-ParquetClassLibrary-Maps-ExitPoint 'ParquetClassLibrary.Maps.ExitPoint').

##### Returns

The representation.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Maps-ExitPoint-op_Equality-ParquetClassLibrary-Maps-ExitPoint,ParquetClassLibrary-Maps-ExitPoint-'></a>
### op_Equality(inPoint1,inPoint2) `method`

##### Summary

Determines whether a specified instance of [ExitPoint](#T-ParquetClassLibrary-Maps-ExitPoint 'ParquetClassLibrary.Maps.ExitPoint')
is equal to another specified instance of [ExitPoint](#T-ParquetClassLibrary-Maps-ExitPoint 'ParquetClassLibrary.Maps.ExitPoint').

##### Returns

`true` if the two points are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inPoint1 | [ParquetClassLibrary.Maps.ExitPoint](#T-ParquetClassLibrary-Maps-ExitPoint 'ParquetClassLibrary.Maps.ExitPoint') | The first [ExitPoint](#T-ParquetClassLibrary-Maps-ExitPoint 'ParquetClassLibrary.Maps.ExitPoint') to compare. |
| inPoint2 | [ParquetClassLibrary.Maps.ExitPoint](#T-ParquetClassLibrary-Maps-ExitPoint 'ParquetClassLibrary.Maps.ExitPoint') | The second [ExitPoint](#T-ParquetClassLibrary-Maps-ExitPoint 'ParquetClassLibrary.Maps.ExitPoint') to compare. |

<a name='M-ParquetClassLibrary-Maps-ExitPoint-op_Inequality-ParquetClassLibrary-Maps-ExitPoint,ParquetClassLibrary-Maps-ExitPoint-'></a>
### op_Inequality(inPoint1,inPoint2) `method`

##### Summary

Determines whether a specified instance of [ExitPoint](#T-ParquetClassLibrary-Maps-ExitPoint 'ParquetClassLibrary.Maps.ExitPoint')
is not equal to another specified [ExitPoint](#T-ParquetClassLibrary-Maps-ExitPoint 'ParquetClassLibrary.Maps.ExitPoint').

##### Returns

`true` if the two points are not equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inPoint1 | [ParquetClassLibrary.Maps.ExitPoint](#T-ParquetClassLibrary-Maps-ExitPoint 'ParquetClassLibrary.Maps.ExitPoint') | The first [ExitPoint](#T-ParquetClassLibrary-Maps-ExitPoint 'ParquetClassLibrary.Maps.ExitPoint') to compare. |
| inPoint2 | [ParquetClassLibrary.Maps.ExitPoint](#T-ParquetClassLibrary-Maps-ExitPoint 'ParquetClassLibrary.Maps.ExitPoint') | The second [ExitPoint](#T-ParquetClassLibrary-Maps-ExitPoint 'ParquetClassLibrary.Maps.ExitPoint') to compare. |

<a name='T-ParquetClassLibrary-Parquets-FloorModel'></a>
## FloorModel `type`

##### Namespace

ParquetClassLibrary.Parquets

##### Summary

Configurations for a sandbox parquet walking surface.

<a name='M-ParquetClassLibrary-Parquets-FloorModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Nullable{ParquetClassLibrary-ModelID},ParquetClassLibrary-ModelTag,ParquetClassLibrary-ModelTag,ParquetClassLibrary-Items-ModificationTool,System-String-'></a>
### #ctor(inID,inName,inDescription,inComment,inItemID,inAddsToBiome,inAddsToRoom,inModTool,inTrenchName) `constructor`

##### Summary

Initializes a new instance of the [FloorModel](#T-ParquetClassLibrary-Parquets-FloorModel 'ParquetClassLibrary.Parquets.FloorModel') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | Unique identifier for the parquet.  Cannot be null. |
| inName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly name of the parquet.  Cannot be null. |
| inDescription | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly description of the parquet. |
| inComment | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Comment of, on, or by the parquet. |
| inItemID | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel') awarded to the player when a character gathers this parquet. |
| inAddsToBiome | [ParquetClassLibrary.ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag') | Which, if any, [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel') this parquet helps to generate. |
| inAddsToRoom | [ParquetClassLibrary.ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag') | Describes which, if any, [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe')(s) this parquet helps form. |
| inModTool | [ParquetClassLibrary.Items.ModificationTool](#T-ParquetClassLibrary-Items-ModificationTool 'ParquetClassLibrary.Items.ModificationTool') | The tool used to modify this floor. |
| inTrenchName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name to use for this floor when it has been dug out. |

<a name='F-ParquetClassLibrary-Parquets-FloorModel-defaultTrenchName'></a>
### defaultTrenchName `constants`

##### Summary

A name to employ for parquets when IsTrench is set, if none is provided.

<a name='P-ParquetClassLibrary-Parquets-FloorModel-Bounds'></a>
### Bounds `property`

##### Summary

The set of values that are allowed for Floor IDs.

<a name='P-ParquetClassLibrary-Parquets-FloorModel-ModTool'></a>
### ModTool `property`

##### Summary

The tool used to dig out or fill in the floor.

<a name='P-ParquetClassLibrary-Parquets-FloorModel-TrenchName'></a>
### TrenchName `property`

##### Summary

Player-facing name of the parquet, used when it has been dug out.

<a name='T-ParquetClassLibrary-Parquets-FurnishingModel'></a>
## FurnishingModel `type`

##### Namespace

ParquetClassLibrary.Parquets

##### Summary

Configurations for large sandbox parquet items, such as furniture or plants.

<a name='M-ParquetClassLibrary-Parquets-FurnishingModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Nullable{ParquetClassLibrary-ModelID},ParquetClassLibrary-ModelTag,ParquetClassLibrary-ModelTag,System-Boolean,System-Boolean,System-Boolean,System-Boolean,System-Nullable{ParquetClassLibrary-ModelID}-'></a>
### #ctor(inID,inName,inDescription,inComment,inItemID,inAddsToBiome,inAddsToRoom,inIsWalkable,inIsEntry,inIsEnclosing,inIsFlammable,inSwapID) `constructor`

##### Summary

Initializes a new instance of the [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | Unique identifier for the [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel').  Cannot be null. |
| inName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly name of the [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel').  Cannot be null or empty. |
| inDescription | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly description of the parquet. |
| inComment | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Comment of, on, or by the parquet. |
| inItemID | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') that represents this [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') in the [Inventory](#T-ParquetClassLibrary-Items-Inventory 'ParquetClassLibrary.Items.Inventory'). |
| inAddsToBiome | [ParquetClassLibrary.ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag') | Indicates which, if any, [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel') this parquet helps to generate. |
| inAddsToRoom | [ParquetClassLibrary.ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag') | Describes which, if any, [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe')(s) this parquet helps form. |
| inIsWalkable | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If `true` this [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') may be walked on. |
| inIsEntry | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If `true` this [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') serves as an entry to a [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room'). |
| inIsEnclosing | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If `true` this [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') serves as part of a perimeter of a [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room'). |
| inIsFlammable | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If `true` this [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') may catch fire. |
| inSwapID | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | A [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') to swap with this furnishing on open/close actions. |

<a name='P-ParquetClassLibrary-Parquets-FurnishingModel-Bounds'></a>
### Bounds `property`

##### Summary

The set of values that are allowed for Furnishing IDs.

<a name='P-ParquetClassLibrary-Parquets-FurnishingModel-IsEnclosing'></a>
### IsEnclosing `property`

##### Summary

Indicates whether this [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') serves as part of a perimeter of a [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room').

<a name='P-ParquetClassLibrary-Parquets-FurnishingModel-IsEntry'></a>
### IsEntry `property`

##### Summary

Indicates whether this [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') serves as an entry to a [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room').

<a name='P-ParquetClassLibrary-Parquets-FurnishingModel-IsFlammable'></a>
### IsFlammable `property`

##### Summary

Whether or not the [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') is flammable.

<a name='P-ParquetClassLibrary-Parquets-FurnishingModel-IsWalkable'></a>
### IsWalkable `property`

##### Summary

Indicates whether this [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') may be walked on.

<a name='P-ParquetClassLibrary-Parquets-FurnishingModel-SwapID'></a>
### SwapID `property`

##### Summary

The [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') to swap with this Furnishing on an open/close action.

<a name='T-ParquetClassLibrary-Parquets-GatheringEffect'></a>
## GatheringEffect `type`

##### Namespace

ParquetClassLibrary.Parquets

##### Summary

IDs for effects that can happen when a character gathers a [BlockModel](#T-ParquetClassLibrary-Parquets-BlockModel 'ParquetClassLibrary.Parquets.BlockModel').

<a name='F-ParquetClassLibrary-Parquets-GatheringEffect-Collectible'></a>
### Collectible `constants`

##### Summary

Replaces this parquet with a [CollectibleModel](#T-ParquetClassLibrary-Parquets-CollectibleModel 'ParquetClassLibrary.Parquets.CollectibleModel').

<a name='F-ParquetClassLibrary-Parquets-GatheringEffect-Item'></a>
### Item `constants`

##### Summary

Awards the [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') a given [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel').

<a name='F-ParquetClassLibrary-Parquets-GatheringEffect-None'></a>
### None `constants`

##### Summary

Gathering this parquet has no effect.

<a name='T-ParquetClassLibrary-Items-GatheringTool'></a>
## GatheringTool `type`

##### Namespace

ParquetClassLibrary.Items

##### Summary

IDs for [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel') tools that Characters can use to gather [BlockModel](#T-ParquetClassLibrary-Parquets-BlockModel 'ParquetClassLibrary.Parquets.BlockModel')s.

##### Remarks

The tool subtypes are hard-coded, but individual [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel')s themselves are configured in CSV files.

<a name='F-ParquetClassLibrary-Items-GatheringTool-Axe'></a>
### Axe `constants`

##### Summary

This parquet can be gathered by using a axe-like tool.

<a name='F-ParquetClassLibrary-Items-GatheringTool-Bucket'></a>
### Bucket `constants`

##### Summary

This parquet can be gathered by using a bucket-like tool.

<a name='F-ParquetClassLibrary-Items-GatheringTool-None'></a>
### None `constants`

##### Summary

This parquet cannot be gathered.

<a name='F-ParquetClassLibrary-Items-GatheringTool-Pick'></a>
### Pick `constants`

##### Summary

This parquet can be gathered by using a pick-like tool.

<a name='F-ParquetClassLibrary-Items-GatheringTool-Shovel'></a>
### Shovel `constants`

##### Summary

This parquet can be gathered by using a shovel-like tool.

<a name='T-ParquetClassLibrary-GridConverter`2'></a>
## GridConverter\`2 `type`

##### Namespace

ParquetClassLibrary

##### Summary

Type converter for any collection that implements [IGrid\`1](#T-ParquetClassLibrary-IGrid`1 'ParquetClassLibrary.IGrid`1').

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TElement | The type collected. |
| TGrid | The type of the collection. |

<a name='P-ParquetClassLibrary-GridConverter`2-ConverterFactory'></a>
### ConverterFactory `property`

##### Summary

Allows the converter to construct itself statically.

<a name='M-ParquetClassLibrary-GridConverter`2-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData-'></a>
### ConvertFromString(inText,inRow,inMemberMapData) `method`

##### Summary

Converts the given record column to a 2D collection.

##### Returns

The [IGrid\`1](#T-ParquetClassLibrary-IGrid`1 'ParquetClassLibrary.IGrid`1') created from the record column.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inText | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The record column to convert to an object. |
| inRow | [CsvHelper.IReaderRow](#T-CsvHelper-IReaderRow 'CsvHelper.IReaderRow') | The [IReaderRow](#T-CsvHelper-IReaderRow 'CsvHelper.IReaderRow') for the current record. |
| inMemberMapData | [CsvHelper.Configuration.MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') | The [MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') for the member being created. |

<a name='M-ParquetClassLibrary-GridConverter`2-ConvertToString-System-Object,CsvHelper-IWriterRow,CsvHelper-Configuration-MemberMapData-'></a>
### ConvertToString(inValue,inRow,inMemberMapData) `method`

##### Summary

Converts the given 2D collection into a record column.

##### Returns

The given collection serialized.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inValue | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The collection to convert. |
| inRow | [CsvHelper.IWriterRow](#T-CsvHelper-IWriterRow 'CsvHelper.IWriterRow') | The current context and configuration. |
| inMemberMapData | [CsvHelper.Configuration.MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') | Mapping info for a member to a CSV field or property. |

<a name='T-ParquetClassLibrary-IGrid`1'></a>
## IGrid\`1 `type`

##### Namespace

ParquetClassLibrary

##### Summary

A two-dimensional collection that functions much like an array.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TElement | The type collected. |

##### Remarks

For serialization, implementing classes need to guarantee stable iteration order.

<a name='P-ParquetClassLibrary-IGrid`1-Columns'></a>
### Columns `property`

##### Summary

Gets the number of elements in the X dimension of the [IGrid\`1](#T-ParquetClassLibrary-IGrid`1 'ParquetClassLibrary.IGrid`1').

<a name='P-ParquetClassLibrary-IGrid`1-Item-System-Int32,System-Int32-'></a>
### Item `property`

##### Summary

Access to any object in the grid.

<a name='P-ParquetClassLibrary-IGrid`1-Rows'></a>
### Rows `property`

##### Summary

Gets the number of elements in the Y dimension of the [IGrid\`1](#T-ParquetClassLibrary-IGrid`1 'ParquetClassLibrary.IGrid`1').

<a name='T-ParquetClassLibrary-Maps-IMapRegionEdit'></a>
## IMapRegionEdit `type`

##### Namespace

ParquetClassLibrary.Maps

##### Summary

Facilitates editing of [MapRegion](#T-ParquetClassLibrary-Maps-MapRegion 'ParquetClassLibrary.Maps.MapRegion') characteristics from design tools while maintaining a read-only face for use during play.

<a name='P-ParquetClassLibrary-Maps-IMapRegionEdit-BackgroundColor'></a>
### BackgroundColor `property`

##### Summary

A color to display in any empty areas of the region.

<a name='P-ParquetClassLibrary-Maps-IMapRegionEdit-ElevationGlobal'></a>
### ElevationGlobal `property`

##### Summary

The region's elevation relative to all other regions.

<a name='P-ParquetClassLibrary-Maps-IMapRegionEdit-ElevationLocal'></a>
### ElevationLocal `property`

##### Summary

The region's elevation in absolute terms.

<a name='P-ParquetClassLibrary-Maps-IMapRegionEdit-Name'></a>
### Name `property`

##### Summary

What the region is called in-game.

<a name='T-ParquetClassLibrary-IModelEdit'></a>
## IModelEdit `type`

##### Namespace

ParquetClassLibrary

##### Summary

Facilitates editing of a [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') from design tools while maintaining a read-only face for use during play.

<a name='P-ParquetClassLibrary-IModelEdit-Comment'></a>
### Comment `property`

##### Summary

Optional comment.

##### Remarks

Could be used for designer notes or to implement an in-game dialogue
with or on the [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model').

<a name='P-ParquetClassLibrary-IModelEdit-Description'></a>
### Description `property`

##### Summary

Player-facing description.

<a name='P-ParquetClassLibrary-IModelEdit-Name'></a>
### Name `property`

##### Summary

Player-facing name.

<a name='T-ParquetClassLibrary-Parquets-IParquetStack'></a>
## IParquetStack `type`

##### Namespace

ParquetClassLibrary.Parquets

##### Summary

Interface to a simple container for one of each layer of parquet occupying the same position.

##### Remarks

Supports injecting [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') into [Rasterization](#T-ParquetClassLibrary-Utilities-Rasterization 'ParquetClassLibrary.Utilities.Rasterization') methods.

<a name='P-ParquetClassLibrary-Parquets-IParquetStack-Block'></a>
### Block `property`

##### Summary

The block contained in this stack.

<a name='P-ParquetClassLibrary-Parquets-IParquetStack-Collectible'></a>
### Collectible `property`

##### Summary

The collectible contained in this stack.

<a name='P-ParquetClassLibrary-Parquets-IParquetStack-Floor'></a>
### Floor `property`

##### Summary

The floor contained in this stack.

<a name='P-ParquetClassLibrary-Parquets-IParquetStack-Furnishing'></a>
### Furnishing `property`

##### Summary

The furnishing contained in this stack.

<a name='P-ParquetClassLibrary-Parquets-IParquetStack-IsEmpty'></a>
### IsEmpty `property`

##### Summary

Indicates whether this [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') is empty.

<a name='T-ParquetClassLibrary-Beings-IPronounGroupEdit'></a>
## IPronounGroupEdit `type`

##### Namespace

ParquetClassLibrary.Beings

##### Summary

Facilitates editing of a [PronounGroup](#T-ParquetClassLibrary-Beings-PronounGroup 'ParquetClassLibrary.Beings.PronounGroup') from design tools while maintaining a read-only face for use during play.

<a name='P-ParquetClassLibrary-Beings-IPronounGroupEdit-Determiner'></a>
### Determiner `property`

##### Summary

Personal pronoun used to attribute possession.

<a name='P-ParquetClassLibrary-Beings-IPronounGroupEdit-Objective'></a>
### Objective `property`

##### Summary

Personal pronoun used as the indirect object of a preposition or verb.

<a name='P-ParquetClassLibrary-Beings-IPronounGroupEdit-Possessive'></a>
### Possessive `property`

##### Summary

Personal pronoun used to indicate a relationship.

<a name='P-ParquetClassLibrary-Beings-IPronounGroupEdit-Reflexive'></a>
### Reflexive `property`

##### Summary

Personal pronoun used to indicate the user.

<a name='P-ParquetClassLibrary-Beings-IPronounGroupEdit-Subjective'></a>
### Subjective `property`

##### Summary

Personal pronoun used as the subject of a verb.

<a name='T-ParquetClassLibrary-IntExtensions'></a>
## IntExtensions `type`

##### Namespace

ParquetClassLibrary

##### Summary

Provides extension methods to the built in integer type.

<a name='M-ParquetClassLibrary-IntExtensions-Normalize-System-Int32,System-Int32,System-Int32-'></a>
### Normalize(inInt,inLowerBound,inUpperBound) `method`

##### Summary

Ensures an integer falls within the given range.

##### Returns

The integer, normalized.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inInt | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Integer to normalize. |
| inLowerBound | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The lowest valid value for the integer. |
| inUpperBound | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The highest valid value for the integer. |

<a name='T-ParquetClassLibrary-Scripts-InteractionModel'></a>
## InteractionModel `type`

##### Namespace

ParquetClassLibrary.Scripts

##### Summary

Models input, output, and process of an in-game interaction.
This could be a quest, cutscene, environmental effect, or dialogue between [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel')s

<a name='M-ParquetClassLibrary-Scripts-InteractionModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID}-'></a>
### #ctor(inID,inName,inDescription,inComment,inPrerequisites,inSteps,inOutcomes) `constructor`

##### Summary

Initializes a new instance of the [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | Unique identifier for the [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel').  Cannot be null. |
| inName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly name of the [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel').  Cannot be null or empty. |
| inDescription | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly description of the [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel'). |
| inComment | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Comment of, on, or by the [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel'). |
| inPrerequisites | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}') | Describes the criteria for beginning this [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel'). |
| inSteps | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}') | Describes the criteria for completing this [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel'). |
| inOutcomes | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}') | Describes the results of finishing this [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel'). |

<a name='P-ParquetClassLibrary-Scripts-InteractionModel-Outcomes'></a>
### Outcomes `property`

##### Summary

Describes the results of finishing this interaction.

<a name='P-ParquetClassLibrary-Scripts-InteractionModel-Prerequisites'></a>
### Prerequisites `property`

##### Summary

Describes the criteria for begining this interaction.

<a name='P-ParquetClassLibrary-Scripts-InteractionModel-Steps'></a>
### Steps `property`

##### Summary

Everything this interaction entails.

<a name='T-ParquetClassLibrary-Scripts-InteractionStatus'></a>
## InteractionStatus `type`

##### Namespace

ParquetClassLibrary.Scripts

##### Summary

Models the status of an [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel').

<a name='M-ParquetClassLibrary-Scripts-InteractionStatus-#ctor-ParquetClassLibrary-Scripts-InteractionModel,ParquetClassLibrary-Scripts-RunState,System-Int32-'></a>
### #ctor(inInteractionDefinition,inState,inProgramCounter) `constructor`

##### Summary

Initializes a new instance of the [InteractionStatus](#T-ParquetClassLibrary-Scripts-InteractionStatus 'ParquetClassLibrary.Scripts.InteractionStatus') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inInteractionDefinition | [ParquetClassLibrary.Scripts.InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel') | The [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel') whose status is being tracked. |
| inState | [ParquetClassLibrary.Scripts.RunState](#T-ParquetClassLibrary-Scripts-RunState 'ParquetClassLibrary.Scripts.RunState') | The [RunState](#T-ParquetClassLibrary-Scripts-RunState 'ParquetClassLibrary.Scripts.RunState') of the tracked [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel'). |
| inProgramCounter | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Index to the current [ScriptNode](#T-ParquetClassLibrary-Scripts-ScriptNode 'ParquetClassLibrary.Scripts.ScriptNode') in the tracked [Steps](#P-ParquetClassLibrary-Scripts-InteractionModel-Steps 'ParquetClassLibrary.Scripts.InteractionModel.Steps'). |

<a name='P-ParquetClassLibrary-Scripts-InteractionStatus-DataVersion'></a>
### DataVersion `property`

##### Summary

Describes the version of serialized data.
Allows selecting data files that can be successfully deserialized.

<a name='P-ParquetClassLibrary-Scripts-InteractionStatus-InteractionDefinition'></a>
### InteractionDefinition `property`

##### Summary

The script being tracked.

<a name='P-ParquetClassLibrary-Scripts-InteractionStatus-ProgramCounter'></a>
### ProgramCounter `property`

##### Summary

The index the script node about to be executed.

<a name='P-ParquetClassLibrary-Scripts-InteractionStatus-Revision'></a>
### Revision `property`

##### Summary

Tracks how many times the data structure has been serialized.

<a name='P-ParquetClassLibrary-Scripts-InteractionStatus-State'></a>
### State `property`

##### Summary

The current execution status of the tracked script.

<a name='M-ParquetClassLibrary-Scripts-InteractionStatus-ToString'></a>
### ToString() `method`

##### Summary

Returns a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents the current [InteractionStatus](#T-ParquetClassLibrary-Scripts-InteractionStatus 'ParquetClassLibrary.Scripts.InteractionStatus').

##### Returns

The representation.

##### Parameters

This method has no parameters.

<a name='T-ParquetClassLibrary-Items-Inventory'></a>
## Inventory `type`

##### Namespace

ParquetClassLibrary.Items

##### Summary

Models an item that characters may carry, use, equip, trade, and/or build with.

<a name='M-ParquetClassLibrary-Items-Inventory-#ctor-System-Int32-'></a>
### #ctor(inCapacity) `constructor`

##### Summary

Initializes a new empty instance of the [Inventory](#T-ParquetClassLibrary-Items-Inventory 'ParquetClassLibrary.Items.Inventory') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inCapacity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | How many inventory slots exist.  Must be positive |

<a name='M-ParquetClassLibrary-Items-Inventory-#ctor-System-Collections-Generic-IEnumerable{ParquetClassLibrary-Items-InventorySlot},System-Int32-'></a>
### #ctor(inSlots,inCapacity) `constructor`

##### Summary

Initializes a new instance of the [Inventory](#T-ParquetClassLibrary-Items-Inventory 'ParquetClassLibrary.Items.Inventory') class from a collection of [InventorySlot](#T-ParquetClassLibrary-Items-InventorySlot 'ParquetClassLibrary.Items.InventorySlot')s.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inSlots | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Items.InventorySlot}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Items.InventorySlot}') | The [InventorySlot](#T-ParquetClassLibrary-Items-InventorySlot 'ParquetClassLibrary.Items.InventorySlot')s to collect.  Cannot be null. |
| inCapacity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | How many inventory slots exist.  Must be positive |

<a name='P-ParquetClassLibrary-Items-Inventory-Capacity'></a>
### Capacity `property`

##### Summary

How many [InventorySlot](#T-ParquetClassLibrary-Items-InventorySlot 'ParquetClassLibrary.Items.InventorySlot')s exits.

<a name='P-ParquetClassLibrary-Items-Inventory-Count'></a>
### Count `property`

##### Summary

How many [InventorySlot](#T-ParquetClassLibrary-Items-InventorySlot 'ParquetClassLibrary.Items.InventorySlot')s are currently occupied.

<a name='P-ParquetClassLibrary-Items-Inventory-Slots'></a>
### Slots `property`

##### Summary

The internal collection mechanism.

<a name='M-ParquetClassLibrary-Items-Inventory-Contains-ParquetClassLibrary-ModelID-'></a>
### Contains(inItemID) `method`

##### Summary

Determines how many of given type of item is contained in the [Inventory](#T-ParquetClassLibrary-Items-Inventory 'ParquetClassLibrary.Items.Inventory').

##### Returns

The number of items of the given type contained.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inItemID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The item type to check for.  Cannot be [None](#F-ParquetClassLibrary-ModelID-None 'ParquetClassLibrary.ModelID.None'). |

<a name='M-ParquetClassLibrary-Items-Inventory-GetEnumerator'></a>
### GetEnumerator() `method`

##### Summary

Retrieves an enumerator for the [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1').

##### Returns

An enumerator that iterates through the inventory.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Items-Inventory-Give-ParquetClassLibrary-Items-InventorySlot-'></a>
### Give(inSlot) `method`

##### Summary

Stores the given [InventorySlot](#T-ParquetClassLibrary-Items-InventorySlot 'ParquetClassLibrary.Items.InventorySlot') if possible.

##### Returns

If everything was stored successfully, `0`;
otherwise, the number of items that could not be stored because the [Inventory](#T-ParquetClassLibrary-Items-Inventory 'ParquetClassLibrary.Items.Inventory') is full.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inSlot | [ParquetClassLibrary.Items.InventorySlot](#T-ParquetClassLibrary-Items-InventorySlot 'ParquetClassLibrary.Items.InventorySlot') | The slot to give. |

<a name='M-ParquetClassLibrary-Items-Inventory-Give-ParquetClassLibrary-ModelID,System-Int32-'></a>
### Give(inItemID,inHowMany) `method`

##### Summary

Stores the given number of the given item, if possible.

##### Returns

If everything was stored successfully, `0`;
otherwise, the number of items that could not be stored because the [Inventory](#T-ParquetClassLibrary-Items-Inventory 'ParquetClassLibrary.Items.Inventory') is full.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inItemID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | What kind of item to give. |
| inHowMany | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | How many of the item to give.  Must be positive. |

<a name='M-ParquetClassLibrary-Items-Inventory-Has-System-Collections-Generic-IEnumerable{System-ValueTuple{ParquetClassLibrary-ModelID,System-Int32}}-'></a>
### Has(inItems) `method`

##### Summary

Determines if the [Inventory](#T-ParquetClassLibrary-Items-Inventory 'ParquetClassLibrary.Items.Inventory') contains the given items in the given quantities.

##### Returns

`true` if everything was found; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inItems | [System.Collections.Generic.IEnumerable{System.ValueTuple{ParquetClassLibrary.ModelID,System.Int32}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.ValueTuple{ParquetClassLibrary.ModelID,System.Int32}}') | The items to check for.  Cannot be null or empty. |

<a name='M-ParquetClassLibrary-Items-Inventory-Has-System-Collections-Generic-IEnumerable{ParquetClassLibrary-Items-InventorySlot}-'></a>
### Has(inSlots) `method`

##### Summary

Determines if the [Inventory](#T-ParquetClassLibrary-Items-Inventory 'ParquetClassLibrary.Items.Inventory') contains the given [InventorySlot](#T-ParquetClassLibrary-Items-InventorySlot 'ParquetClassLibrary.Items.InventorySlot')s.

##### Returns

`true` if everything was found; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inSlots | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Items.InventorySlot}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Items.InventorySlot}') | The slots to check for.  Cannot be null or empty. |

<a name='M-ParquetClassLibrary-Items-Inventory-Has-ParquetClassLibrary-Items-InventorySlot-'></a>
### Has(inSlot) `method`

##### Summary

Determines if the [Inventory](#T-ParquetClassLibrary-Items-Inventory 'ParquetClassLibrary.Items.Inventory') contains the given [InventorySlot](#T-ParquetClassLibrary-Items-InventorySlot 'ParquetClassLibrary.Items.InventorySlot').

##### Returns

`true` if everything was found; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inSlot | [ParquetClassLibrary.Items.InventorySlot](#T-ParquetClassLibrary-Items-InventorySlot 'ParquetClassLibrary.Items.InventorySlot') | The slot to check for.  Cannot be null. |

<a name='M-ParquetClassLibrary-Items-Inventory-Has-ParquetClassLibrary-ModelID,System-Int32-'></a>
### Has(inItemID,inHowMany) `method`

##### Summary

Determines if the [Inventory](#T-ParquetClassLibrary-Items-Inventory 'ParquetClassLibrary.Items.Inventory') contains the given number of the given item.

##### Returns

`true` if everything was found; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inItemID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | What kind of item to check for. |
| inHowMany | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | How many of the item to check for.  Must be positive. |

<a name='M-ParquetClassLibrary-Items-Inventory-System#Collections#IEnumerable#GetEnumerator'></a>
### System#Collections#IEnumerable#GetEnumerator() `method`

##### Summary

Exposes an [IEnumerator](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.IEnumerator 'System.Collections.IEnumerator') to support simple iteration.

##### Returns

An enumerator.

##### Parameters

This method has no parameters.

##### Remarks

Used by LINQ. No accessibility modifiers are valid in this context.

<a name='M-ParquetClassLibrary-Items-Inventory-Take-ParquetClassLibrary-Items-InventorySlot-'></a>
### Take(inSlot) `method`

##### Summary

Removes the given [InventorySlot](#T-ParquetClassLibrary-Items-InventorySlot 'ParquetClassLibrary.Items.InventorySlot'), if possible.

##### Returns

If everything was removed successfully, `0`;
otherwise, the number of items that could not be removed because the [Inventory](#T-ParquetClassLibrary-Items-Inventory 'ParquetClassLibrary.Items.Inventory') did not have any more.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inSlot | [ParquetClassLibrary.Items.InventorySlot](#T-ParquetClassLibrary-Items-InventorySlot 'ParquetClassLibrary.Items.InventorySlot') | The slot to take. |

<a name='M-ParquetClassLibrary-Items-Inventory-Take-ParquetClassLibrary-ModelID,System-Int32-'></a>
### Take(inItemID,inHowMany) `method`

##### Summary

Removes the given number of the given item, if possible.

##### Returns

If everything was removed successfully, `0`;
otherwise, the number of items that could not be removed because the [Inventory](#T-ParquetClassLibrary-Items-Inventory 'ParquetClassLibrary.Items.Inventory') did not have any more.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inItemID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | What kind of item to take. |
| inHowMany | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | How many of the item to take.  Must be positive. |

<a name='M-ParquetClassLibrary-Items-Inventory-ToString'></a>
### ToString() `method`

##### Summary

Returns a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents the current [Inventory](#T-ParquetClassLibrary-Items-Inventory 'ParquetClassLibrary.Items.Inventory').

##### Returns

The representation.

##### Parameters

This method has no parameters.

<a name='T-ParquetClassLibrary-Items-InventorySlot'></a>
## InventorySlot `type`

##### Namespace

ParquetClassLibrary.Items

##### Summary

Allows multiple copies of a given [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel')
to be grouped together in an [Inventory](#T-ParquetClassLibrary-Items-Inventory 'ParquetClassLibrary.Items.Inventory').

<a name='M-ParquetClassLibrary-Items-InventorySlot-#ctor'></a>
### #ctor() `constructor`

##### Summary

Creates a sham slot for serialization purposes.

##### Parameters

This constructor has no parameters.

<a name='M-ParquetClassLibrary-Items-InventorySlot-#ctor-ParquetClassLibrary-ModelID,System-Int32-'></a>
### #ctor(inItemToStore,inHowMany) `constructor`

##### Summary

Creates a new slot to store the given item type.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inItemToStore | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') corresponding to the item being stored here.
Must be in-range and not [None](#F-ParquetClassLibrary-ModelID-None 'ParquetClassLibrary.ModelID.None'). |
| inHowMany | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | How many of the item to store initially.  Must be positive. |

<a name='F-ParquetClassLibrary-Items-InventorySlot-DefaultStackMax'></a>
### DefaultStackMax `constants`

##### Summary

Stack maximum assumed when none is defined.

<a name='F-ParquetClassLibrary-Items-InventorySlot-StackMax'></a>
### StackMax `constants`

##### Summary

How many of the item may share this slow, cached.

<a name='P-ParquetClassLibrary-Items-InventorySlot-ConverterFactory'></a>
### ConverterFactory `property`

##### Summary

Allows the converter to construct itself statically.

<a name='P-ParquetClassLibrary-Items-InventorySlot-Count'></a>
### Count `property`

##### Summary

How many instances of the items are stores in this slot.

<a name='P-ParquetClassLibrary-Items-InventorySlot-ItemID'></a>
### ItemID `property`

##### Summary

What [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel')s are stored in this slot.

<a name='M-ParquetClassLibrary-Items-InventorySlot-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData-'></a>
### ConvertFromString(inText,inRow,inMemberMapData) `method`

##### Summary

Converts the given [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') to an [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') as deserialization.

##### Returns

The given instance deserialized.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inText | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The text to convert. |
| inRow | [CsvHelper.IReaderRow](#T-CsvHelper-IReaderRow 'CsvHelper.IReaderRow') | The current context and configuration. |
| inMemberMapData | [CsvHelper.Configuration.MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') | Mapping info for a member to a CSV field or property. |

<a name='M-ParquetClassLibrary-Items-InventorySlot-ConvertToString-System-Object,CsvHelper-IWriterRow,CsvHelper-Configuration-MemberMapData-'></a>
### ConvertToString(inValue,inRow,inMemberMapData) `method`

##### Summary

Converts the given [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') to a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') for serialization.

##### Returns

The given instance serialized.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inValue | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The instance to convert. |
| inRow | [CsvHelper.IWriterRow](#T-CsvHelper-IWriterRow 'CsvHelper.IWriterRow') | The current context and configuration. |
| inMemberMapData | [CsvHelper.Configuration.MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') | Mapping info for a member to a CSV field or property. |

<a name='M-ParquetClassLibrary-Items-InventorySlot-Give-System-Int32-'></a>
### Give(inHowMany) `method`

##### Summary

Increases the number of items stored by the given amount.

##### Returns

The number of items still needing to be stored if this stack is full.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inHowMany | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | How many of the item to give.  Must be positive. |

<a name='M-ParquetClassLibrary-Items-InventorySlot-Take-System-Int32-'></a>
### Take(inHowMany) `method`

##### Summary

Decreases the number of items stored by the given amount.

##### Returns

The number of items still needing to be removed from another
[InventorySlot](#T-ParquetClassLibrary-Items-InventorySlot 'ParquetClassLibrary.Items.InventorySlot') once this one is emptied.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inHowMany | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | How many of the item to take.  Must be positive. |

<a name='M-ParquetClassLibrary-Items-InventorySlot-ToString'></a>
### ToString() `method`

##### Summary

Returns a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents the current [InventorySlot](#T-ParquetClassLibrary-Items-InventorySlot 'ParquetClassLibrary.Items.InventorySlot').

##### Returns

The representation.

##### Parameters

This method has no parameters.

<a name='T-ParquetClassLibrary-Items-ItemModel'></a>
## ItemModel `type`

##### Namespace

ParquetClassLibrary.Items

##### Summary

Models an item that characters may carry, use, equip, trade, and/or build with.

<a name='M-ParquetClassLibrary-Items-ItemModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,ParquetClassLibrary-Items-ItemType,System-Int32,System-Int32,System-Int32,ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID,System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag}-'></a>
### #ctor(inID,inName,inDescription,inComment,inSubtype,inPrice,inRarity,inStackMax,inEffectWhileHeld,inEffectWhenUsed,inParquetID,inItemTags) `constructor`

##### Summary

Initializes a new instance of the [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | Unique identifier for the [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel').  Cannot be null. |
| inName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly name of the [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel').  Cannot be null or empty. |
| inDescription | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly description of the [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel'). |
| inComment | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Comment of, on, or by the [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel'). |
| inSubtype | [ParquetClassLibrary.Items.ItemType](#T-ParquetClassLibrary-Items-ItemType 'ParquetClassLibrary.Items.ItemType') | The type of [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel'). |
| inPrice | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel') cost. |
| inRarity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel') rarity. |
| inStackMax | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | How many such items may be stacked together in the [Inventory](#T-ParquetClassLibrary-Items-Inventory 'ParquetClassLibrary.Items.Inventory').  Must be positive. |
| inEffectWhileHeld | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel')'s passive effect. |
| inEffectWhenUsed | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel')'s active effect. |
| inParquetID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The parquet represented, if any. |
| inItemTags | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}') | Any additional functionality this item has, e.g. contributing to a [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel'). |

<a name='P-ParquetClassLibrary-Items-ItemModel-EffectWhenUsed'></a>
### EffectWhenUsed `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel') generating the in-game effect caused by
using (consuming) the item.

<a name='P-ParquetClassLibrary-Items-ItemModel-EffectWhileHeld'></a>
### EffectWhileHeld `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel') generating the in-game effect caused by
keeping the item in a [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel')'s [Inventory](#T-ParquetClassLibrary-Items-Inventory 'ParquetClassLibrary.Items.Inventory').

<a name='P-ParquetClassLibrary-Items-ItemModel-ItemTags'></a>
### ItemTags `property`

##### Summary

Any additional functionality this item has, e.g. contributing to a [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel').

<a name='P-ParquetClassLibrary-Items-ItemModel-ParquetID'></a>
### ParquetID `property`

##### Summary

The parquet that corresponds to this item, if any.

<a name='P-ParquetClassLibrary-Items-ItemModel-Price'></a>
### Price `property`

##### Summary

In-game value of the item.  Must be non-negative.

<a name='P-ParquetClassLibrary-Items-ItemModel-Rarity'></a>
### Rarity `property`

##### Summary

How relatively rare this item is.

<a name='P-ParquetClassLibrary-Items-ItemModel-StackMax'></a>
### StackMax `property`

##### Summary

How many of the item may share a single inventory slot.

<a name='P-ParquetClassLibrary-Items-ItemModel-Subtype'></a>
### Subtype `property`

##### Summary

The type of item this is.

<a name='M-ParquetClassLibrary-Items-ItemModel-GetAllTags'></a>
### GetAllTags() `method`

##### Summary

Returns a collection of all [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag')s the [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') has applied to it. Classes inheriting from [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') that include [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag') should override accordingly.

##### Returns

List of all [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag')s.

##### Parameters

This method has no parameters.

<a name='T-ParquetClassLibrary-Items-ItemType'></a>
## ItemType `type`

##### Namespace

ParquetClassLibrary.Items

##### Summary

Represents the different types of [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel')s that may be carried and used.

##### Remarks

The [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel') subtypes are hard-coded, but individual items themselves are configured in CSV files.

<a name='F-ParquetClassLibrary-Items-ItemType-Consumable'></a>
### Consumable `constants`

##### Summary

This item may be used only once.

<a name='F-ParquetClassLibrary-Items-ItemType-Equipment'></a>
### Equipment `constants`

##### Summary

This item may be worn, carried, or otherwise employed in an ongoing fashion.

<a name='F-ParquetClassLibrary-Items-ItemType-KeyItem'></a>
### KeyItem `constants`

##### Summary

This item unlocks a mechanic, domain, or door.

<a name='F-ParquetClassLibrary-Items-ItemType-Material'></a>
### Material `constants`

##### Summary

This item may be used in crafting a recipe.

<a name='F-ParquetClassLibrary-Items-ItemType-Other'></a>
### Other `constants`

##### Summary

This item corresponds to no particular category.

<a name='F-ParquetClassLibrary-Items-ItemType-Storage'></a>
### Storage `constants`

##### Summary

This item may contain other items.

<a name='F-ParquetClassLibrary-Items-ItemType-ToolForGathering'></a>
### ToolForGathering `constants`

##### Summary

This item may be used multiple times to gather parquets.

<a name='F-ParquetClassLibrary-Items-ItemType-ToolForModification'></a>
### ToolForModification `constants`

##### Summary

This item may be used multiple times to alter parquets.

<a name='T-ParquetClassLibrary-Location'></a>
## Location `type`

##### Namespace

ParquetClassLibrary

##### Summary

Represents a specific position within a specific [MapRegion](#T-ParquetClassLibrary-Maps-MapRegion 'ParquetClassLibrary.Maps.MapRegion').

##### Remarks

While primarily used in-library by [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') this class
is made generally available to support it's general use by game client code.

<a name='P-ParquetClassLibrary-Location-Position'></a>
### Position `property`

##### Summary

The position within the current [MapRegion](#T-ParquetClassLibrary-Maps-MapRegion 'ParquetClassLibrary.Maps.MapRegion') of this located.

<a name='P-ParquetClassLibrary-Location-RegionID'></a>
### RegionID `property`

##### Summary

The identifier for the [MapRegion](#T-ParquetClassLibrary-Maps-MapRegion 'ParquetClassLibrary.Maps.MapRegion') of this located.

<a name='M-ParquetClassLibrary-Location-Equals-ParquetClassLibrary-Location-'></a>
### Equals(inLocation) `method`

##### Summary

Determines whether the specified [Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location') is equal to the current [Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location').

##### Returns

`true` if they are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inLocation | [ParquetClassLibrary.Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location') | The [Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location') to compare with the current. |

<a name='M-ParquetClassLibrary-Location-Equals-System-Object-'></a>
### Equals(obj) `method`

##### Summary

Determines whether the specified [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') is equal to the current [Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location').

##### Returns

`true` if they are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') to compare with the current [Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location'). |

<a name='M-ParquetClassLibrary-Location-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Serves as a hash function for a [Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location').

##### Returns

A hash code for this instance that is suitable for use in hashing algorithms and data structures.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Location-ToString'></a>
### ToString() `method`

##### Summary

Describes the [Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location') as a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String').

##### Returns

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents the current [Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location').

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Location-op_Equality-ParquetClassLibrary-Location,ParquetClassLibrary-Location-'></a>
### op_Equality(inLocation1,inLocation2) `method`

##### Summary

Determines whether a specified instance of [Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location') is equal to another specified instance of [Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location').

##### Returns

`true` if they are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inLocation1 | [ParquetClassLibrary.Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location') | The first [Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location') to compare. |
| inLocation2 | [ParquetClassLibrary.Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location') | The second [Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location') to compare. |

<a name='M-ParquetClassLibrary-Location-op_Inequality-ParquetClassLibrary-Location,ParquetClassLibrary-Location-'></a>
### op_Inequality(inLocation1,inLocation2) `method`

##### Summary

Determines whether a specified instance of [Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location') is not equal to another specified instance of [Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location').

##### Returns

`true` if they are NOT equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inLocation1 | [ParquetClassLibrary.Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location') | The first [Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location') to compare. |
| inLocation2 | [ParquetClassLibrary.Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location') | The second [Location](#T-ParquetClassLibrary-Location 'ParquetClassLibrary.Location') to compare. |

<a name='T-ParquetClassLibrary-Maps-MapChunk'></a>
## MapChunk `type`

##### Namespace

ParquetClassLibrary.Maps

##### Summary

Models details of a playable chunk in sandbox.
[MapChunk](#T-ParquetClassLibrary-Maps-MapChunk 'ParquetClassLibrary.Maps.MapChunk')s are composed of parquets and [ExitPoint](#T-ParquetClassLibrary-Maps-ExitPoint 'ParquetClassLibrary.Maps.ExitPoint')s.

<a name='M-ParquetClassLibrary-Maps-MapChunk-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-String,System-Int32,System-Collections-Generic-IEnumerable{ParquetClassLibrary-Maps-ExitPoint},ParquetClassLibrary-Parquets-ParquetStatusGrid,ParquetClassLibrary-Parquets-ParquetStackGrid-'></a>
### #ctor(inID,inName,inDescription,inComment,inDataVersion,inRevision,inExits,inParquetStatuses,inParquetDefinitions) `constructor`

##### Summary

Used by children of the [MapModel](#T-ParquetClassLibrary-Maps-MapModel 'ParquetClassLibrary.Maps.MapModel') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | Unique identifier for the map.  Cannot be null. |
| inName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly name of the map.  Cannot be null or empty. |
| inDescription | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly description of the map. |
| inComment | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Comment of, on, or by the map. |
| inDataVersion | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Describes the version of serialized data, to support versioning. |
| inRevision | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | An option revision count. |
| inExits | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Maps.ExitPoint}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Maps.ExitPoint}') | Locations on the map at which a something happens that cannot be determined from parquets alone. |
| inParquetStatuses | [ParquetClassLibrary.Parquets.ParquetStatusGrid](#T-ParquetClassLibrary-Parquets-ParquetStatusGrid 'ParquetClassLibrary.Parquets.ParquetStatusGrid') | The statuses of the collected parquets. |
| inParquetDefinitions | [ParquetClassLibrary.Parquets.ParquetStackGrid](#T-ParquetClassLibrary-Parquets-ParquetStackGrid 'ParquetClassLibrary.Parquets.ParquetStackGrid') | The definitions of the collected parquets. |

<a name='F-ParquetClassLibrary-Maps-MapChunk-Empty'></a>
### Empty `constants`

##### Summary

Used to indicate an empty grid.

<a name='P-ParquetClassLibrary-Maps-MapChunk-Bounds'></a>
### Bounds `property`

##### Summary

The set of values that are allowed for [MapChunk](#T-ParquetClassLibrary-Maps-MapChunk 'ParquetClassLibrary.Maps.MapChunk')[ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s.

<a name='P-ParquetClassLibrary-Maps-MapChunk-DimensionsInParquets'></a>
### DimensionsInParquets `property`

##### Summary

The chunk's dimensions in parquets.

<a name='P-ParquetClassLibrary-Maps-MapChunk-ParquetDefinitions'></a>
### ParquetDefinitions `property`

##### Summary

Floors and walkable terrain in the chunk.

<a name='P-ParquetClassLibrary-Maps-MapChunk-ParquetStatuses'></a>
### ParquetStatuses `property`

##### Summary

The statuses of parquets in the chunk.

<a name='M-ParquetClassLibrary-Maps-MapChunk-ToString'></a>
### ToString() `method`

##### Summary

Describes the [MapChunk](#T-ParquetClassLibrary-Maps-MapChunk 'ParquetClassLibrary.Maps.MapChunk') as a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing basic information.

##### Returns

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents the current [MapChunk](#T-ParquetClassLibrary-Maps-MapChunk 'ParquetClassLibrary.Maps.MapChunk').

##### Parameters

This method has no parameters.

<a name='T-ParquetClassLibrary-Maps-MapModel'></a>
## MapModel `type`

##### Namespace

ParquetClassLibrary.Maps

##### Summary

Provides methods that are used by all parquet-based map models (for example [MapRegion](#T-ParquetClassLibrary-Maps-MapRegion 'ParquetClassLibrary.Maps.MapRegion') and [MapChunk](#T-ParquetClassLibrary-Maps-MapChunk 'ParquetClassLibrary.Maps.MapChunk'),
but contrast [ChunkTypeGrid](#T-ParquetClassLibrary-Maps-ChunkTypeGrid 'ParquetClassLibrary.Maps.ChunkTypeGrid') which is not parquet-based).

<a name='M-ParquetClassLibrary-Maps-MapModel-#ctor-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-String,System-Int32,System-Collections-Generic-IEnumerable{ParquetClassLibrary-Maps-ExitPoint}-'></a>
### #ctor(inBounds,inID,inName,inDescription,inComment,inDataVersion,inRevision,inExits) `constructor`

##### Summary

Used by children of the [MapModel](#T-ParquetClassLibrary-Maps-MapModel 'ParquetClassLibrary.Maps.MapModel') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inBounds | [ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}](#T-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID} 'ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}') | The bounds within which the derived map type's [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') is defined. |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | Unique identifier for the map.  Cannot be null. |
| inName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly name of the map.  Cannot be null or empty. |
| inDescription | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly description of the map. |
| inComment | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Comment of, on, or by the map. |
| inDataVersion | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Describes the version of serialized data, to support versioning. |
| inRevision | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | How many times this map has been serialized. |
| inExits | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Maps.ExitPoint}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Maps.ExitPoint}') | Locations on the map at which a something happens that cannot be determined from parquets alone. |

<a name='P-ParquetClassLibrary-Maps-MapModel-DataVersion'></a>
### DataVersion `property`

##### Summary

Describes the version of serialized data, to support versioning.

<a name='P-ParquetClassLibrary-Maps-MapModel-DimensionsInParquets'></a>
### DimensionsInParquets `property`

##### Summary

Dimensions in parquets.  Defined by child classes.

<a name='P-ParquetClassLibrary-Maps-MapModel-Exits'></a>
### Exits `property`

##### Summary

Locations on the map at which a something happens that cannot be determined from parquets alone.

<a name='P-ParquetClassLibrary-Maps-MapModel-ParquetDefinitions'></a>
### ParquetDefinitions `property`

##### Summary

Definitions for every [FloorModel](#T-ParquetClassLibrary-Parquets-FloorModel 'ParquetClassLibrary.Parquets.FloorModel'), [BlockModel](#T-ParquetClassLibrary-Parquets-BlockModel 'ParquetClassLibrary.Parquets.BlockModel'), [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel'),
and [CollectibleModel](#T-ParquetClassLibrary-Parquets-CollectibleModel 'ParquetClassLibrary.Parquets.CollectibleModel') that makes up this part of the game world.

<a name='P-ParquetClassLibrary-Maps-MapModel-ParquetStatuses'></a>
### ParquetStatuses `property`

##### Summary

Floors and walkable terrain on the map.

<a name='P-ParquetClassLibrary-Maps-MapModel-ParquetsCount'></a>
### ParquetsCount `property`

##### Summary

The total number of parquets in the entire map.

<a name='P-ParquetClassLibrary-Maps-MapModel-Revision'></a>
### Revision `property`

##### Summary

Tracks how many times the data structure has been serialized.

<a name='M-ParquetClassLibrary-Maps-MapModel-GetSubregion'></a>
### GetSubregion() `method`

##### Summary

Provides all parquet definitions within the current map.

##### Returns

The entire map as a subregion.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Maps-MapModel-GetSubregion-ParquetClassLibrary-Vector2D,ParquetClassLibrary-Vector2D-'></a>
### GetSubregion(inUpperLeft,inLowerRight) `method`

##### Summary

Provides all parquet definitions within the specified rectangular subsection of the current map.

##### Returns

A portion of the map as a subregion.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inUpperLeft | [ParquetClassLibrary.Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') | The position of the upper-leftmost corner of the subregion. |
| inLowerRight | [ParquetClassLibrary.Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') | The position of the lower-rightmost corner of the subregion. |

<a name='M-ParquetClassLibrary-Maps-MapModel-IsValidPosition-ParquetClassLibrary-Vector2D-'></a>
### IsValidPosition(inPosition) `method`

##### Summary

Determines if the given position corresponds to a point in the region.

##### Returns

`true`, if the position is valid, `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inPosition | [ParquetClassLibrary.Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') | The position to validate. |

<a name='M-ParquetClassLibrary-Maps-MapModel-ToString'></a>
### ToString() `method`

##### Summary

Describes the map through general characteristics.

##### Returns

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents the current map.

##### Parameters

This method has no parameters.

<a name='T-ParquetClassLibrary-Maps-MapRegion'></a>
## MapRegion `type`

##### Namespace

ParquetClassLibrary.Maps

##### Summary

A playable region in sandbox.

<a name='M-ParquetClassLibrary-Maps-MapRegion-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-String,System-Int32,System-String,ParquetClassLibrary-Biomes-Elevation,System-Int32,System-Collections-Generic-IEnumerable{ParquetClassLibrary-Maps-ExitPoint},ParquetClassLibrary-Parquets-ParquetStatusGrid,ParquetClassLibrary-Parquets-ParquetStackGrid-'></a>
### #ctor(inID,inName,inDescription,inComment,inDataVersion,inRevision,inBackgroundColor,inElevationLocal,inElevationGlobal,inExits,inParquetStatuses,inParquetDefinitions) `constructor`

##### Summary

Constructs a new instance of the [MapRegion](#T-ParquetClassLibrary-Maps-MapRegion 'ParquetClassLibrary.Maps.MapRegion') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | Unique identifier for the map.  Cannot be null. |
| inName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The player-facing name of the new region. |
| inDescription | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly description of the map. |
| inComment | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Comment of, on, or by the map. |
| inDataVersion | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Describes the version of serialized data, to support versioning. |
| inRevision | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | An option revision count. |
| inBackgroundColor | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A color to show in the new region when no parquet is present. |
| inElevationLocal | [ParquetClassLibrary.Biomes.Elevation](#T-ParquetClassLibrary-Biomes-Elevation 'ParquetClassLibrary.Biomes.Elevation') | The absolute elevation of this region. |
| inElevationGlobal | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The relative elevation of this region expressed as a signed integer. |
| inExits | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Maps.ExitPoint}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Maps.ExitPoint}') | Locations on the map at which a something happens that cannot be determined from parquets alone. |
| inParquetStatuses | [ParquetClassLibrary.Parquets.ParquetStatusGrid](#T-ParquetClassLibrary-Parquets-ParquetStatusGrid 'ParquetClassLibrary.Parquets.ParquetStatusGrid') | The statuses of the collected parquets. |
| inParquetDefinitions | [ParquetClassLibrary.Parquets.ParquetStackGrid](#T-ParquetClassLibrary-Parquets-ParquetStackGrid 'ParquetClassLibrary.Parquets.ParquetStackGrid') | The definitions of the collected parquets. |

<a name='F-ParquetClassLibrary-Maps-MapRegion-DefaultColor'></a>
### DefaultColor `constants`

##### Summary

Default color for new regions.

<a name='F-ParquetClassLibrary-Maps-MapRegion-DefaultGlobalElevation'></a>
### DefaultGlobalElevation `constants`

##### Summary

Relative elevation to use if none is provided.

<a name='F-ParquetClassLibrary-Maps-MapRegion-DefaultName'></a>
### DefaultName `constants`

##### Summary

Default name for new regions.

<a name='F-ParquetClassLibrary-Maps-MapRegion-Empty'></a>
### Empty `constants`

##### Summary

Used to indicate an empty grid.

<a name='P-ParquetClassLibrary-Maps-MapRegion-BackgroundColor'></a>
### BackgroundColor `property`

##### Summary

A color to display in any empty areas of the region.

<a name='P-ParquetClassLibrary-Maps-MapRegion-Bounds'></a>
### Bounds `property`

##### Summary

The set of values that are allowed for [MapRegion](#T-ParquetClassLibrary-Maps-MapRegion 'ParquetClassLibrary.Maps.MapRegion')[ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s.

<a name='P-ParquetClassLibrary-Maps-MapRegion-DimensionsInParquets'></a>
### DimensionsInParquets `property`

##### Summary

The region's dimensions in parquets.

<a name='P-ParquetClassLibrary-Maps-MapRegion-ElevationGlobal'></a>
### ElevationGlobal `property`

##### Summary

The region's elevation relative to all other regions.

<a name='P-ParquetClassLibrary-Maps-MapRegion-ElevationLocal'></a>
### ElevationLocal `property`

##### Summary

The region's elevation in absolute terms.

<a name='P-ParquetClassLibrary-Maps-MapRegion-ParquetClassLibrary#Maps#IMapRegionEdit#BackgroundColor'></a>
### ParquetClassLibrary#Maps#IMapRegionEdit#BackgroundColor `property`

##### Summary

A color to display in any empty areas of the region.

<a name='P-ParquetClassLibrary-Maps-MapRegion-ParquetClassLibrary#Maps#IMapRegionEdit#ElevationGlobal'></a>
### ParquetClassLibrary#Maps#IMapRegionEdit#ElevationGlobal `property`

##### Summary

The region's elevation relative to all other regions.

<a name='P-ParquetClassLibrary-Maps-MapRegion-ParquetClassLibrary#Maps#IMapRegionEdit#ElevationLocal'></a>
### ParquetClassLibrary#Maps#IMapRegionEdit#ElevationLocal `property`

##### Summary

The region's elevation in absolute terms.

<a name='P-ParquetClassLibrary-Maps-MapRegion-ParquetClassLibrary#Maps#IMapRegionEdit#Name'></a>
### ParquetClassLibrary#Maps#IMapRegionEdit#Name `property`

##### Summary

What the region is called in-game.

<a name='P-ParquetClassLibrary-Maps-MapRegion-ParquetDefinitions'></a>
### ParquetDefinitions `property`

##### Summary

Parquets that make up the region.  If changing or replacing one of these,
remember to update the corresponding element in [ParquetStatuses](#P-ParquetClassLibrary-Maps-MapRegion-ParquetStatuses 'ParquetClassLibrary.Maps.MapRegion.ParquetStatuses')!

<a name='P-ParquetClassLibrary-Maps-MapRegion-ParquetStatuses'></a>
### ParquetStatuses `property`

##### Summary

The statuses of parquets in the chunk.

<a name='M-ParquetClassLibrary-Maps-MapRegion-ToString'></a>
### ToString() `method`

##### Summary

Describes the [MapRegion](#T-ParquetClassLibrary-Maps-MapRegion 'ParquetClassLibrary.Maps.MapRegion').

##### Returns

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents the current [MapRegion](#T-ParquetClassLibrary-Maps-MapRegion 'ParquetClassLibrary.Maps.MapRegion').

##### Parameters

This method has no parameters.

<a name='T-ParquetClassLibrary-Maps-MapRegionSketch'></a>
## MapRegionSketch `type`

##### Namespace

ParquetClassLibrary.Maps

##### Summary

A pattern and metadata to generate a playable region.

##### Remarks

[MapRegion](#T-ParquetClassLibrary-Maps-MapRegion 'ParquetClassLibrary.Maps.MapRegion')s are stored as [MapRegionSketch](#T-ParquetClassLibrary-Maps-MapRegionSketch 'ParquetClassLibrary.Maps.MapRegionSketch')es, for example in an editor tool,
before being fleshed, for example on load in-game.

<a name='M-ParquetClassLibrary-Maps-MapRegionSketch-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-String,System-Int32,System-String,ParquetClassLibrary-Biomes-Elevation,System-Int32,System-Collections-Generic-IEnumerable{ParquetClassLibrary-Maps-ExitPoint},ParquetClassLibrary-Maps-ChunkTypeGrid-'></a>
### #ctor(inID,inName,inDescription,inComment,inDataVersion,inRevision,inBackgroundColor,inElevationLocal,inElevationGlobal,inExits,inChunks) `constructor`

##### Summary

Constructs a new instance of the [MapRegionSketch](#T-ParquetClassLibrary-Maps-MapRegionSketch 'ParquetClassLibrary.Maps.MapRegionSketch') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | Unique identifier for the map.  Cannot be null. |
| inName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The player-facing name of the new region. |
| inDescription | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly description of the map. |
| inComment | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Comment of, on, or by the map. |
| inDataVersion | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Describes the version of serialized data, to support versioning. |
| inRevision | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | An option revision count. |
| inBackgroundColor | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A color to show in the new region when no parquet is present. |
| inElevationLocal | [ParquetClassLibrary.Biomes.Elevation](#T-ParquetClassLibrary-Biomes-Elevation 'ParquetClassLibrary.Biomes.Elevation') | The absolute elevation of this region. |
| inElevationGlobal | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The relative elevation of this region expressed as a signed integer. |
| inExits | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Maps.ExitPoint}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Maps.ExitPoint}') | Locations on the map at which a something happens that cannot be determined from parquets alone. |
| inChunks | [ParquetClassLibrary.Maps.ChunkTypeGrid](#T-ParquetClassLibrary-Maps-ChunkTypeGrid 'ParquetClassLibrary.Maps.ChunkTypeGrid') | The pattern from which a [MapRegion](#T-ParquetClassLibrary-Maps-MapRegion 'ParquetClassLibrary.Maps.MapRegion') may be generated. |

<a name='F-ParquetClassLibrary-Maps-MapRegionSketch-DefaultColor'></a>
### DefaultColor `constants`

##### Summary

Default color for new regions.

<a name='F-ParquetClassLibrary-Maps-MapRegionSketch-DefaultGlobalElevation'></a>
### DefaultGlobalElevation `constants`

##### Summary

Relative elevation to use if none is provided.

<a name='F-ParquetClassLibrary-Maps-MapRegionSketch-DefaultTitle'></a>
### DefaultTitle `constants`

##### Summary

Default name for new regions.

<a name='F-ParquetClassLibrary-Maps-MapRegionSketch-Empty'></a>
### Empty `constants`

##### Summary

Used to indicate an empty grid.

<a name='P-ParquetClassLibrary-Maps-MapRegionSketch-BackgroundColor'></a>
### BackgroundColor `property`

##### Summary

A color to display in any empty areas of the region.

<a name='P-ParquetClassLibrary-Maps-MapRegionSketch-Bounds'></a>
### Bounds `property`

##### Summary

The set of values that are allowed for [MapRegionSketch](#T-ParquetClassLibrary-Maps-MapRegionSketch 'ParquetClassLibrary.Maps.MapRegionSketch')[ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s.

<a name='P-ParquetClassLibrary-Maps-MapRegionSketch-Chunks'></a>
### Chunks `property`

##### Summary

[ChunkType](#T-ParquetClassLibrary-Maps-ChunkType 'ParquetClassLibrary.Maps.ChunkType')s that can generate parquets to compose a [MapRegion](#T-ParquetClassLibrary-Maps-MapRegion 'ParquetClassLibrary.Maps.MapRegion').

<a name='P-ParquetClassLibrary-Maps-MapRegionSketch-DimensionsInParquets'></a>
### DimensionsInParquets `property`

##### Summary

The region's dimensions in parquets.

<a name='P-ParquetClassLibrary-Maps-MapRegionSketch-ElevationGlobal'></a>
### ElevationGlobal `property`

##### Summary

The region's elevation relative to all other regions.

<a name='P-ParquetClassLibrary-Maps-MapRegionSketch-ElevationLocal'></a>
### ElevationLocal `property`

##### Summary

The region's elevation in absolute terms.

<a name='P-ParquetClassLibrary-Maps-MapRegionSketch-ParquetClassLibrary#Maps#IMapRegionEdit#BackgroundColor'></a>
### ParquetClassLibrary#Maps#IMapRegionEdit#BackgroundColor `property`

##### Summary

A color to display in any empty areas of the region.

<a name='P-ParquetClassLibrary-Maps-MapRegionSketch-ParquetClassLibrary#Maps#IMapRegionEdit#ElevationGlobal'></a>
### ParquetClassLibrary#Maps#IMapRegionEdit#ElevationGlobal `property`

##### Summary

The region's elevation relative to all other regions.

<a name='P-ParquetClassLibrary-Maps-MapRegionSketch-ParquetClassLibrary#Maps#IMapRegionEdit#ElevationLocal'></a>
### ParquetClassLibrary#Maps#IMapRegionEdit#ElevationLocal `property`

##### Summary

The region's elevation in absolute terms.

<a name='P-ParquetClassLibrary-Maps-MapRegionSketch-ParquetClassLibrary#Maps#IMapRegionEdit#Name'></a>
### ParquetClassLibrary#Maps#IMapRegionEdit#Name `property`

##### Summary

What the region is called in-game.

<a name='P-ParquetClassLibrary-Maps-MapRegionSketch-ParquetDefinitions'></a>
### ParquetDefinitions `property`

##### Summary

Generate a [MapRegion](#T-ParquetClassLibrary-Maps-MapRegion 'ParquetClassLibrary.Maps.MapRegion') before accessing parquets.

<a name='P-ParquetClassLibrary-Maps-MapRegionSketch-ParquetStatuses'></a>
### ParquetStatuses `property`

##### Summary

Generate a [MapRegion](#T-ParquetClassLibrary-Maps-MapRegion 'ParquetClassLibrary.Maps.MapRegion') before accessing parquet statuses.

<a name='M-ParquetClassLibrary-Maps-MapRegionSketch-ToString'></a>
### ToString() `method`

##### Summary

Describes the [MapRegionSketch](#T-ParquetClassLibrary-Maps-MapRegionSketch 'ParquetClassLibrary.Maps.MapRegionSketch').

##### Returns

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents the current [MapRegionSketch](#T-ParquetClassLibrary-Maps-MapRegionSketch 'ParquetClassLibrary.Maps.MapRegionSketch').

##### Parameters

This method has no parameters.

<a name='T-ParquetClassLibrary-Rooms-MapSpace'></a>
## MapSpace `type`

##### Namespace

ParquetClassLibrary.Rooms

##### Summary

A [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') together with its coordinates within a given [MapRegion](#T-ParquetClassLibrary-Maps-MapRegion 'ParquetClassLibrary.Maps.MapRegion').

<a name='M-ParquetClassLibrary-Rooms-MapSpace-#ctor-ParquetClassLibrary-Vector2D,ParquetClassLibrary-Parquets-ParquetStack,ParquetClassLibrary-Parquets-ParquetStackGrid-'></a>
### #ctor(inPosition,inContent,inSubregion) `constructor`

##### Summary

Initializes a new instance of the [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inPosition | [ParquetClassLibrary.Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') | Where this [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') is. |
| inContent | [ParquetClassLibrary.Parquets.ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') | All parquets occupying this [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace'). |
| inSubregion | [ParquetClassLibrary.Parquets.ParquetStackGrid](#T-ParquetClassLibrary-Parquets-ParquetStackGrid 'ParquetClassLibrary.Parquets.ParquetStackGrid') | The [ParquetStackGrid](#T-ParquetClassLibrary-Parquets-ParquetStackGrid 'ParquetClassLibrary.Parquets.ParquetStackGrid') within which this [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') occurs. |

<a name='M-ParquetClassLibrary-Rooms-MapSpace-#ctor-System-Int32,System-Int32,ParquetClassLibrary-Parquets-ParquetStack,ParquetClassLibrary-Parquets-ParquetStackGrid-'></a>
### #ctor(inX,inY,inContent,inSubregion) `constructor`

##### Summary

Initializes a new instance of the [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inX | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | X-coordinate of this [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace'). |
| inY | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Y-coordinate of this [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace'). |
| inContent | [ParquetClassLibrary.Parquets.ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') | All parquets occupying this [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace'). |
| inSubregion | [ParquetClassLibrary.Parquets.ParquetStackGrid](#T-ParquetClassLibrary-Parquets-ParquetStackGrid 'ParquetClassLibrary.Parquets.ParquetStackGrid') | The subregion in which this [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') occurs. |

<a name='F-ParquetClassLibrary-Rooms-MapSpace-Empty'></a>
### Empty `constants`

##### Summary

The null [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace'), which exists nowhere and contains nothing.

<a name='P-ParquetClassLibrary-Rooms-MapSpace-Content'></a>
### Content `property`

##### Summary

All parquets occupying this [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace').

<a name='P-ParquetClassLibrary-Rooms-MapSpace-IsEmpty'></a>
### IsEmpty `property`

##### Summary

Indicates whether this [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') is empty.

<a name='P-ParquetClassLibrary-Rooms-MapSpace-IsEnclosing'></a>
### IsEnclosing `property`

##### Summary

A [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') is Enclosing iff:
1, It has a [BlockModel](#T-ParquetClassLibrary-Parquets-BlockModel 'ParquetClassLibrary.Parquets.BlockModel') that is not [IsLiquid](#P-ParquetClassLibrary-Parquets-BlockModel-IsLiquid 'ParquetClassLibrary.Parquets.BlockModel.IsLiquid'); or,
2, It has a [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') that is [IsEnclosing](#P-ParquetClassLibrary-Parquets-FurnishingModel-IsEnclosing 'ParquetClassLibrary.Parquets.FurnishingModel.IsEnclosing').

##### Returns

`true`, if this [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') is Enclosing, `false` otherwise.

<a name='P-ParquetClassLibrary-Rooms-MapSpace-IsEntry'></a>
### IsEntry `property`

##### Summary

A [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') is Entry iff:
1, Its [Content](#P-ParquetClassLibrary-Rooms-MapSpace-Content 'ParquetClassLibrary.Rooms.MapSpace.Content') is either Walkable or Enclosing; and,
2, It has a [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') that is [IsEntry](#P-ParquetClassLibrary-Parquets-FurnishingModel-IsEntry 'ParquetClassLibrary.Parquets.FurnishingModel.IsEntry').

##### Returns

`true`, if this [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') is Entry, `false` otherwise.

<a name='P-ParquetClassLibrary-Rooms-MapSpace-IsWalkable'></a>
### IsWalkable `property`

##### Summary

A [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') is Walkable iff:
1, It has a [FloorModel](#T-ParquetClassLibrary-Parquets-FloorModel 'ParquetClassLibrary.Parquets.FloorModel');
2, It does not have a [BlockModel](#T-ParquetClassLibrary-Parquets-BlockModel 'ParquetClassLibrary.Parquets.BlockModel');
3, It does not have a [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') that is not [IsEnclosing](#P-ParquetClassLibrary-Parquets-FurnishingModel-IsEnclosing 'ParquetClassLibrary.Parquets.FurnishingModel.IsEnclosing').

##### Returns

`true`, if this [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') is Walkable, `false` otherwise.

<a name='P-ParquetClassLibrary-Rooms-MapSpace-IsWalkableEntry'></a>
### IsWalkableEntry `property`

##### Summary

Determines if this [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') is both [IsEntry](#P-ParquetClassLibrary-Rooms-MapSpace-IsEntry 'ParquetClassLibrary.Rooms.MapSpace.IsEntry')
and [IsWalkable](#P-ParquetClassLibrary-Rooms-MapSpace-IsWalkable 'ParquetClassLibrary.Rooms.MapSpace.IsWalkable').

##### Returns

`true`, if this [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') may be used as a walkable entry by a [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room'), `false` otherwise.

##### See Also

- [ParquetClassLibrary.Rooms.MapSpace.IsEnclosingEntry](#M-ParquetClassLibrary-Rooms-MapSpace-IsEnclosingEntry-ParquetClassLibrary-Rooms-MapSpaceCollection- 'ParquetClassLibrary.Rooms.MapSpace.IsEnclosingEntry(ParquetClassLibrary.Rooms.MapSpaceCollection)')

<a name='P-ParquetClassLibrary-Rooms-MapSpace-Position'></a>
### Position `property`

##### Summary

Location of this [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace').

<a name='P-ParquetClassLibrary-Rooms-MapSpace-Subregion'></a>
### Subregion `property`

##### Summary

The subregion containing this [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace').

<a name='M-ParquetClassLibrary-Rooms-MapSpace-EastNeighbor'></a>
### EastNeighbor() `method`

##### Summary

Finds the [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') to the east of the given space, if any.

##### Returns

A [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') if it exists, or [Empty](#F-ParquetClassLibrary-Rooms-MapSpace-Empty 'ParquetClassLibrary.Rooms.MapSpace.Empty') otherwise.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Rooms-MapSpace-Equals-ParquetClassLibrary-Rooms-MapSpace-'></a>
### Equals(inSpace) `method`

##### Summary

Determines whether the specified [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') is equal to the current [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace').

##### Returns

`true` if the [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace')s are equal.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inSpace | [ParquetClassLibrary.Rooms.MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') | The [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') to compare with the current. |

<a name='M-ParquetClassLibrary-Rooms-MapSpace-Equals-System-Object-'></a>
### Equals(obj) `method`

##### Summary

Determines whether the specified [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') is equal to the current [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace').

##### Returns

`true` if the specified [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') is equal to the current [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace'); otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') to compare with the current [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace'). |

<a name='M-ParquetClassLibrary-Rooms-MapSpace-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Serves as a hash function for a [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') class.

##### Returns

A hash code for this instance that is suitable for use in hashing algorithms and data structures.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Rooms-MapSpace-IsEnclosingEntry-ParquetClassLibrary-Rooms-MapSpaceCollection-'></a>
### IsEnclosingEntry(inWalkableArea) `method`

##### Summary

Determines if this [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') is:
1) [IsEntry](#P-ParquetClassLibrary-Rooms-MapSpace-IsEntry 'ParquetClassLibrary.Rooms.MapSpace.IsEntry')
2) [IsEnclosing](#P-ParquetClassLibrary-Rooms-MapSpace-IsEnclosing 'ParquetClassLibrary.Rooms.MapSpace.IsEnclosing')
3) has one walkable neighbor that is within the given [MapSpaceCollection](#T-ParquetClassLibrary-Rooms-MapSpaceCollection 'ParquetClassLibrary.Rooms.MapSpaceCollection') and one not within the collection.

##### Returns

`true`, if this [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') may be used as an enclosing entry by a [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room'), `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inWalkableArea | [ParquetClassLibrary.Rooms.MapSpaceCollection](#T-ParquetClassLibrary-Rooms-MapSpaceCollection 'ParquetClassLibrary.Rooms.MapSpaceCollection') | The [MapSpaceCollection](#T-ParquetClassLibrary-Rooms-MapSpaceCollection 'ParquetClassLibrary.Rooms.MapSpaceCollection') used to define this [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace'). |

<a name='M-ParquetClassLibrary-Rooms-MapSpace-Neighbor-ParquetClassLibrary-Vector2D-'></a>
### Neighbor() `method`

##### Summary

Finds the [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') related to the given space by the given offset, if any.

##### Returns

A [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') if it exists, or [Empty](#F-ParquetClassLibrary-Rooms-MapSpace-Empty 'ParquetClassLibrary.Rooms.MapSpace.Empty') otherwise.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Rooms-MapSpace-Neighbors'></a>
### Neighbors() `method`

##### Summary

Finds the [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') related to the given space by the given offset, if any.

##### Returns

A list of four [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace')s, some or all of which may be [Empty](#F-ParquetClassLibrary-Rooms-MapSpace-Empty 'ParquetClassLibrary.Rooms.MapSpace.Empty').

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Rooms-MapSpace-NorthNeighbor'></a>
### NorthNeighbor() `method`

##### Summary

Finds the [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') to the north of the given space, if any.

##### Returns

A [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') if it exists, or [Empty](#F-ParquetClassLibrary-Rooms-MapSpace-Empty 'ParquetClassLibrary.Rooms.MapSpace.Empty') otherwise.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Rooms-MapSpace-SouthNeighbor'></a>
### SouthNeighbor() `method`

##### Summary

Finds the [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') to the south of the given space, if any.

##### Returns

A [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') if it exists, or [Empty](#F-ParquetClassLibrary-Rooms-MapSpace-Empty 'ParquetClassLibrary.Rooms.MapSpace.Empty') otherwise.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Rooms-MapSpace-ToString'></a>
### ToString() `method`

##### Summary

Returns a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents the current [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace').

##### Returns

The representation.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Rooms-MapSpace-WestNeighbor'></a>
### WestNeighbor() `method`

##### Summary

Finds the [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') to the west of the given space, if any.

##### Returns

A [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') if it exists, or [Empty](#F-ParquetClassLibrary-Rooms-MapSpace-Empty 'ParquetClassLibrary.Rooms.MapSpace.Empty') otherwise.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Rooms-MapSpace-op_Equality-ParquetClassLibrary-Rooms-MapSpace,ParquetClassLibrary-Rooms-MapSpace-'></a>
### op_Equality(inSpace1,inSpace2) `method`

##### Summary

Determines whether a specified instance of [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') is equal to
another specified instance of [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace').

##### Returns

`true` if the two [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace')s are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inSpace1 | [ParquetClassLibrary.Rooms.MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') | The first [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') to compare. |
| inSpace2 | [ParquetClassLibrary.Rooms.MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') | The second [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') to compare. |

<a name='M-ParquetClassLibrary-Rooms-MapSpace-op_Inequality-ParquetClassLibrary-Rooms-MapSpace,ParquetClassLibrary-Rooms-MapSpace-'></a>
### op_Inequality(inSpace1,inSpace2) `method`

##### Summary

Determines whether a specified instance of [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') is unequal to
another specified instance of [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace').

##### Returns

`true` if the two [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace')s are NOT equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inSpace1 | [ParquetClassLibrary.Rooms.MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') | The first [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') to compare. |
| inSpace2 | [ParquetClassLibrary.Rooms.MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') | The second [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') to compare. |

<a name='T-ParquetClassLibrary-Rooms-MapSpaceCollection'></a>
## MapSpaceCollection `type`

##### Namespace

ParquetClassLibrary.Rooms

##### Summary

Stores a collection of [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace')s.
Provides bounds-checking and various routines useful when dealing with [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room')s.

<a name='M-ParquetClassLibrary-Rooms-MapSpaceCollection-#ctor-System-Collections-Generic-IEnumerable{ParquetClassLibrary-Rooms-MapSpace}-'></a>
### #ctor(inSpaces) `constructor`

##### Summary

Initializes a new instance of the [MapSpaceCollection](#T-ParquetClassLibrary-Rooms-MapSpaceCollection 'ParquetClassLibrary.Rooms.MapSpaceCollection') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inSpaces | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Rooms.MapSpace}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Rooms.MapSpace}') | The [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace')s to collect.  Cannot be null. |

<a name='P-ParquetClassLibrary-Rooms-MapSpaceCollection-Count'></a>
### Count `property`

##### Summary

The number of [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace')s in the [MapSpaceCollection](#T-ParquetClassLibrary-Rooms-MapSpaceCollection 'ParquetClassLibrary.Rooms.MapSpaceCollection').

<a name='P-ParquetClassLibrary-Rooms-MapSpaceCollection-Empty'></a>
### Empty `property`

##### Summary

The canonical empty collection.

<a name='P-ParquetClassLibrary-Rooms-MapSpaceCollection-First'></a>
### First `property`

##### Summary

The first [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') in the sequence, if any.

<a name='P-ParquetClassLibrary-Rooms-MapSpaceCollection-Spaces'></a>
### Spaces `property`

##### Summary

The internal collection mechanism.

<a name='M-ParquetClassLibrary-Rooms-MapSpaceCollection-AllSpacesAreReachable-System-Predicate{ParquetClassLibrary-Rooms-MapSpace}-'></a>
### AllSpacesAreReachable(inIsApplicable) `method`

##### Summary

Determines if it is possible to reach every [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') in the given subregion
whose [Content](#P-ParquetClassLibrary-Rooms-MapSpace-Content 'ParquetClassLibrary.Rooms.MapSpace.Content') conforms to the given predicate using only
4-connected movements, beginning at an arbitrary [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace').

##### Returns

`true` if all members of the given set are reachable from all other members of the given set.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inIsApplicable | [System.Predicate{ParquetClassLibrary.Rooms.MapSpace}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Predicate 'System.Predicate{ParquetClassLibrary.Rooms.MapSpace}') | Determines if a [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') is a target MapSpace. |

<a name='M-ParquetClassLibrary-Rooms-MapSpaceCollection-AllSpacesAreReachableAndCycleExists-System-Predicate{ParquetClassLibrary-Rooms-MapSpace}-'></a>
### AllSpacesAreReachableAndCycleExists(inIsApplicable) `method`

##### Summary

Determines if it is possible to reach every [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') in the given subregion
whose [Content](#P-ParquetClassLibrary-Rooms-MapSpace-Content 'ParquetClassLibrary.Rooms.MapSpace.Content') conforms to the given predicate using only
4-connected movements, beginning at an arbitrary [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace'), while encountering
at least one cycle.

##### Returns

`true` if all members of the given set are reachable from all other members of the given set.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inIsApplicable | [System.Predicate{ParquetClassLibrary.Rooms.MapSpace}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Predicate 'System.Predicate{ParquetClassLibrary.Rooms.MapSpace}') | Determines if a [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') is a target MapSpace. |

<a name='M-ParquetClassLibrary-Rooms-MapSpaceCollection-Contains-ParquetClassLibrary-Rooms-MapSpace-'></a>
### Contains(inSpace) `method`

##### Summary

Determines whether the [MapSpaceCollection](#T-ParquetClassLibrary-Rooms-MapSpaceCollection 'ParquetClassLibrary.Rooms.MapSpaceCollection') contains the specified [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace').

##### Returns

`true` if the [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') was found; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inSpace | [ParquetClassLibrary.Rooms.MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') | The [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') to find. |

<a name='M-ParquetClassLibrary-Rooms-MapSpaceCollection-GetEnumerator'></a>
### GetEnumerator() `method`

##### Summary

Exposes an enumerator for the [MapSpaceCollection](#T-ParquetClassLibrary-Rooms-MapSpaceCollection 'ParquetClassLibrary.Rooms.MapSpaceCollection'), which supports simple iteration.

##### Returns

An enumerator.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Rooms-MapSpaceCollection-Search-ParquetClassLibrary-Rooms-MapSpace,System-Predicate{ParquetClassLibrary-Rooms-MapSpace},System-Predicate{ParquetClassLibrary-Rooms-MapSpace}-'></a>
### Search(inStart,inIsApplicable,inIsGoal) `method`

##### Summary

Searches the given set of [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace')s using only 4-connected movements,
considering all spaces that conform to the given applicability predicate,
beginning at an arbitrary space and continuing until the given goal predicate is satisfied.

##### Returns

Information about the results of the search procedure.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inStart | [ParquetClassLibrary.Rooms.MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') | The [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') to begin searching from. |
| inIsApplicable | [System.Predicate{ParquetClassLibrary.Rooms.MapSpace}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Predicate 'System.Predicate{ParquetClassLibrary.Rooms.MapSpace}') | `true` if a [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') ought to be considered. |
| inIsGoal | [System.Predicate{ParquetClassLibrary.Rooms.MapSpace}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Predicate 'System.Predicate{ParquetClassLibrary.Rooms.MapSpace}') | `true` if a the search goal has been satisfied. |

##### Remarks

Searches in a preorder, depth-first fashion.

<a name='M-ParquetClassLibrary-Rooms-MapSpaceCollection-SetEquals-ParquetClassLibrary-Rooms-MapSpaceCollection-'></a>
### SetEquals(inEqualTo) `method`

##### Summary

Determines whether the [MapSpaceCollection](#T-ParquetClassLibrary-Rooms-MapSpaceCollection 'ParquetClassLibrary.Rooms.MapSpaceCollection') is set-equal to the given MapSpaceCollection.

##### Returns

`true` if the [MapSpaceCollection](#T-ParquetClassLibrary-Rooms-MapSpaceCollection 'ParquetClassLibrary.Rooms.MapSpaceCollection')s are set-equal; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inEqualTo | [ParquetClassLibrary.Rooms.MapSpaceCollection](#T-ParquetClassLibrary-Rooms-MapSpaceCollection 'ParquetClassLibrary.Rooms.MapSpaceCollection') | The collection to compare against this collection. Cannot be null. |

<a name='M-ParquetClassLibrary-Rooms-MapSpaceCollection-System#Collections#Generic#IEnumerable{ParquetClassLibrary#Rooms#MapSpace}#GetEnumerator'></a>
### System#Collections#Generic#IEnumerable{ParquetClassLibrary#Rooms#MapSpace}#GetEnumerator() `method`

##### Summary

Exposes an [IEnumerator\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerator`1 'System.Collections.Generic.IEnumerator`1'), which supports simple iteration.

##### Returns

An enumerator.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Rooms-MapSpaceCollection-ToString'></a>
### ToString() `method`

##### Summary

Returns a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents the current [MapSpaceCollection](#T-ParquetClassLibrary-Rooms-MapSpaceCollection 'ParquetClassLibrary.Rooms.MapSpaceCollection').

##### Returns

The representation.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Rooms-MapSpaceCollection-TryGetPerimeter-ParquetClassLibrary-Rooms-MapSpaceCollection@-'></a>
### TryGetPerimeter(outPerimeter) `method`

##### Summary

Finds a walkable area's perimiter in a given subregion.

##### Returns

`true` if a valid perimeter was found; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| outPerimeter | [ParquetClassLibrary.Rooms.MapSpaceCollection@](#T-ParquetClassLibrary-Rooms-MapSpaceCollection@ 'ParquetClassLibrary.Rooms.MapSpaceCollection@') | The walkable area's valid perimiter, if it exists. |

<a name='M-ParquetClassLibrary-Rooms-MapSpaceCollection-op_Implicit-ParquetClassLibrary-Rooms-MapSpaceCollection-~System-Collections-Generic-HashSet{ParquetClassLibrary-Rooms-MapSpace}'></a>
### op_Implicit(inSpaces) `method`

##### Summary

Converts the given [MapSpaceCollection](#T-ParquetClassLibrary-Rooms-MapSpaceCollection 'ParquetClassLibrary.Rooms.MapSpaceCollection') to a plain [HashSet\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.HashSet`1 'System.Collections.Generic.HashSet`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inSpaces | [ParquetClassLibrary.Rooms.MapSpaceCollection)~System.Collections.Generic.HashSet{ParquetClassLibrary.Rooms.MapSpace}](#T-ParquetClassLibrary-Rooms-MapSpaceCollection-~System-Collections-Generic-HashSet{ParquetClassLibrary-Rooms-MapSpace} 'ParquetClassLibrary.Rooms.MapSpaceCollection)~System.Collections.Generic.HashSet{ParquetClassLibrary.Rooms.MapSpace}') | The collection to convert. |

<a name='M-ParquetClassLibrary-Rooms-MapSpaceCollection-op_Implicit-System-Collections-Generic-HashSet{ParquetClassLibrary-Rooms-MapSpace}-~ParquetClassLibrary-Rooms-MapSpaceCollection'></a>
### op_Implicit(inSpaces) `method`

##### Summary

Converts the given [HashSet\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.HashSet`1 'System.Collections.Generic.HashSet`1') to a full [MapSpaceCollection](#T-ParquetClassLibrary-Rooms-MapSpaceCollection 'ParquetClassLibrary.Rooms.MapSpaceCollection').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inSpaces | [System.Collections.Generic.HashSet{ParquetClassLibrary.Rooms.MapSpace})~ParquetClassLibrary.Rooms.MapSpaceCollection](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.HashSet 'System.Collections.Generic.HashSet{ParquetClassLibrary.Rooms.MapSpace})~ParquetClassLibrary.Rooms.MapSpaceCollection') | The collection to convert. |

<a name='T-ParquetClassLibrary-Model'></a>
## Model `type`

##### Namespace

ParquetClassLibrary

##### Summary

Models a unique, identifiable type of game object.

##### Remarks

All [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model')s are identified with a [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID'),
and are considered equal if and only if their respective ModelIDs are equal.



Model is intended to represent the parts of a game object that do not change
from one instance to another.  In this sense, it can be thought of as
analogous to a C# class.



Individual game objects are represented and referenced as instances of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')
within [ModelCollection\`1](#T-ParquetClassLibrary-ModelCollection`1 'ParquetClassLibrary.ModelCollection`1')s in other classes.  Like a class instance,
the Model for a given ModelID is looked up from a singular definition,
in this case via [Get\`\`1](#M-ParquetClassLibrary-ModelCollection`1-Get``1-ParquetClassLibrary-ModelID- 'ParquetClassLibrary.ModelCollection`1.Get``1(ParquetClassLibrary.ModelID)').



Collections of the definitions used during play are contained in [All](#T-ParquetClassLibrary-All 'ParquetClassLibrary.All').



If individual game objects must have mutable state then a separate partner class,
such as [ParquetStatus](#T-ParquetClassLibrary-Parquets-ParquetStatus 'ParquetClassLibrary.Parquets.ParquetStatus') or [BeingStatus](#T-ParquetClassLibrary-Beings-BeingStatus 'ParquetClassLibrary.Beings.BeingStatus'),
represents that state.



Model could be considered the fundamental class of the entire Parquet library.

##### See Also

- [ParquetClassLibrary.ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag')

<a name='M-ParquetClassLibrary-Model-#ctor-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},ParquetClassLibrary-ModelID,System-String,System-String,System-String-'></a>
### #ctor(inBounds,inID,inName,inDescription,inComment) `constructor`

##### Summary

Initializes a new instance of concrete implementations of the [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inBounds | [ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}](#T-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID} 'ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}') | The bounds within which the derived type's [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') is defined. |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | Unique identifier for the [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model').  Cannot be null. |
| inName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly name of the [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model').  Cannot be null or empty. |
| inDescription | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly description of the [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model'). |
| inComment | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Comment of, on, or by the [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model'). |

<a name='P-ParquetClassLibrary-Model-Comment'></a>
### Comment `property`

##### Summary

Optional comment.

##### Remarks

Could be used for designer notes or to implement an in-game dialogue with or on the [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model').

<a name='P-ParquetClassLibrary-Model-Description'></a>
### Description `property`

##### Summary

Player-facing description.

<a name='P-ParquetClassLibrary-Model-ID'></a>
### ID `property`

##### Summary

Game-wide unique identifier.

<a name='P-ParquetClassLibrary-Model-Name'></a>
### Name `property`

##### Summary

Player-facing name.

<a name='P-ParquetClassLibrary-Model-ParquetClassLibrary#IModelEdit#Comment'></a>
### ParquetClassLibrary#IModelEdit#Comment `property`

##### Summary

Optional comment.

<a name='P-ParquetClassLibrary-Model-ParquetClassLibrary#IModelEdit#Description'></a>
### ParquetClassLibrary#IModelEdit#Description `property`

##### Summary

Player-facing description.

<a name='P-ParquetClassLibrary-Model-ParquetClassLibrary#IModelEdit#Name'></a>
### ParquetClassLibrary#IModelEdit#Name `property`

##### Summary

Player-facing name.

<a name='M-ParquetClassLibrary-Model-Equals-ParquetClassLibrary-Model-'></a>
### Equals(inModel) `method`

##### Summary

Determines whether the specified [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') is equal to the current [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model').

##### Returns

`true` if they are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inModel | [ParquetClassLibrary.Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') | The [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') to compare with the current. |

<a name='M-ParquetClassLibrary-Model-Equals-System-Object-'></a>
### Equals(obj) `method`

##### Summary

Determines whether the specified [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') is equal to the current [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model').

##### Returns

`true` if they are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') to compare with the current [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model'). |

<a name='M-ParquetClassLibrary-Model-GetAllTags'></a>
### GetAllTags() `method`

##### Summary

Returns a collection of all [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag')s the [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') has applied to it. Classes inheriting from [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') that include [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag') should override accordingly.

##### Returns

List of all [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag')s.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Model-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Serves as a hash function for a [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model').

##### Returns

A hash code for this instance that is suitable for use in hashing algorithms and data structures.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Model-ToString'></a>
### ToString() `method`

##### Summary

Returns a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents the current [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model').

##### Returns

The representation.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Model-op_Equality-ParquetClassLibrary-Model,ParquetClassLibrary-Model-'></a>
### op_Equality(inModel1,inModel2) `method`

##### Summary

Determines whether a specified instance of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') is equal to another specified instance of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model').

##### Returns

`true` if they are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inModel1 | [ParquetClassLibrary.Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') | The first [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') to compare. |
| inModel2 | [ParquetClassLibrary.Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') | The second [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') to compare. |

<a name='M-ParquetClassLibrary-Model-op_Inequality-ParquetClassLibrary-Model,ParquetClassLibrary-Model-'></a>
### op_Inequality(inModel1,inModel2) `method`

##### Summary

Determines whether a specified instance of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') is not equal to another specified instance of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model').

##### Returns

`true` if they are NOT equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inModel1 | [ParquetClassLibrary.Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') | The first [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') to compare. |
| inModel2 | [ParquetClassLibrary.Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') | The second [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') to compare. |

<a name='T-ParquetClassLibrary-ModelCollection'></a>
## ModelCollection `type`

##### Namespace

ParquetClassLibrary

##### Summary

Stores a [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') collection.
 Provides bounds-checking and type-checking against [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model').

##### Remarks

All [ModelCollection](#T-ParquetClassLibrary-ModelCollection 'ParquetClassLibrary.ModelCollection')s implicitly contain [None](#F-ParquetClassLibrary-ModelID-None 'ParquetClassLibrary.ModelID.None').
 
 This version supports collections that do not rely heavily on
 multiple incompatible subclasses of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model').

 For more details, see remarks on [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model').

<a name='M-ParquetClassLibrary-ModelCollection-#ctor-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Model}-'></a>
### #ctor(inBounds,inModels) `constructor`

##### Summary

Initializes a new instance of the [ModelCollection](#T-ParquetClassLibrary-ModelCollection 'ParquetClassLibrary.ModelCollection') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inBounds | [ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}](#T-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID} 'ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}') | The bounds within which the collected [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s are defined. |
| inModels | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Model}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Model}') | The [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model')s to collect.  Cannot be null. |

<a name='M-ParquetClassLibrary-ModelCollection-#ctor-System-Collections-Generic-IEnumerable{ParquetClassLibrary-Range{ParquetClassLibrary-ModelID}},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Model}-'></a>
### #ctor(inBounds,inModels) `constructor`

##### Summary

Initializes a new instance of the [ModelCollection](#T-ParquetClassLibrary-ModelCollection 'ParquetClassLibrary.ModelCollection') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inBounds | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}}') | The bounds within which the collected [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s are defined. |
| inModels | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Model}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Model}') | The [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model')s to collect.  Cannot be null. |

<a name='F-ParquetClassLibrary-ModelCollection-Default'></a>
### Default `constants`

##### Summary

A value to use in place of uninitialized [ModelCollection\`1](#T-ParquetClassLibrary-ModelCollection`1 'ParquetClassLibrary.ModelCollection`1')s.

<a name='M-ParquetClassLibrary-ModelCollection-Get-ParquetClassLibrary-ModelID-'></a>
### Get(inID) `method`

##### Summary

Returns the specified [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model').

##### Returns

The specified [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | A valid, defined [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') identifier. |

<a name='M-ParquetClassLibrary-ModelCollection-GetFilePath``1'></a>
### GetFilePath\`\`1() `method`

##### Summary

Given a type, returns the filename and path associated with that type's designer file.

##### Returns

A full path to the associated designer file.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TModel | The type whose path and filename are sought. |

<a name='T-ParquetClassLibrary-ModelCollection`1'></a>
## ModelCollection\`1 `type`

##### Namespace

ParquetClassLibrary

##### Summary

Collects a group of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model')s.
Provides bounds-checking and type-checking against `TModel`.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TModel | The type collected, typically a decendent of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model'). |

##### Remarks

All [ModelCollection\`1](#T-ParquetClassLibrary-ModelCollection`1 'ParquetClassLibrary.ModelCollection`1')s implicitly contain [None](#F-ParquetClassLibrary-ModelID-None 'ParquetClassLibrary.ModelID.None').



This generic version is intended to support [Parquets](#P-ParquetClassLibrary-All-Parquets 'ParquetClassLibrary.All.Parquets') allowing
the collection to store all parquet types but return only the requested subtype.



For more details, see remarks on [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model').

##### See Also

- [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')
- [ParquetClassLibrary.ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag')
- [ParquetClassLibrary.All](#T-ParquetClassLibrary-All 'ParquetClassLibrary.All')

<a name='M-ParquetClassLibrary-ModelCollection`1-#ctor-System-Collections-Generic-IEnumerable{ParquetClassLibrary-Range{ParquetClassLibrary-ModelID}},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Model}-'></a>
### #ctor(inBounds,inModels) `constructor`

##### Summary

Initializes a new instance of the [ModelCollection\`1](#T-ParquetClassLibrary-ModelCollection`1 'ParquetClassLibrary.ModelCollection`1') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inBounds | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}}') | The bounds within which the collected [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s are defined. |
| inModels | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Model}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Model}') | The [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model')s to collect.  Cannot be null. |

<a name='M-ParquetClassLibrary-ModelCollection`1-#ctor-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Model}-'></a>
### #ctor(inBounds,inModels) `constructor`

##### Summary

Initializes a new instance of the [ModelCollection\`1](#T-ParquetClassLibrary-ModelCollection`1 'ParquetClassLibrary.ModelCollection`1') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inBounds | [ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}](#T-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID} 'ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}') | The bounds within which the collected [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s are defined. |
| inModels | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Model}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Model}') | The [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model')s to collect.  Cannot be null. |

<a name='F-ParquetClassLibrary-ModelCollection`1-Default'></a>
### Default `constants`

##### Summary

A value to use in place of uninitialized [ModelCollection\`1](#T-ParquetClassLibrary-ModelCollection`1 'ParquetClassLibrary.ModelCollection`1')s.

<a name='P-ParquetClassLibrary-ModelCollection`1-Bounds'></a>
### Bounds `property`

##### Summary

The bounds within which all collected [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model')s must be defined.

<a name='P-ParquetClassLibrary-ModelCollection`1-ConverterFactory'></a>
### ConverterFactory `property`

##### Summary

Allows the converter to construct itself statically.

<a name='P-ParquetClassLibrary-ModelCollection`1-Count'></a>
### Count `property`

##### Summary

The number of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model')s in the [ModelCollection\`1](#T-ParquetClassLibrary-ModelCollection`1 'ParquetClassLibrary.ModelCollection`1').

<a name='P-ParquetClassLibrary-ModelCollection`1-Models'></a>
### Models `property`

##### Summary

The internal collection mechanism.

<a name='M-ParquetClassLibrary-ModelCollection`1-AssignMissingIDs``1-System-Collections-Generic-List{``0},System-Text-StringBuilder-'></a>
### AssignMissingIDs\`\`1(inModelsWithOldIDs,inRecordsNeedingIDs) `method`

##### Summary

Assigns [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s to the given [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model')s and adds them to the given [List\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List`1 'System.Collections.Generic.List`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inModelsWithOldIDs | [System.Collections.Generic.List{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{``0}') | Models that already had IDs. |
| inRecordsNeedingIDs | [System.Text.StringBuilder](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.StringBuilder 'System.Text.StringBuilder') | Records of models that have not yet had their IDs assigned. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TModelInner | The type to assign IDs to. |

<a name='M-ParquetClassLibrary-ModelCollection`1-ConfigureCSVReader-System-IO-TextReader-'></a>
### ConfigureCSVReader(inReader) `method`

##### Summary

Sets up a [TextReader](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextReader 'System.IO.TextReader') to work with Parquet's CSV files.

##### Returns

A new, configured reader that will need to be disposed.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inReader | [System.IO.TextReader](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextReader 'System.IO.TextReader') | The reader to configure. |

<a name='M-ParquetClassLibrary-ModelCollection`1-Contains-ParquetClassLibrary-Model-'></a>
### Contains(inModel) `method`

##### Summary

Determines whether the [ModelCollection\`1](#T-ParquetClassLibrary-ModelCollection`1 'ParquetClassLibrary.ModelCollection`1') contains the specified [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model').

##### Returns

`true` if the [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') was found; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inModel | [ParquetClassLibrary.Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') | The [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') to find. |

<a name='M-ParquetClassLibrary-ModelCollection`1-Contains-ParquetClassLibrary-ModelID-'></a>
### Contains(inID) `method`

##### Summary

Determines whether the [ModelCollection\`1](#T-ParquetClassLibrary-ModelCollection`1 'ParquetClassLibrary.ModelCollection`1') contains a [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model')
with the specified [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID').

##### Returns

`true` if the [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') was found; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') to find. |

<a name='M-ParquetClassLibrary-ModelCollection`1-GetEnumerator'></a>
### GetEnumerator() `method`

##### Summary

Retrieves an enumerator for the [ModelCollection\`1](#T-ParquetClassLibrary-ModelCollection`1 'ParquetClassLibrary.ModelCollection`1').

##### Returns

An enumerator that iterates through the collection.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-ModelCollection`1-GetRecordsForType``1-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID}-'></a>
### GetRecordsForType\`\`1(inBounds) `method`

##### Summary

Reads all records of the given type from the appropriate file.

##### Returns

The instances read.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inBounds | [ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}](#T-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID} 'ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}') | The range in which the records are defined. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TModelInner | The type to deserialize. |

<a name='M-ParquetClassLibrary-ModelCollection`1-GetRecordsForType``1-System-Collections-Generic-IEnumerable{ParquetClassLibrary-Range{ParquetClassLibrary-ModelID}}-'></a>
### GetRecordsForType\`\`1(inBounds) `method`

##### Summary

Reads all records of the given type from the appropriate file.

##### Returns

The instances read.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inBounds | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}}') | The range in which the records are defined. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TModelInner | The type to deserialize. |

<a name='M-ParquetClassLibrary-ModelCollection`1-Get``1-ParquetClassLibrary-ModelID-'></a>
### Get\`\`1(inID) `method`

##### Summary

Returns the specified `TModel`.

##### Returns

The specified `TTarget` model.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | A valid, defined `TModel` identifier. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TTarget | The type of `TModel` sought.  Must correspond to the given `inID`. |

<a name='M-ParquetClassLibrary-ModelCollection`1-HandleUnassignedIDs``1-System-String[],System-Collections-Generic-List{``0}-'></a>
### HandleUnassignedIDs\`\`1(inColumnHeaders,inModels) `method`

##### Summary

Assigns [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s to any models that need them.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inColumnHeaders | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | Text indicating which value corresponds to which model member. |
| inModels | [System.Collections.Generic.List{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{``0}') | Models created by the most recent call to CsvReader.GetRecords. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TModelInner | The type to assign IDs to. |

##### Remarks

Optionally, a subset of deserialized records may not have [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s.
This detects such records and assigns an ID to all models created from them.

<a name='M-ParquetClassLibrary-ModelCollection`1-PutRecordsForType``1'></a>
### PutRecordsForType\`\`1() `method`

##### Summary

Writes all of the given type to records to the appropriate file.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TModelInner | The type to serialize. |

<a name='M-ParquetClassLibrary-ModelCollection`1-ReconstructHeader-System-String[],System-Text-StringBuilder-'></a>
### ReconstructHeader(inColumnHeaders,inRecordsWithNewIDs) `method`

##### Summary

Reconstructs the header that would be used by [CsvReader](#T-CsvHelper-CsvReader 'CsvHelper.CsvReader') to deserialize models from the given records.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inColumnHeaders | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | Individual header elements. |
| inRecordsWithNewIDs | [System.Text.StringBuilder](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.StringBuilder 'System.Text.StringBuilder') | Data laid out in CSV-fashion in need of a header. |

<a name='M-ParquetClassLibrary-ModelCollection`1-RemoveHeaderPrefix-System-String,System-Int32-'></a>
### RemoveHeaderPrefix(inHeaderText,inHeaderIndex) `method`

##### Summary

Removes the "in" element used in the Parquet C# style from appearing in CSV file headers.

##### Returns

The modified text.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inHeaderText | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The text to modify. |
| inHeaderIndex | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Ignored. |

<a name='M-ParquetClassLibrary-ModelCollection`1-System#Collections#Generic#IEnumerable{TModel}#GetEnumerator'></a>
### System#Collections#Generic#IEnumerable{TModel}#GetEnumerator() `method`

##### Summary

Exposes an [IEnumerator\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerator`1 'System.Collections.Generic.IEnumerator`1') to support simple iteration.

##### Returns

An enumerator.

##### Parameters

This method has no parameters.

##### Remarks

Used by LINQ. No accessibility modifiers are valid in this context.

<a name='M-ParquetClassLibrary-ModelCollection`1-System#Collections#IEnumerable#GetEnumerator'></a>
### System#Collections#IEnumerable#GetEnumerator() `method`

##### Summary

Exposes an [IEnumerator](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.IEnumerator 'System.Collections.IEnumerator') to support simple iteration.

##### Returns

An enumerator.

##### Parameters

This method has no parameters.

##### Remarks

Used by LINQ. No accessibility modifiers are valid in this context.

<a name='M-ParquetClassLibrary-ModelCollection`1-ToString'></a>
### ToString() `method`

##### Summary

Returns a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents the current [ModelCollection\`1](#T-ParquetClassLibrary-ModelCollection`1 'ParquetClassLibrary.ModelCollection`1').

##### Returns

The representation.

##### Parameters

This method has no parameters.

<a name='T-ParquetClassLibrary-ModelID'></a>
## ModelID `type`

##### Namespace

ParquetClassLibrary

##### Summary

Uniquely identifies every [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model').

##### Remarks

[ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s provide a means for the library
to track and rapidly update large numbers of equivalent
game objects.



For example, multiple identical parquet IDs may be assigned
to [MapChunk](#T-ParquetClassLibrary-Maps-MapChunk 'ParquetClassLibrary.Maps.MapChunk')s or [MapRegion](#T-ParquetClassLibrary-Maps-MapRegion 'ParquetClassLibrary.Maps.MapRegion')s,
and multiple duplicate [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel') IDs may exist in
accross various [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') inventories.



Using ModelID the library looks up the game object definitions
for each of these when other game elements interact with them,
without filling RAM with numerous duplicate Models.



There are multiple [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') subtypes
([ParquetModel](#T-ParquetClassLibrary-Parquets-ParquetModel 'ParquetClassLibrary.Parquets.ParquetModel'), [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel'),
etc.), and each of these subtypes has multiple definitions.
The definitions are purely data-driven, read in from CSV or
other files, and not type-checked by the compiler.



Although the compiler does not provide type-checking for IDs,
the library defines valid ranges for all ID subtypes ([All](#T-ParquetClassLibrary-All 'ParquetClassLibrary.All'))
and these are checked by library code.



A note on implementation as of January 1st, 2020.



ModelID is implemented as a mutable struct because, under the hood,
it is simply an Int32.  ModelID is designed to be implicitly
interoperable with and implcity castable to and from integer types.



Since the entire point of this ID system is to provide a way for the
library to rapidly track changes in large arrays of identical game
objects, it must be a light-weight mutable value type.  This is
analagous to the use case for C# 7 tuples, which are also light-weight
mutable value types.



If the implementation were ever to become more complex, ModelID
would need to become a class.

<a name='F-ParquetClassLibrary-ModelID-None'></a>
### None `constants`

##### Summary

Indicates the lack of a [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model').

<a name='F-ParquetClassLibrary-ModelID-RecordsWithMissingIDs'></a>
### RecordsWithMissingIDs `constants`

##### Summary

A collection of records that need to have [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s assigned to them before deserialization.

<a name='F-ParquetClassLibrary-ModelID-id'></a>
### id `constants`

##### Summary

Backing type for the [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID').

##### Remarks

This is implemented as an [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') rather than a [Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid')
to support human-readable design documents and [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1') validation.

<a name='P-ParquetClassLibrary-ModelID-ConverterFactory'></a>
### ConverterFactory `property`

##### Summary

Allows the converter to construct itself statically.

<a name='M-ParquetClassLibrary-ModelID-CompareTo-ParquetClassLibrary-ModelID-'></a>
### CompareTo(inIDentifier) `method`

##### Summary

Enables [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') to be compared to one another.

##### Returns

A value indicating the relative ordering of the [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s being compared.
The return value has these meanings:
    Less than zero indicates that the current instance precedes the given [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') in the sort order.
    Zero indicates that the current instance occurs in the same position in the sort order as the given [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID').
    Greater than zero indicates that the current instance follows the given [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') in the sort order.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inIDentifier | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | Any [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID'). |

<a name='M-ParquetClassLibrary-ModelID-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData-'></a>
### ConvertFromString(inText,inRow,inMemberMapData) `method`

##### Summary

Converts the given record column to [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID').

##### Returns

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') created from the record column.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inText | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The record column to convert to an object. |
| inRow | [CsvHelper.IReaderRow](#T-CsvHelper-IReaderRow 'CsvHelper.IReaderRow') | The [IReaderRow](#T-CsvHelper-IReaderRow 'CsvHelper.IReaderRow') for the current record. |
| inMemberMapData | [CsvHelper.Configuration.MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') | The [MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') for the member being created. |

<a name='M-ParquetClassLibrary-ModelID-ConvertToString-System-Object,CsvHelper-IWriterRow,CsvHelper-Configuration-MemberMapData-'></a>
### ConvertToString(inValue,inRow,inMemberMapData) `method`

##### Summary

Converts the given [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') to a record column.

##### Returns

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') as a CSV record.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inValue | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The instance to convert. |
| inRow | [CsvHelper.IWriterRow](#T-CsvHelper-IWriterRow 'CsvHelper.IWriterRow') | The [IReaderRow](#T-CsvHelper-IReaderRow 'CsvHelper.IReaderRow') for the current record. |
| inMemberMapData | [CsvHelper.Configuration.MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') | The [MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') for the member being serialized. |

<a name='M-ParquetClassLibrary-ModelID-Equals-ParquetClassLibrary-ModelID-'></a>
### Equals(inIDentifier) `method`

##### Summary

Determines whether the specified [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') is equal to the current [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID').

##### Returns

`true` if they are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inIDentifier | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') to compare with the current. |

<a name='M-ParquetClassLibrary-ModelID-Equals-System-Object-'></a>
### Equals(obj) `method`

##### Summary

Determines whether the specified [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') is equal to the current [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID').

##### Returns

`true` if they are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') to compare with the current [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID'). |

<a name='M-ParquetClassLibrary-ModelID-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Serves as a hash function for a [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID').

##### Returns

A hash code for this instance that is suitable for use in hashing algorithms and data structures.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-ModelID-IsValidForRange-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID}-'></a>
### IsValidForRange(inRange) `method`

##### Summary

Validates the current [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') over a [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1').
1. It is [None](#F-ParquetClassLibrary-ModelID-None 'ParquetClassLibrary.ModelID.None').
2. It is defined within the given [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1'), inclusive, regardless of sign.

##### Returns

`true`, if the [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') is valid given the [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1'), `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inRange | [ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}](#T-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID} 'ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}') | The [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1') within which the absolute value of the [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') must fall. |

<a name='M-ParquetClassLibrary-ModelID-IsValidForRange-System-Collections-Generic-IEnumerable{ParquetClassLibrary-Range{ParquetClassLibrary-ModelID}}-'></a>
### IsValidForRange(inRanges) `method`

##### Summary

Validates the current [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') over a [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1').
A [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') is valid iff:
1. It is [None](#F-ParquetClassLibrary-ModelID-None 'ParquetClassLibrary.ModelID.None').
2. It is defined within any of the [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1')a in the given [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1'), inclusive, regardless of sign.

##### Returns

`true`, if the [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') is valid given the [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1'), `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inRanges | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}}') | The [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1') within which the [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') must fall. |

<a name='M-ParquetClassLibrary-ModelID-RegisterMissingID-System-String-'></a>
### RegisterMissingID(inRawRecord) `method`

##### Summary

Registers the given record as a [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') in need of a [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inRawRecord | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The record to regiseter. |

##### Remarks

Used during deserialization to allow the library to generate appropriate IDs.

<a name='M-ParquetClassLibrary-ModelID-ToString'></a>
### ToString() `method`

##### Summary

Returns a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents the current [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID').

##### Returns

The representation.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-ModelID-op_Equality-ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID-'></a>
### op_Equality(inIDentifier1,inIDentifier2) `method`

##### Summary

Determines whether a specified instance of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') is equal to another specified instance of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID').

##### Returns

`true` if they are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inIDentifier1 | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The first [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') to compare. |
| inIDentifier2 | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The second [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') to compare. |

<a name='M-ParquetClassLibrary-ModelID-op_GreaterThan-ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID-'></a>
### op_GreaterThan(inIDentifier1,inIDentifier2) `method`

##### Summary

Determines whether a specified instance of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') strictly follows another specified instance of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID').

##### Returns

`true` if the first identifier strictly followa the second; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inIDentifier1 | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The first [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') to compare. |
| inIDentifier2 | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The second [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') to compare. |

<a name='M-ParquetClassLibrary-ModelID-op_GreaterThanOrEqual-ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID-'></a>
### op_GreaterThanOrEqual(inIDentifier1,inIDentifier2) `method`

##### Summary

Determines whether a specified instance of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') follows or is ordinally equivalent with
another specified instance of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID').

##### Returns

`true` if the first identifier follows or is ordinally equivalent with the second; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inIDentifier1 | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The first [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') to compare. |
| inIDentifier2 | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The second [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') to compare. |

<a name='M-ParquetClassLibrary-ModelID-op_Implicit-System-Int32-~ParquetClassLibrary-ModelID'></a>
### op_Implicit(inValue) `method`

##### Summary

Enables [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s to be treated as their backing type.

##### Returns

The given identifier value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inValue | [System.Int32)~ParquetClassLibrary.ModelID](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32)~ParquetClassLibrary.ModelID 'System.Int32)~ParquetClassLibrary.ModelID') | Any valid identifier value. |

<a name='M-ParquetClassLibrary-ModelID-op_Implicit-ParquetClassLibrary-ModelID-~System-Int32'></a>
### op_Implicit(inIDentifier) `method`

##### Summary

Enables [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') to be treated as their backing type.

##### Returns

The identifier's value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inIDentifier | [ParquetClassLibrary.ModelID)~System.Int32](#T-ParquetClassLibrary-ModelID-~System-Int32 'ParquetClassLibrary.ModelID)~System.Int32') | Any identifier. |

<a name='M-ParquetClassLibrary-ModelID-op_Inequality-ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID-'></a>
### op_Inequality(inIDentifier1,inIDentifier2) `method`

##### Summary

Determines whether a specified instance of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') is not equal to another specified instance of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID').

##### Returns

`true` if they are NOT equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inIDentifier1 | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The first [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') to compare. |
| inIDentifier2 | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The second [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') to compare. |

<a name='M-ParquetClassLibrary-ModelID-op_LessThan-ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID-'></a>
### op_LessThan(inIDentifier1,inIDentifier2) `method`

##### Summary

Determines whether a specified instance of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') strictly precedes another specified instance of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID').

##### Returns

`true` if the first identifier strictly precedes the second; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inIDentifier1 | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The first [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') to compare. |
| inIDentifier2 | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The second [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') to compare. |

<a name='M-ParquetClassLibrary-ModelID-op_LessThanOrEqual-ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID-'></a>
### op_LessThanOrEqual(inIDentifier1,inIDentifier2) `method`

##### Summary

Determines whether a specified instance of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') precedes or is ordinally equivalent with
another specified instance of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID').

##### Returns

`true` if the first identifier precedes or is ordinally equivalent with the second; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inIDentifier1 | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The first [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') to compare. |
| inIDentifier2 | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The second [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') to compare. |

<a name='T-ParquetClassLibrary-ModelTag'></a>
## ModelTag `type`

##### Namespace

ParquetClassLibrary

##### Summary

Identifies functional characteristics of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model')s,
such as their role in [CraftingRecipe](#T-ParquetClassLibrary-Crafts-CraftingRecipe 'ParquetClassLibrary.Crafts.CraftingRecipe')s or
[BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel')s.

##### Remarks

The intent is that definitional narrative and mechanical features
of each game [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') be taggable.



This means that more than one [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag') can coexist
on a specific [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') within the same model
category (parquets, beings, etc.).



This allows for flexible definition of Models such that a loose
category of models may answer a particular functional need; e.g.,
"any parquet that has the Volcanic tag" or "any item that is a Key".

##### See Also

- [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')
- [ParquetClassLibrary.All](#T-ParquetClassLibrary-All 'ParquetClassLibrary.All')

<a name='F-ParquetClassLibrary-ModelTag-None'></a>
### None `constants`

##### Summary

Indicates the lack of any [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag')s.

<a name='F-ParquetClassLibrary-ModelTag-tagContent'></a>
### tagContent `constants`

##### Summary

Backing type for the [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag').

<a name='P-ParquetClassLibrary-ModelTag-ConverterFactory'></a>
### ConverterFactory `property`

##### Summary

Allows the converter to construct itself statically.

<a name='M-ParquetClassLibrary-ModelTag-CompareTo-ParquetClassLibrary-ModelTag-'></a>
### CompareTo(inTag) `method`

##### Summary

Enables [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag')s to be compared one another.

##### Returns

A value indicating the relative ordering of the [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag')s being compared.
The return value has these meanings:
    Less than zero indicates that the current instance precedes the given [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag') in the sort order.
    Zero indicates that the current instance occurs in the same position in the sort order as the given [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag').
    Greater than zero indicates that the current instance follows the given [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag') in the sort order.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inTag | [ParquetClassLibrary.ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag') | Any valid [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag'). |

<a name='M-ParquetClassLibrary-ModelTag-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData-'></a>
### ConvertFromString(inText,inRow,inMemberMapData) `method`

##### Summary

Converts the given [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') to a [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag').

##### Returns

The [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag') created from the [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inText | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') to convert to an object. |
| inRow | [CsvHelper.IReaderRow](#T-CsvHelper-IReaderRow 'CsvHelper.IReaderRow') | The [IReaderRow](#T-CsvHelper-IReaderRow 'CsvHelper.IReaderRow') for the current record. |
| inMemberMapData | [CsvHelper.Configuration.MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') | The [MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') for the member being created. |

<a name='M-ParquetClassLibrary-ModelTag-ConvertToString-System-Object,CsvHelper-IWriterRow,CsvHelper-Configuration-MemberMapData-'></a>
### ConvertToString(inValue,inRow,inMemberMapData) `method`

##### Summary

Converts the given [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag') to a record column.

##### Returns

The [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag') as a CSV record.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inValue | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The instance to convert. |
| inRow | [CsvHelper.IWriterRow](#T-CsvHelper-IWriterRow 'CsvHelper.IWriterRow') | The [IReaderRow](#T-CsvHelper-IReaderRow 'CsvHelper.IReaderRow') for the current record. |
| inMemberMapData | [CsvHelper.Configuration.MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') | The [MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') for the member being serialized. |

<a name='M-ParquetClassLibrary-ModelTag-ToString'></a>
### ToString() `method`

##### Summary

Returns a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents the current [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag').

##### Returns

The representation.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-ModelTag-op_Implicit-System-String-~ParquetClassLibrary-ModelTag'></a>
### op_Implicit(inValue) `method`

##### Summary

Enables [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag')s to be treated as their backing type.

##### Returns

The given value as a tag.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inValue | [System.String)~ParquetClassLibrary.ModelTag](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String)~ParquetClassLibrary.ModelTag 'System.String)~ParquetClassLibrary.ModelTag') | Any valid tag value.  Invalid values will be sanitized. |

<a name='M-ParquetClassLibrary-ModelTag-op_Implicit-ParquetClassLibrary-ModelTag-~System-String'></a>
### op_Implicit(inTag) `method`

##### Summary

Enables [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag')s to be treated as their backing type.

##### Returns

The tag's value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inTag | [ParquetClassLibrary.ModelTag)~System.String](#T-ParquetClassLibrary-ModelTag-~System-String 'ParquetClassLibrary.ModelTag)~System.String') | Any tag. |

<a name='T-ParquetClassLibrary-Items-ModificationTool'></a>
## ModificationTool `type`

##### Namespace

ParquetClassLibrary.Items

##### Summary

IDs for [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel') tools that Characters can use to modify [BlockModel](#T-ParquetClassLibrary-Parquets-BlockModel 'ParquetClassLibrary.Parquets.BlockModel')s and [FloorModel](#T-ParquetClassLibrary-Parquets-FloorModel 'ParquetClassLibrary.Parquets.FloorModel')s.

##### Remarks

The tool subtypes are hard-coded, but individual [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel')s themselves are configured in CSV files.

<a name='F-ParquetClassLibrary-Items-ModificationTool-Hammer'></a>
### Hammer `constants`

##### Summary

This parquet can be modified with a hammer-like tool.

<a name='F-ParquetClassLibrary-Items-ModificationTool-None'></a>
### None `constants`

##### Summary

This parquet cannot be modified.

<a name='F-ParquetClassLibrary-Items-ModificationTool-Shovel'></a>
### Shovel `constants`

##### Summary

This parquet can be modified with a shovel-like tool.

<a name='T-ParquetClassLibrary-Parquets-ParquetModel'></a>
## ParquetModel `type`

##### Namespace

ParquetClassLibrary.Parquets

##### Summary

Models a sandbox parquet.

<a name='M-ParquetClassLibrary-Parquets-ParquetModel-#ctor-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},ParquetClassLibrary-ModelID,System-String,System-String,System-String,ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelTag,ParquetClassLibrary-ModelTag-'></a>
### #ctor(inBounds,inID,inName,inDescription,inComment,inItemID,inAddsToBiome,inAddsToRoom) `constructor`

##### Summary

Used by children of the [ParquetModel](#T-ParquetClassLibrary-Parquets-ParquetModel 'ParquetClassLibrary.Parquets.ParquetModel') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inBounds | [ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}](#T-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID} 'ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}') | The bounds within which the derived parquet type's ModelID is defined. |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | Unique identifier for the parquet.  Cannot be null. |
| inName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly name of the parquet.  Cannot be null or empty. |
| inDescription | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly description of the parquet. |
| inComment | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Comment of, on, or by the parquet. |
| inItemID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel') awarded to the player when a character gathers or collects this parquet. |
| inAddsToBiome | [ParquetClassLibrary.ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag') | Describes which, if any, [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel')(s) this parquet helps form. |
| inAddsToRoom | [ParquetClassLibrary.ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag') | Describes which, if any, [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe')(s) this parquet helps form. |

<a name='P-ParquetClassLibrary-Parquets-ParquetModel-AddsToBiome'></a>
### AddsToBiome `property`

##### Summary

Describes the [BiomeModel](#T-ParquetClassLibrary-Biomes-BiomeModel 'ParquetClassLibrary.Biomes.BiomeModel')(s) that this parquet helps form.
Guaranteed to never be `null`.

<a name='P-ParquetClassLibrary-Parquets-ParquetModel-AddsToRoom'></a>
### AddsToRoom `property`

##### Summary

A property of the parquet that can, for example, be used by [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe')s.
Guaranteed to never be `null`.

##### Remarks

Allows the creation of classes of constructs, for example "wooden", "golden", "rustic", or "fancy" rooms.

<a name='P-ParquetClassLibrary-Parquets-ParquetModel-ItemID'></a>
### ItemID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel') awarded to the player when a character gathers or collects this parquet.

<a name='M-ParquetClassLibrary-Parquets-ParquetModel-GetAllTags'></a>
### GetAllTags() `method`

##### Summary

Returns a collection of all [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag')s the [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') has applied to it. Classes inheriting from [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') that include [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag') should override accordingly.

##### Returns

List of all [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag')s.

##### Parameters

This method has no parameters.

<a name='T-ParquetClassLibrary-Parquets-ParquetStack'></a>
## ParquetStack `type`

##### Namespace

ParquetClassLibrary.Parquets

##### Summary

Simple container for one of each overlapping layer of parquets.

<a name='M-ParquetClassLibrary-Parquets-ParquetStack-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new default instance of the [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') class.

##### Parameters

This constructor has no parameters.

##### Remarks

This is primarily useful for serialization as the default values are featureless.

<a name='M-ParquetClassLibrary-Parquets-ParquetStack-#ctor-ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID-'></a>
### #ctor(inFloor,inBlock,inFurnishing,inCollectible) `constructor`

##### Summary

Initializes a new instance of the [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inFloor | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The floor-layer parquet. |
| inBlock | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The The floor-layer parquet-layer parquet. |
| inFurnishing | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The furnishing-layer parquet. |
| inCollectible | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The collectible-layer parquet. |

<a name='P-ParquetClassLibrary-Parquets-ParquetStack-Block'></a>
### Block `property`

##### Summary

The block contained in this stack.

<a name='P-ParquetClassLibrary-Parquets-ParquetStack-Collectible'></a>
### Collectible `property`

##### Summary

The collectible contained in this stack.

<a name='P-ParquetClassLibrary-Parquets-ParquetStack-ConverterFactory'></a>
### ConverterFactory `property`

##### Summary

Allows the converter to construct itself statically.

<a name='P-ParquetClassLibrary-Parquets-ParquetStack-Count'></a>
### Count `property`

##### Summary

The number of parquets actually present in this stack.

<a name='P-ParquetClassLibrary-Parquets-ParquetStack-Empty'></a>
### Empty `property`

##### Summary

Cannonical null [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack'), representing an arbitrary empty stack.

<a name='P-ParquetClassLibrary-Parquets-ParquetStack-Floor'></a>
### Floor `property`

##### Summary

The floor contained in this stack.

<a name='P-ParquetClassLibrary-Parquets-ParquetStack-Furnishing'></a>
### Furnishing `property`

##### Summary

The furnishing contained in this stack.

<a name='P-ParquetClassLibrary-Parquets-ParquetStack-IsEmpty'></a>
### IsEmpty `property`

##### Summary

Indicates whether this [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') is empty.

<a name='P-ParquetClassLibrary-Parquets-ParquetStack-IsEnclosing'></a>
### IsEnclosing `property`

##### Summary

A [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') is Enclosing iff:
1, It has a [Block](#P-ParquetClassLibrary-Parquets-ParquetStack-Block 'ParquetClassLibrary.Parquets.ParquetStack.Block') that is not [IsLiquid](#P-ParquetClassLibrary-Parquets-BlockModel-IsLiquid 'ParquetClassLibrary.Parquets.BlockModel.IsLiquid'); or,
2, It has a [Furnishing](#P-ParquetClassLibrary-Parquets-ParquetStack-Furnishing 'ParquetClassLibrary.Parquets.ParquetStack.Furnishing') that is [IsEnclosing](#P-ParquetClassLibrary-Parquets-FurnishingModel-IsEnclosing 'ParquetClassLibrary.Parquets.FurnishingModel.IsEnclosing').

##### Returns

`true`, if this [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') is Enclosing, `false` otherwise.

<a name='P-ParquetClassLibrary-Parquets-ParquetStack-IsEntry'></a>
### IsEntry `property`

##### Summary

A [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') is Entry iff:
1, It is either Walkable or Enclosing but not both; and,
2, It has a [Furnishing](#P-ParquetClassLibrary-Parquets-ParquetStack-Furnishing 'ParquetClassLibrary.Parquets.ParquetStack.Furnishing') that is [IsEntry](#P-ParquetClassLibrary-Parquets-FurnishingModel-IsEntry 'ParquetClassLibrary.Parquets.FurnishingModel.IsEntry').

##### Returns

`true`, if this [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') is Entry, `false` otherwise.

<a name='P-ParquetClassLibrary-Parquets-ParquetStack-IsWalkable'></a>
### IsWalkable `property`

##### Summary

A [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') is considered walkable iff:
1, It has a [Floor](#P-ParquetClassLibrary-Parquets-ParquetStack-Floor 'ParquetClassLibrary.Parquets.ParquetStack.Floor');
2, It does not have a [Block](#P-ParquetClassLibrary-Parquets-ParquetStack-Block 'ParquetClassLibrary.Parquets.ParquetStack.Block');
3, It does not have a [Furnishing](#P-ParquetClassLibrary-Parquets-ParquetStack-Furnishing 'ParquetClassLibrary.Parquets.ParquetStack.Furnishing') that [IsEnclosing](#P-ParquetClassLibrary-Parquets-FurnishingModel-IsEnclosing 'ParquetClassLibrary.Parquets.FurnishingModel.IsEnclosing').

##### Returns

`true`, if this [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') is Walkable, `false` otherwise.

<a name='M-ParquetClassLibrary-Parquets-ParquetStack-Clone'></a>
### Clone() `method`

##### Summary

Creates a new instance with the same characteristics as the current instance.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Parquets-ParquetStack-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData-'></a>
### ConvertFromString(inText,inRow,inMemberMapData) `method`

##### Summary

Converts the given [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') to an [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') as deserialization.

##### Returns

The given instance deserialized.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inText | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The text to convert. |
| inRow | [CsvHelper.IReaderRow](#T-CsvHelper-IReaderRow 'CsvHelper.IReaderRow') | The current context and configuration. |
| inMemberMapData | [CsvHelper.Configuration.MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') | Mapping info for a member to a CSV field or property. |

<a name='M-ParquetClassLibrary-Parquets-ParquetStack-ConvertToString-System-Object,CsvHelper-IWriterRow,CsvHelper-Configuration-MemberMapData-'></a>
### ConvertToString(inValue,inRow,inMemberMapData) `method`

##### Summary

Converts the given [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') to a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') for serialization.

##### Returns

The given instance serialized.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inValue | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The instance to convert. |
| inRow | [CsvHelper.IWriterRow](#T-CsvHelper-IWriterRow 'CsvHelper.IWriterRow') | The current context and configuration. |
| inMemberMapData | [CsvHelper.Configuration.MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') | Mapping info for a member to a CSV field or property. |

<a name='M-ParquetClassLibrary-Parquets-ParquetStack-Equals-ParquetClassLibrary-Parquets-ParquetStack-'></a>
### Equals(inStack) `method`

##### Summary

Determines whether the specified [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') is equal to the current [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack').

##### Returns

`true` if they are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inStack | [ParquetClassLibrary.Parquets.ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') | The [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') to compare with the current. |

<a name='M-ParquetClassLibrary-Parquets-ParquetStack-Equals-System-Object-'></a>
### Equals(obj) `method`

##### Summary

Determines whether the specified [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') is equal to the current [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack').

##### Returns

`true` if they are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') to compare with the current [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack'). |

<a name='M-ParquetClassLibrary-Parquets-ParquetStack-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Serves as a hash function for a [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack').

##### Returns

A hash code for this instance that is suitable for use in hashing algorithms and data structures.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Parquets-ParquetStack-ToString'></a>
### ToString() `method`

##### Summary

Returns a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents the current [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack').

##### Returns

The representation.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Parquets-ParquetStack-op_Equality-ParquetClassLibrary-Parquets-ParquetStack,ParquetClassLibrary-Parquets-ParquetStack-'></a>
### op_Equality(inStack1,inStack2) `method`

##### Summary

Determines whether a specified instance of [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') is equal to another specified instance of [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack').

##### Returns

`true` if they are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inStack1 | [ParquetClassLibrary.Parquets.ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') | The first [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') to compare. |
| inStack2 | [ParquetClassLibrary.Parquets.ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') | The second [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') to compare. |

<a name='M-ParquetClassLibrary-Parquets-ParquetStack-op_Inequality-ParquetClassLibrary-Parquets-ParquetStack,ParquetClassLibrary-Parquets-ParquetStack-'></a>
### op_Inequality(inStack1,inStack2) `method`

##### Summary

Determines whether a specified instance of [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') is not equal to another specified instance of [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack').

##### Returns

`true` if they are NOT equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inStack1 | [ParquetClassLibrary.Parquets.ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') | The first [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') to compare. |
| inStack2 | [ParquetClassLibrary.Parquets.ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') | The second [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') to compare. |

<a name='T-ParquetClassLibrary-Parquets-ParquetStackArrayExtensions'></a>
## ParquetStackArrayExtensions `type`

##### Namespace

ParquetClassLibrary.Parquets

##### Summary

Provides extension methods useful when dealing with 2D arrays of [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack')s.

<a name='M-ParquetClassLibrary-Parquets-ParquetStackArrayExtensions-IsValidPosition-ParquetClassLibrary-Parquets-ParquetStack[0-,0-],ParquetClassLibrary-Vector2D-'></a>
### IsValidPosition(inSubregion,inPosition) `method`

##### Summary

Determines if the given position corresponds to a point within the current array.

##### Returns

`true`, if the position is valid, `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inSubregion | [ParquetClassLibrary.Parquets.ParquetStack[0:](#T-ParquetClassLibrary-Parquets-ParquetStack[0- 'ParquetClassLibrary.Parquets.ParquetStack[0:') | The [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') array to validate against. |
| inPosition | [0:]](#T-0-] '0:]') | The position to validate. |

<a name='T-ParquetClassLibrary-Rooms-RegionAnalysis-ParquetStackExtensions'></a>
## ParquetStackExtensions `type`

##### Namespace

ParquetClassLibrary.Rooms.RegionAnalysis

##### Summary

Extension methods used only by [RoomCollection](#T-ParquetClassLibrary-Rooms-RoomCollection 'ParquetClassLibrary.Rooms.RoomCollection') when analyzing subregions of [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace')s.

<a name='M-ParquetClassLibrary-Rooms-RegionAnalysis-ParquetStackExtensions-GetWalkableAreas-ParquetClassLibrary-Parquets-ParquetStackGrid-'></a>
### GetWalkableAreas(inSubregion) `method`

##### Summary

Finds all valid Walkable Areas in a given subregion.

##### Returns

The list of vallid Walkable Areas.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inSubregion | [ParquetClassLibrary.Parquets.ParquetStackGrid](#T-ParquetClassLibrary-Parquets-ParquetStackGrid 'ParquetClassLibrary.Parquets.ParquetStackGrid') | The [ParquetStackGrid](#T-ParquetClassLibrary-Parquets-ParquetStackGrid 'ParquetClassLibrary.Parquets.ParquetStackGrid')s to search. |

<a name='T-ParquetClassLibrary-Parquets-ParquetStackGrid'></a>
## ParquetStackGrid `type`

##### Namespace

ParquetClassLibrary.Parquets

##### Summary

A square, two-dimensional collection of [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack')s for use in [MapModel](#T-ParquetClassLibrary-Maps-MapModel 'ParquetClassLibrary.Maps.MapModel') and derived classes.

##### Remarks

The intent is that this class function much like a read-only array.

<a name='M-ParquetClassLibrary-Parquets-ParquetStackGrid-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new [ParquetStackGrid](#T-ParquetClassLibrary-Parquets-ParquetStackGrid 'ParquetClassLibrary.Parquets.ParquetStackGrid') with unusable dimensions.

##### Parameters

This constructor has no parameters.

##### Remarks

For this class, there are no reasonable default values.
 However, this version of the constructor exists to make the generic new() constraint happy
 and is used in the library in a context where its limitations are understood.
 You probably don't want to use this constructor in your own code.

<a name='M-ParquetClassLibrary-Parquets-ParquetStackGrid-#ctor-System-Int32,System-Int32-'></a>
### #ctor(inRowCount,inColumnCount) `constructor`

##### Summary

Initializes a new empty [ParquetStackGrid](#T-ParquetClassLibrary-Parquets-ParquetStackGrid 'ParquetClassLibrary.Parquets.ParquetStackGrid').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inRowCount | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The length of the Y dimension of the collection. |
| inColumnCount | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The length of the X dimension of the collection. |

<a name='M-ParquetClassLibrary-Parquets-ParquetStackGrid-#ctor-ParquetClassLibrary-Parquets-ParquetStack[0-,0-]-'></a>
### #ctor(inParquetStackArray) `constructor`

##### Summary

Initializes a new [ParquetStackGrid](#T-ParquetClassLibrary-Parquets-ParquetStackGrid 'ParquetClassLibrary.Parquets.ParquetStackGrid') from the given 2D [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') array.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inParquetStackArray | [ParquetClassLibrary.Parquets.ParquetStack[0:](#T-ParquetClassLibrary-Parquets-ParquetStack[0- 'ParquetClassLibrary.Parquets.ParquetStack[0:') | The array containing the subregion. |

<a name='P-ParquetClassLibrary-Parquets-ParquetStackGrid-Columns'></a>
### Columns `property`

##### Summary

Gets the number of elements in the X dimension of the [ParquetStackGrid](#T-ParquetClassLibrary-Parquets-ParquetStackGrid 'ParquetClassLibrary.Parquets.ParquetStackGrid').

<a name='P-ParquetClassLibrary-Parquets-ParquetStackGrid-Count'></a>
### Count `property`

##### Summary

The total number of parquets collected.

<a name='P-ParquetClassLibrary-Parquets-ParquetStackGrid-Item-System-Int32,System-Int32-'></a>
### Item `property`

##### Summary

Access to any [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') in the grid.

<a name='P-ParquetClassLibrary-Parquets-ParquetStackGrid-ParquetStacks'></a>
### ParquetStacks `property`

##### Summary

The backing collection of [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack')s.

<a name='P-ParquetClassLibrary-Parquets-ParquetStackGrid-Rows'></a>
### Rows `property`

##### Summary

Gets the number of elements in the Y dimension of the [ParquetStackGrid](#T-ParquetClassLibrary-Parquets-ParquetStackGrid 'ParquetClassLibrary.Parquets.ParquetStackGrid').

<a name='M-ParquetClassLibrary-Parquets-ParquetStackGrid-GetEnumerator'></a>
### GetEnumerator() `method`

##### Summary

Exposes an enumerator for the [ParquetStackGrid](#T-ParquetClassLibrary-Parquets-ParquetStackGrid 'ParquetClassLibrary.Parquets.ParquetStackGrid'), which supports simple iteration.

##### Returns

An enumerator.

##### Parameters

This method has no parameters.

##### Remarks

For serialization, this guarantees stable iteration order.

<a name='M-ParquetClassLibrary-Parquets-ParquetStackGrid-IsValidPosition-ParquetClassLibrary-Vector2D-'></a>
### IsValidPosition(inPosition) `method`

##### Summary

Determines if the given position corresponds to a point within the collection.

##### Returns

`true`, if the position is valid, `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inPosition | [ParquetClassLibrary.Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') | The position to validate. |

<a name='M-ParquetClassLibrary-Parquets-ParquetStackGrid-System#Collections#Generic#IEnumerable{ParquetClassLibrary#Parquets#ParquetStack}#GetEnumerator'></a>
### System#Collections#Generic#IEnumerable{ParquetClassLibrary#Parquets#ParquetStack}#GetEnumerator() `method`

##### Summary

Exposes an [IEnumerator\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerator`1 'System.Collections.Generic.IEnumerator`1'), which supports simple iteration.

##### Returns

An enumerator.

##### Parameters

This method has no parameters.

##### Remarks

For serialization, this guarantees stable iteration order.

<a name='T-ParquetClassLibrary-Rooms-RegionAnalysis-ParquetStackGridExtensions'></a>
## ParquetStackGridExtensions `type`

##### Namespace

ParquetClassLibrary.Rooms.RegionAnalysis

##### Summary

Provides extension methods for deriving [MapSpaceCollection](#T-ParquetClassLibrary-Rooms-MapSpaceCollection 'ParquetClassLibrary.Rooms.MapSpaceCollection')s from [ParquetStackGrid](#T-ParquetClassLibrary-Parquets-ParquetStackGrid 'ParquetClassLibrary.Parquets.ParquetStackGrid')s.

<a name='M-ParquetClassLibrary-Rooms-RegionAnalysis-ParquetStackGridExtensions-GetSpaces-ParquetClassLibrary-Parquets-ParquetStackGrid-'></a>
### GetSpaces() `method`

##### Summary

Returns the [MapSpaceCollection](#T-ParquetClassLibrary-Rooms-MapSpaceCollection 'ParquetClassLibrary.Rooms.MapSpaceCollection') corresponding to the [ParquetStackGrid](#T-ParquetClassLibrary-Parquets-ParquetStackGrid 'ParquetClassLibrary.Parquets.ParquetStackGrid').

##### Returns

A collection of [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace')s.

##### Parameters

This method has no parameters.

<a name='T-ParquetClassLibrary-Parquets-ParquetStatus'></a>
## ParquetStatus `type`

##### Namespace

ParquetClassLibrary.Parquets

##### Summary

Models the status of a stack of sandbox parquets.

<a name='M-ParquetClassLibrary-Parquets-ParquetStatus-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [ParquetStatus](#T-ParquetClassLibrary-Parquets-ParquetStatus 'ParquetClassLibrary.Parquets.ParquetStatus') class with default values.

##### Parameters

This constructor has no parameters.

##### Remarks

Primarily useful in the context of serialization.

<a name='M-ParquetClassLibrary-Parquets-ParquetStatus-#ctor-System-Boolean,System-Int32,System-Int32-'></a>
### #ctor(inIsTrench,inToughness,inMaxToughness) `constructor`

##### Summary

Initializes a new instance of the [ParquetStatus](#T-ParquetClassLibrary-Parquets-ParquetStatus 'ParquetClassLibrary.Parquets.ParquetStatus') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inIsTrench | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Whether or not the [FloorModel](#T-ParquetClassLibrary-Parquets-FloorModel 'ParquetClassLibrary.Parquets.FloorModel') associated with this status has been dug out. |
| inToughness | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The toughness of the [BlockModel](#T-ParquetClassLibrary-Parquets-BlockModel 'ParquetClassLibrary.Parquets.BlockModel') associated with this status. |
| inMaxToughness | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The native toughness of the [BlockModel](#T-ParquetClassLibrary-Parquets-BlockModel 'ParquetClassLibrary.Parquets.BlockModel') associated with this status. |

<a name='F-ParquetClassLibrary-Parquets-ParquetStatus-maxToughness'></a>
### maxToughness `constants`

##### Summary

The [BlockModel](#T-ParquetClassLibrary-Parquets-BlockModel 'ParquetClassLibrary.Parquets.BlockModel')'s native toughness.

<a name='F-ParquetClassLibrary-Parquets-ParquetStatus-toughness'></a>
### toughness `constants`

##### Summary

The [BlockModel](#T-ParquetClassLibrary-Parquets-BlockModel 'ParquetClassLibrary.Parquets.BlockModel')'s current toughness.

<a name='P-ParquetClassLibrary-Parquets-ParquetStatus-ConverterFactory'></a>
### ConverterFactory `property`

##### Summary

Allows the converter to construct itself statically.

<a name='P-ParquetClassLibrary-Parquets-ParquetStatus-IsTrench'></a>
### IsTrench `property`

##### Summary

If the floor has been dug out.

<a name='P-ParquetClassLibrary-Parquets-ParquetStatus-Toughness'></a>
### Toughness `property`

##### Summary

The [BlockModel](#T-ParquetClassLibrary-Parquets-BlockModel 'ParquetClassLibrary.Parquets.BlockModel')'s current toughness, from [LowestPossibleToughness](#F-ParquetClassLibrary-Parquets-BlockModel-LowestPossibleToughness 'ParquetClassLibrary.Parquets.BlockModel.LowestPossibleToughness') to [MaxToughness](#P-ParquetClassLibrary-Parquets-BlockModel-MaxToughness 'ParquetClassLibrary.Parquets.BlockModel.MaxToughness').

<a name='P-ParquetClassLibrary-Parquets-ParquetStatus-Unused'></a>
### Unused `property`

##### Summary

Provides a throwaway instance of the [ParquetStatus](#T-ParquetClassLibrary-Parquets-ParquetStatus 'ParquetClassLibrary.Parquets.ParquetStatus') class with default values.

<a name='M-ParquetClassLibrary-Parquets-ParquetStatus-Clone'></a>
### Clone() `method`

##### Summary

Creates a new instance with the same characteristics as the current instance.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Parquets-ParquetStatus-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData-'></a>
### ConvertFromString(inText,inRow,inMemberMapData) `method`

##### Summary

Converts the given [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') to an [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') as deserialization.

##### Returns

The given instance deserialized.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inText | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The text to convert. |
| inRow | [CsvHelper.IReaderRow](#T-CsvHelper-IReaderRow 'CsvHelper.IReaderRow') | The current context and configuration. |
| inMemberMapData | [CsvHelper.Configuration.MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') | Mapping info for a member to a CSV field or property. |

<a name='M-ParquetClassLibrary-Parquets-ParquetStatus-ConvertToString-System-Object,CsvHelper-IWriterRow,CsvHelper-Configuration-MemberMapData-'></a>
### ConvertToString(inValue,inRow,inMemberMapData) `method`

##### Summary

Converts the given [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') to a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') for serialization.

##### Returns

The given instance serialized.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inValue | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The instance to convert. |
| inRow | [CsvHelper.IWriterRow](#T-CsvHelper-IWriterRow 'CsvHelper.IWriterRow') | The current context and configuration. |
| inMemberMapData | [CsvHelper.Configuration.MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') | Mapping info for a member to a CSV field or property. |

<a name='M-ParquetClassLibrary-Parquets-ParquetStatus-Equals-ParquetClassLibrary-Parquets-ParquetStatus-'></a>
### Equals(inStatus) `method`

##### Summary

Determines whether the specified [ParquetStatus](#T-ParquetClassLibrary-Parquets-ParquetStatus 'ParquetClassLibrary.Parquets.ParquetStatus') is equal to the current [ParquetStatus](#T-ParquetClassLibrary-Parquets-ParquetStatus 'ParquetClassLibrary.Parquets.ParquetStatus').

##### Returns

`true` if they are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inStatus | [ParquetClassLibrary.Parquets.ParquetStatus](#T-ParquetClassLibrary-Parquets-ParquetStatus 'ParquetClassLibrary.Parquets.ParquetStatus') | The [ParquetStatus](#T-ParquetClassLibrary-Parquets-ParquetStatus 'ParquetClassLibrary.Parquets.ParquetStatus') to compare with the current. |

<a name='M-ParquetClassLibrary-Parquets-ParquetStatus-Equals-System-Object-'></a>
### Equals(obj) `method`

##### Summary

Determines whether the specified [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') is equal to the current [ParquetStatus](#T-ParquetClassLibrary-Parquets-ParquetStatus 'ParquetClassLibrary.Parquets.ParquetStatus').

##### Returns

`true` if they are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') to compare with the current [ParquetStatus](#T-ParquetClassLibrary-Parquets-ParquetStatus 'ParquetClassLibrary.Parquets.ParquetStatus'). |

<a name='M-ParquetClassLibrary-Parquets-ParquetStatus-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Serves as a hash function for a [ParquetStatus](#T-ParquetClassLibrary-Parquets-ParquetStatus 'ParquetClassLibrary.Parquets.ParquetStatus').

##### Returns

A hash code for this instance that is suitable for use in hashing algorithms and data structures.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Parquets-ParquetStatus-ToString'></a>
### ToString() `method`

##### Summary

Returns a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents the current [ParquetStatus](#T-ParquetClassLibrary-Parquets-ParquetStatus 'ParquetClassLibrary.Parquets.ParquetStatus').

##### Returns

The representation.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Parquets-ParquetStatus-op_Equality-ParquetClassLibrary-Parquets-ParquetStatus,ParquetClassLibrary-Parquets-ParquetStatus-'></a>
### op_Equality(inStatus1,inStatus2) `method`

##### Summary

Determines whether a specified instance of [ParquetStatus](#T-ParquetClassLibrary-Parquets-ParquetStatus 'ParquetClassLibrary.Parquets.ParquetStatus') is equal to another specified instance of [ParquetStatus](#T-ParquetClassLibrary-Parquets-ParquetStatus 'ParquetClassLibrary.Parquets.ParquetStatus').

##### Returns

`true` if they are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inStatus1 | [ParquetClassLibrary.Parquets.ParquetStatus](#T-ParquetClassLibrary-Parquets-ParquetStatus 'ParquetClassLibrary.Parquets.ParquetStatus') | The first [ParquetStatus](#T-ParquetClassLibrary-Parquets-ParquetStatus 'ParquetClassLibrary.Parquets.ParquetStatus') to compare. |
| inStatus2 | [ParquetClassLibrary.Parquets.ParquetStatus](#T-ParquetClassLibrary-Parquets-ParquetStatus 'ParquetClassLibrary.Parquets.ParquetStatus') | The second [ParquetStatus](#T-ParquetClassLibrary-Parquets-ParquetStatus 'ParquetClassLibrary.Parquets.ParquetStatus') to compare. |

<a name='M-ParquetClassLibrary-Parquets-ParquetStatus-op_Inequality-ParquetClassLibrary-Parquets-ParquetStatus,ParquetClassLibrary-Parquets-ParquetStatus-'></a>
### op_Inequality(inStatus1,inStatus2) `method`

##### Summary

Determines whether a specified instance of [ParquetStatus](#T-ParquetClassLibrary-Parquets-ParquetStatus 'ParquetClassLibrary.Parquets.ParquetStatus') is not equal to another specified instance of [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack').

##### Returns

`true` if they are NOT equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inStatus1 | [ParquetClassLibrary.Parquets.ParquetStatus](#T-ParquetClassLibrary-Parquets-ParquetStatus 'ParquetClassLibrary.Parquets.ParquetStatus') | The first [ParquetStatus](#T-ParquetClassLibrary-Parquets-ParquetStatus 'ParquetClassLibrary.Parquets.ParquetStatus') to compare. |
| inStatus2 | [ParquetClassLibrary.Parquets.ParquetStatus](#T-ParquetClassLibrary-Parquets-ParquetStatus 'ParquetClassLibrary.Parquets.ParquetStatus') | The second [ParquetStatus](#T-ParquetClassLibrary-Parquets-ParquetStatus 'ParquetClassLibrary.Parquets.ParquetStatus') to compare. |

<a name='T-ParquetClassLibrary-Parquets-ParquetStatusArrayExtensions'></a>
## ParquetStatusArrayExtensions `type`

##### Namespace

ParquetClassLibrary.Parquets

##### Summary

Provides extension methods useful when dealing with 2D arrays of [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack')s.

<a name='M-ParquetClassLibrary-Parquets-ParquetStatusArrayExtensions-IsValidPosition-ParquetClassLibrary-Parquets-ParquetStatus[0-,0-],ParquetClassLibrary-Vector2D-'></a>
### IsValidPosition(inSubregion,inPosition) `method`

##### Summary

Determines if the given position corresponds to a point within the current array.

##### Returns

`true`, if the position is valid, `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inSubregion | [ParquetClassLibrary.Parquets.ParquetStatus[0:](#T-ParquetClassLibrary-Parquets-ParquetStatus[0- 'ParquetClassLibrary.Parquets.ParquetStatus[0:') | The [ParquetStatus](#T-ParquetClassLibrary-Parquets-ParquetStatus 'ParquetClassLibrary.Parquets.ParquetStatus') array to validate against. |
| inPosition | [0:]](#T-0-] '0:]') | The position to validate. |

<a name='T-ParquetClassLibrary-Parquets-ParquetStatusGrid'></a>
## ParquetStatusGrid `type`

##### Namespace

ParquetClassLibrary.Parquets

##### Summary

A square, two-dimensional collection of [ParquetStatus](#T-ParquetClassLibrary-Parquets-ParquetStatus 'ParquetClassLibrary.Parquets.ParquetStatus')es for use in [MapModel](#T-ParquetClassLibrary-Maps-MapModel 'ParquetClassLibrary.Maps.MapModel') and derived classes.

##### Remarks

The intent is that this class function much like a read-only array.

<a name='M-ParquetClassLibrary-Parquets-ParquetStatusGrid-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new [ParquetStatusGrid](#T-ParquetClassLibrary-Parquets-ParquetStatusGrid 'ParquetClassLibrary.Parquets.ParquetStatusGrid') with unusable dimensions.

##### Parameters

This constructor has no parameters.

##### Remarks

For this class, there are no reasonable default values.
 However, this version of the constructor exists to make the generic new() constraint happy
 and is used in the library in a context where its limitations are understood.
 You probably don't want to use this constructor in your own code.

<a name='M-ParquetClassLibrary-Parquets-ParquetStatusGrid-#ctor-System-Int32,System-Int32-'></a>
### #ctor(inRowCount,inColumnCount) `constructor`

##### Summary

Initializes a new [ParquetStatusGrid](#T-ParquetClassLibrary-Parquets-ParquetStatusGrid 'ParquetClassLibrary.Parquets.ParquetStatusGrid').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inRowCount | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The length of the Y dimension of the collection. |
| inColumnCount | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The length of the X dimension of the collection. |

<a name='P-ParquetClassLibrary-Parquets-ParquetStatusGrid-Columns'></a>
### Columns `property`

##### Summary

Gets the number of elements in the X dimension of the [ParquetStatusGrid](#T-ParquetClassLibrary-Parquets-ParquetStatusGrid 'ParquetClassLibrary.Parquets.ParquetStatusGrid').

<a name='P-ParquetClassLibrary-Parquets-ParquetStatusGrid-Count'></a>
### Count `property`

##### Summary

The total number of parquets collected.

<a name='P-ParquetClassLibrary-Parquets-ParquetStatusGrid-Item-System-Int32,System-Int32-'></a>
### Item `property`

##### Summary

Access to any [ParquetStatus](#T-ParquetClassLibrary-Parquets-ParquetStatus 'ParquetClassLibrary.Parquets.ParquetStatus') in the grid.

<a name='P-ParquetClassLibrary-Parquets-ParquetStatusGrid-ParquetStatuses'></a>
### ParquetStatuses `property`

##### Summary

The backing collection of [ParquetStatus](#T-ParquetClassLibrary-Parquets-ParquetStatus 'ParquetClassLibrary.Parquets.ParquetStatus')es.

<a name='P-ParquetClassLibrary-Parquets-ParquetStatusGrid-Rows'></a>
### Rows `property`

##### Summary

Gets the number of elements in the Y dimension of the [ParquetStatusGrid](#T-ParquetClassLibrary-Parquets-ParquetStatusGrid 'ParquetClassLibrary.Parquets.ParquetStatusGrid').

<a name='M-ParquetClassLibrary-Parquets-ParquetStatusGrid-GetEnumerator'></a>
### GetEnumerator() `method`

##### Summary

Exposes an enumerator for the [ParquetStatusGrid](#T-ParquetClassLibrary-Parquets-ParquetStatusGrid 'ParquetClassLibrary.Parquets.ParquetStatusGrid'), which supports simple iteration.

##### Returns

An enumerator.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Parquets-ParquetStatusGrid-IsValidPosition-ParquetClassLibrary-Vector2D-'></a>
### IsValidPosition(inPosition) `method`

##### Summary

Determines if the given position corresponds to a point within the collection.

##### Returns

`true`, if the position is valid, `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inPosition | [ParquetClassLibrary.Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') | The position to validate. |

<a name='M-ParquetClassLibrary-Parquets-ParquetStatusGrid-System#Collections#Generic#IEnumerable{ParquetClassLibrary#Parquets#ParquetStatus}#GetEnumerator'></a>
### System#Collections#Generic#IEnumerable{ParquetClassLibrary#Parquets#ParquetStatus}#GetEnumerator() `method`

##### Summary

Exposes an [IEnumerator\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerator`1 'System.Collections.Generic.IEnumerator`1'), which supports simple iteration.

##### Returns

An enumerator.

##### Parameters

This method has no parameters.

<a name='T-ParquetClassLibrary-Maps-PositionInfoEventArgs'></a>
## PositionInfoEventArgs `type`

##### Namespace

ParquetClassLibrary.Maps

##### Summary

Indicates that the encapsulated info corresponding to a particular position in the current map
is ready to be displayed.

<a name='M-ParquetClassLibrary-Maps-PositionInfoEventArgs-#ctor-ParquetClassLibrary-Parquets-ParquetStack,ParquetClassLibrary-Parquets-ParquetStatus,System-Collections-Generic-IEnumerable{ParquetClassLibrary-Maps-ExitPoint}-'></a>
### #ctor(inStacks,inStatuses,inPoints) `constructor`

##### Summary

Triggered when the information about a specific map location is ready to be displayed.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inStacks | [ParquetClassLibrary.Parquets.ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') | Definition of any and all parquets at the location. |
| inStatuses | [ParquetClassLibrary.Parquets.ParquetStatus](#T-ParquetClassLibrary-Parquets-ParquetStatus 'ParquetClassLibrary.Parquets.ParquetStatus') | Status of any and all parquets at the location. |
| inPoints | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Maps.ExitPoint}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Maps.ExitPoint}') | Any and all special points at the location. |

<a name='P-ParquetClassLibrary-Maps-PositionInfoEventArgs-SpecialPoints'></a>
### SpecialPoints `property`

##### Summary

Special points at the given position.

<a name='P-ParquetClassLibrary-Maps-PositionInfoEventArgs-Stack'></a>
### Stack `property`

##### Summary

Parquets at the given position.

<a name='P-ParquetClassLibrary-Maps-PositionInfoEventArgs-Status'></a>
### Status `property`

##### Summary

Status of parquets at the given position.

<a name='T-ParquetClassLibrary-Utilities-Precondition'></a>
## Precondition `type`

##### Namespace

ParquetClassLibrary.Utilities

##### Summary

Provides constructors and initialization routines with concise arugment boilerplate.

<a name='F-ParquetClassLibrary-Utilities-Precondition-DefaultArgumentName'></a>
### DefaultArgumentName `constants`

##### Summary

Text to use when no argument name is provided.

<a name='M-ParquetClassLibrary-Utilities-Precondition-AreInRange-System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},System-String-'></a>
### AreInRange(inEnumerable,inBounds,inArgumentName) `method`

##### Summary

Verifies that all of the given [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s fall within the given
[Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1'), inclusive.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inEnumerable | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}') | The identifiers to test. |
| inBounds | [ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}](#T-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID} 'ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}') | The range they must fall within. |
| inArgumentName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the argument to use in error reporting. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | When the identifier is not in range. |

<a name='M-ParquetClassLibrary-Utilities-Precondition-AreInRange-System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Range{ParquetClassLibrary-ModelID}},System-String-'></a>
### AreInRange(inEnumerable,inBoundsCollection,inArgumentName) `method`

##### Summary

Verifies that all of the given [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s fall within the given 
collection of [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1')s, inclusive.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inEnumerable | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}') | The identifiers to test. |
| inBoundsCollection | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}}') | The collection of ranges they must fall within. |
| inArgumentName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the argument to use in error reporting. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | When the identifier is not in range. |

<a name='M-ParquetClassLibrary-Utilities-Precondition-IsInRange-System-Int32,ParquetClassLibrary-Range{System-Int32},System-String-'></a>
### IsInRange(inInt,inBounds,inArgumentName) `method`

##### Summary

Checks if the given [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') falls within the given [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1'), inclusive.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inInt | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The integer to test. |
| inBounds | [ParquetClassLibrary.Range{System.Int32}](#T-ParquetClassLibrary-Range{System-Int32} 'ParquetClassLibrary.Range{System.Int32}') | The range it must fall within. |
| inArgumentName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the argument to use in error reporting. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | When the integer is not in range. |

<a name='M-ParquetClassLibrary-Utilities-Precondition-IsInRange-ParquetClassLibrary-ModelID,ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},System-String-'></a>
### IsInRange(inID,inBounds,inArgumentName) `method`

##### Summary

Checks if the given [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') falls within the given [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1'), inclusive.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The identifier to test. |
| inBounds | [ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}](#T-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID} 'ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}') | The range it must fall within. |
| inArgumentName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the argument to use in error reporting. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | When the identifier is not in range. |

<a name='M-ParquetClassLibrary-Utilities-Precondition-IsInRange-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},System-String-'></a>
### IsInRange(inInnerBounds,inOuterBounds,inArgumentName) `method`

##### Summary

Checks if the first given [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1') falls within the second given [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1'), inclusive.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inInnerBounds | [ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}](#T-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID} 'ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}') | The range to test. |
| inOuterBounds | [ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}](#T-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID} 'ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}') | The range it must fall within. |
| inArgumentName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the argument to use in error reporting. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | When the first range is not in the second range. |

<a name='M-ParquetClassLibrary-Utilities-Precondition-IsInRange-ParquetClassLibrary-ModelID,System-Collections-Generic-IEnumerable{ParquetClassLibrary-Range{ParquetClassLibrary-ModelID}},System-String-'></a>
### IsInRange(inID,inBoundsCollection,inArgumentName) `method`

##### Summary

Checks if the first given [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') falls within at least one of the
given collection of [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1')s, inclusive.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The identifier to test. |
| inBoundsCollection | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}}') | The collection of ranges it must fall within. |
| inArgumentName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the argument to use in error reporting. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | When the identifier is not in any of the ranges. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | When `inBoundsCollection` is null. |

<a name='M-ParquetClassLibrary-Utilities-Precondition-IsInRange-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Range{ParquetClassLibrary-ModelID}},System-String-'></a>
### IsInRange(inInnerBounds,inBoundsCollection,inArgumentName) `method`

##### Summary

Checks if the given [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1') falls within at least one of the
given collection of [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1')s, inclusive.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inInnerBounds | [ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}](#T-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID} 'ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}') | The range to test. |
| inBoundsCollection | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}}') | The collection of ranges it must fall within. |
| inArgumentName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the argument to use in error reporting. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | When the first range is not in the second range. |

<a name='M-ParquetClassLibrary-Utilities-Precondition-IsNotNone-ParquetClassLibrary-ModelID,System-String-'></a>
### IsNotNone(inID,inArgumentName) `method`

##### Summary

Verifies that the given [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') is not [None](#F-ParquetClassLibrary-ModelID-None 'ParquetClassLibrary.ModelID.None').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The number to test. |
| inArgumentName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the argument to use in error reporting. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | When the number is -1 or less. |

<a name='M-ParquetClassLibrary-Utilities-Precondition-IsNotNull-System-Object,System-String-'></a>
### IsNotNull(inReference,inArgumentName) `method`

##### Summary

Verifies that the given reference is not `null`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inReference | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The reference to test. |
| inArgumentName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the argument to use in error reporting. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | When `inReference` is null. |

<a name='M-ParquetClassLibrary-Utilities-Precondition-IsNotNullOrEmpty-System-String,System-String-'></a>
### IsNotNullOrEmpty(inString,inArgumentName) `method`

##### Summary

Verifies that the given [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') is not empty.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inString | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The string to test. |
| inArgumentName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the argument to use in error reporting. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IndexOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IndexOutOfRangeException 'System.IndexOutOfRangeException') | When `inString` is null or empty. |

<a name='M-ParquetClassLibrary-Utilities-Precondition-IsNotNullOrEmpty``1-System-Collections-Generic-IEnumerable{``0},System-String-'></a>
### IsNotNullOrEmpty\`\`1(inEnumerable,inArgumentName) `method`

##### Summary

Verifies that the given [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1') is not empty.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inEnumerable | [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{``0}') | The collection to test. |
| inArgumentName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the argument to use in error reporting. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | When `inEnumerable` is null. |
| [System.IndexOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IndexOutOfRangeException 'System.IndexOutOfRangeException') | When `inEnumerable` is empty. |

<a name='M-ParquetClassLibrary-Utilities-Precondition-IsOfType``2-System-String-'></a>
### IsOfType\`\`2(inArgumentName) `method`

##### Summary

Verifies that the first given class is or is derived from the second given class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inArgumentName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the argument to use in error reporting. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TToCheck | The type to check. |
| TTarget | The type of which it must be a subtype. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | When `TToCheck` does not correspond to `TTarget`. |

<a name='M-ParquetClassLibrary-Utilities-Precondition-MustBeNonNegative-System-Int32,System-String-'></a>
### MustBeNonNegative(inNumber,inArgumentName) `method`

##### Summary

Verifies that the given number is zero or positive.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inNumber | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The number to test. |
| inArgumentName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the argument to use in error reporting. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | When the number is -1 or less. |

<a name='M-ParquetClassLibrary-Utilities-Precondition-MustBePositive-System-Int32,System-String-'></a>
### MustBePositive(inNumber,inArgumentName) `method`

##### Summary

Verifies that the given number is positive.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inNumber | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The number to test. |
| inArgumentName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the argument to use in error reporting. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | When the number is zero or less. |

<a name='T-ParquetClassLibrary-Beings-PronounGroup'></a>
## PronounGroup `type`

##### Namespace

ParquetClassLibrary.Beings

##### Summary

A group of personal pronouns used together to indicate an individual, potentially communicating both their plurality and their gender.

<a name='M-ParquetClassLibrary-Beings-PronounGroup-#ctor-System-String,System-String,System-String,System-String,System-String-'></a>
### #ctor(inSubjective,inObjective,inDeterminer,inPossessive,inReflexive) `constructor`

##### Summary

Initializes a new instance of the [PronounGroup](#T-ParquetClassLibrary-Beings-PronounGroup 'ParquetClassLibrary.Beings.PronounGroup') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inSubjective | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Personal pronoun used as the subject of a verb.  Cannot be null or empty. |
| inObjective | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Personal pronoun used as the indirect object of a preposition or verb.  Cannot be null or empty. |
| inDeterminer | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Personal pronoun used to modify a noun attributing possession.  Cannot be null or empty. |
| inPossessive | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Personal pronoun used to indicate a relationship in a broad sense.  Cannot be null or empty. |
| inReflexive | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Personal pronoun used as a coreferential to indicate the user.  Cannot be null or empty. |

<a name='F-ParquetClassLibrary-Beings-PronounGroup-DefaultGroup'></a>
### DefaultGroup `constants`

##### Summary

A pronoun to use when none is specified.

<a name='F-ParquetClassLibrary-Beings-PronounGroup-DefaultKey'></a>
### DefaultKey `constants`

##### Summary

A pronoun to use when none is specified.

<a name='F-ParquetClassLibrary-Beings-PronounGroup-DeterminerTag'></a>
### DeterminerTag `constants`

##### Summary

Indicates the [Determiner](#P-ParquetClassLibrary-Beings-PronounGroup-Determiner 'ParquetClassLibrary.Beings.PronounGroup.Determiner') should be used.

<a name='F-ParquetClassLibrary-Beings-PronounGroup-ObjectiveTag'></a>
### ObjectiveTag `constants`

##### Summary

Indicates the [Objective](#P-ParquetClassLibrary-Beings-PronounGroup-Objective 'ParquetClassLibrary.Beings.PronounGroup.Objective') should be used.

<a name='F-ParquetClassLibrary-Beings-PronounGroup-PossessiveTag'></a>
### PossessiveTag `constants`

##### Summary

Indicates the [Possessive](#P-ParquetClassLibrary-Beings-PronounGroup-Possessive 'ParquetClassLibrary.Beings.PronounGroup.Possessive') should be used.

<a name='F-ParquetClassLibrary-Beings-PronounGroup-ReflexiveTag'></a>
### ReflexiveTag `constants`

##### Summary

Indicates the [Reflexive](#P-ParquetClassLibrary-Beings-PronounGroup-Reflexive 'ParquetClassLibrary.Beings.PronounGroup.Reflexive') should be used.

<a name='F-ParquetClassLibrary-Beings-PronounGroup-SubjectiveTag'></a>
### SubjectiveTag `constants`

##### Summary

Indicates the [Subjective](#P-ParquetClassLibrary-Beings-PronounGroup-Subjective 'ParquetClassLibrary.Beings.PronounGroup.Subjective') should be used.

<a name='P-ParquetClassLibrary-Beings-PronounGroup-Determiner'></a>
### Determiner `property`

##### Summary

Personal pronoun used to attribute possession.

<a name='P-ParquetClassLibrary-Beings-PronounGroup-Objective'></a>
### Objective `property`

##### Summary

Personal pronoun used as the indirect object of a preposition or verb.

<a name='P-ParquetClassLibrary-Beings-PronounGroup-ParquetClassLibrary#Beings#IPronounGroupEdit#Determiner'></a>
### ParquetClassLibrary#Beings#IPronounGroupEdit#Determiner `property`

##### Summary

Personal pronoun used to attribute possession.

<a name='P-ParquetClassLibrary-Beings-PronounGroup-ParquetClassLibrary#Beings#IPronounGroupEdit#Objective'></a>
### ParquetClassLibrary#Beings#IPronounGroupEdit#Objective `property`

##### Summary

Personal pronoun used as the indirect object of a preposition or verb.

<a name='P-ParquetClassLibrary-Beings-PronounGroup-ParquetClassLibrary#Beings#IPronounGroupEdit#Possessive'></a>
### ParquetClassLibrary#Beings#IPronounGroupEdit#Possessive `property`

##### Summary

Personal pronoun used to indicate a relationship.

<a name='P-ParquetClassLibrary-Beings-PronounGroup-ParquetClassLibrary#Beings#IPronounGroupEdit#Reflexive'></a>
### ParquetClassLibrary#Beings#IPronounGroupEdit#Reflexive `property`

##### Summary

Personal pronoun used to indicate the user.

<a name='P-ParquetClassLibrary-Beings-PronounGroup-ParquetClassLibrary#Beings#IPronounGroupEdit#Subjective'></a>
### ParquetClassLibrary#Beings#IPronounGroupEdit#Subjective `property`

##### Summary

Personal pronoun used as the subject of a verb.

<a name='P-ParquetClassLibrary-Beings-PronounGroup-Possessive'></a>
### Possessive `property`

##### Summary

Personal pronoun used to indicate a relationship.

<a name='P-ParquetClassLibrary-Beings-PronounGroup-Reflexive'></a>
### Reflexive `property`

##### Summary

Personal pronoun used to indicate the user.

<a name='P-ParquetClassLibrary-Beings-PronounGroup-Subjective'></a>
### Subjective `property`

##### Summary

Personal pronoun used as the subject of a verb.

<a name='M-ParquetClassLibrary-Beings-PronounGroup-GetFilePath'></a>
### GetFilePath() `method`

##### Summary

Returns the filename and path associated with [PronounGroup](#T-ParquetClassLibrary-Beings-PronounGroup 'ParquetClassLibrary.Beings.PronounGroup')s' designer file.

##### Returns

A full path to the associated designer file.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Beings-PronounGroup-GetRecords'></a>
### GetRecords() `method`

##### Summary

Reads all [PronounGroup](#T-ParquetClassLibrary-Beings-PronounGroup 'ParquetClassLibrary.Beings.PronounGroup') records from the appropriate file.

##### Returns

The instances read.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Beings-PronounGroup-PutRecords-System-Collections-Generic-IEnumerable{ParquetClassLibrary-Beings-PronounGroup}-'></a>
### PutRecords() `method`

##### Summary

Writes all [PronounGroup](#T-ParquetClassLibrary-Beings-PronounGroup 'ParquetClassLibrary.Beings.PronounGroup') records to the appropriate file.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Beings-PronounGroup-ToString'></a>
### ToString() `method`

##### Summary

Returns a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents the [PronounGroup](#T-ParquetClassLibrary-Beings-PronounGroup 'ParquetClassLibrary.Beings.PronounGroup').

##### Returns

The representation.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Beings-PronounGroup-UpdatePronouns-System-Text-StringBuilder-'></a>
### UpdatePronouns(inText) `method`

##### Summary

Replaces pronoun tags with the given [PronounGroup](#T-ParquetClassLibrary-Beings-PronounGroup 'ParquetClassLibrary.Beings.PronounGroup').

##### Returns

The updated text.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inText | [System.Text.StringBuilder](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.StringBuilder 'System.Text.StringBuilder') | The text to transform. |

<a name='M-ParquetClassLibrary-Beings-PronounGroup-UpdatePronouns-System-String-'></a>
### UpdatePronouns(inText) `method`

##### Summary

Replaces pronoun tags with the given [PronounGroup](#T-ParquetClassLibrary-Beings-PronounGroup 'ParquetClassLibrary.Beings.PronounGroup').

##### Returns

The updated text.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inText | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The text to transform. |

<a name='T-ParquetClassLibrary-RangeCollectionExtensions'></a>
## RangeCollectionExtensions `type`

##### Namespace

ParquetClassLibrary

##### Summary

Provides extension methods to [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1') collections of [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1').

<a name='M-ParquetClassLibrary-RangeCollectionExtensions-ContainsRange``1-System-Collections-Generic-IEnumerable{ParquetClassLibrary-Range{``0}},ParquetClassLibrary-Range{``0}-'></a>
### ContainsRange\`\`1(inRangeCollection,inRange) `method`

##### Summary

Determines if the given [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1') is contained by any of the ranges
in the current [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1').

##### Returns

`true`, if the given range was containsed in the list, `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inRangeCollection | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{``0}}') | The range collection in which to search. |
| inRange | [ParquetClassLibrary.Range{\`\`0}](#T-ParquetClassLibrary-Range{``0} 'ParquetClassLibrary.Range{``0}') | The range to search for. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TElement | The type over which the Ranges are defined. |

<a name='M-ParquetClassLibrary-RangeCollectionExtensions-ContainsValue``1-System-Collections-Generic-IEnumerable{ParquetClassLibrary-Range{``0}},``0-'></a>
### ContainsValue\`\`1(inRangeCollection,inValue) `method`

##### Summary

Determines if the given `inValue` is contained by any of the [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1')s
in the current [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1').

##### Returns

`true`, if the `inValue` was containsed in `inRangeCollection`,
`false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inRangeCollection | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{``0}}') | The range collection in which to search. |
| inValue | [\`\`0](#T-``0 '``0') | The value to search for. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TElement | The type over which the Ranges are defined. |

<a name='M-ParquetClassLibrary-RangeCollectionExtensions-IsValid``1-System-Collections-Generic-IEnumerable{ParquetClassLibrary-Range{``0}}-'></a>
### IsValid\`\`1() `method`

##### Summary

Determines if all of the given [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1')s are well defined;
that is, if Minima are less than or equal to Maxima.

##### Returns

`true`, if the range is valid, `false` otherwise.

##### Parameters

This method has no parameters.

<a name='T-ParquetClassLibrary-Range`1'></a>
## Range\`1 `type`

##### Namespace

ParquetClassLibrary

##### Summary

Stores the endpoints for a set of values specifying an inclusive range over the given type.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TElement | The type over which the range is spread. |

<a name='M-ParquetClassLibrary-Range`1-#ctor-`0,`0-'></a>
### #ctor(inMinimum,inMaximum) `constructor`

##### Summary

Initializes a new instance of the [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1') struct.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inMinimum | [\`0](#T-`0 '`0') | The lower end of the range. |
| inMaximum | [\`0](#T-`0 '`0') | The upper end of the range. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | When the range is not well-defined.  . |

<a name='P-ParquetClassLibrary-Range`1-ConverterFactory'></a>
### ConverterFactory `property`

##### Summary

Allows the converter to construct itself statically.

<a name='P-ParquetClassLibrary-Range`1-Int32ConverterFactory'></a>
### Int32ConverterFactory `property`

##### Summary

Allows deserialization of `TElement`s that are interchangeable with [Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64').

<a name='P-ParquetClassLibrary-Range`1-Maximum'></a>
### Maximum `property`

##### Summary

Maximum value of the range.

<a name='P-ParquetClassLibrary-Range`1-Minimum'></a>
### Minimum `property`

##### Summary

Minimum value of the range.

<a name='P-ParquetClassLibrary-Range`1-SingleConverterFactory'></a>
### SingleConverterFactory `property`

##### Summary

Allows deserialization of `TElement`s that are interchangeable with [Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double').

<a name='M-ParquetClassLibrary-Range`1-ContainsRange-ParquetClassLibrary-Range{`0}-'></a>
### ContainsRange(inRange) `method`

##### Summary

Determines if the given [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1') is equal to or entirely contained within the current Range.

##### Returns

`true`, if the given range is within the current range, `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inRange | [ParquetClassLibrary.Range{\`0}](#T-ParquetClassLibrary-Range{`0} 'ParquetClassLibrary.Range{`0}') | The [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1') to test. |

<a name='M-ParquetClassLibrary-Range`1-ContainsValue-`0-'></a>
### ContainsValue(inValue) `method`

##### Summary

Determines if the given value is within the range, inclusive.

##### Returns

`true`, if the value is in range, `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inValue | [\`0](#T-`0 '`0') | The value to test. |

<a name='M-ParquetClassLibrary-Range`1-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData-'></a>
### ConvertFromString(inText,inRow,inMemberMapData) `method`

##### Summary

Converts the given [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') to an [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') as deserialization.

##### Returns

The given instance deserialized.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inText | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The instance to convert. |
| inRow | [CsvHelper.IReaderRow](#T-CsvHelper-IReaderRow 'CsvHelper.IReaderRow') | The current context and configuration. |
| inMemberMapData | [CsvHelper.Configuration.MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') | Mapping info for a member to a CSV field or property. |

<a name='M-ParquetClassLibrary-Range`1-ConvertToString-System-Object,CsvHelper-IWriterRow,CsvHelper-Configuration-MemberMapData-'></a>
### ConvertToString(inValue,inRow,inMemberMapData) `method`

##### Summary

Converts the given [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') to a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') for serialization.

##### Returns

The given instance serialized.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inValue | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The instance to convert. |
| inRow | [CsvHelper.IWriterRow](#T-CsvHelper-IWriterRow 'CsvHelper.IWriterRow') | The current context and configuration. |
| inMemberMapData | [CsvHelper.Configuration.MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') | Mapping info for a member to a CSV field or property. |

<a name='M-ParquetClassLibrary-Range`1-Equals-ParquetClassLibrary-Range{`0}-'></a>
### Equals(inRange) `method`

##### Summary

Determines whether the specified [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1') is equal to the current [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1').

##### Returns

`true` if they are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inRange | [ParquetClassLibrary.Range{\`0}](#T-ParquetClassLibrary-Range{`0} 'ParquetClassLibrary.Range{`0}') | The [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1') to compare with the current. |

<a name='M-ParquetClassLibrary-Range`1-Equals-System-Object-'></a>
### Equals(obj) `method`

##### Summary

Determines whether the specified [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') is equal to the current [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1').

##### Returns

`true` if they are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') to compare with the current [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1'). |

<a name='M-ParquetClassLibrary-Range`1-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Serves as a hash function for a [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1').

##### Returns

A hash code for this instance that is suitable for use in hashing algorithms and data structures.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Range`1-IsValid'></a>
### IsValid() `method`

##### Summary

Determines if the [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1') is well defined; that is, if Minimum is less than or equal to Maximum.

##### Returns

`true`, if the range is valid, `false` otherwise.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Range`1-ToString'></a>
### ToString() `method`

##### Summary

Returns a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents the current [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1').

##### Returns

The representation.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Range`1-op_Equality-ParquetClassLibrary-Range{`0},ParquetClassLibrary-Range{`0}-'></a>
### op_Equality(inRange1,inRange2) `method`

##### Summary

Determines whether a specified instance of [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1')
is equal to another specified instance of [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1').

##### Returns

`true` if they are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inRange1 | [ParquetClassLibrary.Range{\`0}](#T-ParquetClassLibrary-Range{`0} 'ParquetClassLibrary.Range{`0}') | The first [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1') to compare. |
| inRange2 | [ParquetClassLibrary.Range{\`0}](#T-ParquetClassLibrary-Range{`0} 'ParquetClassLibrary.Range{`0}') | The second [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1') to compare. |

<a name='M-ParquetClassLibrary-Range`1-op_Inequality-ParquetClassLibrary-Range{`0},ParquetClassLibrary-Range{`0}-'></a>
### op_Inequality(inRange1,inRange2) `method`

##### Summary

Determines whether a specified instance of [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1')
is not equal to another specified instance of [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1').

##### Returns

`true` if they are NOT equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inRange1 | [ParquetClassLibrary.Range{\`0}](#T-ParquetClassLibrary-Range{`0} 'ParquetClassLibrary.Range{`0}') | The first [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1') to compare. |
| inRange2 | [ParquetClassLibrary.Range{\`0}](#T-ParquetClassLibrary-Range{`0} 'ParquetClassLibrary.Range{`0}') | The second [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1') to compare. |

<a name='T-ParquetClassLibrary-Utilities-Rasterization'></a>
## Rasterization `type`

##### Namespace

ParquetClassLibrary.Utilities

##### Summary

Methods and data to assist in rasterization.

<a name='M-ParquetClassLibrary-Utilities-Rasterization-PlotCircle-ParquetClassLibrary-Vector2D,System-Int32,System-Boolean,System-Predicate{ParquetClassLibrary-Vector2D}-'></a>
### PlotCircle(inCenter,inRadius,inIsFilled,inIsValid) `method`

##### Summary

Plots a circular region including all points contained on the circle but none within it.

##### Returns

The circle.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inCenter | [ParquetClassLibrary.Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') | The circle's center. |
| inRadius | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The circle's radius. |
| inIsFilled | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If set to `true` in is filled. |
| inIsValid | [System.Predicate{ParquetClassLibrary.Vector2D}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Predicate 'System.Predicate{ParquetClassLibrary.Vector2D}') | Tests if plotted points are useable in their intended domain. |

<a name='M-ParquetClassLibrary-Utilities-Rasterization-PlotEmptyRectangle-ParquetClassLibrary-Vector2D,ParquetClassLibrary-Vector2D,System-Predicate{ParquetClassLibrary-Vector2D}-'></a>
### PlotEmptyRectangle(inUpperLeft,inLowerRight,inIsValid) `method`

##### Summary

Plots a rectangular region including all points contained on the rectanle but none within it.

##### Returns

The rectangle.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inUpperLeft | [ParquetClassLibrary.Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') | The upper left corner of the rectangle. |
| inLowerRight | [ParquetClassLibrary.Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') | The lower right corner of the rectangle. |
| inIsValid | [System.Predicate{ParquetClassLibrary.Vector2D}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Predicate 'System.Predicate{ParquetClassLibrary.Vector2D}') | Tests if plotted points are useable in their intended domain. |

<a name='M-ParquetClassLibrary-Utilities-Rasterization-PlotFilledRectangle-ParquetClassLibrary-Vector2D,ParquetClassLibrary-Vector2D,System-Predicate{ParquetClassLibrary-Vector2D}-'></a>
### PlotFilledRectangle(inUpperLeft,inLowerRight,inIsValid) `method`

##### Summary

Plots a rectangular region including all points contained on and within the rectanle.

##### Returns

The filled rectangle.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inUpperLeft | [ParquetClassLibrary.Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') | The upper left corner of the rectangle. |
| inLowerRight | [ParquetClassLibrary.Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') | The lower right corner of the rectangle. |
| inIsValid | [System.Predicate{ParquetClassLibrary.Vector2D}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Predicate 'System.Predicate{ParquetClassLibrary.Vector2D}') | Tests if plotted points are useable in their intended domain. |

<a name='M-ParquetClassLibrary-Utilities-Rasterization-PlotFloodFill``1-ParquetClassLibrary-Vector2D,``0,System-Predicate{ParquetClassLibrary-Vector2D},System-Func{ParquetClassLibrary-Vector2D,``0,System-Boolean}-'></a>
### PlotFloodFill\`\`1(inStart,inTarget,inIsValid,inMatches) `method`

##### Summary

Plots a contiguous section of the positions using a four-way flood fill.
Plots all valid positions adjacent to the given position, provided that they match
the parquets at the given position according to the provided matching criteria.

##### Returns

A selection of contiguous positions.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inStart | [ParquetClassLibrary.Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') | The position on which to base the fill. |
| inTarget | [\`\`0](#T-``0 '``0') | The element to replace. |
| inIsValid | [System.Predicate{ParquetClassLibrary.Vector2D}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Predicate 'System.Predicate{ParquetClassLibrary.Vector2D}') | In rule for determining a valid position. |
| inMatches | [System.Func{ParquetClassLibrary.Vector2D,\`\`0,System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{ParquetClassLibrary.Vector2D,``0,System.Boolean}') | The rule for determining matching parquets. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TTarget | The type of the target element. |

<a name='M-ParquetClassLibrary-Utilities-Rasterization-PlotLine-ParquetClassLibrary-Vector2D,ParquetClassLibrary-Vector2D,System-Predicate{ParquetClassLibrary-Vector2D}-'></a>
### PlotLine(inStart,inEend,inIsValid) `method`

##### Summary

Approximates a line segment between two positions.

##### Returns

The line segment.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inStart | [ParquetClassLibrary.Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') | One end of the line segment. |
| inEend | [ParquetClassLibrary.Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') | The other end of the line segment. |
| inIsValid | [System.Predicate{ParquetClassLibrary.Vector2D}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Predicate 'System.Predicate{ParquetClassLibrary.Vector2D}') | Tests if plotted points are useable in their intended domain. |

<a name='T-ParquetClassLibrary-RecipeElement'></a>
## RecipeElement `type`

##### Namespace

ParquetClassLibrary

##### Summary

Models the category and amount of a [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') from a recipe, e.g. [CraftingRecipe](#T-ParquetClassLibrary-Crafts-CraftingRecipe 'ParquetClassLibrary.Crafts.CraftingRecipe')
or [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe').  The [RecipeElement](#T-ParquetClassLibrary-RecipeElement 'ParquetClassLibrary.RecipeElement') may either be consumed as an ingredient
or returned as the final product.

##### Remarks

The pairing of ElementTag with an ElementAmount achieves two ends:
- It allows multiple element instances to be required without storing and counting multiple objects representing that element.
- It allows various Models to be used interchangably for the same recipe purpose; see [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag').

<a name='M-ParquetClassLibrary-RecipeElement-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes an empty instance of [RecipeElement](#T-ParquetClassLibrary-RecipeElement 'ParquetClassLibrary.RecipeElement') with default values.

##### Parameters

This constructor has no parameters.

##### Remarks

Useful primarily in the context of serialization.

<a name='M-ParquetClassLibrary-RecipeElement-#ctor-System-Int32,ParquetClassLibrary-ModelTag-'></a>
### #ctor(inElementAmount,inElementTag) `constructor`

##### Summary

Initializes a new instance of the [RecipeElement](#T-ParquetClassLibrary-RecipeElement 'ParquetClassLibrary.RecipeElement') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inElementAmount | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The amount of the element.  Must be positive. |
| inElementTag | [ParquetClassLibrary.ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag') | A [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag') describing the element. |

<a name='F-ParquetClassLibrary-RecipeElement-None'></a>
### None `constants`

##### Summary

Indicates the lack of any [RecipeElement](#T-ParquetClassLibrary-RecipeElement 'ParquetClassLibrary.RecipeElement')s.

<a name='P-ParquetClassLibrary-RecipeElement-ConverterFactory'></a>
### ConverterFactory `property`

##### Summary

Allows the converter to construct itself statically.

<a name='P-ParquetClassLibrary-RecipeElement-ElementAmount'></a>
### ElementAmount `property`

##### Summary

The number of [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel')s.

<a name='P-ParquetClassLibrary-RecipeElement-ElementTag'></a>
### ElementTag `property`

##### Summary

A [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag') describing the [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel').

<a name='M-ParquetClassLibrary-RecipeElement-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData-'></a>
### ConvertFromString(inText,inRow,inMemberMapData) `method`

##### Summary

Converts the given record column to [RecipeElement](#T-ParquetClassLibrary-RecipeElement 'ParquetClassLibrary.RecipeElement').

##### Returns

The [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag') created from the record column.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inText | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The record column to convert to an object. |
| inRow | [CsvHelper.IReaderRow](#T-CsvHelper-IReaderRow 'CsvHelper.IReaderRow') | The [IReaderRow](#T-CsvHelper-IReaderRow 'CsvHelper.IReaderRow') for the current record. |
| inMemberMapData | [CsvHelper.Configuration.MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') | The [MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') for the member being created. |

<a name='M-ParquetClassLibrary-RecipeElement-ConvertToString-System-Object,CsvHelper-IWriterRow,CsvHelper-Configuration-MemberMapData-'></a>
### ConvertToString(inValue,inRow,inMemberMapData) `method`

##### Summary

Converts the given [RecipeElement](#T-ParquetClassLibrary-RecipeElement 'ParquetClassLibrary.RecipeElement') to a record column.

##### Returns

The [RecipeElement](#T-ParquetClassLibrary-RecipeElement 'ParquetClassLibrary.RecipeElement') as a CSV record.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inValue | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The instance to convert. |
| inRow | [CsvHelper.IWriterRow](#T-CsvHelper-IWriterRow 'CsvHelper.IWriterRow') | The [IReaderRow](#T-CsvHelper-IReaderRow 'CsvHelper.IReaderRow') for the current record. |
| inMemberMapData | [CsvHelper.Configuration.MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') | The [MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') for the member being serialized. |

<a name='M-ParquetClassLibrary-RecipeElement-Equals-ParquetClassLibrary-RecipeElement-'></a>
### Equals(inElement) `method`

##### Summary

Determines whether the specified [RecipeElement](#T-ParquetClassLibrary-RecipeElement 'ParquetClassLibrary.RecipeElement') is equal to the current [RecipeElement](#T-ParquetClassLibrary-RecipeElement 'ParquetClassLibrary.RecipeElement').

##### Returns

`true` if they are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inElement | [ParquetClassLibrary.RecipeElement](#T-ParquetClassLibrary-RecipeElement 'ParquetClassLibrary.RecipeElement') | The [RecipeElement](#T-ParquetClassLibrary-RecipeElement 'ParquetClassLibrary.RecipeElement') to compare with the current. |

<a name='M-ParquetClassLibrary-RecipeElement-Equals-System-Object-'></a>
### Equals(obj) `method`

##### Summary

Determines whether the specified [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') is equal to the current [RecipeElement](#T-ParquetClassLibrary-RecipeElement 'ParquetClassLibrary.RecipeElement').

##### Returns

`true` if they are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') to compare with the current [RecipeElement](#T-ParquetClassLibrary-RecipeElement 'ParquetClassLibrary.RecipeElement'). |

<a name='M-ParquetClassLibrary-RecipeElement-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Serves as a hash function for a [RecipeElement](#T-ParquetClassLibrary-RecipeElement 'ParquetClassLibrary.RecipeElement').

##### Returns

A hash code for this instance that is suitable for use in hashing algorithms and data structures.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-RecipeElement-ToString'></a>
### ToString() `method`

##### Summary

Returns a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents the current [RecipeElement](#T-ParquetClassLibrary-RecipeElement 'ParquetClassLibrary.RecipeElement').

##### Returns

The representation.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-RecipeElement-op_Equality-ParquetClassLibrary-RecipeElement,ParquetClassLibrary-RecipeElement-'></a>
### op_Equality(inElement1,inElement2) `method`

##### Summary

Determines whether a specified instance of [RecipeElement](#T-ParquetClassLibrary-RecipeElement 'ParquetClassLibrary.RecipeElement') is equal to another specified instance of [RecipeElement](#T-ParquetClassLibrary-RecipeElement 'ParquetClassLibrary.RecipeElement').

##### Returns

`true` if they are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inElement1 | [ParquetClassLibrary.RecipeElement](#T-ParquetClassLibrary-RecipeElement 'ParquetClassLibrary.RecipeElement') | The first [RecipeElement](#T-ParquetClassLibrary-RecipeElement 'ParquetClassLibrary.RecipeElement') to compare. |
| inElement2 | [ParquetClassLibrary.RecipeElement](#T-ParquetClassLibrary-RecipeElement 'ParquetClassLibrary.RecipeElement') | The second [RecipeElement](#T-ParquetClassLibrary-RecipeElement 'ParquetClassLibrary.RecipeElement') to compare. |

<a name='M-ParquetClassLibrary-RecipeElement-op_Inequality-ParquetClassLibrary-RecipeElement,ParquetClassLibrary-RecipeElement-'></a>
### op_Inequality(inElement1,inElement2) `method`

##### Summary

Determines whether a specified instance of [RecipeElement](#T-ParquetClassLibrary-RecipeElement 'ParquetClassLibrary.RecipeElement') is not equal to another specified instance of [RecipeElement](#T-ParquetClassLibrary-RecipeElement 'ParquetClassLibrary.RecipeElement').

##### Returns

`true` if they are NOT equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inElement1 | [ParquetClassLibrary.RecipeElement](#T-ParquetClassLibrary-RecipeElement 'ParquetClassLibrary.RecipeElement') | The first [RecipeElement](#T-ParquetClassLibrary-RecipeElement 'ParquetClassLibrary.RecipeElement') to compare. |
| inElement2 | [ParquetClassLibrary.RecipeElement](#T-ParquetClassLibrary-RecipeElement 'ParquetClassLibrary.RecipeElement') | The second [RecipeElement](#T-ParquetClassLibrary-RecipeElement 'ParquetClassLibrary.RecipeElement') to compare. |

<a name='T-ParquetClassLibrary-Rules-Recipes'></a>
## Recipes `type`

##### Namespace

ParquetClassLibrary.Rules

##### Summary

Provides recipe requirements for the game.

<a name='T-ParquetClassLibrary-Properties-Resources'></a>
## Resources `type`

##### Namespace

ParquetClassLibrary.Properties

##### Summary

A strongly-typed resource class, for looking up localized strings, etc.

<a name='P-ParquetClassLibrary-Properties-Resources-Culture'></a>
### Culture `property`

##### Summary

Overrides the current thread's CurrentUICulture property for all
  resource lookups using this strongly typed resource class.

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorCannotConvert'></a>
### ErrorCannotConvert `property`

##### Summary

Looks up a localized string similar to Could not convert '{1}' to {2}..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorCannotParse'></a>
### ErrorCannotParse `property`

##### Summary

Looks up a localized string similar to Could not parse '{1}' as {2}..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorInvalidCast'></a>
### ErrorInvalidCast `property`

##### Summary

Looks up a localized string similar to {1} is of type {2} but must be of type {3}..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorInvalidPosition'></a>
### ErrorInvalidPosition `property`

##### Summary

Looks up a localized string similar to Invalid position: {1} is not within {2}..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorModelNotFound'></a>
### ErrorModelNotFound `property`

##### Summary

Looks up a localized string similar to No model of type {1} exists for ID {2}..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorMustBeNonNegative'></a>
### ErrorMustBeNonNegative `property`

##### Summary

Looks up a localized string similar to {1} must be a non-negative number..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorMustBePositive'></a>
### ErrorMustBePositive `property`

##### Summary

Looks up a localized string similar to {1} must be a positive number..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorMustNotBeEmpty'></a>
### ErrorMustNotBeEmpty `property`

##### Summary

Looks up a localized string similar to {1} cannot be empty..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorMustNotBeNone'></a>
### ErrorMustNotBeNone `property`

##### Summary

Looks up a localized string similar to {1} cannot be None..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorMustNotBeNull'></a>
### ErrorMustNotBeNull `property`

##### Summary

Looks up a localized string similar to {1} cannot be null..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorMustNotBeNullEmpty'></a>
### ErrorMustNotBeNullEmpty `property`

##### Summary

Looks up a localized string similar to {1} cannot be null or empty..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorNoExitFound'></a>
### ErrorNoExitFound `property`

##### Summary

Looks up a localized string similar to No entry/exit found in {1} or {2}..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorOutOfBounds'></a>
### ErrorOutOfBounds `property`

##### Summary

Looks up a localized string similar to {1}: {2} is not within {3}..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorOutOfOrder'></a>
### ErrorOutOfOrder `property`

##### Summary

Looks up a localized string similar to {1} must be less than or equal to {2}..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorUngenerated'></a>
### ErrorUngenerated `property`

##### Summary

Looks up a localized string similar to Cannot access {1} on ungenerated {2}..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorUnsupportedDimension'></a>
### ErrorUnsupportedDimension `property`

##### Summary

Looks up a localized string similar to Dimension outside specification: {1}.

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorUnsupportedDuplicate'></a>
### ErrorUnsupportedDuplicate `property`

##### Summary

Looks up a localized string similar to Tried to duplicate {1} {2}..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorUnsupportedNode'></a>
### ErrorUnsupportedNode `property`

##### Summary

Looks up a localized string similar to Unsupported {1} node {2}..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorUnsupportedSerialization'></a>
### ErrorUnsupportedSerialization `property`

##### Summary

Looks up a localized string similar to Serializing or deserializing {1} is not yet supported..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorUornsupportedVersion'></a>
### ErrorUornsupportedVersion `property`

##### Summary

Looks up a localized string similar to Unsupported {1} version {2}..

<a name='P-ParquetClassLibrary-Properties-Resources-ResourceManager'></a>
### ResourceManager `property`

##### Summary

Returns the cached ResourceManager instance used by this class.

<a name='P-ParquetClassLibrary-Properties-Resources-WarningTriedToGiveNothing'></a>
### WarningTriedToGiveNothing `property`

##### Summary

Looks up a localized string similar to Tried to give {1} to {2}..

<a name='P-ParquetClassLibrary-Properties-Resources-WarningTriedToStoreNothing'></a>
### WarningTriedToStoreNothing `property`

##### Summary

Looks up a localized string similar to Tried to store {1} in {2}..

<a name='T-ParquetClassLibrary-Rooms-Room'></a>
## Room `type`

##### Namespace

ParquetClassLibrary.Rooms

##### Summary

Models the a constructed [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room').

<a name='T-ParquetClassLibrary-Rules-Recipes-Room'></a>
## Room `type`

##### Namespace

ParquetClassLibrary.Rules.Recipes

##### Summary

Provides room recipe requirements for the game.

<a name='M-ParquetClassLibrary-Rooms-Room-#ctor-ParquetClassLibrary-Rooms-MapSpaceCollection,ParquetClassLibrary-Rooms-MapSpaceCollection-'></a>
### #ctor(inWalkableArea,inPerimeter) `constructor`

##### Summary

Initializes a new instance of the [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inWalkableArea | [ParquetClassLibrary.Rooms.MapSpaceCollection](#T-ParquetClassLibrary-Rooms-MapSpaceCollection 'ParquetClassLibrary.Rooms.MapSpaceCollection') | The [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace')s on which a [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel')
may walk within this [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room'). |
| inPerimeter | [ParquetClassLibrary.Rooms.MapSpaceCollection](#T-ParquetClassLibrary-Rooms-MapSpaceCollection 'ParquetClassLibrary.Rooms.MapSpaceCollection') | The [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace')s whose [BlockModel](#T-ParquetClassLibrary-Parquets-BlockModel 'ParquetClassLibrary.Parquets.BlockModel')s and [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel')s
define the limits of this [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room'). |

<a name='F-ParquetClassLibrary-Rules-Recipes-Room-MaxWalkableSpaces'></a>
### MaxWalkableSpaces `constants`

##### Summary

Maximum number of open walkable spaces needed for any room to register.

<a name='F-ParquetClassLibrary-Rules-Recipes-Room-MinPerimeterSpaces'></a>
### MinPerimeterSpaces `constants`

##### Summary

Minimum number of enclosing spaces needed for any room to register.

<a name='F-ParquetClassLibrary-Rules-Recipes-Room-MinWalkableSpaces'></a>
### MinWalkableSpaces `constants`

##### Summary

Minimum number of open walkable spaces needed for any room to register.

<a name='P-ParquetClassLibrary-Rooms-Room-FurnishingTags'></a>
### FurnishingTags `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s for every [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') found in this [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room')
together with the number of times that furnishing occurs.

<a name='P-ParquetClassLibrary-Rooms-Room-Perimeter'></a>
### Perimeter `property`

##### Summary

The [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace')s whose [BlockModel](#T-ParquetClassLibrary-Parquets-BlockModel 'ParquetClassLibrary.Parquets.BlockModel')s and [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel')s
define the limits of this [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room').

<a name='P-ParquetClassLibrary-Rooms-Room-Position'></a>
### Position `property`

##### Summary

A location with the least X and Y coordinates of every [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace') in this [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room').

##### Remarks

This location could server as a the upper, left point of a bounding rectangle entirely containing the room.

<a name='P-ParquetClassLibrary-Rooms-Room-RecipeID'></a>
### RecipeID `property`

##### Summary

The [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe') that this [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') matches.

<a name='P-ParquetClassLibrary-Rooms-Room-WalkableArea'></a>
### WalkableArea `property`

##### Summary

The [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace')s on which a [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel')
may walk within this [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room').

<a name='M-ParquetClassLibrary-Rooms-Room-ContainsPosition-ParquetClassLibrary-Vector2D-'></a>
### ContainsPosition(inPosition) `method`

##### Summary

Determines whether or not the given position is included in this [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room').

##### Returns

`true`, if the position was containsed, `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inPosition | [ParquetClassLibrary.Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') | The position to check for. |

<a name='M-ParquetClassLibrary-Rooms-Room-Equals-ParquetClassLibrary-Rooms-Room-'></a>
### Equals(inRoom) `method`

##### Summary

Determines whether the specified [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') is equal to the current [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room').

##### Returns

`true` if they are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inRoom | [ParquetClassLibrary.Rooms.Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') | The [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') to compare with the current. |

<a name='M-ParquetClassLibrary-Rooms-Room-Equals-System-Object-'></a>
### Equals(obj) `method`

##### Summary

Determines whether the specified [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') is equal to the current [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room').

##### Returns

`true` if they are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') to compare with the current [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room'). |

<a name='M-ParquetClassLibrary-Rooms-Room-FindBestMatch'></a>
### FindBestMatch() `method`

##### Summary

Finds the [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe') that best matches this [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room').

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Rooms-Room-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Serves as a hash function for a [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room').

##### Returns

A hash code for this instance that is suitable for use in hashing algorithms and data structures.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Rooms-Room-op_Equality-ParquetClassLibrary-Rooms-Room,ParquetClassLibrary-Rooms-Room-'></a>
### op_Equality(inRoom1,inRoom2) `method`

##### Summary

Determines whether a specified instance of [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') is equal to another specified instance of [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room').

##### Returns

`true` if they are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inRoom1 | [ParquetClassLibrary.Rooms.Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') | The first [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') to compare. |
| inRoom2 | [ParquetClassLibrary.Rooms.Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') | The second [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') to compare. |

<a name='M-ParquetClassLibrary-Rooms-Room-op_Inequality-ParquetClassLibrary-Rooms-Room,ParquetClassLibrary-Rooms-Room-'></a>
### op_Inequality(inRoom1,inRoom2) `method`

##### Summary

Determines whether a specified instance of [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') is not equal to another specified instance of [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room').

##### Returns

`true` if they are NOT equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inRoom1 | [ParquetClassLibrary.Rooms.Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') | The first [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') to compare. |
| inRoom2 | [ParquetClassLibrary.Rooms.Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') | The second [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') to compare. |

<a name='T-ParquetClassLibrary-Rooms-RoomCollection'></a>
## RoomCollection `type`

##### Namespace

ParquetClassLibrary.Rooms

##### Summary

Stores a [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') collection.
Analyzes subregions of [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack')s to find all valid rooms within them.

##### Remarks

For a complete explanation of the algorithm implemented here, see:

<a name='M-ParquetClassLibrary-Rooms-RoomCollection-#ctor-System-Collections-Generic-IEnumerable{ParquetClassLibrary-Rooms-Room}-'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [RoomCollection](#T-ParquetClassLibrary-Rooms-RoomCollection 'ParquetClassLibrary.Rooms.RoomCollection') class.

##### Parameters

This constructor has no parameters.

##### Remarks

Private so that empty [RoomCollection](#T-ParquetClassLibrary-Rooms-RoomCollection 'ParquetClassLibrary.Rooms.RoomCollection')s are not made in client code.

<a name='P-ParquetClassLibrary-Rooms-RoomCollection-Count'></a>
### Count `property`

##### Summary

The number of [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room')s in the [RoomCollection](#T-ParquetClassLibrary-Rooms-RoomCollection 'ParquetClassLibrary.Rooms.RoomCollection').

<a name='P-ParquetClassLibrary-Rooms-RoomCollection-Rooms'></a>
### Rooms `property`

##### Summary

The internal collection mechanism.

<a name='M-ParquetClassLibrary-Rooms-RoomCollection-Contains-ParquetClassLibrary-Rooms-Room-'></a>
### Contains(inRoom) `method`

##### Summary

Determines whether the [RoomCollection](#T-ParquetClassLibrary-Rooms-RoomCollection 'ParquetClassLibrary.Rooms.RoomCollection') contains the specified [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room').

##### Returns

`true` if the [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') was found; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inRoom | [ParquetClassLibrary.Rooms.Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') | The [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') to find. |

<a name='M-ParquetClassLibrary-Rooms-RoomCollection-CreateFromSubregion-ParquetClassLibrary-Parquets-ParquetStackGrid-'></a>
### CreateFromSubregion(inSubregion) `method`

##### Summary

Initializes a new instance of the [RoomCollection](#T-ParquetClassLibrary-Rooms-RoomCollection 'ParquetClassLibrary.Rooms.RoomCollection') class.

##### Returns

An initialized [RoomCollection](#T-ParquetClassLibrary-Rooms-RoomCollection 'ParquetClassLibrary.Rooms.RoomCollection').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inSubregion | [ParquetClassLibrary.Parquets.ParquetStackGrid](#T-ParquetClassLibrary-Parquets-ParquetStackGrid 'ParquetClassLibrary.Parquets.ParquetStackGrid') | The collection of parquets to search for [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room')s. |

<a name='M-ParquetClassLibrary-Rooms-RoomCollection-GetEnumerator'></a>
### GetEnumerator() `method`

##### Summary

Retrieves an enumerator for the [RoomCollection](#T-ParquetClassLibrary-Rooms-RoomCollection 'ParquetClassLibrary.Rooms.RoomCollection').

##### Returns

An enumerator that iterates through the collection.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Rooms-RoomCollection-GetRoomAt-ParquetClassLibrary-Vector2D-'></a>
### GetRoomAt(inPosition) `method`

##### Summary

Returns the [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') at the given position, if there is one.

##### Returns

The specified [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') if found; otherwise, null.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inPosition | [ParquetClassLibrary.Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') | An in-bounds position to search for a [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room'). |

<a name='M-ParquetClassLibrary-Rooms-RoomCollection-System#Collections#IEnumerable#GetEnumerator'></a>
### System#Collections#IEnumerable#GetEnumerator() `method`

##### Summary

Exposes an [IEnumerator](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.IEnumerator 'System.Collections.IEnumerator'), which supports simple iteration.

##### Returns

An enumerator.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Rooms-RoomCollection-ToString'></a>
### ToString() `method`

##### Summary

Returns a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents the current [RoomCollection](#T-ParquetClassLibrary-Rooms-RoomCollection 'ParquetClassLibrary.Rooms.RoomCollection').

##### Returns

The representation.

##### Parameters

This method has no parameters.

<a name='T-ParquetClassLibrary-Rooms-RoomRecipe'></a>
## RoomRecipe `type`

##### Namespace

ParquetClassLibrary.Rooms

##### Summary

Models the minimum requirements for a [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') to be recognizable and useful.

<a name='M-ParquetClassLibrary-Rooms-RoomRecipe-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Int32,System-Collections-Generic-IEnumerable{ParquetClassLibrary-RecipeElement},System-Collections-Generic-IEnumerable{ParquetClassLibrary-RecipeElement},System-Collections-Generic-IEnumerable{ParquetClassLibrary-RecipeElement}-'></a>
### #ctor(inID,inName,inDescription,inComment,inMinimumWalkableSpaces,inOptionallyRequiredFurnishings,inOptionallyRequiredWalkableFloors,inOptionallyRequiredPerimeterBlocks) `constructor`

##### Summary

Initializes a new instance of the [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | Unique identifier for the [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe').  Cannot be null. |
| inName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly name of the [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe'). |
| inDescription | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly description of the [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe'). |
| inComment | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Comment of, on, or by the [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe'). |
| inMinimumWalkableSpaces | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The minimum number of walkable [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace')s required by this [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe'). |
| inOptionallyRequiredFurnishings | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.RecipeElement}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.RecipeElement}') | An optional list of furnishing categories this [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe') requires. |
| inOptionallyRequiredWalkableFloors | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.RecipeElement}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.RecipeElement}') | An optional list of floor categories this [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe') requires. |
| inOptionallyRequiredPerimeterBlocks | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.RecipeElement}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.RecipeElement}') | An optional list of block categories this [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe') requires as walls. |

<a name='P-ParquetClassLibrary-Rooms-RoomRecipe-MinimumWalkableSpaces'></a>
### MinimumWalkableSpaces `property`

##### Summary

Minimum number of open spaces needed for this [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe') to register.

<a name='P-ParquetClassLibrary-Rooms-RoomRecipe-OptionallyRequiredFurnishings'></a>
### OptionallyRequiredFurnishings `property`

##### Summary

A list of [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') categories this [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe') requires.

<a name='P-ParquetClassLibrary-Rooms-RoomRecipe-OptionallyRequiredPerimeterBlocks'></a>
### OptionallyRequiredPerimeterBlocks `property`

##### Summary

An optional list of [BlockModel](#T-ParquetClassLibrary-Parquets-BlockModel 'ParquetClassLibrary.Parquets.BlockModel') categories this [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe') requires as walls.

<a name='P-ParquetClassLibrary-Rooms-RoomRecipe-OptionallyRequiredWalkableFloors'></a>
### OptionallyRequiredWalkableFloors `property`

##### Summary

An optional list of [FloorModel](#T-ParquetClassLibrary-Parquets-FloorModel 'ParquetClassLibrary.Parquets.FloorModel') categories this [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe') requires.

<a name='P-ParquetClassLibrary-Rooms-RoomRecipe-Priority'></a>
### Priority `property`

##### Summary

A measure of the stringency of this [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe')'s requirements.
If a [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') corresponds to multiple recipes' requirements,
the room is asigned the type of the most demanding recipe.

<a name='M-ParquetClassLibrary-Rooms-RoomRecipe-Matches-ParquetClassLibrary-Rooms-Room-'></a>
### Matches(inRoom) `method`

##### Summary

Determines if the given [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') conforms to this [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe').

##### Returns

`ture` if `inRoom` is an instance of this [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe');
`false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inRoom | [ParquetClassLibrary.Rooms.Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') | The [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') to check. |

<a name='T-ParquetClassLibrary-Rules'></a>
## Rules `type`

##### Namespace

ParquetClassLibrary

##### Summary

Provides rules, dimensions, and parameters for the game.

<a name='T-ParquetClassLibrary-Scripts-RunState'></a>
## RunState `type`

##### Namespace

ParquetClassLibrary.Scripts

##### Summary

Status of a [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel') in an [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel').

<a name='F-ParquetClassLibrary-Scripts-RunState-Completed'></a>
### Completed `constants`

##### Summary

This script is completed execution.

<a name='F-ParquetClassLibrary-Scripts-RunState-InProgress'></a>
### InProgress `constants`

##### Summary

This script is currently executing.

<a name='F-ParquetClassLibrary-Scripts-RunState-Unstarted'></a>
### Unstarted `constants`

##### Summary

This script has not yet begun execution.

<a name='T-ParquetClassLibrary-Scripts-ScriptModel'></a>
## ScriptModel `type`

##### Namespace

ParquetClassLibrary.Scripts

##### Summary

Models a series of imperative, procedural commands.

<a name='M-ParquetClassLibrary-Scripts-ScriptModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Collections-Generic-IEnumerable{ParquetClassLibrary-Scripts-ScriptNode}-'></a>
### #ctor(inID,inName,inDescription,inComment,inNodes) `constructor`

##### Summary

Initializes a new instance of the [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | Unique identifier for the [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel').  Cannot be null. |
| inName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly name of the [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel').  Cannot be null or empty. |
| inDescription | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly description of the [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel'). |
| inComment | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Comment of, on, or by the [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel'). |
| inNodes | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Scripts.ScriptNode}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Scripts.ScriptNode}') | Describes the criteria for completing this [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel'). |

<a name='P-ParquetClassLibrary-Scripts-ScriptModel-Nodes'></a>
### Nodes `property`

##### Summary

A series of imperative, procedural commands.

<a name='M-ParquetClassLibrary-Scripts-ScriptModel-GetActions'></a>
### GetActions() `method`

##### Summary

Yields an [Action](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action') for each [ScriptNode](#T-ParquetClassLibrary-Scripts-ScriptNode 'ParquetClassLibrary.Scripts.ScriptNode'), in order.

##### Returns

The action to perform for the current node.

##### Parameters

This method has no parameters.

<a name='T-ParquetClassLibrary-Scripts-ScriptNode'></a>
## ScriptNode `type`

##### Namespace

ParquetClassLibrary.Scripts

##### Summary

Models the an element within a scripted element of gameplay.
For example, a precondition, postcondition, or step in an [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel')
or the effect of an [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel').

<a name='F-ParquetClassLibrary-Scripts-ScriptNode-None'></a>
### None `constants`

##### Summary

Indicates the lack of any [ScriptNode](#T-ParquetClassLibrary-Scripts-ScriptNode 'ParquetClassLibrary.Scripts.ScriptNode')s.

<a name='F-ParquetClassLibrary-Scripts-ScriptNode-nodeContent'></a>
### nodeContent `constants`

##### Summary

Backing type for the [ScriptNode](#T-ParquetClassLibrary-Scripts-ScriptNode 'ParquetClassLibrary.Scripts.ScriptNode').

<a name='P-ParquetClassLibrary-Scripts-ScriptNode-ConverterFactory'></a>
### ConverterFactory `property`

##### Summary

Allows the converter to construct itself statically.

<a name='M-ParquetClassLibrary-Scripts-ScriptNode-CompareTo-ParquetClassLibrary-Scripts-ScriptNode-'></a>
### CompareTo(inTag) `method`

##### Summary

Enables [ScriptNode](#T-ParquetClassLibrary-Scripts-ScriptNode 'ParquetClassLibrary.Scripts.ScriptNode')s to be compared one another.

##### Returns

A value indicating the relative ordering of the [ScriptNode](#T-ParquetClassLibrary-Scripts-ScriptNode 'ParquetClassLibrary.Scripts.ScriptNode')s being compared.
The return value has these meanings:
    Less than zero indicates that the current instance precedes the given [ScriptNode](#T-ParquetClassLibrary-Scripts-ScriptNode 'ParquetClassLibrary.Scripts.ScriptNode') in the sort order.
    Zero indicates that the current instance occurs in the same position in the sort order as the given [ScriptNode](#T-ParquetClassLibrary-Scripts-ScriptNode 'ParquetClassLibrary.Scripts.ScriptNode').
    Greater than zero indicates that the current instance follows the given [ScriptNode](#T-ParquetClassLibrary-Scripts-ScriptNode 'ParquetClassLibrary.Scripts.ScriptNode') in the sort order.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inTag | [ParquetClassLibrary.Scripts.ScriptNode](#T-ParquetClassLibrary-Scripts-ScriptNode 'ParquetClassLibrary.Scripts.ScriptNode') | Any valid [ScriptNode](#T-ParquetClassLibrary-Scripts-ScriptNode 'ParquetClassLibrary.Scripts.ScriptNode'). |

<a name='M-ParquetClassLibrary-Scripts-ScriptNode-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData-'></a>
### ConvertFromString(inText,inRow,inMemberMapData) `method`

##### Summary

Converts the given [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') to a [ScriptNode](#T-ParquetClassLibrary-Scripts-ScriptNode 'ParquetClassLibrary.Scripts.ScriptNode').

##### Returns

The [ScriptNode](#T-ParquetClassLibrary-Scripts-ScriptNode 'ParquetClassLibrary.Scripts.ScriptNode') created from the [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inText | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') to convert to an object. |
| inRow | [CsvHelper.IReaderRow](#T-CsvHelper-IReaderRow 'CsvHelper.IReaderRow') | The [IReaderRow](#T-CsvHelper-IReaderRow 'CsvHelper.IReaderRow') for the current record. |
| inMemberMapData | [CsvHelper.Configuration.MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') | The [MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') for the member being created. |

<a name='M-ParquetClassLibrary-Scripts-ScriptNode-ConvertToString-System-Object,CsvHelper-IWriterRow,CsvHelper-Configuration-MemberMapData-'></a>
### ConvertToString(inValue,inRow,inMemberMapData) `method`

##### Summary

Converts the given [ScriptNode](#T-ParquetClassLibrary-Scripts-ScriptNode 'ParquetClassLibrary.Scripts.ScriptNode') to a record column.

##### Returns

The [ScriptNode](#T-ParquetClassLibrary-Scripts-ScriptNode 'ParquetClassLibrary.Scripts.ScriptNode') as a CSV record.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inValue | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The instance to convert. |
| inRow | [CsvHelper.IWriterRow](#T-CsvHelper-IWriterRow 'CsvHelper.IWriterRow') | The [IReaderRow](#T-CsvHelper-IReaderRow 'CsvHelper.IReaderRow') for the current record. |
| inMemberMapData | [CsvHelper.Configuration.MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') | The [MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') for the member being serialized. |

<a name='M-ParquetClassLibrary-Scripts-ScriptNode-GetAction'></a>
### GetAction() `method`

##### Summary

Transforms the [ScriptNode](#T-ParquetClassLibrary-Scripts-ScriptNode 'ParquetClassLibrary.Scripts.ScriptNode') into an [Action](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action') to be invoked.

##### Returns

The action to perform.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Scripts-ScriptNode-ParseCommand-System-String,System-String,System-String-'></a>
### ParseCommand(inCommandText,inSourceText,inTargetText) `method`

##### Summary

Transforms the given texts into an [Action](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action') to be invoked.

##### Returns

The action to perform.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inCommandText | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the command. |
| inSourceText | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The source or subject of the command. |
| inTargetText | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The target or object of the command. |

<a name='M-ParquetClassLibrary-Scripts-ScriptNode-ToString'></a>
### ToString() `method`

##### Summary

Returns a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents the current [ScriptNode](#T-ParquetClassLibrary-Scripts-ScriptNode 'ParquetClassLibrary.Scripts.ScriptNode').

##### Returns

The representation.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Scripts-ScriptNode-op_Implicit-System-String-~ParquetClassLibrary-Scripts-ScriptNode'></a>
### op_Implicit(inValue) `method`

##### Summary

Enables [ScriptNode](#T-ParquetClassLibrary-Scripts-ScriptNode 'ParquetClassLibrary.Scripts.ScriptNode')s to be treated as their backing type.

##### Returns

The given value as a tag.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inValue | [System.String)~ParquetClassLibrary.Scripts.ScriptNode](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String)~ParquetClassLibrary.Scripts.ScriptNode 'System.String)~ParquetClassLibrary.Scripts.ScriptNode') | Any valid tag value.  Invalid values will be sanitized. |

<a name='M-ParquetClassLibrary-Scripts-ScriptNode-op_Implicit-ParquetClassLibrary-Scripts-ScriptNode-~System-String'></a>
### op_Implicit(inNode) `method`

##### Summary

Enables [ScriptNode](#T-ParquetClassLibrary-Scripts-ScriptNode 'ParquetClassLibrary.Scripts.ScriptNode')s to be treated as their backing type.

##### Returns

The tag's value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inNode | [ParquetClassLibrary.Scripts.ScriptNode)~System.String](#T-ParquetClassLibrary-Scripts-ScriptNode-~System-String 'ParquetClassLibrary.Scripts.ScriptNode)~System.String') | Any tag. |

<a name='T-ParquetClassLibrary-Rooms-MapSpaceCollection-SearchResults'></a>
## SearchResults `type`

##### Namespace

ParquetClassLibrary.Rooms.MapSpaceCollection

##### Summary

Encapsulates the results of a graph search.

<a name='F-ParquetClassLibrary-Rooms-MapSpaceCollection-SearchResults-CycleFound'></a>
### CycleFound `constants`

##### Summary

`true` if a cycle was met during the search, `false` otherwise.

<a name='F-ParquetClassLibrary-Rooms-MapSpaceCollection-SearchResults-GoalFound'></a>
### GoalFound `constants`

##### Summary

`true` if the goal condition was met, `false` otherwise.

<a name='F-ParquetClassLibrary-Rooms-MapSpaceCollection-SearchResults-Visited'></a>
### Visited `constants`

##### Summary

A collection of all the [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace')s visited during the search.

<a name='T-ParquetClassLibrary-SeriesConverter`2'></a>
## SeriesConverter\`2 `type`

##### Namespace

ParquetClassLibrary

##### Summary

Type converter for any collection that implements [ICollection\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.ICollection`1 'System.Collections.Generic.ICollection`1').

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TElement | The type collected. |
| TCollection | The type of the collection. |

<a name='P-ParquetClassLibrary-SeriesConverter`2-ConverterFactory'></a>
### ConverterFactory `property`

##### Summary

Allows the converter to construct itself statically.

<a name='M-ParquetClassLibrary-SeriesConverter`2-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData-'></a>
### ConvertFromString(inText,inRow,inMemberMapData) `method`

##### Summary

Converts the given record column to a 1D collection.

##### Returns

The [ICollection\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.ICollection`1 'System.Collections.Generic.ICollection`1') created from the record column.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inText | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The record column to convert to an object. |
| inRow | [CsvHelper.IReaderRow](#T-CsvHelper-IReaderRow 'CsvHelper.IReaderRow') | The [IReaderRow](#T-CsvHelper-IReaderRow 'CsvHelper.IReaderRow') for the current record. |
| inMemberMapData | [CsvHelper.Configuration.MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') | The [MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') for the member being created. |

<a name='M-ParquetClassLibrary-SeriesConverter`2-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData,System-String-'></a>
### ConvertFromString(inText,inRow,inMemberMapData,inDelimiter) `method`

##### Summary

Converts the given record column to a 1D collection.

##### Returns

The [ICollection\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.ICollection`1 'System.Collections.Generic.ICollection`1') created from the record column.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inText | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The record column to convert to an object. |
| inRow | [CsvHelper.IReaderRow](#T-CsvHelper-IReaderRow 'CsvHelper.IReaderRow') | The [IReaderRow](#T-CsvHelper-IReaderRow 'CsvHelper.IReaderRow') for the current record. |
| inMemberMapData | [CsvHelper.Configuration.MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') | The [MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') for the member being created. |
| inDelimiter | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The string used to separate elements in the series. |

<a name='M-ParquetClassLibrary-SeriesConverter`2-ConvertToString-System-Object,CsvHelper-IWriterRow,CsvHelper-Configuration-MemberMapData-'></a>
### ConvertToString(inValue,inRow,inMemberMapData) `method`

##### Summary

Converts the given 1D collection into a record column.

##### Returns

The given collection serialized.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inValue | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The collection to convert. |
| inRow | [CsvHelper.IWriterRow](#T-CsvHelper-IWriterRow 'CsvHelper.IWriterRow') | The current context and configuration. |
| inMemberMapData | [CsvHelper.Configuration.MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') | Mapping info for a member to a CSV field or property. |

<a name='T-ParquetClassLibrary-Crafts-StrikePanel'></a>
## StrikePanel `type`

##### Namespace

ParquetClassLibrary.Crafts

##### Summary

Models the panels that the player must strike during item crafting.

<a name='M-ParquetClassLibrary-Crafts-StrikePanel-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel') class with default values.

##### Parameters

This constructor has no parameters.

<a name='M-ParquetClassLibrary-Crafts-StrikePanel-#ctor-ParquetClassLibrary-Range{System-Int32},ParquetClassLibrary-Range{System-Int32}-'></a>
### #ctor(inWorkingRange,inIdealRange) `constructor`

##### Summary

Initializes a new instance of the [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inWorkingRange | [ParquetClassLibrary.Range{System.Int32}](#T-ParquetClassLibrary-Range{System-Int32} 'ParquetClassLibrary.Range{System.Int32}') | The range of values this panel can take on while being worked. |
| inIdealRange | [ParquetClassLibrary.Range{System.Int32}](#T-ParquetClassLibrary-Range{System-Int32} 'ParquetClassLibrary.Range{System.Int32}') | The range of values this panel targets for a completed craft. |

<a name='F-ParquetClassLibrary-Crafts-StrikePanel-Unused'></a>
### Unused `constants`

##### Summary

Indicates an space in a [StrikePanelGrid](#T-ParquetClassLibrary-Crafts-StrikePanelGrid 'ParquetClassLibrary.Crafts.StrikePanelGrid').

<a name='F-ParquetClassLibrary-Crafts-StrikePanel-defaultIdealRange'></a>
### defaultIdealRange `constants`

##### Summary

Part of the definition for an [Unused](#F-ParquetClassLibrary-Crafts-StrikePanel-Unused 'ParquetClassLibrary.Crafts.StrikePanel.Unused') panel.

<a name='F-ParquetClassLibrary-Crafts-StrikePanel-defaultWorkingRange'></a>
### defaultWorkingRange `constants`

##### Summary

Part of the definition for an [Unused](#F-ParquetClassLibrary-Crafts-StrikePanel-Unused 'ParquetClassLibrary.Crafts.StrikePanel.Unused') panel.

<a name='F-ParquetClassLibrary-Crafts-StrikePanel-idealRangeBackingStruct'></a>
### idealRangeBackingStruct `constants`

##### Summary

Backing value for [IdealRange](#P-ParquetClassLibrary-Crafts-StrikePanel-IdealRange 'ParquetClassLibrary.Crafts.StrikePanel.IdealRange').

<a name='F-ParquetClassLibrary-Crafts-StrikePanel-workingRangeBackingStruct'></a>
### workingRangeBackingStruct `constants`

##### Summary

Backing value for [WorkingRange](#P-ParquetClassLibrary-Crafts-StrikePanel-WorkingRange 'ParquetClassLibrary.Crafts.StrikePanel.WorkingRange').

<a name='P-ParquetClassLibrary-Crafts-StrikePanel-ConverterFactory'></a>
### ConverterFactory `property`

##### Summary

Allows the converter to construct itself statically.

<a name='P-ParquetClassLibrary-Crafts-StrikePanel-IdealRange'></a>
### IdealRange `property`

##### Summary

The range of values this panel targets for a completed craft.
This range expands that given by [WorkingRange](#P-ParquetClassLibrary-Crafts-StrikePanel-WorkingRange 'ParquetClassLibrary.Crafts.StrikePanel.WorkingRange') if necessary.

<a name='P-ParquetClassLibrary-Crafts-StrikePanel-WorkingRange'></a>
### WorkingRange `property`

##### Summary

The range of values this panel can take on while being worked.  [Minimum](#P-ParquetClassLibrary-Range`1-Minimum 'ParquetClassLibrary.Range`1.Minimum') is normally 0.
This range constricts that given by [IdealRange](#P-ParquetClassLibrary-Crafts-StrikePanel-IdealRange 'ParquetClassLibrary.Crafts.StrikePanel.IdealRange').

<a name='M-ParquetClassLibrary-Crafts-StrikePanel-Clone'></a>
### Clone() `method`

##### Summary

Creates a new instance with the same characteristics as the current instance.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Crafts-StrikePanel-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData-'></a>
### ConvertFromString(inText,inRow,inMemberMapData) `method`

##### Summary

Converts the given [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') to a [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel').

##### Returns

The [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel') created from the [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inText | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') to convert to an object. |
| inRow | [CsvHelper.IReaderRow](#T-CsvHelper-IReaderRow 'CsvHelper.IReaderRow') | The [IReaderRow](#T-CsvHelper-IReaderRow 'CsvHelper.IReaderRow') for the current record. |
| inMemberMapData | [CsvHelper.Configuration.MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') | The [MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') for the member being created. |

<a name='M-ParquetClassLibrary-Crafts-StrikePanel-ConvertToString-System-Object,CsvHelper-IWriterRow,CsvHelper-Configuration-MemberMapData-'></a>
### ConvertToString(inValue,inRow,inMemberMapData) `method`

##### Summary

Converts the given [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel') to a record column.

##### Returns

The [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel') as a CSV record.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inValue | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The instance to convert. |
| inRow | [CsvHelper.IWriterRow](#T-CsvHelper-IWriterRow 'CsvHelper.IWriterRow') | The [IReaderRow](#T-CsvHelper-IReaderRow 'CsvHelper.IReaderRow') for the current record. |
| inMemberMapData | [CsvHelper.Configuration.MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') | The [MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') for the member being serialized. |

<a name='M-ParquetClassLibrary-Crafts-StrikePanel-Equals-ParquetClassLibrary-Crafts-StrikePanel-'></a>
### Equals(inStrikePanel) `method`

##### Summary

Determines whether the specified [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel') is equal to the current [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel').

##### Returns

`true` if they are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inStrikePanel | [ParquetClassLibrary.Crafts.StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel') | The [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel') to compare with the current. |

<a name='M-ParquetClassLibrary-Crafts-StrikePanel-Equals-System-Object-'></a>
### Equals(obj) `method`

##### Summary

Determines whether the specified [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') is equal to the current [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel').

##### Returns

`true` if they are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') to compare with the current [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel'). |

<a name='M-ParquetClassLibrary-Crafts-StrikePanel-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Serves as a hash function for a [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel').

##### Returns

A hash code for this instance that is suitable for use in hashing algorithms and data structures.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Crafts-StrikePanel-ToString'></a>
### ToString() `method`

##### Summary

Returns a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents the current [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel').

##### Returns

The representation.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Crafts-StrikePanel-op_Equality-ParquetClassLibrary-Crafts-StrikePanel,ParquetClassLibrary-Crafts-StrikePanel-'></a>
### op_Equality(inStrikePanel1,inStrikePanel2) `method`

##### Summary

Determines whether a specified instance of [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel') is equal to another specified instance of [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel').

##### Returns

`true` if they are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inStrikePanel1 | [ParquetClassLibrary.Crafts.StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel') | The first [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel') to compare. |
| inStrikePanel2 | [ParquetClassLibrary.Crafts.StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel') | The second [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel') to compare. |

<a name='M-ParquetClassLibrary-Crafts-StrikePanel-op_Inequality-ParquetClassLibrary-Crafts-StrikePanel,ParquetClassLibrary-Crafts-StrikePanel-'></a>
### op_Inequality(inStrikePanel1,inStrikePanel2) `method`

##### Summary

Determines whether a specified instance of [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel') is not equal to another specified instance of [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel').

##### Returns

`true` if they are NOT equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inStrikePanel1 | [ParquetClassLibrary.Crafts.StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel') | The first [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel') to compare. |
| inStrikePanel2 | [ParquetClassLibrary.Crafts.StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel') | The second [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel') to compare. |

<a name='T-ParquetClassLibrary-Crafts-StrikePanelArrayExtensions'></a>
## StrikePanelArrayExtensions `type`

##### Namespace

ParquetClassLibrary.Crafts

##### Summary

Provides extension methods useful when dealing with 2D arrays of [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel')s.

<a name='M-ParquetClassLibrary-Crafts-StrikePanelArrayExtensions-IsValidPosition-ParquetClassLibrary-Crafts-StrikePanel[0-,0-],ParquetClassLibrary-Vector2D-'></a>
### IsValidPosition(inStrikePanels,inPosition) `method`

##### Summary

Determines if the given position corresponds to a point within the current array.

##### Returns

`true`, if the position is valid, `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inStrikePanels | [ParquetClassLibrary.Crafts.StrikePanel[0:](#T-ParquetClassLibrary-Crafts-StrikePanel[0- 'ParquetClassLibrary.Crafts.StrikePanel[0:') | The [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel') to check against. |
| inPosition | [0:]](#T-0-] '0:]') | The position to validate. |

<a name='T-ParquetClassLibrary-Crafts-StrikePanelGrid'></a>
## StrikePanelGrid `type`

##### Namespace

ParquetClassLibrary.Crafts

##### Summary

A square, two-dimensional collection of [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel')s for use in [CraftingRecipe](#T-ParquetClassLibrary-Crafts-CraftingRecipe 'ParquetClassLibrary.Crafts.CraftingRecipe')s.

<a name='M-ParquetClassLibrary-Crafts-StrikePanelGrid-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new [StrikePanelGrid](#T-ParquetClassLibrary-Crafts-StrikePanelGrid 'ParquetClassLibrary.Crafts.StrikePanelGrid') with dimensions as specifid in [Dimensions](#T-ParquetClassLibrary-Rules-Dimensions 'ParquetClassLibrary.Rules.Dimensions').

##### Parameters

This constructor has no parameters.

<a name='M-ParquetClassLibrary-Crafts-StrikePanelGrid-#ctor-System-Int32,System-Int32-'></a>
### #ctor(inRowCount,inColumnCount) `constructor`

##### Summary

Initializes a new [StrikePanelGrid](#T-ParquetClassLibrary-Crafts-StrikePanelGrid 'ParquetClassLibrary.Crafts.StrikePanelGrid').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inRowCount | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The length of the Y dimension of the collection. |
| inColumnCount | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The length of the X dimension of the collection. |

<a name='P-ParquetClassLibrary-Crafts-StrikePanelGrid-Columns'></a>
### Columns `property`

##### Summary

Gets the number of elements in the X dimension of the [StrikePanelGrid](#T-ParquetClassLibrary-Crafts-StrikePanelGrid 'ParquetClassLibrary.Crafts.StrikePanelGrid').

<a name='P-ParquetClassLibrary-Crafts-StrikePanelGrid-Count'></a>
### Count `property`

##### Summary

The total number of parquets collected.

<a name='P-ParquetClassLibrary-Crafts-StrikePanelGrid-Item-System-Int32,System-Int32-'></a>
### Item `property`

##### Summary

Access to any [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel') in the grid.

<a name='P-ParquetClassLibrary-Crafts-StrikePanelGrid-Rows'></a>
### Rows `property`

##### Summary

Gets the number of elements in the Y dimension of the [StrikePanelGrid](#T-ParquetClassLibrary-Crafts-StrikePanelGrid 'ParquetClassLibrary.Crafts.StrikePanelGrid').

<a name='P-ParquetClassLibrary-Crafts-StrikePanelGrid-StrikePanels'></a>
### StrikePanels `property`

##### Summary

The backing collection of [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel')es.

<a name='M-ParquetClassLibrary-Crafts-StrikePanelGrid-GetEnumerator'></a>
### GetEnumerator() `method`

##### Summary

Exposes an enumerator for the [StrikePanelGrid](#T-ParquetClassLibrary-Crafts-StrikePanelGrid 'ParquetClassLibrary.Crafts.StrikePanelGrid'), which supports simple iteration.

##### Returns

An enumerator.

##### Parameters

This method has no parameters.

##### Remarks

For serialization, this guarantees stable iteration order.

<a name='M-ParquetClassLibrary-Crafts-StrikePanelGrid-IsValidPosition-ParquetClassLibrary-Vector2D-'></a>
### IsValidPosition(inPosition) `method`

##### Summary

Determines if the given position corresponds to a point within the collection.

##### Returns

`true`, if the position is valid, `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inPosition | [ParquetClassLibrary.Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') | The position to validate. |

<a name='M-ParquetClassLibrary-Crafts-StrikePanelGrid-System#Collections#Generic#IEnumerable{ParquetClassLibrary#Crafts#StrikePanel}#GetEnumerator'></a>
### System#Collections#Generic#IEnumerable{ParquetClassLibrary#Crafts#StrikePanel}#GetEnumerator() `method`

##### Summary

Exposes an [IEnumerator\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerator`1 'System.Collections.Generic.IEnumerator`1'), which supports simple iteration.

##### Returns

An enumerator.

##### Parameters

This method has no parameters.

##### Remarks

For serialization, this guarantees stable iteration order.

<a name='T-ParquetClassLibrary-Vector2D'></a>
## Vector2D `type`

##### Namespace

ParquetClassLibrary

##### Summary

A simple representation of two coordinate integers, tailored for Parquet's needs.

<a name='M-ParquetClassLibrary-Vector2D-#ctor-System-Int32,System-Int32-'></a>
### #ctor(inX,inY) `constructor`

##### Summary

Initializes a new instance of the [Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') struct.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inX | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Offset in x. |
| inY | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Offset in y. |

<a name='F-ParquetClassLibrary-Vector2D-East'></a>
### East `constants`

##### Summary

The vector offset to the East.

<a name='F-ParquetClassLibrary-Vector2D-North'></a>
### North `constants`

##### Summary

The vector offset to the North.

<a name='F-ParquetClassLibrary-Vector2D-South'></a>
### South `constants`

##### Summary

The vector offset to the South.

<a name='F-ParquetClassLibrary-Vector2D-Unit'></a>
### Unit `constants`

##### Summary

The unit vector.

<a name='F-ParquetClassLibrary-Vector2D-West'></a>
### West `constants`

##### Summary

The vector offset to the West.

<a name='F-ParquetClassLibrary-Vector2D-Zero'></a>
### Zero `constants`

##### Summary

The zero vector.

<a name='P-ParquetClassLibrary-Vector2D-ConverterFactory'></a>
### ConverterFactory `property`

##### Summary

Allows the converter to construct itself statically.

<a name='P-ParquetClassLibrary-Vector2D-Magnitude'></a>
### Magnitude `property`

##### Summary

Provides the magnitude of the vector as an integer, rounded-down.

<a name='P-ParquetClassLibrary-Vector2D-X'></a>
### X `property`

##### Summary

Offset from origin in x.

<a name='P-ParquetClassLibrary-Vector2D-Y'></a>
### Y `property`

##### Summary

Offset from origin in y.

<a name='M-ParquetClassLibrary-Vector2D-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData-'></a>
### ConvertFromString(inText,inRow,inMemberMapData) `method`

##### Summary

Converts the given [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') to an [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') as deserialization.

##### Returns

The given instance deserialized.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inText | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The text to convert. |
| inRow | [CsvHelper.IReaderRow](#T-CsvHelper-IReaderRow 'CsvHelper.IReaderRow') | The current context and configuration. |
| inMemberMapData | [CsvHelper.Configuration.MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') | Mapping info for a member to a CSV field or property. |

<a name='M-ParquetClassLibrary-Vector2D-ConvertToString-System-Object,CsvHelper-IWriterRow,CsvHelper-Configuration-MemberMapData-'></a>
### ConvertToString(inValue,inRow,inMemberMapData) `method`

##### Summary

Converts the given [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') to a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') for serialization.

##### Returns

The given instance serialized.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inValue | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The instance to convert. |
| inRow | [CsvHelper.IWriterRow](#T-CsvHelper-IWriterRow 'CsvHelper.IWriterRow') | The current context and configuration. |
| inMemberMapData | [CsvHelper.Configuration.MemberMapData](#T-CsvHelper-Configuration-MemberMapData 'CsvHelper.Configuration.MemberMapData') | Mapping info for a member to a CSV field or property. |

<a name='M-ParquetClassLibrary-Vector2D-Equals-ParquetClassLibrary-Vector2D-'></a>
### Equals(inVector) `method`

##### Summary

Determines whether the specified [Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') is equal to the current [Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D').

##### Returns

`true` if the [Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D')s are equal.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inVector | [ParquetClassLibrary.Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') | The [Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') to compare with the current. |

<a name='M-ParquetClassLibrary-Vector2D-Equals-System-Object-'></a>
### Equals(obj) `method`

##### Summary

Determines whether the specified [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') is equal to the current [Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D').

##### Returns

`true` if the specified [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') is equal to the current [Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D'); otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') to compare with the current [Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D'). |

<a name='M-ParquetClassLibrary-Vector2D-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Serves as a hash function for a [Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') struct.

##### Returns

A hash code for this instance that is suitable for use in hashing algorithms and data structures.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Vector2D-ToString'></a>
### ToString() `method`

##### Summary

Returns a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents the current [Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D').

##### Returns

The representation.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Vector2D-op_Addition-ParquetClassLibrary-Vector2D,ParquetClassLibrary-Vector2D-'></a>
### op_Addition(inVector1,inVector2) `method`

##### Summary

Sums the given vectors.

##### Returns

A vector representing the sum of the given vectors.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inVector1 | [ParquetClassLibrary.Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') | First operand. |
| inVector2 | [ParquetClassLibrary.Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') | Second operand. |

<a name='M-ParquetClassLibrary-Vector2D-op_Equality-ParquetClassLibrary-Vector2D,ParquetClassLibrary-Vector2D-'></a>
### op_Equality(inVector1,inVector2) `method`

##### Summary

Determines whether a specified instance of [Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') is equal to
another specified instance of [Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D').

##### Returns

`true` if the two operands are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inVector1 | [ParquetClassLibrary.Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') | The first [Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') to compare. |
| inVector2 | [ParquetClassLibrary.Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') | The second [Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') to compare. |

<a name='M-ParquetClassLibrary-Vector2D-op_Inequality-ParquetClassLibrary-Vector2D,ParquetClassLibrary-Vector2D-'></a>
### op_Inequality(inVector1,inVector2) `method`

##### Summary

Determines whether a specified instance of [Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') is not equal
to another specified instance of [Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D').

##### Returns

`true` if the two operands are NOT equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inVector1 | [ParquetClassLibrary.Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') | The first [Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') to compare. |
| inVector2 | [ParquetClassLibrary.Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') | The second [Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') to compare. |

<a name='M-ParquetClassLibrary-Vector2D-op_Multiply-System-Int32,ParquetClassLibrary-Vector2D-'></a>
### op_Multiply(inScalar,inVector) `method`

##### Summary

Scales a vector.

##### Returns

A scaled vector.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inScalar | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The scalar. |
| inVector | [ParquetClassLibrary.Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') | The vector. |

<a name='M-ParquetClassLibrary-Vector2D-op_Subtraction-ParquetClassLibrary-Vector2D,ParquetClassLibrary-Vector2D-'></a>
### op_Subtraction(inVector1,inVector2) `method`

##### Summary

Finds the difference between the given vectors.

##### Returns

A vector representing the difference of the given vectors.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inVector1 | [ParquetClassLibrary.Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') | First operand. |
| inVector2 | [ParquetClassLibrary.Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') | Second operand. |