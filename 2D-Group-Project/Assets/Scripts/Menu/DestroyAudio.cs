using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAudio : MonoBehaviour
{
    void Awake()
    {
        GameObject audio = GameObject.Find("AudioManger");
        if (audio != null)
            Destroy(audio); 
       
    }
}
