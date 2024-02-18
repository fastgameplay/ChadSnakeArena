namespace ChadSnakeArena.Game
{
    using UnityEngine;
    public class ArenaGrid : MonoBehaviour
    {
        public Color gridColor = Color.white;
        public Color lineColor = Color.gray;
        public float lineThickness = 0.05f;
        public int rowCount = 5;
        public int columnCount = 5;
        public float scale = 1;

        [SerializeField] private LineRenderer _lineRendererPrefab;
        [SerializeField] private SpriteRenderer _backGround;

        // void Start()
        // {
        //     UpdateGrid();
        // }
        private void OnValidate() {
            // UpdateGrid();
        }
        public void UpdateGrid()
        {
            
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
           
            Vector2 size = new Vector2(scale * rowCount, scale * columnCount);

            _backGround.color  = gridColor;
            _backGround.transform.localScale = size;


            DrawGridLines(size);
        }

        void DrawGridLines(Vector2 size)
        {
            Vector2 startPosition = size / -2;
            LineRenderer edgeLine = CreateLineRenderer("Border Line",transform);
            edgeLine.positionCount = 5;
            edgeLine.SetPosition(0, startPosition);
            // - -
            // + -
            // + +
            // - +
            // - -
            edgeLine.SetPosition(0, startPosition);                         // - -
            edgeLine.SetPosition(1, startPosition * new Vector2(-1,  1));   // + -
            edgeLine.SetPosition(2, startPosition * new Vector2(-1, -1));   // + +
            edgeLine.SetPosition(3, startPosition * new Vector2( 1, -1));   // - +
            edgeLine.SetPosition(4, startPosition);                         // - -

            for(int i = 1; i < rowCount; i++){
                LineRenderer verticalLine = CreateLineRenderer($"Vertical Line {i-1}",transform);
                verticalLine.positionCount = 2;
                verticalLine.SetPosition(0, startPosition + new Vector2(i * scale, 0));
                verticalLine.SetPosition(1, startPosition + new Vector2(i * scale, size.y));
            }
            for(int i = 1; i < columnCount; i++){
                LineRenderer horizontalLine = CreateLineRenderer($"Horizontal Line {i-1}",transform);
                horizontalLine.positionCount = 2;
                horizontalLine.SetPosition(0, startPosition + new Vector2(0, i * scale));
                horizontalLine.SetPosition(1, startPosition + new Vector2(size.x, i * scale));
            }
           
        }

        private LineRenderer CreateLineRenderer(string name, Transform parent){
            LineRenderer line = Instantiate(_lineRendererPrefab,parent);
            line.gameObject.name = name;
            line.startColor = lineColor;    
            line.endColor = lineColor;
            line.startWidth = lineThickness;
            line.endWidth = lineThickness;
            return line;
        }
    }
}
