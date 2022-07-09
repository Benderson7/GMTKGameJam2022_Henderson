using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TimeClock : MonoBehaviour
{
    public TMP_Text timeClock;
    public bool started { get; private set; } = false;

    DateTime timeStarted;

    public TimeSpan timeElapsed { get; private set; }

    public double totalTime;

    void Update()
    {
        if (started)
        {
            timeElapsed = DateTime.Now.Subtract(timeStarted);
            timeClock.text = timeElapsed.ToString("mm\\:ss\\:ff");
        }
    }

    public void StartClock()
    {
        timeStarted = DateTime.Now;
        started = true;
    }
}
