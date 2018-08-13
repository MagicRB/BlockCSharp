using OpenTK.Graphics.OpenGL4;

namespace BlockCSharp.OpenGLAdditions
{
    public class IndexBuffer
    {
        public uint Id;
        
        public void Create()
        {
            GL.GenBuffers(1, out Id);
        }

        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, Id);
        }

        public void SetData(uint[] rawData)
        {
            GL.BufferData(BufferTarget.ElementArrayBuffer, rawData.Length * sizeof(uint), rawData, BufferUsageHint.StaticDraw);
        }
    }
}