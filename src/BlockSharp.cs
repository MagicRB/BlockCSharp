using System;
using BlockCSharp.BaseClasses;
using BlockCSharp.Entities;
using BlockCSharp.GUIs;
using BlockCSharp.Renderers;
using OpenTK;
using OpenTK.Input;

namespace BlockCSharp
{
    public class BlockSharp : GameWindow
    {
        private readonly Player _localPlayer = new Player();

        private Renderer _renderer;

        public BlockSharp()
        {
            Width = 640;
            Height = 480;
        }

        protected override void OnLoad(EventArgs e)
        {
            _renderer = new OpenGLRenderer(_localPlayer);
            _renderer.Setup();
            
            Initialization.Start();
            
            _localPlayer.Start(new Vector3(0, 0, 0), new Vector3(0, 0, 0));
            _localPlayer.CurrentScreen = Registries.ScreenRegistry.Get(new RegistryKey("screen:blockcsharp:in_world_gui")) as InWorldGUI;
            
            World.World.AddChunk(new Vector2i(0, 0));
            World.World.AddChunk(new Vector2i(-1, 0));

            World.World.SetBlock(new Vector3i(0, 0, 0), Registries.BlockRegistry.Get(new RegistryKey("block:blockcsharp:test_block")));
            //World.World.SetBlock(new Vector3i(1, 0, 0), typeof(TestBlock));
            //World.World.SetBlock(new Vector3i(1, 1, 0), typeof(TestBlock));
            //World.World.SetBlock(new Vector3i(0, 1, 0), typeof(TestBlock));

            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            _renderer.RenderFrame();

            SwapBuffers();

            base.OnRenderFrame(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            if (World.World.ChunkUpdateQueue.Count != 0)
                World.World.ChunkUpdateQueue.Pop().ChunkUpdate();

            base.OnUpdateFrame(e);
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            _localPlayer.CurrentScreen.KeyDictionary[e.Key](e);
        }

        protected override void OnKeyUp(KeyboardKeyEventArgs e)
        {
            _localPlayer.CurrentScreen.KeyDictionary[e.Key](e);
        }
    }
}