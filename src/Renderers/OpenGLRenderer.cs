using BlockCSharp.BaseClasses;
using BlockCSharp.Entities;
using BlockCSharp.OpenGLAdditions;
using OpenTK.Graphics.OpenGL4;

namespace BlockCSharp.Renderers
{
    public class OpenGLRenderer : Renderer
    {
        private readonly Shader _fragmentShader = new Shader();

        private readonly Player _localPlayer;
        private int _shaderProgramId;

        private int _vertexArrayId;
        private readonly Shader _vertexShader = new Shader();

        public OpenGLRenderer(Player localPlayer)
        {
            _localPlayer = localPlayer;
        }

        public override void Setup()
        {
            _vertexArrayId = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayId);

            _vertexShader.Create(ShaderType.VertexShader, "#version 330 core\n" +
                                                          "layout(location = 0) in vec3 position;\n" +
                                                          "layout(location = 1) in vec4 color;\n" +
                                                          "layout(location = 2) in vec2 uv_position;\n" +
                                                          "layout(location = 3) in int render_type;\n" +
                                                          "\n" +
                                                          "uniform mat4 viewProjection;\n" +
                                                          "\n" +
                                                          "out vec4 frag_color;\n" +
                                                          "out vec2 uv;\n" +
                                                          "\n" +
                                                          "void main() {\n" +
                                                          "    gl_Position = viewProjection * vec4(position, 1.0);\n" +
                                                          "    frag_color = color;\n" +
                                                          "}");

            _fragmentShader.Create(ShaderType.FragmentShader, "#version 330 core\n" +
                                                              "in vec4 frag_color;" +
                                                              "in vec2 uv;\n" +
                                                              "\n" +
                                                              "out vec4 color;\n" +
                                                              "\n" +
                                                              "void main() {\n" +
                                                              "    color = frag_color;\n" +
                                                              "}");

            _shaderProgramId = GL.CreateProgram();
            GL.AttachShader(_shaderProgramId, _vertexShader.Id);
            GL.AttachShader(_shaderProgramId, _fragmentShader.Id);

            //  Now we can link the program.
            GL.LinkProgram(_shaderProgramId);
        }

        public override void RenderFrame()
        {
            GL.ClearColor(0.0f, 1.0f, 1.0f, 0);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.UseProgram(_shaderProgramId);

            var viewProjectionMatrixId = GL.GetUniformLocation(_shaderProgramId, "viewProjection");

            foreach (var chunk in World.World.Chunks.Values)
            {
                GL.UniformMatrix4(viewProjectionMatrixId, false,
                    ref _localPlayer.ViewProjectionMatrix);

                chunk.Render();
            }
        }
    }
}