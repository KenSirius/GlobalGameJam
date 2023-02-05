using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionPuntaje : MonoBehaviour
{
    private Rigidbody2D rigidbodyPuntaje;
    public int contador=0;
    public float contadorTiempo=0;
    public float contadorTiempoFuera=0;
    public bool restar=false;
    public int BarraLograda=10;

    public GameObject ObjetoBarra;
    public GanarPuntaje barraLogro;

    public Animator animator;
    public GameObject objeto;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyPuntaje = GetComponent<Rigidbody2D>();
        barraLogro = ObjetoBarra.GetComponent<GanarPuntaje>();
        Debug.Log(BarraLograda+"+++"+contador);
        barraLogro.InicializarBarra(BarraLograda);
        barraLogro.CambiarBarraActual(contador);
        animator = objeto.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if(restar)
        {
            contadorTiempoFuera=Time.deltaTime+contadorTiempoFuera;            
            if(contadorTiempoFuera>1)
            {
                contador=contador-2;
                contadorTiempoFuera=0;
            }
        }
        Debug.Log(contador);
        barraLogro.CambiarBarraActual(contador);
        if(contador==10)
        {
            Debug.Log("Ganaste");
            animator.SetBool("SePico",true);
        }
        if(contador<=0)
        {
            contador=0;
        }
    }
    void OnTriggerStay2D(Collider2D otro)
    {
        if(otro.CompareTag("Puntuador"))
        {
            restar=false;
            contadorTiempo= Time.deltaTime+contadorTiempo;   
            //Debug.Log(contadorTiempo+" --- "+contador);                   
            if(contadorTiempo>=1)            
            {
                contador=contador+2;
                contadorTiempo=0;
            }
        }
    }
    void OnTriggerExit2D(Collider2D otro)
    {
        Debug.Log("Salio");
        if(otro.CompareTag("Puntuador"))
        {
            restar=true;
        }
    }
}
