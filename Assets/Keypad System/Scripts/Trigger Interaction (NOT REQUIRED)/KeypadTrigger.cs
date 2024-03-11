using UnityEngine;

namespace KeypadSystem
{
    public class KeypadTrigger : MonoBehaviour
    {
        [Header("Keypad Object")]
        [SerializeField] private KeypadItem keypadObject = null;

        private const string playerTag = "Player";
        private bool canUse;

        private void Update()
        {
            ShowKeypadUI();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(playerTag))
            {
                Debug.Log("Player in zone");
                canUse = true;
                KPUIManager.instance.ShowInteractPrompt(canUse);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(playerTag))
            {
                    canUse = false;
                    KPUIManager.instance.ShowInteractPrompt(canUse);
            }
        }

        void ShowKeypadUI()
        {
            if (canUse)
            {

                keypadObject.ShowKeypadUI();
                canUse = false; // Restablecer canUse después de mostrar la interfaz
                KPUIManager.instance.ShowInteractPrompt(false);
            }
        }
    }
}
