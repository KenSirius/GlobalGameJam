using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovBarraAli : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbodyBarAli;
    [SerializeField] private float VelSubida=10f;
    [SerializeField] private bool SwSube = true;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyBarAli = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        rigidbodyBarAli.velocity = new Vector2(rigidbodyBarAli.velocity.x, VelSubida );
    }
}
