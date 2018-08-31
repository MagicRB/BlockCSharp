namespace BlockCSharp.BaseClasses
{
    public abstract class Block
    {
        public bool Opaque = false;
        public Vector3i Position = new Vector3i();

        public abstract void Start(Vector3i blockPosition);
        public abstract void Update(Block updater);
    }
}