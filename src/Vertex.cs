namespace BlockCSharp
{
    public class Vertex
    {
        public Color4 Color;
        public Vector3 Position;
        public float RenderType;
        public Vector2 UV;

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