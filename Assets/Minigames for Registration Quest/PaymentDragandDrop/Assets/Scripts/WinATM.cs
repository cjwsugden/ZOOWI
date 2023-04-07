using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinATM : MonoBehaviour
{
    private int pointsToWin;
    public GameObject myParts;
    private int currentPoints;
    // Start is called before the first frame update
    void Start()
    {
        pointsToWin = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPoints > pointsToWin)
        {
            transform.GetChild(0).gameObject.SetActive(true);

        }
        
    }

    public void AddPoints(int i){
        if(i == 1){
            currentPoints = currentPoints +1;
            Debug.Log(currentPoints);
        }

        if(i == 5){
            currentPoints = currentPoints +5;
            Debug.Log(currentPoints);
        }

        if(i == 10){
            currentPoints = currentPoints +10;
        Debug.Log(currentPoints);
        }

        if(i == 20){
            currentPoints = currentPoints +20;
       Debug.Log(currentPoints);
        }


        if(i == 50){
            currentPoints = currentPoints +50;
        Debug.Log(currentPoints);
        }

        if(i == 100){
            currentPoints = currentPoints +100;
        Debug.Log(currentPoints);
        }

        Debug.Log(currentPoints);
    }
}
