using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public ScoreboardManager scoreboardManager;
    public SongManager songManager;
    public TimeClock timeClock;
    public NoteBlock noteBlock; // Temp
    void Update()
    {
        if (Input.anyKeyDown) {
            if (timeClock.started)
            {
                double curTime = timeClock.timeElapsed.TotalSeconds;
                Note[] notes = songManager.GetCurrentNotes(curTime);
                ActionManager.Action hit = ActionManager.Hit(notes);
                scoreboardManager.UpdateScoreboard(hit);
            } else if (Input.GetKey(KeyCode.Space))
            {
                timeClock.StartClock();
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                Debug.Log("Note Block Created.");
                Instantiate(noteBlock, new Vector2(0, 0), Quaternion.identity);
            }
        }
    }
}
