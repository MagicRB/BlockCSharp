namespace BlockCSharp.World
{
    public class ExpandedBlockPosition
    {
        public Vector2i ChunkPosition;
        public Vector3i PositionInChunk;

        public ExpandedBlockPosition(Vector2i chunkPosition, Vector3i positionInChunk)
        {
            ChunkPosition = chunkPosition;
            PositionInChunk = positionInChunk;
        }

        public ExpandedBlockPosition(int chunkX, int chunkY, int inChunkX, int inChunkY, int inChunkZ)
        {
            ChunkPosition = new Vector2i(chunkX, chunkY);
            PositionInChunk = new Vector3i(inChunkX, inChunkY, inChunkZ);
        }

        public ExpandedBlockPosition()
        {
            ChunkPosition = new Vector2i();
            PositionInChunk = new Vector3i();
        }

        public override string ToString()
        {
            return "{" + ChunkPosition + "; " + PositionInChunk + "}";
        }
    }
}