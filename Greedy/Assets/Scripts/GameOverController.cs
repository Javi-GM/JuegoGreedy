using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void EndGame()
    {
        Debug.Log("Cerrar");
        Application.Quit();
    }
}
