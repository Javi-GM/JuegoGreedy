using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public GreedyGameManager GGM;

    public void NewGame()
    {
        GGM.restartPlayerData();
        GGM.savePlayerData();
        SceneManager.LoadScene("Nivel"+GGM.getNivel());
    }

    public void Continue()
    {
        if (GGM.getVidas() <= 0) { GGM.setVidas(3); }
        GGM.setPuntuacion(GGM.getPuntuacion()-200);
        GGM.savePlayerData();
        SceneManager.LoadScene("Nivel" + GGM.getNivel());
    }

    public void EndGame()
    {
        Debug.Log("Cerrar");
        GGM.savePlayerData();
        Application.Quit();
    }
}
