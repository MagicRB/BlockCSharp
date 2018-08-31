using System;

namespace BlockCSharp.BaseClasses
{
    public class RegistryAttribute : Attribute
    {
        public string SRegistryKey { get; set; }
    }
}