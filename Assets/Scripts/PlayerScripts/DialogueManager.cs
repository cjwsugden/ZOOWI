using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public NPC npc;
    bool isTalking = false;
    public bool outOfRange = true;

    float distance;
    float curResponseTracker = 0;

    public GameObject player;
    public GameObject dialogueUI;
    public GameObject NPCGUI;

    public TMP_Text Name;
    public TMP_Text DialogueBox;
    public TMP_Text playerResponse;



    void Start()
    {
        dialogueUI.SetActive(false);
    }

    void OnMouseOver()
    {
        NPCGUI.gameObject.SetActive(true);
        Invoke("popUp",1);
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance <= 3.5f)
        {
           NPCGUI.gameObject.SetActive(false);
           
            if(Input.GetKeyDown(KeyCode.Y))
            {
                curResponseTracker++;
                if(curResponseTracker >= npc.playerDialogue.Length - 1)
                {
                    curResponseTracker = npc.playerDialogue.Length - 1;
                }
            }
            else if(Input.GetKeyDown(KeyCode.U))
            {
                curResponseTracker--;
                if(curResponseTracker < 0)
                {
                    curResponseTracker = 0;
                }
            }
            //trigger dialogue
            if(Input.GetKeyDown(KeyCode.F) && isTalking == false)
            {
                StartConverstation();
                 
            }
            
           
            else if(Input.GetKeyDown(KeyCode.F) && isTalking == true)
            {
                EndDialogue();
                
            }

            if(curResponseTracker == 0 && npc.playerDialogue.Length >= 0)
            {
                playerResponse.text = npc.playerDialogue[0];
                if(Input.GetKeyDown(KeyCode.Return))
                {
                    DialogueBox.text = npc.dialogue[1];
                }
            }
            else if(curResponseTracker == 1 && npc.playerDialogue.Length >= 1)
            {
                playerResponse.text = npc.playerDialogue[1];
                if(Input.GetKeyDown(KeyCode.Return))
                {
                    DialogueBox.text = npc.dialogue[2];
                }
            }
            else if(curResponseTracker == 1 && npc.playerDialogue.Length >= 0)
            {
                playerResponse.text = npc.playerDialogue[1];
                if(Input.GetKeyDown(KeyCode.Return))
                {
                    DialogueBox.text = npc.dialogue[2];
                    EndDialogue();
                }
            }
        }
    }

    void StartConverstation()
    {
        isTalking = true;
        curResponseTracker = 0;
        dialogueUI.SetActive(true);
        Name.text = npc.name;
        DialogueBox.text = npc.dialogue[0];
        NPCGUI.gameObject.SetActive(false);
    }
    void EndDialogue()
    {
        isTalking = false;
        dialogueUI.SetActive(false);
        NPCGUI.gameObject.SetActive(false);
    }

    public void popUp(){
        NPCGUI.gameObject.SetActive(false);
    }

    



}
