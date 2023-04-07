using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using UnityEngine.SceneManagement;
using System.IO;

public class PBTimer : PBGameManager
{
    public float timeRemaining = 120;
    public bool timerIsRunning = false;
    public TMP_Text timeText;
    private GameObject defeatpanel;
    private GameObject victorypanel;
    private GameObject drawpanel;
    private int player;
    private int pc;

    private void Start()
    {
        // Starts the timer automatically
        defeatpanel = GameObject.FindGameObjectWithTag("Panel");
         defeatpanel.SetActive(false);
         victorypanel = GameObject.FindGameObjectWithTag("Panel2");
       victorypanel.SetActive(false); 
        timerIsRunning = true;
        drawpanel = GameObject.FindGameObjectWithTag("Panel3");
        drawpanel.SetActive(false);
        
    }
    void Update()
    {
        player = PBGameManager.getplayerscore();
        pc = PBGameManager.getpcscore();
        
        if (timerIsRunning)
        {
            DisplayTime(timeRemaining);
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {

                if(pc > player){
                    Cursor.lockState = CursorLockMode.Confined;
                    defeatpanel.SetActive(true); 
                    MainManager.alertSports();
                    MainManager.alertPBlose();
                    PigDialogue.losePawball();
                     
                    
                    //MainManager.PBnotInProgress();
                    
                }

                else if (player > pc){
                    victorypanel.SetActive(true);
                    Cursor.lockState = CursorLockMode.Confined;
                    MainManager.alertSports();
                    MainManager.alertPBwin();
                    PigDialogue.winPawball();

                    
                    //MainManager.PBnotInProgress();
                   
                }

                else if (player == pc){
                    drawpanel.SetActive(true);
                    Cursor.lockState = CursorLockMode.Confined;
                    MainManager.alertSports();
                    MainManager.alertPBdraw();
                    PigDialogue.drawPawball();

                    
                    //MainManager.PBnotInProgress();
                   
                }



                
               
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
    float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
    float seconds = Mathf.FloorToInt(timeToDisplay % 60);
    timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public static void scenechanger(){
        SceneManager.LoadScene(1);
    }



}