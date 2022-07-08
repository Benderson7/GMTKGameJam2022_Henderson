using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public ScoreboardManager scoreboardManager;

    void Update()
    {
        if (Input.anyKeyDown) {
            ActionManager.Action hit = ActionManager.Hit();
            scoreboardManager.UpdateScoreboard(hit);
        }
    }
}
