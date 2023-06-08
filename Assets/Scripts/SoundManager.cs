using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{

    public Sound[] sounds;

    public static SoundManager instance;

    // Start is called before the first frame update
    void Awake()
    {

        if(instance == null)
            instance = this;

        else
        {
            Destroy(gameObject);
            return;
        }
            

        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in sounds)
        {
            if (SceneManager.GetActiveScene().name == "Title Screen")
            {
                sound.source.Pause();
            }

            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }



    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
            return;
        s.source.Play();
    }


}
