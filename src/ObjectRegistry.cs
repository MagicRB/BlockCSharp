using System;
using System.Collections.Generic;
using System.Reflection;
using BlockCSharp.BaseClasses;

namespace BlockCSharp
{
    public class ObjectRegistry<T, A> where A : RegistryAttribute
    {
        private Dictionary<RegistryKey, object> _registry = new Dictionary<RegistryKey, object>();

        public void Add(RegistryKey registryKey, T obj)
        {
            _registry.Add(registryKey, obj);
        }

        public void Add(string compressedName, object obj)
        {
            RegistryKey registryKey = new RegistryKey(compressedName);
            
            _registry.Add(registryKey, obj);
        }

        public object Get(RegistryKey registryKey)
        {
            return _registry[registryKey];
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
                            Add(registryAttribute.SRegistryKey, Activator.CreateInstance(type));
                        }
                    }
                }
            }
        }
    }
}