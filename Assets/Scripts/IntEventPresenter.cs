namespace ChadSnakeArena.UI
{
    using UnityEngine;
    using TMPro;
    using ScriptableEvents.Base;

    [RequireComponent(typeof(TextMeshProUGUI))]
    public class IntEventPresenter : MonoBehaviour
    {
        [SerializeField] SO_BaseEvent<int> _onIntegerChange;
        TextMeshProUGUI _text;

        private void Awake() {
            _text = GetComponent<TextMeshProUGUI>();
        }
        private void OnIntChange(int value) {
            _text.text = value.ToString();
        }
        private void OnEnable() {
            _onIntegerChange += OnIntChange;
        }
        private void OnDisable() {
            _onIntegerChange -= OnIntChange;
        }
    }

}