using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyControl : MonoBehaviour, InterfaceKillable
{
    public GameObject Player;
    public int dmgMin = 10;
    public int dmgMax = 20;
    public AudioClip AudioZombieDeath;
    


    private AnimationControl animationControl;
    private MovimentControl movimentControl;
    private Status status;
    private Vector3 randonPosition;
    private Vector3 direction;
    private float timeWalking;
    private float timeWaiting = 4;
    


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        movimentControl = GetComponent<MovimentControl>();
        animationControl = GetComponent<AnimationControl>();
        
        status  = GetComponent<Status>();

        RandomZombie();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {       
        float dist = Vector3.Distance(transform.position, Player.transform.position);
        
        movimentControl.rotation(direction);
        animationControl.MovingEnemy(direction.magnitude);
        if(dist > 15) { 
            WalkingDead();
        } else if (dist > 2.5)
        {
            direction = Player.transform.position - transform.position;
            movimentControl.moveNormalized(direction, status.Velocidade);
            animationControl.Atack(false);
        } else {
            animationControl.Atack(true);
        }
    }
    private void WalkingDead()
    {
        timeWalking -= Time.deltaTime;
        if (timeWalking <= 0)
        {
            randonPosition = RandomizePosition();
            timeWalking += timeWaiting;
        }

        bool close = Vector3.Distance(transform.position, randonPosition) <= 0.5;
        if(close == false) {
            direction = randonPosition - transform.position;
            movimentControl.moveNormalized(direction, status.Velocidade);
        }

    }
    private Vector3 RandomizePosition()
    {
        Vector3 position = Random.insideUnitSphere * 10;
        position += transform.position;
        position.y = transform.position.y;
        return position;
    }


    private void AtackPlayer()
    {
        int dmg = Random.Range(dmgMin, dmgMax); // Randon dmg
        Player.GetComponent<ControlPlayer>().dmgTaken(dmg);
        
    }

    private void RandomZombie()
    {
        int zombieSkin = Random.Range(1, 28);
        transform.GetChild(zombieSkin).gameObject.SetActive(true);
    }

    public void dmgTaken(int dmg)
    {
        status.Vida -= dmg;
        if(status.Vida < 0)
        {
            died();
        }
    }

    public void died()
    {
        Destroy(gameObject);
        AudioControler.instance.PlayOneShot(AudioZombieDeath);
        Player.GetComponent<Status>().ScoreCounter();

    }

}
