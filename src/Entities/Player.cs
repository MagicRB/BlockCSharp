using System;
using BlockCSharp.Attributes;
using BlockCSharp.BaseClasses;
using BlockCSharp.GUIs;
using BlockCSharp.Interfaces;
using GlmNet;
using OpenTK;
using OpenTK.Input;

namespace BlockCSharp.Entities
{
    [Entity(SRegistryKey = "entity:blockcsharp:player")]
    public class Player : Entity, ITickable
    {
        public Matrix4 ViewProjectionMatrix;

        public IScreen CurrentScreen;

        public Vector3 Position
        {
            get => _position;
            set => _position = value;
        }

        public Vector3 Rotation
        {
            get => _rotation;
            set => _rotation = value;
        }

        public void Tick()
        {
        }

        public override void Translate(Vector3 moveVector)
        {
            _position += moveVector;

            UpdateViewMatrix();
        }

        public override void Rotate(Vector3 rotateVector)
        {
            _rotation += rotateVector;

            if (_rotation.X > 360) _rotation.X -= 360;
            if (_rotation.Y > 360) _rotation.Y -= 360;
            if (_rotation.Z > 360) _rotation.Z -= 360;

            UpdateViewMatrix();
        }

        public override void Start(Vector3 entityPosition, Vector3 entityRotation)
        {
            UpdateViewMatrix();

            InWorldGUI inWorldGui = Registries.ScreenRegistry.Get(new RegistryKey("screen:blockcsharp:in_world_gui")) as InWorldGUI;
            inWorldGui.KeyDictionary.Add(Key.W, OnKeyDown);
            inWorldGui.KeyDictionary.Add(Key.A, OnKeyDown);
            inWorldGui.KeyDictionary.Add(Key.S, OnKeyDown);
            inWorldGui.KeyDictionary.Add(Key.D, OnKeyDown);
        }

        public override void Update(Block updater)
        {
        }

        public void UpdateViewMatrix()
        {
            Console.WriteLine(Position);
            
            ViewProjectionMatrix = Matrix4.CreatePerspectiveFieldOfView(OpenTK.MathHelper.DegreesToRadians(90.0f), 4.0f / 3.0f, 0.1f, 100.0f) * Matrix4.LookAt(Position, new OpenTK.Vector3(0, 1, 0), new OpenTK.Vector3(0, 1, 0));
        }

        public int OnKeyDown(KeyboardKeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                    Translate(new Vector3(-0.1f, 0, 0));
                    break;
                case Key.A:
                    Translate(new Vector3(0, 0, -0.1f));
                    break;
                case Key.S:
                    Translate(new Vector3(0.1f, 0, 0));
                    break;
                case Key.D:
                    Translate(new Vector3(0, 0, 0.1f));
                    break;
                default:
                    break;
            }

            return 0;
        }
    }
}