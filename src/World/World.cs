using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection;
using System.Text.RegularExpressions;
using BlockCSharp.BaseClasses;
using BlockCSharp.Blocks;

namespace BlockCSharp.World
{
    public static class World
    {
        public static Dictionary<Vector2i, Chunk> Chunks = new Dictionary<Vector2i, Chunk>();

        public static Stack<Chunk> ChunkUpdateQueue = new Stack<Chunk>();
        
        public static void AddChunk(Vector2i chunkPosition)
        {
            if (!Chunks.ContainsKey(chunkPosition))
            {
                Chunks.Add(chunkPosition, new Chunk());
                Chunks[chunkPosition].BuildVertexArray();
            }
        }

        public static void DeleteChunk(Vector2i chunkPosition)
        {
            if (Chunks.ContainsKey(chunkPosition))
            {
                Chunks.Remove(chunkPosition);
            }
        }

        public static Chunk GetChunk(Vector2i chunkPosition)
        {
            if (Chunks.ContainsKey(chunkPosition))
            {
                return Chunks[chunkPosition];
            }

            return null;
        }
        
        public static Block SetBlock(Vector3i blockPosition, Type blockType)
        {
            ExpandedBlockPosition ebp = ExpandBlockPosition(blockPosition);

            if (Chunks.ContainsKey(ebp.ChunkPosition))
            {
                Chunk chunk = Chunks[ebp.ChunkPosition];

                Block block = GetBlock(blockPosition);

                
                chunk.Blocks[ebp.PositionInChunk.X, ebp.PositionInChunk.Y, ebp.PositionInChunk.Z] = Activator.CreateInstance(blockType) as Block;
                chunk.Blocks[ebp.PositionInChunk.X, ebp.PositionInChunk.Y, ebp.PositionInChunk.Z].Start(blockPosition);
                
                return block;
            }
            return new NotLoaded();
        }

        public static Block GetBlock(Vector3i blockPosition)
        {
            ExpandedBlockPosition ebp = ExpandBlockPosition(blockPosition);

            if (Chunks.ContainsKey(ebp.ChunkPosition) && blockPosition.Y >= 0 && blockPosition.Y <= 255)
            {
                Chunk chunk = Chunks[ebp.ChunkPosition];

                Block block = chunk.Blocks[ebp.PositionInChunk.X, ebp.PositionInChunk.Y, ebp.PositionInChunk.Z];

                if (block != null)
                {
                    return chunk.Blocks[ebp.PositionInChunk.X, ebp.PositionInChunk.Y, ebp.PositionInChunk.Z];
                }
                return new Air();
            }
            return new NotLoaded();
        }

        public static Vector2i BlockToChunkPosition(Vector3i blockPosition)
        {
            return new Vector2i((int) Math.Floor(blockPosition.X / 16.0f), (int) Math.Floor(blockPosition.Z / 16.0f));
        }

        public static Vector3i BlockPositionInChunk(Vector3i blockPosition)
        {
            Vector3i vector3i = new Vector3i(blockPosition.X % 16, blockPosition.Y, blockPosition.Z % 16);

            if (vector3i.X < 0) vector3i.X += 16;
            if (vector3i.Z < 0) vector3i.Z += 16;

            return vector3i;
        }

        public static ExpandedBlockPosition ExpandBlockPosition(Vector3i blockPosition)
        {
            return new ExpandedBlockPosition(BlockToChunkPosition(blockPosition), BlockPositionInChunk(blockPosition));
        }

        public static SurroundingBlocks Surroundings(Vector3i blockPosition)
        {
            SurroundingBlocks surroundingBlocks = new SurroundingBlocks();

            surroundingBlocks.PositiveX = GetBlock(blockPosition + new Vector3i(1, 0, 0));
            surroundingBlocks.NegativeX = GetBlock(blockPosition + new Vector3i(-1, 0, 0));
            surroundingBlocks.PositiveY = GetBlock(blockPosition + new Vector3i(0, 1, 0));
            surroundingBlocks.NegativeY = GetBlock(blockPosition + new Vector3i(0, -1, 0));
            surroundingBlocks.PositiveZ = GetBlock(blockPosition + new Vector3i(0, 0, 1));
            surroundingBlocks.NegativeZ = GetBlock(blockPosition + new Vector3i(0, 0, -1));

            return surroundingBlocks;
        }

        public static void DispatchBlockUpdate(Block block)
        {
            SurroundingBlocks surroundingBlocks = Surroundings(block.Position);
            
            surroundingBlocks.PositiveX.Update(block);
            surroundingBlocks.NegativeX.Update(block);
            surroundingBlocks.PositiveY.Update(block);
            surroundingBlocks.NegativeY.Update(block);
            surroundingBlocks.PositiveZ.Update(block);
            surroundingBlocks.NegativeZ.Update(block);
        }

        public static BitArray OpaqueSurroundings(Vector3i blockPosition)
        {
            BitArray bitArray = new BitArray(6, false);

            SurroundingBlocks surroundingBlocks = Surroundings(blockPosition);

            bitArray[0] = surroundingBlocks.PositiveX.Opaque;
            bitArray[1] = surroundingBlocks.NegativeX.Opaque;
            bitArray[2] = surroundingBlocks.PositiveY.Opaque;
            bitArray[3] = surroundingBlocks.NegativeY.Opaque;
            bitArray[4] = surroundingBlocks.PositiveZ.Opaque;
            bitArray[5] = surroundingBlocks.NegativeZ.Opaque;
            
            return bitArray;
        }
    }
}