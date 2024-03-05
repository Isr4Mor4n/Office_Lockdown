using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _pauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pause;
    // Truqueamos las suscripciones seteando el bool a true
    bool _isRegistered = true;
    bool _isPause = true;

    // Start is called before the first frame update
    void Start()
    {
        // Jalamos el Singleton del Game Manager para llamar al evento 
        // Cuando sucede el evento llamamos a la funcion GameManagerCall
        // Nos suscribimos al evento
        GameManager.GetInstance().OnGameStateChanged += GameManagerCall;

        // Con un get nos actualizamos al Estado del Evento Actual 
        GameManagerCall(GameManager.GetInstance().GetCurrentGameState());
    }

    private void OnEnable()
    {
        if (_isRegistered)
        {
            // Jalamos el Singleton del Game Manager para llamar al evento 
            // Cuando sucede el evento llamamos a la funcion GameManagerCall
            GameManager.GetInstance().OnGameStateChanged += GameManagerCall;

            // Con un get nos actualizamos al Estado del Evento Actual
            GameManagerCall(GameManager.GetInstance().GetCurrentGameState());

            // Cambiamos el estado del bool Reafirmamos que estamos ya suscritos
            _isRegistered = true;
        }
    }

    // Nos desuscribimos del evento
    private void OnDisable()
    {
        if (_isRegistered)
        {
            // Nos desuscribimos del evento
            GameManager.GetInstance().OnGameStateChanged -= GameManagerCall;

            // Cambiamos el estado del bool
            _isRegistered = false;
        }
    }

    void GameManagerCall(GAME_STATE _gameManagerNewGameState)
    {
        _isPause = _gameManagerNewGameState == GAME_STATE.PAUSE;
        Pause();
    }


    public void Pause()
    {
        _pause.SetActive(true);
        Debug.Log("Pause");
    }

    public void Home()
    {
        SceneManager.LoadScene("_mainMenu");
    }

    public void Resume()
    {
       _pause.SetActive(false);
        Debug.Log("Resume");
        if (!_isPause)
        {
            return;
        }
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }





}
