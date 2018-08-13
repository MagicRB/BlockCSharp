using OpenTK.Graphics.OpenGL4;

namespace BlockCSharp.OpenGLAdditions
{
    public class VertexBuffer
    {
        public int Id;
        
        public void Create()
        {
            GL.GenBuffers(1, out Id);
        }

        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, Id);
        }

        public void SetData(float[] rawData)
        {
            GL.BufferData(BufferTarget.ArrayBuffer, rawData.Length * sizeof(float), rawData, BufferUsageHint.StaticDraw);
        }
    }
}