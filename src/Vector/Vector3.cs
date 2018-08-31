using GlmNet;

namespace BlockCSharp
{
    public class Vector3
    {
        public float X;
        public float Y;
        public float Z;

        public Vector3()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static implicit operator vec3(Vector3 v)
        {
            return new vec3(v.X, v.Y, v.Z);
        }
        
        public static implicit operator OpenTK.Vector3(Vector3 v)
        {
            return new OpenTK.Vector3(v.X, v.Y, v.Z);
        }

        public override string ToString()
        {
            return "[" + X + ", " + Y + ", " + Z + ", " + "]";
        }

        public static Vector3 operator +(Vector3 b, Vector3 c)
        {
            return new Vector3(b.X + c.X, b.Y + c.Y, b.Z + c.Z);
        }

        public static Vector3 operator -(Vector3 b, Vector3 c)
        {
            return new Vector3(b.X - c.X, b.Y - c.Y, b.Z - c.Z);
        }

        public static Vector3 operator *(Vector3 b, Vector3 c)
        {
            return new Vector3(b.X * c.X, b.Y * c.Y, b.Z * c.Z);
        }

        public static Vector3 operator /(Vector3 b, Vector3 c)
        {
            return new Vector3(b.X / c.X, b.Y / c.Y, b.Z / c.Z);
        }

        public static bool operator ==(Vector3 b, Vector3 c)
        {
            return Equals(b, c);
        }

        public static bool operator !=(Vector3 b, Vector3 c)
        {
            return !Equals(b, c);
        }

        protected bool Equals(Vector3 other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Vector3) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                return hashCode;
            }
        }
    }
}