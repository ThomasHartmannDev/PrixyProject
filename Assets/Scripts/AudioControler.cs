using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControler : MonoBehaviour
{
    private AudioSource audioSource;
    public static AudioSource instance; //Static = Const

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        instance = audioSource;

    }

}
