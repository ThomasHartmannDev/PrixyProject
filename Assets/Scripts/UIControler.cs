using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControler : MonoBehaviour
{
    // Start is called before the first frame update
    private ControlPlayer ControlPlayer;
    public Slider SlinderVida;
    void Start()
    {
        ControlPlayer = GameObject.FindWithTag("Player").GetComponent<ControlPlayer>();
        SlinderVida.maxValue= ControlPlayer.status.Vida;
        SlinderVida.value = ControlPlayer.status.Vida;
    }

    // Update is called once per frame 
    void Update()
    {
        
    }

    public void AtualizarSliderVida()
    {
        SlinderVida.value = ControlPlayer.status.Vida;
    }
}
