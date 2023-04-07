using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class MoveSystemATM : MonoBehaviour
{

    public GameObject correctForm;
    public GameObject removeObject;
   
    private bool moving;
    private bool finish;
    private float startPosX;
    private float startPosY;
    

    private Vector3 resetPosition;

    // Start is called before the first frame update
    void Start()
    {
        resetPosition = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (finish == false)
        {
               if (moving)
        {
           Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
            

        }

        }
     
        
    }

    private void OnMouseDown()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            moving = true;

            
        }

        

        

    }

    private void OnMouseUp()
    {
        moving = false;
        

        if(Mathf.Abs(this.transform.localPosition.x - correctForm.transform.localPosition.x) <= 0.5f &&
        Mathf.Abs(this.transform.localPosition.y - correctForm.transform.localPosition.y) <= 0.5f)
        {
            this.transform.position = new Vector3(correctForm.transform.position.x, correctForm.transform.position.y, correctForm.transform.position.z);
            finish = true;

            

            
            Invoke("Reappear",0.1f);
             
           
        }

        else
        {
            this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
        }

    }
    private void Disappear(){
        removeObject.gameObject.SetActive(false);
    }

    private void Reappear(){
        removeObject.gameObject.SetActive(true);
        finish = false;
        this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
     
    }

    
}
