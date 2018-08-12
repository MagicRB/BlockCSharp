using System;
using OpenGL;

namespace BlockCSharp.OpenGLAdditions
{
    public class IndexBuffer
    {
        public uint Id;
        
        public void Create()
        {
            uint[] ids = new uint[1];
            Gl.GenBuffers(ids);
            Id = ids[0];
        }

        public void Bind()
        {
            Gl.BindBuffer(BufferTarget.ElementArrayBuffer, Id);
        }

        public void SetData(uint[] rawData)
        {
            Gl.BufferData(BufferTarget.ElementArrayBuffer, (uint)rawData.Length * sizeof(uint), rawData, BufferUsage.StaticDraw);
        }
    }
}