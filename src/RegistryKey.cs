using System;

namespace BlockCSharp
{
    public class RegistryKey
    {
        public string Type;
        public string Namespace;
        public string Name;
        
        public RegistryKey(string compressedName)
        {
            string[] split = compressedName.Split(':');

            if (split.Length == 3)
            {
                Type = split[0];
                Namespace = split[1];
                Name = split[2];
            }
            else
            {
                Type = "null";
                Namespace = "null";
                Name = "null";
            }
        }

        public RegistryKey(string assembly, string nameSpace, string name)
        {
            Type = assembly;
            Namespace = nameSpace;
            Name = name;
        }

        public string GetCompressedName()
        {
            return Type + ':' + Namespace + ":" + Name;
        }

        protected bool Equals(RegistryKey other)
        {
            return string.Equals(Type, other.Type) && string.Equals(Namespace, other.Namespace) && string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RegistryKey) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Type != null ? Type.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Namespace != null ? Namespace.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}