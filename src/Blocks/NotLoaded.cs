using BlockCSharp.Attributes;
using BlockCSharp.BaseClasses;

namespace BlockCSharp.Blocks
{
    [Block(SRegistryKey = "block:blockcsharp:not_loaded")]
    public class NotLoaded : Block
    {
        public override void Start(Vector3i blockPosition)
        {
        }

        public override void Update(Block updater)
        {
        }
    }
}