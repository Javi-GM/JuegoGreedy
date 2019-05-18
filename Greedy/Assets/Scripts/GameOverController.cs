using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        Debug.Log("Cerrar");
        Application.Quit();
    }
}
