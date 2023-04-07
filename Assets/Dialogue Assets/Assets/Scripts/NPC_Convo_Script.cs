using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPC_Convo_Script : MonoBehaviour
{
    public NPCConversation myConvo;
    public GameObject currentConversation;
    public GameObject nextConversation;
    //public script interI;
    //public script move;

    
    public void StartConvo()
    {
        ConversationManager.Instance.StartConversation(myConvo);
        //Cursor.lockState = CursorLockMode.Confined;
        //conversationFocus.SetActive(true);
        //interI.SetActive(false);
        //move.SetActive(false);
        
    }
    
    public void DeactivaeConvo()
    {
        currentConversation.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        //interI.SetActive(false);
        //move.SetActive(false);
    }

    public void ActivateConvo()
    {
        nextConversation.SetActive(true);
    }


}
