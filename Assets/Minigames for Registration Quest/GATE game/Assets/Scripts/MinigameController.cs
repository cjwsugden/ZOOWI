using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MinigameController : MonoBehaviour
{

    [SerializeField]
    public float startingTime;
    
    private float currentTime;




    [SerializeField]
    public TextMeshProUGUI timeText;
    [SerializeField]
    public int timePenalty;


    [SerializeField]
    public TMP_InputField userInputName;
    [SerializeField]
    public TextMeshProUGUI nameQuestionText;



    [SerializeField]
    public TMP_InputField userInputAddress;
    [SerializeField]
    public TextMeshProUGUI addressQuestionText;



    [SerializeField]
    public TMP_InputField userInputID;
    [SerializeField]
    public TextMeshProUGUI idQuestionText;



    [SerializeField]
    public TMP_InputField userInputSemester;
    [SerializeField]
    public TextMeshProUGUI semesterQuestionText;



    [SerializeField]
    public TMP_InputField userInputDegree;
    [SerializeField]
    public TextMeshProUGUI degreeQuestionText;




    private string userResponseName;
    private string userResponseAddress;
    private string userResponseID;
    private string userResponseSemester;
    private string userResponseDegree;

    [SerializeField]
    public string expectedName;
    [SerializeField]
    public string expectedAddress;
    [SerializeField]
    public string expectedID;
    [SerializeField]
    public string expectedSemester;
    [SerializeField]
    public string expectedDegree;



    private bool winner;
    
    public GameObject winnerScreen;
    public GameObject loserScreen;

    // Start is called before the first frame update
    void Start()
    {
        winnerScreen.SetActive(false);
        loserScreen.SetActive(false);

        timeText.text   = startingTime.ToString();
        currentTime     = startingTime;

        nameQuestionText.text       = "Enter Name (all common):";
        addressQuestionText.text    = "Enter D.O.B (dd/mm/yyyy):";
        idQuestionText.text         = "Enter ID:";
        semesterQuestionText.text   = "Enter Email (all common):";
        degreeQuestionText.text     = "Enter Species (all common):";
    }

    // Update is called once per frame
    void Update()
    {
        if(winner != true)
        {
            currentTime     -= 1 * Time.deltaTime;
            timeText.text   = currentTime.ToString("0");

            if(currentTime <= 0)
            {
                currentTime = 0;
                winner = false;
                loserScreen.SetActive(true);
            }
        }
    }



    public void onButtonPress()
    {

        acceptUserInput();

        if(!verifyName())
        {
            currentTime -= timePenalty;
            userInputName.text = "";
        }

        if(!verifyAddress())
        {
            currentTime -= timePenalty;
            userInputAddress.text = "";
        }

        if(!verifyID())
        {
            currentTime -= timePenalty;
            userInputID.text = "";
        }

        if(!verifySemester())
        {
            currentTime -= timePenalty;
            userInputSemester.text = "";
        }

        if(!verifyDegree())
        {
            currentTime -= timePenalty;
            userInputDegree.text = "";
        }

        if(verifyName() && verifyAddress() && verifyID() && verifySemester() && verifyDegree())
        {
            winner = true;
            winnerScreen.SetActive(true);
            
        }

    }



    void acceptUserInput()
    {
        
        userResponseName     = userInputName.text;
        userResponseAddress  = userInputAddress.text;
        userResponseID       = userInputID.text;
        userResponseSemester = userInputSemester.text;
        userResponseDegree   = userInputDegree.text;

    }


    public bool verifyName()
    {
        if(userResponseName == expectedName)
        {
            return true;
        }

        return false;
    }

    public bool verifyAddress()
    {
        if(userResponseAddress == expectedAddress)
        {
            return true;
        }
        return false;
    }

    public bool verifyID()
    {
        if(userResponseID == expectedID)
        {
            return true;
        }
        return false;
    }

    public bool verifySemester()
    {
        if(userResponseSemester == expectedSemester)
        {
            return true;
        }
        return false;
    }

    public bool verifyDegree()
    {
        if(userResponseDegree == expectedDegree)
        {
            return true;
        }
        return false;
    }
}
