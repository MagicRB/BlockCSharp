using System;
using BlockCSharp.Blocks;
using BlockCSharp.OpenGLAdditions;
using GlmNet;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;

namespace BlockCSharp
{
    public class BlockSharp : GameWindow
    {
        private Shader _vertexShader = new Shader();
        private Shader _fragmentShader = new Shader();
        private int _shaderProgramId = 0;

        private int _vertexArrayId = 0;

        private mat4 _viewProjectionMatrix = glm.ortho(1,1,1,1);

        private vec3 _cameraPosition = new vec3(0, 0, 0);
        private vec2 _cameraYZRotation = new vec2(0, 0);
            
        bool _updateViewMatrix = true;
        
        public BlockSharp()
        {
            Width = 640;
            Height = 480;
        }
        
        void OpenGlSetup()
        {
            _vertexArrayId = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayId);
            
            _vertexShader.Create(ShaderType.VertexShader,       "#version 330 core\n" +
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
            
            _fragmentShader.Create(ShaderType.FragmentShader,     "#version 330 core\n" +
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
        
        protected override void OnLoad(EventArgs e)
        {
            OpenGlSetup();
            
            World.World.AddChunk(new Vector2i(0, 0));
            World.World.AddChunk(new Vector2i(-1, 0));
            
            World.World.SetBlock(new Vector3i(0, 0, 0), typeof(TestBlock));
            //World.World.SetBlock(new Vector3i(1, 0, 0), typeof(TestBlock));
            //World.World.SetBlock(new Vector3i(1, 1, 0), typeof(TestBlock));
            //World.World.SetBlock(new Vector3i(0, 1, 0), typeof(TestBlock));
            
            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.ClearColor(0.0f, 1.0f, 1.0f, 0);
                    
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.UseProgram(_shaderProgramId);

            int viewProjectionMatrixId = GL.GetUniformLocation(_shaderProgramId, "viewProjection"); 
                    
            Title = "aaa";
                    
            foreach (var chunk in World.World.Chunks.Values)
            {
                GL.UniformMatrix4(viewProjectionMatrixId, 1, false, ref _viewProjectionMatrix.to_array()[0]);

                chunk.Render();
            }
            
            SwapBuffers();
            
            base.OnRenderFrame(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            if (World.World.ChunkUpdateQueue.Count != 0)
                World.World.ChunkUpdateQueue.Pop().ChunkUpdate();

            if (_updateViewMatrix)
            {
                _viewProjectionMatrix = glm.perspective(glm.radians(90), 4.0f / 3.0f, 0.1f, 100.0f) * glm.translate(mat4.identity(), _cameraPosition);
                Console.WriteLine(_cameraPosition.z);
                _updateViewMatrix = false;
            }

            base.OnUpdateFrame(e);
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.S:
                {
                    _cameraPosition += new vec3(0, 0, 0.1f);
                    _updateViewMatrix = true;
                    break;   
                }
                case Key.W:
                {
                    _cameraPosition += new vec3(0, 0, -0.1f);
                    _updateViewMatrix = true;
                    break;
                }
                case Key.A:
                {
                    _cameraPosition += new vec3(0.1f, 0, 0);
                    _updateViewMatrix = true;
                    break;   
                }
                case Key.D:
                {
                    _cameraPosition += new vec3(-0.1f, 0, 0);
                    _updateViewMatrix = true;
                    break;
                }
                case Key.Space:
                {
                    _cameraPosition += new vec3(0, -0.1f, 0);
                    _updateViewMatrix = true;
                    break;   
                }
                case Key.ShiftLeft:
                {
                    _cameraPosition += new vec3(0, 0.1f, 0);
                    _updateViewMatrix = true;
                    break;
                }
                case Key.Up:
                {
                    _cameraYZRotation += new vec2(0, 1f);
                    _updateViewMatrix = true;
                    break;   
                }
                case Key.Down:
                {
                    _cameraYZRotation += new vec2(0, 1f);
                    _updateViewMatrix = true;
                    break;
                }
                case Key.Left:
                {
                    _cameraYZRotation += new vec2(1f, 0);
                    _updateViewMatrix = true;
                    break;   
                }
                case Key.Right:
                {
                    _cameraYZRotation += new vec2(1f, 0);
                    _updateViewMatrix = true;
                    break;
                }
            }
            
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyboardKeyEventArgs e)
        {
            base.OnKeyUp(e);
        }
    }
}