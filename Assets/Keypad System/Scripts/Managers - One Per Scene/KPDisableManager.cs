using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace KeypadSystem
{
    public class KPDisableManager : MonoBehaviour
    {
        // [SerializeField] private FirstPersonController player = null;
        [SerializeField] private PlayerController _player = null;


        public static KPDisableManager instance;

        void Awake()
        {
            if (instance != null) { Destroy(gameObject); }
            else { instance = this; DontDestroyOnLoad(gameObject); }
        }

        
        public void DisablePlayer(bool disable)
        {
            _player.enabled = !disable;
           // KPUIManager.instance.ShowCrosshair(disable);
        }

        /*
        public void EnablePlayer(bool enable)
        {
            _player.enabled = enable;
        }
        */
    }
}
