using BlockCSharp.Attributes;
using BlockCSharp.BaseClasses;
using BlockCSharp.Interfaces;

namespace BlockCSharp.Blocks
{
    [Block(SRegistryKey = "block:blockcsharp:test_block")]
    public class TestBlock : Block, IBlockModel
    {
        public Model Model { get; set; }

        public override void Start(Vector3i blockPosition)
        {
            Position = blockPosition;
            Opaque = true;

            Update(this);
            World.World.DispatchBlockUpdate(this);
        }

        public override void Update(Block updater)
        {
            Model = PredefinedModels.SimpleCubeModel(Position, World.World.OpaqueSurroundings(Position));

            if (!World.World.ChunkUpdateQueue.Contains(World.World.GetChunk(World.World.BlockToChunkPosition(Position)))
            )
                World.World.ChunkUpdateQueue.Push(World.World.GetChunk(World.World.BlockToChunkPosition(Position)));
        }
    }
}