using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    public TextAsset jsonFile;
    public double halfBufferRange = 0.05;
    private List<Note> notes;
    public Note[] GetCurrentNotes(double time)
    {
        notes = notes ?? new List<Note>(NoteMap.CreateFromJSON(jsonFile.text).notes);
        return notes.FindAll(note => CloseEnough(note.time, time)).ToArray();
    }

    private bool CloseEnough(double noteTime, double time)
    {
        bool closeEnough = time < noteTime + halfBufferRange && time > noteTime - halfBufferRange;
        if (closeEnough)
        {
            Debug.Log($"Note's Time Value: {noteTime}\n Key Pressed At: {time}");  
        }
        return closeEnough;
    }
}
