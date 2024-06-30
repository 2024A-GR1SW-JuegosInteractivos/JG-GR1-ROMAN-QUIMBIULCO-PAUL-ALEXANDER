using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void OnButtonClick()
    {
        Debug.Log("El botón ha sido clickeado!");
        SceneManager.LoadScene(0);
    }
}
