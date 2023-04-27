using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieGenerator : MonoBehaviour
{
    public GameObject zombie;
    float timeCounter = 0;
    public float timeGenerator = 1;
    public LayerMask LayerZombie;
    private float distGen = 3;

    private float distPlayerToGen = 20;
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > distPlayerToGen){
            timeCounter += Time.deltaTime;
            if (timeCounter >= timeGenerator)
            {
                StartCoroutine(NewZombieGenerator());
                timeCounter = 0;
            }
        }
        
    }
    IEnumerator NewZombieGenerator()
    {
        Vector3 posGen = RandomPosition();
        Collider[] col = Physics.OverlapSphere(posGen, 1, LayerZombie);
        while(col.Length != 0 )
        {
            posGen = RandomPosition();
            col = Physics.OverlapSphere(posGen, 1, LayerZombie);
            yield return null;
        }

        Instantiate(zombie, posGen, transform.rotation);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distGen);
    }

    Vector3 RandomPosition()
    {
        Vector3 pos = Random.insideUnitSphere * distGen;
        pos += transform.position;
        pos.y = 0;
        return pos;
    }

}
