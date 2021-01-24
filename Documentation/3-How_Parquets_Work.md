A **parquet** is the smallest interactive unit of the game world.  These are the units with which the player builds and that are available in the map editor.

The word "parquet" refers to a specific part of game logic, not a graphical component or style.

Parquets are defined once and used many times throughout the game world's 2D map.  Once a type of parquet is defined, each parquet of that type shares all the mechanical attributes of the definition.  For example, all silver coin collectibles award the player the same amount of money.

Some types of parquets, notably *floors* and *blocks*, may have statuses that are particular to a specific location.  For example, the block at the player's location may have been damaged while other blocks have not.

Parquets are normally arranged in **Parquet Packs**.  In a ptack, a given location on the map may hold four parquets of different types simultaneously, arranged as follows from top to bottom:

* Collectibles
* Furnishings
* Blocks
* Floors

As an example, a Parquet Pack might consist of:

* a feather Collectible
* on a birdhouse Furnishing
* in a pine tree Block
* growing on a grass forest Floor.

Another example is:

* a rubber duck Collectible
* and no Furnishing
* on a water Block
* sitting in a *dug out* porcelain basin Floor.

The player automatically interacts with Collectibles when moving onto their location.  Other parquets require mediation for interaction.

Furnishings, Blocks, and Floors require tools to be interacted with.  These interactions can result in Floors changing state (e.g. *filled in* vs. *dug out*), Blocks becoming Collectibles (chopping down a tree to form wood), or in being directly removed from the map and added to the player's inventory as **Items**.

When Furnishings and Blocks are transferred from the map to the inventory they are said to be **Gather**ed. 
 Collectibles are said to be **Collect**ed, since this happens without the mediation of tools.  This distinction is important on a game design and implementation level but is invisible to the player.
