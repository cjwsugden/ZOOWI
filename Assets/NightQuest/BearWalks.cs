using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BearWalks : MonoBehaviour
{

    public Transform AltercationPositionBear;
    NavMeshAgent agent;
    public Animator anim;
    public bool walked = false;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(walked)
        {
            agent.destination = AltercationPositionBear.position;
            anim.SetBool("isRunning", true);
            if(agent.transform.position.x == AltercationPositionBear.transform.position.x && agent.transform.position.z == AltercationPositionBear.transform.position.z)
            {
                anim.SetBool("isRunning", false);
                walked = false;
            }
            
        }
    }

    public void WalkToAltercationBear()
    {
        walked = true;
    }
}
