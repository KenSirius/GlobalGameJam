using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    // Start is called before the first frame update
    public void Iniciar()
    {
        SceneManager.LoadScene("1raEscena");
    }
    public void Salir()
    {
        Debug.Log("salio");
        Application.Quit();
    }
}
