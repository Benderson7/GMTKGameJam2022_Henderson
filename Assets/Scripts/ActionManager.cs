using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActionManager : MonoBehaviour
{
    public enum Action
    {
        HIT,
        MISS,
        OTHER
    }

    public static Action Hit(Note[] correctNotes)
    {
        Action hit = Action.OTHER;
        if (Input.GetKeyDown(KeyCode.F))
        {
            hit = Array.Exists(correctNotes, note => note.midi == 64) ? Action.HIT : Action.MISS;
        }
        if (Input.GetKeyDown(KeyCode.J) && hit != Action.MISS)
        {
            hit = Array.Exists(correctNotes, note => note.midi == 69) ? Action.HIT : Action.MISS;
        }
        Debug.Log(hit);
        return hit;
    }
}
