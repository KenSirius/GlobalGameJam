using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class tokitchen : MonoBehaviour
{
   public void ChangeScene()
    {
        SceneManager.LoadScene("kitchen");
    }
    private void OnMouseDown()
    {
         ChangeScene();
        Debug.Log("Click en la imagen");
    }
}
