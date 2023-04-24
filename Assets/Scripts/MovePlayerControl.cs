using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayerControl : MovimentControl
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rotationPlayer(LayerMask floorMask)
    {
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(raio.origin, raio.direction * 1000, Color.red);

        RaycastHit impact;

        if (Physics.Raycast(raio, out impact, 100, floorMask))
        {
            Vector3 posicaoMira = impact.point - transform.position;

            posicaoMira.y = 0;

            rotation(posicaoMira);
        }
    }
}
