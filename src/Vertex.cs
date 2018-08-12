

namespace BlockCSharp
{
    public class Vertex
    {
        public Vector3 Position;
        public Color4 Color;
        public Vector2 UV;
        public float RenderType;
        
        public Vertex()
        {
            Position = new Vector3();
            Color = new Color4();
            UV = new Vector2();
        }

        public Vertex(Vector3 position, Color4 color, Vector2 uv, float renderType)
        {
            Position = position;
            Color = color;
            UV = uv;
            RenderType = renderType;
        }

        public override string ToString()
        {
            return "[" + Position + "; " + Color + "; " + UV + ";" + RenderType + "]";
        }
    }
}