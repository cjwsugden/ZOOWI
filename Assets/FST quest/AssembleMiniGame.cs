using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AssembleMiniGame : MonoBehaviour
{

    public GameObject PlayerToMove;
    public static bool stage = false;
    public GameObject preSpeech;
    public GameObject postSpeech;
    public GameObject completeMessage;

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Start is called before the first frame update
    void Start()
    {
           if(stage){
            
            preSpeech.SetActive(false);
            postSpeech.SetActive(true);  
            setZonPos();   
        }  
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
        GetComponent<AudioSource> ().Pause ();
    }
    public void LoadScene()
    {
        //saveZonPos();
        SceneManager.LoadScene(8);
        Cursor.lockState = CursorLockMode.Confined;
        

    }


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
   
    PlayerToMove.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"), PlayerPrefs.GetFloat("PlayerZ"));

    }

    public static void stageAssemble(){
        stage = true;
    }

    public void playMessage(){
        completeMessage.SetActive(true);
        Invoke("FadeOut", 3);
        Invoke("ReturnToZOOWI", 4);
    }

    public void ReturnToZOOWI()
    {
        MainManager.alertFST();
        SceneManager.LoadScene(1);
    }

         public void FadeOut()
    {
        completeMessage.gameObject.SetActive(false);

    }

    public void QuitGame ()
    {
        Application.Quit();
    }

}
