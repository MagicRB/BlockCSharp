namespace BlockCSharp
{
    public class Color4
    {
        public float R;
        public float G;
        public float B;
        public float A;
        
        public Color4()
        {
            R = 0;
            G = 0;
            B = 0;
            A = 0;
        }

        public Color4(float r, float g, float b, float a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public override string ToString()
        {
            return "[" + R + ", " + G + ", " + B + ", " + A + "]";
        }

        public static Color4 operator +(Color4 b, Color4 c)
        {
            return new Color4(b.R + c.R, b.G + c.G, b.B + c.B, b.A + c.A);
        }
        
        public static Color4 operator -(Color4 b, Color4 c)
        {
            return new Color4(b.R - c.R, b.G - c.G, b.B - c.B, b.A - c.A);
        }
        
        public static Color4 operator *(Color4 b, Color4 c)
        {
            return new Color4(b.R * c.R, b.G * c.G, b.B * c.B, b.A * c.A);
        }
        
        public static Color4 operator /(Color4 b, Color4 c)
        {
            return new Color4(b.R / c.R, b.G / c.G, b.B / c.B, b.A / c.A);
        }

        public static bool operator ==(Color4 b, Color4 c)
        {
            return Equals(b, c);
        }
        
        public static bool operator !=(Color4 b, Color4 c)
        {
            return !Equals(b, c);
        }

        protected bool Equals(Color4 other)
        {
            return R.Equals(other.R) && G.Equals(other.G) && B.Equals(other.B) && A.Equals(other.A);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Color4) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = R.GetHashCode();
                hashCode = (hashCode * 397) ^ G.GetHashCode();
                hashCode = (hashCode * 397) ^ B.GetHashCode();
                hashCode = (hashCode * 397) ^ A.GetHashCode();
                return hashCode;
            }
        }
    }
}