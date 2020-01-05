# Parquet

This class library implements mechanics and models for a 2D sandbox game focused on building, crafting, and narrative, more or less in that priority order.

A game built with this system offers many of the features of contemporary quest-driven building games but in a simple, single-layer, top-down world and without the combat.

# Version 0.1.0 Warning

Code and documentation are incomplete and under rapid development.  Expect frequent breaking changes.  Maybe don't use this yet; when the [Alpha milestone](https://github.com/mxashlynn/Parquet/milestone/2) has been hit the project should be much more usable.

![An image of the milestones planned for 2020\.](https://media.githubusercontent.com/media/mxashlynn/Parquet/master/Documentation/Parquet_Roadmap_2020.png "Parquet Development Roadmap 2020")

Design and usage will be fully documented in [the wiki](https://github.com/mxashlynn/Parquet/wiki) once the [Alpha milestone](https://github.com/mxashlynn/Parquet/milestone/2) has been reached.

Development milestone deadlines are tentative right now.

# Goals

This project has two goals:

    1) To provide a foundation for games developed in C# stacks (probably FNA+Nez and Unity);
    2) To provide a learning exercise for the lead developer.

Due to goal 2, no attempt has been made to design the most elegant, effecient, general-purpose, or powerful library possible.
What has been attempted is a cleanly-coded, clearly-documented, easily maintainable class library.

# Features

Parquet targets the following features:

    1) A peaceful 2D top-down overworld map that may be explored.
    2) Simple free-form building mechanics allowing player characters to create homes in the world.
    3) Resource collection mechanics allowing players to upgrade their homes and tools.
    4) A simple crafting system allowing players to unlock new tools and building materials.
    5) Interactive noncombatant NPCs.
    6) A quest system encouraging players to build particular building types.
    7) Dialogue and narrative delivery.

    8) Data-driven design with all key game entities customizable from CSV files.

# Solution Structure

The solution contains several related projects, each of which is structured so that every folder corresponds to a namespace.

- **ParquetClassLibrary**
    - The library itself. The root namespace contains classes for working with [Entities](https://github.com/mxashlynn/Parquet/wiki/2.-How-Parquet-Handles-Game-Objects).
    - **Beings**, including players and NPCs.
    - **Biomes**.
    - **Crafting**.
    - **Items**.
    - **Maps**.
    - **Parquets**, [the basic units of play](https://github.com/mxashlynn/Parquet/wiki/3.-How-Parquets-Work).
    - **Quests**.
    - **Rooms**, [recognized at runtime](https://github.com/mxashlynn/Parquet/wiki/4.-Room-Detection-and-Type-Assignment).
    - **Utilities** of which Range, Vector2D, and Precondition are all very frequently used.
- **ParquetCLITool**
    - A command line tool for working with CSV files containing game definitions.
- **ParquetRunner**
    - A simple app for use in library development.  If you are not developing the library itself, just ignore this.
- **ParquetUnitTests**
    - Unit tests for ParquetClassLibrary.

# Requirements

To work with this repository you will need:

- [.NET Core](https://dotnet.microsoft.com/download/dotnet-core) >= 3.1
- [XUnit](https://github.com/xunit/xunit) >= 2.4
- [CSVHelper](https://joshclose.github.io/CsvHelper/)  >= 12.1

# Credits
- Primary coding and design by [Paige Ashlynn](https://github.com/mxashlynn/).
- Special thanks to [Mint Gould](https://github.com/WispyMouse), [Caidence Stone](https://github.com/caidencestone), [Ashley Hauck](https://github.com/khyperia), [Emma Maassen](https://github.com/Enichan), and Lillian Harris for help with code reviews, mathematics, algorithms, game design quandries, and understanding the finer points of C#.
