using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActDesact : MonoBehaviour
{
    public GameObject AlimentoDesa;
    public GameObject BarraInter;
    public GameObject BarraComple;

    public GameObject Recetario;
    public GameObject Ticket;
    [SerializeField] private Animator animacionPlato;
    // Start is called before the first frame updateç
    void Start()
    {
        //AlimentoDesa = GameObject.Find("Carne");
        //BarraComple = GameObject.Find("BarraCompleta");
        animacionPlato = GetComponent<Animator>();
        //BarraInter = GameObject.Find("BarraInteractuable");
        //Recetario = GameObject.Find("LibroReceta");
        //Ticket = GameObject.Find("Ticket");
    }
    public void ActivarOtros()
    {
        animacionPlato.SetBool("SePico",true);
    }
    public void DesActivar()
    {
        Recetario.SetActive(true);
        Ticket.SetActive(true);
        AlimentoDesa.SetActive(false);
        BarraComple.SetActive(false);
        BarraInter.SetActive(false);
        Time.timeScale=0f;
    }
}
