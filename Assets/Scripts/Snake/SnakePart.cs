namespace ChadSnakeArena.Game.Snake
{
    using UnityEngine;
    
    [RequireComponent(typeof(SpriteRenderer))]
    public class SnakePart : MonoBehaviour
    {
        public int ID {
            get => _id; 
            set {
                _id = value;
                Color = _data.GetBodyColor(value);
            }
        }
        public Color Color {
            get => _renderer.color; 
            set {
                UpdateRenderer();
                _renderer.color = value;
            }
        }
        
        [SerializeField] 
        private SO_SnakeData _data;
        private SnakePart _connectedPart;
        private SpriteRenderer _renderer;
        private int _id;

        private void Awake() => UpdateRenderer();
        public void ChainMovement(Vector3 nextPosition, bool createPart) {
            
            if(_connectedPart == null) {
                if(createPart){
                    DuplicatePart(Vector3.zero);
                }
            } 
            else {
                _connectedPart.ChainMovement(transform.localPosition, createPart);
            }
            transform.localPosition = nextPosition;
        }

        private void DuplicatePart(Vector3 relativePosition){
            SnakePart tail = Instantiate(_data.PartPrefab, transform.parent);
            _connectedPart = tail;
            tail.transform.localPosition = transform.localPosition + relativePosition;
            tail.ID = ID + 1;
        }

        private void UpdateRenderer(){
            if (_renderer == null) _renderer = GetComponent<SpriteRenderer>();
        }
        
        private void OnPositionCheckRequest(Vector3 position){
            if(transform.localPosition != position) return;
            _data.Events.OnPositionCheckResult.Invoke(true);                
        }

        private void OnEnable() {
            _data.Events.OnPositionCheckRequest += OnPositionCheckRequest;
        }
        private void OnDisable() {
            _data.Events.OnPositionCheckRequest -= OnPositionCheckRequest;
        }
    }
}