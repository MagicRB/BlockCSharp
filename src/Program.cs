namespace BlockCSharp
{
    internal class Program
    {
//        private static double _graphicsFrameTime = 1000 / 30;
//        private static double _logicFrameTime = 1000 / 20;
//        
        private static BlockSharp _blockSharp;

//        private static Timer _graphicsTimer;
//        private static Timer _logicTimer;
//        
//        private static volatile bool _runGraphics;
//        private static volatile bool _runLogic;
//        
//        private static volatile int _graphicsRemainingTime = 1;
//        private static volatile int _logicRemainingTime = 1;

//        private static Shader _vertexShader = new Shader();
//        private static Shader _fragmentShader = new Shader();
//        private static int _shaderProgramId = 0;
//
//        private static int _vertexArrayId = 0;

//        private static Matrix4 _viewProjectionMatrix;

//        static void OpenGlSetup()
//        {
//            _vertexArrayId = GL.GenVertexArray();
//            GL.BindVertexArray(_vertexArrayId);
//            
//            _vertexShader.Create(ShaderType.VertexShader,       "#version 330 core\n" +
//                                                                "layout(location = 0) in vec3 position;\n" +
//                                                                "layout(location = 1) in vec4 color;\n" +
//                                                                "layout(location = 2) in vec2 uv_position;\n" +
//                                                                "layout(location = 3) in int render_type;\n" +
//                                                                "\n" +
//                                                                "uniform mat4 viewProjection;\n" +
//                                                                "\n" +
//                                                                "out vec4 frag_color;\n" +
//                                                                "out vec2 uv;\n" +
//                                                                "\n" +
//                                                                "void main() {\n" +
//                                                                "    gl_Position = viewProjection * vec4(position, 1.0);\n" +
//                                                                "    frag_color = color;\n" +
//                                                                "}");
//            
//            _fragmentShader.Create(ShaderType.FragmentShader,     "#version 330 core\n" +
//                                                                  "in vec4 frag_color;" +
//                                                                  "in vec2 uv;\n" +
//                                                                  "\n" +
//                                                                  "out vec4 color;\n" +
//                                                                  "\n" +
//                                                                  "void main() {\n" +
//                                                                  "    color = frag_color;\n" +
//                                                                  "}");
//            
//            _shaderProgramId = GL.CreateProgram();
//            GL.AttachShader(_shaderProgramId, _vertexShader.Id);
//            GL.AttachShader(_shaderProgramId, _fragmentShader.Id);
//            
//            //  Now we can link the program.
//            GL.LinkProgram(_shaderProgramId);
//        }
//
//        static void TimerSetup()
//        {
//            _graphicsTimer = new Timer();
//            _graphicsTimer.Interval = _graphicsFrameTime;
//            _graphicsTimer.AutoReset = true;
//            _graphicsTimer.Elapsed += GraphicsFrame;
//            
//            _graphicsTimer.Start();
//            
//            _logicTimer = new Timer();
//            _logicTimer.Interval = _logicFrameTime;
//            _logicTimer.AutoReset = true;
//            _logicTimer.Elapsed += LogicFrame;
//            
//            _logicTimer.Start();
//        }
//        
        private static void Main(string[] args)
        {
            _blockSharp = new BlockSharp();
            _blockSharp.Context.MakeCurrent(_blockSharp.WindowInfo);
            _blockSharp.Run(20, 60);

//            OpenGlSetup();

            //TimerSetup();

            //World.World.SetBlock(new Vector3i(-1, 0, 0), typeof(TestBlock));

//            _viewProjectionMatrix = Matrix4.CreatePerspectiveFieldOfView(90, 4.0f/3.0f, 0.1f, 100) * Matrix4.CreateTranslation(new OpenTK.Vector3(1, 0, 0)) * Matrix4.CreateRotationY(45);
//            
//            while (!_blockSharp.ShouldClose())
//            {
//                if (_runGraphics)
//                {
//                    Glfw.PollEvents();
//                    
//                    GL.ClearColor(0.0f, 1.0f, 1.0f, 0);
//                    
//                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
//
//                    GL.UseProgram(_shaderProgramId);
//
//                    int viewProjectionMatrixId = GL.GetUniformLocation(_shaderProgramId, "viewProjection"); 
//                    
//                    _blockSharp.Title = "Remaining Time: " + _graphicsRemainingTime + " Max Time: " + _graphicsFrameTime + " Fps: " + 1000 / _graphicsRemainingTime;
//                    
//                    foreach (var chunk in World.World.Chunks.Values)
//                    {
//                        GL.UniformMatrix4(viewProjectionMatrixId, false, ref _viewProjectionMatrix.);
//
//                        chunk.Render();
//                    }
//                    // Draw
//                    
//                    Glfw.SwapBuffers(_blockSharp);
//                    
//                    _runGraphics = false;
//                }
//                else if (_runLogic)
//                {
//                    if (World.World.ChunkUpdateQueue.Count != 0)
//                        World.World.ChunkUpdateQueue.Pop().ChunkUpdate();
//                    
//                    _runLogic = false;
//                }
//            }
        }

//        static void GraphicsFrame(Object source, ElapsedEventArgs e)
//        {
//            _runGraphics = true;
//
//            while (_runGraphics) {}
//            
//            _graphicsRemainingTime = (int)_graphicsFrameTime - (DateTime.Now.Millisecond - e.SignalTime.Millisecond);
//        }
//
//        static void LogicFrame(Object source, ElapsedEventArgs e)
//        {
//            _runLogic = true;
//            
//            while (_runLogic) {}
//            
//            _logicRemainingTime = (int)_logicFrameTime - (DateTime.Now.Millisecond - e.SignalTime.Millisecond);
//        }
    }
}