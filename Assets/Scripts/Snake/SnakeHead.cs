namespace ChadSnakeArena.Game
{
    using ChadSnakeArena.Game.Snake;
    using UnityEngine;
    public class SnakeHead : SnakePart
    {
        Vector3 direction;
        private void Start() {
            direction = Vector3.up;
            DuplicatePart(-direction);
            Color = _data.HeadColor;

        }
        void Update() {
            if (Input.GetKeyDown(KeyCode.UpArrow) && direction != -Vector3.up){
                direction = Vector3.up;
                ChainMovement(transform.localPosition + direction, false);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && direction != Vector3.up){
                direction = -Vector3.up;
                ChainMovement(transform.localPosition + direction, false);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && direction != Vector3.right){
                direction = -Vector3.right;
                ChainMovement(transform.localPosition + direction, false);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && direction != -Vector3.right){
                direction = Vector3.right;
                ChainMovement(transform.localPosition + direction, false);
            }
            if(Input.GetKeyDown(KeyCode.Space)){
                ChainMovement(transform.localPosition + direction, true);
            }
        }
        
    }
}