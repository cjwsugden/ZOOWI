using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuScript : MonoBehaviour
{

    public GameObject LoadMenuUI;
    public GameObject loadFailUI;
    //public AudioClip MainMusic;


    void Start()
    {
        //Time.timeScale = 0f;
        //GetComponent<AudioSource> ().playOnAwake = true;
       //GetComponent<AudioSource> ().clip = MainMusic;
       Cursor.lockState = CursorLockMode.Confined;


    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void activateWarning()
    {
        LoadMenuUI.SetActive(true);
    }

    public void deActivateWarning()
    {
        LoadMenuUI.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void LoadGame()
    {
        if(SavingData.loadGame() == null)
        {
            loadFailUI.SetActive(true);
        }

        else
        {
            SceneManager.LoadScene(1);
            Cursor.lockState = CursorLockMode.Locked;
        }
        
    }

    public void eraseSave()
    {

        MainManager.TourQuestCompleted = false;
        MainManager.RegQuestCompleted = false;
        MainManager.FSTQuestCompleted = false;
        MainManager.NightQuestCompleted = false;
        MainManager.AstronomyQuestCompleted = false;
        MainManager.SportsQuestCompleted = false;
        
        MainManager.pbWin = false;
        MainManager.pbDraw = false;
        MainManager.pbLose = false;

        MainManager.astBronze = false;
        MainManager.astSilver = false;
        MainManager.astGold = false;

        string path = Application.persistentDataPath + "/zoowisave.zon";
        File.Delete(path);
    }

    public void deActivateLoadFail()
    {
        loadFailUI.SetActive(false);
    }



    public void QuitGame ()
    {
        Application.Quit();
    }

}
