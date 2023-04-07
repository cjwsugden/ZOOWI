using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class Manager : MonoBehaviour
{

    public GameObject q1b1;
    public GameObject q1b2;
    public GameObject q1b3;
    public GameObject q1b4;

    public GameObject Toggle1;
    public GameObject Toggle2;
    public GameObject Toggle3;
    public GameObject Toggle4;
    public GameObject Toggle5;
    public GameObject Toggle6;
    public GameObject Toggle7;
    public GameObject Toggle8;
    public GameObject Toggle9;

    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;
    public GameObject c5;

    public GameObject timeText;
    public GameObject timerImage;


    public GameObject[] Levels;
    //public GameObject ResetScreen,End; 

    int currentLevel;
    int choice;

    public float timeRemaining = 60;

    public bool timerIsRunning = false;

    public bool dep1 = false;
    public bool dep2 = false;
    public bool dep3 = false;
    public bool dep4 = false;

    void Start()
    {
        q1b1.GetComponent<Button>();
        q1b2.GetComponent<Button>();
        q1b3.GetComponent<Button>();
        q1b4.GetComponent<Button>();

        Toggle1.GetComponent<Toggle>();
        Toggle2.GetComponent<Toggle>();
        Toggle3.GetComponent<Toggle>();
        Toggle4.GetComponent<Toggle>();
        Toggle5.GetComponent<Toggle>();
        Toggle6.GetComponent<Toggle>();
        Toggle7.GetComponent<Toggle>();
        Toggle8.GetComponent<Toggle>();
        Toggle9.GetComponent<Toggle>();

        c1.GetComponent<Text>();
        c2.GetComponent<Text>();
        c3.GetComponent<Text>();
        c4.GetComponent<Text>();
        c5.GetComponent<Text>();



        load_Choice ();

    }

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
                Levels[currentLevel].SetActive(false);
                Levels[5].SetActive(true);
                currentLevel = 0;
                timeText.SetActive(false);
                timerImage.SetActive(false);
                

            }
        }

        if(currentLevel == 4)
        {
            timeText.SetActive(false);
            timerImage.SetActive(false);
            timerIsRunning = false;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.GetComponent<Text>().text = string.Format("{0:00}", seconds);
    }

    public void startTimer()
    {
        timerIsRunning = true;
        timeRemaining = 60;
    }

    public void correctAnswer1()
    {
        if(currentLevel + 1 != Levels.Length)
        {
            Levels[currentLevel].SetActive(false);
            currentLevel++;
            Levels[currentLevel].SetActive(true);
        }
    }

    public void wrongAnswer()
    {
        timeRemaining -= 5;
    }

    public void resetGame()
    {
        Levels[currentLevel].SetActive(true);
        Levels[5].SetActive(false);
    }



    public void populateButtonsQ1()
    {
        if(choice == 0)
        {
            q1b1.GetComponentInChildren<Text>().text = "Chemistry";
            q1b2.GetComponentInChildren<Text>().text = "Physics";
            q1b3.GetComponentInChildren<Text>().text = "Mathematics and Statistics";
            q1b4.GetComponentInChildren<Text>().text = "Computer and Information Technology";
        }

        if(choice == 1)
        {
            q1b1.GetComponentInChildren<Text>().text = "Chemical";
            q1b2.GetComponentInChildren<Text>().text = "Civil and Environmental";
            q1b3.GetComponentInChildren<Text>().text = "Mechanical and Manufacturing";
            q1b4.GetComponentInChildren<Text>().text = "Electrical and Computer";
        }

        if(choice == 2)
        {
            q1b1.GetComponentInChildren<Text>().text = "Pharmacy";
            q1b2.GetComponentInChildren<Text>().text = "Medicine";
            q1b3.GetComponentInChildren<Text>().text = "Vetinary Medicine";
            q1b4.GetComponentInChildren<Text>().text = "Nursing";
        }

        if(choice == 3)
        {
            q1b1.GetComponentInChildren<Text>().text = "Behavioural Sciences";
            q1b2.GetComponentInChildren<Text>().text = "Economics";
            q1b3.GetComponentInChildren<Text>().text = "Management Studies";
            q1b4.GetComponentInChildren<Text>().text = "Political Science";
        }

        

    }

    public void d1Selected()
    {
        dep1 = true;
    }

    public void d2Selected()
    {
        dep2 = true;
    }

    public void d3Selected()
    {
        dep3 = true;
    }

    public void d4Selected()
    {
        dep4 = true;
    }


    public void populateButtonsQ3()
    {

///////////////////////////////////////////////////////////////////////////////////////////////////////
/*                                      FST COURSES                                                  */
///////////////////////////////////////////////////////////////////////////////////////////////////////
        if(choice == 0 && dep1)
        {
            Toggle1.GetComponentInChildren<Text>().text = "CHEM1000";
            Toggle2.GetComponentInChildren<Text>().text = "POTION1000";
            Toggle3.GetComponentInChildren<Text>().text = "CHEM1001";
            Toggle4.GetComponentInChildren<Text>().text = "MATH1001";
            Toggle5.GetComponentInChildren<Text>().text = "CHEM1002";
            Toggle6.GetComponentInChildren<Text>().text = "CHEM1003";
            Toggle7.GetComponentInChildren<Text>().text = "CHEM2001";
            Toggle8.GetComponentInChildren<Text>().text = "POTION1001";
            Toggle9.GetComponentInChildren<Text>().text = "MATH1000";

            c1.GetComponent<Text>().text = "CHEM1000";
            c2.GetComponent<Text>().text = "POTION1000";
            c3.GetComponent<Text>().text = "CHEM1001";
            c4.GetComponent<Text>().text = "MATH1001";
            c5.GetComponent<Text>().text = "CHEM1002";

        }

        if(choice == 0 && dep2)
        {
            Toggle1.GetComponentInChildren<Text>().text = "PHYS1000";
            Toggle2.GetComponentInChildren<Text>().text = "PHYS1001";
            Toggle3.GetComponentInChildren<Text>().text = "MATH1000";
            Toggle4.GetComponentInChildren<Text>().text = "MATH1001";
            Toggle5.GetComponentInChildren<Text>().text = "NEWTON1001";
            Toggle6.GetComponentInChildren<Text>().text = "MATH1002";
            Toggle7.GetComponentInChildren<Text>().text = "PHYS1003";
            Toggle8.GetComponentInChildren<Text>().text = "PHYS3015";
            Toggle9.GetComponentInChildren<Text>().text = "MATH2175";

            c1.GetComponent<Text>().text = "PHYS1000";
            c2.GetComponent<Text>().text = "PHYS1001";
            c3.GetComponent<Text>().text = "MATH1000";
            c4.GetComponent<Text>().text = "MATH1001";
            c5.GetComponent<Text>().text = "NEWTON1001";
        }

        if(choice == 0 && dep3)
        {
            Toggle1.GetComponentInChildren<Text>().text = "MATH1000";
            Toggle2.GetComponentInChildren<Text>().text = "MATH1001";
            Toggle3.GetComponentInChildren<Text>().text = "MATH1002";
            Toggle4.GetComponentInChildren<Text>().text = "STAT1000";
            Toggle5.GetComponentInChildren<Text>().text = "STAT1111";
            Toggle6.GetComponentInChildren<Text>().text = "STAT1003";
            Toggle7.GetComponentInChildren<Text>().text = "MATH1003";
            Toggle8.GetComponentInChildren<Text>().text = "MATH3000";
            Toggle9.GetComponentInChildren<Text>().text = "STAT2000";

            c1.GetComponent<Text>().text = "MATH1000";
            c2.GetComponent<Text>().text = "MATH1001";
            c3.GetComponent<Text>().text = "MATH1002";
            c4.GetComponent<Text>().text = "STAT1000";
            c5.GetComponent<Text>().text = "STAT1111";
        }

        if(choice == 0 && dep4)
        {
            Toggle1.GetComponentInChildren<Text>().text = "COMP1600";
            Toggle2.GetComponentInChildren<Text>().text = "COMP1601";
            Toggle3.GetComponentInChildren<Text>().text = "INFO1600";
            Toggle4.GetComponentInChildren<Text>().text = "INFO1601";
            Toggle5.GetComponentInChildren<Text>().text = "COMP1602";
            Toggle6.GetComponentInChildren<Text>().text = "COMP1603";
            Toggle7.GetComponentInChildren<Text>().text = "COMP1604";
            Toggle8.GetComponentInChildren<Text>().text = "INFO1602";
            Toggle9.GetComponentInChildren<Text>().text = "COMP2611";

            c1.GetComponent<Text>().text = "COMP1600";
            c2.GetComponent<Text>().text = "COMP1601";
            c3.GetComponent<Text>().text = "INFO1600";
            c4.GetComponent<Text>().text = "INFO1601";
            c5.GetComponent<Text>().text = "COMP1602";
        }

///////////////////////////////////////////////////////////////////////////////////////////////////////
/*                                      ENG COURSES                                                  */
///////////////////////////////////////////////////////////////////////////////////////////////////////
        if(choice == 1 && dep1)
        {
            Toggle1.GetComponentInChildren<Text>().text = "CHEM1000";
            Toggle2.GetComponentInChildren<Text>().text = "POTION1000";
            Toggle3.GetComponentInChildren<Text>().text = "CHEM1001";
            Toggle4.GetComponentInChildren<Text>().text = "ENG1000";
            Toggle5.GetComponentInChildren<Text>().text = "ENG1001";
            Toggle6.GetComponentInChildren<Text>().text = "CHEM1003";
            Toggle7.GetComponentInChildren<Text>().text = "CHEM2001";
            Toggle8.GetComponentInChildren<Text>().text = "POTION1001";
            Toggle9.GetComponentInChildren<Text>().text = "MATH1000";

            c1.GetComponent<Text>().text = "CHEM1000";
            c2.GetComponent<Text>().text = "POTION1000";
            c3.GetComponent<Text>().text = "CHEM1001";
            c4.GetComponent<Text>().text = "ENG1000";
            c5.GetComponent<Text>().text = "ENG1001";

        }

        if(choice == 1 && dep2)
        {
            Toggle1.GetComponentInChildren<Text>().text = "PHYS1000";
            Toggle2.GetComponentInChildren<Text>().text = "CIV1000";
            Toggle3.GetComponentInChildren<Text>().text = "CIV1001";
            Toggle4.GetComponentInChildren<Text>().text = "ENG1000";
            Toggle5.GetComponentInChildren<Text>().text = "MATH1000";
            Toggle6.GetComponentInChildren<Text>().text = "MATH1002";
            Toggle7.GetComponentInChildren<Text>().text = "PHYS1003";
            Toggle8.GetComponentInChildren<Text>().text = "PHYS3015";
            Toggle9.GetComponentInChildren<Text>().text = "MATH2175";

            c1.GetComponent<Text>().text = "PHYS1000";
            c2.GetComponent<Text>().text = "CIV1000";
            c3.GetComponent<Text>().text = "CIV1001";
            c4.GetComponent<Text>().text = "ENG1000";
            c5.GetComponent<Text>().text = "MATH1000";
        }

        if(choice == 1 && dep3)
        {
            Toggle1.GetComponentInChildren<Text>().text = "MATH1000";
            Toggle2.GetComponentInChildren<Text>().text = "MECH1000";
            Toggle3.GetComponentInChildren<Text>().text = "MECH1001";
            Toggle4.GetComponentInChildren<Text>().text = "ENG1000";
            Toggle5.GetComponentInChildren<Text>().text = "PHYS1000";
            Toggle6.GetComponentInChildren<Text>().text = "STAT1003";
            Toggle7.GetComponentInChildren<Text>().text = "MATH1003";
            Toggle8.GetComponentInChildren<Text>().text = "MATH3000";
            Toggle9.GetComponentInChildren<Text>().text = "STAT2000";

            c1.GetComponent<Text>().text = "MATH1000";
            c2.GetComponent<Text>().text = "MECH1000";
            c3.GetComponent<Text>().text = "MECH1001";
            c4.GetComponent<Text>().text = "ENG1000";
            c5.GetComponent<Text>().text = "PHYS1000";
        }

        if(choice == 1 && dep4)
        {
            Toggle1.GetComponentInChildren<Text>().text = "ECNG1000";
            Toggle2.GetComponentInChildren<Text>().text = "ECNG1001";
            Toggle3.GetComponentInChildren<Text>().text = "ENG1000";
            Toggle4.GetComponentInChildren<Text>().text = "ELEC1000";
            Toggle5.GetComponentInChildren<Text>().text = "ELEC1001";
            Toggle6.GetComponentInChildren<Text>().text = "COMP1603";
            Toggle7.GetComponentInChildren<Text>().text = "COMP1604";
            Toggle8.GetComponentInChildren<Text>().text = "INFO1602";
            Toggle9.GetComponentInChildren<Text>().text = "COMP2611";

            c1.GetComponent<Text>().text = "ECNG1000";
            c2.GetComponent<Text>().text = "ECNG1001";
            c3.GetComponent<Text>().text = "ENG1000";
            c4.GetComponent<Text>().text = "ELEC1000";
            c5.GetComponent<Text>().text = "ELEC1001";
        }

///////////////////////////////////////////////////////////////////////////////////////////////////////
/*                                      MED COURSES                                                  */
///////////////////////////////////////////////////////////////////////////////////////////////////////
        if(choice == 2 && dep1)
        {
            Toggle1.GetComponentInChildren<Text>().text = "PHARM1000";
            Toggle2.GetComponentInChildren<Text>().text = "PHARM1001";
            Toggle3.GetComponentInChildren<Text>().text = "MED1000";
            Toggle4.GetComponentInChildren<Text>().text = "MED1001";
            Toggle5.GetComponentInChildren<Text>().text = "PILL1000";
            Toggle6.GetComponentInChildren<Text>().text = "PHARM1002";
            Toggle7.GetComponentInChildren<Text>().text = "MATH1000";
            Toggle8.GetComponentInChildren<Text>().text = "POTION1000";
            Toggle9.GetComponentInChildren<Text>().text = "MED1002";

            c1.GetComponent<Text>().text = "PHARM1000";
            c2.GetComponent<Text>().text = "PHARM1001";
            c3.GetComponent<Text>().text = "MED1000";
            c4.GetComponent<Text>().text = "MED1001";
            c5.GetComponent<Text>().text = "PILL1000";

        }

        if(choice == 2 && dep2)
        {
            Toggle1.GetComponentInChildren<Text>().text = "MED1000";
            Toggle2.GetComponentInChildren<Text>().text = "MED1001";
            Toggle3.GetComponentInChildren<Text>().text = "DOC1000";
            Toggle4.GetComponentInChildren<Text>().text = "HEAL1000";
            Toggle5.GetComponentInChildren<Text>().text = "DOC1001";
            Toggle6.GetComponentInChildren<Text>().text = "MATH1000";
            Toggle7.GetComponentInChildren<Text>().text = "PHYS1000";
            Toggle8.GetComponentInChildren<Text>().text = "CHEM1000";
            Toggle9.GetComponentInChildren<Text>().text = "MATH2175";

            c1.GetComponent<Text>().text = "MED1000";
            c2.GetComponent<Text>().text = "MED1001";
            c3.GetComponent<Text>().text = "DOC1000";
            c4.GetComponent<Text>().text = "HEAL1000";
            c5.GetComponent<Text>().text = "DOC1001";
        }

        
        if(choice == 2 && dep3)
        {
            Toggle1.GetComponentInChildren<Text>().text = "VET1000";
            Toggle2.GetComponentInChildren<Text>().text = "VET1001";
            Toggle3.GetComponentInChildren<Text>().text = "MED1000";
            Toggle4.GetComponentInChildren<Text>().text = "FAUNA1000";
            Toggle5.GetComponentInChildren<Text>().text = "FAUNA1001";
            Toggle6.GetComponentInChildren<Text>().text = "MED1001";
            Toggle7.GetComponentInChildren<Text>().text = "VET1002";
            Toggle8.GetComponentInChildren<Text>().text = "CHEM1000";
            Toggle9.GetComponentInChildren<Text>().text = "STAT2000";

            c1.GetComponent<Text>().text = "VET1000";
            c2.GetComponent<Text>().text = "VET1001";
            c3.GetComponent<Text>().text = "MED1000";
            c4.GetComponent<Text>().text = "FAUNA1000";
            c5.GetComponent<Text>().text = "FAUNA1001";
        }

        if(choice == 2 && dep4)
        {
            Toggle1.GetComponentInChildren<Text>().text = "MED1000";
            Toggle2.GetComponentInChildren<Text>().text = "MED1001";
            Toggle3.GetComponentInChildren<Text>().text = "NURSE1000";
            Toggle4.GetComponentInChildren<Text>().text = "HEAL1000";
            Toggle5.GetComponentInChildren<Text>().text = "NURSE1001";
            Toggle6.GetComponentInChildren<Text>().text = "HEAL1001";
            Toggle7.GetComponentInChildren<Text>().text = "MED1002";
            Toggle8.GetComponentInChildren<Text>().text = "CHEM1000";
            Toggle9.GetComponentInChildren<Text>().text = "PILL1000";

            c1.GetComponent<Text>().text = "MED1000";
            c2.GetComponent<Text>().text = "MED1001";
            c3.GetComponent<Text>().text = "NURSE1000";
            c4.GetComponent<Text>().text = "HEAL1000";
            c5.GetComponent<Text>().text = "NURSE1001";
        }

///////////////////////////////////////////////////////////////////////////////////////////////////////
/*                                        SOCIAL SCIENCE COURSES                                     */
///////////////////////////////////////////////////////////////////////////////////////////////////////

        if(choice == 3 && dep1)
        {
            Toggle1.GetComponentInChildren<Text>().text = "BEHAVE1000";
            Toggle2.GetComponentInChildren<Text>().text = "BEHAVE1001";
            Toggle3.GetComponentInChildren<Text>().text = "MANNERS1000";
            Toggle4.GetComponentInChildren<Text>().text = "MANNERS1001";
            Toggle5.GetComponentInChildren<Text>().text = "SS1000";
            Toggle6.GetComponentInChildren<Text>().text = "MATH1000";
            Toggle7.GetComponentInChildren<Text>().text = "LANG1000";
            Toggle8.GetComponentInChildren<Text>().text = "LANG1001";
            Toggle9.GetComponentInChildren<Text>().text = "BEHAVE1002";

            c1.GetComponent<Text>().text = "BEHAVE1000";
            c2.GetComponent<Text>().text = "BEHAVE1001";
            c3.GetComponent<Text>().text = "MANNERS1000";
            c4.GetComponent<Text>().text = "MANNERS1001";
            c5.GetComponent<Text>().text = "SS1000";

        }

        if(choice == 3 && dep2)
        {
            Toggle1.GetComponentInChildren<Text>().text = "ECON1000";
            Toggle2.GetComponentInChildren<Text>().text = "ECON1001";
            Toggle3.GetComponentInChildren<Text>().text = "MATH1000";
            Toggle4.GetComponentInChildren<Text>().text = "SS1000";
            Toggle5.GetComponentInChildren<Text>().text = "STAT1000";
            Toggle6.GetComponentInChildren<Text>().text = "MATH1001";
            Toggle7.GetComponentInChildren<Text>().text = "PHYS1000";
            Toggle8.GetComponentInChildren<Text>().text = "CHEM1000";
            Toggle9.GetComponentInChildren<Text>().text = "MATH2175";

            c1.GetComponent<Text>().text = "ECON1000";
            c2.GetComponent<Text>().text = "ECON1001";
            c3.GetComponent<Text>().text = "MATH1000";
            c4.GetComponent<Text>().text = "SS1000";
            c5.GetComponent<Text>().text = "STAT1000";
        }

        if(choice == 3 && dep3)
        {
            Toggle1.GetComponentInChildren<Text>().text = "SS1000";
            Toggle2.GetComponentInChildren<Text>().text = "MS1000";
            Toggle3.GetComponentInChildren<Text>().text = "MS1001";
            Toggle4.GetComponentInChildren<Text>().text = "LANG1000";
            Toggle5.GetComponentInChildren<Text>().text = "MS1002";
            Toggle6.GetComponentInChildren<Text>().text = "SS1002";
            Toggle7.GetComponentInChildren<Text>().text = "MATH1000";
            Toggle8.GetComponentInChildren<Text>().text = "CHEM1000";
            Toggle9.GetComponentInChildren<Text>().text = "STAT1000";

            c1.GetComponent<Text>().text = "SS1000";
            c2.GetComponent<Text>().text = "MS1000";
            c3.GetComponent<Text>().text = "MS1001";
            c4.GetComponent<Text>().text = "LANG1000";
            c5.GetComponent<Text>().text = "MS1002";
        }


        if(choice == 3 && dep4)
        {
            Toggle1.GetComponentInChildren<Text>().text = "POL1000";
            Toggle2.GetComponentInChildren<Text>().text = "POL1001";
            Toggle3.GetComponentInChildren<Text>().text = "SS1000";
            Toggle4.GetComponentInChildren<Text>().text = "LANG1000";
            Toggle5.GetComponentInChildren<Text>().text = "POL1002";
            Toggle6.GetComponentInChildren<Text>().text = "HEAL1000";
            Toggle7.GetComponentInChildren<Text>().text = "SS1001";
            Toggle8.GetComponentInChildren<Text>().text = "CHEM1000";
            Toggle9.GetComponentInChildren<Text>().text = "PILL1000";

            c1.GetComponent<Text>().text = "POL1000";
            c2.GetComponent<Text>().text = "POL1001";
            c3.GetComponent<Text>().text = "SS1000";
            c4.GetComponent<Text>().text = "LANG1000";
            c5.GetComponent<Text>().text = "POL1002";
        }

    }

    public void checkToggled()
    {
        if(Toggle1.GetComponent<Toggle>().isOn && Toggle2.GetComponent<Toggle>().isOn && Toggle3.GetComponent<Toggle>().isOn && 
            Toggle4.GetComponent<Toggle>().isOn && Toggle5.GetComponent<Toggle>().isOn && !Toggle6.GetComponent<Toggle>().isOn && 
            !Toggle7.GetComponent<Toggle>().isOn && !Toggle8.GetComponent<Toggle>().isOn)
        {
            correctAnswer1();
        }

        else
        {
            wrongAnswer();
        }
    }

    public void placeButtons()
    {

        System.Random r = new System.Random();
        int randomizer = r.Next(-1, 6);

        if(randomizer == 0)
        {
            ///////////////////////////////////////////////
            Toggle1.transform.localPosition = new Vector2(175, -126);
            ///////////////////////////////////////////////
            Toggle2.transform.localPosition = new Vector2(-182, 12);
            //////////////////////////////////////////////
            Toggle3.transform.localPosition = new Vector2(-182, -126);
            /////////////////////////////////////////////
            Toggle4.transform.localPosition = new Vector2(-2, -126);
            ////////////////////////////////////////////
            Toggle5.transform.localPosition = new Vector2(-2, 12);
            ///////////////////////////////////////////
            Toggle6.transform.localPosition = new Vector2(175, 12);
            //////////////////////////////////////////
            Toggle7.transform.localPosition = new Vector2(-182, -60);
            ///////////////////////////////////////////
            Toggle8.transform.localPosition = new Vector2(175, -60);
            ///////////////////////////////////////////
            Toggle9.transform.localPosition = new Vector2(-2, -60);
            ///////////////////////////////////////////
        }

        if(randomizer == 1)
        {
            ///////////////////////////////////////////////
            Toggle1.transform.localPosition = new Vector2(-182, -126);
            ///////////////////////////////////////////////
            Toggle2.transform.localPosition = new Vector2(-2, -60);
            //////////////////////////////////////////////
            Toggle3.transform.localPosition = new Vector2(-2, 12);
            /////////////////////////////////////////////
            Toggle4.transform.localPosition = new Vector2(-182, 12);
            ////////////////////////////////////////////
            Toggle5.transform.localPosition = new Vector2(175, -126);
            ///////////////////////////////////////////
            Toggle6.transform.localPosition = new Vector2(175, 12);
            //////////////////////////////////////////
            Toggle7.transform.localPosition = new Vector2(-182, -60);
            ///////////////////////////////////////////
            Toggle8.transform.localPosition = new Vector2(175, -60);
            ///////////////////////////////////////////
            Toggle9.transform.localPosition = new Vector2(-2, -126);
            ///////////////////////////////////////////
        }

        if(randomizer == 2)
        {
            ///////////////////////////////////////////////
            Toggle1.transform.localPosition = new Vector2(175, -60);
            ///////////////////////////////////////////////
            Toggle2.transform.localPosition = new Vector2(-2, -60);
            //////////////////////////////////////////////
            Toggle3.transform.localPosition = new Vector2(175, 12);
            /////////////////////////////////////////////
            Toggle4.transform.localPosition = new Vector2(-182, 12);
            ////////////////////////////////////////////
            Toggle5.transform.localPosition = new Vector2(175, -126);
            ///////////////////////////////////////////
            Toggle6.transform.localPosition = new Vector2(-2, 12);
            //////////////////////////////////////////
            Toggle7.transform.localPosition = new Vector2(-182, -60);
            ///////////////////////////////////////////
            Toggle8.transform.localPosition = new Vector2(-182, -126);
            ///////////////////////////////////////////
            Toggle9.transform.localPosition = new Vector2(-2, -126);
            ///////////////////////////////////////////
        }

        if(randomizer == 3)
        {
            ///////////////////////////////////////////////
            Toggle1.transform.localPosition = new Vector2(-2, -60);
            ///////////////////////////////////////////////
            Toggle2.transform.localPosition = new Vector2(-2, -126);
            //////////////////////////////////////////////
            Toggle3.transform.localPosition = new Vector2(-2, 12);
            /////////////////////////////////////////////
            Toggle4.transform.localPosition = new Vector2(-182, 12);
            ////////////////////////////////////////////
            Toggle5.transform.localPosition = new Vector2(-182, -60);
            ///////////////////////////////////////////
            Toggle6.transform.localPosition = new Vector2(175, 12);
            //////////////////////////////////////////
            Toggle7.transform.localPosition = new Vector2(175, -126);
            ///////////////////////////////////////////
            Toggle8.transform.localPosition = new Vector2(-182, -126);
            ///////////////////////////////////////////
            Toggle9.transform.localPosition = new Vector2(175, -60);
            ///////////////////////////////////////////
        }

        if(randomizer == 4)
        {
            ///////////////////////////////////////////////
            Toggle1.transform.localPosition = new Vector2(-2, 12);
            ///////////////////////////////////////////////
            Toggle2.transform.localPosition = new Vector2(-182, 12);
            //////////////////////////////////////////////
            Toggle3.transform.localPosition = new Vector2(-2, -60);
            /////////////////////////////////////////////
            Toggle4.transform.localPosition = new Vector2(-2, -126);
            ////////////////////////////////////////////
            Toggle5.transform.localPosition = new Vector2(175, -126);
            ///////////////////////////////////////////
            Toggle6.transform.localPosition = new Vector2(175, -60);
            //////////////////////////////////////////
            Toggle7.transform.localPosition = new Vector2(-182, -60);
            ///////////////////////////////////////////
            Toggle8.transform.localPosition = new Vector2(-182, -126);
            ///////////////////////////////////////////
            Toggle9.transform.localPosition = new Vector2(175, 12); 
            ///////////////////////////////////////////
        }

        if(randomizer == 5)
        {
            ///////////////////////////////////////////////
            Toggle1.transform.localPosition = new Vector2(-182, -60);
            ///////////////////////////////////////////////
            Toggle2.transform.localPosition = new Vector2(-182, 12);
            //////////////////////////////////////////////
            Toggle3.transform.localPosition = new Vector2(-182, -126);
            /////////////////////////////////////////////
            Toggle4.transform.localPosition = new Vector2(-2, -126);
            ////////////////////////////////////////////
            Toggle5.transform.localPosition = new Vector2(175, -126);
            ///////////////////////////////////////////
            Toggle6.transform.localPosition = new Vector2(175, -60);
            //////////////////////////////////////////
            Toggle7.transform.localPosition = new Vector2(175, 12);
            ///////////////////////////////////////////
            Toggle8.transform.localPosition = new Vector2(-2, -60);
            ///////////////////////////////////////////
            Toggle9.transform.localPosition = new Vector2(-2, 12); 
            ///////////////////////////////////////////
        }
    }

    public void gameWon()
    {
        AdvisingDialogue.alertZon();
        AdvisingDialogue.stage1Complete();
        Cursor.lockState = CursorLockMode.Locked;
        
        SceneManager.LoadScene(2);
        

    }

    public void load_Choice ()
    {
        FacultyChoice data = ChoiceTransfer.loadChoice();


        if(data != null)
        {
            choice = data._choice;
        }
        
        
    }



}
