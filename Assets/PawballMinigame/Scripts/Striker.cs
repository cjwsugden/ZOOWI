using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Striker : MonoBehaviour
{

     public float bounceFactor = 0.9f; // Determines how the ball will be bouncing after landing. The value is [0..1]
     public float forceFactor = 10f;
     public float tMax = 5f; // Pressing time upper limit
 
     private float kickStart; // Keeps time, when you press button
     private float kickForce; // Keeps time interval between button press and release 
     private Vector3 prevVelocity; // Keeps rigidbody velocity, calculated in FixedUpdate()
     private GameObject player;
     public Transform cat;
     public Transform goal;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = cat.position; 

        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", true);
    }

    void OnTriggerEnter(Collider col){
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
             if (col.gameObject.CompareTag("Ball")) {
                transform.root.parent = col.transform;
                
                GetComponent<Rigidbody>().Sleep();
                }
                 agent.destination = goal.position; 
             
    }
    void OnTriggerExit(Collider col){
       
         transform.parent = null;
         
    }




    void OnTriggerStay(Collider col){
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
       if(col.gameObject.tag == "Ball") // Rename ball object to "Ball" in Inspector, or change name here
                     kickForce = 0.3f;
                     
                    

        if(kickForce != 0)
         {
             float angle = Random.Range(0,20) * Mathf.Deg2Rad;
             GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 
                                            forceFactor * Mathf.Clamp(kickForce, 0.0f, tMax) * Mathf.Sin(angle),
                                            forceFactor * Mathf.Clamp(kickForce, 0.0f, tMax) * Mathf.Cos(angle)), 
                                ForceMode.VelocityChange); 
             kickForce = 0;
         }

         prevVelocity = GetComponent<Rigidbody>().velocity;
         
         if(col.gameObject.tag == "Ground") // Do not forget assign tag to the field
         {
             GetComponent<Rigidbody>().velocity = new Vector3(prevVelocity.x, 
                                              -prevVelocity.y * Mathf.Clamp01(bounceFactor), 
                                              prevVelocity.z);
         }
         
         

         
     }
}
