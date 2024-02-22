namespace ChadSnakeArena.Game
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "Arena Data", menuName ="Data/Arena")]
    public class SO_ArenaSettings : ScriptableObject
    {
        [field: Header("Grid Settings")]
        [field: SerializeField] public Color GridColor {get; private set;}
        [field: SerializeField] public int RowCount {get; private set;}
        [field: SerializeField] public int ColumnCount {get; private set;}
        [field: SerializeField] public float Scale {get; private set;}

        [field: Header("Line Settings")]
        [field: SerializeField] public float LineThickness {get; private set;}
        [field: SerializeField] public Color LineColor {get; private set;}
        [field: SerializeField] public LineRenderer LineRendererPrefab {get; private set;}
        [field: SerializeField] public GameObject FoodObjectPrefab {get; private set;}

        public Vector3 GetWorldPosition(int x, int y) => new Vector3(RowCount / -2, ColumnCount / -2) + new Vector3(x * Scale, y * Scale);
        public Vector3 GetWorldPosition(Vector2Int pos) => GetWorldPosition(pos.x, pos.y);
        public Vector3 GetRandomWorldPosition(){
            return GetWorldPosition(Random.Range(0,RowCount), Random.Range(0,ColumnCount));
        }
        public bool CheckOutsideOfBorder(Vector3 position){
            if(position.x < RowCount / -2 || position.x > RowCount / 2) return true;
            if (position.y < ColumnCount / -2 || position.y > ColumnCount / 2) return true;
            return false;
        }
    }
}