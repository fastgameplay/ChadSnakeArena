namespace ChadSnakeArena.Game{
    using System.Collections;
    using ScriptableEvents.Base;
    using UnityEngine;
    using UnityEngine.UI;
    public class ChallengeTimer : MonoBehaviour
    {
        [SerializeField] SO_BaseEvent _onGameOver;
        [SerializeField] SO_ArenaSettings _arenaSettings;
        [SerializeField] Image _clockImage;

        private void Start() {
            StartCoroutine("IETimerClock");
        }

        IEnumerator IETimerClock(){
            float elapsedTime = 0f;
            float endFillAmount = 0f;
            Debug.Log(_arenaSettings.ChallengeTime);
            while (elapsedTime < _arenaSettings.ChallengeTime)
            {
                elapsedTime += Time.deltaTime;
                _clockImage.fillAmount = Mathf.Lerp(1f, endFillAmount, elapsedTime / _arenaSettings.ChallengeTime);
                Debug.Log(elapsedTime);
                yield return null;
            }

            // Ensure the fill amount is exactly 0
            _clockImage.fillAmount = endFillAmount;
            _onGameOver.Invoke();
        }
    }
}