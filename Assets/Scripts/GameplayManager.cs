using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public ScoreboardManager scoreboardManager;
    public SongManager songManager;
    public TimeClock timeClock;
    public AudioSource song;
    void Update()
    {
        if (Input.anyKeyDown) {
            if (timeClock.started)
            {
                double curTime = timeClock.timeElapsed.TotalSeconds;
                Note[] notes = songManager.GetNotes(note => songManager.CloseEnough(note.time, curTime));
                ActionManager.Action hit = ActionManager.Hit(notes);
                scoreboardManager.UpdateScoreboard(hit);
            } else if (Input.GetKey(KeyCode.Space))
            {
                timeClock.StartClock();
                song.Play();
            }
        }
    }
}
