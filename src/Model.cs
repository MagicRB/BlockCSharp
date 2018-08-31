namespace BlockCSharp
{
    public class Model
    {
        public uint ElementCount;
        public uint[] Elements;

        public int TriangleCount;
        public uint VertexCount;
        public Vertex[] Vertices;

        public override string ToString()
        {
            var vertices = string.Empty;

            for (var i = 0; i < VertexCount; i++) vertices += Vertices[i] + "; ";

            var elements = string.Empty;

            for (var i = 0; i < ElementCount; i++) elements += Elements[i] + "; ";

            elements = elements.TrimEnd().TrimEnd();
            vertices = vertices.TrimEnd().TrimEnd();

            var str = VertexCount + ": {" + vertices + "}\n" + ElementCount + ": {" + elements + "}\n";

            return str;
        }
    }
}