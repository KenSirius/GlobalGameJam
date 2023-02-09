using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GanarPuntaje : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {   
        if(GameObject.Find("BarraCompleta")!=null)
        {  
            slider= GameObject.Find("BarraCompleta").GetComponent<Slider>();
        }
    }

    // Update is called once per frame
    public void CambiarBarraMaxima(float barraMaxima)
    {
        slider.maxValue = barraMaxima;
    }
    public void CambiarBarraActual(float barraActual)
    {
        //Debug.Log("entro a cambiar barra. El valor recibido fue: "+ barraActual);
        slider.SetValueWithoutNotify(barraActual);
        //Debug.Log("valor posterior al cambio: "+ slider.value);
    }
    public void InicializarBarra(float barra)
    {
        //Debug.Log("entro a inicializar barra");
        CambiarBarraActual(barra);
        CambiarBarraMaxima(barra);
    }
}
