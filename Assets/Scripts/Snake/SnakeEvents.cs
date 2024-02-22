namespace ChadSnakeArena.Game.Snake
{
    using ScriptableEvents.Base;
    using UnityEngine;
    using System;

    [Serializable]
    public struct SnakeEvents{
        public EventReference<Vector3> OnPositionCheckRequest;
        public EventReference<bool> OnPositionCheckResult;

        public EventReference OnGameOver;
        public EventReference OnFoodGained;
        public EventReference<SnakePart> OnSnakePartAdded;



    }
}