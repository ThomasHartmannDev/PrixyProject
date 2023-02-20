using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class ControlPlayer : MonoBehaviour
{
    public float velocidade = 10;
    public LayerMask floorMask;
    public GameObject GameOver;
    public GameObject ButtonPlay;
    public bool dead = false;
    public bool started = false;

    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        if (started == false)
        {
            Time.timeScale = 0;
            ButtonPlay.SetActive(true);
        }

    }


    // Update is called once per frame
    void Update(){
        float eixoX = Input.GetAxis("Horizontal"); // Setas: Cima - Baixo || Teclas: W - S 
        float eixoZ = Input.GetAxis("Vertical"); // Setas: Esquerda - Direita || Teclas: A - D 
        
        direction = new Vector3(eixoX,0, eixoZ);

        //transform.Translate(direction * velocidade * Time.deltaTime);
        
        if(direction != Vector3.zero){
            GetComponent<Animator>().SetBool("Moving", true);
        } else {
            GetComponent<Animator>().SetBool("Moving", false);
        }

    }

    void FixedUpdate()
    {

        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (direction * velocidade * Time.deltaTime));

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(raio.origin, raio.direction * 1000, Color.red);

        RaycastHit impact;

        if (Physics.Raycast(raio, out impact, 100, floorMask))
        {
            Vector3 posicaoMira = impact.point - transform.position;

            posicaoMira.y = 0;

            Quaternion Rotacao = Quaternion.LookRotation(posicaoMira);

            GetComponent<Rigidbody>().rotation = Rotacao;
        }

    }

    public void Reset()
    {
        SceneManager.LoadScene("Game");
        
    }
    public void StartGame()
    {
        started = true;
        ButtonPlay.SetActive(false);
        Time.timeScale = 1;
        
    }
}
