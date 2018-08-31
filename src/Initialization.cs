using System.Reflection;

namespace BlockCSharp
{
    public static class Initialization
    {
        public static void Start()
        {
            _loadMods();
            _populateRegistries();
            _getAttributes();

            _preInit();
            _init();
            _postInit();
        }

        private static void _loadMods()
        {
        }

        private static void _getAttributes()
        {
            
        }

        private static void _populateRegistries()
        {
            Registries.BlockRegistry.Populate(new []{ Assembly.GetExecutingAssembly()});
            Registries.EntityRegistry.Populate(new []{ Assembly.GetExecutingAssembly()});
            Registries.ScreenRegistry.Populate(new []{ Assembly.GetExecutingAssembly()});
        }

        private static void _preInit()
        {
        }

        private static void _init()
        {
        }

        private static void _postInit()
        {
        }
    }
}