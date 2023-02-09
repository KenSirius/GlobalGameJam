using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionPuntaje : MonoBehaviour
{
    private Rigidbody2D rigidbodyPuntaje;
    public float contador=5f;
    public float contadorTiempo=0f;
    public float contadorTiempoFuera=0f;
    public bool restar=false;
    public float BarraLograda=10f;

    public GameObject ObjetoBarra;
    public GanarPuntaje barraLogro;

    public Animator animator;
    public GameObject objeto;
    [SerializeField] private float PuntajeGanado= 0f;
    [SerializeField] private float PuntajePerdido= 0f;
    [SerializeField] private GameObject ObjetoVapor;
    [SerializeField] private GameObject ObjetoBarraInter;

    [SerializeField] private GameObject Menufinal;
    // Start is called before the first frame update
    void Start()
    {        
        rigidbodyPuntaje = GetComponent<Rigidbody2D>();
        barraLogro = ObjetoBarra.GetComponent<GanarPuntaje>();
        //Debug.Log(BarraLograda+"+++"+contador);
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
                contador=contador-PuntajePerdido;
                contadorTiempoFuera=0;
            }
        }
        //Debug.Log(contador);
        barraLogro.CambiarBarraActual(contador);
        if(contador==10)
        {
            //Debug.Log("Ganaste");
            animator.SetBool("SePico",true);
            ObjetoBarra.SetActive(false);
            ObjetoVapor.SetActive(false);
            ObjetoBarraInter.SetActive(false);
        }
        if(contador<=0)
        {
            ObjetoBarra.SetActive(false);
            ObjetoVapor.SetActive(false);
            ObjetoBarraInter.SetActive(false);
            objeto.SetActive(false);
            Menufinal.SetActive(true);
            Time.timeScale=0f;
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
                contador=contador+PuntajeGanado;
                contadorTiempo=0;
            }
        }
    }
    void OnTriggerExit2D(Collider2D otro)
    {
        //Debug.Log("Salio");
        if(otro.CompareTag("Puntuador"))
        {
            restar=true;
        }
    }
}
