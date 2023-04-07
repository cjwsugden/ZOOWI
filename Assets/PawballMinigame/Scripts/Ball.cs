using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update

     Vector3 originalPos;




    private void Start()
    {
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
 //alternatively, just: originalPos = gameObject.transform.position;
        ResetPosition();
    }

    public void ResetPosition(){
        gameObject.transform.position = originalPos;
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
