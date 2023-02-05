using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class toFireKitchen : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("fireKitchen");
    }
    private void OnMouseDown()
    {
         ChangeScene();
        Debug.Log("Click en la imagen");
    }
}
