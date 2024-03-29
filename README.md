# Parquet

This class library implements mechanics and models for a 2D sandbox game focused on building, crafting, and narrative, more or less in that priority order.

A game built with this system offers many of the features of contemporary quest-driven building games but in a simple, top-down world and without combat.

# Version 0.4 Warning

Code and documentation are incomplete and under rapid development.  Expect frequent breaking changes.  Maybe don't use this yet; when the [Alpha milestone](https://github.com/mxashlynn/Parquet/milestone/2) has been hit the project should be much more usable.

Design and usage will be [fully documented](https://github.com/mxashlynn/Parquet/tree/master/Documentation) once the [Beta milestone](https://github.com/mxashlynn/Parquet/milestone/3) has been reached.

Development milestone deadlines are tentative right now.
Because this is one of several side projects that I maintain in addition to my fulltime dayjob, it will be a long time before Parquet is ready.

# Goals

This project has two goals:

1. To provide a foundation for games developed in C# stacks;
2. To provide a learning exercise for the lead developer.

Due to goal 2, no attempt has been made to design the most elegant, efficient, general-purpose, or powerful library possible.
What has been attempted is a cleanly-coded, clearly-documented, easily maintainable class library.

# Features

Parquet targets the following features:

1. A peaceful 2D top-down overworld map that may be explored.
2. Simple free-form building mechanics allowing player characters to create homes in the world.
3. Resource collection mechanics allowing players to upgrade their homes and tools.
4. A simple crafting system allowing players to unlock new tools and building materials.
5. Interactive noncombatant NPCs.
6. A quest system encouraging players to build particular building types.
7. Dialogue and narrative delivery.
8. Data-driven design with all game models customizable from CSV files.

# Repository Structure

The solution contains several related projects.
Each C# namespace gets its own folder.

- **Documentation**
    - How to use the library and its tools.
- **ExampleData**
    - Configuration files used in developing and testing the library.
- **ParquetClassLibrary**
    - The library itself. The root namespace contains classes for working with [Models](https://github.com/mxashlynn/Parquet/blob/master/Documentation/2-How_Parquet_Handles_Game_Objects.md) and Statuses.
    - **Beings**, including player characters and NPCs.
    - **Biomes**, sets of characteristics that Regions may share.
    - **Crafts**, recipes and mini-games that produce Items.
    - **Items**, objects that Beings may carry, including parquets.
    - **Parquets**, [the basic units of play](https://github.com/mxashlynn/Parquet/blob/master/Documentation/3-How_Parquets_Work.md).
    - **Properties** error strings, icons, and other static content.
    - **Regions**, collections of parquets and Beings which together make up the game world.
    - **Rooms**, built from parquets and [recognized at runtime](https://github.com/mxashlynn/Parquet/blob/master/Documentation/4.-Room_Detection_and_Type_Assignment.md).
    - **Scripts**, used to define Being Interactions and Item effects.
- **ParquetRunner**
    - A simple smoke test.
- **ParquetUnitTests**
    - Unit tests for ParquetClassLibrary.

# Requirements

To work with this repository you will need:

- [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)
- [CSVHelper 19](https://joshclose.github.io/CsvHelper/)
- [XUnit 2.4](https://github.com/xunit/xunit) (to compile the unit tests only)

# Contributors
- Library design and code by [Paige Ashlynn](https://github.com/mxashlynn/).
- Special thanks to [Mint Gould](https://github.com/WispyMouse), [Caidence Stone](https://github.com/caidencestone), [Ashley Hauck](https://github.com/khyperia), [Emma Maassen](https://github.com/Enichan), and Lillian Harris for help with code reviews, mathematics, algorithms, game design, and technical decisions.
