using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{
    Rigidbody2D rigidbodyBola;
    public float moveDirection;
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyBola = GetComponent<Rigidbody2D> ();    
    }

    // Update is called once per frame
    
    void Update()
    {
        moveDirection=Input.GetAxis("Horizontal");
           
    }
    void FixedUpdate()
    {
        rigidbodyBola.velocity= new Vector2( moveDirection * speed, rigidbodyBola.velocity.y);
    }
}
