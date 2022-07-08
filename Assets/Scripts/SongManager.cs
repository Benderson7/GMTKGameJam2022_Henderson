using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    public TextAsset jsonFile;
    private NoteMap? noteMap;
    public Note[] GetCurrentNotes(double time)
    {
        noteMap = noteMap ?? NoteMap.CreateFromJSON(jsonFile.text);
        return new Note[0];
    }
}
