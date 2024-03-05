using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _audioManager : MonoBehaviour
{
    public _sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    public void PlayMusic(string name)
    {
        _sound s = Array.Find(musicSounds, x => x.name == name);
        if (s == null) { Debug.Log("Sound not found"); }

        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        _sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null) { Debug.Log("Sound not found"); }

        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }
}
