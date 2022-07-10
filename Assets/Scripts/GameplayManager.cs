using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class GameplayManager : MonoBehaviour
{
    private enum State
    {
        IDLE,
        IN_PROGRESS
    }
    public ScoreboardManager scoreboardManager;
    public SongManager songManager;
    public TimeClock timeClock;
    public AudioSource song;
    public TimeProgress progress;
    public double hitBuffer;
    public double postUnhitDespawnTime;
    public double bpm;

    private State state;
    private List<NoteBlock> currentNoteBlocks = new();
    private static readonly KeyCode[] HitKeys = new KeyCode[] { KeyCode.F, KeyCode.J };

    void Start()
    {
        this.state = State.IDLE;
    }

    void Update()
    {
        switch (this.state)
        {
            case State.IDLE:
                Idle();
                break;
            case State.IN_PROGRESS:
                InProgress();
                break;
            default:
                Debug.LogError($"Unexpected state: {state}");
                break;
        }
    }

    private void Idle()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            state = State.IN_PROGRESS;
            timeClock.StartClock();
            song.Play();
        }
    }

    private void InProgress()
    {
        double timeElapsed = timeClock.Advance();
        progress.UpdateProgress();
        currentNoteBlocks = currentNoteBlocks.Concat(songManager.SpawnBlocks(timeElapsed, bpm)).ToList();
        Action hit = HitNotes(timeElapsed);
        scoreboardManager.UpdateScoreboard(hit);
        int unhits = CountUnhits(timeElapsed);
        for (int i = 0; i < unhits; i++)
        {
            scoreboardManager.UpdateScoreboard(Action.MISS);
        }
    }

    private Action HitNotes(double timeElapsed)
    {
        List<KeyCode> keysPressed = new();
        foreach (KeyCode keyCode in HitKeys)
        {
            if (Input.GetKeyDown(keyCode))
            {
                keysPressed.Add(keyCode);
            }
        }
        switch (keysPressed.Count)
        {
            case 0:
                return Action.NONE;
            case 1:
                return HitNoteBlock(keysPressed[0], timeElapsed);
            case 2:
                bool hit = (HitNoteBlock(KeyCode.F, timeElapsed), HitNoteBlock(KeyCode.J, timeElapsed)) == (Action.HIT, Action.HIT);
                return hit ? Action.HIT : Action.MISS;
            default:
                Debug.LogError("Somehow pressed more keys than expected.");
                return Action.NONE;
        }
    }

    private Action HitNoteBlock(KeyCode keyPressed, double timeElapsed)
    {
        Action action = Action.MISS;
        List<NoteBlock> noteBlocksToHit = HittableNoteBlocks(timeElapsed);
        foreach (NoteBlock noteBlock in noteBlocksToHit)
        {
            action = noteBlock.Hit(keyPressed, timeElapsed) == Action.HIT ? Action.HIT : action;
            if (action == Action.HIT)
            {
                currentNoteBlocks.Remove(noteBlock);
            }
        }
        return action;
    }

    private List<NoteBlock> HittableNoteBlocks(double timeElapsed)
    {
        return currentNoteBlocks.FindAll(noteBlock => noteBlock.time / bpm * 120 < timeElapsed + hitBuffer && noteBlock.time / bpm * 120 > timeElapsed - hitBuffer);
    }

    private int CountUnhits(double timeElapsed)
    {
        int count = 0;
        List<NoteBlock> unhitNotes = currentNoteBlocks.FindAll(noteBlock => (noteBlock.time + postUnhitDespawnTime) / bpm * 120 < timeElapsed);
        foreach (NoteBlock noteBlock in unhitNotes)
        {
            count++;
            currentNoteBlocks.Remove(noteBlock);
            noteBlock.Despawn();
        }
        return count;
    }
}
