namespace BlockCSharp
{
    public class Vector2
    {
        public float X;
        public float Y;
        
        public Vector2()
        {
            X = 0;
            Y = 0;
        }
        
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return "[" + X + ", " + Y + "]";
        }
        
        public static Vector2 operator +(Vector2 b, Vector2 c)
        {
            return new Vector2(b.X + c.X, b.Y + c.Y);
        }
        
        public static Vector2 operator -(Vector2 b, Vector2 c)
        {
            return new Vector2(b.X - c.X, b.Y - c.Y);
        }
        
        public static Vector2 operator *(Vector2 b, Vector2 c)
        {
            return new Vector2(b.X * c.X, b.Y * c.Y);
        }
        
        public static Vector2 operator /(Vector2 b, Vector2 c)
        {
            return new Vector2(b.X / c.X, b.Y / c.Y);
        }

        public static bool operator ==(Vector2 b, Vector2 c)
        {
            return Equals(b, c);
        }
        
        public static bool operator !=(Vector2 b, Vector2 c)
        {
            return !Equals(b, c);
        }

        protected bool Equals(Vector2 other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Vector2) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
            }
        }
    }
}