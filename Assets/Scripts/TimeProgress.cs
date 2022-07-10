using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeProgress : MonoBehaviour
{
    enum State
    {
        EMPTY,
        PERCENT_25,
        PERCENT_50,
        PERCENT_75,
        FULL
    }
    public List<Sprite> meterStates;
    public string SceneName;
    public TimeClock timeClock;
    private State state;

    void Start()
    {
        state = State.EMPTY;
    }

    public void UpdateProgress()
    {
        switch (state)
        {
            case State.EMPTY:
                UpdateState(0.25, 0, State.PERCENT_25);
                break;
            case State.PERCENT_25:
                UpdateState(0.5, 1, State.PERCENT_50);
                break;
            case State.PERCENT_50:
                UpdateState(0.75, 2, State.PERCENT_75);
                break;
            case State.PERCENT_75:
                UpdateState(1, 3, State.FULL);
                break;
            default:
                break;
        }
    }

    private void UpdateState(double changeAtRatio, int indexOfNextSprite, State nextState)
    {
        double currentRatio = timeClock.timeElapsed.TotalSeconds / timeClock.totalTime;
        if (currentRatio > changeAtRatio)
        {
            Debug.Log($"Current Ratio: {currentRatio}\nChange At Ratio: {changeAtRatio}\nChanging to State: {nextState}");
            this.GetComponent<SpriteRenderer>().sprite = meterStates[indexOfNextSprite];
            state = nextState;
        }
        if(currentRatio > 1.0f)
            SceneManager.LoadScene(SceneName);
        // this.transform.GetChild(0).GetComponent<Image>().fillAmount = (float) ((float)timeClock.timeElapsed.Seconds / timeClock.totalTime);
    }
}
