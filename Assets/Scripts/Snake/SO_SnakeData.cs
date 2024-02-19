namespace ChadSnakeArena.Game.Snake
{
    using UnityEngine;
    [CreateAssetMenu(fileName = "Snake Data", menuName = "Data/Snake")]
    public class SO_SnakeData : ScriptableObject
    {

        [field: Header("Movement")]
        [field: SerializeField] public float TimeForMove {get; private set;}
        
        [field: Space(10)]
        [field: Header("Settings")]
        [field: SerializeField] public Color HeadColor {get; private set;}
        [field: SerializeField] public Color[] _bodyColors {get; private set;}

        [field: Space(10)]
        [field: Header("Reference")]
        [field: SerializeField] public SnakePart PartPrefab {get; private set;}

        public SnakeEvents Events = new SnakeEvents();
        public Color GetBodyColor(int id) => _bodyColors[id % _bodyColors.Length];
    }
}
