using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text timerText;
    private float secondsCount = 0;
    private int minuteCount = 1;

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
