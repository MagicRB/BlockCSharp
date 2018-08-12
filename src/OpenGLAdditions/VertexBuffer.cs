using OpenGL;

namespace BlockCSharp.OpenGLAdditions
{
    public class VertexBuffer
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
            Gl.BindBuffer(BufferTarget.ArrayBuffer, Id);
        }

        public void SetData(float[] rawData)
        {
            Gl.BufferData(BufferTarget.ArrayBuffer, (uint)rawData.Length * sizeof(float), rawData, BufferUsage.StaticDraw);
        }
    }
}