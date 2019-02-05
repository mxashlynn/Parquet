namespace ParquetClassLibrary.Sandbox.Parquets
{
    public struct ParquetStack
    {
        public Floor floor;
        public Block block;
        public Furnishing furnishing;
        public Collectable collectable;

        public ParquetStack(Floor in_floor, Block in_block, Furnishing in_furnishing, Collectable in_collectable)
        {
            floor = in_floor;
            block = in_block;
            furnishing = in_furnishing;
            collectable = in_collectable;
        }
    }
}
