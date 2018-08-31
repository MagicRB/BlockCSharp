namespace BlockCSharp.BaseClasses
{
    public abstract class Entity
    {
        protected Vector3 _position = new Vector3();
        protected Vector3 _rotation = new Vector3();

        public abstract void Start(Vector3 entityPosition, Vector3 entityRotation);
        public abstract void Update(Block updater);

        public abstract void Translate(Vector3 moveVector);
        public abstract void Rotate(Vector3 rotateVector);
    }
}