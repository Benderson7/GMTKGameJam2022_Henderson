using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SongManager : MonoBehaviour
{
    public TextAsset jsonFile;
    public double halfBufferRange;
    public double doublePrecision;
    public Note[] notes;
    public NoteBlock noteBlock;
    public TimeClock timeClock;
    public double preHitSpawnTime;

    void Start()
    {
        NoteMap map = NoteMap.CreateFromJSON(jsonFile.text);
        timeClock.totalTime = map.duration;
        notes = map.notes;
    }

    void Update()
    {
        if (timeClock.started)
        {

            Note[] tempNotes = GetNotes(note => {return AlmostEqual(note.time, timeClock.timeElapsed.TotalSeconds - preHitSpawnTime) && !note.hasSpawned;});
            //For all notes whose time it is to spawn
            for(int i = 0; i < tempNotes.Length; i++)
            {
                Note note = tempNotes[i];

                //Spawn left
                if (note.midi == 64)
                {
                    NoteBlock block = Instantiate(noteBlock, new Vector2(-9.5f, 3.5f), Quaternion.identity);
                    block.noteInfo = note;
                }
                //Spawn right
                else if (note.midi == 69)
                {
                    NoteBlock block = Instantiate(noteBlock, new Vector2(9.5f, 3.5f), Quaternion.identity);
                    block.noteInfo = note;
                }

                tempNotes[i].hasSpawned = true;
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
        notes = notes.Length > 0 ? notes : NoteMap.CreateFromJSON(jsonFile.text).notes;
        return Array.FindAll(notes, predicate);
    }

    public NoteBlock[] GetNoteBlocks(Predicate<NoteBlock> predicate)
    {
        return Array.FindAll(GameObject.FindObjectsOfType<NoteBlock>(), predicate);
    }

    private bool AlmostEqual(double value1, double value2)
    {
        return Math.Abs(value1 - value2) < doublePrecision; 
    }
}
