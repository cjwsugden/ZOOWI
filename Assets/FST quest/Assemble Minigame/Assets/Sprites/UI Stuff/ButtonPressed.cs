using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ButtonPressed : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{


    public GameObject UI;
    public GameObject BG;
    public AudioClip clip;
    public AudioSource asource;


    public void OnPointerDown(PointerEventData eventData)
    {
        asource.PlayOneShot(clip);
        Invoke("removeUI", 1);

    }


     public void OnPointerUp(PointerEventData eventData)
    {
        //img = default;
    }

    public void removeUI(){
        UI.gameObject.SetActive(false);
        BG.gameObject.SetActive(true);
    }


}
