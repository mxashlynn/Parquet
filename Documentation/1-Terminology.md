Here are definitions for some of the terms used in this class library.

## Parquets

* A **parquet** in everyday speech is a flooring composed of wooden blocks in a geometrical arrangement.  In the United States it is pronounced /pɑːɹˈkeɪ/, i.e. *"par-kay"*.

* Within the context of this library, a **parquet** is the smallest interactive unit of the game world.  These are the units with which the player builds and that are available in the map editor.  Oftentimes in the context of other libraries or games the word "tile" is used to mean something similar; the word "parquet" is employed here to avoid ambiguity.

* **Parquet Stacks** hold parquets during game play.  Up to four parquets of distinct types may occupy a stack.

* **Floor**s are a type of parquet.  They are the lowest layer of parquets in a stack, providing a background and context for other parquets and the various *character*s that inhabit the world.  Floors may be either filled in or dug out; if they are dug out they can contain liquid blocks.  Natural surfaces are implemented as floors.  Examples of floors:

    * Sand
    * Mosaic Tile
    * Metal Catwalk
    * Dropcloth

* **Block**s are a type of parquet.  They exist in a layer above floors and below furnishings.  Blocks are the most complex type of parquet, often the layer with which the player and other characters are interacting.  They may be **gather**ed directly or broken down into **collectible**s.  They may also be crafted and placed in the world by the player.  Examples of blocks:

    * Seawater
    * Inlaid Brick
    * Plasteel Plating
    * Plastered Drywall

    Liquid blocks can only exist on top of floors with the *dug out* property set.

* **Furnishing**s are a type of parquet.  They exist in a layer above blocks and below collectibles.  Furnishings are complex parquets that can have special behaviors.  Often they are crafted objects and may be placed or removed by the player.  Examples of furnishings:

    * Anchored Buoy
    * Palace Gate
    * Photon Forge
    * Padded Sawhorse

* **Collectible**s are a type of parquet.  Constituting the topmost layer, collectibles are simple parquets that represent items on the map that characters (such as the player) may pick up.  Often, they form as a result of breaking down blocks.  Examples of collectibles:

    * Seashell
    * Heart (that grants health)
    * 1 Federation Credit
    * Wrist & Ankle Restraints

*See [How Parquets Work](https://github.com/mxashlynn/Parquet/wiki/How-Parquets-Work).*

## Inventory-Related Terms

* Characters including the player carries objects from the game world around with them in their **Inventory**.

* An **Item** is any game object in the inventory.  Items never exist on the map, although they may be equivalent to parquets that exist on the map.  In the right circumstances, the player may remove parquets from the map.  When a player does so, the parquets become items.

## Map-Related Terms

* The **Map** is a 2D space, the entirety of the playable game world.  Once play has begun the Map is, at the atomic level, composed of parquets.

* **Map Region**s are sections of the game world in play.  Exactly one of these is in play at a time.  Map Regions are composed of *Parquet Stacks*.  All of a given Map Region's parquets exists on the same elevation level, although regions may be higher or lower than one another.  Exits from the current region to other regions may be defined at any specific location.

* **Map Chunk Grid**s are sections of the game world equivalent to Map Regions, but in an uninitialized state before play begins.  They consist of Map Chunks together with locations that have been designated as entrances or exits.  Map Regions may be generated from Map Chunk Grids in a procedural process at the time of load.

* **Map Chunk**s are small subsections of the Map.  They come in two flavors.  Custom map chunks are "Handmade" segments of parquets which will be loaded exactly as they are laid out in the editor.  Procedural map chunks consist of instructions describing the parquets to procedurally generate in this location on the grid.
