using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra : MonoBehaviour
{
    private bool ClickIzquierdo = false;
    public float velocidadSalto;
    private Rigidbody2D rigidbodyBarra;
    // Start is called before the first frame update
    void Start()
    {
        // la variable los componenetes de rigidbody
        rigidbodyBarra = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ClickIzquierdo =Input.GetMouseButton(0);
        // if(ClickIzquierdo)
        //     Debug.Log("HaceClick");
    }  
    void FixedUpdate()
    {
        if(ClickIzquierdo)
        {
            rigidbodyBarra.AddForce(new Vector2 (0,velocidadSalto),ForceMode2D.Impulse );
        }
    }  
}
