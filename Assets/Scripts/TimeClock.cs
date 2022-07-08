using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TimeClock : MonoBehaviour
{
    public TMP_Text timeClock;
    bool started;

    DateTime timeStarted;

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            timeClock.text = DateTime.Now.Subtract(timeStarted).ToString("mm\\:ss\\:ff");
        }
        else
        {
            if (Input.anyKey)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    timeStarted = DateTime.Now;
                    started = true;
                }
            }
        }
    }
}
