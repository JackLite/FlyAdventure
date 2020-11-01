using System;
using UnityEngine;
using UnityEngine.UI;

namespace Goldstein.Utilities.UiProviders
{
    public sealed class ButtonProvider : MonoBehaviour
    {
        [SerializeField] private Button button;

        public event Action OnButtonClick;

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