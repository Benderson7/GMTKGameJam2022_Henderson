using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct NoteMap
{
    public Note[] notes;

    public static NoteMap CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<NoteMap>(jsonString);
    }

    public override string ToString()
    {
        string noteString = "";
        foreach (Note note in notes)
        {
            noteString += $"\t{note.ToString()}\n";
        }
        return $"<NoteMap:\n{noteString}>";
    }
}