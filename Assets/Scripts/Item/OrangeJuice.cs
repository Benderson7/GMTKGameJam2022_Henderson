using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeJuice : Item
{
    public override string ItemName => "Cigarette";

    public PlayerMovement playerMovement;

    public SpriteRenderer spriteRenderer;
    public override void Use()
    {
        playerMovement.topSpeed *= 2;
        Debug.Log("Orange Juice Used.");
        spriteRenderer.color = Color.yellow;
        Destroy(gameObject);
    }
}
