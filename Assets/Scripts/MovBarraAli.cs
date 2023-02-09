using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovBarraAli : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbodyBarAli;
    [SerializeField] private float VelSubida=3f;
    [SerializeField] private bool SwSube = true;
    [SerializeField] private bool SwMueve = false;
    [SerializeField] private float TiempoFrameSumado = 0;
    [SerializeField] private float TiempoLimiteEnMov = 2;
    [SerializeField] private float TiempoLimiteQuieto = 3;
    [SerializeField] private float VelocidadFrenado = 1f;
    [SerializeField] private float RestoVelocidadMin = 1f;
    //[SerializeField] private Vector3 TamañoCubo;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyBarAli = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        TiempoFrameSumado = TiempoFrameSumado + Time.deltaTime;
        if(TiempoFrameSumado>=TiempoLimiteEnMov||TiempoFrameSumado>=TiempoLimiteQuieto)
        {
            TiempoFrameSumado = 0;
            SwMueve = !SwMueve;
            VelocidadFrenado = (float)Random.Range((int)RestoVelocidadMin,(int)Mathf.Abs(VelSubida)+1);            
        }        
    }
    void FixedUpdate()
    {   
        if(SwMueve)
        {
            rigidbodyBarAli.velocity = new Vector2(rigidbodyBarAli.velocity.x, VelSubida );
        }else{
            // rigidbodyBarAli.velocity= new Vector2(rigidbodyBarAli.velocity.x,VelSubida-VelocidadFrenado);
            if(rigidbodyBarAli.velocity.y>0)
            {
                rigidbodyBarAli.velocity = new Vector2(rigidbodyBarAli.velocity.x, VelSubida-VelocidadFrenado);
            }
            else
            {
                rigidbodyBarAli.velocity = new Vector2(rigidbodyBarAli.velocity.x, VelSubida+VelocidadFrenado);
            }
        }
        // Debug.Log(" velocidad frenado: "+VelocidadFrenado+ " velocidadMovimiento: "+VelSubida+
        //     "velocidadTotal: "+rigidbodyBarAli.velocity.y);
    }    
    void OnTriggerEnter2D(Collider2D otro)
    {
        if(otro.CompareTag("BarraFija"))
        {
            //Debug.Log("Entro en contacto");
            VelSubida= VelSubida*-1;
            SwSube=!SwSube;
        }
    }
    
}
