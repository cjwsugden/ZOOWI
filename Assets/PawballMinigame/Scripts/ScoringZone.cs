using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScoringZone : MonoBehaviour
{
    //public AudioClip scoreSound;

    void Start ()   
     {
        // GetComponent<AudioSource> ().playOnAwake = false;
        // GetComponent<AudioSource> ().clip = scoreSound;

     }  

    public EventTrigger.TriggerEvent scoreTrigger;

    private void OnCollisionEnter(Collision collision){
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null){
            BaseEventData eventData = new BaseEventData(EventSystem.current);
            this.scoreTrigger.Invoke(eventData);
            //GetComponent<AudioSource>().Play();

        }
            
    }

}
