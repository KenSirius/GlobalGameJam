using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu1raEscena : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {        
    }
    public void Pausar()
    {
        Time.timeScale=0f;
    }
    public void Continuar()
    {
        Time.timeScale=1f;
    }
    public void Reiniciar()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Salir()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene("EscenaInicio");
    }
    public void SiguienteEscena()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }        
}
