using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //Top topSpeed of player
    public float topSpeed;

    //Time to get to player top speed
    public float topSpeedTime;

    //Current vector at which the player is moving
    Vector2 curSpeed;
    Vector2 prevSpeed;
    int speedLerp;

    float timePressed;

    Vector2 targetMovement;

    public SpriteRenderer spriteRenderer;
    public Sprite idleSprite;
    public Sprite movementSprite;

    // Start is called before the first frame update
    void Start()
    {
        targetMovement = new Vector2();
        timePressed = 0;

        if(topSpeedTime == 0)
        {
            topSpeedTime = 0.0000001f;
        }
    }

    void changeImage()
    {
        KeyCode[] movementKeys = new KeyCode[] {KeyCode.A, KeyCode.W, KeyCode.S, KeyCode.D};
        bool moving = false;
        foreach (var key in movementKeys)
        {
            if (Input.GetKey(key))
            {
                moving = true;
            }
        }
        spriteRenderer.sprite = moving ? movementSprite : idleSprite;
    }

    // Update is called once per frame
    void Update()
    {
        changeImage();
        Vector2 refMovement = new Vector2();
        if(Input.anyKey)
        {
            if(Input.GetKey(KeyCode.A))
            {
                refMovement += new Vector2(-1, 0);
            }
            if(Input.GetKey(KeyCode.D))
            {
                refMovement += new Vector2(1, 0);
            }
            if(Input.GetKey(KeyCode.W))
            {
                refMovement += new Vector2(0, 1);
            }
            if(Input.GetKey(KeyCode.S))
            {
                refMovement += new Vector2(0, -1);
            }

            if(curSpeed != refMovement)
            {
                prevSpeed = targetMovement;
                curSpeed = refMovement;
                timePressed = 0;
            }
        }
        else if(curSpeed.magnitude != 0)
        {
            timePressed = 0;
            prevSpeed = targetMovement;
            curSpeed = new Vector2();
        }


        if(timePressed != topSpeedTime)
        {
            timePressed = Mathf.Min(timePressed + Time.deltaTime, topSpeedTime);
            targetMovement = Vector2.Lerp(prevSpeed, curSpeed, timePressed / topSpeedTime);           
        }

        if(targetMovement.magnitude > 0)
        {
            transform.position += new Vector3(targetMovement.x, targetMovement.y, 0) * topSpeed * Time.deltaTime;
        }
    }
}
