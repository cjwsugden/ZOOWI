using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class NightQuestManager : MonoBehaviour
{

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/*                                                              BEACONS                                                                     */
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public GameObject kbMain;
    public GameObject kbAfterGuide;
    public GameObject kbAfterWater;
    public GameObject kbAfterCards;
    public GameObject kbAltercation;
    public GameObject kbAfterAltercation;

    public GameObject PlayerToMove;
    public GameObject NPCToMove;

    public GameObject KiranMain;
    public GameObject AfterCards;
    public GameObject AfterWater;

    public static bool water = false;
    public static bool cards = false;
    public static bool alerted = false;

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;


    // Start is called before the first frame update
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        //setZonPos();
        setKiranPos();
        
        if(water && !cards)
        {
            KiranMain.SetActive(false);
            AfterWater.SetActive(true);
            PlayerToMove.transform.position = new Vector3(68.45f, 1.6f, -8.2f);
        }
 ////////////////////////////////////////////////////////////////////////       
        if(!water && cards)
        {
            KiranMain.SetActive(false);
            AfterCards.SetActive(true);
            PlayerToMove.transform.position = new Vector3(113.89f, 0f, 7.6f);
        }

        water = false;
        cards = false;
        alerted = false;

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        GetComponent<AudioSource> ().Play ();

    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.Confined;
        GetComponent<AudioSource> ().Pause();
    }


//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/*                                                          BEACON FUNCTIONS                                                                */
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void KBMainon()
    {
        kbMain.SetActive(true);
    }

    public void KBMainoff()
    {
        kbMain.SetActive(false);
    }

/////////////////////////////////////////////

    public void KBAfterGuideOn()
    {
        kbAfterGuide.SetActive(true);
    }

    public void KBAfterGuideOff()
    {
        kbAfterGuide.SetActive(false);
    }

/////////////////////////////////////////////

    public void KBAfterWaterOn()
    {
        kbAfterWater.SetActive(true);
    }

    public void KBAfterWaterOff()
    {
        kbAfterWater.SetActive(false);
    }

/////////////////////////////////////////////

    public void KBAfterCardsOn()
    {
        kbAfterCards.SetActive(true);
    }

    public void KBAfterCardsOff()
    {
        kbAfterCards.SetActive(false);
    }

/////////////////////////////////////////////

    public void KBAltercationOn()
    {
        kbAltercation.SetActive(true);
    }

    public void KBAltercationOff()
    {
        kbAltercation.SetActive(false);
    }

/////////////////////////////////////////////

    public void KBAfterAltercationOn()
    {
        kbAfterAltercation.SetActive(true);
    }

    public void KBAfterAltercationOff()
    {
        kbAfterAltercation.SetActive(false);
    }

/////////////////////////////////////////////

    public void saveZonPos()
    {

        PlayerPrefs.SetFloat("zonNQX", PlayerToMove.transform.localPosition.x);
        PlayerPrefs.SetFloat("zonNQY", PlayerToMove.transform.localPosition.y);
        PlayerPrefs.SetFloat("zonNQZ", PlayerToMove.transform.localPosition.z);
    }

    public void setZonPos()
    {
        if(alerted)
        {
            PlayerToMove.transform.position = new Vector3(PlayerPrefs.GetFloat("zonNQX"), PlayerPrefs.GetFloat("zonNQY"), PlayerPrefs.GetFloat("zonNQZ"));
        }


    }

    public void saveKiranPos()
    {

        PlayerPrefs.SetFloat("kiranNQX", NPCToMove.transform.localPosition.x);
        PlayerPrefs.SetFloat("kiranNQY", NPCToMove.transform.localPosition.y);
        PlayerPrefs.SetFloat("kiranNQZ", NPCToMove.transform.localPosition.z);
    }

    public void setKiranPos()
    {
        if(alerted)
        {
            NPCToMove.transform.position = new Vector3(PlayerPrefs.GetFloat("kiranNQX"), PlayerPrefs.GetFloat("kiranNQY"), PlayerPrefs.GetFloat("kiranNQZ"));
        }


    }

    public void startFPSGame()

    {
        saveZonPos();
        saveKiranPos();
        Cursor.lockState = CursorLockMode.Locked;
        switchAlert();
        switchWater();
        SceneManager.LoadScene(10);
    }

    public void startCardGame()
    {
        saveZonPos();
        saveKiranPos();
        Cursor.lockState = CursorLockMode.Confined;
        switchAlert();
        switchCards();
        SceneManager.LoadScene(11);
    }

    public void ReturnToZOOWI()
    {
        MainManager.alertNight();
        Cursor.lockState = CursorLockMode.Locked;
        
        SceneManager.LoadScene(1);
    }



    public static void switchAlert()
    {
        alerted = true;
    }

    public static void switchWater()
    {
        water = true;
    }

    public static void switchCards()
    {
        cards = true;
    }


    public void QuitGame ()
    {
        Application.Quit();
    }

}
