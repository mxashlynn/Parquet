# Elevation

Parquet is a 2D game library, so the concept of elevation exists only in rudimentary form.

Any given Map Region may be assigned to one of three possible elevations:  above, level with, or below ground.  Level is the default.

Map Regions are connected to one another via Exit Points.  Exit Points are arbitrary and do not consider elevation (or adjacency of any kind).

However, a Map Region with Above Ground elevation may have another Map Region designated below it.  Likewise, a Below Ground Map Region may have another region above it.  And a Level Ground region may have both.

# Liquid Blocks Flow Down

Liquid Blocks that flow onto an empty space in a Map Region that has another region below it will flow down to that lower elevation Map Region automatically.

# Beings Travel Up & Down

Similarly, Critters and Characters that walk onto an empty space in a Map Region with another region below will fall through to the lower region.

Finally, a Character may build an item like a staircase or ladder at an arbitrary point in a Map Region that has another Map Region designated Above it in order to climb up.
