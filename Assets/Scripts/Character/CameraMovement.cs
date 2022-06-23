using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject followObject;

    Vector2 curError;
    Vector2 prevError;

    public float pconst;
    public float dconst;

    // Start is called before the first frame update
    void Start()
    {
        curError = new Vector2();
        prevError = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        prevError = curError;
        curError = this.gameObject.transform.position - followObject.transform.position;

        //Apply The Fucking PID Controller, thus admitting that my microcontrollers course wasn't a waste
        //of my time and money
        Vector2 deltaPos = (pconst * curError + dconst * (curError - prevError)) * Time.deltaTime;

        this.gameObject.transform.position -= new Vector3(deltaPos.x, deltaPos.y, 0);
    }
}
