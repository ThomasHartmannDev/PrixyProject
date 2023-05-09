using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int VidaInit = 100;
    [HideInInspector]
    public int Vida;
    public float Velocidade = 10;
    public int Score = 0;

    public void ScoreCounter()
    {
        Debug.Log("Scored");
        Score += 10;
    }
    private void Awake()
    {
           Vida = VidaInit;
    }




}
