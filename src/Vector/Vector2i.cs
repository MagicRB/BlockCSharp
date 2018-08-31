using GlmNet;

namespace BlockCSharp
{
    public class Vector2i
    {
        public int X;
        public int Y;

        public Vector2i()
        {
            X = 0;
            Y = 0;
        }

        public Vector2i(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static implicit operator vec2(Vector2i v)
        {
            return new vec2(v.X, v.Y);
        }

        public override string ToString()
        {
            return "[" + X + ", " + Y + "]";
        }

        public static Vector2i operator +(Vector2i b, Vector2i c)
        {
            return new Vector2i(b.X + c.X, b.Y + c.Y);
        }

        public static Vector2i operator -(Vector2i b, Vector2i c)
        {
            return new Vector2i(b.X - c.X, b.Y - c.Y);
        }

        public static Vector2i operator *(Vector2i b, Vector2i c)
        {
            return new Vector2i(b.X * c.X, b.Y * c.Y);
        }

        public static Vector2i operator /(Vector2i b, Vector2i c)
        {
            return new Vector2i(b.X / c.X, b.Y / c.Y);
        }

        public static bool operator ==(Vector2i b, Vector2i c)
        {
            return Equals(b, c);
        }

        public static bool operator !=(Vector2i b, Vector2i c)
        {
            return !Equals(b, c);
        }

        protected bool Equals(Vector2i other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Vector2i) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }
}