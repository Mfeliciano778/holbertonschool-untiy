using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    public Stopwatch timer;
    public bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        timer = new Stopwatch();
        // TimerText.text = "0:00.00";
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
            timer.Start();
        TimeSpan timeSpan = timer.Elapsed;
        TimerText.text = string.Format("{0:00}:{1:00}.{2:00}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);
    }
}
