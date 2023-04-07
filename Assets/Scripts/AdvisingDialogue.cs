using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class AdvisingDialogue : MonoBehaviour
{

    public int choice;

    public static bool alerted = false;
    public static bool stg1 = false;
    public static bool stg2 = false;
    public static bool stg3 = false;

    public Vector3 pos;
    public Quaternion rot;

    public GameObject PlayerToMove;

    public GameObject FSTinfo;
    public GameObject ENGinfo;
    public GameObject Medinfo;
    public GameObject Businfo;
    public GameObject GATE;

    public GameObject FSTcourses;
    public GameObject ENGcourses;
    public GameObject Medcourses;
    public GameObject Buscourses;

    public GameObject QuestBeacon;
    public GameObject pcQB;
    public GameObject pc2QB;
    public GameObject pc3QB;
    public GameObject pc4QB;

    public GameObject timQB;
    public GameObject cocoQB;

    public GameObject cocoConvo1;
    public GameObject cocoConvo3;
    public GameObject cocoConvo5;
    public GameObject cocoConvo7;
    public GameObject timConvo1;

    public GameObject Gary;

    public GameObject idCard;
    public GameObject idCardPrompt;
    public bool idOpen = false;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    

    // Start is called before the first frame update
    void Start()
    {

        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;

        setZonPos();
        
        if(stg1 && !stg2 && !stg3)
        {
            cocoConvo1.SetActive(false);
            cocoConvo3.SetActive(true);
            GaryOff();
            cocoQB.SetActive(true);


        }
 ////////////////////////////////////////////////////////////////////////       
        if(stg1 && stg2 && !stg3)
        {
            cocoConvo1.SetActive(false);
            cocoConvo3.SetActive(false);
            cocoConvo5.SetActive(true);
            timConvo1.SetActive(true);
            GaryOff();
            
            timQB.SetActive(true);
            cocoQB.SetActive(true);

        }

        if(stg1 && stg2 && stg3)
        {
            cocoConvo1.SetActive(false);
            cocoConvo3.SetActive(false);
            cocoConvo5.SetActive(false);
            cocoConvo7.SetActive(true);
            timConvo1.SetActive(false);
            GaryOff();
            
            timQB.SetActive(false);
            cocoQB.SetActive(true);

        }

        
        alerted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
            {
                if(idOpen)
                {
                    TurnOffID();
                }
                else if(!GameIsPaused)
                {
                    TurnOnID();
                }
            }
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else if(!idOpen)
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
        //Cursor.lockState = CursorLockMode.Locked;
        if(GetComponent<AudioSource>() != null){
            GetComponent<AudioSource> ().Play ();}

    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.Confined;
        if(GetComponent<AudioSource>() != null){
            GetComponent<AudioSource> ().Pause ();}
    }

    public void TurnOnID()
    {
        idCard.SetActive(true);
        Time.timeScale = 0f;
        idOpen = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void TurnOffID()
    {
        idCard.SetActive(false);
        Time.timeScale = 1f;
        idOpen = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

//////////////////////////////////////////////////////////////////////////////////

    public void selectFST()
    {
        choice = 0;
    }

    public void selectEng()
    {
        choice = 1;
    }

    public void selectMed()
    {
        choice = 2;
    }

    public void selectBusiness()
    {
        choice = 3;
    }

////////////////////////////////////////////////////////////////////////////////    

    public void showGATE()
    {
        GATE.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void hideGATE()
    {
        GATE.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;

    }
//////////////////////////////////////////////////////////////////////////////////

    public void showInformation()
    {
        if(choice == 0)
        {
            FSTinfo.SetActive(true);
        }

        if(choice == 1)
        {
            ENGinfo.SetActive(true);
        }

        if(choice == 2)
        {
            Medinfo.SetActive(true);
        }

        if(choice == 3)
        {
            Businfo.SetActive(true);
        }

        Cursor.lockState = CursorLockMode.Confined;
    }

//////////////////////////////////////////////////////////////////////////////////

    public void hideInformation()
    {
        if(choice == 0)
        {
            FSTinfo.SetActive(false);
        }

        if(choice == 1)
        {
            ENGinfo.SetActive(false);
        }

        if(choice == 2)
        {
            Medinfo.SetActive(false);
        }

        if(choice == 3)
        {
            Businfo.SetActive(false);
        }
    }

//////////////////////////////////////////////////////////////////////////////////

    public void showCourses()
    {
        if(choice == 0)
        {
            FSTcourses.SetActive(true);
        }

        if(choice == 1)
        {
            ENGcourses.SetActive(true);
        }

        if(choice == 2)
        {
            Medcourses.SetActive(true);
        }

        if(choice == 3)
        {
            Buscourses.SetActive(true);
        }

        Cursor.lockState = CursorLockMode.Confined;
    }

//////////////////////////////////////////////////////////////////////////////////

    public void hideCourses()
    {
        if(choice == 0)
        {
            FSTcourses.SetActive(false);
        }

        if(choice == 1)
        {
            ENGcourses.SetActive(false);
        }

        if(choice == 2)
        {
            Medcourses.SetActive(false);
        }

        if(choice == 3)
        {
            Buscourses.SetActive(false);
        }

    }

    public void turnOffQuestBeacon()
    {
        QuestBeacon.SetActive(false);
    }

/////////////////////////////////////////////
    public void PCqbOn()
    {
        pcQB.SetActive(true);
    }

    public void PCqbOff()
    {
        pcQB.SetActive(false);
    }

/////////////////////////////////////////////

    public void PC2qbOn()
    {
        pc2QB.SetActive(true);
    }

    public void PC2qbOff()
    {
        pc2QB.SetActive(false);
    }

//////////////////////////////////////////////

    public void PC3qbOn()
    {
        pc3QB.SetActive(true);
    }

    public void PC3qbOff()
    {
        pc3QB.SetActive(false);
    }

//////////////////////////////////////////////

    public void PC4qbOn()
    {
        pc4QB.SetActive(true);
    }

    public void PC4qbOff()
    {
        pc4QB.SetActive(false);
    }

///////////////////////////////////////////////

    public void CocoqbOn()
    {
        cocoQB.SetActive(true);
    }

    public void CocoqbOff()
    {
        cocoQB.SetActive(false);
    }
/////////////////////////////////////////////////
    public void TimqbOn()
    {
        timQB.SetActive(true);
    }

    public void TimqbOff()
    {
        timQB.SetActive(false);
    }
//////////////////////////////////////////////////////////

    public void GaryOn()
    {
        Gary.SetActive(true);
    }

    public void GaryOff()
    {
        Gary.SetActive(false);
    }

    public void save_Choice()
    {
        ChoiceTransfer.saveChoice(this);
    }

  //////////////////////////////////////////////////////////  

    public void RegScene()
    {

        SceneManager.LoadScene(3);
        Cursor.lockState = CursorLockMode.Confined;
    }

//////////////////////////////////////////////////////////

    public void RegScene2()
    {

        SceneManager.LoadScene(4);
        Cursor.lockState = CursorLockMode.Confined;
    }

//////////////////////////////////////////////////////////

    public void RegScene3()
    {

        SceneManager.LoadScene(5);
        Cursor.lockState = CursorLockMode.Confined;
    }

//////////////////////////////////////////////////////////
    
    public void RegScene4()
    {

        SceneManager.LoadScene(6);
        Cursor.lockState = CursorLockMode.Confined;
    }

//////////////////////////////////////////////////////////

    public void saveZonPos()
    {
        //pos = PlayerToMove.transform.localPosition;
        //rot = PlayerToMove.transform.localRotation;
        //SavePosition.savePos(this);
        PlayerPrefs.SetFloat("PlayerX", PlayerToMove.transform.localPosition.x);
        PlayerPrefs.SetFloat("PlayerY", PlayerToMove.transform.localPosition.y);
        PlayerPrefs.SetFloat("PlayerZ", PlayerToMove.transform.localPosition.z);
    }

    public void setZonPos()
    {
        if(alerted)
        {
            PlayerToMove.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"), PlayerPrefs.GetFloat("PlayerZ"));
        }


    }

    public static void alertZon()
    {
        alerted = true;
    }

    public static void stage1Complete()
    {
        stg1 = true;
    }

    public static void stage2Complete()
    {
        stg2 = true;
    }

    public static void stage3Complete()
    {
        stg3 = true;
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

}
