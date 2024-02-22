namespace ChadSnakeArena.Game.Snake
{
    using System.Collections.Generic;
    using System.Linq;
    using Unity.VisualScripting;
    using UnityEngine;
    public class SnakeHead : SnakePart
    {
        [SerializeField] private FoodManager _foodManager;
        [SerializeField] private SO_ArenaSettings _arenaSettings;
        private Vector3 direction;
        private List<SnakePart> _snakeParts;
        private bool _gameOver;
        private void Start() {
            _snakeParts = new List<SnakePart>();
            direction = Vector3.up;
            DuplicatePart(-direction);
            Color = _data.HeadColor;
        }
        void Update() {
            if(_gameOver) return;
            if (Input.GetKeyDown(KeyCode.UpArrow) && direction != -Vector3.up){
                direction = Vector3.up;
                CheckAndMove(Vector3.up);

            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && direction != Vector3.up){
                direction = -Vector3.up;
                CheckAndMove(-Vector3.up);

            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && direction != Vector3.right){
                direction = -Vector3.right;
                CheckAndMove(-Vector3.right);

            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && direction != -Vector3.right){
                direction = Vector3.right;
                CheckAndMove(Vector3.right);
            }

            if(Input.GetKeyDown(KeyCode.Space)){
                ChainMovement(transform.localPosition + direction, true);
            }
        }
        private void CheckAndMove(Vector3 direction){
            Vector3 position = transform.position + direction;
            if(_arenaSettings.CheckOutsideOfBorder(position) || CheckSnakePartsAtPosition(position)){
                _data.Events.OnGameOver.Invoke();
                _gameOver = true;
                return;
            }
            bool createPart = _foodManager.CheckFood(transform.position + direction, true);
            ChainMovement(transform.localPosition + direction, createPart);
        }
        private bool CheckSnakePartsAtPosition(Vector3 position){
            return _snakeParts.Any(part => part.CheckLocation(position));
        }
        private void OnSnakePartAdded(SnakePart part){
            _snakeParts.Add(part);
            _data.Events.OnScoreChange.Invoke(_snakeParts.Count-1);
        }
        private void OnEnable() {
            _data.Events.OnSnakePartAdded += OnSnakePartAdded;
        }
        private void OnDisable(){
            _data.Events.OnSnakePartAdded -= OnSnakePartAdded;
        }
    }
}