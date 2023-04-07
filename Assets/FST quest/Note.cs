using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Note : MonoBehaviour
{

    public GameObject notePad;
    //private bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
              
}
        
    

    // Update is called once per frame
    void Update(){
           if(Input.GetKeyDown(KeyCode.O)){
                //isOpen = !isOpen;
                notePad.gameObject.SetActive(true);
                }

            if(Input.GetKeyDown(KeyCode.P)){
             notePad.gameObject.SetActive(false);
             //isOpen = false;
             }
}

public void isActive(){
    notePad.gameObject.SetActive(true);
}
}
