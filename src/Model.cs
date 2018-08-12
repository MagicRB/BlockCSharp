using System;
using GlmNet;

namespace BlockCSharp
{
    public class Model
    {
        public Vertex[] Vertices;
        public uint VertexCount;
        public uint[] Elements;
        public uint ElementCount;

        public int TriangleCount;
        
        public override string ToString()
        {
            String vertices = String.Empty;

            for (int i = 0; i < VertexCount; i++)
            {
                vertices += Vertices[i] + "; ";
            }
            
            String elements = String.Empty;

            for (int i = 0; i < ElementCount; i++)
            {
                elements += Elements[i] + "; ";
            }

            elements = elements.TrimEnd().TrimEnd();
            vertices = vertices.TrimEnd().TrimEnd();
            
            String str = VertexCount + ": {" + vertices + "}\n" + ElementCount + ": {" + elements + "}\n";

            return str;
        }
    }
}