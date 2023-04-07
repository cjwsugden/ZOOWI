using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KiranWalks : MonoBehaviour
{

    public Transform SouthGatePosition;
    public Transform BusStopPosition;
    public Transform QuadranglePosition;
    public Transform sacPosition;
    public Transform AltercationPosition;
    public GameObject beacon;

    public GameObject MainConvo;
    public GameObject WalkConvo;
    
    public bool walkedBusStop;
    public bool walkedSouthGate;
    public bool walkedQuad;
    public bool walkedSAC;
    public bool walkedAlter;

    public Animator anim;
    

    NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(walkedBusStop)
        {
            agent.destination = BusStopPosition.position;
            anim.SetBool("isWalking", true);
            if(agent.transform.position.x == BusStopPosition.transform.position.x && agent.transform.position.z == BusStopPosition.transform.position.z)
            {
                anim.SetBool("isWalking", false);
                //Debug.Log("Successful Walk");

                WalkConvo.SetActive(false);
                MainConvo.SetActive(true);

                walkedBusStop = false;
            }
            
        }

        //////////////////////////////////////


        if(walkedAlter)
        {
            agent.destination = AltercationPosition.position;
            anim.SetBool("isWalking", true);
            if(agent.transform.position.x == AltercationPosition.transform.position.x && agent.transform.position.z == AltercationPosition.transform.position.z)
            {
                //Debug.Log("Successful Walk");
                anim.SetBool("isWalking", false);

                WalkConvo.SetActive(false);
                MainConvo.SetActive(true);
                walkedAlter = false;
            }
            
        }

        ///////////////////////////////////////

        if(walkedQuad)
        {
            agent.destination = QuadranglePosition.position;
            anim.SetBool("isWalking", true);
            if(agent.transform.position.x == QuadranglePosition.transform.position.x && agent.transform.position.z == QuadranglePosition.transform.position.z)
            {
                anim.SetBool("isWalking", false);
                //Debug.Log("Successful Walk");

                WalkConvo.SetActive(false);
                MainConvo.SetActive(true);
                walkedQuad = false;
            }
            
        }

        ///////////////////////////////////

        if(walkedSAC)
        {
            agent.destination = sacPosition.position;
            anim.SetBool("isWalking", true);
            if(agent.transform.position.x == sacPosition.transform.position.x && agent.transform.position.z == sacPosition.transform.position.z)
            {
                anim.SetBool("isWalking", false);
                //Debug.Log("Successful Walk");

                WalkConvo.SetActive(false);
                MainConvo.SetActive(true);
                walkedSAC = false;
            }
            
        }

        ////////////////////////////////////////

        if(walkedSouthGate)
        {
            agent.destination = SouthGatePosition.position;
            anim.SetBool("isWalking", true);
            if(agent.transform.position.x == SouthGatePosition.transform.position.x && agent.transform.position.z == SouthGatePosition.transform.position.z)
            {
                anim.SetBool("isWalking", false);
                //Debug.Log("Successful Walk");

                WalkConvo.SetActive(false);
                MainConvo.SetActive(true);
                walkedSouthGate = false;
            }
            
        }
    }

    public void WalkToSouthGate()
    {
        MainConvo.SetActive(false);
        WalkConvo.SetActive(true);
        walkedSouthGate = true;

    }

    public void WalkToBusStop()
    {
        MainConvo.SetActive(false);
        WalkConvo.SetActive(true);

        walkedBusStop = true;
        
        
    }

    public void WalkToQuadrangle()
    {
        MainConvo.SetActive(false);
        WalkConvo.SetActive(true);

        walkedQuad = true;
    }

    public void WalkToAltercation()
    {
        MainConvo.SetActive(false);
        WalkConvo.SetActive(true);

        walkedAlter = true;
    }

    public void WalkToSAC()
    {
        MainConvo.SetActive(false);
        WalkConvo.SetActive(true);

        walkedSAC = true;
    }

}
