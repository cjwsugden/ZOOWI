using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class CocoConversation : MonoBehaviour
{
    public NPCConversation myConversation;

    public void InteractWith()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ConversationManager.Instance.StartConversation(myConversation);
        }
    }
}
