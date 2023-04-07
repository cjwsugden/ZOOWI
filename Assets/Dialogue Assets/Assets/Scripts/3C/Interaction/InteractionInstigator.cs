using System.Collections.Generic;
using UnityEngine;

public class InteractionInstigator : MonoBehaviour
{
    //private List<Interactable> m_NearbyInteractables = new List<Interactable>();

    //public bool HasNearbyInteractables()
    //{
    //    return m_NearbyInteractables.Count != 0;
    //}

    public Interactable inter;
    bool checker = false;

    private void Update()

    
    {
        if(checker == true)
        {
            
        
            if (inter != null && (Input.GetKeyDown(KeyCode.F)))
            {
                
                inter.DoInteraction();
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        inter = other.GetComponent<Interactable>();
        checker = true;

    }

    private void OnTriggerExit(Collider other)
    {
        checker = false;  

    }

    /*private void OnTriggerStay(Collider other)
    {
        inter = other.GetComponent<Interactable>();
        
        if (inter != null && (Input.GetKeyDown(KeyCode.F)))
        {
            
            inter.DoInteraction();
        }
            

    }*/
}