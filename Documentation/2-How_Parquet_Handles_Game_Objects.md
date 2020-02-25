The vast majority of game objects in a given Parquet game consist of details set at design time that do not change at any point during play.  Parquet tracks these as "Models".

Here is how the system works.

## Models
A **Model** could be considered the fundamental concept in the Parquet library.  It represents the parts of a game object that do not change over time, or from one instance to another.

## ModelIDs and ModelCollections

As part of their definition, every Model has an identifier, providing a means to track and rapidly swap large numbers of models at runtime.

Many different game objects can then share a single definition when working out their game rules and behaviors.  For example, we might define what it means to be a bunny and then introduce many bunnies around the place; they would all share our original definition.  In this sense, you could think of Models as equivalent to C# classes.

As the analogy with C# classes would suggest, Parquet also provides a means to track individual instances of each model -- a way to have a collection of five individual bunnies, rather than simply the idea of a bunny.

These individuals are similar to C# object instances, and Parquet represents them as **ModelID**s.

Individual game objects reference their models, and those models live within **ModelCollection**s.  A ModelCollection can contain any number of models of the same general sort -- bunnies with other critters, wooden planks with other types of flooring, and so on.

## All: Where Models Are Defined

An ModelID is used to look up the singular Model from the appropriate ModelCollection.  Most of the time, this is done via one of the canonical model collections provided by the "**All**" super-collection.

This allows (hopefully!) fluent constructions in code such as

```cs
block1 = All.Parquets.Get<BlockModel>(1);
```

where `1` is the ModelID.

Using lines of code like this, the library looks up the game object definitions for any particular game object as needed when game rules are checked or game elements interact.

All is populated during initialization and remains immutable afterward, serving as the source of truth about the parts of game objects that do not change during play.

## Model Status

Of course, even in a Parquet game many game objects have details that _do_ change over time or from one instance to another.

For example, one of the bunnies might hop over from the clover down to the brook, and the game would need to track where exactly that specific bunny had moved.

If individual game objects must have mutable state like this, then a separate partner class captures those details.  Such classes always end in the word "Status"; examples include **ParquetStatus** for floors and blocks, or **BeingStatus** for player characters and NPCs.

## Model Types and Sub-Types

Most of the time when we are talking about a group of Models we are talking about a group of very similar Models, such as those bunnies.

Many of the game objects that Parquet deals with can be grouped together like this into collections with shared characteristics.  In such a collection, Parquet guarantees that all the given Models have the same general type of information in their definition.

The types of Entities that Parquet knows about are:
- Being Models
    - Character Models
    - Critter Models
- Biome Models
- Interaction Models
    - Dialogue Models
    - Quest Models
- Item Models
- Parquet Models
    - Floor Models
    - Block Models
    - Furnishing Models
    - Collectible Models
- Recipes
    - Crafting Recipes
    - Room Recipes

Similar to how a C# compiler provides type-checking for C# objects, Parquet defines valid ID ranges for all Model types and sub-types.

## Tags: Grouping Models Across Types

Sometimes we want to talk about Models that are not in the same formal group but nevertheless share a characteristic.  For example, we might be interested to note that one of the bunnies is bright pink, and that there are similar pink flowers down by the brook.

For scenarios like this, Parquet provides a way to identify characteristics outside the scope of the formal definition.  Narrative, aesthetic, or mechanical features can be tagged to indicate what informal attributes they exhibit.

This allows for the definition of Models that rely on a loose category of other Models.  For example, a volcanic BiomeModel might be interested in every ParquetModel that has the "Volcanic" tag, or a candy CraftingRecipe might be interested in any Item Model with the "Sugary" tag.

To support this kind of flexibility, more than one **ModelTag** can coexist on a specific Model.

## More Details

For more technical details, please read the remarks on the [Model](https://github.com/mxashlynn/Parquet/blob/master/ParquetClassLibrary/Model.cs) class and related classes.
