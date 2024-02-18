namespace ChadSnakeArena.Game.Snake
{
    using UnityEngine;
    public class SO_SnakeData : ScriptableObject
    {
        public float TimeForMove => _timeForMove;
        public Color HeadColor => _headColor;
        public SnakePart PartPrefab => _snakePartPrefab;

        [Header("Movement")]
        [SerializeField] private float _timeForMove;
        
        [Space(10)]
        [Header("Settings")]
        [SerializeField] Color _headColor;
        [SerializeField] Color[] _bodyColors;

        [Space(10)]
        [Header("Reference")]
        [SerializeField] SnakePart _snakePartPrefab;

        public SnakeEvents Events = new SnakeEvents();
        public Color GetBodyColor(int id) => _bodyColors[id % _bodyColors.Length];
    }
}
