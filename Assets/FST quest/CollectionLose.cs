using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CollectionLose : MonoBehaviour
{
    public GameObject timeDisplay;
    public int seconds = 10;
    public bool deductingTime;
    public GameObject GameOver;
    public GameObject CoinCollector;
    public GameObject GameGUI;
    public GameObject Globals; 

    void Update()
    {
        if (deductingTime == false)
        {
            deductingTime = true;
            StartCoroutine(DeductSecond());
        }

        if (seconds == 0)
        {
           failQuest();
        }

        
    }

    IEnumerator DeductSecond()
    {

        yield return new WaitForSeconds(1);
        seconds -= 1;
        timeDisplay.GetComponent<TMP_Text>().text = "Time rem: " + seconds;
        deductingTime = false;
    }

     public void FadeOut()
    {
        GameOver.gameObject.SetActive(false);

    }

    public void LoadScene()
    {
        SceneManager.LoadScene(7);

    }

    public void failQuest(){
            GameOver.gameObject.SetActive(true);
            CoinCollector.gameObject.SetActive(false);
            GameGUI.gameObject.SetActive(false);
            Globals.gameObject.SetActive(false);
            Invoke("FadeOut", 2);
            Invoke("LoadScene", 3);
            CollectionWin.coinCount = 0;

    }


}
