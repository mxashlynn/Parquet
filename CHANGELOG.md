# Changelog
This file reflects changes at each project milestone.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning 2.0.0](https://semver.org/).


## [0.5.0] - 2021-??-??
### Alpha
- This update makes Parquet method calls more C# idiomatic.
#### Adds
- The ability to serialize status classes.
#### Removes
- ...
#### Changes
- Simplifies the signature for creating/serializing CraftingRecipes.
- Renames All.LoadFromCSVs to All.TryLoadModels.
- Renames All.SaveToCSVs to All.TrySaveModels.

## [0.4.0] - 2021-02-23
### Pre-Alpha 3 API Revision
- This update changes the API in far-reaching ways in order to separate design-time and play-time concerns in map-related types.
#### Adds
- Adds Status type as a base class for all mutable-at-play types, analogous to Models.
- Derives a Status-based partner class for most Model classes.
- Adds Pack container type as base for ParquetModelPack and ParquetStatusPack.
- Adds LibraryState static class to track build and run characteristics, particularly Debug-vs-Release and Play-vs-Edit.
#### Removes
- MapModel abstract class, as there is only one map-related Model in the new hierarchy.
#### Changes
- Merges the definitional elements (procedural generation instructions and metadata) of MapRegion and MapSketch into single RegionModel.
- Merges the mutable elements (parquets and their statuses) of MapRegion and MapSketch into a single RegionStatus class.
- Changes MapChunk to a stand-alone class rather than a Model subtype.
- Renames namespace from Map to Region.
- Alters the BeingModel class family to better interoperate with the new RegionModel class family.
- Changes the name of Inventory class to InventoryCollection to avoid confusion in the BeingStatus classes.
- Updates the serialized example data for RegionModel and BeingModel class families.
- Reimplements cloning to enforce deep copying.
- Many minor fixes and corrections along the way.

## [0.3.56] - 2021-02-12
#### Adds
- General purpose Tags collection to the base Model type.
#### Removes
- ItemModel.ItemTags collection, as Model.Tags makes it redundant.

## [0.3.52] - 2021-01-29
#### Removes
- Roller command line utility.  It is now built as part of Scribe instead.

## [0.3.0] - 2020-08-11
### Pre-Alpha 2 Milestone
#### Added
- Major mechanical systems.
#### Changes
- Many small changes to support Scribe GUI editor.

## [0.2.0] - 2020-04-18
### Pre-Alpha 1 Milestone
#### Added
- Models for all major game systems.
- Roller command line utility.

## [0.1.0] - 2019-01-28
#### Added
- Initial commit.

## [0.0.0] - 2018-12-05
#### Project begun.
