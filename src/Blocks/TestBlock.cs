using System;
using BlockCSharp.BaseClasses;
using BlockCSharp.Interfaces;

namespace BlockCSharp.Blocks
{
    public class TestBlock : Block, IBlockModel
    {
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
            
            if (!World.World.ChunkUpdateQueue.Contains(World.World.GetChunk(World.World.BlockToChunkPosition(Position))))
                World.World.ChunkUpdateQueue.Push(World.World.GetChunk(World.World.BlockToChunkPosition(Position)));
        }

        public Model Model { get; set; }
    }
}