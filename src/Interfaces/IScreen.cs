using System;
using System.Collections.Generic;
using OpenTK.Input;

namespace BlockCSharp.Interfaces
{
    public interface IScreen
    {
        Dictionary<Key, Func<KeyboardKeyEventArgs, int>> KeyDictionary { get; set; }

        string Id { get; set; }
    }
}