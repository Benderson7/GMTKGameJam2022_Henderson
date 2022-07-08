using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreboardManager : MonoBehaviour
{
    int hitsCount, missesCount = 0;
    public TMP_Text hitsText, missesText;

    public void UpdateScoreboard(ActionManager.Action hit)
    {
        switch (hit)
        {
            case ActionManager.Action.HIT:
                hitsCount++;
                break;
            case ActionManager.Action.MISS:
                missesCount++;
                break;
            default:
                break;
        }
        UpdateScoreboardText();
    }

    private void UpdateScoreboardText()
    {
        hitsText.text = string.Format("{0} Hits", hitsCount);
        missesText.text = string.Format("{0} Misses", missesCount);
    }
}
