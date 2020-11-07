using System;
using UnityEngine;
using UnityEngine.UI;
using Logger = Goldstein.Scripts.Utilities.Logger;

namespace Goldstein.Utilities.UiProviders
{
    public sealed class ButtonProvider : MonoBehaviour
    {
        [SerializeField] private Button button;

        public event Action OnButtonClick;

        private void OnValidate()
        {
            if (button == null)
                button = GetComponent<Button>();
            if (button == null)
                Logger.LogError($"Missing Reference {nameof(button)}");
        }

        private void Awake()
        {
            button.onClick.AddListener(OnButtonClickHandler);
        }

        private void OnButtonClickHandler()
        {
            OnButtonClick?.Invoke();
        }
    }
}