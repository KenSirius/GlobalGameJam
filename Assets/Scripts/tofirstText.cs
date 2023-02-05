using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class tofirstText : MonoBehaviour
{
     public void ChangeScene()
    {
        SceneManager.LoadScene("firstText");
    }
    private void OnMouseDown()
    {
        Debug.Log("Click en la imagen");
         ChangeScene();
        
    }
}
