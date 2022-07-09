using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBlock : MonoBehaviour
{
    public float speed;
    public KeyCode keyCode;
    public double time;
    
    void Update()
    {
        MoveDown();
    }

    // Side Effect: Destroys this if it is a hit
    public Action Hit(KeyCode keyPressed, double timePressed)
    {
        if (keyPressed == keyCode)
        {
            Destroy(gameObject, 0.1f);
            return Action.HIT;
        }
        return Action.MISS;
    }

    public void Despawn()
    {
        Destroy(gameObject);
    }

    private void MoveDown()
    {
        Vector3 curPos = transform.position;
        transform.position = new Vector3(curPos.x, curPos.y - speed, curPos.z);
    }
}
