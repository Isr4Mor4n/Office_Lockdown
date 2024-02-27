using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _timerText;
    float _remainingTime = 301.0f;

    void Update()
    {
        if (_remainingTime > 0)
        {
            _remainingTime -= Time.deltaTime;
        }

        else if (_remainingTime < 0)
        {
            _remainingTime = 0;
            //GameOver();
        }

        if (_remainingTime < 31)
        {
            _timerText.color = Color.red;
        }

        int minutes = Mathf.FloorToInt(_remainingTime / 60);
        int seconds = Mathf.FloorToInt(_remainingTime % 60);

        _timerText.text = string.Format("{00:00}:{1:00}", minutes, seconds);
    }
}