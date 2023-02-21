using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{   
    public float velocidade = 8;
    public GameObject Player;
    public int dmgMin = 10;
    public int dmgMax = 20;
    private Animator animatorEnemy;
    private Rigidbody rigidbodyEnemy;
    // Start is called before the first frame update
    void Start()
    {
        animatorEnemy= GetComponent<Animator>();
        rigidbodyEnemy= GetComponent<Rigidbody>();

        Player = GameObject.FindWithTag("Player");
        
        int zombieSkin = Random.Range(1, 28);
        transform.GetChild(zombieSkin).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {       
        float dist = Vector3.Distance(transform.position, Player.transform.position);
        Vector3 dir = Player.transform.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(dir);
        rigidbodyEnemy.MoveRotation(rot);

        if (dist > 2.5)
        {
            rigidbodyEnemy.MovePosition(rigidbodyEnemy.position + (dir.normalized * velocidade * Time.deltaTime));
            animatorEnemy.SetBool("Atacar", false);
        } else {
            animatorEnemy.SetBool("Atacar", true);
        }
    }
    private void AtackPlayer()
    {

        //Player.GetComponent<ControlPlayer>().GameOver.SetActive(true);
        //Player.GetComponent<ControlPlayer>().dead = true;
        //Time.timeScale = 0;
        int dmg = Random.Range(dmgMin, dmgMax); // Randon dmg
        Player.GetComponent<ControlPlayer>().dmgTaken(dmg);
    }


}
