using UnityEngine;

namespace Goldstein.Utilities.UiProviders
{
    public class ScreenProvider : MonoBehaviour
    {
        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}