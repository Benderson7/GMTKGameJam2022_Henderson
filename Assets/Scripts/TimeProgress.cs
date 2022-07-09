using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeProgress : MonoBehaviour
{
    public TimeClock timeClock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateProgress()
    {
        this.transform.GetChild(0).GetComponent<Image>().fillAmount = (float) ((float)timeClock.timeElapsed.Seconds / timeClock.totalTime);
    }
}
