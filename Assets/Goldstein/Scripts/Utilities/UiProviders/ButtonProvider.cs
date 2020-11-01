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

        private void Awake()
        {
            Logger.Log("ButtonAwake");
            button.onClick.AddListener(OnButtonClickHandler);
        }

        private void OnButtonClickHandler()
        {
            Logger.Log("ClickHandler");
            OnButtonClick?.Invoke();
        }
    }
}