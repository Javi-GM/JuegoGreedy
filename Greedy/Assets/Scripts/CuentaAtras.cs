using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuentaAtras : MonoBehaviour
{

    public Text timerText;
    public float secondsCount;
    public int minuteCount;

    void Start()
    {
        timerText.text = minuteCount.ToString("00") + ((int)secondsCount).ToString("00");
    }

// Update is called once per frame
    void Update()
    {
      UpdateTimerUI();  
    }

    public void UpdateTimerUI()
    {
        //set timer UI
        secondsCount -= Time.deltaTime;
        timerText.text = minuteCount.ToString("00") + ":" + ((int)secondsCount).ToString("00");
        if (secondsCount <= 0)
        {
            minuteCount--;
            secondsCount = 60;
        }

    }
}




