using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class LightsFlicker : MonoBehaviour
{
    public Light lightOB;
    public AudioSource lightSound;

    private float timer;
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;

    void Start()
    {
        timer = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        LightsFlickering();
    }

    void LightsFlickering()
    {
        if (timer > 0)
            timer -= Time.deltaTime;

        if (timer <= 0)
        {
            lightOB.enabled = !lightOB.enabled;
            timer = Random.Range(minTime, maxTime);
            //lightSound.Play();
        }
    }
}