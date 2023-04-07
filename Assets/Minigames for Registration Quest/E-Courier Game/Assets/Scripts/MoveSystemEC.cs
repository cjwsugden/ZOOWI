using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class MoveSystemEC : MonoBehaviour
{

    public GameObject correctForm;
    public GameObject removeObject;


    private bool moving;
    private bool finish;
    private float startPosX;
    private float startPosY;

    public int counter = 0;

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

        if(Mathf.Abs(this.transform.localPosition.x - correctForm.transform.localPosition.x) <= 2.5f &&
        Mathf.Abs(this.transform.localPosition.y - correctForm.transform.localPosition.y) <= 2.5f)
        {
            this.transform.position = new Vector3(correctForm.transform.position.x, correctForm.transform.position.y, correctForm.transform.position.z);
            finish = true;

            counter++;

            GameObject.Find("PointsHandler").GetComponent<WinEC>().AddPoints();
            Invoke("Disappear",0.1f);
            //Invoke("Reappear",2);
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

    /*

    private void OnTriggerEnter2D(Collider2D collision){
        


        if(collision.gameObject.CompareTag(GateFile)){
            
            
            removeObject = collision.gameObject.GetComponent<GameObject>();
            Disappear();
        }
    }
    */

        /*if(collision.gameObject.CompareTag(tag5)){
            score = score + 5;
            amt = amt - 5;
        }

        if(collision.gameObject.CompareTag(tag10)){
            score = score + 10;
            amt = amt - 10;
        }
        if(collision.gameObject.CompareTag(tag20)){
            score = score + 20;
            amt = amt - 20;
        }
        if(collision.gameObject.CompareTag(tag50)){
            score = score + 50;
            amt = amt - 50;
        }
        if(collision.gameObject.CompareTag(tag100)){
            score = score + 100;
            amt = amt - 100;
        }*/
}
