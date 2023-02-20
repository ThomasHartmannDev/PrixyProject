using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{   
    public float velocidade = 8;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
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
        GetComponent<Rigidbody>().MoveRotation(rot);

        if (dist > 2.5)
        {
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (dir.normalized * velocidade * Time.deltaTime));
            GetComponent<Animator>().SetBool("Atacar", false);
        } else {
            GetComponent<Animator>().SetBool("Atacar", true);
        }
    }
    private void AtackPlayer()
    {
        
        Player.GetComponent<ControlPlayer>().GameOver.SetActive(true);
        Player.GetComponent<ControlPlayer>().dead = true;
        Time.timeScale = 0;
    }


}
