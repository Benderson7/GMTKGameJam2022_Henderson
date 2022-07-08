using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    public enum Action
    {
        HIT,
        MISS,
        OTHER
    }

    public static Action Hit()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            return Action.HIT;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            return Action.MISS;
        }
        return Action.OTHER;
    }
}
