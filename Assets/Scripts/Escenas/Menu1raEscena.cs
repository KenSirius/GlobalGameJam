using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu1raEscena : MonoBehaviour
{
    // Start is called before the first frame update
    public void Pausar()
    {
        Time.timeScale=0f;
    }
    public void Continuar()
    {
        Time.timeScale=1f;
    }
    public void Salir()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene("EscenaInicio");
    }
}
