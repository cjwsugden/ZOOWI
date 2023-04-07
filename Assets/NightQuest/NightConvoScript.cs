using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NightConvoScript : MonoBehaviour
{
    public NPCConversation myConvo;
    public GameObject currentConversation;
    public GameObject nextConversation1;
    public GameObject nextConversation2;
    public GameObject waterSceneTransfer;
    public GameObject cardsSceneTransfer;

    
    public void StartConvo()
    {
        ConversationManager.Instance.StartConversation(myConvo);

        
    }
    
    public void DeactivateConvo()
    {
        currentConversation.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;

    }

    public void ActivateConvo1()
    {
        nextConversation1.SetActive(true);
    }

    public void ActivateConvo2()
    {
        nextConversation2.SetActive(true);
    }

    public void waterScene()
    {
        waterSceneTransfer.SetActive(true);
    }

    public void cardsScene()
    {
        cardsSceneTransfer.SetActive(true);
    }



}
