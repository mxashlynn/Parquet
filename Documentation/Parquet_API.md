<a name='assembly'></a>
# Parquet

## Contents

- [All](#T-ParquetClassLibrary-All 'ParquetClassLibrary.All')
  - [AllDefinedIDs](#F-ParquetClassLibrary-All-AllDefinedIDs 'ParquetClassLibrary.All.AllDefinedIDs')
  - [BeingIDs](#F-ParquetClassLibrary-All-BeingIDs 'ParquetClassLibrary.All.BeingIDs')
  - [BiomeIDs](#F-ParquetClassLibrary-All-BiomeIDs 'ParquetClassLibrary.All.BiomeIDs')
  - [BlockIDs](#F-ParquetClassLibrary-All-BlockIDs 'ParquetClassLibrary.All.BlockIDs')
  - [CharacterIDs](#F-ParquetClassLibrary-All-CharacterIDs 'ParquetClassLibrary.All.CharacterIDs')
  - [CollectibleIDs](#F-ParquetClassLibrary-All-CollectibleIDs 'ParquetClassLibrary.All.CollectibleIDs')
  - [CraftingRecipeIDs](#F-ParquetClassLibrary-All-CraftingRecipeIDs 'ParquetClassLibrary.All.CraftingRecipeIDs')
  - [CritterIDs](#F-ParquetClassLibrary-All-CritterIDs 'ParquetClassLibrary.All.CritterIDs')
  - [FloorIDs](#F-ParquetClassLibrary-All-FloorIDs 'ParquetClassLibrary.All.FloorIDs')
  - [FurnishingIDs](#F-ParquetClassLibrary-All-FurnishingIDs 'ParquetClassLibrary.All.FurnishingIDs')
  - [GameIDs](#F-ParquetClassLibrary-All-GameIDs 'ParquetClassLibrary.All.GameIDs')
  - [InteractionIDs](#F-ParquetClassLibrary-All-InteractionIDs 'ParquetClassLibrary.All.InteractionIDs')
  - [ItemIDs](#F-ParquetClassLibrary-All-ItemIDs 'ParquetClassLibrary.All.ItemIDs')
  - [MapChunkIDs](#F-ParquetClassLibrary-All-MapChunkIDs 'ParquetClassLibrary.All.MapChunkIDs')
  - [MapIDs](#F-ParquetClassLibrary-All-MapIDs 'ParquetClassLibrary.All.MapIDs')
  - [MapRegionIDs](#F-ParquetClassLibrary-All-MapRegionIDs 'ParquetClassLibrary.All.MapRegionIDs')
  - [ParquetIDs](#F-ParquetClassLibrary-All-ParquetIDs 'ParquetClassLibrary.All.ParquetIDs')
  - [RoomRecipeIDs](#F-ParquetClassLibrary-All-RoomRecipeIDs 'ParquetClassLibrary.All.RoomRecipeIDs')
  - [ScriptIDs](#F-ParquetClassLibrary-All-ScriptIDs 'ParquetClassLibrary.All.ScriptIDs')
  - [SerializedNumberStyle](#F-ParquetClassLibrary-All-SerializedNumberStyle 'ParquetClassLibrary.All.SerializedNumberStyle')
  - [Beings](#P-ParquetClassLibrary-All-Beings 'ParquetClassLibrary.All.Beings')
  - [Biomes](#P-ParquetClassLibrary-All-Biomes 'ParquetClassLibrary.All.Biomes')
  - [CollectionsHaveBeenInitialized](#P-ParquetClassLibrary-All-CollectionsHaveBeenInitialized 'ParquetClassLibrary.All.CollectionsHaveBeenInitialized')
  - [ConversionConverters](#P-ParquetClassLibrary-All-ConversionConverters 'ParquetClassLibrary.All.ConversionConverters')
  - [CraftingRecipes](#P-ParquetClassLibrary-All-CraftingRecipes 'ParquetClassLibrary.All.CraftingRecipes')
  - [Games](#P-ParquetClassLibrary-All-Games 'ParquetClassLibrary.All.Games')
  - [IdentifierOptions](#P-ParquetClassLibrary-All-IdentifierOptions 'ParquetClassLibrary.All.IdentifierOptions')
  - [Interactions](#P-ParquetClassLibrary-All-Interactions 'ParquetClassLibrary.All.Interactions')
  - [Items](#P-ParquetClassLibrary-All-Items 'ParquetClassLibrary.All.Items')
  - [Maps](#P-ParquetClassLibrary-All-Maps 'ParquetClassLibrary.All.Maps')
  - [Parquets](#P-ParquetClassLibrary-All-Parquets 'ParquetClassLibrary.All.Parquets')
  - [ProjectDirectory](#P-ParquetClassLibrary-All-ProjectDirectory 'ParquetClassLibrary.All.ProjectDirectory')
  - [PronounGroups](#P-ParquetClassLibrary-All-PronounGroups 'ParquetClassLibrary.All.PronounGroups')
  - [RoomRecipes](#P-ParquetClassLibrary-All-RoomRecipes 'ParquetClassLibrary.All.RoomRecipes')
  - [Scripts](#P-ParquetClassLibrary-All-Scripts 'ParquetClassLibrary.All.Scripts')
  - [#cctor()](#M-ParquetClassLibrary-All-#cctor 'ParquetClassLibrary.All.#cctor')
  - [Clear()](#M-ParquetClassLibrary-All-Clear 'ParquetClassLibrary.All.Clear')
  - [GetIDRangeForType(inID)](#M-ParquetClassLibrary-All-GetIDRangeForType-ParquetClassLibrary-ModelID- 'ParquetClassLibrary.All.GetIDRangeForType(ParquetClassLibrary.ModelID)')
  - [GetIDRangeForType(inModel)](#M-ParquetClassLibrary-All-GetIDRangeForType-ParquetClassLibrary-Model- 'ParquetClassLibrary.All.GetIDRangeForType(ParquetClassLibrary.Model)')
  - [GetIDRangeForType(inModelType)](#M-ParquetClassLibrary-All-GetIDRangeForType-System-Type- 'ParquetClassLibrary.All.GetIDRangeForType(System.Type)')
  - [InitializeCollections(inPronouns,inBeings,inBiomes,inCraftingRecipes,inGames,inInteractions,inMaps,inParquets,inRoomRecipes,inScripts,inItems)](#M-ParquetClassLibrary-All-InitializeCollections-System-Collections-Generic-IEnumerable{ParquetClassLibrary-Beings-PronounGroup},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Beings-BeingModel},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Biomes-BiomeRecipe},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Crafts-CraftingRecipe},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Games-GameModel},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Scripts-InteractionModel},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Maps-MapModel},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Parquets-ParquetModel},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Rooms-RoomRecipe},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Scripts-ScriptModel},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Items-ItemModel}- 'ParquetClassLibrary.All.InitializeCollections(System.Collections.Generic.IEnumerable{ParquetClassLibrary.Beings.PronounGroup},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Beings.BeingModel},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Biomes.BiomeRecipe},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Crafts.CraftingRecipe},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Games.GameModel},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Scripts.InteractionModel},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Maps.MapModel},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Parquets.ParquetModel},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Rooms.RoomRecipe},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Scripts.ScriptModel},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Items.ItemModel})')
  - [LoadFromCSVs()](#M-ParquetClassLibrary-All-LoadFromCSVs 'ParquetClassLibrary.All.LoadFromCSVs')
  - [SaveToCSVs()](#M-ParquetClassLibrary-All-SaveToCSVs 'ParquetClassLibrary.All.SaveToCSVs')
- [AssemblyInfo](#T-ParquetClassLibrary-AssemblyInfo 'ParquetClassLibrary.AssemblyInfo')
  - [LibraryVersion](#F-ParquetClassLibrary-AssemblyInfo-LibraryVersion 'ParquetClassLibrary.AssemblyInfo.LibraryVersion')
- [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel')
  - [#ctor(inBounds,inID,inName,inDescription,inComment,inNativeBiomeID,inPrimaryBehaviorID,inAvoidsIDs,inSeeksIDs)](#M-ParquetClassLibrary-Beings-BeingModel-#ctor-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID}- 'ParquetClassLibrary.Beings.BeingModel.#ctor(ParquetClassLibrary.Range{ParquetClassLibrary.ModelID},ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.Nullable{ParquetClassLibrary.ModelID},System.Nullable{ParquetClassLibrary.ModelID},System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID},System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID})')
  - [AvoidsIDs](#P-ParquetClassLibrary-Beings-BeingModel-AvoidsIDs 'ParquetClassLibrary.Beings.BeingModel.AvoidsIDs')
  - [NativeBiomeID](#P-ParquetClassLibrary-Beings-BeingModel-NativeBiomeID 'ParquetClassLibrary.Beings.BeingModel.NativeBiomeID')
  - [ParquetClassLibrary#Beings#IBeingModelEdit#AvoidsIDs](#P-ParquetClassLibrary-Beings-BeingModel-ParquetClassLibrary#Beings#IBeingModelEdit#AvoidsIDs 'ParquetClassLibrary.Beings.BeingModel.ParquetClassLibrary#Beings#IBeingModelEdit#AvoidsIDs')
  - [ParquetClassLibrary#Beings#IBeingModelEdit#NativeBiomeID](#P-ParquetClassLibrary-Beings-BeingModel-ParquetClassLibrary#Beings#IBeingModelEdit#NativeBiomeID 'ParquetClassLibrary.Beings.BeingModel.ParquetClassLibrary#Beings#IBeingModelEdit#NativeBiomeID')
  - [ParquetClassLibrary#Beings#IBeingModelEdit#PrimaryBehaviorID](#P-ParquetClassLibrary-Beings-BeingModel-ParquetClassLibrary#Beings#IBeingModelEdit#PrimaryBehaviorID 'ParquetClassLibrary.Beings.BeingModel.ParquetClassLibrary#Beings#IBeingModelEdit#PrimaryBehaviorID')
  - [ParquetClassLibrary#Beings#IBeingModelEdit#SeeksIDs](#P-ParquetClassLibrary-Beings-BeingModel-ParquetClassLibrary#Beings#IBeingModelEdit#SeeksIDs 'ParquetClassLibrary.Beings.BeingModel.ParquetClassLibrary#Beings#IBeingModelEdit#SeeksIDs')
  - [PrimaryBehaviorID](#P-ParquetClassLibrary-Beings-BeingModel-PrimaryBehaviorID 'ParquetClassLibrary.Beings.BeingModel.PrimaryBehaviorID')
  - [SeeksIDs](#P-ParquetClassLibrary-Beings-BeingModel-SeeksIDs 'ParquetClassLibrary.Beings.BeingModel.SeeksIDs')
- [BeingStatus](#T-ParquetClassLibrary-Beings-BeingStatus 'ParquetClassLibrary.Beings.BeingStatus')
  - [#ctor(inBeingDefinition,inPosition,inSpawnAt,inCurrentBehavior,inBiomeTimeRemaining,inBuildingSpeed,inModificationSpeed,inGatheringSpeed,inMovementSpeed,inKnownBeings,inKnownParquets,inKnownRoomRecipes,inKnownCraftingRecipes,inQuests,inInventory)](#M-ParquetClassLibrary-Beings-BeingStatus-#ctor-ParquetClassLibrary-Beings-BeingModel,ParquetClassLibrary-ModelID,ParquetClassLibrary-Location,ParquetClassLibrary-Location,System-Int32,System-Single,System-Single,System-Single,System-Single,System-Collections-Generic-List{ParquetClassLibrary-ModelID},System-Collections-Generic-List{ParquetClassLibrary-ModelID},System-Collections-Generic-List{ParquetClassLibrary-ModelID},System-Collections-Generic-List{ParquetClassLibrary-ModelID},System-Collections-Generic-List{ParquetClassLibrary-ModelID},System-Collections-Generic-List{ParquetClassLibrary-ModelID}- 'ParquetClassLibrary.Beings.BeingStatus.#ctor(ParquetClassLibrary.Beings.BeingModel,ParquetClassLibrary.ModelID,ParquetClassLibrary.Location,ParquetClassLibrary.Location,System.Int32,System.Single,System.Single,System.Single,System.Single,System.Collections.Generic.List{ParquetClassLibrary.ModelID},System.Collections.Generic.List{ParquetClassLibrary.ModelID},System.Collections.Generic.List{ParquetClassLibrary.ModelID},System.Collections.Generic.List{ParquetClassLibrary.ModelID},System.Collections.Generic.List{ParquetClassLibrary.ModelID},System.Collections.Generic.List{ParquetClassLibrary.ModelID})')
  - [BeingDefinition](#P-ParquetClassLibrary-Beings-BeingStatus-BeingDefinition 'ParquetClassLibrary.Beings.BeingStatus.BeingDefinition')
  - [BiomeTimeRemaining](#P-ParquetClassLibrary-Beings-BeingStatus-BiomeTimeRemaining 'ParquetClassLibrary.Beings.BeingStatus.BiomeTimeRemaining')
  - [BuildingSpeed](#P-ParquetClassLibrary-Beings-BeingStatus-BuildingSpeed 'ParquetClassLibrary.Beings.BeingStatus.BuildingSpeed')
  - [CurrentBehaviorID](#P-ParquetClassLibrary-Beings-BeingStatus-CurrentBehaviorID 'ParquetClassLibrary.Beings.BeingStatus.CurrentBehaviorID')
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
- [BiomeConfiguration](#T-ParquetClassLibrary-Biomes-BiomeConfiguration 'ParquetClassLibrary.Biomes.BiomeConfiguration')
  - [ParquetsPerLayer](#F-ParquetClassLibrary-Biomes-BiomeConfiguration-ParquetsPerLayer 'ParquetClassLibrary.Biomes.BiomeConfiguration.ParquetsPerLayer')
  - [LandThreshold](#P-ParquetClassLibrary-Biomes-BiomeConfiguration-LandThreshold 'ParquetClassLibrary.Biomes.BiomeConfiguration.LandThreshold')
  - [LandThresholdFactor](#P-ParquetClassLibrary-Biomes-BiomeConfiguration-LandThresholdFactor 'ParquetClassLibrary.Biomes.BiomeConfiguration.LandThresholdFactor')
  - [LiquidThreshold](#P-ParquetClassLibrary-Biomes-BiomeConfiguration-LiquidThreshold 'ParquetClassLibrary.Biomes.BiomeConfiguration.LiquidThreshold')
  - [LiquidThresholdFactor](#P-ParquetClassLibrary-Biomes-BiomeConfiguration-LiquidThresholdFactor 'ParquetClassLibrary.Biomes.BiomeConfiguration.LiquidThresholdFactor')
  - [RoomThreshold](#P-ParquetClassLibrary-Biomes-BiomeConfiguration-RoomThreshold 'ParquetClassLibrary.Biomes.BiomeConfiguration.RoomThreshold')
  - [RoomThresholdFactor](#P-ParquetClassLibrary-Biomes-BiomeConfiguration-RoomThresholdFactor 'ParquetClassLibrary.Biomes.BiomeConfiguration.RoomThresholdFactor')
  - [GetFilePath()](#M-ParquetClassLibrary-Biomes-BiomeConfiguration-GetFilePath 'ParquetClassLibrary.Biomes.BiomeConfiguration.GetFilePath')
  - [GetRecord()](#M-ParquetClassLibrary-Biomes-BiomeConfiguration-GetRecord 'ParquetClassLibrary.Biomes.BiomeConfiguration.GetRecord')
  - [PutRecord()](#M-ParquetClassLibrary-Biomes-BiomeConfiguration-PutRecord 'ParquetClassLibrary.Biomes.BiomeConfiguration.PutRecord')
- [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe')
  - [#ctor(inID,inName,inDescription,inComment,inTier,inIsRoomBased,inIsLiquidBased,inParquetCriteria,inEntryRequirements)](#M-ParquetClassLibrary-Biomes-BiomeRecipe-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Int32,System-Boolean,System-Boolean,System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag}- 'ParquetClassLibrary.Biomes.BiomeRecipe.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.Int32,System.Boolean,System.Boolean,System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag},System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag})')
  - [EntryRequirements](#P-ParquetClassLibrary-Biomes-BiomeRecipe-EntryRequirements 'ParquetClassLibrary.Biomes.BiomeRecipe.EntryRequirements')
  - [IsLiquidBased](#P-ParquetClassLibrary-Biomes-BiomeRecipe-IsLiquidBased 'ParquetClassLibrary.Biomes.BiomeRecipe.IsLiquidBased')
  - [IsRoomBased](#P-ParquetClassLibrary-Biomes-BiomeRecipe-IsRoomBased 'ParquetClassLibrary.Biomes.BiomeRecipe.IsRoomBased')
  - [None](#P-ParquetClassLibrary-Biomes-BiomeRecipe-None 'ParquetClassLibrary.Biomes.BiomeRecipe.None')
  - [ParquetClassLibrary#Biomes#IBiomeRecipeEdit#EntryRequirements](#P-ParquetClassLibrary-Biomes-BiomeRecipe-ParquetClassLibrary#Biomes#IBiomeRecipeEdit#EntryRequirements 'ParquetClassLibrary.Biomes.BiomeRecipe.ParquetClassLibrary#Biomes#IBiomeRecipeEdit#EntryRequirements')
  - [ParquetClassLibrary#Biomes#IBiomeRecipeEdit#IsLiquidBased](#P-ParquetClassLibrary-Biomes-BiomeRecipe-ParquetClassLibrary#Biomes#IBiomeRecipeEdit#IsLiquidBased 'ParquetClassLibrary.Biomes.BiomeRecipe.ParquetClassLibrary#Biomes#IBiomeRecipeEdit#IsLiquidBased')
  - [ParquetClassLibrary#Biomes#IBiomeRecipeEdit#IsRoomBased](#P-ParquetClassLibrary-Biomes-BiomeRecipe-ParquetClassLibrary#Biomes#IBiomeRecipeEdit#IsRoomBased 'ParquetClassLibrary.Biomes.BiomeRecipe.ParquetClassLibrary#Biomes#IBiomeRecipeEdit#IsRoomBased')
  - [ParquetClassLibrary#Biomes#IBiomeRecipeEdit#ParquetCriteria](#P-ParquetClassLibrary-Biomes-BiomeRecipe-ParquetClassLibrary#Biomes#IBiomeRecipeEdit#ParquetCriteria 'ParquetClassLibrary.Biomes.BiomeRecipe.ParquetClassLibrary#Biomes#IBiomeRecipeEdit#ParquetCriteria')
  - [ParquetClassLibrary#Biomes#IBiomeRecipeEdit#Tier](#P-ParquetClassLibrary-Biomes-BiomeRecipe-ParquetClassLibrary#Biomes#IBiomeRecipeEdit#Tier 'ParquetClassLibrary.Biomes.BiomeRecipe.ParquetClassLibrary#Biomes#IBiomeRecipeEdit#Tier')
  - [ParquetCriteria](#P-ParquetClassLibrary-Biomes-BiomeRecipe-ParquetCriteria 'ParquetClassLibrary.Biomes.BiomeRecipe.ParquetCriteria')
  - [Tier](#P-ParquetClassLibrary-Biomes-BiomeRecipe-Tier 'ParquetClassLibrary.Biomes.BiomeRecipe.Tier')
  - [GetAllTags()](#M-ParquetClassLibrary-Biomes-BiomeRecipe-GetAllTags 'ParquetClassLibrary.Biomes.BiomeRecipe.GetAllTags')
- [BlockModel](#T-ParquetClassLibrary-Parquets-BlockModel 'ParquetClassLibrary.Parquets.BlockModel')
  - [#ctor(inID,inName,inDescription,inComment,inItemID,inAddsToBiome,inAddsToRoom,inGatherTool,inGatherEffect,inCollectibleID,inIsFlammable,inIsLiquid,inMaxToughness)](#M-ParquetClassLibrary-Parquets-BlockModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Nullable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag},ParquetClassLibrary-Items-GatheringTool,ParquetClassLibrary-Parquets-GatheringEffect,System-Nullable{ParquetClassLibrary-ModelID},System-Boolean,System-Boolean,System-Int32- 'ParquetClassLibrary.Parquets.BlockModel.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.Nullable{ParquetClassLibrary.ModelID},System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag},System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag},ParquetClassLibrary.Items.GatheringTool,ParquetClassLibrary.Parquets.GatheringEffect,System.Nullable{ParquetClassLibrary.ModelID},System.Boolean,System.Boolean,System.Int32)')
  - [DefaultMaxToughness](#F-ParquetClassLibrary-Parquets-BlockModel-DefaultMaxToughness 'ParquetClassLibrary.Parquets.BlockModel.DefaultMaxToughness')
  - [LowestPossibleToughness](#F-ParquetClassLibrary-Parquets-BlockModel-LowestPossibleToughness 'ParquetClassLibrary.Parquets.BlockModel.LowestPossibleToughness')
  - [Bounds](#P-ParquetClassLibrary-Parquets-BlockModel-Bounds 'ParquetClassLibrary.Parquets.BlockModel.Bounds')
  - [CollectibleID](#P-ParquetClassLibrary-Parquets-BlockModel-CollectibleID 'ParquetClassLibrary.Parquets.BlockModel.CollectibleID')
  - [GatherEffect](#P-ParquetClassLibrary-Parquets-BlockModel-GatherEffect 'ParquetClassLibrary.Parquets.BlockModel.GatherEffect')
  - [GatherTool](#P-ParquetClassLibrary-Parquets-BlockModel-GatherTool 'ParquetClassLibrary.Parquets.BlockModel.GatherTool')
  - [IsFlammable](#P-ParquetClassLibrary-Parquets-BlockModel-IsFlammable 'ParquetClassLibrary.Parquets.BlockModel.IsFlammable')
  - [IsLiquid](#P-ParquetClassLibrary-Parquets-BlockModel-IsLiquid 'ParquetClassLibrary.Parquets.BlockModel.IsLiquid')
  - [MaxToughness](#P-ParquetClassLibrary-Parquets-BlockModel-MaxToughness 'ParquetClassLibrary.Parquets.BlockModel.MaxToughness')
  - [ParquetClassLibrary#Parquets#IBlockModelEdit#CollectibleID](#P-ParquetClassLibrary-Parquets-BlockModel-ParquetClassLibrary#Parquets#IBlockModelEdit#CollectibleID 'ParquetClassLibrary.Parquets.BlockModel.ParquetClassLibrary#Parquets#IBlockModelEdit#CollectibleID')
  - [ParquetClassLibrary#Parquets#IBlockModelEdit#GatherEffect](#P-ParquetClassLibrary-Parquets-BlockModel-ParquetClassLibrary#Parquets#IBlockModelEdit#GatherEffect 'ParquetClassLibrary.Parquets.BlockModel.ParquetClassLibrary#Parquets#IBlockModelEdit#GatherEffect')
  - [ParquetClassLibrary#Parquets#IBlockModelEdit#GatherTool](#P-ParquetClassLibrary-Parquets-BlockModel-ParquetClassLibrary#Parquets#IBlockModelEdit#GatherTool 'ParquetClassLibrary.Parquets.BlockModel.ParquetClassLibrary#Parquets#IBlockModelEdit#GatherTool')
  - [ParquetClassLibrary#Parquets#IBlockModelEdit#IsFlammable](#P-ParquetClassLibrary-Parquets-BlockModel-ParquetClassLibrary#Parquets#IBlockModelEdit#IsFlammable 'ParquetClassLibrary.Parquets.BlockModel.ParquetClassLibrary#Parquets#IBlockModelEdit#IsFlammable')
  - [ParquetClassLibrary#Parquets#IBlockModelEdit#IsLiquid](#P-ParquetClassLibrary-Parquets-BlockModel-ParquetClassLibrary#Parquets#IBlockModelEdit#IsLiquid 'ParquetClassLibrary.Parquets.BlockModel.ParquetClassLibrary#Parquets#IBlockModelEdit#IsLiquid')
  - [ParquetClassLibrary#Parquets#IBlockModelEdit#MaxToughness](#P-ParquetClassLibrary-Parquets-BlockModel-ParquetClassLibrary#Parquets#IBlockModelEdit#MaxToughness 'ParquetClassLibrary.Parquets.BlockModel.ParquetClassLibrary#Parquets#IBlockModelEdit#MaxToughness')
- [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel')
  - [#ctor(inID,inName,inDescription,inComment,inNativeBiomeID,inPrimaryBehaviorID,inAvoidsIDs,inSeeksIDs,inPronouns,inStoryCharacterID,inStartingQuestIDs,inStartingDialogueIDs,inStartingInventoryIDs)](#M-ParquetClassLibrary-Beings-CharacterModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-String,System-String,System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID}- 'ParquetClassLibrary.Beings.CharacterModel.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.Nullable{ParquetClassLibrary.ModelID},System.Nullable{ParquetClassLibrary.ModelID},System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID},System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID},System.String,System.String,System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID},System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID},System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID})')
  - [FamilyName](#P-ParquetClassLibrary-Beings-CharacterModel-FamilyName 'ParquetClassLibrary.Beings.CharacterModel.FamilyName')
  - [ParquetClassLibrary#Beings#ICharacterModelEdit#FamilyName](#P-ParquetClassLibrary-Beings-CharacterModel-ParquetClassLibrary#Beings#ICharacterModelEdit#FamilyName 'ParquetClassLibrary.Beings.CharacterModel.ParquetClassLibrary#Beings#ICharacterModelEdit#FamilyName')
  - [ParquetClassLibrary#Beings#ICharacterModelEdit#PersonalName](#P-ParquetClassLibrary-Beings-CharacterModel-ParquetClassLibrary#Beings#ICharacterModelEdit#PersonalName 'ParquetClassLibrary.Beings.CharacterModel.ParquetClassLibrary#Beings#ICharacterModelEdit#PersonalName')
  - [ParquetClassLibrary#Beings#ICharacterModelEdit#Pronouns](#P-ParquetClassLibrary-Beings-CharacterModel-ParquetClassLibrary#Beings#ICharacterModelEdit#Pronouns 'ParquetClassLibrary.Beings.CharacterModel.ParquetClassLibrary#Beings#ICharacterModelEdit#Pronouns')
  - [ParquetClassLibrary#Beings#ICharacterModelEdit#StartingDialogueIDs](#P-ParquetClassLibrary-Beings-CharacterModel-ParquetClassLibrary#Beings#ICharacterModelEdit#StartingDialogueIDs 'ParquetClassLibrary.Beings.CharacterModel.ParquetClassLibrary#Beings#ICharacterModelEdit#StartingDialogueIDs')
  - [ParquetClassLibrary#Beings#ICharacterModelEdit#StartingInventoryIDs](#P-ParquetClassLibrary-Beings-CharacterModel-ParquetClassLibrary#Beings#ICharacterModelEdit#StartingInventoryIDs 'ParquetClassLibrary.Beings.CharacterModel.ParquetClassLibrary#Beings#ICharacterModelEdit#StartingInventoryIDs')
  - [ParquetClassLibrary#Beings#ICharacterModelEdit#StartingQuestIDs](#P-ParquetClassLibrary-Beings-CharacterModel-ParquetClassLibrary#Beings#ICharacterModelEdit#StartingQuestIDs 'ParquetClassLibrary.Beings.CharacterModel.ParquetClassLibrary#Beings#ICharacterModelEdit#StartingQuestIDs')
  - [ParquetClassLibrary#Beings#ICharacterModelEdit#StoryCharacterID](#P-ParquetClassLibrary-Beings-CharacterModel-ParquetClassLibrary#Beings#ICharacterModelEdit#StoryCharacterID 'ParquetClassLibrary.Beings.CharacterModel.ParquetClassLibrary#Beings#ICharacterModelEdit#StoryCharacterID')
  - [PersonalName](#P-ParquetClassLibrary-Beings-CharacterModel-PersonalName 'ParquetClassLibrary.Beings.CharacterModel.PersonalName')
  - [Pronouns](#P-ParquetClassLibrary-Beings-CharacterModel-Pronouns 'ParquetClassLibrary.Beings.CharacterModel.Pronouns')
  - [StartingDialogueIDs](#P-ParquetClassLibrary-Beings-CharacterModel-StartingDialogueIDs 'ParquetClassLibrary.Beings.CharacterModel.StartingDialogueIDs')
  - [StartingInventoryIDs](#P-ParquetClassLibrary-Beings-CharacterModel-StartingInventoryIDs 'ParquetClassLibrary.Beings.CharacterModel.StartingInventoryIDs')
  - [StartingQuestIDs](#P-ParquetClassLibrary-Beings-CharacterModel-StartingQuestIDs 'ParquetClassLibrary.Beings.CharacterModel.StartingQuestIDs')
  - [StoryCharacterID](#P-ParquetClassLibrary-Beings-CharacterModel-StoryCharacterID 'ParquetClassLibrary.Beings.CharacterModel.StoryCharacterID')
- [ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail')
  - [#ctor()](#M-ParquetClassLibrary-Maps-ChunkDetail-#ctor 'ParquetClassLibrary.Maps.ChunkDetail.#ctor')
  - [#ctor(inBaseTopography,inBaseComposition,inModifierTopography,inModifierComposition)](#M-ParquetClassLibrary-Maps-ChunkDetail-#ctor-ParquetClassLibrary-Maps-ChunkTopography,ParquetClassLibrary-ModelTag,ParquetClassLibrary-Maps-ChunkTopography,ParquetClassLibrary-ModelTag- 'ParquetClassLibrary.Maps.ChunkDetail.#ctor(ParquetClassLibrary.Maps.ChunkTopography,ParquetClassLibrary.ModelTag,ParquetClassLibrary.Maps.ChunkTopography,ParquetClassLibrary.ModelTag)')
  - [None](#F-ParquetClassLibrary-Maps-ChunkDetail-None 'ParquetClassLibrary.Maps.ChunkDetail.None')
  - [BaseComposition](#P-ParquetClassLibrary-Maps-ChunkDetail-BaseComposition 'ParquetClassLibrary.Maps.ChunkDetail.BaseComposition')
  - [BaseTopography](#P-ParquetClassLibrary-Maps-ChunkDetail-BaseTopography 'ParquetClassLibrary.Maps.ChunkDetail.BaseTopography')
  - [ConverterFactory](#P-ParquetClassLibrary-Maps-ChunkDetail-ConverterFactory 'ParquetClassLibrary.Maps.ChunkDetail.ConverterFactory')
  - [ModifierComposition](#P-ParquetClassLibrary-Maps-ChunkDetail-ModifierComposition 'ParquetClassLibrary.Maps.ChunkDetail.ModifierComposition')
  - [ModifierTopography](#P-ParquetClassLibrary-Maps-ChunkDetail-ModifierTopography 'ParquetClassLibrary.Maps.ChunkDetail.ModifierTopography')
  - [Clone()](#M-ParquetClassLibrary-Maps-ChunkDetail-Clone 'ParquetClassLibrary.Maps.ChunkDetail.Clone')
  - [ConvertFromString(inText,inRow,inMemberMapData)](#M-ParquetClassLibrary-Maps-ChunkDetail-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData- 'ParquetClassLibrary.Maps.ChunkDetail.ConvertFromString(System.String,CsvHelper.IReaderRow,CsvHelper.Configuration.MemberMapData)')
  - [ConvertToString(inValue,inRow,inMemberMapData)](#M-ParquetClassLibrary-Maps-ChunkDetail-ConvertToString-System-Object,CsvHelper-IWriterRow,CsvHelper-Configuration-MemberMapData- 'ParquetClassLibrary.Maps.ChunkDetail.ConvertToString(System.Object,CsvHelper.IWriterRow,CsvHelper.Configuration.MemberMapData)')
  - [Equals(inChunkType)](#M-ParquetClassLibrary-Maps-ChunkDetail-Equals-ParquetClassLibrary-Maps-ChunkDetail- 'ParquetClassLibrary.Maps.ChunkDetail.Equals(ParquetClassLibrary.Maps.ChunkDetail)')
  - [Equals(obj)](#M-ParquetClassLibrary-Maps-ChunkDetail-Equals-System-Object- 'ParquetClassLibrary.Maps.ChunkDetail.Equals(System.Object)')
  - [GetHashCode()](#M-ParquetClassLibrary-Maps-ChunkDetail-GetHashCode 'ParquetClassLibrary.Maps.ChunkDetail.GetHashCode')
  - [ToString()](#M-ParquetClassLibrary-Maps-ChunkDetail-ToString 'ParquetClassLibrary.Maps.ChunkDetail.ToString')
  - [op_Equality(inChunkType1,inChunkType2)](#M-ParquetClassLibrary-Maps-ChunkDetail-op_Equality-ParquetClassLibrary-Maps-ChunkDetail,ParquetClassLibrary-Maps-ChunkDetail- 'ParquetClassLibrary.Maps.ChunkDetail.op_Equality(ParquetClassLibrary.Maps.ChunkDetail,ParquetClassLibrary.Maps.ChunkDetail)')
  - [op_Inequality(inChunkType1,inChunkType2)](#M-ParquetClassLibrary-Maps-ChunkDetail-op_Inequality-ParquetClassLibrary-Maps-ChunkDetail,ParquetClassLibrary-Maps-ChunkDetail- 'ParquetClassLibrary.Maps.ChunkDetail.op_Inequality(ParquetClassLibrary.Maps.ChunkDetail,ParquetClassLibrary.Maps.ChunkDetail)')
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
- [CollectibleModel](#T-ParquetClassLibrary-Parquets-CollectibleModel 'ParquetClassLibrary.Parquets.CollectibleModel')
  - [#ctor(inID,inName,inDescription,inComment,inItemID,inAddsToBiome,inAddsToRoom,inCollectionEffect,inEffectAmount)](#M-ParquetClassLibrary-Parquets-CollectibleModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Nullable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag},ParquetClassLibrary-Parquets-CollectingEffect,System-Int32- 'ParquetClassLibrary.Parquets.CollectibleModel.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.Nullable{ParquetClassLibrary.ModelID},System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag},System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag},ParquetClassLibrary.Parquets.CollectingEffect,System.Int32)')
  - [Bounds](#P-ParquetClassLibrary-Parquets-CollectibleModel-Bounds 'ParquetClassLibrary.Parquets.CollectibleModel.Bounds')
  - [CollectionEffect](#P-ParquetClassLibrary-Parquets-CollectibleModel-CollectionEffect 'ParquetClassLibrary.Parquets.CollectibleModel.CollectionEffect')
  - [EffectAmount](#P-ParquetClassLibrary-Parquets-CollectibleModel-EffectAmount 'ParquetClassLibrary.Parquets.CollectibleModel.EffectAmount')
  - [ParquetClassLibrary#Parquets#ICollectibleModelEdit#CollectionEffect](#P-ParquetClassLibrary-Parquets-CollectibleModel-ParquetClassLibrary#Parquets#ICollectibleModelEdit#CollectionEffect 'ParquetClassLibrary.Parquets.CollectibleModel.ParquetClassLibrary#Parquets#ICollectibleModelEdit#CollectionEffect')
  - [ParquetClassLibrary#Parquets#ICollectibleModelEdit#EffectAmount](#P-ParquetClassLibrary-Parquets-CollectibleModel-ParquetClassLibrary#Parquets#ICollectibleModelEdit#EffectAmount 'ParquetClassLibrary.Parquets.CollectibleModel.ParquetClassLibrary#Parquets#ICollectibleModelEdit#EffectAmount')
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
- [CraftConfiguration](#T-ParquetClassLibrary-Crafts-CraftConfiguration 'ParquetClassLibrary.Crafts.CraftConfiguration')
  - [IngredientCount](#P-ParquetClassLibrary-Crafts-CraftConfiguration-IngredientCount 'ParquetClassLibrary.Crafts.CraftConfiguration.IngredientCount')
  - [ProductCount](#P-ParquetClassLibrary-Crafts-CraftConfiguration-ProductCount 'ParquetClassLibrary.Crafts.CraftConfiguration.ProductCount')
  - [GetFilePath()](#M-ParquetClassLibrary-Crafts-CraftConfiguration-GetFilePath 'ParquetClassLibrary.Crafts.CraftConfiguration.GetFilePath')
  - [GetRecord()](#M-ParquetClassLibrary-Crafts-CraftConfiguration-GetRecord 'ParquetClassLibrary.Crafts.CraftConfiguration.GetRecord')
  - [PutRecord()](#M-ParquetClassLibrary-Crafts-CraftConfiguration-PutRecord 'ParquetClassLibrary.Crafts.CraftConfiguration.PutRecord')
- [CraftingRecipe](#T-ParquetClassLibrary-Crafts-CraftingRecipe 'ParquetClassLibrary.Crafts.CraftingRecipe')
  - [#ctor(inID,inName,inDescription,inComment,inProducts,inIngredients,inPanelPattern)](#M-ParquetClassLibrary-Crafts-CraftingRecipe-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Collections-Generic-IEnumerable{ParquetClassLibrary-RecipeElement},System-Collections-Generic-IEnumerable{ParquetClassLibrary-RecipeElement},ParquetClassLibrary-Crafts-StrikePanelGrid- 'ParquetClassLibrary.Crafts.CraftingRecipe.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.Collections.Generic.IEnumerable{ParquetClassLibrary.RecipeElement},System.Collections.Generic.IEnumerable{ParquetClassLibrary.RecipeElement},ParquetClassLibrary.Crafts.StrikePanelGrid)')
  - [EmptyCraftingElementList](#P-ParquetClassLibrary-Crafts-CraftingRecipe-EmptyCraftingElementList 'ParquetClassLibrary.Crafts.CraftingRecipe.EmptyCraftingElementList')
  - [Ingredients](#P-ParquetClassLibrary-Crafts-CraftingRecipe-Ingredients 'ParquetClassLibrary.Crafts.CraftingRecipe.Ingredients')
  - [NotCraftable](#P-ParquetClassLibrary-Crafts-CraftingRecipe-NotCraftable 'ParquetClassLibrary.Crafts.CraftingRecipe.NotCraftable')
  - [PanelPattern](#P-ParquetClassLibrary-Crafts-CraftingRecipe-PanelPattern 'ParquetClassLibrary.Crafts.CraftingRecipe.PanelPattern')
  - [ParquetClassLibrary#Crafts#ICraftingRecipeEdit#Ingredients](#P-ParquetClassLibrary-Crafts-CraftingRecipe-ParquetClassLibrary#Crafts#ICraftingRecipeEdit#Ingredients 'ParquetClassLibrary.Crafts.CraftingRecipe.ParquetClassLibrary#Crafts#ICraftingRecipeEdit#Ingredients')
  - [ParquetClassLibrary#Crafts#ICraftingRecipeEdit#PanelPattern](#P-ParquetClassLibrary-Crafts-CraftingRecipe-ParquetClassLibrary#Crafts#ICraftingRecipeEdit#PanelPattern 'ParquetClassLibrary.Crafts.CraftingRecipe.ParquetClassLibrary#Crafts#ICraftingRecipeEdit#PanelPattern')
  - [ParquetClassLibrary#Crafts#ICraftingRecipeEdit#Products](#P-ParquetClassLibrary-Crafts-CraftingRecipe-ParquetClassLibrary#Crafts#ICraftingRecipeEdit#Products 'ParquetClassLibrary.Crafts.CraftingRecipe.ParquetClassLibrary#Crafts#ICraftingRecipeEdit#Products')
  - [Products](#P-ParquetClassLibrary-Crafts-CraftingRecipe-Products 'ParquetClassLibrary.Crafts.CraftingRecipe.Products')
- [CritterModel](#T-ParquetClassLibrary-Beings-CritterModel 'ParquetClassLibrary.Beings.CritterModel')
  - [#ctor(inID,inName,inDescription,inComment,inNativeBiomeID,inPrimaryBehaviorID,inAvoidsIDs,inSeeksIDs)](#M-ParquetClassLibrary-Beings-CritterModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID}- 'ParquetClassLibrary.Beings.CritterModel.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.Nullable{ParquetClassLibrary.ModelID},System.Nullable{ParquetClassLibrary.ModelID},System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID},System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID})')
- [Delimiters](#T-ParquetClassLibrary-Delimiters 'ParquetClassLibrary.Delimiters')
  - [DimensionalDelimiter](#F-ParquetClassLibrary-Delimiters-DimensionalDelimiter 'ParquetClassLibrary.Delimiters.DimensionalDelimiter')
  - [DimensionalTerminator](#F-ParquetClassLibrary-Delimiters-DimensionalTerminator 'ParquetClassLibrary.Delimiters.DimensionalTerminator')
  - [ElementDelimiter](#F-ParquetClassLibrary-Delimiters-ElementDelimiter 'ParquetClassLibrary.Delimiters.ElementDelimiter')
  - [InternalDelimiter](#F-ParquetClassLibrary-Delimiters-InternalDelimiter 'ParquetClassLibrary.Delimiters.InternalDelimiter')
  - [NameDelimiter](#F-ParquetClassLibrary-Delimiters-NameDelimiter 'ParquetClassLibrary.Delimiters.NameDelimiter')
  - [PrimaryDelimiter](#F-ParquetClassLibrary-Delimiters-PrimaryDelimiter 'ParquetClassLibrary.Delimiters.PrimaryDelimiter')
  - [PronounDelimiter](#F-ParquetClassLibrary-Delimiters-PronounDelimiter 'ParquetClassLibrary.Delimiters.PronounDelimiter')
  - [SecondaryDelimiter](#F-ParquetClassLibrary-Delimiters-SecondaryDelimiter 'ParquetClassLibrary.Delimiters.SecondaryDelimiter')
- [EntryType](#T-ParquetClassLibrary-Parquets-EntryType 'ParquetClassLibrary.Parquets.EntryType')
  - [Down](#F-ParquetClassLibrary-Parquets-EntryType-Down 'ParquetClassLibrary.Parquets.EntryType.Down')
  - [None](#F-ParquetClassLibrary-Parquets-EntryType-None 'ParquetClassLibrary.Parquets.EntryType.None')
  - [Room](#F-ParquetClassLibrary-Parquets-EntryType-Room 'ParquetClassLibrary.Parquets.EntryType.Room')
  - [Up](#F-ParquetClassLibrary-Parquets-EntryType-Up 'ParquetClassLibrary.Parquets.EntryType.Up')
- [FloorModel](#T-ParquetClassLibrary-Parquets-FloorModel 'ParquetClassLibrary.Parquets.FloorModel')
  - [#ctor(inID,inName,inDescription,inComment,inItemID,inAddsToBiome,inAddsToRoom,inModTool,inTrenchName)](#M-ParquetClassLibrary-Parquets-FloorModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Nullable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag},ParquetClassLibrary-Items-ModificationTool,System-String- 'ParquetClassLibrary.Parquets.FloorModel.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.Nullable{ParquetClassLibrary.ModelID},System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag},System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag},ParquetClassLibrary.Items.ModificationTool,System.String)')
  - [defaultTrenchName](#F-ParquetClassLibrary-Parquets-FloorModel-defaultTrenchName 'ParquetClassLibrary.Parquets.FloorModel.defaultTrenchName')
  - [Bounds](#P-ParquetClassLibrary-Parquets-FloorModel-Bounds 'ParquetClassLibrary.Parquets.FloorModel.Bounds')
  - [ModTool](#P-ParquetClassLibrary-Parquets-FloorModel-ModTool 'ParquetClassLibrary.Parquets.FloorModel.ModTool')
  - [ParquetClassLibrary#Parquets#IFloorModelEdit#ModTool](#P-ParquetClassLibrary-Parquets-FloorModel-ParquetClassLibrary#Parquets#IFloorModelEdit#ModTool 'ParquetClassLibrary.Parquets.FloorModel.ParquetClassLibrary#Parquets#IFloorModelEdit#ModTool')
  - [ParquetClassLibrary#Parquets#IFloorModelEdit#TrenchName](#P-ParquetClassLibrary-Parquets-FloorModel-ParquetClassLibrary#Parquets#IFloorModelEdit#TrenchName 'ParquetClassLibrary.Parquets.FloorModel.ParquetClassLibrary#Parquets#IFloorModelEdit#TrenchName')
  - [TrenchName](#P-ParquetClassLibrary-Parquets-FloorModel-TrenchName 'ParquetClassLibrary.Parquets.FloorModel.TrenchName')
- [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel')
  - [#ctor(inID,inName,inDescription,inComment,inItemID,inAddsToBiome,inAddsToRoom,inIsWalkable,inEntry,inIsEnclosing,inIsFlammable,inSwapID)](#M-ParquetClassLibrary-Parquets-FurnishingModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Nullable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag},System-Boolean,ParquetClassLibrary-Parquets-EntryType,System-Boolean,System-Boolean,System-Nullable{ParquetClassLibrary-ModelID}- 'ParquetClassLibrary.Parquets.FurnishingModel.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.Nullable{ParquetClassLibrary.ModelID},System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag},System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag},System.Boolean,ParquetClassLibrary.Parquets.EntryType,System.Boolean,System.Boolean,System.Nullable{ParquetClassLibrary.ModelID})')
  - [Bounds](#P-ParquetClassLibrary-Parquets-FurnishingModel-Bounds 'ParquetClassLibrary.Parquets.FurnishingModel.Bounds')
  - [Entry](#P-ParquetClassLibrary-Parquets-FurnishingModel-Entry 'ParquetClassLibrary.Parquets.FurnishingModel.Entry')
  - [IsEnclosing](#P-ParquetClassLibrary-Parquets-FurnishingModel-IsEnclosing 'ParquetClassLibrary.Parquets.FurnishingModel.IsEnclosing')
  - [IsFlammable](#P-ParquetClassLibrary-Parquets-FurnishingModel-IsFlammable 'ParquetClassLibrary.Parquets.FurnishingModel.IsFlammable')
  - [IsWalkable](#P-ParquetClassLibrary-Parquets-FurnishingModel-IsWalkable 'ParquetClassLibrary.Parquets.FurnishingModel.IsWalkable')
  - [ParquetClassLibrary#Parquets#IFurnishingModelEdit#Entry](#P-ParquetClassLibrary-Parquets-FurnishingModel-ParquetClassLibrary#Parquets#IFurnishingModelEdit#Entry 'ParquetClassLibrary.Parquets.FurnishingModel.ParquetClassLibrary#Parquets#IFurnishingModelEdit#Entry')
  - [ParquetClassLibrary#Parquets#IFurnishingModelEdit#IsEnclosing](#P-ParquetClassLibrary-Parquets-FurnishingModel-ParquetClassLibrary#Parquets#IFurnishingModelEdit#IsEnclosing 'ParquetClassLibrary.Parquets.FurnishingModel.ParquetClassLibrary#Parquets#IFurnishingModelEdit#IsEnclosing')
  - [ParquetClassLibrary#Parquets#IFurnishingModelEdit#IsFlammable](#P-ParquetClassLibrary-Parquets-FurnishingModel-ParquetClassLibrary#Parquets#IFurnishingModelEdit#IsFlammable 'ParquetClassLibrary.Parquets.FurnishingModel.ParquetClassLibrary#Parquets#IFurnishingModelEdit#IsFlammable')
  - [ParquetClassLibrary#Parquets#IFurnishingModelEdit#IsWalkable](#P-ParquetClassLibrary-Parquets-FurnishingModel-ParquetClassLibrary#Parquets#IFurnishingModelEdit#IsWalkable 'ParquetClassLibrary.Parquets.FurnishingModel.ParquetClassLibrary#Parquets#IFurnishingModelEdit#IsWalkable')
  - [ParquetClassLibrary#Parquets#IFurnishingModelEdit#SwapID](#P-ParquetClassLibrary-Parquets-FurnishingModel-ParquetClassLibrary#Parquets#IFurnishingModelEdit#SwapID 'ParquetClassLibrary.Parquets.FurnishingModel.ParquetClassLibrary#Parquets#IFurnishingModelEdit#SwapID')
  - [SwapID](#P-ParquetClassLibrary-Parquets-FurnishingModel-SwapID 'ParquetClassLibrary.Parquets.FurnishingModel.SwapID')
- [GameModel](#T-ParquetClassLibrary-Games-GameModel 'ParquetClassLibrary.Games.GameModel')
  - [#ctor(inID,inName,inDescription,inComment,inIsEpisode,inEpisodeTitle,inEpisodeNumber,inPlayerCharacterID,inFirstScriptID)](#M-ParquetClassLibrary-Games-GameModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Boolean,System-String,System-Int32,System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID}- 'ParquetClassLibrary.Games.GameModel.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.Boolean,System.String,System.Int32,System.Nullable{ParquetClassLibrary.ModelID},System.Nullable{ParquetClassLibrary.ModelID})')
  - [EpisodeNumber](#P-ParquetClassLibrary-Games-GameModel-EpisodeNumber 'ParquetClassLibrary.Games.GameModel.EpisodeNumber')
  - [EpisodeTitle](#P-ParquetClassLibrary-Games-GameModel-EpisodeTitle 'ParquetClassLibrary.Games.GameModel.EpisodeTitle')
  - [FirstScriptID](#P-ParquetClassLibrary-Games-GameModel-FirstScriptID 'ParquetClassLibrary.Games.GameModel.FirstScriptID')
  - [IsEpisode](#P-ParquetClassLibrary-Games-GameModel-IsEpisode 'ParquetClassLibrary.Games.GameModel.IsEpisode')
  - [ParquetClassLibrary#Games#IGameModelEdit#EpisodeNumber](#P-ParquetClassLibrary-Games-GameModel-ParquetClassLibrary#Games#IGameModelEdit#EpisodeNumber 'ParquetClassLibrary.Games.GameModel.ParquetClassLibrary#Games#IGameModelEdit#EpisodeNumber')
  - [ParquetClassLibrary#Games#IGameModelEdit#EpisodeTitle](#P-ParquetClassLibrary-Games-GameModel-ParquetClassLibrary#Games#IGameModelEdit#EpisodeTitle 'ParquetClassLibrary.Games.GameModel.ParquetClassLibrary#Games#IGameModelEdit#EpisodeTitle')
  - [ParquetClassLibrary#Games#IGameModelEdit#FirstScriptID](#P-ParquetClassLibrary-Games-GameModel-ParquetClassLibrary#Games#IGameModelEdit#FirstScriptID 'ParquetClassLibrary.Games.GameModel.ParquetClassLibrary#Games#IGameModelEdit#FirstScriptID')
  - [ParquetClassLibrary#Games#IGameModelEdit#IsEpisode](#P-ParquetClassLibrary-Games-GameModel-ParquetClassLibrary#Games#IGameModelEdit#IsEpisode 'ParquetClassLibrary.Games.GameModel.ParquetClassLibrary#Games#IGameModelEdit#IsEpisode')
  - [ParquetClassLibrary#Games#IGameModelEdit#PlayerCharacterID](#P-ParquetClassLibrary-Games-GameModel-ParquetClassLibrary#Games#IGameModelEdit#PlayerCharacterID 'ParquetClassLibrary.Games.GameModel.ParquetClassLibrary#Games#IGameModelEdit#PlayerCharacterID')
  - [PlayerCharacterID](#P-ParquetClassLibrary-Games-GameModel-PlayerCharacterID 'ParquetClassLibrary.Games.GameModel.PlayerCharacterID')
  - [ToString()](#M-ParquetClassLibrary-Games-GameModel-ToString 'ParquetClassLibrary.Games.GameModel.ToString')
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
- [IBeingModelEdit](#T-ParquetClassLibrary-Beings-IBeingModelEdit 'ParquetClassLibrary.Beings.IBeingModelEdit')
  - [AvoidsIDs](#P-ParquetClassLibrary-Beings-IBeingModelEdit-AvoidsIDs 'ParquetClassLibrary.Beings.IBeingModelEdit.AvoidsIDs')
  - [NativeBiomeID](#P-ParquetClassLibrary-Beings-IBeingModelEdit-NativeBiomeID 'ParquetClassLibrary.Beings.IBeingModelEdit.NativeBiomeID')
  - [PrimaryBehaviorID](#P-ParquetClassLibrary-Beings-IBeingModelEdit-PrimaryBehaviorID 'ParquetClassLibrary.Beings.IBeingModelEdit.PrimaryBehaviorID')
  - [SeeksIDs](#P-ParquetClassLibrary-Beings-IBeingModelEdit-SeeksIDs 'ParquetClassLibrary.Beings.IBeingModelEdit.SeeksIDs')
- [IBiomeRecipeEdit](#T-ParquetClassLibrary-Biomes-IBiomeRecipeEdit 'ParquetClassLibrary.Biomes.IBiomeRecipeEdit')
  - [EntryRequirements](#P-ParquetClassLibrary-Biomes-IBiomeRecipeEdit-EntryRequirements 'ParquetClassLibrary.Biomes.IBiomeRecipeEdit.EntryRequirements')
  - [IsLiquidBased](#P-ParquetClassLibrary-Biomes-IBiomeRecipeEdit-IsLiquidBased 'ParquetClassLibrary.Biomes.IBiomeRecipeEdit.IsLiquidBased')
  - [IsRoomBased](#P-ParquetClassLibrary-Biomes-IBiomeRecipeEdit-IsRoomBased 'ParquetClassLibrary.Biomes.IBiomeRecipeEdit.IsRoomBased')
  - [ParquetCriteria](#P-ParquetClassLibrary-Biomes-IBiomeRecipeEdit-ParquetCriteria 'ParquetClassLibrary.Biomes.IBiomeRecipeEdit.ParquetCriteria')
  - [Tier](#P-ParquetClassLibrary-Biomes-IBiomeRecipeEdit-Tier 'ParquetClassLibrary.Biomes.IBiomeRecipeEdit.Tier')
- [IBlockModelEdit](#T-ParquetClassLibrary-Parquets-IBlockModelEdit 'ParquetClassLibrary.Parquets.IBlockModelEdit')
  - [CollectibleID](#P-ParquetClassLibrary-Parquets-IBlockModelEdit-CollectibleID 'ParquetClassLibrary.Parquets.IBlockModelEdit.CollectibleID')
  - [GatherEffect](#P-ParquetClassLibrary-Parquets-IBlockModelEdit-GatherEffect 'ParquetClassLibrary.Parquets.IBlockModelEdit.GatherEffect')
  - [GatherTool](#P-ParquetClassLibrary-Parquets-IBlockModelEdit-GatherTool 'ParquetClassLibrary.Parquets.IBlockModelEdit.GatherTool')
  - [IsFlammable](#P-ParquetClassLibrary-Parquets-IBlockModelEdit-IsFlammable 'ParquetClassLibrary.Parquets.IBlockModelEdit.IsFlammable')
  - [IsLiquid](#P-ParquetClassLibrary-Parquets-IBlockModelEdit-IsLiquid 'ParquetClassLibrary.Parquets.IBlockModelEdit.IsLiquid')
  - [MaxToughness](#P-ParquetClassLibrary-Parquets-IBlockModelEdit-MaxToughness 'ParquetClassLibrary.Parquets.IBlockModelEdit.MaxToughness')
- [ICharacterModelEdit](#T-ParquetClassLibrary-Beings-ICharacterModelEdit 'ParquetClassLibrary.Beings.ICharacterModelEdit')
  - [FamilyName](#P-ParquetClassLibrary-Beings-ICharacterModelEdit-FamilyName 'ParquetClassLibrary.Beings.ICharacterModelEdit.FamilyName')
  - [PersonalName](#P-ParquetClassLibrary-Beings-ICharacterModelEdit-PersonalName 'ParquetClassLibrary.Beings.ICharacterModelEdit.PersonalName')
  - [Pronouns](#P-ParquetClassLibrary-Beings-ICharacterModelEdit-Pronouns 'ParquetClassLibrary.Beings.ICharacterModelEdit.Pronouns')
  - [StartingDialogueIDs](#P-ParquetClassLibrary-Beings-ICharacterModelEdit-StartingDialogueIDs 'ParquetClassLibrary.Beings.ICharacterModelEdit.StartingDialogueIDs')
  - [StartingInventoryIDs](#P-ParquetClassLibrary-Beings-ICharacterModelEdit-StartingInventoryIDs 'ParquetClassLibrary.Beings.ICharacterModelEdit.StartingInventoryIDs')
  - [StartingQuestIDs](#P-ParquetClassLibrary-Beings-ICharacterModelEdit-StartingQuestIDs 'ParquetClassLibrary.Beings.ICharacterModelEdit.StartingQuestIDs')
  - [StoryCharacterID](#P-ParquetClassLibrary-Beings-ICharacterModelEdit-StoryCharacterID 'ParquetClassLibrary.Beings.ICharacterModelEdit.StoryCharacterID')
- [ICollectibleModelEdit](#T-ParquetClassLibrary-Parquets-ICollectibleModelEdit 'ParquetClassLibrary.Parquets.ICollectibleModelEdit')
  - [CollectionEffect](#P-ParquetClassLibrary-Parquets-ICollectibleModelEdit-CollectionEffect 'ParquetClassLibrary.Parquets.ICollectibleModelEdit.CollectionEffect')
  - [EffectAmount](#P-ParquetClassLibrary-Parquets-ICollectibleModelEdit-EffectAmount 'ParquetClassLibrary.Parquets.ICollectibleModelEdit.EffectAmount')
- [ICraftingRecipeEdit](#T-ParquetClassLibrary-Crafts-ICraftingRecipeEdit 'ParquetClassLibrary.Crafts.ICraftingRecipeEdit')
  - [Ingredients](#P-ParquetClassLibrary-Crafts-ICraftingRecipeEdit-Ingredients 'ParquetClassLibrary.Crafts.ICraftingRecipeEdit.Ingredients')
  - [PanelPattern](#P-ParquetClassLibrary-Crafts-ICraftingRecipeEdit-PanelPattern 'ParquetClassLibrary.Crafts.ICraftingRecipeEdit.PanelPattern')
  - [Products](#P-ParquetClassLibrary-Crafts-ICraftingRecipeEdit-Products 'ParquetClassLibrary.Crafts.ICraftingRecipeEdit.Products')
- [ICritterModelEdit](#T-ParquetClassLibrary-Beings-ICritterModelEdit 'ParquetClassLibrary.Beings.ICritterModelEdit')
- [IDByDirection](#T-ParquetClassLibrary-Maps-MapAnalysis`1-IDByDirection 'ParquetClassLibrary.Maps.MapAnalysis`1.IDByDirection')
- [IFloorModelEdit](#T-ParquetClassLibrary-Parquets-IFloorModelEdit 'ParquetClassLibrary.Parquets.IFloorModelEdit')
  - [ModTool](#P-ParquetClassLibrary-Parquets-IFloorModelEdit-ModTool 'ParquetClassLibrary.Parquets.IFloorModelEdit.ModTool')
  - [TrenchName](#P-ParquetClassLibrary-Parquets-IFloorModelEdit-TrenchName 'ParquetClassLibrary.Parquets.IFloorModelEdit.TrenchName')
- [IFurnishingModelEdit](#T-ParquetClassLibrary-Parquets-IFurnishingModelEdit 'ParquetClassLibrary.Parquets.IFurnishingModelEdit')
  - [Entry](#P-ParquetClassLibrary-Parquets-IFurnishingModelEdit-Entry 'ParquetClassLibrary.Parquets.IFurnishingModelEdit.Entry')
  - [IsEnclosing](#P-ParquetClassLibrary-Parquets-IFurnishingModelEdit-IsEnclosing 'ParquetClassLibrary.Parquets.IFurnishingModelEdit.IsEnclosing')
  - [IsFlammable](#P-ParquetClassLibrary-Parquets-IFurnishingModelEdit-IsFlammable 'ParquetClassLibrary.Parquets.IFurnishingModelEdit.IsFlammable')
  - [IsWalkable](#P-ParquetClassLibrary-Parquets-IFurnishingModelEdit-IsWalkable 'ParquetClassLibrary.Parquets.IFurnishingModelEdit.IsWalkable')
  - [SwapID](#P-ParquetClassLibrary-Parquets-IFurnishingModelEdit-SwapID 'ParquetClassLibrary.Parquets.IFurnishingModelEdit.SwapID')
- [IGameModelEdit](#T-ParquetClassLibrary-Games-IGameModelEdit 'ParquetClassLibrary.Games.IGameModelEdit')
  - [EpisodeNumber](#P-ParquetClassLibrary-Games-IGameModelEdit-EpisodeNumber 'ParquetClassLibrary.Games.IGameModelEdit.EpisodeNumber')
  - [EpisodeTitle](#P-ParquetClassLibrary-Games-IGameModelEdit-EpisodeTitle 'ParquetClassLibrary.Games.IGameModelEdit.EpisodeTitle')
  - [FirstScriptID](#P-ParquetClassLibrary-Games-IGameModelEdit-FirstScriptID 'ParquetClassLibrary.Games.IGameModelEdit.FirstScriptID')
  - [IsEpisode](#P-ParquetClassLibrary-Games-IGameModelEdit-IsEpisode 'ParquetClassLibrary.Games.IGameModelEdit.IsEpisode')
  - [PlayerCharacterID](#P-ParquetClassLibrary-Games-IGameModelEdit-PlayerCharacterID 'ParquetClassLibrary.Games.IGameModelEdit.PlayerCharacterID')
- [IGrid\`1](#T-ParquetClassLibrary-IGrid`1 'ParquetClassLibrary.IGrid`1')
  - [Columns](#P-ParquetClassLibrary-IGrid`1-Columns 'ParquetClassLibrary.IGrid`1.Columns')
  - [Item](#P-ParquetClassLibrary-IGrid`1-Item-System-Int32,System-Int32- 'ParquetClassLibrary.IGrid`1.Item(System.Int32,System.Int32)')
  - [Rows](#P-ParquetClassLibrary-IGrid`1-Rows 'ParquetClassLibrary.IGrid`1.Rows')
- [IInteractionModelEdit](#T-ParquetClassLibrary-Scripts-IInteractionModelEdit 'ParquetClassLibrary.Scripts.IInteractionModelEdit')
  - [OutcomesIDs](#P-ParquetClassLibrary-Scripts-IInteractionModelEdit-OutcomesIDs 'ParquetClassLibrary.Scripts.IInteractionModelEdit.OutcomesIDs')
  - [PrerequisitesIDs](#P-ParquetClassLibrary-Scripts-IInteractionModelEdit-PrerequisitesIDs 'ParquetClassLibrary.Scripts.IInteractionModelEdit.PrerequisitesIDs')
  - [StepsIDs](#P-ParquetClassLibrary-Scripts-IInteractionModelEdit-StepsIDs 'ParquetClassLibrary.Scripts.IInteractionModelEdit.StepsIDs')
- [IItemModelEdit](#T-ParquetClassLibrary-Items-IItemModelEdit 'ParquetClassLibrary.Items.IItemModelEdit')
  - [EffectWhenUsedID](#P-ParquetClassLibrary-Items-IItemModelEdit-EffectWhenUsedID 'ParquetClassLibrary.Items.IItemModelEdit.EffectWhenUsedID')
  - [EffectWhileHeldID](#P-ParquetClassLibrary-Items-IItemModelEdit-EffectWhileHeldID 'ParquetClassLibrary.Items.IItemModelEdit.EffectWhileHeldID')
  - [ItemTags](#P-ParquetClassLibrary-Items-IItemModelEdit-ItemTags 'ParquetClassLibrary.Items.IItemModelEdit.ItemTags')
  - [ParquetID](#P-ParquetClassLibrary-Items-IItemModelEdit-ParquetID 'ParquetClassLibrary.Items.IItemModelEdit.ParquetID')
  - [Price](#P-ParquetClassLibrary-Items-IItemModelEdit-Price 'ParquetClassLibrary.Items.IItemModelEdit.Price')
  - [Rarity](#P-ParquetClassLibrary-Items-IItemModelEdit-Rarity 'ParquetClassLibrary.Items.IItemModelEdit.Rarity')
  - [StackMax](#P-ParquetClassLibrary-Items-IItemModelEdit-StackMax 'ParquetClassLibrary.Items.IItemModelEdit.StackMax')
  - [Subtype](#P-ParquetClassLibrary-Items-IItemModelEdit-Subtype 'ParquetClassLibrary.Items.IItemModelEdit.Subtype')
- [IMapRegionEdit](#T-ParquetClassLibrary-Maps-IMapRegionEdit 'ParquetClassLibrary.Maps.IMapRegionEdit')
  - [BackgroundColor](#P-ParquetClassLibrary-Maps-IMapRegionEdit-BackgroundColor 'ParquetClassLibrary.Maps.IMapRegionEdit.BackgroundColor')
  - [RegionAboveID](#P-ParquetClassLibrary-Maps-IMapRegionEdit-RegionAboveID 'ParquetClassLibrary.Maps.IMapRegionEdit.RegionAboveID')
  - [RegionBelowID](#P-ParquetClassLibrary-Maps-IMapRegionEdit-RegionBelowID 'ParquetClassLibrary.Maps.IMapRegionEdit.RegionBelowID')
  - [RegionToTheEastID](#P-ParquetClassLibrary-Maps-IMapRegionEdit-RegionToTheEastID 'ParquetClassLibrary.Maps.IMapRegionEdit.RegionToTheEastID')
  - [RegionToTheNorthID](#P-ParquetClassLibrary-Maps-IMapRegionEdit-RegionToTheNorthID 'ParquetClassLibrary.Maps.IMapRegionEdit.RegionToTheNorthID')
  - [RegionToTheSouthID](#P-ParquetClassLibrary-Maps-IMapRegionEdit-RegionToTheSouthID 'ParquetClassLibrary.Maps.IMapRegionEdit.RegionToTheSouthID')
  - [RegionToTheWestID](#P-ParquetClassLibrary-Maps-IMapRegionEdit-RegionToTheWestID 'ParquetClassLibrary.Maps.IMapRegionEdit.RegionToTheWestID')
- [IModelCollectionEdit\`1](#T-ParquetClassLibrary-IModelCollectionEdit`1 'ParquetClassLibrary.IModelCollectionEdit`1')
  - [Add(inModel)](#M-ParquetClassLibrary-IModelCollectionEdit`1-Add-`0- 'ParquetClassLibrary.IModelCollectionEdit`1.Add(`0)')
  - [Clear()](#M-ParquetClassLibrary-IModelCollectionEdit`1-Clear 'ParquetClassLibrary.IModelCollectionEdit`1.Clear')
  - [Remove(inModel)](#M-ParquetClassLibrary-IModelCollectionEdit`1-Remove-`0- 'ParquetClassLibrary.IModelCollectionEdit`1.Remove(`0)')
  - [Remove(inID)](#M-ParquetClassLibrary-IModelCollectionEdit`1-Remove-ParquetClassLibrary-ModelID- 'ParquetClassLibrary.IModelCollectionEdit`1.Remove(ParquetClassLibrary.ModelID)')
  - [Replace(inModel)](#M-ParquetClassLibrary-IModelCollectionEdit`1-Replace-`0- 'ParquetClassLibrary.IModelCollectionEdit`1.Replace(`0)')
- [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit')
  - [Comment](#P-ParquetClassLibrary-IModelEdit-Comment 'ParquetClassLibrary.IModelEdit.Comment')
  - [Description](#P-ParquetClassLibrary-IModelEdit-Description 'ParquetClassLibrary.IModelEdit.Description')
  - [ID](#P-ParquetClassLibrary-IModelEdit-ID 'ParquetClassLibrary.IModelEdit.ID')
  - [Name](#P-ParquetClassLibrary-IModelEdit-Name 'ParquetClassLibrary.IModelEdit.Name')
- [IParquetModelEdit](#T-ParquetClassLibrary-Parquets-IParquetModelEdit 'ParquetClassLibrary.Parquets.IParquetModelEdit')
  - [AddsToBiome](#P-ParquetClassLibrary-Parquets-IParquetModelEdit-AddsToBiome 'ParquetClassLibrary.Parquets.IParquetModelEdit.AddsToBiome')
  - [AddsToRoom](#P-ParquetClassLibrary-Parquets-IParquetModelEdit-AddsToRoom 'ParquetClassLibrary.Parquets.IParquetModelEdit.AddsToRoom')
  - [ItemID](#P-ParquetClassLibrary-Parquets-IParquetModelEdit-ItemID 'ParquetClassLibrary.Parquets.IParquetModelEdit.ItemID')
- [IParquetStack](#T-ParquetClassLibrary-Parquets-IParquetStack 'ParquetClassLibrary.Parquets.IParquetStack')
  - [BlockID](#P-ParquetClassLibrary-Parquets-IParquetStack-BlockID 'ParquetClassLibrary.Parquets.IParquetStack.BlockID')
  - [CollectibleID](#P-ParquetClassLibrary-Parquets-IParquetStack-CollectibleID 'ParquetClassLibrary.Parquets.IParquetStack.CollectibleID')
  - [FloorID](#P-ParquetClassLibrary-Parquets-IParquetStack-FloorID 'ParquetClassLibrary.Parquets.IParquetStack.FloorID')
  - [FurnishingID](#P-ParquetClassLibrary-Parquets-IParquetStack-FurnishingID 'ParquetClassLibrary.Parquets.IParquetStack.FurnishingID')
  - [IsEmpty](#P-ParquetClassLibrary-Parquets-IParquetStack-IsEmpty 'ParquetClassLibrary.Parquets.IParquetStack.IsEmpty')
- [IPronounGroupEdit](#T-ParquetClassLibrary-Beings-IPronounGroupEdit 'ParquetClassLibrary.Beings.IPronounGroupEdit')
  - [Determiner](#P-ParquetClassLibrary-Beings-IPronounGroupEdit-Determiner 'ParquetClassLibrary.Beings.IPronounGroupEdit.Determiner')
  - [Objective](#P-ParquetClassLibrary-Beings-IPronounGroupEdit-Objective 'ParquetClassLibrary.Beings.IPronounGroupEdit.Objective')
  - [Possessive](#P-ParquetClassLibrary-Beings-IPronounGroupEdit-Possessive 'ParquetClassLibrary.Beings.IPronounGroupEdit.Possessive')
  - [Reflexive](#P-ParquetClassLibrary-Beings-IPronounGroupEdit-Reflexive 'ParquetClassLibrary.Beings.IPronounGroupEdit.Reflexive')
  - [Subjective](#P-ParquetClassLibrary-Beings-IPronounGroupEdit-Subjective 'ParquetClassLibrary.Beings.IPronounGroupEdit.Subjective')
- [IRoomRecipeEdit](#T-ParquetClassLibrary-Rooms-IRoomRecipeEdit 'ParquetClassLibrary.Rooms.IRoomRecipeEdit')
  - [MinimumWalkableSpaces](#P-ParquetClassLibrary-Rooms-IRoomRecipeEdit-MinimumWalkableSpaces 'ParquetClassLibrary.Rooms.IRoomRecipeEdit.MinimumWalkableSpaces')
  - [OptionallyRequiredFurnishings](#P-ParquetClassLibrary-Rooms-IRoomRecipeEdit-OptionallyRequiredFurnishings 'ParquetClassLibrary.Rooms.IRoomRecipeEdit.OptionallyRequiredFurnishings')
  - [OptionallyRequiredPerimeterBlocks](#P-ParquetClassLibrary-Rooms-IRoomRecipeEdit-OptionallyRequiredPerimeterBlocks 'ParquetClassLibrary.Rooms.IRoomRecipeEdit.OptionallyRequiredPerimeterBlocks')
  - [OptionallyRequiredWalkableFloors](#P-ParquetClassLibrary-Rooms-IRoomRecipeEdit-OptionallyRequiredWalkableFloors 'ParquetClassLibrary.Rooms.IRoomRecipeEdit.OptionallyRequiredWalkableFloors')
- [IScriptModelEdit](#T-ParquetClassLibrary-Scripts-IScriptModelEdit 'ParquetClassLibrary.Scripts.IScriptModelEdit')
  - [Nodes](#P-ParquetClassLibrary-Scripts-IScriptModelEdit-Nodes 'ParquetClassLibrary.Scripts.IScriptModelEdit.Nodes')
- [IntExtensions](#T-ParquetClassLibrary-IntExtensions 'ParquetClassLibrary.IntExtensions')
  - [Normalize(inInt,inLowerBound,inUpperBound)](#M-ParquetClassLibrary-IntExtensions-Normalize-System-Int32,System-Int32,System-Int32- 'ParquetClassLibrary.IntExtensions.Normalize(System.Int32,System.Int32,System.Int32)')
- [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel')
  - [#ctor(inID,inName,inDescription,inComment,inPrerequisitesIDs,inStepsIDs,inOutcomesIDs)](#M-ParquetClassLibrary-Scripts-InteractionModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID}- 'ParquetClassLibrary.Scripts.InteractionModel.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID},System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID},System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID})')
  - [OutcomesIDs](#P-ParquetClassLibrary-Scripts-InteractionModel-OutcomesIDs 'ParquetClassLibrary.Scripts.InteractionModel.OutcomesIDs')
  - [ParquetClassLibrary#Scripts#IInteractionModelEdit#OutcomesIDs](#P-ParquetClassLibrary-Scripts-InteractionModel-ParquetClassLibrary#Scripts#IInteractionModelEdit#OutcomesIDs 'ParquetClassLibrary.Scripts.InteractionModel.ParquetClassLibrary#Scripts#IInteractionModelEdit#OutcomesIDs')
  - [ParquetClassLibrary#Scripts#IInteractionModelEdit#PrerequisitesIDs](#P-ParquetClassLibrary-Scripts-InteractionModel-ParquetClassLibrary#Scripts#IInteractionModelEdit#PrerequisitesIDs 'ParquetClassLibrary.Scripts.InteractionModel.ParquetClassLibrary#Scripts#IInteractionModelEdit#PrerequisitesIDs')
  - [ParquetClassLibrary#Scripts#IInteractionModelEdit#StepsIDs](#P-ParquetClassLibrary-Scripts-InteractionModel-ParquetClassLibrary#Scripts#IInteractionModelEdit#StepsIDs 'ParquetClassLibrary.Scripts.InteractionModel.ParquetClassLibrary#Scripts#IInteractionModelEdit#StepsIDs')
  - [PrerequisitesIDs](#P-ParquetClassLibrary-Scripts-InteractionModel-PrerequisitesIDs 'ParquetClassLibrary.Scripts.InteractionModel.PrerequisitesIDs')
  - [StepsIDs](#P-ParquetClassLibrary-Scripts-InteractionModel-StepsIDs 'ParquetClassLibrary.Scripts.InteractionModel.StepsIDs')
- [InteractionStatus](#T-ParquetClassLibrary-Scripts-InteractionStatus 'ParquetClassLibrary.Scripts.InteractionStatus')
  - [#ctor(inInteractionDefinition,inState,inProgramCounter)](#M-ParquetClassLibrary-Scripts-InteractionStatus-#ctor-ParquetClassLibrary-Scripts-InteractionModel,ParquetClassLibrary-Scripts-RunState,System-Int32- 'ParquetClassLibrary.Scripts.InteractionStatus.#ctor(ParquetClassLibrary.Scripts.InteractionModel,ParquetClassLibrary.Scripts.RunState,System.Int32)')
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
  - [#ctor(inID,inName,inDescription,inComment,inSubtype,inPrice,inRarity,inStackMax,inEffectWhileHeldID,inEffectWhenUsedID,inParquetID,inItemTags)](#M-ParquetClassLibrary-Items-ItemModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,ParquetClassLibrary-Items-ItemType,System-Int32,System-Int32,System-Int32,System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag}- 'ParquetClassLibrary.Items.ItemModel.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,ParquetClassLibrary.Items.ItemType,System.Int32,System.Int32,System.Int32,System.Nullable{ParquetClassLibrary.ModelID},System.Nullable{ParquetClassLibrary.ModelID},System.Nullable{ParquetClassLibrary.ModelID},System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag})')
  - [DefaultStackMax](#F-ParquetClassLibrary-Items-ItemModel-DefaultStackMax 'ParquetClassLibrary.Items.ItemModel.DefaultStackMax')
  - [EffectWhenUsedID](#P-ParquetClassLibrary-Items-ItemModel-EffectWhenUsedID 'ParquetClassLibrary.Items.ItemModel.EffectWhenUsedID')
  - [EffectWhileHeldID](#P-ParquetClassLibrary-Items-ItemModel-EffectWhileHeldID 'ParquetClassLibrary.Items.ItemModel.EffectWhileHeldID')
  - [ItemTags](#P-ParquetClassLibrary-Items-ItemModel-ItemTags 'ParquetClassLibrary.Items.ItemModel.ItemTags')
  - [ParquetClassLibrary#Items#IItemModelEdit#EffectWhenUsedID](#P-ParquetClassLibrary-Items-ItemModel-ParquetClassLibrary#Items#IItemModelEdit#EffectWhenUsedID 'ParquetClassLibrary.Items.ItemModel.ParquetClassLibrary#Items#IItemModelEdit#EffectWhenUsedID')
  - [ParquetClassLibrary#Items#IItemModelEdit#EffectWhileHeldID](#P-ParquetClassLibrary-Items-ItemModel-ParquetClassLibrary#Items#IItemModelEdit#EffectWhileHeldID 'ParquetClassLibrary.Items.ItemModel.ParquetClassLibrary#Items#IItemModelEdit#EffectWhileHeldID')
  - [ParquetClassLibrary#Items#IItemModelEdit#ItemTags](#P-ParquetClassLibrary-Items-ItemModel-ParquetClassLibrary#Items#IItemModelEdit#ItemTags 'ParquetClassLibrary.Items.ItemModel.ParquetClassLibrary#Items#IItemModelEdit#ItemTags')
  - [ParquetClassLibrary#Items#IItemModelEdit#ParquetID](#P-ParquetClassLibrary-Items-ItemModel-ParquetClassLibrary#Items#IItemModelEdit#ParquetID 'ParquetClassLibrary.Items.ItemModel.ParquetClassLibrary#Items#IItemModelEdit#ParquetID')
  - [ParquetClassLibrary#Items#IItemModelEdit#Price](#P-ParquetClassLibrary-Items-ItemModel-ParquetClassLibrary#Items#IItemModelEdit#Price 'ParquetClassLibrary.Items.ItemModel.ParquetClassLibrary#Items#IItemModelEdit#Price')
  - [ParquetClassLibrary#Items#IItemModelEdit#Rarity](#P-ParquetClassLibrary-Items-ItemModel-ParquetClassLibrary#Items#IItemModelEdit#Rarity 'ParquetClassLibrary.Items.ItemModel.ParquetClassLibrary#Items#IItemModelEdit#Rarity')
  - [ParquetClassLibrary#Items#IItemModelEdit#StackMax](#P-ParquetClassLibrary-Items-ItemModel-ParquetClassLibrary#Items#IItemModelEdit#StackMax 'ParquetClassLibrary.Items.ItemModel.ParquetClassLibrary#Items#IItemModelEdit#StackMax')
  - [ParquetClassLibrary#Items#IItemModelEdit#Subtype](#P-ParquetClassLibrary-Items-ItemModel-ParquetClassLibrary#Items#IItemModelEdit#Subtype 'ParquetClassLibrary.Items.ItemModel.ParquetClassLibrary#Items#IItemModelEdit#Subtype')
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
- [MapAnalysis](#T-ParquetClassLibrary-Maps-MapAnalysis 'ParquetClassLibrary.Maps.MapAnalysis')
  - [CheckExitConsistency\`\`1(inRegionID)](#M-ParquetClassLibrary-Maps-MapAnalysis-CheckExitConsistency``1-ParquetClassLibrary-ModelID- 'ParquetClassLibrary.Maps.MapAnalysis.CheckExitConsistency``1(ParquetClassLibrary.ModelID)')
- [MapAnalysis\`1](#T-ParquetClassLibrary-Maps-MapAnalysis`1 'ParquetClassLibrary.Maps.MapAnalysis`1')
  - [Directions](#F-ParquetClassLibrary-Maps-MapAnalysis`1-Directions 'ParquetClassLibrary.Maps.MapAnalysis`1.Directions')
- [MapChunkModel](#T-ParquetClassLibrary-Maps-MapChunkModel 'ParquetClassLibrary.Maps.MapChunkModel')
  - [#ctor(inID,inName,inDescription,inComment,inRevision,inIsFilledOut,inDetails,inParquetDefinitions)](#M-ParquetClassLibrary-Maps-MapChunkModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Int32,System-Boolean,ParquetClassLibrary-Maps-ChunkDetail,ParquetClassLibrary-Parquets-ParquetStackGrid- 'ParquetClassLibrary.Maps.MapChunkModel.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.Int32,System.Boolean,ParquetClassLibrary.Maps.ChunkDetail,ParquetClassLibrary.Parquets.ParquetStackGrid)')
  - [ParquetsPerChunkDimension](#F-ParquetClassLibrary-Maps-MapChunkModel-ParquetsPerChunkDimension 'ParquetClassLibrary.Maps.MapChunkModel.ParquetsPerChunkDimension')
  - [Bounds](#P-ParquetClassLibrary-Maps-MapChunkModel-Bounds 'ParquetClassLibrary.Maps.MapChunkModel.Bounds')
  - [Details](#P-ParquetClassLibrary-Maps-MapChunkModel-Details 'ParquetClassLibrary.Maps.MapChunkModel.Details')
  - [DimensionsInParquets](#P-ParquetClassLibrary-Maps-MapChunkModel-DimensionsInParquets 'ParquetClassLibrary.Maps.MapChunkModel.DimensionsInParquets')
  - [Empty](#P-ParquetClassLibrary-Maps-MapChunkModel-Empty 'ParquetClassLibrary.Maps.MapChunkModel.Empty')
  - [IsFilledOut](#P-ParquetClassLibrary-Maps-MapChunkModel-IsFilledOut 'ParquetClassLibrary.Maps.MapChunkModel.IsFilledOut')
  - [ParquetDefinitions](#P-ParquetClassLibrary-Maps-MapChunkModel-ParquetDefinitions 'ParquetClassLibrary.Maps.MapChunkModel.ParquetDefinitions')
  - [Generate()](#M-ParquetClassLibrary-Maps-MapChunkModel-Generate 'ParquetClassLibrary.Maps.MapChunkModel.Generate')
  - [ToString()](#M-ParquetClassLibrary-Maps-MapChunkModel-ToString 'ParquetClassLibrary.Maps.MapChunkModel.ToString')
- [MapModel](#T-ParquetClassLibrary-Maps-MapModel 'ParquetClassLibrary.Maps.MapModel')
  - [#ctor(inBounds,inID,inName,inDescription,inComment,inRevision)](#M-ParquetClassLibrary-Maps-MapModel-#ctor-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Int32- 'ParquetClassLibrary.Maps.MapModel.#ctor(ParquetClassLibrary.Range{ParquetClassLibrary.ModelID},ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.Int32)')
  - [DimensionsInParquets](#P-ParquetClassLibrary-Maps-MapModel-DimensionsInParquets 'ParquetClassLibrary.Maps.MapModel.DimensionsInParquets')
  - [ParquetDefinitions](#P-ParquetClassLibrary-Maps-MapModel-ParquetDefinitions 'ParquetClassLibrary.Maps.MapModel.ParquetDefinitions')
  - [ParquetsCount](#P-ParquetClassLibrary-Maps-MapModel-ParquetsCount 'ParquetClassLibrary.Maps.MapModel.ParquetsCount')
  - [Revision](#P-ParquetClassLibrary-Maps-MapModel-Revision 'ParquetClassLibrary.Maps.MapModel.Revision')
  - [GetSubregion()](#M-ParquetClassLibrary-Maps-MapModel-GetSubregion 'ParquetClassLibrary.Maps.MapModel.GetSubregion')
  - [GetSubregion(inUpperLeft,inLowerRight)](#M-ParquetClassLibrary-Maps-MapModel-GetSubregion-ParquetClassLibrary-Vector2D,ParquetClassLibrary-Vector2D- 'ParquetClassLibrary.Maps.MapModel.GetSubregion(ParquetClassLibrary.Vector2D,ParquetClassLibrary.Vector2D)')
  - [IsValidPosition(inPosition)](#M-ParquetClassLibrary-Maps-MapModel-IsValidPosition-ParquetClassLibrary-Vector2D- 'ParquetClassLibrary.Maps.MapModel.IsValidPosition(ParquetClassLibrary.Vector2D)')
  - [ToString()](#M-ParquetClassLibrary-Maps-MapModel-ToString 'ParquetClassLibrary.Maps.MapModel.ToString')
- [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel')
  - [#ctor(inID,inName,inDescription,inComment,inRevision,inBackgroundColor,inRegionToTheNorth,inRegionToTheEast,inRegionToTheSouth,inRegionToTheWest,inRegionAbove,inRegionBelow,inParquetStatuses,inParquetDefinitions)](#M-ParquetClassLibrary-Maps-MapRegionModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Int32,System-String,System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID},ParquetClassLibrary-Parquets-ParquetStatusGrid,ParquetClassLibrary-Parquets-ParquetStackGrid- 'ParquetClassLibrary.Maps.MapRegionModel.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.Int32,System.String,System.Nullable{ParquetClassLibrary.ModelID},System.Nullable{ParquetClassLibrary.ModelID},System.Nullable{ParquetClassLibrary.ModelID},System.Nullable{ParquetClassLibrary.ModelID},System.Nullable{ParquetClassLibrary.ModelID},System.Nullable{ParquetClassLibrary.ModelID},ParquetClassLibrary.Parquets.ParquetStatusGrid,ParquetClassLibrary.Parquets.ParquetStackGrid)')
  - [DefaultColor](#F-ParquetClassLibrary-Maps-MapRegionModel-DefaultColor 'ParquetClassLibrary.Maps.MapRegionModel.DefaultColor')
  - [Empty](#F-ParquetClassLibrary-Maps-MapRegionModel-Empty 'ParquetClassLibrary.Maps.MapRegionModel.Empty')
  - [ParquetsPerRegionDimension](#F-ParquetClassLibrary-Maps-MapRegionModel-ParquetsPerRegionDimension 'ParquetClassLibrary.Maps.MapRegionModel.ParquetsPerRegionDimension')
  - [BackgroundColor](#P-ParquetClassLibrary-Maps-MapRegionModel-BackgroundColor 'ParquetClassLibrary.Maps.MapRegionModel.BackgroundColor')
  - [Bounds](#P-ParquetClassLibrary-Maps-MapRegionModel-Bounds 'ParquetClassLibrary.Maps.MapRegionModel.Bounds')
  - [DimensionsInParquets](#P-ParquetClassLibrary-Maps-MapRegionModel-DimensionsInParquets 'ParquetClassLibrary.Maps.MapRegionModel.DimensionsInParquets')
  - [ParquetClassLibrary#IModelEdit#Name](#P-ParquetClassLibrary-Maps-MapRegionModel-ParquetClassLibrary#IModelEdit#Name 'ParquetClassLibrary.Maps.MapRegionModel.ParquetClassLibrary#IModelEdit#Name')
  - [ParquetClassLibrary#Maps#IMapRegionEdit#BackgroundColor](#P-ParquetClassLibrary-Maps-MapRegionModel-ParquetClassLibrary#Maps#IMapRegionEdit#BackgroundColor 'ParquetClassLibrary.Maps.MapRegionModel.ParquetClassLibrary#Maps#IMapRegionEdit#BackgroundColor')
  - [ParquetClassLibrary#Maps#IMapRegionEdit#RegionAboveID](#P-ParquetClassLibrary-Maps-MapRegionModel-ParquetClassLibrary#Maps#IMapRegionEdit#RegionAboveID 'ParquetClassLibrary.Maps.MapRegionModel.ParquetClassLibrary#Maps#IMapRegionEdit#RegionAboveID')
  - [ParquetClassLibrary#Maps#IMapRegionEdit#RegionBelowID](#P-ParquetClassLibrary-Maps-MapRegionModel-ParquetClassLibrary#Maps#IMapRegionEdit#RegionBelowID 'ParquetClassLibrary.Maps.MapRegionModel.ParquetClassLibrary#Maps#IMapRegionEdit#RegionBelowID')
  - [ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheEastID](#P-ParquetClassLibrary-Maps-MapRegionModel-ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheEastID 'ParquetClassLibrary.Maps.MapRegionModel.ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheEastID')
  - [ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheNorthID](#P-ParquetClassLibrary-Maps-MapRegionModel-ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheNorthID 'ParquetClassLibrary.Maps.MapRegionModel.ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheNorthID')
  - [ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheSouthID](#P-ParquetClassLibrary-Maps-MapRegionModel-ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheSouthID 'ParquetClassLibrary.Maps.MapRegionModel.ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheSouthID')
  - [ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheWestID](#P-ParquetClassLibrary-Maps-MapRegionModel-ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheWestID 'ParquetClassLibrary.Maps.MapRegionModel.ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheWestID')
  - [ParquetDefinitions](#P-ParquetClassLibrary-Maps-MapRegionModel-ParquetDefinitions 'ParquetClassLibrary.Maps.MapRegionModel.ParquetDefinitions')
  - [ParquetStatuses](#P-ParquetClassLibrary-Maps-MapRegionModel-ParquetStatuses 'ParquetClassLibrary.Maps.MapRegionModel.ParquetStatuses')
  - [RegionAbove](#P-ParquetClassLibrary-Maps-MapRegionModel-RegionAbove 'ParquetClassLibrary.Maps.MapRegionModel.RegionAbove')
  - [RegionBelow](#P-ParquetClassLibrary-Maps-MapRegionModel-RegionBelow 'ParquetClassLibrary.Maps.MapRegionModel.RegionBelow')
  - [RegionToTheEast](#P-ParquetClassLibrary-Maps-MapRegionModel-RegionToTheEast 'ParquetClassLibrary.Maps.MapRegionModel.RegionToTheEast')
  - [RegionToTheNorth](#P-ParquetClassLibrary-Maps-MapRegionModel-RegionToTheNorth 'ParquetClassLibrary.Maps.MapRegionModel.RegionToTheNorth')
  - [RegionToTheSouth](#P-ParquetClassLibrary-Maps-MapRegionModel-RegionToTheSouth 'ParquetClassLibrary.Maps.MapRegionModel.RegionToTheSouth')
  - [RegionToTheWest](#P-ParquetClassLibrary-Maps-MapRegionModel-RegionToTheWest 'ParquetClassLibrary.Maps.MapRegionModel.RegionToTheWest')
  - [Rooms](#P-ParquetClassLibrary-Maps-MapRegionModel-Rooms 'ParquetClassLibrary.Maps.MapRegionModel.Rooms')
  - [GetBiome()](#M-ParquetClassLibrary-Maps-MapRegionModel-GetBiome 'ParquetClassLibrary.Maps.MapRegionModel.GetBiome')
  - [ToString()](#M-ParquetClassLibrary-Maps-MapRegionModel-ToString 'ParquetClassLibrary.Maps.MapRegionModel.ToString')
- [MapRegionSketch](#T-ParquetClassLibrary-Maps-MapRegionSketch 'ParquetClassLibrary.Maps.MapRegionSketch')
  - [#ctor(inID,inName,inDescription,inComment,inRevision,inBackgroundColor,inRegionToTheNorth,inRegionToTheEast,inRegionToTheSouth,inRegionToTheWest,inRegionAbove,inRegionBelow,inChunks)](#M-ParquetClassLibrary-Maps-MapRegionSketch-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Int32,System-String,System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID},ParquetClassLibrary-ModelIDGrid- 'ParquetClassLibrary.Maps.MapRegionSketch.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.Int32,System.String,System.Nullable{ParquetClassLibrary.ModelID},System.Nullable{ParquetClassLibrary.ModelID},System.Nullable{ParquetClassLibrary.ModelID},System.Nullable{ParquetClassLibrary.ModelID},System.Nullable{ParquetClassLibrary.ModelID},System.Nullable{ParquetClassLibrary.ModelID},ParquetClassLibrary.ModelIDGrid)')
  - [ChunksPerRegionDimension](#F-ParquetClassLibrary-Maps-MapRegionSketch-ChunksPerRegionDimension 'ParquetClassLibrary.Maps.MapRegionSketch.ChunksPerRegionDimension')
  - [DefaultColor](#F-ParquetClassLibrary-Maps-MapRegionSketch-DefaultColor 'ParquetClassLibrary.Maps.MapRegionSketch.DefaultColor')
  - [Empty](#F-ParquetClassLibrary-Maps-MapRegionSketch-Empty 'ParquetClassLibrary.Maps.MapRegionSketch.Empty')
  - [BackgroundColor](#P-ParquetClassLibrary-Maps-MapRegionSketch-BackgroundColor 'ParquetClassLibrary.Maps.MapRegionSketch.BackgroundColor')
  - [Bounds](#P-ParquetClassLibrary-Maps-MapRegionSketch-Bounds 'ParquetClassLibrary.Maps.MapRegionSketch.Bounds')
  - [Chunks](#P-ParquetClassLibrary-Maps-MapRegionSketch-Chunks 'ParquetClassLibrary.Maps.MapRegionSketch.Chunks')
  - [DimensionsInChunks](#P-ParquetClassLibrary-Maps-MapRegionSketch-DimensionsInChunks 'ParquetClassLibrary.Maps.MapRegionSketch.DimensionsInChunks')
  - [DimensionsInParquets](#P-ParquetClassLibrary-Maps-MapRegionSketch-DimensionsInParquets 'ParquetClassLibrary.Maps.MapRegionSketch.DimensionsInParquets')
  - [ParquetClassLibrary#IModelEdit#Name](#P-ParquetClassLibrary-Maps-MapRegionSketch-ParquetClassLibrary#IModelEdit#Name 'ParquetClassLibrary.Maps.MapRegionSketch.ParquetClassLibrary#IModelEdit#Name')
  - [ParquetClassLibrary#Maps#IMapRegionEdit#BackgroundColor](#P-ParquetClassLibrary-Maps-MapRegionSketch-ParquetClassLibrary#Maps#IMapRegionEdit#BackgroundColor 'ParquetClassLibrary.Maps.MapRegionSketch.ParquetClassLibrary#Maps#IMapRegionEdit#BackgroundColor')
  - [ParquetClassLibrary#Maps#IMapRegionEdit#RegionAboveID](#P-ParquetClassLibrary-Maps-MapRegionSketch-ParquetClassLibrary#Maps#IMapRegionEdit#RegionAboveID 'ParquetClassLibrary.Maps.MapRegionSketch.ParquetClassLibrary#Maps#IMapRegionEdit#RegionAboveID')
  - [ParquetClassLibrary#Maps#IMapRegionEdit#RegionBelowID](#P-ParquetClassLibrary-Maps-MapRegionSketch-ParquetClassLibrary#Maps#IMapRegionEdit#RegionBelowID 'ParquetClassLibrary.Maps.MapRegionSketch.ParquetClassLibrary#Maps#IMapRegionEdit#RegionBelowID')
  - [ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheEastID](#P-ParquetClassLibrary-Maps-MapRegionSketch-ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheEastID 'ParquetClassLibrary.Maps.MapRegionSketch.ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheEastID')
  - [ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheNorthID](#P-ParquetClassLibrary-Maps-MapRegionSketch-ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheNorthID 'ParquetClassLibrary.Maps.MapRegionSketch.ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheNorthID')
  - [ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheSouthID](#P-ParquetClassLibrary-Maps-MapRegionSketch-ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheSouthID 'ParquetClassLibrary.Maps.MapRegionSketch.ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheSouthID')
  - [ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheWestID](#P-ParquetClassLibrary-Maps-MapRegionSketch-ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheWestID 'ParquetClassLibrary.Maps.MapRegionSketch.ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheWestID')
  - [ParquetDefinitions](#P-ParquetClassLibrary-Maps-MapRegionSketch-ParquetDefinitions 'ParquetClassLibrary.Maps.MapRegionSketch.ParquetDefinitions')
  - [RegionAbove](#P-ParquetClassLibrary-Maps-MapRegionSketch-RegionAbove 'ParquetClassLibrary.Maps.MapRegionSketch.RegionAbove')
  - [RegionBelow](#P-ParquetClassLibrary-Maps-MapRegionSketch-RegionBelow 'ParquetClassLibrary.Maps.MapRegionSketch.RegionBelow')
  - [RegionToTheEast](#P-ParquetClassLibrary-Maps-MapRegionSketch-RegionToTheEast 'ParquetClassLibrary.Maps.MapRegionSketch.RegionToTheEast')
  - [RegionToTheNorth](#P-ParquetClassLibrary-Maps-MapRegionSketch-RegionToTheNorth 'ParquetClassLibrary.Maps.MapRegionSketch.RegionToTheNorth')
  - [RegionToTheSouth](#P-ParquetClassLibrary-Maps-MapRegionSketch-RegionToTheSouth 'ParquetClassLibrary.Maps.MapRegionSketch.RegionToTheSouth')
  - [RegionToTheWest](#P-ParquetClassLibrary-Maps-MapRegionSketch-RegionToTheWest 'ParquetClassLibrary.Maps.MapRegionSketch.RegionToTheWest')
  - [Stitch()](#M-ParquetClassLibrary-Maps-MapRegionSketch-Stitch 'ParquetClassLibrary.Maps.MapRegionSketch.Stitch')
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
  - [ParquetClassLibrary#IModelEdit#ID](#P-ParquetClassLibrary-Model-ParquetClassLibrary#IModelEdit#ID 'ParquetClassLibrary.Model.ParquetClassLibrary#IModelEdit#ID')
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
  - [EditableModels](#P-ParquetClassLibrary-ModelCollection`1-EditableModels 'ParquetClassLibrary.ModelCollection`1.EditableModels')
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
  - [ParquetClassLibrary#IModelCollectionEdit{TModel}#Add(inModel)](#M-ParquetClassLibrary-ModelCollection`1-ParquetClassLibrary#IModelCollectionEdit{TModel}#Add-`0- 'ParquetClassLibrary.ModelCollection`1.ParquetClassLibrary#IModelCollectionEdit{TModel}#Add(`0)')
  - [ParquetClassLibrary#IModelCollectionEdit{TModel}#Clear()](#M-ParquetClassLibrary-ModelCollection`1-ParquetClassLibrary#IModelCollectionEdit{TModel}#Clear 'ParquetClassLibrary.ModelCollection`1.ParquetClassLibrary#IModelCollectionEdit{TModel}#Clear')
  - [ParquetClassLibrary#IModelCollectionEdit{TModel}#Remove(inModel)](#M-ParquetClassLibrary-ModelCollection`1-ParquetClassLibrary#IModelCollectionEdit{TModel}#Remove-`0- 'ParquetClassLibrary.ModelCollection`1.ParquetClassLibrary#IModelCollectionEdit{TModel}#Remove(`0)')
  - [ParquetClassLibrary#IModelCollectionEdit{TModel}#Remove(inID)](#M-ParquetClassLibrary-ModelCollection`1-ParquetClassLibrary#IModelCollectionEdit{TModel}#Remove-ParquetClassLibrary-ModelID- 'ParquetClassLibrary.ModelCollection`1.ParquetClassLibrary#IModelCollectionEdit{TModel}#Remove(ParquetClassLibrary.ModelID)')
  - [ParquetClassLibrary#IModelCollectionEdit{TModel}#Replace(inModel)](#M-ParquetClassLibrary-ModelCollection`1-ParquetClassLibrary#IModelCollectionEdit{TModel}#Replace-`0- 'ParquetClassLibrary.ModelCollection`1.ParquetClassLibrary#IModelCollectionEdit{TModel}#Replace(`0)')
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
- [ModelIDExtensions](#T-ParquetClassLibrary-ModelIDExtensions 'ParquetClassLibrary.ModelIDExtensions')
  - [IsValidPosition(inIDArray,inPosition)](#M-ParquetClassLibrary-ModelIDExtensions-IsValidPosition-ParquetClassLibrary-ModelID[0-,0-],ParquetClassLibrary-Vector2D- 'ParquetClassLibrary.ModelIDExtensions.IsValidPosition(ParquetClassLibrary.ModelID[0:,0:],ParquetClassLibrary.Vector2D)')
- [ModelIDGrid](#T-ParquetClassLibrary-ModelIDGrid 'ParquetClassLibrary.ModelIDGrid')
  - [#ctor()](#M-ParquetClassLibrary-ModelIDGrid-#ctor 'ParquetClassLibrary.ModelIDGrid.#ctor')
  - [#ctor(inRowCount,inColumnCount)](#M-ParquetClassLibrary-ModelIDGrid-#ctor-System-Int32,System-Int32- 'ParquetClassLibrary.ModelIDGrid.#ctor(System.Int32,System.Int32)')
  - [Columns](#P-ParquetClassLibrary-ModelIDGrid-Columns 'ParquetClassLibrary.ModelIDGrid.Columns')
  - [Count](#P-ParquetClassLibrary-ModelIDGrid-Count 'ParquetClassLibrary.ModelIDGrid.Count')
  - [Empty](#P-ParquetClassLibrary-ModelIDGrid-Empty 'ParquetClassLibrary.ModelIDGrid.Empty')
  - [IDs](#P-ParquetClassLibrary-ModelIDGrid-IDs 'ParquetClassLibrary.ModelIDGrid.IDs')
  - [Item](#P-ParquetClassLibrary-ModelIDGrid-Item-System-Int32,System-Int32- 'ParquetClassLibrary.ModelIDGrid.Item(System.Int32,System.Int32)')
  - [Rows](#P-ParquetClassLibrary-ModelIDGrid-Rows 'ParquetClassLibrary.ModelIDGrid.Rows')
  - [GetEnumerator()](#M-ParquetClassLibrary-ModelIDGrid-GetEnumerator 'ParquetClassLibrary.ModelIDGrid.GetEnumerator')
  - [IsValidPosition(inPosition)](#M-ParquetClassLibrary-ModelIDGrid-IsValidPosition-ParquetClassLibrary-Vector2D- 'ParquetClassLibrary.ModelIDGrid.IsValidPosition(ParquetClassLibrary.Vector2D)')
  - [System#Collections#Generic#IEnumerable{ParquetClassLibrary#ModelID}#GetEnumerator()](#M-ParquetClassLibrary-ModelIDGrid-System#Collections#Generic#IEnumerable{ParquetClassLibrary#ModelID}#GetEnumerator 'ParquetClassLibrary.ModelIDGrid.System#Collections#Generic#IEnumerable{ParquetClassLibrary#ModelID}#GetEnumerator')
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
  - [#ctor(inBounds,inID,inName,inDescription,inComment,inItemID,inAddsToBiome,inAddsToRoom)](#M-ParquetClassLibrary-Parquets-ParquetModel-#ctor-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Nullable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag}- 'ParquetClassLibrary.Parquets.ParquetModel.#ctor(ParquetClassLibrary.Range{ParquetClassLibrary.ModelID},ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.Nullable{ParquetClassLibrary.ModelID},System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag},System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag})')
  - [AddsToBiome](#P-ParquetClassLibrary-Parquets-ParquetModel-AddsToBiome 'ParquetClassLibrary.Parquets.ParquetModel.AddsToBiome')
  - [AddsToRoom](#P-ParquetClassLibrary-Parquets-ParquetModel-AddsToRoom 'ParquetClassLibrary.Parquets.ParquetModel.AddsToRoom')
  - [ItemID](#P-ParquetClassLibrary-Parquets-ParquetModel-ItemID 'ParquetClassLibrary.Parquets.ParquetModel.ItemID')
  - [ParquetClassLibrary#Parquets#IParquetModelEdit#AddsToBiome](#P-ParquetClassLibrary-Parquets-ParquetModel-ParquetClassLibrary#Parquets#IParquetModelEdit#AddsToBiome 'ParquetClassLibrary.Parquets.ParquetModel.ParquetClassLibrary#Parquets#IParquetModelEdit#AddsToBiome')
  - [ParquetClassLibrary#Parquets#IParquetModelEdit#AddsToRoom](#P-ParquetClassLibrary-Parquets-ParquetModel-ParquetClassLibrary#Parquets#IParquetModelEdit#AddsToRoom 'ParquetClassLibrary.Parquets.ParquetModel.ParquetClassLibrary#Parquets#IParquetModelEdit#AddsToRoom')
  - [ParquetClassLibrary#Parquets#IParquetModelEdit#ItemID](#P-ParquetClassLibrary-Parquets-ParquetModel-ParquetClassLibrary#Parquets#IParquetModelEdit#ItemID 'ParquetClassLibrary.Parquets.ParquetModel.ParquetClassLibrary#Parquets#IParquetModelEdit#ItemID')
  - [GetAllTags()](#M-ParquetClassLibrary-Parquets-ParquetModel-GetAllTags 'ParquetClassLibrary.Parquets.ParquetModel.GetAllTags')
- [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack')
  - [#ctor()](#M-ParquetClassLibrary-Parquets-ParquetStack-#ctor 'ParquetClassLibrary.Parquets.ParquetStack.#ctor')
  - [#ctor(inFloor,inBlock,inFurnishing,inCollectible)](#M-ParquetClassLibrary-Parquets-ParquetStack-#ctor-ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID,ParquetClassLibrary-ModelID- 'ParquetClassLibrary.Parquets.ParquetStack.#ctor(ParquetClassLibrary.ModelID,ParquetClassLibrary.ModelID,ParquetClassLibrary.ModelID,ParquetClassLibrary.ModelID)')
  - [BlockID](#P-ParquetClassLibrary-Parquets-ParquetStack-BlockID 'ParquetClassLibrary.Parquets.ParquetStack.BlockID')
  - [CollectibleID](#P-ParquetClassLibrary-Parquets-ParquetStack-CollectibleID 'ParquetClassLibrary.Parquets.ParquetStack.CollectibleID')
  - [ConverterFactory](#P-ParquetClassLibrary-Parquets-ParquetStack-ConverterFactory 'ParquetClassLibrary.Parquets.ParquetStack.ConverterFactory')
  - [Count](#P-ParquetClassLibrary-Parquets-ParquetStack-Count 'ParquetClassLibrary.Parquets.ParquetStack.Count')
  - [Empty](#P-ParquetClassLibrary-Parquets-ParquetStack-Empty 'ParquetClassLibrary.Parquets.ParquetStack.Empty')
  - [FloorID](#P-ParquetClassLibrary-Parquets-ParquetStack-FloorID 'ParquetClassLibrary.Parquets.ParquetStack.FloorID')
  - [FurnishingID](#P-ParquetClassLibrary-Parquets-ParquetStack-FurnishingID 'ParquetClassLibrary.Parquets.ParquetStack.FurnishingID')
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
  - [Empty](#P-ParquetClassLibrary-Parquets-ParquetStackGrid-Empty 'ParquetClassLibrary.Parquets.ParquetStackGrid.Empty')
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
  - [Empty](#P-ParquetClassLibrary-Parquets-ParquetStatusGrid-Empty 'ParquetClassLibrary.Parquets.ParquetStatusGrid.Empty')
  - [Item](#P-ParquetClassLibrary-Parquets-ParquetStatusGrid-Item-System-Int32,System-Int32- 'ParquetClassLibrary.Parquets.ParquetStatusGrid.Item(System.Int32,System.Int32)')
  - [ParquetStatuses](#P-ParquetClassLibrary-Parquets-ParquetStatusGrid-ParquetStatuses 'ParquetClassLibrary.Parquets.ParquetStatusGrid.ParquetStatuses')
  - [Rows](#P-ParquetClassLibrary-Parquets-ParquetStatusGrid-Rows 'ParquetClassLibrary.Parquets.ParquetStatusGrid.Rows')
  - [GetEnumerator()](#M-ParquetClassLibrary-Parquets-ParquetStatusGrid-GetEnumerator 'ParquetClassLibrary.Parquets.ParquetStatusGrid.GetEnumerator')
  - [IsValidPosition(inPosition)](#M-ParquetClassLibrary-Parquets-ParquetStatusGrid-IsValidPosition-ParquetClassLibrary-Vector2D- 'ParquetClassLibrary.Parquets.ParquetStatusGrid.IsValidPosition(ParquetClassLibrary.Vector2D)')
  - [System#Collections#Generic#IEnumerable{ParquetClassLibrary#Parquets#ParquetStatus}#GetEnumerator()](#M-ParquetClassLibrary-Parquets-ParquetStatusGrid-System#Collections#Generic#IEnumerable{ParquetClassLibrary#Parquets#ParquetStatus}#GetEnumerator 'ParquetClassLibrary.Parquets.ParquetStatusGrid.System#Collections#Generic#IEnumerable{ParquetClassLibrary#Parquets#ParquetStatus}#GetEnumerator')
- [Precondition](#T-ParquetClassLibrary-Precondition 'ParquetClassLibrary.Precondition')
  - [DefaultArgumentName](#F-ParquetClassLibrary-Precondition-DefaultArgumentName 'ParquetClassLibrary.Precondition.DefaultArgumentName')
  - [AreInRange(inEnumerable,inBounds,inArgumentName)](#M-ParquetClassLibrary-Precondition-AreInRange-System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},System-String- 'ParquetClassLibrary.Precondition.AreInRange(System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID},ParquetClassLibrary.Range{ParquetClassLibrary.ModelID},System.String)')
  - [AreInRange(inEnumerable,inBoundsCollection,inArgumentName)](#M-ParquetClassLibrary-Precondition-AreInRange-System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Range{ParquetClassLibrary-ModelID}},System-String- 'ParquetClassLibrary.Precondition.AreInRange(System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}},System.String)')
  - [IsInRange(inInt,inBounds,inArgumentName)](#M-ParquetClassLibrary-Precondition-IsInRange-System-Int32,ParquetClassLibrary-Range{System-Int32},System-String- 'ParquetClassLibrary.Precondition.IsInRange(System.Int32,ParquetClassLibrary.Range{System.Int32},System.String)')
  - [IsInRange(inID,inBounds,inArgumentName)](#M-ParquetClassLibrary-Precondition-IsInRange-ParquetClassLibrary-ModelID,ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},System-String- 'ParquetClassLibrary.Precondition.IsInRange(ParquetClassLibrary.ModelID,ParquetClassLibrary.Range{ParquetClassLibrary.ModelID},System.String)')
  - [IsInRange(inInnerBounds,inOuterBounds,inArgumentName)](#M-ParquetClassLibrary-Precondition-IsInRange-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},System-String- 'ParquetClassLibrary.Precondition.IsInRange(ParquetClassLibrary.Range{ParquetClassLibrary.ModelID},ParquetClassLibrary.Range{ParquetClassLibrary.ModelID},System.String)')
  - [IsInRange(inID,inBoundsCollection,inArgumentName)](#M-ParquetClassLibrary-Precondition-IsInRange-ParquetClassLibrary-ModelID,System-Collections-Generic-IEnumerable{ParquetClassLibrary-Range{ParquetClassLibrary-ModelID}},System-String- 'ParquetClassLibrary.Precondition.IsInRange(ParquetClassLibrary.ModelID,System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}},System.String)')
  - [IsInRange(inInnerBounds,inBoundsCollection,inArgumentName)](#M-ParquetClassLibrary-Precondition-IsInRange-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Range{ParquetClassLibrary-ModelID}},System-String- 'ParquetClassLibrary.Precondition.IsInRange(ParquetClassLibrary.Range{ParquetClassLibrary.ModelID},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Range{ParquetClassLibrary.ModelID}},System.String)')
  - [IsNotNone(inID,inArgumentName)](#M-ParquetClassLibrary-Precondition-IsNotNone-ParquetClassLibrary-ModelID,System-String- 'ParquetClassLibrary.Precondition.IsNotNone(ParquetClassLibrary.ModelID,System.String)')
  - [IsNotNull(inReference,inArgumentName)](#M-ParquetClassLibrary-Precondition-IsNotNull-System-Object,System-String- 'ParquetClassLibrary.Precondition.IsNotNull(System.Object,System.String)')
  - [IsNotNullOrEmpty(inString,inArgumentName)](#M-ParquetClassLibrary-Precondition-IsNotNullOrEmpty-System-String,System-String- 'ParquetClassLibrary.Precondition.IsNotNullOrEmpty(System.String,System.String)')
  - [IsNotNullOrEmpty\`\`1(inEnumerable,inArgumentName)](#M-ParquetClassLibrary-Precondition-IsNotNullOrEmpty``1-System-Collections-Generic-IEnumerable{``0},System-String- 'ParquetClassLibrary.Precondition.IsNotNullOrEmpty``1(System.Collections.Generic.IEnumerable{``0},System.String)')
  - [IsOfType\`\`2(inArgumentName)](#M-ParquetClassLibrary-Precondition-IsOfType``2-System-String- 'ParquetClassLibrary.Precondition.IsOfType``2(System.String)')
  - [MustBeNonNegative(inNumber,inArgumentName)](#M-ParquetClassLibrary-Precondition-MustBeNonNegative-System-Int32,System-String- 'ParquetClassLibrary.Precondition.MustBeNonNegative(System.Int32,System.String)')
  - [MustBePositive(inNumber,inArgumentName)](#M-ParquetClassLibrary-Precondition-MustBePositive-System-Int32,System-String- 'ParquetClassLibrary.Precondition.MustBePositive(System.Int32,System.String)')
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
  - [None](#F-ParquetClassLibrary-Range`1-None 'ParquetClassLibrary.Range`1.None')
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
- [Resources](#T-ParquetClassLibrary-Properties-Resources 'ParquetClassLibrary.Properties.Resources')
  - [Culture](#P-ParquetClassLibrary-Properties-Resources-Culture 'ParquetClassLibrary.Properties.Resources.Culture')
  - [DirectionAbove](#P-ParquetClassLibrary-Properties-Resources-DirectionAbove 'ParquetClassLibrary.Properties.Resources.DirectionAbove')
  - [DirectionBelow](#P-ParquetClassLibrary-Properties-Resources-DirectionBelow 'ParquetClassLibrary.Properties.Resources.DirectionBelow')
  - [DirectionEast](#P-ParquetClassLibrary-Properties-Resources-DirectionEast 'ParquetClassLibrary.Properties.Resources.DirectionEast')
  - [DirectionNorth](#P-ParquetClassLibrary-Properties-Resources-DirectionNorth 'ParquetClassLibrary.Properties.Resources.DirectionNorth')
  - [DirectionSouth](#P-ParquetClassLibrary-Properties-Resources-DirectionSouth 'ParquetClassLibrary.Properties.Resources.DirectionSouth')
  - [DirectionWest](#P-ParquetClassLibrary-Properties-Resources-DirectionWest 'ParquetClassLibrary.Properties.Resources.DirectionWest')
  - [ErrorCannotAdd](#P-ParquetClassLibrary-Properties-Resources-ErrorCannotAdd 'ParquetClassLibrary.Properties.Resources.ErrorCannotAdd')
  - [ErrorCannotConvert](#P-ParquetClassLibrary-Properties-Resources-ErrorCannotConvert 'ParquetClassLibrary.Properties.Resources.ErrorCannotConvert')
  - [ErrorCannotParse](#P-ParquetClassLibrary-Properties-Resources-ErrorCannotParse 'ParquetClassLibrary.Properties.Resources.ErrorCannotParse')
  - [ErrorCannotRemove](#P-ParquetClassLibrary-Properties-Resources-ErrorCannotRemove 'ParquetClassLibrary.Properties.Resources.ErrorCannotRemove')
  - [ErrorCannotReplace](#P-ParquetClassLibrary-Properties-Resources-ErrorCannotReplace 'ParquetClassLibrary.Properties.Resources.ErrorCannotReplace')
  - [ErrorClearAllFirst](#P-ParquetClassLibrary-Properties-Resources-ErrorClearAllFirst 'ParquetClassLibrary.Properties.Resources.ErrorClearAllFirst')
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
  - [ErrorOutOfOrderGTE](#P-ParquetClassLibrary-Properties-Resources-ErrorOutOfOrderGTE 'ParquetClassLibrary.Properties.Resources.ErrorOutOfOrderGTE')
  - [ErrorOutOfOrderLTE](#P-ParquetClassLibrary-Properties-Resources-ErrorOutOfOrderLTE 'ParquetClassLibrary.Properties.Resources.ErrorOutOfOrderLTE')
  - [ErrorUndefinedDirection](#P-ParquetClassLibrary-Properties-Resources-ErrorUndefinedDirection 'ParquetClassLibrary.Properties.Resources.ErrorUndefinedDirection')
  - [ErrorUngenerated](#P-ParquetClassLibrary-Properties-Resources-ErrorUngenerated 'ParquetClassLibrary.Properties.Resources.ErrorUngenerated')
  - [ErrorUnsupportedDimension](#P-ParquetClassLibrary-Properties-Resources-ErrorUnsupportedDimension 'ParquetClassLibrary.Properties.Resources.ErrorUnsupportedDimension')
  - [ErrorUnsupportedDuplicate](#P-ParquetClassLibrary-Properties-Resources-ErrorUnsupportedDuplicate 'ParquetClassLibrary.Properties.Resources.ErrorUnsupportedDuplicate')
  - [ErrorUnsupportedNode](#P-ParquetClassLibrary-Properties-Resources-ErrorUnsupportedNode 'ParquetClassLibrary.Properties.Resources.ErrorUnsupportedNode')
  - [ErrorUnsupportedSerialization](#P-ParquetClassLibrary-Properties-Resources-ErrorUnsupportedSerialization 'ParquetClassLibrary.Properties.Resources.ErrorUnsupportedSerialization')
  - [ResourceManager](#P-ParquetClassLibrary-Properties-Resources-ResourceManager 'ParquetClassLibrary.Properties.Resources.ResourceManager')
  - [WarningTriedToGiveNothing](#P-ParquetClassLibrary-Properties-Resources-WarningTriedToGiveNothing 'ParquetClassLibrary.Properties.Resources.WarningTriedToGiveNothing')
  - [WarningTriedToStoreNothing](#P-ParquetClassLibrary-Properties-Resources-WarningTriedToStoreNothing 'ParquetClassLibrary.Properties.Resources.WarningTriedToStoreNothing')
- [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room')
  - [#ctor(inWalkableArea,inPerimeter)](#M-ParquetClassLibrary-Rooms-Room-#ctor-ParquetClassLibrary-Rooms-MapSpaceCollection,ParquetClassLibrary-Rooms-MapSpaceCollection- 'ParquetClassLibrary.Rooms.Room.#ctor(ParquetClassLibrary.Rooms.MapSpaceCollection,ParquetClassLibrary.Rooms.MapSpaceCollection)')
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
- [RoomConfiguration](#T-ParquetClassLibrary-Rooms-RoomConfiguration 'ParquetClassLibrary.Rooms.RoomConfiguration')
  - [MaxWalkableSpaces](#P-ParquetClassLibrary-Rooms-RoomConfiguration-MaxWalkableSpaces 'ParquetClassLibrary.Rooms.RoomConfiguration.MaxWalkableSpaces')
  - [MinPerimeterSpaces](#P-ParquetClassLibrary-Rooms-RoomConfiguration-MinPerimeterSpaces 'ParquetClassLibrary.Rooms.RoomConfiguration.MinPerimeterSpaces')
  - [MinWalkableSpaces](#P-ParquetClassLibrary-Rooms-RoomConfiguration-MinWalkableSpaces 'ParquetClassLibrary.Rooms.RoomConfiguration.MinWalkableSpaces')
  - [GetFilePath()](#M-ParquetClassLibrary-Rooms-RoomConfiguration-GetFilePath 'ParquetClassLibrary.Rooms.RoomConfiguration.GetFilePath')
  - [GetRecord()](#M-ParquetClassLibrary-Rooms-RoomConfiguration-GetRecord 'ParquetClassLibrary.Rooms.RoomConfiguration.GetRecord')
  - [PutRecord()](#M-ParquetClassLibrary-Rooms-RoomConfiguration-PutRecord 'ParquetClassLibrary.Rooms.RoomConfiguration.PutRecord')
- [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe')
  - [#ctor(inID,inName,inDescription,inComment,inMinimumWalkableSpaces,inOptionallyRequiredFurnishings,inOptionallyRequiredWalkableFloors,inOptionallyRequiredPerimeterBlocks)](#M-ParquetClassLibrary-Rooms-RoomRecipe-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Nullable{System-Int32},System-Collections-Generic-IEnumerable{ParquetClassLibrary-RecipeElement},System-Collections-Generic-IEnumerable{ParquetClassLibrary-RecipeElement},System-Collections-Generic-IEnumerable{ParquetClassLibrary-RecipeElement}- 'ParquetClassLibrary.Rooms.RoomRecipe.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.Nullable{System.Int32},System.Collections.Generic.IEnumerable{ParquetClassLibrary.RecipeElement},System.Collections.Generic.IEnumerable{ParquetClassLibrary.RecipeElement},System.Collections.Generic.IEnumerable{ParquetClassLibrary.RecipeElement})')
  - [MinimumWalkableSpaces](#P-ParquetClassLibrary-Rooms-RoomRecipe-MinimumWalkableSpaces 'ParquetClassLibrary.Rooms.RoomRecipe.MinimumWalkableSpaces')
  - [OptionallyRequiredFurnishings](#P-ParquetClassLibrary-Rooms-RoomRecipe-OptionallyRequiredFurnishings 'ParquetClassLibrary.Rooms.RoomRecipe.OptionallyRequiredFurnishings')
  - [OptionallyRequiredPerimeterBlocks](#P-ParquetClassLibrary-Rooms-RoomRecipe-OptionallyRequiredPerimeterBlocks 'ParquetClassLibrary.Rooms.RoomRecipe.OptionallyRequiredPerimeterBlocks')
  - [OptionallyRequiredWalkableFloors](#P-ParquetClassLibrary-Rooms-RoomRecipe-OptionallyRequiredWalkableFloors 'ParquetClassLibrary.Rooms.RoomRecipe.OptionallyRequiredWalkableFloors')
  - [ParquetClassLibrary#Rooms#IRoomRecipeEdit#MinimumWalkableSpaces](#P-ParquetClassLibrary-Rooms-RoomRecipe-ParquetClassLibrary#Rooms#IRoomRecipeEdit#MinimumWalkableSpaces 'ParquetClassLibrary.Rooms.RoomRecipe.ParquetClassLibrary#Rooms#IRoomRecipeEdit#MinimumWalkableSpaces')
  - [ParquetClassLibrary#Rooms#IRoomRecipeEdit#OptionallyRequiredFurnishings](#P-ParquetClassLibrary-Rooms-RoomRecipe-ParquetClassLibrary#Rooms#IRoomRecipeEdit#OptionallyRequiredFurnishings 'ParquetClassLibrary.Rooms.RoomRecipe.ParquetClassLibrary#Rooms#IRoomRecipeEdit#OptionallyRequiredFurnishings')
  - [ParquetClassLibrary#Rooms#IRoomRecipeEdit#OptionallyRequiredPerimeterBlocks](#P-ParquetClassLibrary-Rooms-RoomRecipe-ParquetClassLibrary#Rooms#IRoomRecipeEdit#OptionallyRequiredPerimeterBlocks 'ParquetClassLibrary.Rooms.RoomRecipe.ParquetClassLibrary#Rooms#IRoomRecipeEdit#OptionallyRequiredPerimeterBlocks')
  - [ParquetClassLibrary#Rooms#IRoomRecipeEdit#OptionallyRequiredWalkableFloors](#P-ParquetClassLibrary-Rooms-RoomRecipe-ParquetClassLibrary#Rooms#IRoomRecipeEdit#OptionallyRequiredWalkableFloors 'ParquetClassLibrary.Rooms.RoomRecipe.ParquetClassLibrary#Rooms#IRoomRecipeEdit#OptionallyRequiredWalkableFloors')
  - [Priority](#P-ParquetClassLibrary-Rooms-RoomRecipe-Priority 'ParquetClassLibrary.Rooms.RoomRecipe.Priority')
  - [Matches(inRoom)](#M-ParquetClassLibrary-Rooms-RoomRecipe-Matches-ParquetClassLibrary-Rooms-Room- 'ParquetClassLibrary.Rooms.RoomRecipe.Matches(ParquetClassLibrary.Rooms.Room)')
- [RunState](#T-ParquetClassLibrary-Scripts-RunState 'ParquetClassLibrary.Scripts.RunState')
  - [Completed](#F-ParquetClassLibrary-Scripts-RunState-Completed 'ParquetClassLibrary.Scripts.RunState.Completed')
  - [InProgress](#F-ParquetClassLibrary-Scripts-RunState-InProgress 'ParquetClassLibrary.Scripts.RunState.InProgress')
  - [Unstarted](#F-ParquetClassLibrary-Scripts-RunState-Unstarted 'ParquetClassLibrary.Scripts.RunState.Unstarted')
- [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel')
  - [#ctor(inID,inName,inDescription,inComment,inNodes)](#M-ParquetClassLibrary-Scripts-ScriptModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Collections-Generic-IEnumerable{ParquetClassLibrary-Scripts-ScriptNode}- 'ParquetClassLibrary.Scripts.ScriptModel.#ctor(ParquetClassLibrary.ModelID,System.String,System.String,System.String,System.Collections.Generic.IEnumerable{ParquetClassLibrary.Scripts.ScriptNode})')
  - [Nodes](#P-ParquetClassLibrary-Scripts-ScriptModel-Nodes 'ParquetClassLibrary.Scripts.ScriptModel.Nodes')
  - [ParquetClassLibrary#Scripts#IScriptModelEdit#Nodes](#P-ParquetClassLibrary-Scripts-ScriptModel-ParquetClassLibrary#Scripts#IScriptModelEdit#Nodes 'ParquetClassLibrary.Scripts.ScriptModel.ParquetClassLibrary#Scripts#IScriptModelEdit#Nodes')
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
  - [PanelsPerPatternHeight](#F-ParquetClassLibrary-Crafts-StrikePanelGrid-PanelsPerPatternHeight 'ParquetClassLibrary.Crafts.StrikePanelGrid.PanelsPerPatternHeight')
  - [PanelsPerPatternWidth](#F-ParquetClassLibrary-Crafts-StrikePanelGrid-PanelsPerPatternWidth 'ParquetClassLibrary.Crafts.StrikePanelGrid.PanelsPerPatternWidth')
  - [Columns](#P-ParquetClassLibrary-Crafts-StrikePanelGrid-Columns 'ParquetClassLibrary.Crafts.StrikePanelGrid.Columns')
  - [Count](#P-ParquetClassLibrary-Crafts-StrikePanelGrid-Count 'ParquetClassLibrary.Crafts.StrikePanelGrid.Count')
  - [Empty](#P-ParquetClassLibrary-Crafts-StrikePanelGrid-Empty 'ParquetClassLibrary.Crafts.StrikePanelGrid.Empty')
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

<a name='F-ParquetClassLibrary-All-AllDefinedIDs'></a>
### AllDefinedIDs `constants`

##### Summary

A collection containing all defined [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1')s.

<a name='F-ParquetClassLibrary-All-BeingIDs'></a>
### BeingIDs `constants`

##### Summary

A collection containing all defined [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1')s of [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel')s.

<a name='F-ParquetClassLibrary-All-BiomeIDs'></a>
### BiomeIDs `constants`

##### Summary

A subset of the values of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') set aside for [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe')s.
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

<a name='F-ParquetClassLibrary-All-GameIDs'></a>
### GameIDs `constants`

##### Summary

A subset of the values of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') set aside for identifying [GameModel](#T-ParquetClassLibrary-Games-GameModel 'ParquetClassLibrary.Games.GameModel')s.
Valid identifiers may be positive or negative.  By convention, negative IDs indicate test characters.

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

A subset of the values of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') set aside for [MapChunkModel](#T-ParquetClassLibrary-Maps-MapChunkModel 'ParquetClassLibrary.Maps.MapChunkModel')s.
Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Items.

<a name='F-ParquetClassLibrary-All-MapIDs'></a>
### MapIDs `constants`

##### Summary

A subset of the values of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') set aside for [MapModel](#T-ParquetClassLibrary-Maps-MapModel 'ParquetClassLibrary.Maps.MapModel')s.
Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Items.

<a name='F-ParquetClassLibrary-All-MapRegionIDs'></a>
### MapRegionIDs `constants`

##### Summary

A subset of the values of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') set aside for [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel')s.
Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Items.

<a name='F-ParquetClassLibrary-All-ParquetIDs'></a>
### ParquetIDs `constants`

##### Summary

A collection containing all defined [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1')s of parquets.

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

A collection of all defined [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe')s.
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

<a name='P-ParquetClassLibrary-All-Games'></a>
### Games `property`

##### Summary

A collection of all defined [GameModel](#T-ParquetClassLibrary-Games-GameModel 'ParquetClassLibrary.Games.GameModel')s.
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

<a name='P-ParquetClassLibrary-All-ProjectDirectory'></a>
### ProjectDirectory `property`

##### Summary

The location of the game data files.  Defaults to the current application's working directory.

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

<a name='M-ParquetClassLibrary-All-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes the [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1')s and [ModelCollection\`1](#T-ParquetClassLibrary-ModelCollection`1 'ParquetClassLibrary.ModelCollection`1')s defined in [All](#T-ParquetClassLibrary-All 'ParquetClassLibrary.All').

##### Parameters

This method has no parameters.

##### Remarks

This supports defining ItemIDs in terms of the other Ranges.

<a name='M-ParquetClassLibrary-All-Clear'></a>
### Clear() `method`

##### Summary

Clears all the [ModelCollection\`1](#T-ParquetClassLibrary-ModelCollection`1 'ParquetClassLibrary.ModelCollection`1')s contained in [All](#T-ParquetClassLibrary-All 'ParquetClassLibrary.All').

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | When called more than once. |

##### Remarks

This method must be called between calls to the initialization routines.

##### See Also

- [ParquetClassLibrary.All.InitializeCollections](#M-ParquetClassLibrary-All-InitializeCollections-System-Collections-Generic-IEnumerable{ParquetClassLibrary-Beings-PronounGroup},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Beings-BeingModel},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Biomes-BiomeRecipe},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Crafts-CraftingRecipe},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Games-GameModel},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Scripts-InteractionModel},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Maps-MapModel},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Parquets-ParquetModel},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Rooms-RoomRecipe},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Scripts-ScriptModel},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Items-ItemModel}- 'ParquetClassLibrary.All.InitializeCollections(System.Collections.Generic.IEnumerable{ParquetClassLibrary.Beings.PronounGroup},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Beings.BeingModel},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Biomes.BiomeRecipe},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Crafts.CraftingRecipe},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Games.GameModel},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Scripts.InteractionModel},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Maps.MapModel},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Parquets.ParquetModel},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Rooms.RoomRecipe},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Scripts.ScriptModel},System.Collections.Generic.IEnumerable{ParquetClassLibrary.Items.ItemModel})')

<a name='M-ParquetClassLibrary-All-GetIDRangeForType-ParquetClassLibrary-ModelID-'></a>
### GetIDRangeForType(inID) `method`

##### Summary

Given a [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID'), return the [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1') within which it is defined.

##### Returns

The range within which this [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') is defined, or [None](#F-ParquetClassLibrary-Range`1-None 'ParquetClassLibrary.Range`1.None') if there is none.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The ID whose [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1') is sought. |

<a name='M-ParquetClassLibrary-All-GetIDRangeForType-ParquetClassLibrary-Model-'></a>
### GetIDRangeForType(inModel) `method`

##### Summary

Given an instance of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model'), return the appropriate [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1').

##### Returns

The range within which this model's [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') is defined, or [None](#F-ParquetClassLibrary-Range`1-None 'ParquetClassLibrary.Range`1.None') if there is none.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inModel | [ParquetClassLibrary.Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') | The model whose [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1') is sought. |

<a name='M-ParquetClassLibrary-All-GetIDRangeForType-System-Type-'></a>
### GetIDRangeForType(inModelType) `method`

##### Summary

Given a [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') derived from a [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model'), return the appropriate [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1').

##### Returns

The range within which this model type's [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') would be define,
dor [None](#F-ParquetClassLibrary-Range`1-None 'ParquetClassLibrary.Range`1.None') if there is none exists.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inModelType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The model type whose ID range is sought. |

<a name='M-ParquetClassLibrary-All-InitializeCollections-System-Collections-Generic-IEnumerable{ParquetClassLibrary-Beings-PronounGroup},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Beings-BeingModel},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Biomes-BiomeRecipe},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Crafts-CraftingRecipe},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Games-GameModel},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Scripts-InteractionModel},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Maps-MapModel},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Parquets-ParquetModel},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Rooms-RoomRecipe},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Scripts-ScriptModel},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Items-ItemModel}-'></a>
### InitializeCollections(inPronouns,inBeings,inBiomes,inCraftingRecipes,inGames,inInteractions,inMaps,inParquets,inRoomRecipes,inScripts,inItems) `method`

##### Summary

Initializes the [ModelCollection\`1](#T-ParquetClassLibrary-ModelCollection`1 'ParquetClassLibrary.ModelCollection`1')s from the given collections.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inPronouns | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Beings.PronounGroup}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Beings.PronounGroup}') | The pronouns that the game knows by default. |
| inBeings | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Beings.BeingModel}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Beings.BeingModel}') | All beings to be used in the game. |
| inBiomes | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Biomes.BiomeRecipe}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Biomes.BiomeRecipe}') | All biomes to be used in the game. |
| inCraftingRecipes | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Crafts.CraftingRecipe}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Crafts.CraftingRecipe}') | All crafting recipes to be used in the game. |
| inGames | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.Games.GameModel}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.Games.GameModel}') | All games or episodes to be used in the game. |
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

The collections of models must be separately cleared between calls to this initialization routine.

##### See Also

- [ParquetClassLibrary.All.Clear](#M-ParquetClassLibrary-All-Clear 'ParquetClassLibrary.All.Clear')

<a name='M-ParquetClassLibrary-All-LoadFromCSVs'></a>
### LoadFromCSVs() `method`

##### Summary

Initializes [All](#T-ParquetClassLibrary-All 'ParquetClassLibrary.All') based on the values in design-time CSV files.

##### Returns

`true` if no exceptions were caught, `false` otherwise.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-All-SaveToCSVs'></a>
### SaveToCSVs() `method`

##### Summary

Stores the content of [All](#T-ParquetClassLibrary-All 'ParquetClassLibrary.All') to CSV files for later reinitialization.

##### Returns

`true` if no exceptions were caught, `false` otherwise.

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

<a name='T-ParquetClassLibrary-Beings-BeingModel'></a>
## BeingModel `type`

##### Namespace

ParquetClassLibrary.Beings

##### Summary

Models the basic definitions shared by any in-game actor.

<a name='M-ParquetClassLibrary-Beings-BeingModel-#ctor-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID}-'></a>
### #ctor(inBounds,inID,inName,inDescription,inComment,inNativeBiomeID,inPrimaryBehaviorID,inAvoidsIDs,inSeeksIDs) `constructor`

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
| inNativeBiomeID | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') for the [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe') in which this [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') is most comfortable. |
| inPrimaryBehaviorID | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | The rules that govern how this [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') acts.  Cannot be null. |
| inAvoidsIDs | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}') | Any parquets this [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') avoids. |
| inSeeksIDs | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}') | Any parquets this [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') seeks. |

<a name='P-ParquetClassLibrary-Beings-BeingModel-AvoidsIDs'></a>
### AvoidsIDs `property`

##### Summary

Types of parquets this [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') avoids, if any.

<a name='P-ParquetClassLibrary-Beings-BeingModel-NativeBiomeID'></a>
### NativeBiomeID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe') in which this character is at home.

<a name='P-ParquetClassLibrary-Beings-BeingModel-ParquetClassLibrary#Beings#IBeingModelEdit#AvoidsIDs'></a>
### ParquetClassLibrary#Beings#IBeingModelEdit#AvoidsIDs `property`

##### Summary

Types of parquets this [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') avoids, if any.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Beings-BeingModel-ParquetClassLibrary#Beings#IBeingModelEdit#NativeBiomeID'></a>
### ParquetClassLibrary#Beings#IBeingModelEdit#NativeBiomeID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe') in which this character is at home.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Beings-BeingModel-ParquetClassLibrary#Beings#IBeingModelEdit#PrimaryBehaviorID'></a>
### ParquetClassLibrary#Beings#IBeingModelEdit#PrimaryBehaviorID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel') governing the way this being acts.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Beings-BeingModel-ParquetClassLibrary#Beings#IBeingModelEdit#SeeksIDs'></a>
### ParquetClassLibrary#Beings#IBeingModelEdit#SeeksIDs `property`

##### Summary

Types of parquets this [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') seeks out, if any.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Beings-BeingModel-PrimaryBehaviorID'></a>
### PrimaryBehaviorID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel') governing the way this being acts.

<a name='P-ParquetClassLibrary-Beings-BeingModel-SeeksIDs'></a>
### SeeksIDs `property`

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
| inBiomeTimeRemaining | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | How long [TODO in what units?] to until being kicked out of the current [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe'). |
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

The time remaining that the tracked [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') can safely remain in the current [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe').

##### Remarks

It is likely that this will only be used by [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') but may be useful for other beings as well.

<a name='P-ParquetClassLibrary-Beings-BeingStatus-BuildingSpeed'></a>
### BuildingSpeed `property`

##### Summary

The time it takes the tracked [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') to place new parquets.

<a name='P-ParquetClassLibrary-Beings-BeingStatus-CurrentBehaviorID'></a>
### CurrentBehaviorID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') for the [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel') currently governing the tracked [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel').

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

<a name='T-ParquetClassLibrary-Biomes-BiomeConfiguration'></a>
## BiomeConfiguration `type`

##### Namespace

ParquetClassLibrary.Biomes

##### Summary

Provides rules for determining a [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel')'s [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe').

<a name='F-ParquetClassLibrary-Biomes-BiomeConfiguration-ParquetsPerLayer'></a>
### ParquetsPerLayer `constants`

##### Summary

Used in computing thresholds.

<a name='P-ParquetClassLibrary-Biomes-BiomeConfiguration-LandThreshold'></a>
### LandThreshold `property`

##### Summary

How many of a layers' worth of parquets must contribute to a land-based [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe').

<a name='P-ParquetClassLibrary-Biomes-BiomeConfiguration-LandThresholdFactor'></a>
### LandThresholdFactor `property`

##### Summary

There must be at least this percentage of non-liquid [ParquetModel](#T-ParquetClassLibrary-Parquets-ParquetModel 'ParquetClassLibrary.Parquets.ParquetModel')s in a given
[MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel') to generate the [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe') associated with them.

<a name='P-ParquetClassLibrary-Biomes-BiomeConfiguration-LiquidThreshold'></a>
### LiquidThreshold `property`

##### Summary

How many of a layers' worth of parquets must contribute to a Liquid-based [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe').

<a name='P-ParquetClassLibrary-Biomes-BiomeConfiguration-LiquidThresholdFactor'></a>
### LiquidThresholdFactor `property`

##### Summary

There must be at least this percentage of liquid [ParquetModel](#T-ParquetClassLibrary-Parquets-ParquetModel 'ParquetClassLibrary.Parquets.ParquetModel')s in a given
[MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel') to generate the [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe') associated with them.

<a name='P-ParquetClassLibrary-Biomes-BiomeConfiguration-RoomThreshold'></a>
### RoomThreshold `property`

##### Summary

How many of a layers' worth of parquets must contribute to a room-based [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe').

<a name='P-ParquetClassLibrary-Biomes-BiomeConfiguration-RoomThresholdFactor'></a>
### RoomThresholdFactor `property`

##### Summary

There must be at least this percentage of [ParquetModel](#T-ParquetClassLibrary-Parquets-ParquetModel 'ParquetClassLibrary.Parquets.ParquetModel')s included in rooms in a given
[MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel') to generate the [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe') associated with them.

<a name='M-ParquetClassLibrary-Biomes-BiomeConfiguration-GetFilePath'></a>
### GetFilePath() `method`

##### Summary

Returns the filename and path associated with [BiomeConfiguration](#T-ParquetClassLibrary-Biomes-BiomeConfiguration 'ParquetClassLibrary.Biomes.BiomeConfiguration')'s definition file.

##### Returns

A full path to the associated file.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Biomes-BiomeConfiguration-GetRecord'></a>
### GetRecord() `method`

##### Summary

Reads [BiomeConfiguration](#T-ParquetClassLibrary-Biomes-BiomeConfiguration 'ParquetClassLibrary.Biomes.BiomeConfiguration') data from the appropriate file.

##### Returns

The instances read.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Biomes-BiomeConfiguration-PutRecord'></a>
### PutRecord() `method`

##### Summary

Writes [BiomeConfiguration](#T-ParquetClassLibrary-Biomes-BiomeConfiguration 'ParquetClassLibrary.Biomes.BiomeConfiguration') data to the appropriate file.

##### Parameters

This method has no parameters.

<a name='T-ParquetClassLibrary-Biomes-BiomeRecipe'></a>
## BiomeRecipe `type`

##### Namespace

ParquetClassLibrary.Biomes

##### Summary

Models the biome that a [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel') embodies.

<a name='M-ParquetClassLibrary-Biomes-BiomeRecipe-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Int32,System-Boolean,System-Boolean,System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag}-'></a>
### #ctor(inID,inName,inDescription,inComment,inTier,inIsRoomBased,inIsLiquidBased,inParquetCriteria,inEntryRequirements) `constructor`

##### Summary

Initializes a new instance of the [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | Unique identifier for the [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe').  Cannot be null. |
| inName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly name of the [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe').  Cannot be null or empty. |
| inDescription | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly description of the [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe'). |
| inComment | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Comment of, on, or by the [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe'). |
| inTier | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | A rating indicating where in the progression this [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe') falls. |
| inIsRoomBased | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Determines whether or not this [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe') is defined in terms of [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room')s. |
| inIsLiquidBased | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Determines whether or not this [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe') is defined in terms of liquid parquets. |
| inParquetCriteria | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}') | Describes the parquets that make up this [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe'). |
| inEntryRequirements | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}') | Describes the [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel')s needed to access this [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe'). |

<a name='P-ParquetClassLibrary-Biomes-BiomeRecipe-EntryRequirements'></a>
### EntryRequirements `property`

##### Summary

Describes the [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel')s a [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') needs to safely access this biome.

<a name='P-ParquetClassLibrary-Biomes-BiomeRecipe-IsLiquidBased'></a>
### IsLiquidBased `property`

##### Summary

Determines whether or not this [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe') is defined in terms of liquid parquets.

<a name='P-ParquetClassLibrary-Biomes-BiomeRecipe-IsRoomBased'></a>
### IsRoomBased `property`

##### Summary

Determines whether or not this [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe') is defined in terms of [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room')s.

<a name='P-ParquetClassLibrary-Biomes-BiomeRecipe-None'></a>
### None `property`

##### Summary

Represents the lack of a [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe') for [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel')s that fail to qualify.

<a name='P-ParquetClassLibrary-Biomes-BiomeRecipe-ParquetClassLibrary#Biomes#IBiomeRecipeEdit#EntryRequirements'></a>
### ParquetClassLibrary#Biomes#IBiomeRecipeEdit#EntryRequirements `property`

##### Summary

Describes the [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel')s a [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') needs to safely access this biome.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require readwrite access.

<a name='P-ParquetClassLibrary-Biomes-BiomeRecipe-ParquetClassLibrary#Biomes#IBiomeRecipeEdit#IsLiquidBased'></a>
### ParquetClassLibrary#Biomes#IBiomeRecipeEdit#IsLiquidBased `property`

##### Summary

Determines whether or not this [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe') is defined in terms of liquid parquets.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require readwrite access.

<a name='P-ParquetClassLibrary-Biomes-BiomeRecipe-ParquetClassLibrary#Biomes#IBiomeRecipeEdit#IsRoomBased'></a>
### ParquetClassLibrary#Biomes#IBiomeRecipeEdit#IsRoomBased `property`

##### Summary

Determines whether or not this [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe') is defined in terms of [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room')s.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require readwrite access.

<a name='P-ParquetClassLibrary-Biomes-BiomeRecipe-ParquetClassLibrary#Biomes#IBiomeRecipeEdit#ParquetCriteria'></a>
### ParquetClassLibrary#Biomes#IBiomeRecipeEdit#ParquetCriteria `property`

##### Summary

Describes the parquets that make up this [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe').

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require readwrite access.

<a name='P-ParquetClassLibrary-Biomes-BiomeRecipe-ParquetClassLibrary#Biomes#IBiomeRecipeEdit#Tier'></a>
### ParquetClassLibrary#Biomes#IBiomeRecipeEdit#Tier `property`

##### Summary

A rating indicating where in the progression this [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe') falls.
Must be non-negative.  Higher values indicate later Biomes.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require readwrite access.

<a name='P-ParquetClassLibrary-Biomes-BiomeRecipe-ParquetCriteria'></a>
### ParquetCriteria `property`

##### Summary

Describes the parquets that make up this [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe').

<a name='P-ParquetClassLibrary-Biomes-BiomeRecipe-Tier'></a>
### Tier `property`

##### Summary

A rating indicating where in the progression this [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe') falls.
Must be non-negative.  Higher values indicate later Biomes.

<a name='M-ParquetClassLibrary-Biomes-BiomeRecipe-GetAllTags'></a>
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

<a name='M-ParquetClassLibrary-Parquets-BlockModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Nullable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag},ParquetClassLibrary-Items-GatheringTool,ParquetClassLibrary-Parquets-GatheringEffect,System-Nullable{ParquetClassLibrary-ModelID},System-Boolean,System-Boolean,System-Int32-'></a>
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
| inAddsToBiome | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}') | A set of flags indicating which, if any, [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe') this parquet helps to generate. |
| inAddsToRoom | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}') | A set of flags indicating which, if any, [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe') this parquet helps to generate. |
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

<a name='P-ParquetClassLibrary-Parquets-BlockModel-ParquetClassLibrary#Parquets#IBlockModelEdit#CollectibleID'></a>
### ParquetClassLibrary#Parquets#IBlockModelEdit#CollectibleID `property`

##### Summary

The Collectible spawned when a character gathers this Block.

##### Remarks

By design, children of [BlockModel](#T-ParquetClassLibrary-Parquets-BlockModel 'ParquetClassLibrary.Parquets.BlockModel') should never themselves use [IBlockModelEdit](#T-ParquetClassLibrary-Parquets-IBlockModelEdit 'ParquetClassLibrary.Parquets.IBlockModelEdit').
IBlockModelEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Parquets-BlockModel-ParquetClassLibrary#Parquets#IBlockModelEdit#GatherEffect'></a>
### ParquetClassLibrary#Parquets#IBlockModelEdit#GatherEffect `property`

##### Summary

The effect generated when a character gathers this Block.

##### Remarks

By design, children of [BlockModel](#T-ParquetClassLibrary-Parquets-BlockModel 'ParquetClassLibrary.Parquets.BlockModel') should never themselves use [IBlockModelEdit](#T-ParquetClassLibrary-Parquets-IBlockModelEdit 'ParquetClassLibrary.Parquets.IBlockModelEdit').
IBlockModelEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Parquets-BlockModel-ParquetClassLibrary#Parquets#IBlockModelEdit#GatherTool'></a>
### ParquetClassLibrary#Parquets#IBlockModelEdit#GatherTool `property`

##### Summary

The tool used to remove the block.

##### Remarks

By design, children of [BlockModel](#T-ParquetClassLibrary-Parquets-BlockModel 'ParquetClassLibrary.Parquets.BlockModel') should never themselves use [IBlockModelEdit](#T-ParquetClassLibrary-Parquets-IBlockModelEdit 'ParquetClassLibrary.Parquets.IBlockModelEdit').
IBlockModelEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Parquets-BlockModel-ParquetClassLibrary#Parquets#IBlockModelEdit#IsFlammable'></a>
### ParquetClassLibrary#Parquets#IBlockModelEdit#IsFlammable `property`

##### Summary

Whether or not the block is flammable.

##### Remarks

By design, children of [BlockModel](#T-ParquetClassLibrary-Parquets-BlockModel 'ParquetClassLibrary.Parquets.BlockModel') should never themselves use [IBlockModelEdit](#T-ParquetClassLibrary-Parquets-IBlockModelEdit 'ParquetClassLibrary.Parquets.IBlockModelEdit').
IBlockModelEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Parquets-BlockModel-ParquetClassLibrary#Parquets#IBlockModelEdit#IsLiquid'></a>
### ParquetClassLibrary#Parquets#IBlockModelEdit#IsLiquid `property`

##### Summary

Whether or not the block is a liquid.

##### Remarks

By design, children of [BlockModel](#T-ParquetClassLibrary-Parquets-BlockModel 'ParquetClassLibrary.Parquets.BlockModel') should never themselves use [IBlockModelEdit](#T-ParquetClassLibrary-Parquets-IBlockModelEdit 'ParquetClassLibrary.Parquets.IBlockModelEdit').
IBlockModelEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Parquets-BlockModel-ParquetClassLibrary#Parquets#IBlockModelEdit#MaxToughness'></a>
### ParquetClassLibrary#Parquets#IBlockModelEdit#MaxToughness `property`

##### Summary

The block's native toughness.

##### Remarks

By design, children of [BlockModel](#T-ParquetClassLibrary-Parquets-BlockModel 'ParquetClassLibrary.Parquets.BlockModel') should never themselves use [IBlockModelEdit](#T-ParquetClassLibrary-Parquets-IBlockModelEdit 'ParquetClassLibrary.Parquets.IBlockModelEdit').
IBlockModelEdit is for external types that require read/write access.

<a name='T-ParquetClassLibrary-Beings-CharacterModel'></a>
## CharacterModel `type`

##### Namespace

ParquetClassLibrary.Beings

##### Summary

Models the definitions of in-game actors that take part in the narrative.

<a name='M-ParquetClassLibrary-Beings-CharacterModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-String,System-String,System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID}-'></a>
### #ctor(inID,inName,inDescription,inComment,inNativeBiomeID,inPrimaryBehaviorID,inAvoidsIDs,inSeeksIDs,inPronouns,inStoryCharacterID,inStartingQuestIDs,inStartingDialogueIDs,inStartingInventoryIDs) `constructor`

##### Summary

Initializes a new instance of the [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | Unique identifier for the [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel').  Cannot be null. |
| inName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Personal and family names of the [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel'), separated by a space.  Cannot be null or empty. |
| inDescription | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly description of the [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel'). |
| inComment | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Comment of, on, or by the [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel'). |
| inNativeBiomeID | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') for the [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe') in which this [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') is most comfortable. |
| inPrimaryBehaviorID | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | The rules that govern how this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') acts.  Cannot be null. |
| inAvoidsIDs | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}') | Any parquets this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') avoids. |
| inSeeksIDs | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}') | Any parquets this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') seeks. |
| inPronouns | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | How to refer to this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel'). |
| inStoryCharacterID | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A means of identifying this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') across multiple shipped game titles. |
| inStartingQuestIDs | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}') | Any quests this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') has to offer or has undertaken. |
| inStartingDialogueIDs | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}') | All dialogue this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') may say. |
| inStartingInventoryIDs | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}') | Any items this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') possesses at the outset. |

<a name='P-ParquetClassLibrary-Beings-CharacterModel-FamilyName'></a>
### FamilyName `property`

##### Summary

Player-facing family name.

<a name='P-ParquetClassLibrary-Beings-CharacterModel-ParquetClassLibrary#Beings#ICharacterModelEdit#FamilyName'></a>
### ParquetClassLibrary#Beings#ICharacterModelEdit#FamilyName `property`

##### Summary

Player-facing family name.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require readwrite access.

<a name='P-ParquetClassLibrary-Beings-CharacterModel-ParquetClassLibrary#Beings#ICharacterModelEdit#PersonalName'></a>
### ParquetClassLibrary#Beings#ICharacterModelEdit#PersonalName `property`

##### Summary

Player-facing personal name.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require readwrite access.

<a name='P-ParquetClassLibrary-Beings-CharacterModel-ParquetClassLibrary#Beings#ICharacterModelEdit#Pronouns'></a>
### ParquetClassLibrary#Beings#ICharacterModelEdit#Pronouns `property`

##### Summary

A key for the [PronounGroup](#T-ParquetClassLibrary-Beings-PronounGroup 'ParquetClassLibrary.Beings.PronounGroup') the [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') uses,
stored as "[Objective](#P-ParquetClassLibrary-Beings-PronounGroup-Objective 'ParquetClassLibrary.Beings.PronounGroup.Objective')/[Subjective](#P-ParquetClassLibrary-Beings-PronounGroup-Subjective 'ParquetClassLibrary.Beings.PronounGroup.Subjective').

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require readwrite access.

<a name='P-ParquetClassLibrary-Beings-CharacterModel-ParquetClassLibrary#Beings#ICharacterModelEdit#StartingDialogueIDs'></a>
### ParquetClassLibrary#Beings#ICharacterModelEdit#StartingDialogueIDs `property`

##### Summary

Dialogue lines this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') can say.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require readwrite access.

<a name='P-ParquetClassLibrary-Beings-CharacterModel-ParquetClassLibrary#Beings#ICharacterModelEdit#StartingInventoryIDs'></a>
### ParquetClassLibrary#Beings#ICharacterModelEdit#StartingInventoryIDs `property`

##### Summary

The set of belongings that this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') begins with.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require readwrite access.

<a name='P-ParquetClassLibrary-Beings-CharacterModel-ParquetClassLibrary#Beings#ICharacterModelEdit#StartingQuestIDs'></a>
### ParquetClassLibrary#Beings#ICharacterModelEdit#StartingQuestIDs `property`

##### Summary

The [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel')s that this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') either offers or has undertaken.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require readwrite access.

<a name='P-ParquetClassLibrary-Beings-CharacterModel-ParquetClassLibrary#Beings#ICharacterModelEdit#StoryCharacterID'></a>
### ParquetClassLibrary#Beings#ICharacterModelEdit#StoryCharacterID `property`

##### Summary

The story character that this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') represents.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require readwrite access.

<a name='P-ParquetClassLibrary-Beings-CharacterModel-PersonalName'></a>
### PersonalName `property`

##### Summary

Player-facing personal name.

<a name='P-ParquetClassLibrary-Beings-CharacterModel-Pronouns'></a>
### Pronouns `property`

##### Summary

A key for the [PronounGroup](#T-ParquetClassLibrary-Beings-PronounGroup 'ParquetClassLibrary.Beings.PronounGroup') the [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') uses,
stored as "[Objective](#P-ParquetClassLibrary-Beings-PronounGroup-Objective 'ParquetClassLibrary.Beings.PronounGroup.Objective')/[Subjective](#P-ParquetClassLibrary-Beings-PronounGroup-Subjective 'ParquetClassLibrary.Beings.PronounGroup.Subjective').

<a name='P-ParquetClassLibrary-Beings-CharacterModel-StartingDialogueIDs'></a>
### StartingDialogueIDs `property`

##### Summary

Dialogue lines this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') can say.

<a name='P-ParquetClassLibrary-Beings-CharacterModel-StartingInventoryIDs'></a>
### StartingInventoryIDs `property`

##### Summary

The set of belongings that this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') begins with.

##### Remarks

This is not the full [Inventory](#T-ParquetClassLibrary-Items-Inventory 'ParquetClassLibrary.Items.Inventory') but a list of item IDs to populate it with.

<a name='P-ParquetClassLibrary-Beings-CharacterModel-StartingQuestIDs'></a>
### StartingQuestIDs `property`

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

<a name='T-ParquetClassLibrary-Maps-ChunkDetail'></a>
## ChunkDetail `type`

##### Namespace

ParquetClassLibrary.Maps

##### Summary

Indicates which parquets constitute this [MapChunkModel](#T-ParquetClassLibrary-Maps-MapChunkModel 'ParquetClassLibrary.Maps.MapChunkModel') and how they are arranged.

##### Remarks

Every chunk is either handmade at design time or procedurally generated during play.
A chunk that is not handmade may have already been procedurally generated; if so, it
is termed "filled out".  If not, it will become filled out once it undergoes generation.
Handmade chunks are always filled out.



Chunks that are not filled out are instead composed of two layers: a base and a modifier.
The base is the underlying structure of the chunk and the modifier overlays it to
produce more complex arrangements than would otherwise be possible.  For example:
- Forest: Base·Grassy Solid · Modifier·Scattered Trees
- Seaside: Base·Watery Solid · Modifier·Eastern Sandy
- Town: Handmade

<a name='M-ParquetClassLibrary-Maps-ChunkDetail-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new default instance of the [ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail') class for use with serialization.

##### Parameters

This constructor has no parameters.

<a name='M-ParquetClassLibrary-Maps-ChunkDetail-#ctor-ParquetClassLibrary-Maps-ChunkTopography,ParquetClassLibrary-ModelTag,ParquetClassLibrary-Maps-ChunkTopography,ParquetClassLibrary-ModelTag-'></a>
### #ctor(inBaseTopography,inBaseComposition,inModifierTopography,inModifierComposition) `constructor`

##### Summary

Initializes a new instance of the [ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inBaseTopography | [ParquetClassLibrary.Maps.ChunkTopography](#T-ParquetClassLibrary-Maps-ChunkTopography 'ParquetClassLibrary.Maps.ChunkTopography') | The basic form that the [MapChunkModel](#T-ParquetClassLibrary-Maps-MapChunkModel 'ParquetClassLibrary.Maps.MapChunkModel') of parquets takes. |
| inBaseComposition | [ParquetClassLibrary.ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag') | Indicates the overall type of parquets in the [MapChunkModel](#T-ParquetClassLibrary-Maps-MapChunkModel 'ParquetClassLibrary.Maps.MapChunkModel'). |
| inModifierTopography | [ParquetClassLibrary.Maps.ChunkTopography](#T-ParquetClassLibrary-Maps-ChunkTopography 'ParquetClassLibrary.Maps.ChunkTopography') | Indicates a modifier on the [MapChunkModel](#T-ParquetClassLibrary-Maps-MapChunkModel 'ParquetClassLibrary.Maps.MapChunkModel') of parquets. |
| inModifierComposition | [ParquetClassLibrary.ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag') | Indicates the type of parquets modifying the [MapChunkModel](#T-ParquetClassLibrary-Maps-MapChunkModel 'ParquetClassLibrary.Maps.MapChunkModel'). |

<a name='F-ParquetClassLibrary-Maps-ChunkDetail-None'></a>
### None `constants`

##### Summary

The null [ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail'), which generates an empty [MapChunkModel](#T-ParquetClassLibrary-Maps-MapChunkModel 'ParquetClassLibrary.Maps.MapChunkModel').

<a name='P-ParquetClassLibrary-Maps-ChunkDetail-BaseComposition'></a>
### BaseComposition `property`

##### Summary

Indicates the overall type of parquets in the [MapChunkModel](#T-ParquetClassLibrary-Maps-MapChunkModel 'ParquetClassLibrary.Maps.MapChunkModel').

<a name='P-ParquetClassLibrary-Maps-ChunkDetail-BaseTopography'></a>
### BaseTopography `property`

##### Summary

Indicates the basic form that the [MapChunkModel](#T-ParquetClassLibrary-Maps-MapChunkModel 'ParquetClassLibrary.Maps.MapChunkModel') of parquets takes.

<a name='P-ParquetClassLibrary-Maps-ChunkDetail-ConverterFactory'></a>
### ConverterFactory `property`

##### Summary

Allows the converter to construct itself statically.

<a name='P-ParquetClassLibrary-Maps-ChunkDetail-ModifierComposition'></a>
### ModifierComposition `property`

##### Summary

Indicates the type of parquets modifying the [MapChunkModel](#T-ParquetClassLibrary-Maps-MapChunkModel 'ParquetClassLibrary.Maps.MapChunkModel').

<a name='P-ParquetClassLibrary-Maps-ChunkDetail-ModifierTopography'></a>
### ModifierTopography `property`

##### Summary

Indicates a modifier on the [MapChunkModel](#T-ParquetClassLibrary-Maps-MapChunkModel 'ParquetClassLibrary.Maps.MapChunkModel') of parquets.

<a name='M-ParquetClassLibrary-Maps-ChunkDetail-Clone'></a>
### Clone() `method`

##### Summary

Creates a new instance with the same characteristics as the current instance.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Maps-ChunkDetail-ConvertFromString-System-String,CsvHelper-IReaderRow,CsvHelper-Configuration-MemberMapData-'></a>
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

<a name='M-ParquetClassLibrary-Maps-ChunkDetail-ConvertToString-System-Object,CsvHelper-IWriterRow,CsvHelper-Configuration-MemberMapData-'></a>
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

<a name='M-ParquetClassLibrary-Maps-ChunkDetail-Equals-ParquetClassLibrary-Maps-ChunkDetail-'></a>
### Equals(inChunkType) `method`

##### Summary

Determines whether the specified [ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail') is equal to the current [ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail').

##### Returns

`true` if the [ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail')s are equal.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inChunkType | [ParquetClassLibrary.Maps.ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail') | The [ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail') to compare with the current. |

<a name='M-ParquetClassLibrary-Maps-ChunkDetail-Equals-System-Object-'></a>
### Equals(obj) `method`

##### Summary

Determines whether the specified [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') is equal to the current [ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail').

##### Returns

`true` if the specified [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') is equal to the current [ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail'); otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') to compare with the current [ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail'). |

<a name='M-ParquetClassLibrary-Maps-ChunkDetail-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Serves as a hash function for a [ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail') class.

##### Returns

A hash code for this instance that is suitable for use in hashing algorithms and data structures.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Maps-ChunkDetail-ToString'></a>
### ToString() `method`

##### Summary

Returns a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents the current [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace').

##### Returns

The representation.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Maps-ChunkDetail-op_Equality-ParquetClassLibrary-Maps-ChunkDetail,ParquetClassLibrary-Maps-ChunkDetail-'></a>
### op_Equality(inChunkType1,inChunkType2) `method`

##### Summary

Determines whether a specified instance of [ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail') is equal to
another specified instance of [ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail').

##### Returns

`true` if the two [ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail')s are equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inChunkType1 | [ParquetClassLibrary.Maps.ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail') | The first [ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail') to compare. |
| inChunkType2 | [ParquetClassLibrary.Maps.ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail') | The second [ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail') to compare. |

<a name='M-ParquetClassLibrary-Maps-ChunkDetail-op_Inequality-ParquetClassLibrary-Maps-ChunkDetail,ParquetClassLibrary-Maps-ChunkDetail-'></a>
### op_Inequality(inChunkType1,inChunkType2) `method`

##### Summary

Determines whether a specified instance of [ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail') is unequal to
another specified instance of [ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail').

##### Returns

`true` if the two [ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail')s are NOT equal; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inChunkType1 | [ParquetClassLibrary.Maps.ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail') | The first [ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail') to compare. |
| inChunkType2 | [ParquetClassLibrary.Maps.ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail') | The second [ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail') to compare. |

<a name='T-ParquetClassLibrary-Maps-ChunkTopography'></a>
## ChunkTopography `type`

##### Namespace

ParquetClassLibrary.Maps

##### Summary

Indicates the basic form that the parquets in a [MapChunkModel](#T-ParquetClassLibrary-Maps-MapChunkModel 'ParquetClassLibrary.Maps.MapChunkModel') take.

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

<a name='T-ParquetClassLibrary-Parquets-CollectibleModel'></a>
## CollectibleModel `type`

##### Namespace

ParquetClassLibrary.Parquets

##### Summary

Configurations for a sandbox collectible object, such as crafting materials.

<a name='M-ParquetClassLibrary-Parquets-CollectibleModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Nullable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag},ParquetClassLibrary-Parquets-CollectingEffect,System-Int32-'></a>
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
| inAddsToBiome | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}') | A set of flags indicating which, if any, [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe') this parquet helps to generate. |
| inAddsToRoom | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}') | A set of flags indicating which, if any, [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe') this parquet helps to generate. |
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

<a name='P-ParquetClassLibrary-Parquets-CollectibleModel-ParquetClassLibrary#Parquets#ICollectibleModelEdit#CollectionEffect'></a>
### ParquetClassLibrary#Parquets#ICollectibleModelEdit#CollectionEffect `property`

##### Summary

The effect generated when a character encounters this Collectible.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Parquets-CollectibleModel-ParquetClassLibrary#Parquets#ICollectibleModelEdit#EffectAmount'></a>
### ParquetClassLibrary#Parquets#ICollectibleModelEdit#EffectAmount `property`

##### Summary

The scale in points of the effect.
For example, how much to alter a stat if the [CollectingEffect](#T-ParquetClassLibrary-Parquets-CollectingEffect 'ParquetClassLibrary.Parquets.CollectingEffect') is set to alter a stat.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require read/write access.

<a name='T-ParquetClassLibrary-Parquets-CollectingEffect'></a>
## CollectingEffect `type`

##### Namespace

ParquetClassLibrary.Parquets

##### Summary

IDs for effects that can happen when a character encounters a Collectible.

<a name='F-ParquetClassLibrary-Parquets-CollectingEffect-BiomeTime'></a>
### BiomeTime `constants`

##### Summary

Allows the [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') to remain safely in the [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe') longer.

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

<a name='T-ParquetClassLibrary-Crafts-CraftConfiguration'></a>
## CraftConfiguration `type`

##### Namespace

ParquetClassLibrary.Crafts

##### Summary

Provides parameters for [CraftingRecipe](#T-ParquetClassLibrary-Crafts-CraftingRecipe 'ParquetClassLibrary.Crafts.CraftingRecipe')s.

<a name='P-ParquetClassLibrary-Crafts-CraftConfiguration-IngredientCount'></a>
### IngredientCount `property`

##### Summary

Number of ingredient categories per recipe.

<a name='P-ParquetClassLibrary-Crafts-CraftConfiguration-ProductCount'></a>
### ProductCount `property`

##### Summary

Number of product categories per recipe.

<a name='M-ParquetClassLibrary-Crafts-CraftConfiguration-GetFilePath'></a>
### GetFilePath() `method`

##### Summary

Returns the filename and path associated with [CraftConfiguration](#T-ParquetClassLibrary-Crafts-CraftConfiguration 'ParquetClassLibrary.Crafts.CraftConfiguration')'s definition file.

##### Returns

A full path to the associated file.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Crafts-CraftConfiguration-GetRecord'></a>
### GetRecord() `method`

##### Summary

Reads [CraftConfiguration](#T-ParquetClassLibrary-Crafts-CraftConfiguration 'ParquetClassLibrary.Crafts.CraftConfiguration') data from the appropriate file.

##### Returns

The instances read.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Crafts-CraftConfiguration-PutRecord'></a>
### PutRecord() `method`

##### Summary

Writes [CraftConfiguration](#T-ParquetClassLibrary-Crafts-CraftConfiguration 'ParquetClassLibrary.Crafts.CraftConfiguration') data to the appropriate file.

##### Parameters

This method has no parameters.

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
[PanelsPerPatternWidth](#F-ParquetClassLibrary-Crafts-StrikePanelGrid-PanelsPerPatternWidth 'ParquetClassLibrary.Crafts.StrikePanelGrid.PanelsPerPatternWidth') and [PanelsPerPatternHeight](#F-ParquetClassLibrary-Crafts-StrikePanelGrid-PanelsPerPatternHeight 'ParquetClassLibrary.Crafts.StrikePanelGrid.PanelsPerPatternHeight'). |

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

<a name='P-ParquetClassLibrary-Crafts-CraftingRecipe-ParquetClassLibrary#Crafts#ICraftingRecipeEdit#Ingredients'></a>
### ParquetClassLibrary#Crafts#ICraftingRecipeEdit#Ingredients `property`

##### Summary

All materials and their quantities needed to follow this recipe once.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require readwrite access.

<a name='P-ParquetClassLibrary-Crafts-CraftingRecipe-ParquetClassLibrary#Crafts#ICraftingRecipeEdit#PanelPattern'></a>
### ParquetClassLibrary#Crafts#ICraftingRecipeEdit#PanelPattern `property`

##### Summary

The arrangment of panels encompassed by this recipe.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require readwrite access.

<a name='P-ParquetClassLibrary-Crafts-CraftingRecipe-ParquetClassLibrary#Crafts#ICraftingRecipeEdit#Products'></a>
### ParquetClassLibrary#Crafts#ICraftingRecipeEdit#Products `property`

##### Summary

The types and amounts of [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel')s created by following this recipe.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require readwrite access.

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

<a name='M-ParquetClassLibrary-Beings-CritterModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID}-'></a>
### #ctor(inID,inName,inDescription,inComment,inNativeBiomeID,inPrimaryBehaviorID,inAvoidsIDs,inSeeksIDs) `constructor`

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
| inNativeBiomeID | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | The [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe') in which this [CritterModel](#T-ParquetClassLibrary-Beings-CritterModel 'ParquetClassLibrary.Beings.CritterModel') is most comfortable. |
| inPrimaryBehaviorID | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | The rules that govern how this [CritterModel](#T-ParquetClassLibrary-Beings-CritterModel 'ParquetClassLibrary.Beings.CritterModel') acts.  Cannot be null. |
| inAvoidsIDs | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}') | Any parquets this [CritterModel](#T-ParquetClassLibrary-Beings-CritterModel 'ParquetClassLibrary.Beings.CritterModel') avoids. |
| inSeeksIDs | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}') | Any parquets this [CritterModel](#T-ParquetClassLibrary-Beings-CritterModel 'ParquetClassLibrary.Beings.CritterModel') seeks. |

<a name='T-ParquetClassLibrary-Delimiters'></a>
## Delimiters `type`

##### Namespace

ParquetClassLibrary

##### Summary

Provides a unified source of serialization separators for the library.

<a name='F-ParquetClassLibrary-Delimiters-DimensionalDelimiter'></a>
### DimensionalDelimiter `constants`

##### Summary

Separator for encoding the dimensions of [IGrid\`1](#T-ParquetClassLibrary-IGrid`1 'ParquetClassLibrary.IGrid`1') implementations.

<a name='F-ParquetClassLibrary-Delimiters-DimensionalTerminator'></a>
### DimensionalTerminator `constants`

##### Summary

Separator for encoding the dimensions of [IGrid\`1](#T-ParquetClassLibrary-IGrid`1 'ParquetClassLibrary.IGrid`1') implementations.

<a name='F-ParquetClassLibrary-Delimiters-ElementDelimiter'></a>
### ElementDelimiter `constants`

##### Summary

Separates primitives within serialized [Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D')s and [Range\`1](#T-ParquetClassLibrary-Range`1 'ParquetClassLibrary.Range`1')s.

<a name='F-ParquetClassLibrary-Delimiters-InternalDelimiter'></a>
### InternalDelimiter `constants`

##### Summary

Separates properties within a class when in serialization.

<a name='F-ParquetClassLibrary-Delimiters-NameDelimiter'></a>
### NameDelimiter `constants`

##### Summary

Separates family and personal names within serialized [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel')s.

<a name='F-ParquetClassLibrary-Delimiters-PrimaryDelimiter'></a>
### PrimaryDelimiter `constants`

##### Summary

Separates collections within files.

<a name='F-ParquetClassLibrary-Delimiters-PronounDelimiter'></a>
### PronounDelimiter `constants`

##### Summary

Marks out tags that need to be replaced with pronouns from a [PronounGroup](#T-ParquetClassLibrary-Beings-PronounGroup 'ParquetClassLibrary.Beings.PronounGroup')s.

<a name='F-ParquetClassLibrary-Delimiters-SecondaryDelimiter'></a>
### SecondaryDelimiter `constants`

##### Summary

Separates objects within collections.

<a name='T-ParquetClassLibrary-Parquets-EntryType'></a>
## EntryType `type`

##### Namespace

ParquetClassLibrary.Parquets

##### Summary

Whether and how a [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') communicates to an adjacent [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel').

<a name='F-ParquetClassLibrary-Parquets-EntryType-Down'></a>
### Down `constants`

##### Summary

This furnishing communicates to the map below.

<a name='F-ParquetClassLibrary-Parquets-EntryType-None'></a>
### None `constants`

##### Summary

This furnishing does not communicate to another map or room.

<a name='F-ParquetClassLibrary-Parquets-EntryType-Room'></a>
### Room `constants`

##### Summary

This furnishing communicates between rooms on the same map.

<a name='F-ParquetClassLibrary-Parquets-EntryType-Up'></a>
### Up `constants`

##### Summary

This furnishing communicates to the map above.

<a name='T-ParquetClassLibrary-Parquets-FloorModel'></a>
## FloorModel `type`

##### Namespace

ParquetClassLibrary.Parquets

##### Summary

Configurations for a sandbox parquet walking surface.

<a name='M-ParquetClassLibrary-Parquets-FloorModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Nullable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag},ParquetClassLibrary-Items-ModificationTool,System-String-'></a>
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
| inAddsToBiome | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}') | Which, if any, [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe') this parquet helps to generate. |
| inAddsToRoom | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}') | Describes which, if any, [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe')(s) this parquet helps form. |
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

<a name='P-ParquetClassLibrary-Parquets-FloorModel-ParquetClassLibrary#Parquets#IFloorModelEdit#ModTool'></a>
### ParquetClassLibrary#Parquets#IFloorModelEdit#ModTool `property`

##### Summary

The tool used to dig out or fill in the floor.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Parquets-FloorModel-ParquetClassLibrary#Parquets#IFloorModelEdit#TrenchName'></a>
### ParquetClassLibrary#Parquets#IFloorModelEdit#TrenchName `property`

##### Summary

Player-facing name of the parquet, used when it has been dug out.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require read/write access.

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

<a name='M-ParquetClassLibrary-Parquets-FurnishingModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Nullable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag},System-Boolean,ParquetClassLibrary-Parquets-EntryType,System-Boolean,System-Boolean,System-Nullable{ParquetClassLibrary-ModelID}-'></a>
### #ctor(inID,inName,inDescription,inComment,inItemID,inAddsToBiome,inAddsToRoom,inIsWalkable,inEntry,inIsEnclosing,inIsFlammable,inSwapID) `constructor`

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
| inAddsToBiome | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}') | Indicates which, if any, [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe') this parquet helps to generate. |
| inAddsToRoom | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}') | Describes which, if any, [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe')(s) this parquet helps form. |
| inIsWalkable | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If `true` this [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') may be walked on. |
| inEntry | [ParquetClassLibrary.Parquets.EntryType](#T-ParquetClassLibrary-Parquets-EntryType 'ParquetClassLibrary.Parquets.EntryType') | If `true` this [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') serves as an entry to a [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room'). |
| inIsEnclosing | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If `true` this [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') serves as part of a perimeter of a [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room'). |
| inIsFlammable | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If `true` this [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') may catch fire. |
| inSwapID | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | A [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') to swap with this furnishing on open/close actions. |

<a name='P-ParquetClassLibrary-Parquets-FurnishingModel-Bounds'></a>
### Bounds `property`

##### Summary

The set of values that are allowed for Furnishing IDs.

<a name='P-ParquetClassLibrary-Parquets-FurnishingModel-Entry'></a>
### Entry `property`

##### Summary

Indicates if and how this [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') serves as an entry to a [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') or [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel').

<a name='P-ParquetClassLibrary-Parquets-FurnishingModel-IsEnclosing'></a>
### IsEnclosing `property`

##### Summary

Indicates whether this [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') serves as part of a perimeter of a [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room').

<a name='P-ParquetClassLibrary-Parquets-FurnishingModel-IsFlammable'></a>
### IsFlammable `property`

##### Summary

Whether or not the [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') is flammable.

<a name='P-ParquetClassLibrary-Parquets-FurnishingModel-IsWalkable'></a>
### IsWalkable `property`

##### Summary

Indicates whether this [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') may be walked on.

<a name='P-ParquetClassLibrary-Parquets-FurnishingModel-ParquetClassLibrary#Parquets#IFurnishingModelEdit#Entry'></a>
### ParquetClassLibrary#Parquets#IFurnishingModelEdit#Entry `property`

##### Summary

Indicates if and how this [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') serves as an entry to a [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') or [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel').

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Parquets-FurnishingModel-ParquetClassLibrary#Parquets#IFurnishingModelEdit#IsEnclosing'></a>
### ParquetClassLibrary#Parquets#IFurnishingModelEdit#IsEnclosing `property`

##### Summary

Indicates whether this [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') serves as part of a perimeter of a [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room').

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Parquets-FurnishingModel-ParquetClassLibrary#Parquets#IFurnishingModelEdit#IsFlammable'></a>
### ParquetClassLibrary#Parquets#IFurnishingModelEdit#IsFlammable `property`

##### Summary

Whether or not the [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') is flammable.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Parquets-FurnishingModel-ParquetClassLibrary#Parquets#IFurnishingModelEdit#IsWalkable'></a>
### ParquetClassLibrary#Parquets#IFurnishingModelEdit#IsWalkable `property`

##### Summary

Indicates whether this [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') may be walked on.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Parquets-FurnishingModel-ParquetClassLibrary#Parquets#IFurnishingModelEdit#SwapID'></a>
### ParquetClassLibrary#Parquets#IFurnishingModelEdit#SwapID `property`

##### Summary

The [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') to swap with this Furnishing on an open/close action.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Parquets-FurnishingModel-SwapID'></a>
### SwapID `property`

##### Summary

The [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') to swap with this Furnishing on an open/close action.

<a name='T-ParquetClassLibrary-Games-GameModel'></a>
## GameModel `type`

##### Namespace

ParquetClassLibrary.Games

##### Summary

Collects data about a Parquet-based game generally.

<a name='M-ParquetClassLibrary-Games-GameModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Boolean,System-String,System-Int32,System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID}-'></a>
### #ctor(inID,inName,inDescription,inComment,inIsEpisode,inEpisodeTitle,inEpisodeNumber,inPlayerCharacterID,inFirstScriptID) `constructor`

##### Summary

Represents a game or game-episode created with the Parquet system.
Primarily cointains metadata and gameplay rules information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | Unique identifier for the [GameModel](#T-ParquetClassLibrary-Games-GameModel 'ParquetClassLibrary.Games.GameModel').  Cannot be null. |
| inName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-facing title of the [GameModel](#T-ParquetClassLibrary-Games-GameModel 'ParquetClassLibrary.Games.GameModel').  Cannot be null or empty. |
| inDescription | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-facing description of the [GameModel](#T-ParquetClassLibrary-Games-GameModel 'ParquetClassLibrary.Games.GameModel'). |
| inComment | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A private comment on the nature of the game or episode. |
| inIsEpisode | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If `true` this game is part of a longer sequence of games. |
| inEpisodeTitle | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Title of this episode, if any. |
| inEpisodeNumber | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Number of this episode in its sequence, if any. |
| inPlayerCharacterID | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') that the player controls at the outset. |
| inFirstScriptID | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel') to run when play begins. |

<a name='P-ParquetClassLibrary-Games-GameModel-EpisodeNumber'></a>
### EpisodeNumber `property`

##### Summary

Number of this episode in its sequence, if any.

<a name='P-ParquetClassLibrary-Games-GameModel-EpisodeTitle'></a>
### EpisodeTitle `property`

##### Summary

Subtitle, if any.  This will be used as the title of the episode if [IsEpisode](#P-ParquetClassLibrary-Games-GameModel-IsEpisode 'ParquetClassLibrary.Games.GameModel.IsEpisode') is `true`.

<a name='P-ParquetClassLibrary-Games-GameModel-FirstScriptID'></a>
### FirstScriptID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel') to run when play begins.

<a name='P-ParquetClassLibrary-Games-GameModel-IsEpisode'></a>
### IsEpisode `property`

##### Summary

If `true` this game is part of a sequence of games.

<a name='P-ParquetClassLibrary-Games-GameModel-ParquetClassLibrary#Games#IGameModelEdit#EpisodeNumber'></a>
### ParquetClassLibrary#Games#IGameModelEdit#EpisodeNumber `property`

##### Summary

Number of this episode in its sequence, if any.

##### Remarks

By design, children of [GameModel](#T-ParquetClassLibrary-Games-GameModel 'ParquetClassLibrary.Games.GameModel') should never themselves use [IGameModelEdit](#T-ParquetClassLibrary-Games-IGameModelEdit 'ParquetClassLibrary.Games.IGameModelEdit').
IGameModelEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Games-GameModel-ParquetClassLibrary#Games#IGameModelEdit#EpisodeTitle'></a>
### ParquetClassLibrary#Games#IGameModelEdit#EpisodeTitle `property`

##### Summary

Subtitle, if any.  This will be used as the title of the episode if [IsEpisode](#P-ParquetClassLibrary-Games-GameModel-IsEpisode 'ParquetClassLibrary.Games.GameModel.IsEpisode') is `true`.

##### Remarks

By design, children of [GameModel](#T-ParquetClassLibrary-Games-GameModel 'ParquetClassLibrary.Games.GameModel') should never themselves use [IGameModelEdit](#T-ParquetClassLibrary-Games-IGameModelEdit 'ParquetClassLibrary.Games.IGameModelEdit').
IGameModelEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Games-GameModel-ParquetClassLibrary#Games#IGameModelEdit#FirstScriptID'></a>
### ParquetClassLibrary#Games#IGameModelEdit#FirstScriptID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel') to run when play begins.

##### Remarks

By design, children of [GameModel](#T-ParquetClassLibrary-Games-GameModel 'ParquetClassLibrary.Games.GameModel') should never themselves use [IGameModelEdit](#T-ParquetClassLibrary-Games-IGameModelEdit 'ParquetClassLibrary.Games.IGameModelEdit').
IGameModelEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Games-GameModel-ParquetClassLibrary#Games#IGameModelEdit#IsEpisode'></a>
### ParquetClassLibrary#Games#IGameModelEdit#IsEpisode `property`

##### Summary

If `true` this game is part of a sequence of games.

##### Remarks

By design, children of [GameModel](#T-ParquetClassLibrary-Games-GameModel 'ParquetClassLibrary.Games.GameModel') should never themselves use [IGameModelEdit](#T-ParquetClassLibrary-Games-IGameModelEdit 'ParquetClassLibrary.Games.IGameModelEdit').
IGameModelEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Games-GameModel-ParquetClassLibrary#Games#IGameModelEdit#PlayerCharacterID'></a>
### ParquetClassLibrary#Games#IGameModelEdit#PlayerCharacterID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') that the player controls at the outset.

##### Remarks

By design, children of [GameModel](#T-ParquetClassLibrary-Games-GameModel 'ParquetClassLibrary.Games.GameModel') should never themselves use [IGameModelEdit](#T-ParquetClassLibrary-Games-IGameModelEdit 'ParquetClassLibrary.Games.IGameModelEdit').
IGameModelEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Games-GameModel-PlayerCharacterID'></a>
### PlayerCharacterID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') that the player controls at the outset.

<a name='M-ParquetClassLibrary-Games-GameModel-ToString'></a>
### ToString() `method`

##### Summary

Returns a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents the current [GameModel](#T-ParquetClassLibrary-Games-GameModel 'ParquetClassLibrary.Games.GameModel').

##### Returns

The representation.

##### Parameters

This method has no parameters.

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

<a name='T-ParquetClassLibrary-Beings-IBeingModelEdit'></a>
## IBeingModelEdit `type`

##### Namespace

ParquetClassLibrary.Beings

##### Summary

Facilitates editing of a [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') from design tools while maintaining a read-only face for use during play.

<a name='P-ParquetClassLibrary-Beings-IBeingModelEdit-AvoidsIDs'></a>
### AvoidsIDs `property`

##### Summary

Types of parquets this [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') avoids, if any.

<a name='P-ParquetClassLibrary-Beings-IBeingModelEdit-NativeBiomeID'></a>
### NativeBiomeID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe') in which this character is at home.

<a name='P-ParquetClassLibrary-Beings-IBeingModelEdit-PrimaryBehaviorID'></a>
### PrimaryBehaviorID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel') governing the way this being acts.

<a name='P-ParquetClassLibrary-Beings-IBeingModelEdit-SeeksIDs'></a>
### SeeksIDs `property`

##### Summary

Types of parquets this [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') seeks out, if any.

<a name='T-ParquetClassLibrary-Biomes-IBiomeRecipeEdit'></a>
## IBiomeRecipeEdit `type`

##### Namespace

ParquetClassLibrary.Biomes

##### Summary

Facilitates editing of a [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe') from design tools while maintaining a read-only face for use during play.

<a name='P-ParquetClassLibrary-Biomes-IBiomeRecipeEdit-EntryRequirements'></a>
### EntryRequirements `property`

##### Summary

Describes the [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel')s a [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') needs to safely access this biome.

<a name='P-ParquetClassLibrary-Biomes-IBiomeRecipeEdit-IsLiquidBased'></a>
### IsLiquidBased `property`

##### Summary

Determines whether or not this [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe') is defined in terms of liquid parquets.

<a name='P-ParquetClassLibrary-Biomes-IBiomeRecipeEdit-IsRoomBased'></a>
### IsRoomBased `property`

##### Summary

Determines whether or not this [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe') is defined in terms of [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room')s.

<a name='P-ParquetClassLibrary-Biomes-IBiomeRecipeEdit-ParquetCriteria'></a>
### ParquetCriteria `property`

##### Summary

Describes the parquets that make up this [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe').

<a name='P-ParquetClassLibrary-Biomes-IBiomeRecipeEdit-Tier'></a>
### Tier `property`

##### Summary

A rating indicating where in the progression this [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe') falls.
Must be non-negative.  Higher values indicate later Biomes.

<a name='T-ParquetClassLibrary-Parquets-IBlockModelEdit'></a>
## IBlockModelEdit `type`

##### Namespace

ParquetClassLibrary.Parquets

##### Summary

Facilitates editing of a [BlockModel](#T-ParquetClassLibrary-Parquets-BlockModel 'ParquetClassLibrary.Parquets.BlockModel') from design tools while maintaining a read-only face for use during play.

##### Remarks

By design, children of [BlockModel](#T-ParquetClassLibrary-Parquets-BlockModel 'ParquetClassLibrary.Parquets.BlockModel') should never themselves use [IBlockModelEdit](#T-ParquetClassLibrary-Parquets-IBlockModelEdit 'ParquetClassLibrary.Parquets.IBlockModelEdit').
IBlockModelEdit is for use only by external types that require read/write access to model properties.

<a name='P-ParquetClassLibrary-Parquets-IBlockModelEdit-CollectibleID'></a>
### CollectibleID `property`

##### Summary

The Collectible spawned when a character gathers this Block.

<a name='P-ParquetClassLibrary-Parquets-IBlockModelEdit-GatherEffect'></a>
### GatherEffect `property`

##### Summary

The effect generated when a character gathers this Block.

<a name='P-ParquetClassLibrary-Parquets-IBlockModelEdit-GatherTool'></a>
### GatherTool `property`

##### Summary

The tool used to remove the block.

<a name='P-ParquetClassLibrary-Parquets-IBlockModelEdit-IsFlammable'></a>
### IsFlammable `property`

##### Summary

Whether or not the block is flammable.

<a name='P-ParquetClassLibrary-Parquets-IBlockModelEdit-IsLiquid'></a>
### IsLiquid `property`

##### Summary

Whether or not the block is a liquid.

<a name='P-ParquetClassLibrary-Parquets-IBlockModelEdit-MaxToughness'></a>
### MaxToughness `property`

##### Summary

The block's native toughness.

<a name='T-ParquetClassLibrary-Beings-ICharacterModelEdit'></a>
## ICharacterModelEdit `type`

##### Namespace

ParquetClassLibrary.Beings

##### Summary

Facilitates editing of a [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') from design tools while maintaining a read-only face for use during play.

##### Remarks

By design, children of [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') should never themselves use [ICharacterModelEdit](#T-ParquetClassLibrary-Beings-ICharacterModelEdit 'ParquetClassLibrary.Beings.ICharacterModelEdit').
ICharacterModelEdit is for use only by external types that require read/write access to model properties.

<a name='P-ParquetClassLibrary-Beings-ICharacterModelEdit-FamilyName'></a>
### FamilyName `property`

##### Summary

Player-facing family name.

<a name='P-ParquetClassLibrary-Beings-ICharacterModelEdit-PersonalName'></a>
### PersonalName `property`

##### Summary

Player-facing personal name.

<a name='P-ParquetClassLibrary-Beings-ICharacterModelEdit-Pronouns'></a>
### Pronouns `property`

##### Summary

A key for the [PronounGroup](#T-ParquetClassLibrary-Beings-PronounGroup 'ParquetClassLibrary.Beings.PronounGroup') the [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') uses,
stored as "[Objective](#P-ParquetClassLibrary-Beings-PronounGroup-Objective 'ParquetClassLibrary.Beings.PronounGroup.Objective')/[Subjective](#P-ParquetClassLibrary-Beings-PronounGroup-Subjective 'ParquetClassLibrary.Beings.PronounGroup.Subjective').

<a name='P-ParquetClassLibrary-Beings-ICharacterModelEdit-StartingDialogueIDs'></a>
### StartingDialogueIDs `property`

##### Summary

Dialogue lines this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') can say.

<a name='P-ParquetClassLibrary-Beings-ICharacterModelEdit-StartingInventoryIDs'></a>
### StartingInventoryIDs `property`

##### Summary

The set of belongings that this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') begins with.

##### Remarks

This is not the full [Inventory](#T-ParquetClassLibrary-Items-Inventory 'ParquetClassLibrary.Items.Inventory') but a list of item IDs to populate it with.

<a name='P-ParquetClassLibrary-Beings-ICharacterModelEdit-StartingQuestIDs'></a>
### StartingQuestIDs `property`

##### Summary

The [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel')s that this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') either offers or has undertaken.

##### Remarks

Typically, NPCs offer quests, player characters undertake them.

<a name='P-ParquetClassLibrary-Beings-ICharacterModelEdit-StoryCharacterID'></a>
### StoryCharacterID `property`

##### Summary

The story character that this [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') represents.

##### Remarks

This identifier provides a link between software character classes
and the characters written of in a game's narrative that they represent.  The goal
is that these identifiers be able to span any number of shipped titles, allowing a
sequel title to import data from prior titles in such a way that one game's NPC
can become another game's protagonist.

<a name='T-ParquetClassLibrary-Parquets-ICollectibleModelEdit'></a>
## ICollectibleModelEdit `type`

##### Namespace

ParquetClassLibrary.Parquets

##### Summary

Facilitates editing of a [CollectibleModel](#T-ParquetClassLibrary-Parquets-CollectibleModel 'ParquetClassLibrary.Parquets.CollectibleModel') from design tools while maintaining a read-only face for use during play.

##### Remarks

By design, children of [CollectibleModel](#T-ParquetClassLibrary-Parquets-CollectibleModel 'ParquetClassLibrary.Parquets.CollectibleModel') should never themselves use [ICollectibleModelEdit](#T-ParquetClassLibrary-Parquets-ICollectibleModelEdit 'ParquetClassLibrary.Parquets.ICollectibleModelEdit').
ICollectibleModelEdit is for use only by external types that require read/write access to model properties.

<a name='P-ParquetClassLibrary-Parquets-ICollectibleModelEdit-CollectionEffect'></a>
### CollectionEffect `property`

##### Summary

The effect generated when a character encounters this Collectible.

<a name='P-ParquetClassLibrary-Parquets-ICollectibleModelEdit-EffectAmount'></a>
### EffectAmount `property`

##### Summary

The scale in points of the effect.
For example, how much to alter a stat if the [CollectingEffect](#T-ParquetClassLibrary-Parquets-CollectingEffect 'ParquetClassLibrary.Parquets.CollectingEffect') is set to alter a stat.

<a name='T-ParquetClassLibrary-Crafts-ICraftingRecipeEdit'></a>
## ICraftingRecipeEdit `type`

##### Namespace

ParquetClassLibrary.Crafts

##### Summary

Facilitates editing of a [CraftingRecipe](#T-ParquetClassLibrary-Crafts-CraftingRecipe 'ParquetClassLibrary.Crafts.CraftingRecipe') from design tools while maintaining a read-only face for use during play.

##### Remarks

By design, children of [CraftingRecipe](#T-ParquetClassLibrary-Crafts-CraftingRecipe 'ParquetClassLibrary.Crafts.CraftingRecipe') should never themselves use [ICraftingRecipeEdit](#T-ParquetClassLibrary-Crafts-ICraftingRecipeEdit 'ParquetClassLibrary.Crafts.ICraftingRecipeEdit').
ICraftingRecipeEdit is for use only by external types that require read/write access to model properties.

<a name='P-ParquetClassLibrary-Crafts-ICraftingRecipeEdit-Ingredients'></a>
### Ingredients `property`

##### Summary

All materials and their quantities needed to follow this recipe once.

<a name='P-ParquetClassLibrary-Crafts-ICraftingRecipeEdit-PanelPattern'></a>
### PanelPattern `property`

##### Summary

The arrangment of panels encompassed by this recipe.

<a name='P-ParquetClassLibrary-Crafts-ICraftingRecipeEdit-Products'></a>
### Products `property`

##### Summary

The types and amounts of [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel')s created by following this recipe.

<a name='T-ParquetClassLibrary-Beings-ICritterModelEdit'></a>
## ICritterModelEdit `type`

##### Namespace

ParquetClassLibrary.Beings

##### Summary

Facilitates editing of a [CritterModel](#T-ParquetClassLibrary-Beings-CritterModel 'ParquetClassLibrary.Beings.CritterModel') from design tools while maintaining a read-only face for use during play.

##### Remarks

By design, children of [CritterModel](#T-ParquetClassLibrary-Beings-CritterModel 'ParquetClassLibrary.Beings.CritterModel') should never themselves use [ICritterModelEdit](#T-ParquetClassLibrary-Beings-ICritterModelEdit 'ParquetClassLibrary.Beings.ICritterModelEdit').
ICritterModelEdit is for use only by external types that require read/write access to model properties.

<a name='T-ParquetClassLibrary-Maps-MapAnalysis`1-IDByDirection'></a>
## IDByDirection `type`

##### Namespace

ParquetClassLibrary.Maps.MapAnalysis`1

##### Summary

Models a method that takes a map and returns the [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') for an adjacent map.

<a name='T-ParquetClassLibrary-Parquets-IFloorModelEdit'></a>
## IFloorModelEdit `type`

##### Namespace

ParquetClassLibrary.Parquets

##### Summary

Facilitates editing of a [FloorModel](#T-ParquetClassLibrary-Parquets-FloorModel 'ParquetClassLibrary.Parquets.FloorModel') from design tools while maintaining a read-only face for use during play.

##### Remarks

By design, children of [FloorModel](#T-ParquetClassLibrary-Parquets-FloorModel 'ParquetClassLibrary.Parquets.FloorModel') should never themselves use [IFloorModelEdit](#T-ParquetClassLibrary-Parquets-IFloorModelEdit 'ParquetClassLibrary.Parquets.IFloorModelEdit').
IFloorModelEdit is for use only by external types that require read/write access to model properties.

<a name='P-ParquetClassLibrary-Parquets-IFloorModelEdit-ModTool'></a>
### ModTool `property`

##### Summary

The tool used to dig out or fill in the floor.

<a name='P-ParquetClassLibrary-Parquets-IFloorModelEdit-TrenchName'></a>
### TrenchName `property`

##### Summary

Player-facing name of the parquet, used when it has been dug out.

<a name='T-ParquetClassLibrary-Parquets-IFurnishingModelEdit'></a>
## IFurnishingModelEdit `type`

##### Namespace

ParquetClassLibrary.Parquets

##### Summary

Facilitates editing of a [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') from design tools while maintaining a read-only face for use during play.

##### Remarks

By design, children of [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') should never themselves use [IFurnishingModelEdit](#T-ParquetClassLibrary-Parquets-IFurnishingModelEdit 'ParquetClassLibrary.Parquets.IFurnishingModelEdit').
IFurnishingModelEdit is for use only by external types that require read/write access to model properties.

<a name='P-ParquetClassLibrary-Parquets-IFurnishingModelEdit-Entry'></a>
### Entry `property`

##### Summary

Indicates if and how this [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') serves as an entry to a [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') or [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel').

<a name='P-ParquetClassLibrary-Parquets-IFurnishingModelEdit-IsEnclosing'></a>
### IsEnclosing `property`

##### Summary

Indicates whether this [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') serves as part of a perimeter of a [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room').

<a name='P-ParquetClassLibrary-Parquets-IFurnishingModelEdit-IsFlammable'></a>
### IsFlammable `property`

##### Summary

Whether or not the [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') is flammable.

<a name='P-ParquetClassLibrary-Parquets-IFurnishingModelEdit-IsWalkable'></a>
### IsWalkable `property`

##### Summary

Indicates whether this [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') may be walked on.

<a name='P-ParquetClassLibrary-Parquets-IFurnishingModelEdit-SwapID'></a>
### SwapID `property`

##### Summary

The [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') to swap with this Furnishing on an open/close action.

<a name='T-ParquetClassLibrary-Games-IGameModelEdit'></a>
## IGameModelEdit `type`

##### Namespace

ParquetClassLibrary.Games

##### Summary

Facilitates editing of a [GameModel](#T-ParquetClassLibrary-Games-GameModel 'ParquetClassLibrary.Games.GameModel') from design tools while maintaining a read-only face for use during play.

##### Remarks

By design, children of [GameModel](#T-ParquetClassLibrary-Games-GameModel 'ParquetClassLibrary.Games.GameModel') should never themselves use [IGameModelEdit](#T-ParquetClassLibrary-Games-IGameModelEdit 'ParquetClassLibrary.Games.IGameModelEdit').
IGameModelEdit is for use only by external types that require read/write access to model properties.

<a name='P-ParquetClassLibrary-Games-IGameModelEdit-EpisodeNumber'></a>
### EpisodeNumber `property`

##### Summary

Number of this episode in its sequence, if any.

<a name='P-ParquetClassLibrary-Games-IGameModelEdit-EpisodeTitle'></a>
### EpisodeTitle `property`

##### Summary

Subtitle, if any.  This will be used as the title of the episode if [IsEpisode](#P-ParquetClassLibrary-Games-IGameModelEdit-IsEpisode 'ParquetClassLibrary.Games.IGameModelEdit.IsEpisode') is `true`.

<a name='P-ParquetClassLibrary-Games-IGameModelEdit-FirstScriptID'></a>
### FirstScriptID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel') to run when play begins.

<a name='P-ParquetClassLibrary-Games-IGameModelEdit-IsEpisode'></a>
### IsEpisode `property`

##### Summary

If `true` this game is part of a longer sequence of games.

<a name='P-ParquetClassLibrary-Games-IGameModelEdit-PlayerCharacterID'></a>
### PlayerCharacterID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel') that the player controls at the outset.

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

<a name='T-ParquetClassLibrary-Scripts-IInteractionModelEdit'></a>
## IInteractionModelEdit `type`

##### Namespace

ParquetClassLibrary.Scripts

##### Summary

Facilitates editing of a [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel') from design tools while maintaining a read-only face for use during play.

##### Remarks

By design, children of [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel') should never themselves use [IInteractionModelEdit](#T-ParquetClassLibrary-Scripts-IInteractionModelEdit 'ParquetClassLibrary.Scripts.IInteractionModelEdit').
IInteractionModelEdit is for use only by external types that require read/write access to model properties.

<a name='P-ParquetClassLibrary-Scripts-IInteractionModelEdit-OutcomesIDs'></a>
### OutcomesIDs `property`

##### Summary

Describes the results of finishing this interaction.

<a name='P-ParquetClassLibrary-Scripts-IInteractionModelEdit-PrerequisitesIDs'></a>
### PrerequisitesIDs `property`

##### Summary

Describes the criteria for begining this interaction.

<a name='P-ParquetClassLibrary-Scripts-IInteractionModelEdit-StepsIDs'></a>
### StepsIDs `property`

##### Summary

Everything this interaction entails.

<a name='T-ParquetClassLibrary-Items-IItemModelEdit'></a>
## IItemModelEdit `type`

##### Namespace

ParquetClassLibrary.Items

##### Summary

Facilitates editing of a [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel') from design tools while maintaining a read-only face for use during play.

##### Remarks

By design, children of [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel') should never themselves use [IItemModelEdit](#T-ParquetClassLibrary-Items-IItemModelEdit 'ParquetClassLibrary.Items.IItemModelEdit').
IItemModelEdit is for use only by external types that require read/write access to model properties.

<a name='P-ParquetClassLibrary-Items-IItemModelEdit-EffectWhenUsedID'></a>
### EffectWhenUsedID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel') generating the in-game effect caused by
using (consuming) the item.

<a name='P-ParquetClassLibrary-Items-IItemModelEdit-EffectWhileHeldID'></a>
### EffectWhileHeldID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel') generating the in-game effect caused by
keeping the item in a [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel')'s [Inventory](#T-ParquetClassLibrary-Items-Inventory 'ParquetClassLibrary.Items.Inventory').

<a name='P-ParquetClassLibrary-Items-IItemModelEdit-ItemTags'></a>
### ItemTags `property`

##### Summary

Any additional functionality this item has, e.g. contributing to a [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe').

<a name='P-ParquetClassLibrary-Items-IItemModelEdit-ParquetID'></a>
### ParquetID `property`

##### Summary

The parquet that corresponds to this item, if any.

<a name='P-ParquetClassLibrary-Items-IItemModelEdit-Price'></a>
### Price `property`

##### Summary

In-game value of the item.  Must be non-negative.

<a name='P-ParquetClassLibrary-Items-IItemModelEdit-Rarity'></a>
### Rarity `property`

##### Summary

How relatively rare this item is.

<a name='P-ParquetClassLibrary-Items-IItemModelEdit-StackMax'></a>
### StackMax `property`

##### Summary

How many of the item may share a single inventory slot.

<a name='P-ParquetClassLibrary-Items-IItemModelEdit-Subtype'></a>
### Subtype `property`

##### Summary

The type of item this is.

<a name='T-ParquetClassLibrary-Maps-IMapRegionEdit'></a>
## IMapRegionEdit `type`

##### Namespace

ParquetClassLibrary.Maps

##### Summary

Facilitates editing of [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel') characteristics from design tools while maintaining a read-only face for use during play.

<a name='P-ParquetClassLibrary-Maps-IMapRegionEdit-BackgroundColor'></a>
### BackgroundColor `property`

##### Summary

A color to display in any empty areas of the region.

<a name='P-ParquetClassLibrary-Maps-IMapRegionEdit-RegionAboveID'></a>
### RegionAboveID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region above this one.

<a name='P-ParquetClassLibrary-Maps-IMapRegionEdit-RegionBelowID'></a>
### RegionBelowID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region below this one.

<a name='P-ParquetClassLibrary-Maps-IMapRegionEdit-RegionToTheEastID'></a>
### RegionToTheEastID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region to the east of this one.

<a name='P-ParquetClassLibrary-Maps-IMapRegionEdit-RegionToTheNorthID'></a>
### RegionToTheNorthID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region to the north of this one.

<a name='P-ParquetClassLibrary-Maps-IMapRegionEdit-RegionToTheSouthID'></a>
### RegionToTheSouthID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region to the south of this one.

<a name='P-ParquetClassLibrary-Maps-IMapRegionEdit-RegionToTheWestID'></a>
### RegionToTheWestID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region to the west of this one.

<a name='T-ParquetClassLibrary-IModelCollectionEdit`1'></a>
## IModelCollectionEdit\`1 `type`

##### Namespace

ParquetClassLibrary

##### Summary

Facilitates updating elements of a [ModelCollection](#T-ParquetClassLibrary-ModelCollection 'ParquetClassLibrary.ModelCollection') from design tools
while maintaining a read-only facade during play.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TModel | The type collected, typically a concrete decendent of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model'). |

<a name='M-ParquetClassLibrary-IModelCollectionEdit`1-Add-`0-'></a>
### Add(inModel) `method`

##### Summary

Adds the given `TModel` to the collection.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inModel | [\`0](#T-`0 '`0') | A valid, defined `TModel` contianed in this collection. |

<a name='M-ParquetClassLibrary-IModelCollectionEdit`1-Clear'></a>
### Clear() `method`

##### Summary

Empties the entire collection.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-IModelCollectionEdit`1-Remove-`0-'></a>
### Remove(inModel) `method`

##### Summary

Removes the given `TModel` from the collection.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inModel | [\`0](#T-`0 '`0') | A valid, defined `TModel` contianed in this collection. |

<a name='M-ParquetClassLibrary-IModelCollectionEdit`1-Remove-ParquetClassLibrary-ModelID-'></a>
### Remove(inID) `method`

##### Summary

Removes the `TModel` associated with the given [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') from the collection.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The ID for a valid, defined `TModel` contianed in this collection. |

<a name='M-ParquetClassLibrary-IModelCollectionEdit`1-Replace-`0-'></a>
### Replace(inModel) `method`

##### Summary

Replaces a contained `TModel` with the given `TModel` whose
[ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') is identicle to that of the model being replaced.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inModel | [\`0](#T-`0 '`0') | A valid, defined `TModel` contianed in this collection. |

<a name='T-ParquetClassLibrary-IModelEdit'></a>
## IModelEdit `type`

##### Namespace

ParquetClassLibrary

##### Summary

Facilitates editing of a [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') from design tools while maintaining a read-only face for use during play.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for use only by external types that require read/write access to model properties.

<a name='P-ParquetClassLibrary-IModelEdit-Comment'></a>
### Comment `property`

##### Summary

Optional comment.

##### Remarks

Could be used for designer's notes or to implement an in-game dialogue with or on the [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model').

<a name='P-ParquetClassLibrary-IModelEdit-Description'></a>
### Description `property`

##### Summary

Player-facing description.

<a name='P-ParquetClassLibrary-IModelEdit-ID'></a>
### ID `property`

##### Summary

Game-wide unique identifier.

##### Remarks

Be cautious editing this.

<a name='P-ParquetClassLibrary-IModelEdit-Name'></a>
### Name `property`

##### Summary

Player-facing name.

<a name='T-ParquetClassLibrary-Parquets-IParquetModelEdit'></a>
## IParquetModelEdit `type`

##### Namespace

ParquetClassLibrary.Parquets

##### Summary

Facilitates editing of a [ParquetModel](#T-ParquetClassLibrary-Parquets-ParquetModel 'ParquetClassLibrary.Parquets.ParquetModel') from design tools while maintaining a read-only face for use during play.

##### Remarks

By design, children of [ParquetModel](#T-ParquetClassLibrary-Parquets-ParquetModel 'ParquetClassLibrary.Parquets.ParquetModel') should never themselves use [IParquetModelEdit](#T-ParquetClassLibrary-Parquets-IParquetModelEdit 'ParquetClassLibrary.Parquets.IParquetModelEdit').
IParquetModelEdit is for use only by external types that require read/write access to model properties.

<a name='P-ParquetClassLibrary-Parquets-IParquetModelEdit-AddsToBiome'></a>
### AddsToBiome `property`

##### Summary

Describes the [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe')(s) that this parquet helps form.
Guaranteed to never be `null`.

<a name='P-ParquetClassLibrary-Parquets-IParquetModelEdit-AddsToRoom'></a>
### AddsToRoom `property`

##### Summary

A property of the parquet that can, for example, be used by [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe')s.
Guaranteed to never be `null`.

##### Remarks

Allows the creation of classes of constructs, for example "wooden", "golden", "rustic", or "fancy" rooms.

<a name='P-ParquetClassLibrary-Parquets-IParquetModelEdit-ItemID'></a>
### ItemID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel') awarded to the player when a character gathers or collects this parquet.

<a name='T-ParquetClassLibrary-Parquets-IParquetStack'></a>
## IParquetStack `type`

##### Namespace

ParquetClassLibrary.Parquets

##### Summary

Interface to a simple container for one of each layer of parquet occupying the same position.

##### Remarks

Supports injecting [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') into game-level methods that performs simple operations, such as rasterization.

<a name='P-ParquetClassLibrary-Parquets-IParquetStack-BlockID'></a>
### BlockID `property`

##### Summary

The block contained in this stack.

<a name='P-ParquetClassLibrary-Parquets-IParquetStack-CollectibleID'></a>
### CollectibleID `property`

##### Summary

The collectible contained in this stack.

<a name='P-ParquetClassLibrary-Parquets-IParquetStack-FloorID'></a>
### FloorID `property`

##### Summary

The floor contained in this stack.

<a name='P-ParquetClassLibrary-Parquets-IParquetStack-FurnishingID'></a>
### FurnishingID `property`

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

<a name='T-ParquetClassLibrary-Rooms-IRoomRecipeEdit'></a>
## IRoomRecipeEdit `type`

##### Namespace

ParquetClassLibrary.Rooms

##### Summary

Facilitates editing of a [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe') from design tools while maintaining a read-only face for use during play.

##### Remarks

By design, children of [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe') should never themselves use [IRoomRecipeEdit](#T-ParquetClassLibrary-Rooms-IRoomRecipeEdit 'ParquetClassLibrary.Rooms.IRoomRecipeEdit').
IRoomRecipeEdit is for use only by external types that require read/write access to model properties.

<a name='P-ParquetClassLibrary-Rooms-IRoomRecipeEdit-MinimumWalkableSpaces'></a>
### MinimumWalkableSpaces `property`

##### Summary

Minimum number of open spaces needed for this [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe') to register.

<a name='P-ParquetClassLibrary-Rooms-IRoomRecipeEdit-OptionallyRequiredFurnishings'></a>
### OptionallyRequiredFurnishings `property`

##### Summary

A list of [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') categories this [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe') requires.

<a name='P-ParquetClassLibrary-Rooms-IRoomRecipeEdit-OptionallyRequiredPerimeterBlocks'></a>
### OptionallyRequiredPerimeterBlocks `property`

##### Summary

An optional list of [BlockModel](#T-ParquetClassLibrary-Parquets-BlockModel 'ParquetClassLibrary.Parquets.BlockModel') categories this [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe') requires as walls.

<a name='P-ParquetClassLibrary-Rooms-IRoomRecipeEdit-OptionallyRequiredWalkableFloors'></a>
### OptionallyRequiredWalkableFloors `property`

##### Summary

An optional list of [FloorModel](#T-ParquetClassLibrary-Parquets-FloorModel 'ParquetClassLibrary.Parquets.FloorModel') categories this [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe') requires.

<a name='T-ParquetClassLibrary-Scripts-IScriptModelEdit'></a>
## IScriptModelEdit `type`

##### Namespace

ParquetClassLibrary.Scripts

##### Summary

Facilitates editing of a [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel') from design tools while maintaining a read-only face for use during play.

##### Remarks

By design, children of [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel') should never themselves use [IScriptModelEdit](#T-ParquetClassLibrary-Scripts-IScriptModelEdit 'ParquetClassLibrary.Scripts.IScriptModelEdit').
IScriptModelEdit is for use only by external types that require read/write access to model properties.

<a name='P-ParquetClassLibrary-Scripts-IScriptModelEdit-Nodes'></a>
### Nodes `property`

##### Summary

A series of imperative, procedural commands.

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
### #ctor(inID,inName,inDescription,inComment,inPrerequisitesIDs,inStepsIDs,inOutcomesIDs) `constructor`

##### Summary

Initializes a new instance of the [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | Unique identifier for the [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel').  Cannot be null. |
| inName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly name of the [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel').  Cannot be null or empty. |
| inDescription | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly description of the [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel'). |
| inComment | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Comment of, on, or by the [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel'). |
| inPrerequisitesIDs | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}') | Describes the criteria for beginning this [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel'). |
| inStepsIDs | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}') | Describes the criteria for completing this [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel'). |
| inOutcomesIDs | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelID}') | Describes the results of finishing this [InteractionModel](#T-ParquetClassLibrary-Scripts-InteractionModel 'ParquetClassLibrary.Scripts.InteractionModel'). |

<a name='P-ParquetClassLibrary-Scripts-InteractionModel-OutcomesIDs'></a>
### OutcomesIDs `property`

##### Summary

Describes the results of finishing this interaction.

<a name='P-ParquetClassLibrary-Scripts-InteractionModel-ParquetClassLibrary#Scripts#IInteractionModelEdit#OutcomesIDs'></a>
### ParquetClassLibrary#Scripts#IInteractionModelEdit#OutcomesIDs `property`

##### Summary

Describes the results of finishing this interaction.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Scripts-InteractionModel-ParquetClassLibrary#Scripts#IInteractionModelEdit#PrerequisitesIDs'></a>
### ParquetClassLibrary#Scripts#IInteractionModelEdit#PrerequisitesIDs `property`

##### Summary

Describes the criteria for begining this interaction.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Scripts-InteractionModel-ParquetClassLibrary#Scripts#IInteractionModelEdit#StepsIDs'></a>
### ParquetClassLibrary#Scripts#IInteractionModelEdit#StepsIDs `property`

##### Summary

Everything this interaction entails.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Scripts-InteractionModel-PrerequisitesIDs'></a>
### PrerequisitesIDs `property`

##### Summary

Describes the criteria for begining this interaction.

<a name='P-ParquetClassLibrary-Scripts-InteractionModel-StepsIDs'></a>
### StepsIDs `property`

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
| inProgramCounter | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Index to the current [ScriptNode](#T-ParquetClassLibrary-Scripts-ScriptNode 'ParquetClassLibrary.Scripts.ScriptNode') in the tracked [StepsIDs](#P-ParquetClassLibrary-Scripts-InteractionModel-StepsIDs 'ParquetClassLibrary.Scripts.InteractionModel.StepsIDs'). |

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

<a name='M-ParquetClassLibrary-Items-ItemModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,ParquetClassLibrary-Items-ItemType,System-Int32,System-Int32,System-Int32,System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag}-'></a>
### #ctor(inID,inName,inDescription,inComment,inSubtype,inPrice,inRarity,inStackMax,inEffectWhileHeldID,inEffectWhenUsedID,inParquetID,inItemTags) `constructor`

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
| inEffectWhileHeldID | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel')'s passive effect. |
| inEffectWhenUsedID | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel')'s active effect. |
| inParquetID | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | The parquet represented, if any. |
| inItemTags | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}') | Any additional functionality this item has, e.g. contributing to a [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe'). |

<a name='F-ParquetClassLibrary-Items-ItemModel-DefaultStackMax'></a>
### DefaultStackMax `constants`

##### Summary

Stack maximum assumed when none is defined.

<a name='P-ParquetClassLibrary-Items-ItemModel-EffectWhenUsedID'></a>
### EffectWhenUsedID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel') generating the in-game effect caused by
using (consuming) the item.

<a name='P-ParquetClassLibrary-Items-ItemModel-EffectWhileHeldID'></a>
### EffectWhileHeldID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel') generating the in-game effect caused by
keeping the item in a [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel')'s [Inventory](#T-ParquetClassLibrary-Items-Inventory 'ParquetClassLibrary.Items.Inventory').

<a name='P-ParquetClassLibrary-Items-ItemModel-ItemTags'></a>
### ItemTags `property`

##### Summary

Any additional functionality this item has, e.g. contributing to a [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe').

<a name='P-ParquetClassLibrary-Items-ItemModel-ParquetClassLibrary#Items#IItemModelEdit#EffectWhenUsedID'></a>
### ParquetClassLibrary#Items#IItemModelEdit#EffectWhenUsedID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel') generating the in-game effect caused by
using (consuming) the item.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require readwrite access.

<a name='P-ParquetClassLibrary-Items-ItemModel-ParquetClassLibrary#Items#IItemModelEdit#EffectWhileHeldID'></a>
### ParquetClassLibrary#Items#IItemModelEdit#EffectWhileHeldID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel') generating the in-game effect caused by
keeping the item in a [CharacterModel](#T-ParquetClassLibrary-Beings-CharacterModel 'ParquetClassLibrary.Beings.CharacterModel')'s [Inventory](#T-ParquetClassLibrary-Items-Inventory 'ParquetClassLibrary.Items.Inventory').

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require readwrite access.

<a name='P-ParquetClassLibrary-Items-ItemModel-ParquetClassLibrary#Items#IItemModelEdit#ItemTags'></a>
### ParquetClassLibrary#Items#IItemModelEdit#ItemTags `property`

##### Summary

Any additional functionality this item has, e.g. contributing to a [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe').

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require readwrite access.

<a name='P-ParquetClassLibrary-Items-ItemModel-ParquetClassLibrary#Items#IItemModelEdit#ParquetID'></a>
### ParquetClassLibrary#Items#IItemModelEdit#ParquetID `property`

##### Summary

The parquet that corresponds to this item, if any.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require readwrite access.

<a name='P-ParquetClassLibrary-Items-ItemModel-ParquetClassLibrary#Items#IItemModelEdit#Price'></a>
### ParquetClassLibrary#Items#IItemModelEdit#Price `property`

##### Summary

In-game value of the item.  Must be non-negative.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require readwrite access.

<a name='P-ParquetClassLibrary-Items-ItemModel-ParquetClassLibrary#Items#IItemModelEdit#Rarity'></a>
### ParquetClassLibrary#Items#IItemModelEdit#Rarity `property`

##### Summary

How relatively rare this item is.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require readwrite access.

<a name='P-ParquetClassLibrary-Items-ItemModel-ParquetClassLibrary#Items#IItemModelEdit#StackMax'></a>
### ParquetClassLibrary#Items#IItemModelEdit#StackMax `property`

##### Summary

How many of the item may share a single inventory slot.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require readwrite access.

<a name='P-ParquetClassLibrary-Items-ItemModel-ParquetClassLibrary#Items#IItemModelEdit#Subtype'></a>
### ParquetClassLibrary#Items#IItemModelEdit#Subtype `property`

##### Summary

The type of item this is.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require readwrite access.

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

Represents a specific position within a specific [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel').

##### Remarks

While primarily used in-library by [BeingModel](#T-ParquetClassLibrary-Beings-BeingModel 'ParquetClassLibrary.Beings.BeingModel') this class
is made generally available to support it's general use by game client code.

<a name='P-ParquetClassLibrary-Location-Position'></a>
### Position `property`

##### Summary

The position within the current [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel') of this located.

<a name='P-ParquetClassLibrary-Location-RegionID'></a>
### RegionID `property`

##### Summary

The identifier for the [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel') of this located.

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

<a name='T-ParquetClassLibrary-Maps-MapAnalysis'></a>
## MapAnalysis `type`

##### Namespace

ParquetClassLibrary.Maps

##### Summary

Provides optional analysis for compatible [MapModel](#T-ParquetClassLibrary-Maps-MapModel 'ParquetClassLibrary.Maps.MapModel')s.

<a name='M-ParquetClassLibrary-Maps-MapAnalysis-CheckExitConsistency``1-ParquetClassLibrary-ModelID-'></a>
### CheckExitConsistency\`\`1(inRegionID) `method`

##### Summary

Finds adjacent maps from which the given map is not adjacent in the expected direction.

 That is, if the player leaves Region 1 by going North and cannot then return to Region 1 by going south,
 that is considered inconsistent and will be reported.

##### Returns

A report of all exit directions leading to regions whose own exits are inconsistent.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inRegionID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the origination and destination map. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TMapType | A type derived from [MapModel](#T-ParquetClassLibrary-Maps-MapModel 'ParquetClassLibrary.Maps.MapModel') that implements [IMapRegionEdit](#T-ParquetClassLibrary-Maps-IMapRegionEdit 'ParquetClassLibrary.Maps.IMapRegionEdit'). |

<a name='T-ParquetClassLibrary-Maps-MapAnalysis`1'></a>
## MapAnalysis\`1 `type`

##### Namespace

ParquetClassLibrary.Maps

##### Summary

Provides optional analysis for compatible [MapModel](#T-ParquetClassLibrary-Maps-MapModel 'ParquetClassLibrary.Maps.MapModel')s.

<a name='F-ParquetClassLibrary-Maps-MapAnalysis`1-Directions'></a>
### Directions `constants`

##### Summary

A database of directions and their opposites, together with the properties needed to inspect both.

<a name='T-ParquetClassLibrary-Maps-MapChunkModel'></a>
## MapChunkModel `type`

##### Namespace

ParquetClassLibrary.Maps

##### Summary

Models details of a portion of a [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel'),
either directly composed of parquets or generated from [ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail')s.

##### Remarks

For more information, read the remarks given in [MapRegionSketch](#T-ParquetClassLibrary-Maps-MapRegionSketch 'ParquetClassLibrary.Maps.MapRegionSketch').

<a name='M-ParquetClassLibrary-Maps-MapChunkModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Int32,System-Boolean,ParquetClassLibrary-Maps-ChunkDetail,ParquetClassLibrary-Parquets-ParquetStackGrid-'></a>
### #ctor(inID,inName,inDescription,inComment,inRevision,inIsFilledOut,inDetails,inParquetDefinitions) `constructor`

##### Summary

Used by children of the [MapModel](#T-ParquetClassLibrary-Maps-MapModel 'ParquetClassLibrary.Maps.MapModel') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | Unique identifier for the map.  Cannot be null. |
| inName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly name of the map.  Cannot be null or empty. |
| inDescription | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly description of the map. |
| inComment | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Comment of, on, or by the map. |
| inRevision | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | An option revision count. |
| inIsFilledOut | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If `true`, the [MapChunkModel](#T-ParquetClassLibrary-Maps-MapChunkModel 'ParquetClassLibrary.Maps.MapChunkModel') was either created at design time or
has already been procedurally generated on load in-game. |
| inDetails | [ParquetClassLibrary.Maps.ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail') | Cues to the generation routines if generated at runtime. |
| inParquetDefinitions | [ParquetClassLibrary.Parquets.ParquetStackGrid](#T-ParquetClassLibrary-Parquets-ParquetStackGrid 'ParquetClassLibrary.Parquets.ParquetStackGrid') | The definitions of the collected parquets if designed by hand. |

<a name='F-ParquetClassLibrary-Maps-MapChunkModel-ParquetsPerChunkDimension'></a>
### ParquetsPerChunkDimension `constants`

##### Summary

The length of each [MapChunkModel](#T-ParquetClassLibrary-Maps-MapChunkModel 'ParquetClassLibrary.Maps.MapChunkModel') dimension in parquets.

<a name='P-ParquetClassLibrary-Maps-MapChunkModel-Bounds'></a>
### Bounds `property`

##### Summary

The set of values that are allowed for [MapChunkModel](#T-ParquetClassLibrary-Maps-MapChunkModel 'ParquetClassLibrary.Maps.MapChunkModel')[ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s.

<a name='P-ParquetClassLibrary-Maps-MapChunkModel-Details'></a>
### Details `property`

##### Summary

A description of the type and arrangement of parquets to generate at runtime.

<a name='P-ParquetClassLibrary-Maps-MapChunkModel-DimensionsInParquets'></a>
### DimensionsInParquets `property`

##### Summary

The chunk's dimensions in parquets.

<a name='P-ParquetClassLibrary-Maps-MapChunkModel-Empty'></a>
### Empty `property`

##### Summary

Used to indicate an empty grid.

<a name='P-ParquetClassLibrary-Maps-MapChunkModel-IsFilledOut'></a>
### IsFilledOut `property`

##### Summary

If `true`, the [MapChunkModel](#T-ParquetClassLibrary-Maps-MapChunkModel 'ParquetClassLibrary.Maps.MapChunkModel') is created at design time instead of procedurally generated.

<a name='P-ParquetClassLibrary-Maps-MapChunkModel-ParquetDefinitions'></a>
### ParquetDefinitions `property`

##### Summary

Floors and walkable terrain in the chunk.

<a name='M-ParquetClassLibrary-Maps-MapChunkModel-Generate'></a>
### Generate() `method`

##### Summary

Transforms the current [MapChunkModel](#T-ParquetClassLibrary-Maps-MapChunkModel 'ParquetClassLibrary.Maps.MapChunkModel') so that it is ready to be stitched together
with others in its [MapRegionSketch](#T-ParquetClassLibrary-Maps-MapRegionSketch 'ParquetClassLibrary.Maps.MapRegionSketch') into a playable [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel').

##### Returns

The generated [MapChunkModel](#T-ParquetClassLibrary-Maps-MapChunkModel 'ParquetClassLibrary.Maps.MapChunkModel').

##### Parameters

This method has no parameters.

##### Remarks

If a chunk [IsFilledOut](#P-ParquetClassLibrary-Maps-MapChunkModel-IsFilledOut 'ParquetClassLibrary.Maps.MapChunkModel.IsFilledOut'), it is ready to go.
Chunks that are not handmade at design time need to undergo procedural generation based on their [ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail')s.

<a name='M-ParquetClassLibrary-Maps-MapChunkModel-ToString'></a>
### ToString() `method`

##### Summary

Describes the [MapChunkModel](#T-ParquetClassLibrary-Maps-MapChunkModel 'ParquetClassLibrary.Maps.MapChunkModel') as a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing basic information.

##### Returns

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents the current [MapChunkModel](#T-ParquetClassLibrary-Maps-MapChunkModel 'ParquetClassLibrary.Maps.MapChunkModel').

##### Parameters

This method has no parameters.

<a name='T-ParquetClassLibrary-Maps-MapModel'></a>
## MapModel `type`

##### Namespace

ParquetClassLibrary.Maps

##### Summary

Provides methods that are used by all map models.

<a name='M-ParquetClassLibrary-Maps-MapModel-#ctor-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Int32-'></a>
### #ctor(inBounds,inID,inName,inDescription,inComment,inRevision) `constructor`

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
| inRevision | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | How many times this map has been serialized. |

<a name='P-ParquetClassLibrary-Maps-MapModel-DimensionsInParquets'></a>
### DimensionsInParquets `property`

##### Summary

Dimensions in parquets.  Defined by child classes.

<a name='P-ParquetClassLibrary-Maps-MapModel-ParquetDefinitions'></a>
### ParquetDefinitions `property`

##### Summary

Definitions for every [FloorModel](#T-ParquetClassLibrary-Parquets-FloorModel 'ParquetClassLibrary.Parquets.FloorModel'), [BlockModel](#T-ParquetClassLibrary-Parquets-BlockModel 'ParquetClassLibrary.Parquets.BlockModel'), [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel'),
and [CollectibleModel](#T-ParquetClassLibrary-Parquets-CollectibleModel 'ParquetClassLibrary.Parquets.CollectibleModel') that makes up this part of the game world.

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

<a name='T-ParquetClassLibrary-Maps-MapRegionModel'></a>
## MapRegionModel `type`

##### Namespace

ParquetClassLibrary.Maps

##### Summary

A playable region of the gameworld, composed of parquets.

<a name='M-ParquetClassLibrary-Maps-MapRegionModel-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Int32,System-String,System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID},ParquetClassLibrary-Parquets-ParquetStatusGrid,ParquetClassLibrary-Parquets-ParquetStackGrid-'></a>
### #ctor(inID,inName,inDescription,inComment,inRevision,inBackgroundColor,inRegionToTheNorth,inRegionToTheEast,inRegionToTheSouth,inRegionToTheWest,inRegionAbove,inRegionBelow,inParquetStatuses,inParquetDefinitions) `constructor`

##### Summary

Constructs a new instance of the [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | Unique identifier for the map.  Cannot be null. |
| inName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The player-facing name of the new region. |
| inDescription | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly description of the map. |
| inComment | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Comment of, on, or by the map. |
| inRevision | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | An option revision count. |
| inBackgroundColor | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A color to show in the new region when no parquet is present. |
| inRegionToTheNorth | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region to the north of this one. |
| inRegionToTheEast | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region to the east of this one. |
| inRegionToTheSouth | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region to the south of this one. |
| inRegionToTheWest | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region to the west of this one. |
| inRegionAbove | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region above this one. |
| inRegionBelow | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region below this one. |
| inParquetStatuses | [ParquetClassLibrary.Parquets.ParquetStatusGrid](#T-ParquetClassLibrary-Parquets-ParquetStatusGrid 'ParquetClassLibrary.Parquets.ParquetStatusGrid') | The statuses of the collected parquets. |
| inParquetDefinitions | [ParquetClassLibrary.Parquets.ParquetStackGrid](#T-ParquetClassLibrary-Parquets-ParquetStackGrid 'ParquetClassLibrary.Parquets.ParquetStackGrid') | The definitions of the collected parquets. |

<a name='F-ParquetClassLibrary-Maps-MapRegionModel-DefaultColor'></a>
### DefaultColor `constants`

##### Summary

Default color for new regions.

<a name='F-ParquetClassLibrary-Maps-MapRegionModel-Empty'></a>
### Empty `constants`

##### Summary

Used to indicate an empty grid.

<a name='F-ParquetClassLibrary-Maps-MapRegionModel-ParquetsPerRegionDimension'></a>
### ParquetsPerRegionDimension `constants`

##### Summary

The length of each [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel') dimension in parquets.

<a name='P-ParquetClassLibrary-Maps-MapRegionModel-BackgroundColor'></a>
### BackgroundColor `property`

##### Summary

A color to display in any empty areas of the region.

<a name='P-ParquetClassLibrary-Maps-MapRegionModel-Bounds'></a>
### Bounds `property`

##### Summary

The set of values that are allowed for [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel')[ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s.

<a name='P-ParquetClassLibrary-Maps-MapRegionModel-DimensionsInParquets'></a>
### DimensionsInParquets `property`

##### Summary

The region's dimensions in parquets.

<a name='P-ParquetClassLibrary-Maps-MapRegionModel-ParquetClassLibrary#IModelEdit#Name'></a>
### ParquetClassLibrary#IModelEdit#Name `property`

##### Summary

What the region is called in-game.

<a name='P-ParquetClassLibrary-Maps-MapRegionModel-ParquetClassLibrary#Maps#IMapRegionEdit#BackgroundColor'></a>
### ParquetClassLibrary#Maps#IMapRegionEdit#BackgroundColor `property`

##### Summary

A color to display in any empty areas of the region.

<a name='P-ParquetClassLibrary-Maps-MapRegionModel-ParquetClassLibrary#Maps#IMapRegionEdit#RegionAboveID'></a>
### ParquetClassLibrary#Maps#IMapRegionEdit#RegionAboveID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region above this one.

<a name='P-ParquetClassLibrary-Maps-MapRegionModel-ParquetClassLibrary#Maps#IMapRegionEdit#RegionBelowID'></a>
### ParquetClassLibrary#Maps#IMapRegionEdit#RegionBelowID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region below this one.

<a name='P-ParquetClassLibrary-Maps-MapRegionModel-ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheEastID'></a>
### ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheEastID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region to the east of this one.

<a name='P-ParquetClassLibrary-Maps-MapRegionModel-ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheNorthID'></a>
### ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheNorthID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region to the north of this one.

<a name='P-ParquetClassLibrary-Maps-MapRegionModel-ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheSouthID'></a>
### ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheSouthID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region to the south of this one.

<a name='P-ParquetClassLibrary-Maps-MapRegionModel-ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheWestID'></a>
### ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheWestID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region to the west of this one.

<a name='P-ParquetClassLibrary-Maps-MapRegionModel-ParquetDefinitions'></a>
### ParquetDefinitions `property`

##### Summary

Parquets that make up the region.  If changing or replacing one of these,
remember to update the corresponding element in [ParquetStatuses](#P-ParquetClassLibrary-Maps-MapRegionModel-ParquetStatuses 'ParquetClassLibrary.Maps.MapRegionModel.ParquetStatuses')!

<a name='P-ParquetClassLibrary-Maps-MapRegionModel-ParquetStatuses'></a>
### ParquetStatuses `property`

##### Summary

The statuses of parquets in the chunk.

<a name='P-ParquetClassLibrary-Maps-MapRegionModel-RegionAbove'></a>
### RegionAbove `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region above this one.

<a name='P-ParquetClassLibrary-Maps-MapRegionModel-RegionBelow'></a>
### RegionBelow `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region below this one.

<a name='P-ParquetClassLibrary-Maps-MapRegionModel-RegionToTheEast'></a>
### RegionToTheEast `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region to the east of this one.

<a name='P-ParquetClassLibrary-Maps-MapRegionModel-RegionToTheNorth'></a>
### RegionToTheNorth `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region to the north of this one.

<a name='P-ParquetClassLibrary-Maps-MapRegionModel-RegionToTheSouth'></a>
### RegionToTheSouth `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region to the south of this one.

<a name='P-ParquetClassLibrary-Maps-MapRegionModel-RegionToTheWest'></a>
### RegionToTheWest `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region to the west of this one.

<a name='P-ParquetClassLibrary-Maps-MapRegionModel-Rooms'></a>
### Rooms `property`

##### Summary

All of the [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room')s detected in the [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel').

<a name='M-ParquetClassLibrary-Maps-MapRegionModel-GetBiome'></a>
### GetBiome() `method`

##### Summary

Determines which [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe') the given [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel') corresponds to.

##### Returns

The appropriate [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID').

##### Parameters

This method has no parameters.

##### Remarks

This method assumes that [Rooms](#P-ParquetClassLibrary-Maps-MapRegionModel-Rooms 'ParquetClassLibrary.Maps.MapRegionModel.Rooms') has already been populated.

<a name='M-ParquetClassLibrary-Maps-MapRegionModel-ToString'></a>
### ToString() `method`

##### Summary

Describes the [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel').

##### Returns

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that represents the current [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel').

##### Parameters

This method has no parameters.

<a name='T-ParquetClassLibrary-Maps-MapRegionSketch'></a>
## MapRegionSketch `type`

##### Namespace

ParquetClassLibrary.Maps

##### Summary

A pattern and metadata to generate a [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel').

##### Remarks

Before play begins, [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel')s may be stored as [MapRegionSketch](#T-ParquetClassLibrary-Maps-MapRegionSketch 'ParquetClassLibrary.Maps.MapRegionSketch')es, for example in an editor tool.

 MapRegionSketches allow additional flexibility, primarily by way of allowing map subsections to be represented not as actual
 collection of parquets, but instead as [MapChunkModel](#T-ParquetClassLibrary-Maps-MapChunkModel 'ParquetClassLibrary.Maps.MapChunkModel')s, instructions to procedural generation routines.  These
 instructions can be used by the library when the MapRegionSketch is loaded for the first time to generate actual parquets
 for the map.  In this way portions of the game world will be different every time the game is played, while still corresponding
 to some general layout instructions provided by the game's designers.
 
 The [Stitch](#M-ParquetClassLibrary-Maps-MapRegionSketch-Stitch 'ParquetClassLibrary.Maps.MapRegionSketch.Stitch') method accomplishes this, forming a composite whole from generated parts.

<a name='M-ParquetClassLibrary-Maps-MapRegionSketch-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Int32,System-String,System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID},System-Nullable{ParquetClassLibrary-ModelID},ParquetClassLibrary-ModelIDGrid-'></a>
### #ctor(inID,inName,inDescription,inComment,inRevision,inBackgroundColor,inRegionToTheNorth,inRegionToTheEast,inRegionToTheSouth,inRegionToTheWest,inRegionAbove,inRegionBelow,inChunks) `constructor`

##### Summary

Constructs a new instance of the [MapRegionSketch](#T-ParquetClassLibrary-Maps-MapRegionSketch 'ParquetClassLibrary.Maps.MapRegionSketch') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | Unique identifier for the map.  Cannot be null. |
| inName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The player-facing name of the new region. |
| inDescription | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Player-friendly description of the map. |
| inComment | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Comment of, on, or by the map. |
| inRevision | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | An option revision count. |
| inBackgroundColor | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A color to show in the new region when no parquet is present. |
| inRegionToTheNorth | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region to the north of this one. |
| inRegionToTheEast | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region to the east of this one. |
| inRegionToTheSouth | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region to the south of this one. |
| inRegionToTheWest | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region to the west of this one. |
| inRegionAbove | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region above this one. |
| inRegionBelow | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region below this one. |
| inChunks | [ParquetClassLibrary.ModelIDGrid](#T-ParquetClassLibrary-ModelIDGrid 'ParquetClassLibrary.ModelIDGrid') | The pattern from which a [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel') may be generated. |

<a name='F-ParquetClassLibrary-Maps-MapRegionSketch-ChunksPerRegionDimension'></a>
### ChunksPerRegionDimension `constants`

##### Summary

The length of each [MapRegionSketch](#T-ParquetClassLibrary-Maps-MapRegionSketch 'ParquetClassLibrary.Maps.MapRegionSketch') dimension in [MapChunkModel](#T-ParquetClassLibrary-Maps-MapChunkModel 'ParquetClassLibrary.Maps.MapChunkModel')s.

<a name='F-ParquetClassLibrary-Maps-MapRegionSketch-DefaultColor'></a>
### DefaultColor `constants`

##### Summary

Default color for new regions.

<a name='F-ParquetClassLibrary-Maps-MapRegionSketch-Empty'></a>
### Empty `constants`

##### Summary

Used to indicate a blank sketch.

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

[ChunkDetail](#T-ParquetClassLibrary-Maps-ChunkDetail 'ParquetClassLibrary.Maps.ChunkDetail')s that can generate parquets to compose a [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel').

<a name='P-ParquetClassLibrary-Maps-MapRegionSketch-DimensionsInChunks'></a>
### DimensionsInChunks `property`

##### Summary

The grid's dimensions in chunks.

<a name='P-ParquetClassLibrary-Maps-MapRegionSketch-DimensionsInParquets'></a>
### DimensionsInParquets `property`

##### Summary

The region's dimensions in parquets.

<a name='P-ParquetClassLibrary-Maps-MapRegionSketch-ParquetClassLibrary#IModelEdit#Name'></a>
### ParquetClassLibrary#IModelEdit#Name `property`

##### Summary

What the region is called in-game.

<a name='P-ParquetClassLibrary-Maps-MapRegionSketch-ParquetClassLibrary#Maps#IMapRegionEdit#BackgroundColor'></a>
### ParquetClassLibrary#Maps#IMapRegionEdit#BackgroundColor `property`

##### Summary

A color to display in any empty areas of the region.

<a name='P-ParquetClassLibrary-Maps-MapRegionSketch-ParquetClassLibrary#Maps#IMapRegionEdit#RegionAboveID'></a>
### ParquetClassLibrary#Maps#IMapRegionEdit#RegionAboveID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region above this one.

<a name='P-ParquetClassLibrary-Maps-MapRegionSketch-ParquetClassLibrary#Maps#IMapRegionEdit#RegionBelowID'></a>
### ParquetClassLibrary#Maps#IMapRegionEdit#RegionBelowID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel') below this one.

<a name='P-ParquetClassLibrary-Maps-MapRegionSketch-ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheEastID'></a>
### ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheEastID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region to the east of this one.

<a name='P-ParquetClassLibrary-Maps-MapRegionSketch-ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheNorthID'></a>
### ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheNorthID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region to the north of this one.

<a name='P-ParquetClassLibrary-Maps-MapRegionSketch-ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheSouthID'></a>
### ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheSouthID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region to the south of this one.

<a name='P-ParquetClassLibrary-Maps-MapRegionSketch-ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheWestID'></a>
### ParquetClassLibrary#Maps#IMapRegionEdit#RegionToTheWestID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region to the west of this one.

<a name='P-ParquetClassLibrary-Maps-MapRegionSketch-ParquetDefinitions'></a>
### ParquetDefinitions `property`

##### Summary

Generate a [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel') before accessing parquets.

<a name='P-ParquetClassLibrary-Maps-MapRegionSketch-RegionAbove'></a>
### RegionAbove `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region above this one.

<a name='P-ParquetClassLibrary-Maps-MapRegionSketch-RegionBelow'></a>
### RegionBelow `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel') below this one.

<a name='P-ParquetClassLibrary-Maps-MapRegionSketch-RegionToTheEast'></a>
### RegionToTheEast `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region to the east of this one.

<a name='P-ParquetClassLibrary-Maps-MapRegionSketch-RegionToTheNorth'></a>
### RegionToTheNorth `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region to the north of this one.

<a name='P-ParquetClassLibrary-Maps-MapRegionSketch-RegionToTheSouth'></a>
### RegionToTheSouth `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region to the south of this one.

<a name='P-ParquetClassLibrary-Maps-MapRegionSketch-RegionToTheWest'></a>
### RegionToTheWest `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the region to the west of this one.

<a name='M-ParquetClassLibrary-Maps-MapRegionSketch-Stitch'></a>
### Stitch() `method`

##### Summary

Combines all consituent [MapChunkModel](#T-ParquetClassLibrary-Maps-MapChunkModel 'ParquetClassLibrary.Maps.MapChunkModel')s to produce a playable [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel').

##### Returns

The new [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel').

##### Parameters

This method has no parameters.

##### Remarks

Invokes procedural generation routines on any [MapChunkModel](#T-ParquetClassLibrary-Maps-MapChunkModel 'ParquetClassLibrary.Maps.MapChunkModel')s that need it.

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

A [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') together with its coordinates within a given [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel').

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
2, It has a [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') that is [Entry](#P-ParquetClassLibrary-Parquets-FurnishingModel-Entry 'ParquetClassLibrary.Parquets.FurnishingModel.Entry').

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

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Model-ParquetClassLibrary#IModelEdit#Description'></a>
### ParquetClassLibrary#IModelEdit#Description `property`

##### Summary

Player-facing description.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Model-ParquetClassLibrary#IModelEdit#ID'></a>
### ParquetClassLibrary#IModelEdit#ID `property`

##### Summary

Game-wide unique identifier.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
 IModelEdit is for external types that require read/write access.

 Be especially cautious editing this property.

<a name='P-ParquetClassLibrary-Model-ParquetClassLibrary#IModelEdit#Name'></a>
### ParquetClassLibrary#IModelEdit#Name `property`

##### Summary

Player-facing name.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require read/write access.

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

Given a type, returns the filename and path associated with that type's definition file.

##### Returns

A full path to the associated file.

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
| TModel | The type collected, typically a concrete decendent of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model'). |

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

<a name='P-ParquetClassLibrary-ModelCollection`1-EditableModels'></a>
### EditableModels `property`

##### Summary

An editable facade onto the internal collection mechanism.

##### Remarks

Should only be accessed from constructor and [IModelCollectionEdit\`1](#T-ParquetClassLibrary-IModelCollectionEdit`1 'ParquetClassLibrary.IModelCollectionEdit`1').

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

<a name='M-ParquetClassLibrary-ModelCollection`1-ParquetClassLibrary#IModelCollectionEdit{TModel}#Add-`0-'></a>
### ParquetClassLibrary#IModelCollectionEdit{TModel}#Add(inModel) `method`

##### Summary

Adds the given `TModel` to the collection.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inModel | [\`0](#T-`0 '`0') | A valid, defined `TModel` contianed in this collection. |

<a name='M-ParquetClassLibrary-ModelCollection`1-ParquetClassLibrary#IModelCollectionEdit{TModel}#Clear'></a>
### ParquetClassLibrary#IModelCollectionEdit{TModel}#Clear() `method`

##### Summary

Empties the entire collection.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-ModelCollection`1-ParquetClassLibrary#IModelCollectionEdit{TModel}#Remove-`0-'></a>
### ParquetClassLibrary#IModelCollectionEdit{TModel}#Remove(inModel) `method`

##### Summary

Removes the given `TModel` from the collection.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inModel | [\`0](#T-`0 '`0') | A valid, defined `TModel` contianed in this collection. |

<a name='M-ParquetClassLibrary-ModelCollection`1-ParquetClassLibrary#IModelCollectionEdit{TModel}#Remove-ParquetClassLibrary-ModelID-'></a>
### ParquetClassLibrary#IModelCollectionEdit{TModel}#Remove(inID) `method`

##### Summary

Removes the `TModel` associated with the given [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') from the collection.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inID | [ParquetClassLibrary.ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') | The ID for a valid, defined `TModel` contianed in this collection. |

<a name='M-ParquetClassLibrary-ModelCollection`1-ParquetClassLibrary#IModelCollectionEdit{TModel}#Replace-`0-'></a>
### ParquetClassLibrary#IModelCollectionEdit{TModel}#Replace(inModel) `method`

##### Summary

Replaces a contained `TModel` with the given `TModel` whose
[ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') is identicle to that of the model being replaced.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inModel | [\`0](#T-`0 '`0') | A valid, defined `TModel` contianed in this collection. |

##### Remarks

Facilitates updating elements from design tools while maintaining a read-only facade during play.

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
to [MapChunkModel](#T-ParquetClassLibrary-Maps-MapChunkModel 'ParquetClassLibrary.Maps.MapChunkModel')s or [MapRegionModel](#T-ParquetClassLibrary-Maps-MapRegionModel 'ParquetClassLibrary.Maps.MapRegionModel')s,
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

<a name='T-ParquetClassLibrary-ModelIDExtensions'></a>
## ModelIDExtensions `type`

##### Namespace

ParquetClassLibrary

##### Summary

Convenience extension methods for concise coding when working with [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') instances.

<a name='M-ParquetClassLibrary-ModelIDExtensions-IsValidPosition-ParquetClassLibrary-ModelID[0-,0-],ParquetClassLibrary-Vector2D-'></a>
### IsValidPosition(inIDArray,inPosition) `method`

##### Summary

Determines if the given position corresponds to a point within the current array.

##### Returns

`true`, if the position is valid, `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inIDArray | [ParquetClassLibrary.ModelID[0:](#T-ParquetClassLibrary-ModelID[0- 'ParquetClassLibrary.ModelID[0:') | The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') array to validate against. |
| inPosition | [0:]](#T-0-] '0:]') | The position to validate. |

<a name='T-ParquetClassLibrary-ModelIDGrid'></a>
## ModelIDGrid `type`

##### Namespace

ParquetClassLibrary

##### Summary

A square, two-dimensional collection of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s for use in [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s.

<a name='M-ParquetClassLibrary-ModelIDGrid-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes an empty [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') with unusable dimensions.

##### Parameters

This constructor has no parameters.

##### Remarks

For this class, there are no reasonable default values.
 However, this version of the constructor exists to make the generic new() constraint happy
 and is used in the library in a context where its limitations are understood.
 You probably don't want to use this constructor in your own code.

<a name='M-ParquetClassLibrary-ModelIDGrid-#ctor-System-Int32,System-Int32-'></a>
### #ctor(inRowCount,inColumnCount) `constructor`

##### Summary

Initializes a new [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inRowCount | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The length of the Y dimension of the collection. |
| inColumnCount | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The length of the X dimension of the collection. |

<a name='P-ParquetClassLibrary-ModelIDGrid-Columns'></a>
### Columns `property`

##### Summary

Gets the number of elements in the X dimension of an array of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID').

<a name='P-ParquetClassLibrary-ModelIDGrid-Count'></a>
### Count `property`

##### Summary

The total number of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s collected.

<a name='P-ParquetClassLibrary-ModelIDGrid-Empty'></a>
### Empty `property`

##### Summary

A value to use in place of uninitialized [ModelIDGrid](#T-ParquetClassLibrary-ModelIDGrid 'ParquetClassLibrary.ModelIDGrid')s.

<a name='P-ParquetClassLibrary-ModelIDGrid-IDs'></a>
### IDs `property`

##### Summary

The backing collection of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')es.

<a name='P-ParquetClassLibrary-ModelIDGrid-Item-System-Int32,System-Int32-'></a>
### Item `property`

##### Summary

Access to any [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') in the grid.

<a name='P-ParquetClassLibrary-ModelIDGrid-Rows'></a>
### Rows `property`

##### Summary

Gets the number of elements in the Y dimension of an array of [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID').

<a name='M-ParquetClassLibrary-ModelIDGrid-GetEnumerator'></a>
### GetEnumerator() `method`

##### Summary

Exposes an enumerator for the [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID'), which supports simple iteration.

##### Returns

An enumerator.

##### Parameters

This method has no parameters.

##### Remarks

For serialization, this guarantees stable iteration order.

<a name='M-ParquetClassLibrary-ModelIDGrid-IsValidPosition-ParquetClassLibrary-Vector2D-'></a>
### IsValidPosition(inPosition) `method`

##### Summary

Determines if the given position corresponds to a point within the collection.

##### Returns

`true`, if the position is valid, `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inPosition | [ParquetClassLibrary.Vector2D](#T-ParquetClassLibrary-Vector2D 'ParquetClassLibrary.Vector2D') | The position to validate. |

<a name='M-ParquetClassLibrary-ModelIDGrid-System#Collections#Generic#IEnumerable{ParquetClassLibrary#ModelID}#GetEnumerator'></a>
### System#Collections#Generic#IEnumerable{ParquetClassLibrary#ModelID}#GetEnumerator() `method`

##### Summary

Exposes an [IEnumerator\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerator`1 'System.Collections.Generic.IEnumerator`1'), which supports simple iteration.

##### Returns

An enumerator.

##### Parameters

This method has no parameters.

##### Remarks

For serialization, this guarantees stable iteration order.

<a name='T-ParquetClassLibrary-ModelTag'></a>
## ModelTag `type`

##### Namespace

ParquetClassLibrary

##### Summary

Identifies functional characteristics of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model')s,
such as their role in [CraftingRecipe](#T-ParquetClassLibrary-Crafts-CraftingRecipe 'ParquetClassLibrary.Crafts.CraftingRecipe')s or
[BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe')s.

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

<a name='M-ParquetClassLibrary-Parquets-ParquetModel-#ctor-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Nullable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag},System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelTag}-'></a>
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
| inItemID | [System.Nullable{ParquetClassLibrary.ModelID}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{ParquetClassLibrary.ModelID}') | The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel') awarded to the player when a character gathers or collects this parquet. |
| inAddsToBiome | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}') | Describes which, if any, [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe')(s) this parquet helps form. |
| inAddsToRoom | [System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{ParquetClassLibrary.ModelTag}') | Describes which, if any, [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe')(s) this parquet helps form. |

<a name='P-ParquetClassLibrary-Parquets-ParquetModel-AddsToBiome'></a>
### AddsToBiome `property`

##### Summary

Describes the [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe')(s) that this parquet helps form.
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

<a name='P-ParquetClassLibrary-Parquets-ParquetModel-ParquetClassLibrary#Parquets#IParquetModelEdit#AddsToBiome'></a>
### ParquetClassLibrary#Parquets#IParquetModelEdit#AddsToBiome `property`

##### Summary

Describes the [BiomeRecipe](#T-ParquetClassLibrary-Biomes-BiomeRecipe 'ParquetClassLibrary.Biomes.BiomeRecipe')(s) that this parquet helps form.
Guaranteed to never be `null`.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Parquets-ParquetModel-ParquetClassLibrary#Parquets#IParquetModelEdit#AddsToRoom'></a>
### ParquetClassLibrary#Parquets#IParquetModelEdit#AddsToRoom `property`

##### Summary

A property of the parquet that can, for example, be used by [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe')s.
Guaranteed to never be `null`.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Parquets-ParquetModel-ParquetClassLibrary#Parquets#IParquetModelEdit#ItemID'></a>
### ParquetClassLibrary#Parquets#IParquetModelEdit#ItemID `property`

##### Summary

The [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') of the [ItemModel](#T-ParquetClassLibrary-Items-ItemModel 'ParquetClassLibrary.Items.ItemModel') awarded to the player when a character gathers or collects this parquet.

##### Remarks

By design, children of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') should never themselves use [IModelEdit](#T-ParquetClassLibrary-IModelEdit 'ParquetClassLibrary.IModelEdit').
IModelEdit is for external types that require read/write access.

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

<a name='P-ParquetClassLibrary-Parquets-ParquetStack-BlockID'></a>
### BlockID `property`

##### Summary

The block contained in this stack.

<a name='P-ParquetClassLibrary-Parquets-ParquetStack-CollectibleID'></a>
### CollectibleID `property`

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

<a name='P-ParquetClassLibrary-Parquets-ParquetStack-FloorID'></a>
### FloorID `property`

##### Summary

The floor contained in this stack.

<a name='P-ParquetClassLibrary-Parquets-ParquetStack-FurnishingID'></a>
### FurnishingID `property`

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
1, It has a [BlockID](#P-ParquetClassLibrary-Parquets-ParquetStack-BlockID 'ParquetClassLibrary.Parquets.ParquetStack.BlockID') that is not [IsLiquid](#P-ParquetClassLibrary-Parquets-BlockModel-IsLiquid 'ParquetClassLibrary.Parquets.BlockModel.IsLiquid'); or,
2, It has a [FurnishingID](#P-ParquetClassLibrary-Parquets-ParquetStack-FurnishingID 'ParquetClassLibrary.Parquets.ParquetStack.FurnishingID') that is [IsEnclosing](#P-ParquetClassLibrary-Parquets-FurnishingModel-IsEnclosing 'ParquetClassLibrary.Parquets.FurnishingModel.IsEnclosing').

##### Returns

`true`, if this [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') is Enclosing, `false` otherwise.

<a name='P-ParquetClassLibrary-Parquets-ParquetStack-IsEntry'></a>
### IsEntry `property`

##### Summary

A [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') is Entry iff:
1, It is either Walkable or Enclosing but not both; and,
2, It has a [FurnishingID](#P-ParquetClassLibrary-Parquets-ParquetStack-FurnishingID 'ParquetClassLibrary.Parquets.ParquetStack.FurnishingID') that is [Entry](#P-ParquetClassLibrary-Parquets-FurnishingModel-Entry 'ParquetClassLibrary.Parquets.FurnishingModel.Entry').

##### Returns

`true`, if this [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') is Entry, `false` otherwise.

<a name='P-ParquetClassLibrary-Parquets-ParquetStack-IsWalkable'></a>
### IsWalkable `property`

##### Summary

A [ParquetStack](#T-ParquetClassLibrary-Parquets-ParquetStack 'ParquetClassLibrary.Parquets.ParquetStack') is considered walkable iff:
1, It has a [FloorID](#P-ParquetClassLibrary-Parquets-ParquetStack-FloorID 'ParquetClassLibrary.Parquets.ParquetStack.FloorID');
2, It does not have a [BlockID](#P-ParquetClassLibrary-Parquets-ParquetStack-BlockID 'ParquetClassLibrary.Parquets.ParquetStack.BlockID');
3, It does not have a [FurnishingID](#P-ParquetClassLibrary-Parquets-ParquetStack-FurnishingID 'ParquetClassLibrary.Parquets.ParquetStack.FurnishingID') that [IsEnclosing](#P-ParquetClassLibrary-Parquets-FurnishingModel-IsEnclosing 'ParquetClassLibrary.Parquets.FurnishingModel.IsEnclosing').

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

<a name='P-ParquetClassLibrary-Parquets-ParquetStackGrid-Empty'></a>
### Empty `property`

##### Summary

A value to use in place of uninitialized [ParquetStackGrid](#T-ParquetClassLibrary-Parquets-ParquetStackGrid 'ParquetClassLibrary.Parquets.ParquetStackGrid')s.

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

<a name='P-ParquetClassLibrary-Parquets-ParquetStatusGrid-Empty'></a>
### Empty `property`

##### Summary

A value to use in place of uninitialized [ParquetStatusGrid](#T-ParquetClassLibrary-Parquets-ParquetStatusGrid 'ParquetClassLibrary.Parquets.ParquetStatusGrid')s.

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

<a name='T-ParquetClassLibrary-Precondition'></a>
## Precondition `type`

##### Namespace

ParquetClassLibrary

##### Summary

Provides constructors and initialization routines with concise arugment boilerplate.

<a name='F-ParquetClassLibrary-Precondition-DefaultArgumentName'></a>
### DefaultArgumentName `constants`

##### Summary

Text to use when no argument name is provided.

<a name='M-ParquetClassLibrary-Precondition-AreInRange-System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},System-String-'></a>
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

<a name='M-ParquetClassLibrary-Precondition-AreInRange-System-Collections-Generic-IEnumerable{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Range{ParquetClassLibrary-ModelID}},System-String-'></a>
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

<a name='M-ParquetClassLibrary-Precondition-IsInRange-System-Int32,ParquetClassLibrary-Range{System-Int32},System-String-'></a>
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

<a name='M-ParquetClassLibrary-Precondition-IsInRange-ParquetClassLibrary-ModelID,ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},System-String-'></a>
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

<a name='M-ParquetClassLibrary-Precondition-IsInRange-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},System-String-'></a>
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

<a name='M-ParquetClassLibrary-Precondition-IsInRange-ParquetClassLibrary-ModelID,System-Collections-Generic-IEnumerable{ParquetClassLibrary-Range{ParquetClassLibrary-ModelID}},System-String-'></a>
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

<a name='M-ParquetClassLibrary-Precondition-IsInRange-ParquetClassLibrary-Range{ParquetClassLibrary-ModelID},System-Collections-Generic-IEnumerable{ParquetClassLibrary-Range{ParquetClassLibrary-ModelID}},System-String-'></a>
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

<a name='M-ParquetClassLibrary-Precondition-IsNotNone-ParquetClassLibrary-ModelID,System-String-'></a>
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

<a name='M-ParquetClassLibrary-Precondition-IsNotNull-System-Object,System-String-'></a>
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

<a name='M-ParquetClassLibrary-Precondition-IsNotNullOrEmpty-System-String,System-String-'></a>
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

<a name='M-ParquetClassLibrary-Precondition-IsNotNullOrEmpty``1-System-Collections-Generic-IEnumerable{``0},System-String-'></a>
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

<a name='M-ParquetClassLibrary-Precondition-IsOfType``2-System-String-'></a>
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

<a name='M-ParquetClassLibrary-Precondition-MustBeNonNegative-System-Int32,System-String-'></a>
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

<a name='M-ParquetClassLibrary-Precondition-MustBePositive-System-Int32,System-String-'></a>
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

Returns the filename and path associated with [PronounGroup](#T-ParquetClassLibrary-Beings-PronounGroup 'ParquetClassLibrary.Beings.PronounGroup')'s definition file.

##### Returns

A full path to the associated file.

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

<a name='F-ParquetClassLibrary-Range`1-None'></a>
### None `constants`

##### Summary

Represents the empty range.

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

<a name='P-ParquetClassLibrary-Properties-Resources-DirectionAbove'></a>
### DirectionAbove `property`

##### Summary

Looks up a localized string similar to above.

<a name='P-ParquetClassLibrary-Properties-Resources-DirectionBelow'></a>
### DirectionBelow `property`

##### Summary

Looks up a localized string similar to below.

<a name='P-ParquetClassLibrary-Properties-Resources-DirectionEast'></a>
### DirectionEast `property`

##### Summary

Looks up a localized string similar to east.

<a name='P-ParquetClassLibrary-Properties-Resources-DirectionNorth'></a>
### DirectionNorth `property`

##### Summary

Looks up a localized string similar to north.

<a name='P-ParquetClassLibrary-Properties-Resources-DirectionSouth'></a>
### DirectionSouth `property`

##### Summary

Looks up a localized string similar to south.

<a name='P-ParquetClassLibrary-Properties-Resources-DirectionWest'></a>
### DirectionWest `property`

##### Summary

Looks up a localized string similar to west.

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorCannotAdd'></a>
### ErrorCannotAdd `property`

##### Summary

Looks up a localized string similar to Tried to add already-contained {0} '{1}'.  Did you mean to call Replace?.

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorCannotConvert'></a>
### ErrorCannotConvert `property`

##### Summary

Looks up a localized string similar to Could not convert '{0}' to {1}..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorCannotParse'></a>
### ErrorCannotParse `property`

##### Summary

Looks up a localized string similar to Could not parse '{0}' as {1}..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorCannotRemove'></a>
### ErrorCannotRemove `property`

##### Summary

Looks up a localized string similar to Tried to remove {0} with ID {1}, but it is not contained in this collection..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorCannotReplace'></a>
### ErrorCannotReplace `property`

##### Summary

Looks up a localized string similar to Tried to replace non-contained {0} '{1}'.  Did you mean to call Add?.

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorClearAllFirst'></a>
### ErrorClearAllFirst `property`

##### Summary

Looks up a localized string similar to You must clear the model database before reloading it..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorInvalidCast'></a>
### ErrorInvalidCast `property`

##### Summary

Looks up a localized string similar to {0} is of type {1} but must be of type {2}..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorInvalidPosition'></a>
### ErrorInvalidPosition `property`

##### Summary

Looks up a localized string similar to Invalid position: {0} is not within {1}..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorModelNotFound'></a>
### ErrorModelNotFound `property`

##### Summary

Looks up a localized string similar to No model of type {0} exists for ID {1}..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorMustBeNonNegative'></a>
### ErrorMustBeNonNegative `property`

##### Summary

Looks up a localized string similar to {0} must be a non-negative number..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorMustBePositive'></a>
### ErrorMustBePositive `property`

##### Summary

Looks up a localized string similar to {0} must be a positive number..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorMustNotBeEmpty'></a>
### ErrorMustNotBeEmpty `property`

##### Summary

Looks up a localized string similar to {0} cannot be empty..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorMustNotBeNone'></a>
### ErrorMustNotBeNone `property`

##### Summary

Looks up a localized string similar to {0} cannot be None..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorMustNotBeNull'></a>
### ErrorMustNotBeNull `property`

##### Summary

Looks up a localized string similar to {0} cannot be null..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorMustNotBeNullEmpty'></a>
### ErrorMustNotBeNullEmpty `property`

##### Summary

Looks up a localized string similar to {0} cannot be null or empty..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorNoExitFound'></a>
### ErrorNoExitFound `property`

##### Summary

Looks up a localized string similar to No entry/exit found in {0} or {1}..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorOutOfBounds'></a>
### ErrorOutOfBounds `property`

##### Summary

Looks up a localized string similar to {0}: {1} is not within {2}..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorOutOfOrderGTE'></a>
### ErrorOutOfOrderGTE `property`

##### Summary

Looks up a localized string similar to {0} is {1} but must be greater than or equal to {2}..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorOutOfOrderLTE'></a>
### ErrorOutOfOrderLTE `property`

##### Summary

Looks up a localized string similar to {0} is {1} but must be less than or equal to {2}..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorUndefinedDirection'></a>
### ErrorUndefinedDirection `property`

##### Summary

Looks up a localized string similar to The direction '{0}' is not defined..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorUngenerated'></a>
### ErrorUngenerated `property`

##### Summary

Looks up a localized string similar to Cannot access {0} on ungenerated {1}..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorUnsupportedDimension'></a>
### ErrorUnsupportedDimension `property`

##### Summary

Looks up a localized string similar to Dimension outside specification: {0}.

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorUnsupportedDuplicate'></a>
### ErrorUnsupportedDuplicate `property`

##### Summary

Looks up a localized string similar to Tried to duplicate {0} {1}..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorUnsupportedNode'></a>
### ErrorUnsupportedNode `property`

##### Summary

Looks up a localized string similar to Unsupported {0} node {1}..

<a name='P-ParquetClassLibrary-Properties-Resources-ErrorUnsupportedSerialization'></a>
### ErrorUnsupportedSerialization `property`

##### Summary

Looks up a localized string similar to Serializing or deserializing {0} is not yet supported..

<a name='P-ParquetClassLibrary-Properties-Resources-ResourceManager'></a>
### ResourceManager `property`

##### Summary

Returns the cached ResourceManager instance used by this class.

<a name='P-ParquetClassLibrary-Properties-Resources-WarningTriedToGiveNothing'></a>
### WarningTriedToGiveNothing `property`

##### Summary

Looks up a localized string similar to Tried to give {0} to {1}..

<a name='P-ParquetClassLibrary-Properties-Resources-WarningTriedToStoreNothing'></a>
### WarningTriedToStoreNothing `property`

##### Summary

Looks up a localized string similar to Tried to store {0} in {1}..

<a name='T-ParquetClassLibrary-Rooms-Room'></a>
## Room `type`

##### Namespace

ParquetClassLibrary.Rooms

##### Summary

Models the a constructed [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room').

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

<a name='P-ParquetClassLibrary-Rooms-Room-FurnishingTags'></a>
### FurnishingTags `property`

##### Summary

The [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag')s for every [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') found in this [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room')
duplicated the number of times each tag is found.

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

<a name='T-ParquetClassLibrary-Rooms-RoomConfiguration'></a>
## RoomConfiguration `type`

##### Namespace

ParquetClassLibrary.Rooms

##### Summary

Provides parameters for [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room')s.

<a name='P-ParquetClassLibrary-Rooms-RoomConfiguration-MaxWalkableSpaces'></a>
### MaxWalkableSpaces `property`

##### Summary

Maximum number of open walkable spaces needed for any room to register.

<a name='P-ParquetClassLibrary-Rooms-RoomConfiguration-MinPerimeterSpaces'></a>
### MinPerimeterSpaces `property`

##### Summary

Minimum number of enclosing spaces needed for any room to register.

<a name='P-ParquetClassLibrary-Rooms-RoomConfiguration-MinWalkableSpaces'></a>
### MinWalkableSpaces `property`

##### Summary

Minimum number of open walkable spaces needed for any room to register.

<a name='M-ParquetClassLibrary-Rooms-RoomConfiguration-GetFilePath'></a>
### GetFilePath() `method`

##### Summary

Returns the filename and path associated with [RoomConfiguration](#T-ParquetClassLibrary-Rooms-RoomConfiguration 'ParquetClassLibrary.Rooms.RoomConfiguration')'s definition file.

##### Returns

A full path to the associated file.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Rooms-RoomConfiguration-GetRecord'></a>
### GetRecord() `method`

##### Summary

Reads [RoomConfiguration](#T-ParquetClassLibrary-Rooms-RoomConfiguration 'ParquetClassLibrary.Rooms.RoomConfiguration') data from the appropriate file.

##### Returns

The instances read.

##### Parameters

This method has no parameters.

<a name='M-ParquetClassLibrary-Rooms-RoomConfiguration-PutRecord'></a>
### PutRecord() `method`

##### Summary

Writes [RoomConfiguration](#T-ParquetClassLibrary-Rooms-RoomConfiguration 'ParquetClassLibrary.Rooms.RoomConfiguration') data to the appropriate file.

##### Parameters

This method has no parameters.

<a name='T-ParquetClassLibrary-Rooms-RoomRecipe'></a>
## RoomRecipe `type`

##### Namespace

ParquetClassLibrary.Rooms

##### Summary

Models the minimum requirements for a [Room](#T-ParquetClassLibrary-Rooms-Room 'ParquetClassLibrary.Rooms.Room') to be recognizable and useful.

<a name='M-ParquetClassLibrary-Rooms-RoomRecipe-#ctor-ParquetClassLibrary-ModelID,System-String,System-String,System-String,System-Nullable{System-Int32},System-Collections-Generic-IEnumerable{ParquetClassLibrary-RecipeElement},System-Collections-Generic-IEnumerable{ParquetClassLibrary-RecipeElement},System-Collections-Generic-IEnumerable{ParquetClassLibrary-RecipeElement}-'></a>
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
| inMinimumWalkableSpaces | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | The minimum number of walkable [MapSpace](#T-ParquetClassLibrary-Rooms-MapSpace 'ParquetClassLibrary.Rooms.MapSpace')s required by this [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe'). |
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

<a name='P-ParquetClassLibrary-Rooms-RoomRecipe-ParquetClassLibrary#Rooms#IRoomRecipeEdit#MinimumWalkableSpaces'></a>
### ParquetClassLibrary#Rooms#IRoomRecipeEdit#MinimumWalkableSpaces `property`

##### Summary

Minimum number of open spaces needed for this [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe') to register.

##### Remarks

By design, children of [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe') should never themselves use [IRoomRecipeEdit](#T-ParquetClassLibrary-Rooms-IRoomRecipeEdit 'ParquetClassLibrary.Rooms.IRoomRecipeEdit').
IRoomRecipeEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Rooms-RoomRecipe-ParquetClassLibrary#Rooms#IRoomRecipeEdit#OptionallyRequiredFurnishings'></a>
### ParquetClassLibrary#Rooms#IRoomRecipeEdit#OptionallyRequiredFurnishings `property`

##### Summary

A list of [FurnishingModel](#T-ParquetClassLibrary-Parquets-FurnishingModel 'ParquetClassLibrary.Parquets.FurnishingModel') categories this [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe') requires.

##### Remarks

By design, children of [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe') should never themselves use [IRoomRecipeEdit](#T-ParquetClassLibrary-Rooms-IRoomRecipeEdit 'ParquetClassLibrary.Rooms.IRoomRecipeEdit').
IRoomRecipeEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Rooms-RoomRecipe-ParquetClassLibrary#Rooms#IRoomRecipeEdit#OptionallyRequiredPerimeterBlocks'></a>
### ParquetClassLibrary#Rooms#IRoomRecipeEdit#OptionallyRequiredPerimeterBlocks `property`

##### Summary

An optional list of [BlockModel](#T-ParquetClassLibrary-Parquets-BlockModel 'ParquetClassLibrary.Parquets.BlockModel') categories this [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe') requires as walls.

##### Remarks

By design, children of [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe') should never themselves use [IRoomRecipeEdit](#T-ParquetClassLibrary-Rooms-IRoomRecipeEdit 'ParquetClassLibrary.Rooms.IRoomRecipeEdit').
IRoomRecipeEdit is for external types that require read/write access.

<a name='P-ParquetClassLibrary-Rooms-RoomRecipe-ParquetClassLibrary#Rooms#IRoomRecipeEdit#OptionallyRequiredWalkableFloors'></a>
### ParquetClassLibrary#Rooms#IRoomRecipeEdit#OptionallyRequiredWalkableFloors `property`

##### Summary

An optional list of [FloorModel](#T-ParquetClassLibrary-Parquets-FloorModel 'ParquetClassLibrary.Parquets.FloorModel') categories this [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe') requires.

##### Remarks

By design, children of [RoomRecipe](#T-ParquetClassLibrary-Rooms-RoomRecipe 'ParquetClassLibrary.Rooms.RoomRecipe') should never themselves use [IRoomRecipeEdit](#T-ParquetClassLibrary-Rooms-IRoomRecipeEdit 'ParquetClassLibrary.Rooms.IRoomRecipeEdit').
IRoomRecipeEdit is for external types that require read/write access.

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

<a name='P-ParquetClassLibrary-Scripts-ScriptModel-ParquetClassLibrary#Scripts#IScriptModelEdit#Nodes'></a>
### ParquetClassLibrary#Scripts#IScriptModelEdit#Nodes `property`

##### Summary

A series of imperative, procedural commands.

##### Remarks

By design, children of [ScriptModel](#T-ParquetClassLibrary-Scripts-ScriptModel 'ParquetClassLibrary.Scripts.ScriptModel') should never themselves use [IScriptModelEdit](#T-ParquetClassLibrary-Scripts-IScriptModelEdit 'ParquetClassLibrary.Scripts.IScriptModelEdit').
IScriptModelEdit is for external types that require read/write access.

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

Initializes a new [StrikePanelGrid](#T-ParquetClassLibrary-Crafts-StrikePanelGrid 'ParquetClassLibrary.Crafts.StrikePanelGrid') with unusable dimensions.

##### Parameters

This constructor has no parameters.

##### Remarks

For this class, there are no reasonable default values.
 However, this version of the constructor exists to make the generic new() constraint happy
 and is used in the library in a context where its limitations are understood.
 You probably don't want to use this constructor in your own code.

<a name='M-ParquetClassLibrary-Crafts-StrikePanelGrid-#ctor-System-Int32,System-Int32-'></a>
### #ctor(inRowCount,inColumnCount) `constructor`

##### Summary

Initializes a new [StrikePanelGrid](#T-ParquetClassLibrary-Crafts-StrikePanelGrid 'ParquetClassLibrary.Crafts.StrikePanelGrid').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inRowCount | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The length of the Y dimension of the collection. |
| inColumnCount | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The length of the X dimension of the collection. |

##### Remarks

This constructor supports instance creation via reflection from the [GridConverter\`2](#T-ParquetClassLibrary-GridConverter`2 'ParquetClassLibrary.GridConverter`2') class.

<a name='F-ParquetClassLibrary-Crafts-StrikePanelGrid-PanelsPerPatternHeight'></a>
### PanelsPerPatternHeight `constants`

##### Summary

Height of the [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel') pattern in [CraftingRecipe](#T-ParquetClassLibrary-Crafts-CraftingRecipe 'ParquetClassLibrary.Crafts.CraftingRecipe').

<a name='F-ParquetClassLibrary-Crafts-StrikePanelGrid-PanelsPerPatternWidth'></a>
### PanelsPerPatternWidth `constants`

##### Summary

Width of the [StrikePanel](#T-ParquetClassLibrary-Crafts-StrikePanel 'ParquetClassLibrary.Crafts.StrikePanel') pattern in [CraftingRecipe](#T-ParquetClassLibrary-Crafts-CraftingRecipe 'ParquetClassLibrary.Crafts.CraftingRecipe').

<a name='P-ParquetClassLibrary-Crafts-StrikePanelGrid-Columns'></a>
### Columns `property`

##### Summary

Gets the number of elements in the X dimension of the [StrikePanelGrid](#T-ParquetClassLibrary-Crafts-StrikePanelGrid 'ParquetClassLibrary.Crafts.StrikePanelGrid').

<a name='P-ParquetClassLibrary-Crafts-StrikePanelGrid-Count'></a>
### Count `property`

##### Summary

The total number of parquets collected.

<a name='P-ParquetClassLibrary-Crafts-StrikePanelGrid-Empty'></a>
### Empty `property`

##### Summary

A value to use in place of uninitialized [StrikePanelGrid](#T-ParquetClassLibrary-Crafts-StrikePanelGrid 'ParquetClassLibrary.Crafts.StrikePanelGrid')s.

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
