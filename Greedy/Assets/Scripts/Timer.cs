using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public GreedyMovement Player;

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
            if (minuteCount < 0) { Player.Fail(); }
            secondsCount = 60;
        }

    }

    public int getTime() { return (minuteCount * 60) + (int)secondsCount; }
}
