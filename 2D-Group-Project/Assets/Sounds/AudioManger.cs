using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManger : MonoBehaviour
{
   public Sounds[] sounds; 
  public static AudioManger instance;

    void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
      
        foreach(Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.Chip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.Loop;
        }
    }

    void Start()
    {
        //Play("GameIntroWAV");
    }
    //FindObjectOfType<AudioManger>().Play to play sounds 
    public void Play(string name, float volume = 0.5f)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
           Debug.LogWarning("sound: " + name + " not found!");
           return;
        }

        s.source.volume = volume;
        s.source.Play();
    }
}
