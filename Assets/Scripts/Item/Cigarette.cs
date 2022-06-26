using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cigarette : Item
{
    public override string ItemName => "Cigarette";

    public override void Use()
    {
        Debug.Log("Cigarette Used.");
        Destroy(gameObject);
    }
}
