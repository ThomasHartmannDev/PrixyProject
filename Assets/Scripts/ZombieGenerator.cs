using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGenerator : MonoBehaviour
{
    public GameObject zombie;
    float timeCounter = 0;
    public float timeGenerator = 1;
    public LayerMask LayerZombie;


    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        if (timeCounter >= timeGenerator) { 
            NewZombieGenerator();
            timeCounter = 0; 
        }
        
    }
    void NewZombieGenerator()
    {
        Vector3 posGen = RandomPosition();
        Collider[] col = Physics.OverlapSphere(posGen, 1, LayerZombie);
        while(col.Length != 0 )
        {
            posGen = RandomPosition();
            col = Physics.OverlapSphere(posGen, 1, LayerZombie);
        }

        Instantiate(zombie, posGen, transform.rotation);
    }

    Vector3 RandomPosition()
    {
        Vector3 pos = Random.insideUnitSphere * 3;
        pos += transform.position;
        pos.y = 0;
        return pos;
    }

}
