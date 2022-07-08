using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public ScoreboardManager scoreboardManager;
    public SongManager songManager;
    public TimeClock timeClock;

    void Update()
    {
        if (Input.anyKeyDown) {
            if (Input.GetKey(KeyCode.Space))
            {
                timeClock.Start();
            }
            if (timeClock.started)
            {
                double curTime = timeClock.timeElapsed.TotalSeconds;
                Note[] notes = SongManager.GetCurrentNotes(curTime);
                ActionManager.Action hit = ActionManager.Hit(notes);
                scoreboardManager.UpdateScoreboard(hit);
            }
        }
    }
}
