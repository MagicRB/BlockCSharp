using System;
using BlockCSharp.BaseClasses;
using BlockCSharp.Interfaces;
using BlockCSharp.OpenGLAdditions;
using OpenTK.Graphics.OpenGL4;

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
            GL.EnableVertexAttribArray(0);
            GL.EnableVertexAttribArray(1);
            GL.EnableVertexAttribArray(2);
            GL.EnableVertexAttribArray(3);
                        
            VertexBuffer.Bind();
            IndexBuffer.Bind();
                        
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, /*0*/ 10 * sizeof(float), new IntPtr(0 * sizeof(float)));
            GL.VertexAttribPointer(1, 4, VertexAttribPointerType.Float, false, /*3*/ 10 * sizeof(float), new IntPtr(3 * sizeof(float)));
            GL.VertexAttribPointer(2, 2, VertexAttribPointerType.Float, false, /*7*/ 10 * sizeof(float), new IntPtr(7 * sizeof(float)));
            GL.VertexAttribPointer(3, 1, VertexAttribPointerType.Float, false, /*9*/ 10 * sizeof(float), new IntPtr(9 * sizeof(float)));
                        
            GL.DrawElements(PrimitiveType.Triangles, Elements.Length, DrawElementsType.UnsignedInt, IntPtr.Zero);
                        
            GL.DisableVertexAttribArray(0);
            GL.DisableVertexAttribArray(1);
            GL.DisableVertexAttribArray(2);
            GL.DisableVertexAttribArray(3);
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