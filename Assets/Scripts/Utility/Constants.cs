using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Constants
{
    #region Classes
    internal class Events
    {
        public const string CollectibleCollidedParamEnum = "CollectibleCollidedParamEnum"; // this will send enum Collectibles representing its type
        public const string CollectibleCollidedParamGameObject = "CollectibleCollidedParamGameObject"; // this will send collectible collided
        public const string LevelStateParamEnum = "LevelStateParamEnum"; // this will send enum LevelState representing its type
        public const string GameStateParamEnum = "GameStateParamEnum"; // this will send enum GameState representing its type
        public const string LevelRequestParamEnum = "LevelRequestParamEnum"; // this will send enum LevelRequest representing its type
        public const string CubesAddedToPlayerParamInt = "CubesAddedToPlayerParamInt"; // this will send int representing cubes add count
        public const string CubesRemovedFromPlayerParamInt = "CubesRemovedFromPlayerParamInt"; // this will send int representing cubes add count
        public const string CollidedWithMultiplierFloorParamVoid = "CollidedWithMultiplierFloorParamVoid";
    }

    internal class Tags
    {
        public const string SurfingCube = "SurfingCube";
        public const string Diamond = "Diamond";
        public const string Magnet = "Magnet";
        public const string Wall = "Wall";
    }

    internal class Layers
    {
        public const int Untagged = 0;
        public const int Player = 8;
        public const int LevelFinisher = 9;
        public const int Collectible = 10;
        public const int Barrier = 11;
        public const int Magnet = 12;
        public const int MultiplierFloor = 13;
    }

    internal class PlayerAnimator
    {
        public const string Jumping = "Jumping";
        public const string Spin = "Spin";
        public const string WaveDance = "WaveDance";
        public const string Death = "Death";
    }
    
    internal class FlagAnimator
    {
        public const string Pop = "Pop";
    }
    #endregion
    
    #region ENUMS
    internal enum GameScenesIndex
    {
        Index = 0,
        Level01,
        Level02,
        Level03,
        Level04,
        Level05,
        Level06,
    }
    
    internal enum Collectibles
    {
        Diamond = 0,
        Magnet,
    }
    
    internal enum LevelState
    {
        Completed = 0,
        Failed,
    }
    
    internal enum GameState
    {
        Active = 0,
        Paused,
    }
    
    internal enum LevelRequest
    {
        Retry = 0,
        GoToNext,
    }
    #endregion
    
}
