using System;
using System.Collections.Generic;
using BlockCSharp.BaseClasses;
using BlockCSharp.Interfaces;
using BlockCSharp.OpenGLAdditions;
using OpenGL;

namespace BlockCSharp.World
{
    public class Chunk
    {
        public Block[,,] Blocks = new Block[16, 256, 16];

        public Vertex[] Vertices;
        public uint[] Elements;
        public uint VertecesCount;
        public uint ElementCount;

        public VertexBuffer VertexBuffer;
        public IndexBuffer IndexBuffer;

        public void Render()
        {
            Gl.EnableVertexAttribArray(0);
            Gl.EnableVertexAttribArray(1);
            Gl.EnableVertexAttribArray(2);
            Gl.EnableVertexAttribArray(3);
                        
            VertexBuffer.Bind();
            IndexBuffer.Bind();
                        
            Gl.VertexAttribPointer(0, 3, VertexAttribType.Float, false, /*0*/ 10 * sizeof(float), new IntPtr(0 * sizeof(float)));
            Gl.VertexAttribPointer(1, 4, VertexAttribType.Float, false, /*3*/ 10 * sizeof(float), new IntPtr(3 * sizeof(float)));
            Gl.VertexAttribPointer(2, 2, VertexAttribType.Float, false, /*7*/ 10 * sizeof(float), new IntPtr(7 * sizeof(float)));
            Gl.VertexAttribPointer(3, 1, VertexAttribType.Float, false, /*9*/ 10 * sizeof(float), new IntPtr(9 * sizeof(float)));
                        
            Gl.DrawElements(PrimitiveType.Triangles, Elements.Length, DrawElementsType.UnsignedInt, IntPtr.Zero);
                        
            Gl.DisableVertexAttribArray(0);
            Gl.DisableVertexAttribArray(1);
            Gl.DisableVertexAttribArray(2);
            Gl.DisableVertexAttribArray(3);
        }
        
        public void BuildVertexArray()
        {
            foreach (var block in Blocks)
            {
                if (block is IBlockModel)
                {
                    IBlockModel blockModel = block as IBlockModel;

                    ElementCount += blockModel.Model.ElementCount;
                    VertecesCount += blockModel.Model.VertexCount;
                }
            }

            Vertices = new Vertex[VertecesCount];
            Elements = new uint[ElementCount];

            uint vertexPos = 0;
            uint elementPos = 0;
            
            foreach (var block in Blocks)
            {
                uint tempVertexPos = vertexPos;
                
                if (block is IBlockModel)
                {
                    IBlockModel blockModel = block as IBlockModel;
                    
                    blockModel.Model.Vertices.CopyTo(Vertices, vertexPos);
                    vertexPos += blockModel.Model.VertexCount;

                    foreach (var element in blockModel.Model.Elements)
                    {
                        Elements[elementPos] = tempVertexPos + element;
                        elementPos++;
                    }
                }
            }
            
            VertexBuffer = new VertexBuffer();
            IndexBuffer = new IndexBuffer();
            
            VertexBuffer.Create();
            VertexBuffer.Bind();
            VertexBuffer.SetData(RawDataCreation.GenRawVertexData(Vertices));
            
            IndexBuffer.Create();
            IndexBuffer.Bind();
            IndexBuffer.SetData(Elements);
        }
        
        public void ChunkUpdate()
        {
            BuildVertexArray();
        }
    }
}