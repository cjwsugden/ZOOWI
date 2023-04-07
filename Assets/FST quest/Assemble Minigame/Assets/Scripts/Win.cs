using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    private int pointsToWin;
    public GameObject myParts;
    public GameObject timer;
    private int currentPoints;
    // Start is called before the first frame update
    void Start()
    {
        pointsToWin = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPoints >= pointsToWin)
        {
           transform.GetChild(0).gameObject.SetActive(true);
           timer.gameObject.SetActive(false);
           Cursor.lockState = CursorLockMode.Locked;
           AssembleMiniGame.stageAssemble();
           LoadScene();
           
        }
        
    }

     public void LoadScene()
    {
        SceneManager.LoadScene(7);

    }


    public void AddPoints(){
        currentPoints++;
    }
}
