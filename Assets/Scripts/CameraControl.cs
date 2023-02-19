using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject Player;
    Vector3 DistCompensar;

    // Start is called before the first frame update
    void Start()
    {
        DistCompensar= transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position + DistCompensar;
        
    }
}
