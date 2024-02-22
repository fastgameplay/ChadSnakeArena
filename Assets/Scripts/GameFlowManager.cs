namespace ChadSnakeArena.Game
{
    using ScriptableEvents.Base;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    public class GameFlowManager : MonoBehaviour
    {
        [SerializeField] SO_BaseEvent _onGameOver;
        [Space(10)]
        [Header("Reference")]
        [SerializeField] GameObject _gameOverTab;
        [SerializeField] GameObject _mainUITab;
        [SerializeField] GameObject _pauseTab;
        [SerializeField] GameObject _settingsTab;

        public void OnRestartBtn(){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void OnHomeBtn(){
            SceneManager.LoadScene(0);
        }
        public void PauseGame(bool state){
            _gameOverTab.SetActive(!state);
            _mainUITab.SetActive(!state);
            _pauseTab.SetActive(state);
            _settingsTab.SetActive(!state);
            Time.timeScale = state ? 1f : 0f;
        }
        private void OnGameOver(){
            _gameOverTab.SetActive(true);
            _mainUITab.SetActive(false);
            _pauseTab.SetActive(false);
            _settingsTab.SetActive(false);
        }

        private void OnEnable() {
            _onGameOver += OnGameOver;
        }
        private void OnDisable() {
            _onGameOver -= OnGameOver;
        }
    }
}