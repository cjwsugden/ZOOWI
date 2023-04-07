using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;


public class MainManager : MonoBehaviour
{

    /////////////////// QUESTS //////////////////////////
    public static bool TourQuestCompleted = false;
    public static bool RegQuestCompleted = false;
    public static bool FSTQuestCompleted = false;
    public static bool NightQuestCompleted = false;
    public static bool AstronomyQuestCompleted = false;
    public static bool SportsQuestCompleted = false;
    
    public static bool pbWin = false;
    public static bool pbDraw = false;
    public static bool pbLose = false;

    public static bool astBronze = false;
    public static bool astSilver = false;
    public static bool astGold = false;

    public GameObject TourQuest;
    public GameObject RegQuest;
    public GameObject FSTQuest;
    public GameObject NightQuest;
    public GameObject AstronomyQuest;
    public GameObject SportsQuest;
    
    //////////////// SAVE DATA ///////////////////
    public float xPos;
    public float yPos;
    public float zPos;

    public bool TourQuestCompleted1 = false;
    public bool RegQuestCompleted1 = false;
    public bool FSTQuestCompleted1 = false;
    public bool NightQuestCompleted1 = false;
    public bool AstronomyQuestCompleted1 = false;
    public bool SportsQuestCompleted1 = false;
    public bool pbWin1 = false;
    public bool pbDraw1 = false;
    public bool pbLose1 = false;


    public bool astBronze1 = false;
    public bool astSilver1 = false;
    public bool astGold1 = false;
    

    
    public static bool GameIsPaused = false;

    //////////////////// OBJECTS /////////////////////////
    public GameObject pauseMenuUI;
    public GameObject ZonObject;
    /////////////////////////////////////////////////////

    public GameObject MainMap;
    public GameObject MainMapCam;
    public GameObject idCard;
    public GameObject idCardPrompt;
    public GameObject gameSaved;

    public bool MapOpen = false;
    public bool idOpen = false;

    public GameObject PlayerToMove;

    public static bool alertedReg = false;
    public static bool alertedFST = false;
    public static bool alertedNight = false;
    public static bool alertedAst = false;
    public static bool alertedSports = false;

    public static bool alertedPBwin = false;
    public static bool alertedPBDraw = false;
    public static bool alertedPBLose = false;

    public static bool alertedBronze = false;
    public static bool alertedSilver = false;
    public static bool alertedGold = false;

    ////////////////////////  BADGES  /////////////////////////////
    public GameObject regBadge;
    public GameObject fstBadge;
    public GameObject sportsBadge;
    public GameObject nightBadge;

    public GameObject astBronzeBadge;
    public GameObject astSilverBadge;
    public GameObject astGoldBadge;

    ///////////////////////////////////////////////////////////////

    public GameObject Building_Names;
    public bool bNames;



    
    void Start()
    {

        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;


        if(!alertedReg && !alertedFST && !alertedNight && !alertedAst && !alertedSports)
        {
            if(SavingData.loadGame() != null)
            {
                LoadData();
            }
        }

        if(alertedReg)
        {
            RegQuestCompleted = true;
            tempLoadReg();
            PlayerToMove.transform.position = new Vector3(80.25f, 1.1f, 242.7f);
            alertedReg = false;
            SaveData();
        }


        if(alertedFST)
        {
            FSTQuestCompleted = true;
            tempLoadFST();
            PlayerToMove.transform.position = new Vector3(-26.6f, 0f, 109.6f);
            alertedFST = false;
            SaveData();
        }


        if(alertedNight)
        {
            NightQuestCompleted = true;
            tempLoadNight();
            PlayerToMove.transform.position = new Vector3(113.55f, 0.1f, 8.2f);
            alertedNight = false;
            SaveData();
        }


        if(alertedAst)
        {
            if(alertedBronze)
            {
                astBronze = true;
                alertedBronze = false;
            }

            if(alertedSilver)
            {
                astSilver = true;
                alertedSilver = false;
            }

            if(alertedGold)
            {
                astGold = true;
                alertedGold = false;
            }

            AstronomyQuestCompleted = true;
            tempLoadAst();
            PlayerToMove.transform.position = new Vector3(44.1f, 1.51f, 2.3f);
            alertedAst = false;
            SaveData();

        }

        

        if(alertedSports)
        {
            if(alertedPBwin)
            {
                pbWin = true;
                alertedPBwin = false;
            }

            if(alertedPBDraw)
            {
                pbDraw = true;
                alertedPBDraw = false;
            }

            if(alertedPBLose)
            {
                pbLose = true;
                alertedPBLose = false;
            }

           // SportsQuestCompleted = true;
            tempLoadPB();
            PlayerToMove.transform.position = new Vector3(212f, 0.02f, 65.4f);
            alertedSports = false;
            SaveData();

        }

        
        

        

        if(pbWin)
        {
            PigDialogue.winPawball();
        }

        if(pbLose)
        {
            PigDialogue.losePawball();
        }

        if(pbDraw)
        {
            PigDialogue.drawPawball();
        }


        

        
    }

    
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(bNames)
            {
                NamesOff();
            }
            else if(!bNames)
            {
                NamesOn();
            }
        }

        ///////////// PAUSE MENU ////////////
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else if(!MapOpen && !idOpen)
            {
                Pause();
            }
        }
        ////////////////////////////////////////

////////////////////////////////////////////////////////////////////////

        ///////////// MAIN MAP ////////////
        if(Input.GetKeyDown(KeyCode.M))
        {
            if(MapOpen)
            {
                TurnOffMap();
            }
            else if(!GameIsPaused && !idOpen)
            {
                TurnOnMap();
            }
        }
        
        
        //////////////////////////////////////// QUESTS  //////////////////////////////////////////

        if(!TourQuestCompleted)
        {
            TourQuest.SetActive(true);
        }

        badgeSwitch();

        if(TourQuestCompleted)
        {

            TourQuest.SetActive(false);

            idCardPrompt.SetActive(true);

            if(!SportsQuestCompleted)
                {
                    SportsQuest.SetActive(true);
                }

            //////////////////////////////////////////////////

                if(!RegQuestCompleted)
                {
                    RegQuest.SetActive(true);
                }

                if(!NightQuestCompleted)
                {
                    NightQuest.SetActive(true);
                }

                if(!FSTQuestCompleted)
                {
                    FSTQuest.SetActive(true);
                }


                if(!AstronomyQuestCompleted)
                {
                    AstronomyQuest.SetActive(true);
                }

            


            /////////////////////////////////////////////////////////////

            if(Input.GetKeyDown(KeyCode.X))
            {
                if(idOpen)
                {
                    TurnOffID();
                }
                else if(!GameIsPaused && !MapOpen)
                {
                    TurnOnID();
                }
            }

        }



    }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////
/*                                              QUESTS SCENES                                               */
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void BeginRegQuest()
    {
        tempSaveZonPos();
        SceneManager.LoadScene(2);
    }

    public void BeginFSTQuest()
    {
        tempSaveZonPos();
        SceneManager.LoadScene(7);
    }

    public void BeginNightQuest()
    {
        tempSaveZonPos();
        SceneManager.LoadScene(9);
    }

    public void BeginAstQuest()
    {
        tempSaveZonPos();
        SceneManager.LoadScene(12);
    }

    public void BeginPBQuest()
    {
        tempSaveZonPos();
        SceneManager.LoadScene(15);
    }


/////////////////////////////////////////////////////////////////////////////////////////////////////////////
/*                                              PAUSE MENU                                                 */
/////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        GetComponent<AudioSource> ().Play();
        HideGS();

    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.Confined;
        GetComponent<AudioSource> ().Pause();
    }

    public void NamesOn()
    {
        Building_Names.SetActive(true);
        bNames = true;
    }

    public void NamesOff()
    {
        Building_Names.SetActive(false);
        bNames = false;
    }

    public void TurnOnMap()
    {
        MainMap.SetActive(true);
        MainMapCam.SetActive(true);
        Time.timeScale = 0f;
        MapOpen = true;
        Cursor.lockState = CursorLockMode.Confined;
        //GetComponent<AudioSource> ().Stop ();
    }

    public void TurnOffMap()
    {
        MainMap.SetActive(false);
        MainMapCam.SetActive(false);
        Time.timeScale = 1f;
        MapOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
        //GetComponent<AudioSource> ().Stop ();
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
        Cursor.lockState = CursorLockMode.Locked;
    }



    public void SaveData()
    {

        xPos = PlayerToMove.transform.localPosition.x;
        yPos = PlayerToMove.transform.localPosition.y;
        zPos = PlayerToMove.transform.localPosition.z;

        TourQuestCompleted1 = TourQuestCompleted;
        RegQuestCompleted1 = RegQuestCompleted;
        FSTQuestCompleted1 = FSTQuestCompleted;
        NightQuestCompleted1 = NightQuestCompleted;
        AstronomyQuestCompleted1 = AstronomyQuestCompleted;
        SportsQuestCompleted1 = SportsQuestCompleted;

        pbWin1 = pbWin;
        pbDraw1 = pbDraw;
        pbLose1 = pbLose;

        astBronze1 = astBronze;
        astSilver1 = astSilver;
        astGold1 = astGold;


        SavingData.saveGame(this);

        Debug.Log("Saved x: " + xPos);
        Debug.Log("Saved y: " + yPos);
        Debug.Log("Saved z: " + zPos);

    }

    public void LoadData()
    {


        SaveProfile data = SavingData.loadGame();

        if(data != null)
        {
            xPos = data.xPos;
            yPos = data.yPos;
            zPos = data.zPos;

            TourQuestCompleted = data.TourQuestCompleted;
            RegQuestCompleted = data.RegQuestCompleted;
            FSTQuestCompleted = data.FSTQuestCompleted;
            NightQuestCompleted = data.NightQuestCompleted;
            AstronomyQuestCompleted = data.AstronomyQuestCompleted;
            SportsQuestCompleted = data.SportsQuestCompleted;

            pbWin = data.pbWin;
            pbDraw = data.pbDraw;
            pbLose = data.pbLose;

            astBronze = data.astBronze;
            astSilver = data.astSilver;
            astGold = data.astGold;
        }


        

        PlayerToMove.transform.position = new Vector3(xPos, yPos, zPos);

        Debug.Log("Loaded x: " + xPos);
        Debug.Log("Loaded y: " + yPos);
        Debug.Log("Loaded z: " + zPos);

    }


    int i = 0;

    public void MutedFunction()
    {
        if(i == 0)
        {
            AudioListener.volume = 0;
            i++;
        }

        else
        {
            AudioListener.volume = 1;
            i = 0;
        }

    }


    public void ReturnToMenu ()
    {

        SaveData();
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

    }


    public void QuitGame ()
    {
        Application.Quit();
    }
/////////////////////////////////////////////////////////////////////////////////////////////////////////////
/*                                            PAUSE MENU END                                               */
/////////////////////////////////////////////////////////////////////////////////////////////////////////////


    public void tempSaveZonPos()
    {
  
        /*PlayerPrefs.SetFloat("PlayerX1", PlayerToMove.transform.localPosition.x);
        PlayerPrefs.SetFloat("PlayerY1", PlayerToMove.transform.localPosition.y);
        PlayerPrefs.SetFloat("PlayerZ1", PlayerToMove.transform.localPosition.z);*/
        PlayerPrefs.SetInt("TourQuest", (TourQuestCompleted ? 1 : 0));
        PlayerPrefs.SetInt("RegQuest", (RegQuestCompleted ? 1 : 0));
        PlayerPrefs.SetInt("FSTQuest", (FSTQuestCompleted ? 1 : 0));
        PlayerPrefs.SetInt("NightQuest", (NightQuestCompleted ? 1 : 0));
        PlayerPrefs.SetInt("AstQuest", (AstronomyQuestCompleted ? 1 : 0));
        PlayerPrefs.SetInt("PBQuest", (SportsQuestCompleted ? 1 : 0));

        PlayerPrefs.SetInt("AstBronze", (astBronze ? 1 : 0));
        PlayerPrefs.SetInt("AstSilver", (astSilver ? 1 : 0));
        PlayerPrefs.SetInt("AstGold", (astGold ? 1 : 0));

        PlayerPrefs.SetInt("PBwin", (pbWin ? 1 : 0));
        PlayerPrefs.SetInt("PBdraw", (pbDraw ? 1 : 0));
        PlayerPrefs.SetInt("PBloss", (pbLose ? 1 : 0));

    }

    public void tempLoadReg()
    {
 
       
            //PlayerToMove.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX1"), PlayerPrefs.GetFloat("PlayerY1"), PlayerPrefs.GetFloat("PlayerZ1"));

            TourQuestCompleted = (PlayerPrefs.GetInt("TourQuest") != 0);
            //RegQuestCompleted = (PlayerPrefs.GetInt("RegQuest") != 0);
            FSTQuestCompleted = (PlayerPrefs.GetInt("FSTQuest") != 0);
            NightQuestCompleted = (PlayerPrefs.GetInt("NightQuest") != 0);
            AstronomyQuestCompleted = (PlayerPrefs.GetInt("AstQuest") != 0);
            SportsQuestCompleted = (PlayerPrefs.GetInt("PBQuest") != 0);

            astBronze = (PlayerPrefs.GetInt("AstBronze") != 0);
            astSilver = (PlayerPrefs.GetInt("AstSilver") != 0);
            astGold = (PlayerPrefs.GetInt("AstGold") != 0);

            pbWin = (PlayerPrefs.GetInt("PBwin") != 0);
            pbDraw = (PlayerPrefs.GetInt("PBdraw") != 0);
            pbLose = (PlayerPrefs.GetInt("PBloss") != 0);


        
    }

    public void tempLoadFST()
    {
 
        
            //PlayerToMove.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX1"), PlayerPrefs.GetFloat("PlayerY1"), PlayerPrefs.GetFloat("PlayerZ1"));

            TourQuestCompleted = (PlayerPrefs.GetInt("TourQuest") != 0);
            RegQuestCompleted = (PlayerPrefs.GetInt("RegQuest") != 0);
            //FSTQuestCompleted = (PlayerPrefs.GetInt("FSTQuest") != 0);
            NightQuestCompleted = (PlayerPrefs.GetInt("NightQuest") != 0);
            AstronomyQuestCompleted = (PlayerPrefs.GetInt("AstQuest") != 0);
            SportsQuestCompleted = (PlayerPrefs.GetInt("PBQuest") != 0);

            astBronze = (PlayerPrefs.GetInt("AstBronze") != 0);
            astSilver = (PlayerPrefs.GetInt("AstSilver") != 0);
            astGold = (PlayerPrefs.GetInt("AstGold") != 0);

            pbWin = (PlayerPrefs.GetInt("PBwin") != 0);
            pbDraw = (PlayerPrefs.GetInt("PBdraw") != 0);
            pbLose = (PlayerPrefs.GetInt("PBloss") != 0);


        
    }

    public void tempLoadNight()
    {
 
        
            //PlayerToMove.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX1"), PlayerPrefs.GetFloat("PlayerY1"), PlayerPrefs.GetFloat("PlayerZ1"));

            TourQuestCompleted = (PlayerPrefs.GetInt("TourQuest") != 0);
            RegQuestCompleted = (PlayerPrefs.GetInt("RegQuest") != 0);
            FSTQuestCompleted = (PlayerPrefs.GetInt("FSTQuest") != 0);
            //NightQuestCompleted = (PlayerPrefs.GetInt("NightQuest") != 0);
            AstronomyQuestCompleted = (PlayerPrefs.GetInt("AstQuest") != 0);
            SportsQuestCompleted = (PlayerPrefs.GetInt("PBQuest") != 0);

            astBronze = (PlayerPrefs.GetInt("AstBronze") != 0);
            astSilver = (PlayerPrefs.GetInt("AstSilver") != 0);
            astGold = (PlayerPrefs.GetInt("AstGold") != 0);

            pbWin = (PlayerPrefs.GetInt("PBwin") != 0);
            pbDraw = (PlayerPrefs.GetInt("PBdraw") != 0);
            pbLose = (PlayerPrefs.GetInt("PBloss") != 0);


    }


    public void tempLoadAst()
    {
 

            //PlayerToMove.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX1"), PlayerPrefs.GetFloat("PlayerY1"), PlayerPrefs.GetFloat("PlayerZ1"));

            TourQuestCompleted = (PlayerPrefs.GetInt("TourQuest") != 0);
            RegQuestCompleted = (PlayerPrefs.GetInt("RegQuest") != 0);
            FSTQuestCompleted = (PlayerPrefs.GetInt("FSTQuest") != 0);
            NightQuestCompleted = (PlayerPrefs.GetInt("NightQuest") != 0);
            //AstronomyQuestCompleted = (PlayerPrefs.GetInt("AstQuest") != 0);
            SportsQuestCompleted = (PlayerPrefs.GetInt("PBQuest") != 0);
           
           // PlayerPrefs.SetInt("AstBronze", (astBronze ? 1 : 0));
            //PlayerPrefs.SetInt("AstSilver", (astSilver ? 1 : 0));
            //PlayerPrefs.SetInt("AstGold", (astGold ? 1 : 0));

            pbWin = (PlayerPrefs.GetInt("PBwin") != 0);
            pbDraw = (PlayerPrefs.GetInt("PBdraw") != 0);
            pbLose = (PlayerPrefs.GetInt("PBloss") != 0);


    }


    public void tempLoadPB()
    {
 
            //PlayerToMove.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX1"), PlayerPrefs.GetFloat("PlayerY1"), PlayerPrefs.GetFloat("PlayerZ1"));

            TourQuestCompleted = (PlayerPrefs.GetInt("TourQuest") != 0);
            RegQuestCompleted = (PlayerPrefs.GetInt("RegQuest") != 0);
            FSTQuestCompleted = (PlayerPrefs.GetInt("FSTQuest") != 0);
            NightQuestCompleted = (PlayerPrefs.GetInt("NightQuest") != 0);
            AstronomyQuestCompleted = (PlayerPrefs.GetInt("AstQuest") != 0);
            //SportsQuestCompleted = (PlayerPrefs.GetInt("PBQuest") != 0);
           
            astBronze = (PlayerPrefs.GetInt("AstBronze") != 0);
            astSilver = (PlayerPrefs.GetInt("AstSilver") != 0);
            astGold = (PlayerPrefs.GetInt("AstGold") != 0);

            //pbWin = (PlayerPrefs.GetInt("PBwin") != 0);
            //pbDraw = (PlayerPrefs.GetInt("PBdraw") != 0);
            //pbLose = (PlayerPrefs.GetInt("PBloss") != 0);

    }

    public static void alertReg()
    {
        alertedReg = true;
    }

    public static void alertFST()
    {
        alertedFST = true;
    }

    public static void alertNight()
    {
        alertedNight = true;
    }

    public static void alertAst()
    {
        alertedAst = true;
    }

    public static void alertSports()
    {
        alertedSports = true;
    }

    public static void alertPBwin()
    {
        alertedPBwin = true;
    }

    public static void alertPBdraw()
    {
        alertedPBDraw = true;
    }

    public static void alertPBlose()
    {
        alertedPBLose = true;
    }



    public void CompleteTourQuest()
    {
        TourQuestCompleted = true;
        
    }


     public void badgeSwitch()
    {
        if(RegQuestCompleted)
        {
            regBadge.SetActive(true);
        }

        if(!RegQuestCompleted)
        {
            regBadge.SetActive(false);
        }

        //////////////////////////////

        if(FSTQuestCompleted)
        {
            fstBadge.SetActive(true);
        }

        if(!FSTQuestCompleted)
        {
            fstBadge.SetActive(false);
        }

        //////////////////////////////

        if(pbWin || pbDraw || pbLose)
        {
            sportsBadge.SetActive(true);
        }

        if(!pbWin && !pbDraw && !pbLose)
        {
            sportsBadge.SetActive(false);
        }

        ///////////////////////////////

        if(NightQuestCompleted)
        {
            nightBadge.SetActive(true);
        }

        if(!NightQuestCompleted)
        {
            nightBadge.SetActive(false);
        }

        //////////////////////////////

        if(astBronze)
        {
            astBronzeBadge.SetActive(true);
        }

        if(!astBronze)
        {
            astBronzeBadge.SetActive(false);
        }

        ////////////////////////////////

        if(astSilver)
        {
            astSilverBadge.SetActive(true);
        }

        if(!astSilver)
        {
            astSilverBadge.SetActive(false);
        }

        ////////////////////////////

        if(astGold)
        {
            astGoldBadge.SetActive(true);
        }

        if(!astGold)
        {
            astGoldBadge.SetActive(false);
        }

    }

    public static void alertBronze()
    {
        alertedBronze = true;
    }

    public static void alertSilver()
    {
        alertedSilver = true;
    }
    
    public static void alertGold()
    {
        alertedGold = true;
    }

    public void ShowGS()
    {
        gameSaved.SetActive(true);
        
    }



    public void HideGS()
    {
        gameSaved.SetActive(false);
    }






    




}



