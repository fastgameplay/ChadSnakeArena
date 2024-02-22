namespace ChadSnakeArena.Game
{
    using System.Collections.Generic;
    using UnityEngine;


    public class FoodManager : MonoBehaviour
    {
        [SerializeField] private int _activeFoodCount = 10;
        [SerializeField] private SO_ArenaSettings _arenaSettings;
        private List<Transform> _activeFood;

        private void Start() {
            _activeFood = new List<Transform>();
            for (int i = 0; i < _activeFoodCount; i++){
                AddFood();
            }    
        }
        public bool CheckFood(Vector3 localPosition, bool replaceFood){
            bool outcome = CheckPosition(localPosition, replaceFood);
            if(outcome && replaceFood){
                AddFood();
            }
            return outcome;
        }
        private void AddFood(){
            Vector3 tempPosition = new Vector3();
            int counter = 0;
            while(true){
                if(counter > 10) break;
                tempPosition = _arenaSettings.GetRandomWorldPosition();
                if(CheckPosition(tempPosition, false) == false) break;
                counter++;
            }
            Debug.Log("CountsToFinish");
            Transform food = Instantiate(_arenaSettings.FoodObjectPrefab, transform).transform;
            food.position = tempPosition;
            _activeFood.Add(food);
        }
        private bool CheckPosition(Vector3 position, bool destory){
            foreach(Transform item in _activeFood){
                if(item.position == position){
                    if(destory){
                        _activeFood.Remove(item);
                        Destroy(item.gameObject);
                    }
                    return true;
                } 
            }
            return false;
        }
       
    }
}