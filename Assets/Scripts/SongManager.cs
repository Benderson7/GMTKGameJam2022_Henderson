using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SongManager : MonoBehaviour
{
    public TextAsset jsonFile;
    public double halfBufferRange;
    public double doublePrecision;
    private List<Note> notes;
    public NoteBlock noteBlock;
    public TimeClock timeClock;
    public double preHitSpawnTime;

    void Update()
    {
        if (timeClock.started)
        {
            foreach (Note note in GetNotes(note => AlmostEqual(note.time, timeClock.timeElapsed.TotalSeconds - preHitSpawnTime)))
            {
                if (note.midi == 64)
                {
                    Instantiate(noteBlock, new Vector2(-9.5f, 3.5f), Quaternion.identity);
                }
                else if (note.midi == 69)
                {
                    Instantiate(noteBlock, new Vector2(9.5f, 3.5f), Quaternion.identity);
                }
            }
        }
    }

    public bool CloseEnough(double noteTime, double time)
    {
        bool closeEnough = time < noteTime + halfBufferRange && time > noteTime - halfBufferRange;
        if (closeEnough)
        {
            // Debug.Log($"Note's Time Value: {noteTime}\n Key Pressed At: {time}");  
        }
        return closeEnough;
    }

    public Note[] GetNotes(Predicate<Note> predicate)
    {
        notes = notes ?? new List<Note>(NoteMap.CreateFromJSON(jsonFile.text).notes);
        return notes.FindAll(predicate).ToArray();
    }

    private bool AlmostEqual(double value1, double value2)
    {
        return Math.Abs(value1 - value2) < doublePrecision; 
    }
}
