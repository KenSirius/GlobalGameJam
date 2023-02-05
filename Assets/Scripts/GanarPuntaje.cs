using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GanarPuntaje : MonoBehaviour
{
    public GameObject objeto;
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {   
        objeto= GameObject.Find("BarraCompleta");     
        slider=objeto.GetComponent<Slider>();
    }

    // Update is called once per frame
    public void CambiarBarraMaxima(int barraMaxima)
    {
        slider.maxValue = barraMaxima;
    }
    public void CambiarBarraActual(int barraActual)
    {
        Debug.Log("entro a cambiar barra. El valor recibido fue: "+ barraActual);
        slider.value = barraActual;
        
        Debug.Log("valor posterior al cambio: "+slider.value);
    }
    public void InicializarBarra(int barra)
    {
        Debug.Log("entro a inicializar barra");
        CambiarBarraActual(barra);
        CambiarBarraMaxima(barra);
    }
    void Update()
    {
        
    }
}
