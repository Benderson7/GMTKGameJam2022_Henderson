using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class SongManager : MonoBehaviour
{
    public TextAsset jsonFile;
    public double doublePrecision;
    public NoteBlock noteBlock;
    public double preHitSpawnTime;
    public TimeClock timeClock;
    private Note[] notes;
    private List<Note> spawnedNotes = new();
    private static readonly Dictionary<int, KeyCode> midiToKeyCodes = new()
    {
        { 64, KeyCode.F},
        { 69, KeyCode.J}
    };
    private static readonly Dictionary<int, Vector2> midiToPositions = new()
    {
        { 64, new Vector2(-3.195f, 3.7f)},
        { 69, new Vector2(3.315f, 3.7f)}
    };

    void Start()
    {
        NoteMap map = NoteMap.CreateFromJSON(jsonFile.text);
        timeClock.totalTime = map.duration;
        notes = map.notes;
    }

    public List<NoteBlock> SpawnBlocks(double timeElapsed, double bpm)
    {
        Note[] notesToSpawn = GetNotes(note => AlmostEqual((note.time - preHitSpawnTime) / bpm * 120, timeElapsed) && !spawnedNotes.Contains(note));
        return notesToSpawn.Select(note => Spawn(note)).ToList();
    }

    public Note[] GetNotes(Predicate<Note> predicate)
    {
        return Array.FindAll(notes, predicate);
    }

    public bool AlmostEqual(double value1, double value2)
    {
        return Math.Abs(value1 - value2) < doublePrecision; 
    }
    
    private NoteBlock Spawn(Note note)
    {
        noteBlock.keyCode = midiToKeyCodes[note.midi];
        noteBlock.time = note.time;
        spawnedNotes.Add(note);
        return Instantiate(noteBlock, midiToPositions[note.midi], Quaternion.identity);
    }
}
