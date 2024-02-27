using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _pauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pause;

    public void Pause()
    {
        _pause.SetActive(true);
    }

    public void Home()
    {
        SceneManager.LoadScene("_mainMenu");
    }

    public void Resume()
    {
       _pause.SetActive(false);

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }





}
