using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject victoriaUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Victoria()
    {
        victoriaUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadMainMenu()
    {
        Resume();
        SceneManager.LoadScene("Menu");
    }

    public void NextLevel()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  //CAMBIO DE NIVEL
    }

    public void LoadOptions()
    {
        /*activar aqui el menu de opciones*/
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
