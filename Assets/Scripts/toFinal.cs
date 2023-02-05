using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class toFinal : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("final");
    }
    private void OnMouseDown()
    {
         ChangeScene();
        Debug.Log("Click en la imagen");
    }
}
