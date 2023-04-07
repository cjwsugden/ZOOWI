using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class WinEC : MonoBehaviour
{
    private int pointsToWin = 3;
    private int currentPoints = 0;
    public GameObject winUI;
    // Start is called before the first frame update
    void Start()
    {
        //pointsToWin = myParts.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPoints >= pointsToWin)
        {
           winUI.SetActive(true);
        }
        
    }

    public void AddPoints(){
        currentPoints++;
    }

    public void ReturnToZOOWI()
    {
        MainManager.alertReg();
        //MainManager.CompleteRegQuest();
        Cursor.lockState = CursorLockMode.Locked;
        
        SceneManager.LoadScene(1);
    }


}
