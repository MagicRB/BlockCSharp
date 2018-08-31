using BlockCSharp.Attributes;
using BlockCSharp.BaseClasses;
using BlockCSharp.Interfaces;

namespace BlockCSharp
{
    public static class Registries
    {
        public static TypeRegistry<Block, BlockAttribute> BlockRegistry = new TypeRegistry<Block, BlockAttribute>();
        public static TypeRegistry<Entity, EntityAttribute> EntityRegistry = new TypeRegistry<Entity, EntityAttribute>();
        public static ObjectRegistry<IScreen, ScreenAttribute> ScreenRegistry = new ObjectRegistry<IScreen, ScreenAttribute>();
    }
}