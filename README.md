# Parquet

This class library implements core game mechanics and data models for a sandbox game focused on building, crafting, and narrative, more or less in that priority order.

This is an attempt to answer the question:  "What would Dragon Quest Builders play like if it were constrained to the 2D presentation of Dragon Quest 4?"

Design and usage will be fully documented in [the wiki](https://github.com/mxashlynn/Parquet/wiki) once the [Alpha milestone](https://github.com/mxashlynn/Parquet/milestone/2) has been reached.

Right now, there are no deadlines set for any development milestone.

# Version 0.1.0 Warning

Code and documentation are incomplete and under rapid development.  Expect frequent breaking changes.  Maybe don't use this yet; when the [Pre-Alpha Vertical Slice milestone](https://github.com/mxashlynn/Parquet/milestone/1) and [Alpha milestone](https://github.com/mxashlynn/Parquet/milestone/2) have both been hit the project should be much more usable.

# Goals

This project has two goals:

    1) To provide a foundation for games developed in C# stacks (definitely Unity, perhaps also MonoGame or others);
    2) To provide a learning exercise for the lead developer.

Due to goal 2, no attempt has been made to design the most elegant, effecient, general-purpose, or powerful library possible.
What has been attempted is a cleanly-coded, clearly-documented, easily maintainable API.

That said, (within the bounds imposed by the license) feel free to use this codebase in your own games if it makes sense to do so.

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

# Requirements

To work with this repository you will need:
 
    1) [.NET Core](https://dotnet.microsoft.com/download/dotnet-core) >= 2.2
    2) [XUnit](https://github.com/xunit/xunit)
    3) [JSONDotNet](https://www.newtonsoft.com/)
    4) [CSVHelper](https://joshclose.github.io/CsvHelper/)

# Credits
    - Primary coding and design by Paige Ashlynn.
    - Special thanks for code help to Isabelle Gould and Ashley Hauck.
    - Special thanks for design help to Caidence Stone and Lillian Harris.
    - Special thanks for math help to Caidence Stone.
