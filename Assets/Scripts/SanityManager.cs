using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityManager : MonoBehaviour
{
    // public int maxSanity;

    // public GameObject sanityObject;

    // private List<GameObject> sanities;

    public List<Sprite> meterStates;

    private double lastTimeFailed;

    private float sanityMeter;

    // Start is called before the first frame update
    void Start()
    {
        // sanities = new List<GameObject>();
        // for(int i = 0; i < maxSanity; i++)
        // {
        //     sanities.Add(Instantiate(sanityObject, this.transform));
        // }
        lastTimeFailed = 0;
        sanityMeter = meterStates.Count;
        this.GetComponent<SpriteRenderer>().sprite = meterStates[meterStates.Count - 1];
    }

    // Update is called once per frame
    void Update()
    {
        // for(int i = 0; i < sanities.Count; i++)
        // {
        //     if(i > sanityMeter)
        //     {
        //         sanities[i].GetComponent<Image>().color = new Color(1, 1, 1, 0);
        //     }
        //     else
        //     {
        //         sanities[i].GetComponent<Image>().color = new Color(1, 1, 1, 1);
        //     }
        // }
    }

    public void DamnSanity()
    {
        sanityMeter = Mathf.Floor(sanityMeter - 1);
        int index = (int)Mathf.Floor(sanityMeter) - 1 > 0 ? (int)Mathf.Floor(sanityMeter) - 1 : 0;
        this.GetComponent<SpriteRenderer>().sprite = meterStates[index];
    }

    public bool Insane()
    {
        return sanityMeter < 0;
    }
}
