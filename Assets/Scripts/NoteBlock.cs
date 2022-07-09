using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBlock : MonoBehaviour
{
    public float speed;
    public Note noteInfo;

    // Update is called once per frame
    void Update()
    {
        Vector3 curPos = transform.position;
        transform.position = new Vector3(curPos.x, curPos.y - speed, curPos.z);
    }
}
