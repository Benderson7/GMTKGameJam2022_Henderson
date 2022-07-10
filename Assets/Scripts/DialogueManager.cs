using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public List<string> Dialogue;
    private int curDialogue;

    // Start is called before the first frame update
    void Start()
    {
        curDialogue = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool AdvanceDialogue()
    {
        curDialogue++;
        if(curDialogue < Dialogue.Count)
        {
            this.gameObject.GetComponent<TextMeshProUGUI>().text = Dialogue[curDialogue];
            return true;
        }

        this.GetComponent<TextMeshProUGUI>().text = "";
        return false;
    }
}
