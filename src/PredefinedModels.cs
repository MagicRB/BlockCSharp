using System.Collections;

namespace BlockCSharp
{
    public static class PredefinedModels
    {
        public static Model SimpleCubeModel(Vector3i blockPosition, BitArray opaqueBlocks, int renderType = 1,
            Color4 color = null)
        {
            if (color == null) color = new Color4(0.0f, 1.0f, 0.0f, 0.0f);

            var model = new Model();

            for (var i = 0; i < 6; i++)
                if (!opaqueBlocks[i])
                {
                    model.VertexCount += 4;
                    model.ElementCount += 6;
                }

            model.Vertices = new Vertex[model.VertexCount];
            model.Elements = new uint[model.ElementCount];

            uint index = 0;

            // X Positive
            if (!opaqueBlocks[0])
            {
                model.Vertices[index * 4 + 0] =
                    new Vertex(new Vector3(blockPosition.X + 0.5f, blockPosition.Y - 0.5f, blockPosition.Z - 0.5f),
                        color, new Vector2(0.0f, 0.0f), renderType);
                model.Vertices[index * 4 + 1] =
                    new Vertex(new Vector3(blockPosition.X + 0.5f, blockPosition.Y - 0.5f, blockPosition.Z + 0.5f),
                        color, new Vector2(0.0f, 0.0f), renderType);
                model.Vertices[index * 4 + 2] =
                    new Vertex(new Vector3(blockPosition.X + 0.5f, blockPosition.Y + 0.5f, blockPosition.Z + 0.5f),
                        color, new Vector2(0.0f, 0.0f), renderType);
                model.Vertices[index * 4 + 3] =
                    new Vertex(new Vector3(blockPosition.X + 0.5f, blockPosition.Y + 0.5f, blockPosition.Z - 0.5f),
                        color, new Vector2(0.0f, 0.0f), renderType);

                model.Elements[index * 6 + 0] = index * 4 + 2;
                model.Elements[index * 6 + 1] = index * 4 + 1;
                model.Elements[index * 6 + 2] = index * 4 + 0;
                model.Elements[index * 6 + 3] = index * 4 + 3;
                model.Elements[index * 6 + 4] = index * 4 + 2;
                model.Elements[index * 6 + 5] = index * 4 + 0;

                index++;
            }

            // X Negative
            if (!opaqueBlocks[1])
            {
                model.Vertices[index * 4 + 0] =
                    new Vertex(new Vector3(blockPosition.X - 0.5f, blockPosition.Y - 0.5f, blockPosition.Z - 0.5f),
                        color, new Vector2(0.0f, 0.0f), renderType);
                model.Vertices[index * 4 + 1] =
                    new Vertex(new Vector3(blockPosition.X - 0.5f, blockPosition.Y - 0.5f, blockPosition.Z + 0.5f),
                        color, new Vector2(0.0f, 0.0f), renderType);
                model.Vertices[index * 4 + 2] =
                    new Vertex(new Vector3(blockPosition.X - 0.5f, blockPosition.Y + 0.5f, blockPosition.Z + 0.5f),
                        color, new Vector2(0.0f, 0.0f), renderType);
                model.Vertices[index * 4 + 3] =
                    new Vertex(new Vector3(blockPosition.X - 0.5f, blockPosition.Y + 0.5f, blockPosition.Z - 0.5f),
                        color, new Vector2(0.0f, 0.0f), renderType);

                model.Elements[index * 6 + 0] = index * 4 + 0;
                model.Elements[index * 6 + 1] = index * 4 + 1;
                model.Elements[index * 6 + 2] = index * 4 + 2;
                model.Elements[index * 6 + 3] = index * 4 + 0;
                model.Elements[index * 6 + 4] = index * 4 + 2;
                model.Elements[index * 6 + 5] = index * 4 + 3;

                index++;
            }

            // Y Positive
            if (!opaqueBlocks[2])
            {
                model.Vertices[index * 4 + 0] =
                    new Vertex(new Vector3(blockPosition.X - 0.5f, blockPosition.Y + 0.5f, blockPosition.Z - 0.5f),
                        color, new Vector2(0.0f, 0.0f), renderType);
                model.Vertices[index * 4 + 1] =
                    new Vertex(new Vector3(blockPosition.X - 0.5f, blockPosition.Y + 0.5f, blockPosition.Z + 0.5f),
                        color, new Vector2(0.0f, 0.0f), renderType);
                model.Vertices[index * 4 + 2] =
                    new Vertex(new Vector3(blockPosition.X + 0.5f, blockPosition.Y + 0.5f, blockPosition.Z + 0.5f),
                        color, new Vector2(0.0f, 0.0f), renderType);
                model.Vertices[index * 4 + 3] =
                    new Vertex(new Vector3(blockPosition.X + 0.5f, blockPosition.Y + 0.5f, blockPosition.Z - 0.5f),
                        color, new Vector2(0.0f, 0.0f), renderType);

                model.Elements[index * 6 + 0] = index * 4 + 0;
                model.Elements[index * 6 + 1] = index * 4 + 1;
                model.Elements[index * 6 + 2] = index * 4 + 2;
                model.Elements[index * 6 + 3] = index * 4 + 0;
                model.Elements[index * 6 + 4] = index * 4 + 2;
                model.Elements[index * 6 + 5] = index * 4 + 3;

                index++;
            }

            // Y Negative
            if (!opaqueBlocks[3])
            {
                model.Vertices[index * 4 + 0] =
                    new Vertex(new Vector3(blockPosition.X - 0.5f, blockPosition.Y - 0.5f, blockPosition.Z - 0.5f),
                        color, new Vector2(0.0f, 0.0f), renderType);
                model.Vertices[index * 4 + 1] =
                    new Vertex(new Vector3(blockPosition.X - 0.5f, blockPosition.Y - 0.5f, blockPosition.Z + 0.5f),
                        color, new Vector2(0.0f, 0.0f), renderType);
                model.Vertices[index * 4 + 2] =
                    new Vertex(new Vector3(blockPosition.X + 0.5f, blockPosition.Y - 0.5f, blockPosition.Z + 0.5f),
                        color, new Vector2(0.0f, 0.0f), renderType);
                model.Vertices[index * 4 + 3] =
                    new Vertex(new Vector3(blockPosition.X + 0.5f, blockPosition.Y - 0.5f, blockPosition.Z - 0.5f),
                        color, new Vector2(0.0f, 0.0f), renderType);

                model.Elements[index * 6 + 0] = index * 4 + 2;
                model.Elements[index * 6 + 1] = index * 4 + 1;
                model.Elements[index * 6 + 2] = index * 4 + 0;
                model.Elements[index * 6 + 3] = index * 4 + 3;
                model.Elements[index * 6 + 4] = index * 4 + 2;
                model.Elements[index * 6 + 5] = index * 4 + 0;

                index++;
            }


            // Z Positive
            if (!opaqueBlocks[4])
            {
                model.Vertices[index * 4 + 0] =
                    new Vertex(new Vector3(blockPosition.X - 0.5f, blockPosition.Y - 0.5f, blockPosition.Z + 0.5f),
                        color, new Vector2(0.0f, 0.0f), renderType);
                model.Vertices[index * 4 + 1] =
                    new Vertex(new Vector3(blockPosition.X - 0.5f, blockPosition.Y + 0.5f, blockPosition.Z + 0.5f),
                        color, new Vector2(0.0f, 0.0f), renderType);
                model.Vertices[index * 4 + 2] =
                    new Vertex(new Vector3(blockPosition.X + 0.5f, blockPosition.Y + 0.5f, blockPosition.Z + 0.5f),
                        color, new Vector2(0.0f, 0.0f), renderType);
                model.Vertices[index * 4 + 3] =
                    new Vertex(new Vector3(blockPosition.X + 0.5f, blockPosition.Y - 0.5f, blockPosition.Z + 0.5f),
                        color, new Vector2(0.0f, 0.0f), renderType);

                model.Elements[index * 6 + 0] = index * 4 + 2;
                model.Elements[index * 6 + 1] = index * 4 + 1;
                model.Elements[index * 6 + 2] = index * 4 + 0;
                model.Elements[index * 6 + 3] = index * 4 + 3;
                model.Elements[index * 6 + 4] = index * 4 + 2;
                model.Elements[index * 6 + 5] = index * 4 + 0;

                index++;
            }

            // Z Negative
            if (!opaqueBlocks[5])
            {
                model.Vertices[index * 4 + 0] =
                    new Vertex(new Vector3(blockPosition.X - 0.5f, blockPosition.Y - 0.5f, blockPosition.Z - 0.5f),
                        color, new Vector2(0.0f, 0.0f), renderType);
                model.Vertices[index * 4 + 1] =
                    new Vertex(new Vector3(blockPosition.X - 0.5f, blockPosition.Y + 0.5f, blockPosition.Z - 0.5f),
                        color, new Vector2(0.0f, 0.0f), renderType);
                model.Vertices[index * 4 + 2] =
                    new Vertex(new Vector3(blockPosition.X + 0.5f, blockPosition.Y + 0.5f, blockPosition.Z - 0.5f),
                        color, new Vector2(0.0f, 0.0f), renderType);
                model.Vertices[index * 4 + 3] =
                    new Vertex(new Vector3(blockPosition.X + 0.5f, blockPosition.Y - 0.5f, blockPosition.Z - 0.5f),
                        color, new Vector2(0.0f, 0.0f), renderType);

                model.Elements[index * 6 + 0] = index * 4 + 0;
                model.Elements[index * 6 + 1] = index * 4 + 1;
                model.Elements[index * 6 + 2] = index * 4 + 2;
                model.Elements[index * 6 + 3] = index * 4 + 0;
                model.Elements[index * 6 + 4] = index * 4 + 2;
                model.Elements[index * 6 + 5] = index * 4 + 3;

                index++;
            }

            return model;
        }
    }
}