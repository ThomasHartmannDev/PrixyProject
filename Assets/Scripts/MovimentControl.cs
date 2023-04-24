using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentControl : MonoBehaviour
{
    private Rigidbody myrigidbody;

    private void Awake()
    {
        myrigidbody = GetComponent<Rigidbody>();
    }

    public void moveNormalized(Vector3 direction, float velocidade)
    {
        myrigidbody.MovePosition(myrigidbody.position + (direction.normalized * velocidade * Time.deltaTime));
    }

    public void move(Vector3 direction, float velocidade)
    {
        myrigidbody.MovePosition(myrigidbody.position + (direction * velocidade * Time.deltaTime));
    }

    public void rotation(Vector3 direction)
    {
        Quaternion rot = Quaternion.LookRotation(direction);
        myrigidbody.MoveRotation(rot);
    }

}
