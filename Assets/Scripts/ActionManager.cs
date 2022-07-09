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

    public static Action Hit(NoteBlock[] correctNotes)
    {
        Action hit = Action.OTHER;
        if (Input.GetKeyDown(KeyCode.F))
        {
            NoteBlock notes = Array.Find(correctNotes, note => note.noteInfo.midi == 64);
            if(notes != null)
            {
                hit = Action.HIT;
                Destroy(notes.transform.parent);
            }
            else
            {
                hit = Action.MISS;
            }
            //hit = Array.Exists(correctNotes, note => note.midi == 64) ? Action.HIT : Action.MISS;
        }
        if (Input.GetKeyDown(KeyCode.J) && hit != Action.MISS)
        {
            hit = Array.Exists(correctNotes, note => note.noteInfo.midi == 69) ? Action.HIT : Action.MISS;
        }
        Debug.Log(hit);
        return hit;
    }
}
