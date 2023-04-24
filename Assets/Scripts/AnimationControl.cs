using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationControl : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Atack (bool state)
    {
        animator.SetBool("Atacar", state);
    }

    public void MovingPlayer(bool MoveValue)
    {
        animator.SetBool("Moving", MoveValue);
    }

    public void MovingEnemy(float MoveValue)
    {
        animator.SetFloat("Moving", MoveValue);
    }
}
