using System;
using System.Collections.Generic;
using System.Reflection;
using BlockCSharp.BaseClasses;

namespace BlockCSharp
{
    public class TypeRegistry<T, A> where A : RegistryAttribute
    {
        private Dictionary<RegistryKey, Type> _registry = new Dictionary<RegistryKey, Type>();
        private Dictionary<Type, RegistryKey> _reverseRegistry = new Dictionary<Type, RegistryKey>();

        public void Add(RegistryKey registryKey, Type type)
        {
            _registry.Add(registryKey, type);
            _reverseRegistry.Add(type, registryKey);
        }

        public void Add(string compressedName, Type type)
        {
            RegistryKey registryKey = new RegistryKey(compressedName);
            
            _registry.Add(registryKey, type);
            _reverseRegistry.Add(type, registryKey);
        }

        public Type Get(RegistryKey registryKey)
        {
            return _registry[registryKey];
        }

        public RegistryKey Get(Type type)
        {
            return _reverseRegistry[type];
        }

        public void Populate(Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (typeof(T).IsAssignableFrom(type))
                    {
                        RegistryAttribute registryAttribute = type.GetCustomAttribute<A>();
                        if (registryAttribute != null)
                        {
                            Console.WriteLine(registryAttribute.SRegistryKey);
                            Add(registryAttribute.SRegistryKey, type);
                        }
                    }
                }
            }
        }
    }
}