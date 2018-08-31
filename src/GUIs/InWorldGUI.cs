using System;
using System.Collections.Generic;
using BlockCSharp.Attributes;
using BlockCSharp.BaseClasses;
using BlockCSharp.Interfaces;
using OpenTK.Input;

namespace BlockCSharp.GUIs
{
    [ScreenAttribute(SRegistryKey = "screen:blockcsharp:in_world_gui")]
    public class InWorldGUI : GUI, IScreen
    {
        public InWorldGUI()
        {
            KeyDictionary = new Dictionary<Key, Func<KeyboardKeyEventArgs, int>>();
            Id = "screen:blockcsharp:in_world_gui";
        }
        
        public Dictionary<Key, Func<KeyboardKeyEventArgs, int>> KeyDictionary { get; set; }
        public string Id { get; set; }
    }
}