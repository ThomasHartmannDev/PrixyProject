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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {       
        float dist = Vector3.Distance(transform.position, Player.transform.position);
        if(dist > 2.5)
        {
            Vector3 dir = Player.transform.position - transform.position;
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (dir.normalized * velocidade * Time.deltaTime));

            Quaternion rot = Quaternion.LookRotation(dir);
            GetComponent<Rigidbody>().MoveRotation(rot);
        } else {
            
        }
    }
}
