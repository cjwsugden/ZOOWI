using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CollectionWin : MonoBehaviour
{
    public GameObject textScore;
    public static int coinCount;
    public GameObject GameWin;
    public GameObject CoinCollector;
    public GameObject GameGUI;
    public GameObject Globals;
    public GameObject finalPart;
    public GameObject table;
    public GameObject preSpeech;
    public GameObject postSpeech;
    public GameObject waypointTechy;
 

    
    void Update()
    {
         textScore.GetComponent<TMP_Text>().text = "Collected: " + coinCount + "/5";
    
    if (coinCount == 5)
        {
           winQuest();
        }

        finalPartFadeOut();


    }

       public void FadeOut()
    {
        GameWin.gameObject.SetActive(false);

    }
      public void LoadScene()
    {
        SceneManager.LoadScene(0);

    }

        public void finalPartFadeOut()
    {
            if (coinCount == 4){
            finalPart.gameObject.SetActive(true);
       
            if(finalPart != null){
            Object.Destroy(finalPart,3); 
            }
        }

    }

    public void winQuest(){
            GameWin.gameObject.SetActive(true);
            CoinCollector.gameObject.SetActive(false);
            GameGUI.gameObject.SetActive(false);
            Globals.gameObject.SetActive(false);
            preSpeech.gameObject.SetActive(false);
            postSpeech.gameObject.SetActive(true);
            waypointTechy.gameObject.SetActive(true);
            Invoke("FadeOut", 2);
            //Invoke("LoadScene", 3);
            coinCount = 0;
        
    }

    public void activeTable(){
        table.gameObject.SetActive(true);
    }

    
}
