using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarPuntuacion : MonoBehaviour
{
    public Text PuntText;
    public GreedyGameManager GGM;

    // Start is called before the first frame update
    void Start()
    {
        PuntText.text = "Puntuacion: " + GGM.getPuntuacion().ToString().PadLeft(6, '0');
    }
}
