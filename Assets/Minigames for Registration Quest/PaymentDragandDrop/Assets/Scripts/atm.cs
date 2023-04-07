using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using UnityEngine.UI;

using TMPro;

public class atm : MonoBehaviour
{


    public GameObject Money100;
    public GameObject Money5;
    public GameObject Money50;
    public GameObject Money20;
    public GameObject Money1;
    public GameObject Money10;
    public int score = 0;
    public int limit = 1586;
    public TMP_Text ScoreText;
    public TMP_Text AmtText;
    public int amt = 1586;
    private string tag1 = "Money1";
    private string tag5 = "Money5";
    private string tag10 = "Money10";
    private string tag20= "Money20";
    private string tag50 = "Money50";
    private string tag100 = "Money100";

    public GameObject timeText;
    public GameObject timerImage;

    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject beginPanel;

    public GameObject disable1;
    public GameObject disable2;
    public GameObject disable3;
    public GameObject disable4;
    public GameObject disable5;
    public GameObject disable6;
    public GameObject disable7;
    public GameObject disable8;
    public GameObject disable9;
    public GameObject disable10;
    public GameObject disable11;
    public GameObject disable12;
    public GameObject disable13;
    public GameObject disable14;
    public GameObject disable15;
    public GameObject disable16;
    public GameObject atmObject;

    public float timeRemaining = 25;

    public bool timerIsRunning = false;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                DisplayTime(timeRemaining);
                timeText.SetActive(true);
                timerImage.SetActive(true);
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                

                //Levels[currentLevel].SetActive(false);
                //Levels[5].SetActive(true);
                //currentLevel = 0;
                timeText.SetActive(false);
                timerImage.SetActive(false);

                disable1.SetActive(false);
                disable2.SetActive(false);
                disable3.SetActive(false);
                disable4.SetActive(false);
                disable5.SetActive(false);
                disable6.SetActive(false);
                disable7.SetActive(false);
                disable8.SetActive(false);
                disable9.SetActive(false);
                disable10.SetActive(false);
                disable11.SetActive(false);
                disable12.SetActive(false);
                disable13.SetActive(false);
                disable14.SetActive(false);
                disable15.SetActive(false);
                disable16.SetActive(false);
                atmObject.GetComponent<SpriteRenderer>().enabled = false;

                losePanel.SetActive(true);
                

            }
        }



        this.ScoreText.text = score.ToString();
        this.AmtText.text = amt.ToString();
        
        if(score == limit){
            
            timeText.SetActive(false);
            timerImage.SetActive(false);
            timerIsRunning = false;

            this.ScoreText.text = "Good job!";

            disable1.SetActive(false);
            disable2.SetActive(false);
            disable3.SetActive(false);
            disable4.SetActive(false);
            disable5.SetActive(false);
            disable6.SetActive(false);
            disable7.SetActive(false);
            disable8.SetActive(false);
            disable9.SetActive(false);
            disable10.SetActive(false);
            disable11.SetActive(false);
            disable12.SetActive(false);
            disable13.SetActive(false);
            disable14.SetActive(false);
            disable15.SetActive(false);
            disable16.SetActive(false);
            atmObject.GetComponent<SpriteRenderer>().enabled = false;

            winPanel.SetActive(true);


            
            

        }

        if(score > limit){
            this.ScoreText.text = "You put too much money!";

            timeText.SetActive(false);
            timerImage.SetActive(false);
            timerIsRunning = false;

            disable1.SetActive(false);
            disable2.SetActive(false);
            disable3.SetActive(false);
            disable4.SetActive(false);
            disable5.SetActive(false);
            disable6.SetActive(false);
            disable7.SetActive(false);
            disable8.SetActive(false);
            disable9.SetActive(false);
            disable10.SetActive(false);
            disable11.SetActive(false);
            disable12.SetActive(false);
            disable13.SetActive(false);
            disable14.SetActive(false);
            disable15.SetActive(false);
            disable16.SetActive(false);
            atmObject.GetComponent<SpriteRenderer>().enabled = false;

            losePanel.SetActive(true);
        }



    }

    public void startGame()
    {
        timerIsRunning = true;
        timeRemaining = 40;

        disable1.SetActive(true);
        disable2.SetActive(true);
        disable3.SetActive(true);
        disable4.SetActive(true);
        disable5.SetActive(true);
        disable6.SetActive(true);
        disable7.SetActive(true);
        disable8.SetActive(true);
        disable9.SetActive(true);
        disable10.SetActive(true);
        disable11.SetActive(true);
        disable12.SetActive(true);
        disable13.SetActive(true);
        disable14.SetActive(true);
        disable15.SetActive(true);
        disable16.SetActive(true);
        atmObject.GetComponent<SpriteRenderer>().enabled = true;

        beginPanel.SetActive(false);

    }

    void DisplayTime(float timeToDisplay)
    {
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.GetComponent<Text>().text = string.Format("{0:00}", seconds);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        


        if(collision.gameObject.CompareTag(tag1)){
            score++;
            amt = amt -1;
            
        }

        if(collision.gameObject.CompareTag(tag5)){
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
        }


        //GameObject money = collision.gameObject.GetComponent<GameObject>();
        //score++;


        
            
    }

    public void returnToZOOWI()
    {
        AdvisingDialogue.alertZon();
        AdvisingDialogue.stage3Complete();
        Cursor.lockState = CursorLockMode.Locked;
            
        SceneManager.LoadScene(2);
    }

    public void restartATM()
    {       
        SceneManager.LoadScene(5);
    }
    




}
