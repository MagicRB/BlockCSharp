namespace BlockCSharp.OpenGLAdditions
{
    public static class RawDataCreation
    {
        public static float[] GenRawVertexData(Vertex[] vertices)
        {
            float[] rawData = new float[vertices.Length * 10];

            int i = 0;
            
            foreach (var vertex in vertices)
            {
                rawData[i + 0] = vertex.Position.X;
                rawData[i + 1] = vertex.Position.Y;
                rawData[i + 2] = vertex.Position.Z;
                rawData[i + 3] = vertex.Color.R;
                rawData[i + 4] = vertex.Color.G;
                rawData[i + 5] = vertex.Color.B;
                rawData[i + 6] = vertex.Color.A;
                rawData[i + 7] = vertex.UV.X;
                rawData[i + 8] = vertex.UV.Y;
                rawData[i + 9] = vertex.RenderType;
                
                i += 10;
            }

            return rawData;
        }
    }
}