using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreedyGameManager : MonoBehaviour
{
    private int nivel = 1;
    private int puntuacion = 0;
    private int vidas = 3;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Nivel")){ nivel = PlayerPrefs.GetInt("Nivel"); }
        if (PlayerPrefs.HasKey("Puntuacion")) { puntuacion = PlayerPrefs.GetInt("Puntuacion"); }
        if (PlayerPrefs.HasKey("Vidas")) { vidas = PlayerPrefs.GetInt("Vidas"); }
    }

    public int getNivel() { return nivel; }
    public int getPuntuacion() { return puntuacion; }
    public int getVidas() { return vidas; }

    public void setNivel(int n) { Debug.Log("N: " + nivel); nivel = Mathf.Min(3,n); }
    public void setPuntuacion(int p) { Debug.Log("P: "+puntuacion); puntuacion = p; }
    public void setVidas(int v) { vidas = v; }

    public void savePlayerData()
    {
        PlayerPrefs.SetInt("Nivel", nivel);
        PlayerPrefs.SetInt("Puntuacion", puntuacion);
        PlayerPrefs.SetInt("Vidas", vidas);

        PlayerPrefs.Save();
    }
    public void restartPlayerData()
    {
        nivel = 1;
        puntuacion = 0;
        vidas = 3;
    }

}
