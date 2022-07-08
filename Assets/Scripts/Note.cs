using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Note
{
    public int midi;
    public double time;
    
    public override string ToString() => $"<Note: midi({midi}), time({time})>";
}
