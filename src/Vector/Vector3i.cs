namespace BlockCSharp
{
    public class Vector3i
    {
        public int X;
        public int Y;
        public int Z;
        
        public Vector3i()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }
        
        public Vector3i(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return "[" + X + ", " + Y + ", " + Z + "]";
        }
        
        public static Vector3i operator +(Vector3i b, Vector3i c)
        {
            return new Vector3i(b.X + c.X, b.Y + c.Y, b.Z + c.Z);
        }
        
        public static Vector3i operator -(Vector3i b, Vector3i c)
        {
            return new Vector3i(b.X - c.X, b.Y - c.Y, b.Z - c.Z);
        }
        
        public static Vector3i operator *(Vector3i b, Vector3i c)
        {
            return new Vector3i(b.X * c.X, b.Y * c.Y, b.Z * c.Z);
        }
        
        public static Vector3i operator /(Vector3i b, Vector3i c)
        {
            return new Vector3i(b.X / c.X, b.Y / c.Y, b.Z / c.Z);
        }

        public static bool operator ==(Vector3i b, Vector3i c)
        {
            return Equals(b, c);
        }
        
        public static bool operator !=(Vector3i b, Vector3i c)
        {
            return !Equals(b, c);
        }

        protected bool Equals(Vector3i other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Vector3i) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X;
                hashCode = (hashCode * 397) ^ Y;
                hashCode = (hashCode * 397) ^ Z;
                return hashCode;
            }
        }
    }
}