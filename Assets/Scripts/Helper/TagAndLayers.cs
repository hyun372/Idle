using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagAndLayers
{
    public class LayerName
    {
        public const string Default = "Default";
        public const string TransparentFX = "TransparentFX";
        public const string IgnoreRaycast = "Ignore Raycast";
        public const string Water = "Water";
        public const string UI = "UI";
    }
    public enum LayerIndex
    {
        Default = 0,
        TransparentFX = 1,
        IgnoreRaycast = 2,
        Water = 4,
        UI = 5
    }

    public class TagName
    {
        public const string Untagged = "Untagged";
        public const string Respawn = "Respawn";
        public const string Finish = "Finish";
        public const string EditorOnly = "EditorOnly";
        public const string MainCamera = "MainCamera";
        public const string Player = "Player";
        public const string GameController = "GameController";
        public const string Work = "Work";
        public const string DropItem = "Drop Item";
        public const string Tile = "Tile";
    }
}
