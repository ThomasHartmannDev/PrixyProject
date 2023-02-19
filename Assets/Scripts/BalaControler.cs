using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaControler : MonoBehaviour
{
    public float Vel = 20;
    public int time = 5;
    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.forward * Vel * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider ObjCollider)
    {
        if (ObjCollider.CompareTag("Inimigo"))
        {
            Destroy(ObjCollider.gameObject);
            
        }
        Destroy(gameObject);
    }
}
