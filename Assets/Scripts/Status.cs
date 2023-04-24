using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int VidaInit = 100;
    [HideInInspector]
    public int Vida;
    public float Velocidade = 10;

    private void Awake()
    {
           Vida = VidaInit;
    }




}
