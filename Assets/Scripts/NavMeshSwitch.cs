using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshSwitch : MonoBehaviour
{

    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNavmesh()
    {
        agent.enabled = true;
    }

    public void OffNavmesh()
    {
        agent.enabled = false;
    }
}
