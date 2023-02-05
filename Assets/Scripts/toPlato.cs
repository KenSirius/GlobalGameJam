using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class toPlato : MonoBehaviour
{
     public void ChangeScene()
    {
        SceneManager.LoadScene("platoServido");
    }
    private void OnMouseDown()
    {
         ChangeScene();
        Debug.Log("Click en la imagen");
    }
}
