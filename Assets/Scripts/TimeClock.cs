using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TimeClock : MonoBehaviour
{
    private enum State
    {
        IDLE,
        STARTED,
        STOPPED
    }
    public TMP_Text timeClock;
    DateTime timeStarted;
    public TimeSpan timeElapsed { get; private set; }
    private State state;
    public double totalTime;

    void Start()
    {
        state = State.IDLE;
    }

    public double Advance()
    {
        if (state != State.STARTED)
        {
            Debug.LogError($"Tried to advance clock that hasn't been started");
            return 0.0;
        } else
        {
            timeElapsed = DateTime.Now.Subtract(timeStarted);
            //timeClock.text = timeElapsed.ToString("mm\\:ss\\:ff"); // UI
            return timeElapsed.TotalSeconds;
        }
    }

    public void StartClock()
    {
        if (state != State.IDLE)
        {
            Debug.LogError($"Started a clock that has already been started.");
        }
        state = State.STARTED;
        timeStarted = DateTime.Now;
    }
}
