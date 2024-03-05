using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    // Creacion de singleton
    private static GameManager _instance;

    public static GameManager GetInstance()
    {
        return _instance;
    }

    private void Awake()
    {
        // Llega la instancia nueva pero ya existe una anterior, entonces se destruye
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        /*
        // Llega la instancia nueva, se mantiene esta y eliminamos la anterior
        if(_instance != null)
        {
            Destroy(_instance.gameObject);
            _instance = this;
            return;
        }
        */


        _instance = this;
    }
    #endregion


    public Action<GAME_STATE> OnGameStateChanged;
    private GAME_STATE _currentGameState;

    // Actualizamos al evento actual
    public GAME_STATE GetCurrentGameState()
    {
        return _currentGameState;
    }


    public void ChangeGameState(GAME_STATE _newGameState)
    {
        // Seteamos el estado al nuevo Estado
        _currentGameState = _newGameState;

        // Checamos si hay otros scripts estan suscritos al evento
        if (OnGameStateChanged != null)
        {
            // Avisamos a los otros scripts
            OnGameStateChanged.Invoke(_currentGameState);
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Seteamos el estado a Pausa
            ChangeGameState(GAME_STATE.PAUSE);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            // Seteamos el estado a Gameplay
            ChangeGameState(GAME_STATE.GAMEPLAY);
        }
    }

}


// Ponerle nombre a los Estados del Juego
public enum GAME_STATE
{
    GAMEPLAY,
    PAUSE,
    MENU,
}