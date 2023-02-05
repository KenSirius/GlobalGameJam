using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GanarPuntaje : MonoBehaviour
{
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider= GetComponent<Slider>();
    }

    // Update is called once per frame
    public void CambiarBarraMaxima(int barraMaxima)
    {
        slider.maxValue = barraMaxima;
    }
    public void CambiarBarraActual(int barraActual)
    {
        slider.value = barraActual;
    }
    public void InicializarBarra(int barra)
    {
        CambiarBarraActual(barra);
        CambiarBarraMaxima(barra);
    }
    void Update()
    {
        
    }
}
