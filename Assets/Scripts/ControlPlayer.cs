using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class ControlPlayer : MonoBehaviour, InterfaceKillable
{
    
    public LayerMask floorMask;
    public GameObject CanvasGameOver;
    public GameObject CanvasPlay;
    public bool started = false;

    public UIControler UIControler;
    public AudioClip audioDmg;
    public Status status;

    private MovePlayerControl movePlayControl;
    private AnimationControl animationControl;

   
    

    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {

        if (started == false)
        {
            Time.timeScale = 0;
            CanvasPlay.SetActive(true);
        }

        movePlayControl = GetComponent<MovePlayerControl>();
        animationControl = GetComponent<AnimationControl>();
        status = GetComponent<Status>();
    }


    // Update is called once per frame
    void Update(){
        float eixoX = Input.GetAxisRaw("Horizontal"); // Setas: Cima - Baixo || Teclas: W - S 
        float eixoZ = Input.GetAxisRaw("Vertical"); // Setas: Esquerda - Direita || Teclas: A - D 
        
        direction = new Vector3(eixoX,0, eixoZ);
        bool moving;
        if (direction != Vector3.zero)
        {
            moving = true;
        } else
        {
            moving = false;
        }
        animationControl.MovingPlayer(moving); // Magnitude = tamanho do vector3

    }

    void FixedUpdate()
    { 
        movePlayControl.move(direction, status.Velocidade);

        movePlayControl.rotationPlayer(floorMask);
    }


    public void dmgTaken(int dmg)
    {
        
        status.Vida -= dmg;
        UIControler.AtualizarSliderVida();
        AudioControler.instance.PlayOneShot(audioDmg);

        if (status.Vida <= 0)
        { // Gameover
            died();
        }
    }
    public void died()
    {
        UIControler.GameOver();
    }

}
