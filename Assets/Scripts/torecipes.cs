using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class torecipes : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("recipes");
    }
    private void OnMouseDown()
    {
         ChangeScene();
        Debug.Log("Click en la imagen");
    }
}
