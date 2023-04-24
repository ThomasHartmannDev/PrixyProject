using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaControler : MonoBehaviour
{
    public float Vel = 20;

    float timeCounter = 0;
    public float timeDestroy = 3;
    public AudioClip AudioZombieDeath;

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.forward * Vel * Time.deltaTime);

    }

    private void Update()
    {
        timeCounter += Time.deltaTime;
        if (timeCounter >= timeDestroy)
        {
            Destroy(gameObject);
            timeCounter = 0;
        }
    }

    private void OnTriggerEnter(Collider ObjCollider)
    {
        if (ObjCollider.CompareTag("Inimigo"))
        {
            int dmg = Random.Range(8, 18);
            ObjCollider.GetComponent<EnemyControl>().dmgTaken(dmg);
        }
        Destroy(gameObject);
    }
}
