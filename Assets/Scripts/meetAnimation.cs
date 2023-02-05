using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meetAnimation : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
         animator = GetComponent<Animator>();
        animator.speed = 0;
    }

    private void OnMouseDown()
    {
         Debug.Log("Click en la animada");
         animator.speed = 1;
        // animator.Play("AnimationName", 0, 0f);
    }
    void OnAnimatorEnd()
    {
        Destroy(animator);
    }
}
