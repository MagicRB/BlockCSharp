namespace BlockCSharp
{
    public class Vector4
    {
        public float X;
        public float Y;
        public float Z;
        public float W;
        
        public Vector4()
        {
            X = 0;
            Y = 0;
            Z = 0;
            W = 0;
        }
        
        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public override string ToString()
        {
            return "[" + X + ", " + Y + ", " + Z + ", " + W + "]";
        }
        
        public static Vector4 operator +(Vector4 b, Vector4 c)
        {
            return new Vector4(b.X + c.X, b.Y + c.Y, b.Z + c.Z, b.W + c.W);
        }
        
        public static Vector4 operator -(Vector4 b, Vector4 c)
        {
            return new Vector4(b.X - c.X, b.Y - c.Y, b.Z - c.Z, b.W - c.W);
        }
        
        public static Vector4 operator *(Vector4 b, Vector4 c)
        {
            return new Vector4(b.X * c.X, b.Y * c.Y, b.Z * c.Z, b.W * c.W);
        }
        
        public static Vector4 operator /(Vector4 b, Vector4 c)
        {
            return new Vector4(b.X / c.X, b.Y / c.Y, b.Z / c.Z, b.W / c.W);
        }

        public static bool operator ==(Vector4 b, Vector4 c)
        {
            return Equals(b, c);
        }
        
        public static bool operator !=(Vector4 b, Vector4 c)
        {
            return !Equals(b, c);
        }

        protected bool Equals(Vector4 other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z) && W.Equals(other.W);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Vector4) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                hashCode = (hashCode * 397) ^ W.GetHashCode();
                return hashCode;
            }
        }
    }
}